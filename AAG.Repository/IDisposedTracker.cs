using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAG.Repository
{
    public interface IDisposedTracker
    {
        bool IsDisposed { get; set; }
    }
}
