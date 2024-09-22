using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze1
{
    public class Units : IEnumerable<Unit>
    {
        private List<Unit> _units = new List<Unit>();

        public void Add(Unit unit)
        {
            _units.Add(unit);
        }

        public IEnumerator GetEnumerator()
        {
            return _units.GetEnumerator();
        }

        public void Remove(Unit unit)
        {
            _units.Remove(unit);
        }

        IEnumerator<Unit> IEnumerable<Unit>.GetEnumerator()
        {
            for (int i = 0; i < _units.Count; i++)
            {
                yield return _units[i];
            }
        }
    }
}
