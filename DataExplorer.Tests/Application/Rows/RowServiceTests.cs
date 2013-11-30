﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Rows;
using DataExplorer.Domain.Rows;
using DataExplorer.Tests.Domain.Rows;
using Moq;
using NUnit.Framework;

namespace DataExplorer.Tests.Application.Rows
{
    [TestFixture]
    public class RowServiceTests
    {
        private RowService _service;
        private Mock<IRowRepository> _mockRepository;
        private Mock<IApplicationStateService> _mockStateService;
        private Mock<IEventBus> _mockEventBus;
        private List<Row> _rows;
        private Row _row;

        [SetUp]
        public void SetUp()
        {
            _row = new RowBuilder().Build();
            _rows = new List<Row> { _row };

            _mockRepository = new Mock<IRowRepository>();
            _mockRepository.Setup(p => p.GetAll()).Returns(_rows);

            _mockStateService = new Mock<IApplicationStateService>();
            _mockStateService.Setup(p => p.GetSelectedRows()).Returns(_rows);
            
            _mockEventBus = new Mock<IEventBus>();
            
            _service = new RowService(
                _mockRepository.Object,
                _mockStateService.Object,
                _mockEventBus.Object);
        }

        [Test]
        public void TestGetAllShouldReturnAllRows()
        {
            var results = _service.GetAll();
            Assert.That(results.Single(), Is.EqualTo(_row));
        }

        [Test]
        public void TestSetSelectedRowsShouldSelectRows()
        {
            _service.SetSelectedRows(_rows);
            _mockStateService.Verify(p => p.SetSelectedRows(_rows), Times.Once());
        }

        [Test]
        public void TestSetSelectedRowsShouldRaiseSelectedRowsChangedEvent()
        {
            _service.SetSelectedRows(_rows);
            _mockEventBus.Verify(p => p.Raise(It.IsAny<SelectedRowsChangedEvent>()), Times.Once());
        }

        [Test]
        public void TestGetSelectedRowsShouldGetSelectedRows()
        {
            var results = _service.GetSelectedRows();
            Assert.That(results.Single(), Is.EqualTo(_row));
        }

        [Test]
        public void TestGetSelectedRowShouldReturnNullIfNoSelectedRows()
        {
            _rows.Clear();
            var result = _service.GetSelectedRow();
            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestGetSelectedRowShouldReturnLastSelectedRow()
        {
            var lastRow = new RowBuilder().Build();
            _rows.Add(lastRow);
            var result = _service.GetSelectedRow();
            Assert.That(result, Is.EqualTo(lastRow));
        }
    }
}
