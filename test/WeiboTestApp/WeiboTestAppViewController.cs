using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace WeiboTestApp {
	public partial class WeiboTestAppViewController : UIViewController {
		public WeiboTestAppViewController(IntPtr handle) : base (handle) {
		}
		
		public override void DidReceiveMemoryWarning() {
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		#region View lifecycle
		
		public override void ViewDidLoad() {
			base.ViewDidLoad();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public override void ViewDidUnload() {
			base.ViewDidUnload();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets();
		}
		
		public override void ViewWillAppear(bool animated) {
			base.ViewWillAppear(animated);
		}
		
		public override void ViewDidAppear(bool animated) {
			base.ViewDidAppear(animated);
		}
		
		public override void ViewWillDisappear(bool animated) {
			base.ViewWillDisappear(animated);
		}
		
		public override void ViewDidDisappear(bool animated) {
			base.ViewDidDisappear(animated);
		}
		
		#endregion
		
		public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation) {
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

