using System;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class WargameManager : WorldManager
	{
		public Wargame Current { get; private set; }

		public bool IsActive => Current != null;

		public int CurrentSquadIndex { get; private set; }

		public static event Action WargameCompleted;

		protected override void OnGameEvent(EGameEvent gameEvent)
		{
			base.OnGameEvent(gameEvent);
			if (gameEvent == EGameEvent.ANALYTICS)
			{
				SendAnalytics();
			}
		}

		public void StartWargame(int squadIndex)
		{
			CurrentSquadIndex = squadIndex;
			Current = new Wargame(new WargameSquad(Collection.GetSquadAtIndex(squadIndex)), WargameSettings.GetRandomSquad());
			Tutorial.TryShow(WargameSettings.PlayTutorialData, OpenWargameHUDPopup);
			static void OpenWargameHUDPopup()
			{
				if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
				{
					TransientManager<InputManager>.Instance.SetVirtualMouseActive(active: true);
				}
				TabletopWorld.TabletopHUDPopup.Open(ETabletopHUDPopupModuleType.WARGAME);
				CameraManager.GraphicRaycasterEnabled = true;
				WargameWorkshop.CurrentlyUsed.OnWargameStarting();
				GraphicsApplicationOptions.TemporarilyApplyWargameShadowSettings();
			}
		}

		public void RestartWargame()
		{
			Current.Destroy();
			Current = new Wargame(new WargameSquad(Collection.GetSquadAtIndex(CurrentSquadIndex)), WargameSettings.GetRandomSquad());
		}

		public void StartDebugWargame()
		{
			Current = new Wargame(WargameSettings.GetRandomSquad(), WargameSettings.GetRandomSquad());
			Time.timeScale = 0f;
			GraphicsApplicationOptions.TemporarilyApplyWargameShadowSettings();
			TabletopWorld.TabletopHUDPopup.Open(ETabletopHUDPopupModuleType.WARGAME);
		}

		public void CompleteWargame(bool backToDeck)
		{
			TransientManager<InputManager>.Instance.DestroyVirtualMouse();
			Time.timeScale = 1f;
			GraphicsApplicationOptions.ApplyDefaultShadowSettings();
			WargameWorkshop.CurrentlyUsed.OnWargameComplete(!backToDeck);
			if (backToDeck)
			{
				Collection.Open(ECollectionMode.SQUAD_SELECTION);
			}
			Current.OnComplete();
			Current.Destroy();
			Current = null;
			WargameManager.WargameCompleted?.Invoke();
		}

		private void SendAnalytics()
		{
			int validSquadsCount = Collection.GetValidSquadsCount();
			if (validSquadsCount != 0)
			{
				GameAnalytics.NewDesignEvent("id_analytics_wargame1_deck", validSquadsCount);
			}
		}
	}
}
