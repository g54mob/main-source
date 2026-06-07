using System.Collections.Generic;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UIInputLocker : CTSBehaviour
	{
		[SerializeField]
		private List<StringKey> _openedCanvas = new List<StringKey>();

		private readonly LockToggle _lockToggle = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			CanvasGroupManager.OpenedControllersChanged += Recalculate;
			_lockToggle.Add(ToggleInput.ObjectLock);
		}

		private void OnDestroy()
		{
			CanvasGroupManager.OpenedControllersChanged -= Recalculate;
			_lockToggle.Clear();
		}

		private void Recalculate()
		{
			foreach (CanvasGroupController openedController in MonoSingleton<CanvasGroupManager>.Instance.OpenedControllers)
			{
				foreach (StringKey openedCanva in _openedCanvas)
				{
					if (openedController.IdKey == openedCanva)
					{
						_lockToggle.Lock();
						return;
					}
				}
			}
			_lockToggle.Unlock();
		}
	}
}
