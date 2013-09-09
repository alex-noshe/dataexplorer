﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Importers
{
    public class DataTypeDetector : IDataTypeDetector
    {
        public Type Detect(IEnumerable<string> values)
        {
           if (IsBoolean(values))
                return typeof(Boolean);

            if (IsDateTime(values))
                return typeof(DateTime);

            if (IsInteger(values))
                return typeof(Int32);

            if (IsFloat(values))
                return typeof(Double);

            return typeof(String);
        }

        private bool IsBoolean(IEnumerable<string> values)
        {
            bool outBoolean;
            return values
                .Where(p => p != string.Empty)
                .All(p => Boolean.TryParse(p, out outBoolean));
        }

        private bool IsDateTime(IEnumerable<string> values)
        {
            DateTime outDateTime;
            return values
                .Where(p => p != string.Empty)
                .All(p => DateTime.TryParse(p, out outDateTime));
        }

        private bool IsInteger(IEnumerable<string> values)
        {
            int outInteger;
            return values
                .Where(p => p != string.Empty)
                .All(p => Int32.TryParse(p, out outInteger));
        }

        private bool IsFloat(IEnumerable<string> values)
        {
            double outDouble;
            return values
                .Where(p => p != string.Empty)
                .All(p => Double.TryParse(p, out outDouble));
        }
    }
}