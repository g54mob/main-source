using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public abstract class CustomControllerExtension : Controller.Extension
	{
		private bool InEqcqSivSEUgBrIdkntOEyDzeJqA;

		public CustomControllerExtension(IControllerExtensionSource P_0)
			: base((IControllerExtensionSource)null)
		{
		}

		protected CustomControllerExtension(CustomControllerExtension P_0)
			: base((IControllerExtensionSource)null)
		{
		}

		protected virtual void OnUpdateData(UpdateLoopType updateLoop)
		{
		}

		protected virtual void OnSourceUpdated(IControllerExtensionSource source)
		{
		}

		protected new IControllerExtensionSource GetSource()
		{
			return null;
		}

		public abstract Controller.Extension ShallowCopy();

		internal override Controller.Extension Clone()
		{
			return null;
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
		}
	}
}
