using SettingScripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UIScripts.UIPanels
{
	public class VisibilityPanel : MonoBehaviour
	{
		[FormerlySerializedAs("PheromonesToggle")]
		public Toggle pheromonesToggle;

		[FormerlySerializedAs("FertilityToggle")]
		public Toggle fertilityToggle;

		[FormerlySerializedAs("RulerToggle")]
		public Toggle rulerToggle;

		[FormerlySerializedAs("StatusBarsToggle")]
		public Toggle statusBarsToggle;

		public Toggle bibiteFOWToggle;

		public GameObject bibiteTargetsLine;

		public Toggle bibiteTargetsToggle;

		public Toggle showGridToggle;

		private void Start()
		{
			pheromonesToggle.isOn = UserSettings.ShowPheromones.val;
			pheromonesToggle.onValueChanged.AddListener(UserSettings.ShowPheromones.SetValue);
			fertilityToggle.isOn = UserSettings.ShowFertility.val;
			fertilityToggle.onValueChanged.AddListener(UserSettings.ShowFertility.SetValue);
			rulerToggle.isOn = UserSettings.ShowRuler.val;
			rulerToggle.onValueChanged.AddListener(UserSettings.ShowRuler.SetValue);
			statusBarsToggle.isOn = UserSettings.ShowStatusBars.val;
			statusBarsToggle.onValueChanged.AddListener(UserSettings.ShowStatusBars.SetValue);
			bibiteFOWToggle.isOn = UserSettings.ShowBibiteFOW.val;
			bibiteFOWToggle.onValueChanged.AddListener(UpdateFOWDisplay);
			bibiteTargetsToggle.isOn = UserSettings.ShowBibiteTargets.val;
			bibiteTargetsToggle.onValueChanged.AddListener(UserSettings.ShowBibiteTargets.SetValue);
			showGridToggle.isOn = UserSettings.ShowGrid.val;
			showGridToggle.onValueChanged.AddListener(UserSettings.ShowGrid.SetValue);
			UserSettings.ShowGrid.OnValueChange.AddListener(UpdateShowGridToggle);
		}

		private void UpdateFOWDisplay(bool val)
		{
			UserSettings.ShowBibiteFOW.SetValue(val);
			bibiteTargetsLine.SetActive(val);
		}

		private void UpdateShowGridToggle(bool val)
		{
			showGridToggle.SetIsOnWithoutNotify(val);
		}
	}
}
