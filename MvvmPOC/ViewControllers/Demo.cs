using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace MvvmPOC.ViewControllers
{
    public partial class Demo : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public Demo(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public Demo(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion
    }
}
