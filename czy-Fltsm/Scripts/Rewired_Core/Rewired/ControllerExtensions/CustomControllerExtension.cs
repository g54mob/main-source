using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public abstract class CustomControllerExtension : Controller.Extension
	{
		private bool KwGVziISQtjJfUvHgeqZUAoWCttE;

		public CustomControllerExtension(IControllerExtensionSource P_0)
			: base(P_0)
		{
		}

		protected CustomControllerExtension(CustomControllerExtension P_0)
			: base(P_0)
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
			return base.GetSource();
		}

		public abstract Controller.Extension ShallowCopy();

		internal override Controller.Extension Clone()
		{
			return ShallowCopy();
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (KwGVziISQtjJfUvHgeqZUAoWCttE && base.enabled)
			{
				OnUpdateData(updateLoop);
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			KwGVziISQtjJfUvHgeqZUAoWCttE = source != null;
			OnSourceUpdated(source);
		}
	}
}
