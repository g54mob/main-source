using System;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using SettingScripts;
using SimulationScripts;
using TMPro;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
	public class ColorKillerPanel : UIPanel
	{
		[NonSerialized]
		public ColorKiller colorKiller;

		[SerializeField]
		private TMP_Dropdown spawnsDropdown;

		[SerializeField]
		private Slider hueSlider;

		[SerializeField]
		private Slider toleranceSlider;

		[SerializeField]
		private Slider radiusSlider;

		[SerializeField]
		private Toggle bodyOrEyesSwitch;

		[SerializeField]
		private Toggle anyOrMostSwitch;

		[SerializeField]
		private Slider periodSlider;

		[SerializeField]
		private ValueSliderHandle progressInfo;

		[SerializeField]
		private Image colorBar;

		[SerializeField]
		private Image toleranceBar;

		[SerializeField]
		private SpriteRenderer zoneDisplay;

		private Material toleranceMat;

		private Material colorSpectrum;

		private static readonly int Hue = Shader.PropertyToID("_hue");

		private static readonly int Width = Shader.PropertyToID("_width");

		private List<Zone> closestSpawnPoints = new List<Zone>();

		private static readonly FloatSetting SimulationSize = ScenarioIndependentSettings.Instance.SimulationSize;

		private static float simulationSize = SimulationSize.SubscribeTo<FloatSetting, float>(UpdateSimulationSize);

		private static void UpdateSimulationSize(float val)
		{
			simulationSize = val;
		}

		public override void InitPanel()
		{
			colorSpectrum = colorBar.material;
			toleranceMat = toleranceBar.material;
			radiusSlider.onValueChanged.AddListener(UpdateRadius);
			radiusSlider.maxValue = simulationSize;
			radiusSlider.minValue = 0f;
			progressInfo.InitSliderHandle(10f, updatableScale: false);
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			if (colorKiller != null)
			{
				FillPanel();
			}
			else
			{
				ClosePanel();
			}
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			zoneDisplay.gameObject.SetActive(value: false);
		}

		public override void Escape()
		{
			UserControl.Instance.SelectTarget(null);
		}

		public override void FillPanel()
		{
			BuildAttachedSpawnerDropdown();
			hueSlider.value = colorKiller.hue;
			UpdateHue(colorKiller.hue);
			toleranceSlider.value = colorKiller.tolerance;
			UpdateTolerance(colorKiller.tolerance);
			radiusSlider.maxValue = simulationSize;
			radiusSlider.minValue = 100f;
			bodyOrEyesSwitch.isOn = colorKiller.bodyOrEye;
			anyOrMostSwitch.isOn = colorKiller.anyOrMost;
			radiusSlider.value = colorKiller.radius;
			UpdateRadius(colorKiller.radius);
			periodSlider.value = colorKiller.period;
			progressInfo.UpdateScale(colorKiller.period);
			zoneDisplay.gameObject.SetActive(value: true);
		}

		private void BuildAttachedSpawnerDropdown()
		{
			spawnsDropdown.options.Clear();
			List<Zone> zones = ZoneManager.instance.zones;
			closestSpawnPoints = zones.OrderBy((Zone s) => (colorKiller.transform.position - s.transform.position).sqrMagnitude).Take(5).ToList();
			spawnsDropdown.options.Add(new TMP_Dropdown.OptionData("None"));
			int num = 0;
			foreach (Zone closestSpawnPoint in closestSpawnPoints)
			{
				num++;
				spawnsDropdown.options.Add(new TMP_Dropdown.OptionData($"{closestSpawnPoint.settings.zoneName.val} ({(colorKiller.transform.position - closestSpawnPoint.transform.position).magnitude:F0}u)"));
			}
			spawnsDropdown.value = ((colorKiller.attachedSpawner != null) ? (closestSpawnPoints.FindIndex((Zone s) => s == colorKiller.attachedSpawner) + 1) : 0);
			spawnsDropdown.RefreshShownValue();
		}

		protected override void UpdatePanel()
		{
			if (colorKiller == null)
			{
				ClosePanel();
				return;
			}
			progressInfo.UpdateValue(colorKiller.progress);
			zoneDisplay.transform.position = colorKiller.transform.position;
		}

		public void SetHue(float hue)
		{
			colorKiller.UpdateHue(hue);
			UpdateHue(hue);
		}

		private void UpdateHue(float hue)
		{
			colorSpectrum.SetFloat(Hue, hue);
			Color color = Color.HSVToRGB(hue, 1f, 1f);
			color.a = 0.3f;
			zoneDisplay.color = color;
		}

		public void SetTolerance(float val)
		{
			colorKiller.tolerance = val;
			UpdateTolerance(val);
		}

		private void UpdateTolerance(float val)
		{
			toleranceMat.SetFloat(Width, val);
		}

		public void SetSelectionTarget(bool val)
		{
			colorKiller.bodyOrEye = val;
		}

		public void SetKillOption(bool val)
		{
			colorKiller.anyOrMost = val;
		}

		public void SetPeriod(float val)
		{
			colorKiller.period = val;
			UpdatePeriod(val);
		}

		private void UpdatePeriod(float val)
		{
			progressInfo.UpdateScale(val);
		}

		public void SetRadius(float radius)
		{
			colorKiller.radius = radius;
			UpdateRadius(radius);
		}

		private void UpdateRadius(float radius)
		{
			zoneDisplay.transform.localScale = 2f * radius * Vector3.one;
		}

		public void SetAttachedSpawnPoint(int val)
		{
			colorKiller.attachedSpawner = ((val == 0) ? null : closestSpawnPoints[val - 1]);
			if (colorKiller.attachedSpawner != null)
			{
				colorKiller.transform.position = colorKiller.attachedSpawner.pos;
			}
			BuildAttachedSpawnerDropdown();
		}

		public void DestroyColorKiller()
		{
			UnityEngine.Object.Destroy(colorKiller.gameObject);
		}
	}
}
