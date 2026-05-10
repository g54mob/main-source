using CTS.BBT;
using CTS.Core;

namespace CTS
{
	public class UI_MachineMgr_MachinePanel : CTSBehaviour, IRepaint
	{
		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		protected UI_MachineMgr_MachinePanelFeature[] _features;

		private static readonly StringKey _mainCanvasesKey = "MainCanvases";

		public FurnitureInteractor CurrentFurniture { get; private set; }

		public void SetFurniture(FurnitureInteractor furniture)
		{
			if (!(CurrentFurniture == furniture))
			{
				if (CurrentFurniture != null)
				{
					UnsubscribeFromEvents();
				}
				CurrentFurniture = furniture;
				if (CurrentFurniture != null)
				{
					SubscribeToEvents();
				}
				UI_MachineMgr_MachinePanelFeature[] features = _features;
				for (int i = 0; i < features.Length; i++)
				{
					features[i].SetFurniture(CurrentFurniture);
				}
			}
		}

		private void SubscribeToEvents()
		{
			if ((bool)CurrentFurniture.Syncing)
			{
				CurrentFurniture.Syncing.SyncingChanged += OnSyncingChanged;
			}
		}

		private void UnsubscribeFromEvents()
		{
			if ((bool)CurrentFurniture.Syncing)
			{
				CurrentFurniture.Syncing.SyncingChanged -= OnSyncingChanged;
			}
		}

		private void OnDestroy()
		{
			SetFurniture(null);
		}

		public void SetSyncing(bool value)
		{
			if ((bool)CurrentFurniture && (bool)CurrentFurniture.Syncing)
			{
				CurrentFurniture.Syncing.SetSyncing(value);
			}
		}

		private void OnSyncingChanged()
		{
			RepaintSyncs();
		}

		public void RepaintSyncs()
		{
			UI_MachineMgr_MachinePanelFeature[] features = _features;
			for (int i = 0; i < features.Length; i++)
			{
				features[i].RepaintSync();
			}
		}

		public void LocateMachine()
		{
			if ((object)CurrentFurniture != null)
			{
				CanvasExclusivity.Close(null, _mainCanvasesKey);
				WorldSelector.SelectObject(CurrentFurniture.Furniture.SelectableObject);
				MonoSingleton<CameraFollowing>.Instance.EventLock(CurrentFurniture.transform);
			}
		}

		public void Repaint()
		{
			UI_MachineMgr_MachinePanelFeature[] features = _features;
			foreach (UI_MachineMgr_MachinePanelFeature uI_MachineMgr_MachinePanelFeature in features)
			{
				if (uI_MachineMgr_MachinePanelFeature.isActiveAndEnabled)
				{
					uI_MachineMgr_MachinePanelFeature.Repaint();
				}
			}
		}
	}
}
