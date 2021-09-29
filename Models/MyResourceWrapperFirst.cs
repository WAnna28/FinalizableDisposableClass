using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizableDisposableClass.Models
{
    // Dispose() method has been updated to call GC.SuppressFinalize(), which informs
    // the runtime that it is no longer necessary to call the destructor when this object is garbage collected, given
    // that the unmanaged resources have already been freed via the Dispose() logic.
    public class MyResourceWrapperFirst : IDisposable
    {
        // The garbage collector will call this method if the object user forgets to call Dispose().
        ~MyResourceWrapperFirst()
        {
            // Clean up any internal unmanaged resources.
            // Do **not** call Dispose() on any managed objects.
        }

        // The object user will call this method to clean up resources ASAP.
        public void Dispose()
        {
            // Clean up unmanaged resources here.
            // Call Dispose() on other contained disposable objects.
            // No need to finalize if user called Dispose(), so suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
