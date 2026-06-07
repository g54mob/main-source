using TMPro;
using UnityEngine;

namespace DV.Localization.Debug
{
	public class LoadingScreenDebug : MonoBehaviour
	{
		public TMP_Text messagesTMPro;

		public TMP_Text percentageTMPro;

		public TMP_Text modsNoticeTMPro;

		private void Start()
		{
			UpdateTexts();
		}

		private void UpdateTexts()
		{
			messagesTMPro.text = string.Join("\n", LocalizationAPI.L("loading/start_game_data"), LocalizationAPI.L("loading/start_game_data_missing"), LocalizationAPI.L("loading/vegetation"), LocalizationAPI.L("loading/terrains"), LocalizationAPI.L("loading/railway_layout"), LocalizationAPI.L("loading/railway_visuals"), LocalizationAPI.L("loading/streaming"), LocalizationAPI.L("loading/game_content"), LocalizationAPI.L("loading/player"), LocalizationAPI.L("loading/car_pool"), LocalizationAPI.L("loading/restoring_game_state"), LocalizationAPI.L("loading/waiting_for_streaming"), LocalizationAPI.L("loading/waiting_for_terrains"), LocalizationAPI.L("done"));
			percentageTMPro.text = LocalizationAPI.L("loading/please_wait", "100");
			modsNoticeTMPro.gameObject.SetActive(value: true);
			modsNoticeTMPro.text = LocalizationAPI.L("loading/mods_notice");
		}
	}
}
