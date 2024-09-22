using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze1
{
    internal class UnitsEnumerator : IEnumerator<Unit>
    {
        private List<Unit> _units;
        private int _position = -1;

        public UnitsEnumerator(List<Unit> units)
        {
            _units = units;
        }

        public object Current
        {
            get
            {
                return _units[_position];
            }
        }

        Unit IEnumerator<Unit>.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (_position < _units.Count - 1)
            {
                _position++;
                return true;
            }
            return false;
        }

        public void Reset() 
        { 
            _position = -1;
        }
    }
}
