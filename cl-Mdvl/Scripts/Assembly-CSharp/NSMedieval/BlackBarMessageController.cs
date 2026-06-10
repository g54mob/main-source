using System;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval
{
	public class BlackBarMessageController : MonoSingleton<BlackBarMessageController>
	{
		public delegate void Message(string messageText);

		public delegate void ClickableMessage(string messageText, Vector3 position);

		public delegate void ClickableSelectableMessage(string messageText, SelectableObject selectableObject, bool follow);

		public event Message MessageEvent;

		public event ClickableMessage ClickableMessageEvent;

		public event ClickableSelectableMessage ClickableSelectableMessageEvent;

		public event Action HideAllMessagesEvent;

		public void ShowBlackBarMessage(string messageText)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(5, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\BlackBarMessageController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("BBT: ");
				messageBuilder.AppendFormatted(messageText);
			}
			Log.Info(messageBuilder);
			if ((!MonoSingleton<ThreadingJobSystem>.IsInstantiated() || Thread.CurrentThread == MonoSingleton<ThreadingJobSystem>.Instance.MainThread) && !string.IsNullOrEmpty(messageText))
			{
				this.MessageEvent?.Invoke(messageText);
			}
		}

		public void ShowClickableBlackBarMessage(string messageText, Vector3 position)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(5, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\BlackBarMessageController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("BBT: ");
				messageBuilder.AppendFormatted(messageText);
			}
			Log.Debug(messageBuilder);
			if (!MonoSingleton<ThreadingJobSystem>.IsInstantiated() || Thread.CurrentThread == MonoSingleton<ThreadingJobSystem>.Instance.MainThread)
			{
				this.ClickableMessageEvent?.Invoke(messageText, position);
			}
		}

		public void ShowClickableBlackBarMessage(string messageText, SelectableObject selectable, bool follow = false)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(5, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\BlackBarMessageController.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("BBT: ");
				messageBuilder.AppendFormatted(messageText);
			}
			Log.Debug(messageBuilder);
			if (!MonoSingleton<ThreadingJobSystem>.IsInstantiated() || Thread.CurrentThread == MonoSingleton<ThreadingJobSystem>.Instance.MainThread)
			{
				if (selectable == null)
				{
					ShowBlackBarMessage(messageText);
				}
				else
				{
					this.ClickableSelectableMessageEvent?.Invoke(messageText, selectable, follow);
				}
			}
		}

		public void HideAllMessages()
		{
			if (!MonoSingleton<ThreadingJobSystem>.IsInstantiated() || Thread.CurrentThread == MonoSingleton<ThreadingJobSystem>.Instance.MainThread)
			{
				this.HideAllMessagesEvent?.Invoke();
			}
		}
	}
}
