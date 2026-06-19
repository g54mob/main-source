using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MapPinOnline : MapPin
	{
		[SerializeField]
		private MeshRenderer _meshIcon;

		[SerializeField]
		private Material _materialDefault;

		[SerializeField]
		private Material _materialHighlighted;

		[SerializeField]
		private MeshRenderer _alertIcon;

		[SerializeField]
		private Transform _fixedCameraTransform;

		private Metagame _metagame;

		private HUD _hud;

		public void Initialise(MetagameMap metagameMap)
		{
			_metagame = metagameMap.Metagame;
			_hud = metagameMap.HUD;
			UpdateAlertIcon();
			CollaborativeMetagameData collaborativeMetagameData = _metagame.CollaborativeMetagameData;
			collaborativeMetagameData.OnLastViewTimeUpdated = (Action)Delegate.Combine(collaborativeMetagameData.OnLastViewTimeUpdated, new Action(UpdateAlertIcon));
			CollaborativePortfolio collaborativePortfolio = _metagame.CollaborativePortfolio;
			collaborativePortfolio.OnLatestDataGathered = (Action)Delegate.Combine(collaborativePortfolio.OnLatestDataGathered, new Action(UpdateAlertIcon));
			SuperBugProjectManager superBugManager = _metagame.SuperBugManager;
			superBugManager.OnProjectViewed = (Action)Delegate.Combine(superBugManager.OnProjectViewed, new Action(UpdateAlertIcon));
			SuperBugProjectManager superBugManager2 = _metagame.SuperBugManager;
			superBugManager2.OnCompletionDataReceived = (Action)Delegate.Combine(superBugManager2.OnCompletionDataReceived, new Action(UpdateAlertIcon));
			if (_tooltipSpawner != null)
			{
				_tooltipSpawner.SetDataProvider(UpdateTooltip);
			}
		}

		public override void PrepareForDestroy()
		{
			CollaborativeMetagameData collaborativeMetagameData = _metagame.CollaborativeMetagameData;
			collaborativeMetagameData.OnLastViewTimeUpdated = (Action)Delegate.Remove(collaborativeMetagameData.OnLastViewTimeUpdated, new Action(UpdateAlertIcon));
			CollaborativePortfolio collaborativePortfolio = _metagame.CollaborativePortfolio;
			collaborativePortfolio.OnLatestDataGathered = (Action)Delegate.Remove(collaborativePortfolio.OnLatestDataGathered, new Action(UpdateAlertIcon));
			SuperBugProjectManager superBugManager = _metagame.SuperBugManager;
			superBugManager.OnProjectViewed = (Action)Delegate.Remove(superBugManager.OnProjectViewed, new Action(UpdateAlertIcon));
			SuperBugProjectManager superBugManager2 = _metagame.SuperBugManager;
			superBugManager2.OnCompletionDataReceived = (Action)Delegate.Remove(superBugManager2.OnCompletionDataReceived, new Action(UpdateAlertIcon));
		}

		private void UpdateTooltip(Tooltip tooltip)
		{
			tooltip.Text = (OnlineManager.IsInitializedAndLoggedOn() ? ScriptLocalization.Tooltip.MapPinOnline_ResearchDepartment_CS : ScriptLocalization.Tooltip.MapPinOnline_NotOnline_CS);
		}

		public override void OnCursorOver(bool over)
		{
			base.OnCursorOver(over);
			_meshIcon.material = (over ? _materialHighlighted : _materialDefault);
		}

		public override void OnSelected()
		{
			base.OnSelected();
			HideSelectedHospitalMenu();
		}

		private void UpdateAlertIcon()
		{
			if (!OnlineManager.IsInitializedAndLoggedOn())
			{
				_alertIcon.gameObject.SetActive(value: false);
				return;
			}
			bool active = _metagame.CollaborativePortfolio.HasPortfolioGotNewData();
			_alertIcon.gameObject.SetActive(active);
		}

		private void HideSelectedHospitalMenu()
		{
			SelectedHospitalMenu selectedHospitalMenu = _hud.FindMenu<SelectedHospitalMenu>();
			if (selectedHospitalMenu != null)
			{
				selectedHospitalMenu.CloseMenu();
			}
		}
	}
}
