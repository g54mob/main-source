using System;

namespace TH20
{
	public class HospitalEditEvents : MustCallDestroy, IGameEventsBase
	{
		public Action OnStart;

		public Action OnEnd;

		public Action OnBeginBuilding;

		public Action OnEndBuilding;

		public Action OnBeginMovePlot;

		public Action OnBeginItemPlacement;

		public Action OnTileMapPreviewToggle;

		public Action<int, int> OnOffsetLandsacpeItems;

		public Action<string> OnNukeLandscapeItems;

		public Action<HospitalPlot> OnSelectHospitalPlot;

		public Action<HospitalPlotLayer> OnSelectHospitalPlotLayer;

		public Action<HospitalPlot> OnHospitalPlotUpdated;

		public Action<HospitalPlot, bool> OnSetHospitalPlotVisible;

		public Action<HospitalPlot, HospitalPlotLayer, bool> OnSetHospitalPlotLayerVisible;

		public Action<HospitalPlot, bool> OnSetHospitalPlotState;

		public Action<HospitalPlot, bool> OnHospitalPlotStateChanging;

		public Action<HospitalMapTile.Type> OnTileTypeSelected;

		[DontSave]
		private HUD _hud;

		private Level _level;

		[DontSave]
		private CursorManager _cursorManager;

		private CursorEditHospital.Config _editHospitalConfig;

		public void Initialise(Level level, CursorEditHospital.Config editHospitalConfig)
		{
			GameEventsRegistry.RegisterLevelEvent(this);
			_level = level;
			_hud = _level.HUD;
			_cursorManager = _level.CursorManager;
			_editHospitalConfig = editHospitalConfig;
			OnStart = (Action)Delegate.Combine(OnStart, new Action(StartEdit));
			OnEnd = (Action)Delegate.Combine(OnEnd, new Action(EndEdit));
		}

		public override void Destroy()
		{
			EndEdit();
			OnStart = (Action)Delegate.Remove(OnStart, new Action(StartEdit));
			OnEnd = (Action)Delegate.Remove(OnEnd, new Action(EndEdit));
			base.Destroy();
		}

		public void VerifyEvents()
		{
			OnStart.VerifyIsNull();
			OnEnd.VerifyIsNull();
			OnBeginBuilding.VerifyIsNull();
			OnEndBuilding.VerifyIsNull();
			OnBeginMovePlot.VerifyIsNull();
			OnBeginItemPlacement.VerifyIsNull();
			OnTileMapPreviewToggle.VerifyIsNull();
			OnSelectHospitalPlot.VerifyIsNull();
			OnSelectHospitalPlotLayer.VerifyIsNull();
			OnHospitalPlotUpdated.VerifyIsNull();
			OnOffsetLandsacpeItems.VerifyIsNull();
			OnNukeLandscapeItems.VerifyIsNull();
			OnSetHospitalPlotVisible.VerifyIsNull();
			OnSetHospitalPlotLayerVisible.VerifyIsNull();
			OnSetHospitalPlotState.VerifyIsNull();
			OnTileTypeSelected.VerifyIsNull();
		}

		private void SetGameHUDVisible(bool visible)
		{
			HubMenu hubMenu = _hud.FindMenu<HubMenu>();
			if (hubMenu != null)
			{
				hubMenu.SetVisible(visible);
			}
			TimeAndStatsMenu timeAndStatsMenu = _hud.FindMenu<TimeAndStatsMenu>();
			if (timeAndStatsMenu != null)
			{
				timeAndStatsMenu.SetVisible(visible);
			}
			GeneralNotificationMenu generalNotificationMenu = _hud.FindMenu<GeneralNotificationMenu>();
			if (generalNotificationMenu != null)
			{
				generalNotificationMenu.SetVisible(visible);
			}
			MessagesMenu messagesMenu = _hud.FindMenu<MessagesMenu>();
			if (messagesMenu != null)
			{
				messagesMenu.SetVisible(visible);
			}
			AdvisorMenu advisorMenu = _hud.FindMenu<AdvisorMenu>();
			if (advisorMenu != null)
			{
				advisorMenu.SetVisible(visible);
			}
		}

		private void StartEdit()
		{
			if (_cursorManager.IsModeActive<CursorEditHospital>())
			{
				return;
			}
			SetGameHUDVisible(visible: false);
			foreach (Character allCharacter in _level.CharacterManager.AllCharacters)
			{
				_level.CharacterEvents.OnDestroyCharacter.InvokeSafe(allCharacter);
			}
			_hud.CreateMenu<EditHospitalMenu>().Setup(_level);
			_cursorManager.PushMode(new CursorEditHospital(_cursorManager, _level, _editHospitalConfig));
		}

		private void EndEdit()
		{
			_cursorManager.PopMode<CursorEditHospital>();
			_hud.DestroyMenu<EditHospitalMenu>();
			SetGameHUDVisible(visible: true);
		}
	}
}
