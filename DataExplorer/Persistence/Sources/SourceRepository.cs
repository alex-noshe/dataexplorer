﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Domain.Sources;

namespace DataExplorer.Persistence.Sources
{
    public class SourceRepository : ISourceRepository
    {
        private readonly IDataContext _context;

        public SourceRepository(IDataContext context)
        {
            _context = context;
        }

        public bool HasSource<T>() where T : ISource
        {
            return _context.Sources.ContainsKey(typeof(T));
        }

        public T GetSource<T>() where T : ISource
        {
            return (T) _context.Sources[typeof(T)];
        }

        public void SetSource<T>(T source) where T : ISource
        {
            _context.Sources[typeof(T)] = source;
        }
    }
}
