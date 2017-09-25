// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MvvmPOC.ViewControllers
{
	[Register ("DemoController")]
	partial class DemoController
	{
		[Outlet]
		AppKit.NSTextField input1TextField { get; set; }

		[Outlet]
		AppKit.NSTextField input2TextField { get; set; }

		[Outlet]
		AppKit.NSButton multiplyButton { get; set; }

		[Outlet]
		AppKit.NSTextField productTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (input1TextField != null) {
				input1TextField.Dispose ();
				input1TextField = null;
			}

			if (input2TextField != null) {
				input2TextField.Dispose ();
				input2TextField = null;
			}

			if (multiplyButton != null) {
				multiplyButton.Dispose ();
				multiplyButton = null;
			}

			if (productTextField != null) {
				productTextField.Dispose ();
				productTextField = null;
			}
		}
	}
}
