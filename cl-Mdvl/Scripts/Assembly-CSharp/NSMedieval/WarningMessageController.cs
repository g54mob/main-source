using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Model;

namespace NSMedieval
{
	public class WarningMessageController : MonoSingleton<WarningMessageController>
	{
		public delegate void WarningMessageHandlerWithClick(WarningMessageData message);

		public delegate void WarningMessageHandler(WarningMessageData message);

		public event WarningMessageHandlerWithClick ShowMessageEvent;

		public event WarningMessageHandlerWithClick UpdateMessageEvent;

		public event WarningMessageHandlerWithClick MessageAlertEvent;

		public event WarningMessageHandler HideMessageEvent;

		private bool TryIsMessageShowing(WarningMessageData message, out bool isShowing)
		{
			if (!MonoSingleton<WarningMessageManager>.IsInstantiated())
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\WarningMessageController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted("WarningMessageManager");
					messageBuilder.AppendLiteral(" is not instantiated, but a message tried to use it. Message: ");
					messageBuilder.AppendFormatted(message);
				}
				Log.Error(messageBuilder);
				isShowing = false;
				return false;
			}
			if (!message.ShouldShow)
			{
				isShowing = false;
				return true;
			}
			isShowing = MonoSingleton<WarningMessageManager>.Instance.IsMessageShowing(message);
			return true;
		}

		public void SetMessageVisible(WarningMessageData message, bool visible)
		{
			if (message.ShouldShow && TryIsMessageShowing(message, out var isShowing) && isShowing != visible)
			{
				if (!visible)
				{
					this.HideMessageEvent?.Invoke(message);
					return;
				}
				this.ShowMessageEvent?.Invoke(message);
				this.MessageAlertEvent?.Invoke(message);
			}
		}

		public void RefreshMessage(WarningMessageData message, bool visible)
		{
			if (!message.ShouldShow || !TryIsMessageShowing(message, out var isShowing))
			{
				return;
			}
			if (!isShowing)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(60, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\WarningMessageController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Can't refresh message because it is not showing. Message: '");
					messageBuilder.AppendFormatted(message);
					messageBuilder.AppendLiteral("'");
				}
				Log.Error(messageBuilder);
			}
			else if (visible)
			{
				this.ShowMessageEvent?.Invoke(message);
			}
			else
			{
				this.HideMessageEvent?.Invoke(message);
			}
		}

		public void ShowMessage(WarningMessageData message)
		{
			if (!message.ShouldShow || !TryIsMessageShowing(message, out var isShowing))
			{
				return;
			}
			if (isShowing)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(81, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\WarningMessageController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Can't show message because it's showing already. Updating content only. Message: ");
					messageBuilder.AppendFormatted(message);
				}
				Log.Info(messageBuilder);
				this.UpdateMessageEvent?.Invoke(message);
			}
			else
			{
				this.ShowMessageEvent?.Invoke(message);
				this.MessageAlertEvent?.Invoke(message);
			}
		}

		public void HideMessage(WarningMessageData message)
		{
			if (!message.ShouldShow || !TryIsMessageShowing(message, out var isShowing))
			{
				return;
			}
			if (!isShowing)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(55, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\WarningMessageController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to hide message that is already hidden. Message: ");
					messageBuilder.AppendFormatted(message);
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				this.HideMessageEvent?.Invoke(message);
			}
		}
	}
}
