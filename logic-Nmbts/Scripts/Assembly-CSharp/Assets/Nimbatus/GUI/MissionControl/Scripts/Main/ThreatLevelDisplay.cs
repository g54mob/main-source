using System.Collections;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.Main
{
	public class ThreatLevelDisplay : MonoBehaviour
	{
		private MissionControlUiManager _manager;

		public UISprite ThreatBar;

		public UISprite PredictedThreatBar;

		public UILabel ThreatIncreaseLabel;

		public void Init(MissionControlUiManager manager)
		{
			_manager = manager;
		}

		public IEnumerator Start()
		{
			while (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.IsLoading || SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy == null)
			{
				yield return null;
			}
			UpdateBar(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.CurrentThreatLevel);
		}

		public void Update()
		{
			ThreatIncreaseLabel.text = LocalizationManager.GetTermTranslation("CampaignMode/Threat") + ": " + LabelHelper.Orange + (ThreatBar.fillAmount * 100f).ToString("F2") + "%";
			UpdatePrediction();
		}

		public IEnumerator AnimateThreatBar(float time, float start, float end)
		{
			float t = 0f;
			while (t < 1f)
			{
				t += Time.deltaTime / time;
				float threatLevel = Mathf.Lerp(start, end, t);
				UpdateBar(threatLevel);
				yield return null;
			}
		}

		public void UpdateBar(float threatLevel)
		{
			ThreatBar.fillAmount = threatLevel / 100f;
		}

		private void UpdatePrediction()
		{
			if (_manager != null)
			{
				float selectedLocationThreatIncrease = _manager.GalaxyMap.SelectedLocationThreatIncrease;
				PredictedThreatBar.fillAmount = ThreatBar.fillAmount + selectedLocationThreatIncrease / 100f;
				if (selectedLocationThreatIncrease > 0f)
				{
					UILabel threatIncreaseLabel = ThreatIncreaseLabel;
					threatIncreaseLabel.text = threatIncreaseLabel.text + LabelHelper.DarkOrange + " (+" + selectedLocationThreatIncrease.ToString("F2") + "% )";
				}
			}
			else
			{
				PredictedThreatBar.fillAmount = 0f;
			}
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("CampaignMode/ThreatTooltip"));
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}
	}
}
