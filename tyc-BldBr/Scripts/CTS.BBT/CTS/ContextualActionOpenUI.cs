using System;
using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[Serializable]
	internal class ContextualActionOpenUI : MenuContextualAction<StationStock>
	{
		[SerializeField]
		private StringKey _canvasToOpen;

		public override void Setup()
		{
		}

		protected override bool CanBePerformed()
		{
			return true;
		}

		protected override void Execution()
		{
			if (!_canvasToOpen.IsValid())
			{
				throw new Exception("Canvas key is invalid");
			}
			if (MonoSingleton<CanvasGroupManager>.Instance.TryGet(_canvasToOpen, out var controller))
			{
				if (controller.IsShown)
				{
					controller.QuickHide();
				}
				else
				{
					controller.QuickShow();
				}
			}
		}
	}
}
