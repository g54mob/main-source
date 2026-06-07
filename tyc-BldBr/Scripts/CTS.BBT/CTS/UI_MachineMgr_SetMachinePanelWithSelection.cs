using System;
using CTS.BBT;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UI_MachineMgr_SetMachinePanelWithSelection : CTSBehaviour, ILockable
	{
		[SerializeField]
		private CanvasGroupController _canvasGroupController;

		[SerializeField]
		[Inject(false)]
		private UI_MachineMgr_MachinePanel _machinePanel;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		protected override void OnAwake()
		{
			base.OnAwake();
			WorldSelector.RegisterToSelection<Furniture>(OnFurnitureInteractorSelected);
			_canvasGroupController.CanvasShowning += OnCanvasGroupShowing;
		}

		private void OnCanvasGroupShowing(bool isShowing)
		{
			if (!isShowing)
			{
				_machinePanel.SetFurniture(null);
			}
		}

		private void OnDestroy()
		{
			WorldSelector.UnregisterToSelection<Furniture>(OnFurnitureInteractorSelected);
		}

		private void OnFurnitureInteractorSelected(Furniture furniture, bool isSelected)
		{
			if (isSelected)
			{
				if (!ObjectLock.IsLocked())
				{
					if (!(furniture.Interactor is IManageableFurniture manageableFurniture))
					{
						_canvasGroupController.QuickHide();
						return;
					}
					_canvasGroupController.QuickShow();
					_machinePanel.SetFurniture((FurnitureInteractor)manageableFurniture);
				}
			}
			else
			{
				_canvasGroupController.QuickHide();
			}
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}
	}
}
