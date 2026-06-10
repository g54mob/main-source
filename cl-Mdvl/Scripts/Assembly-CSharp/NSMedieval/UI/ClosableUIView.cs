using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ClosableUIView : UIView
	{
		[SerializeField]
		private UIView parentView;

		private Keybinding escKeybinding;

		protected virtual void CloseSelf()
		{
			if (!base.SceneUIManager)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\ClosableUIView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(GetType().FullName);
					messageBuilder.AppendLiteral(".");
					messageBuilder.AppendFormatted("CloseSelf");
					messageBuilder.AppendLiteral(": SceneUIManager is null");
				}
				Log.Error(messageBuilder);
			}
			else if (!parentView)
			{
				base.SceneUIManager.ShowPreviousView();
			}
			else
			{
				base.SceneUIManager.ShowNewView(parentView.name);
			}
		}

		public override void Show()
		{
			base.Show();
			if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.SubscribeToEscapeKey(CloseSelf, base.gameObject);
			}
		}

		public override void Hide()
		{
			base.Hide();
			if (MonoSingleton<GlobalKeybindingManager>.IsInstantiated())
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.UnsubscribeFromEscapeKey(CloseSelf, base.gameObject);
			}
		}
	}
}
