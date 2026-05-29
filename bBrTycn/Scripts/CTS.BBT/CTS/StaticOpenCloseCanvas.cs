using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Static Behaviours/Open Close Canvas")]
	public class StaticOpenCloseCanvas : ScriptableObject
	{
		[SerializeField]
		private StringKey _canvasKey;

		public void Open()
		{
			if (MonoSingleton<CanvasGroupManager>.TryGetInstance(out var outInstance) && outInstance.TryGet(_canvasKey, out var controller))
			{
				controller.QuickShow();
			}
		}

		public void Close()
		{
			if (MonoSingleton<CanvasGroupManager>.TryGetInstance(out var outInstance) && outInstance.TryGet(_canvasKey, out var controller))
			{
				controller.QuickHide();
			}
		}

		public void SetOpened(bool isOpen)
		{
			if (MonoSingleton<CanvasGroupManager>.TryGetInstance(out var outInstance) && outInstance.TryGet(_canvasKey, out var controller))
			{
				if (isOpen)
				{
					controller.QuickShow();
				}
				else
				{
					controller.QuickHide();
				}
			}
		}

		public void SetClosed(bool isClosed)
		{
			SetOpened(!isClosed);
		}
	}
}
