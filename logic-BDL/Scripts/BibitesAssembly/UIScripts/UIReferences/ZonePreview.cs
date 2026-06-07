using System;
using System.Linq;
using SettingScripts;
using SimulationScripts;
using TMPro;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Utility.DataLogging;

namespace UIScripts.UIReferences
{
	public class ZonePreview : PoolableDictItem<ZoneSettings, ZonePreview>
	{
		[NonSerialized]
		public ZoneSettings settings;

		[NonSerialized]
		public Zone zone;

		[NonSerialized]
		public ZoneDataPoint point;

		private RectTransform rt;

		private RectTransform parentRT;

		private float radius;

		private Rect rect;

		public Material zoneMaterial;

		[SerializeField]
		private TextMeshProUGUI nameLabel;

		[SerializeField]
		private FloatValueTextHandle biomassLabel;

		[SerializeField]
		private FloatValueTextHandle numberPelletsLabel;

		private Material mat;

		private static readonly int Opacity = Shader.PropertyToID("_Opacity");

		private static readonly int PelletSpawnCoefficient = Shader.PropertyToID("_PelletSpawnCoefficient");

		private float ownBiomass;

		private static readonly int Ring = Shader.PropertyToID("_Ring");

		private static readonly int InsideRadius = Shader.PropertyToID("_insideRadius");

		private static readonly int Rect = Shader.PropertyToID("_Rect");

		public override void Initialize()
		{
			base.Initialize();
			rt = GetComponent<RectTransform>();
			parentRT = base.transform.parent.GetComponent<RectTransform>();
			mat = UnityEngine.Object.Instantiate(zoneMaterial);
			GetComponent<Image>().material = mat;
		}

		public override void AssignKey(ZoneSettings zoneSettings)
		{
			AssignSetting(zoneSettings);
		}

		public void AssignSetting(ZoneSettings zoneSettings)
		{
			settings = zoneSettings;
			settings.zoneName.Subscribe(UpdateName);
			settings.onAnySettingChange.AddListener(RefreshPresentPoint);
			settings.distribution.Subscribe(UpdateBiomass);
			settings.biomassDensity.Subscribe(UpdateBiomass);
			settings.insideRadius.Subscribe(UpdateBiomass);
			settings.fertility.Subscribe(UpdateMaterial);
			settings.pelletSize.Subscribe(UpdatePelletsDisplay);
			settings.spawnMaterial.Subscribe(UpdateSpawnMaterial);
			settings.posX.Subscribe(UpdatePos);
			settings.posY.Subscribe(UpdatePos);
			settings.onSizeChange.AddListener(UpdateSize);
			if (ZoneManager.instance != null)
			{
				zone = ZoneManager.instance.zones.FirstOrDefault((Zone z) => z.settings == settings);
			}
			UpdateName(zoneSettings.zoneName.val);
			UpdateSpawnMaterial();
			UpdateBiomassDisplay();
			UpdateBiomass();
			RefreshPresentPoint();
		}

		private void RefreshPresentPoint()
		{
			UpdatePoint(-1);
		}

		public void UpdatePoint(int timeIndex)
		{
			if (zone == null)
			{
				point = new ZoneDataPoint(settings);
			}
			else if (timeIndex < 1 || timeIndex > zone.zoneData.totalIndexOfApparition)
			{
				point = new ZoneDataPoint(zone);
			}
			else
			{
				point = zone.zoneData[timeIndex];
			}
			bool present = point.present;
			base.gameObject.SetActive(present);
			if (present)
			{
				UpdatePos();
				UpdateSize();
			}
		}

		public override void WakeUp()
		{
			base.WakeUp();
			ScenarioIndependentSettings.Instance.SimulationSize.Subscribe(UpdateBiomassDisplay);
			ScenarioIndependentSettings.Instance.SimulationSize.Subscribe(RefreshPresentPoint);
			ScenarioIndependentSettings.Instance.biomassDensity.Subscribe(UpdateBiomassDisplay);
			ScenarioSettings.Instance.pelletEnergy.Subscribe(UpdatePelletsDisplay);
		}

		public override void Retire()
		{
			base.Retire();
			if (settings != null)
			{
				ScenarioIndependentSettings.Instance.SimulationSize.UnSubscribe(UpdateBiomassDisplay);
				ScenarioIndependentSettings.Instance.SimulationSize.UnSubscribe(RefreshPresentPoint);
				ScenarioIndependentSettings.Instance.biomassDensity.UnSubscribe(UpdateBiomassDisplay);
				ScenarioSettings.Instance.pelletEnergy.UnSubscribe(UpdatePelletsDisplay);
				settings.zoneName.UnSubscribe(UpdateName);
				settings.distribution.UnSubscribe(UpdateBiomass);
				settings.biomassDensity.UnSubscribe(UpdateBiomass);
				settings.insideRadius.UnSubscribe(UpdateBiomass);
				settings.fertility.UnSubscribe(UpdateMaterial);
				settings.pelletSize.UnSubscribe(UpdatePelletsDisplay);
				settings.spawnMaterial.UnSubscribe(UpdateSpawnMaterial);
				settings.posX.UnSubscribe(UpdatePos);
				settings.posY.UnSubscribe(UpdatePos);
				settings.onAnySettingChange.RemoveListener(RefreshPresentPoint);
				settings.onSizeChange.RemoveListener(UpdateSize);
				settings = null;
			}
		}

		public void OnParentRectTransformChange()
		{
			if (!(parentRT == null))
			{
				UpdatePos();
				UpdateSize();
			}
		}

		public void UpdateName(string val)
		{
			nameLabel.text = val;
		}

		public void UpdatePos()
		{
			float x = (float)point.posX / 32767f;
			float y = (float)point.posY / 32767f;
			base.transform.localPosition = parentRT.rect.width / 2f * new Vector2(x, y);
		}

		public void UpdateSize()
		{
			if (settings == null)
			{
				return;
			}
			float num = (float)(int)point.radius / 65535f;
			Rect rect = parentRT.rect;
			if (settings.isRect)
			{
				if (settings.relativeWidth > settings.relativeHeight)
				{
					this.rect.width = 2f * rect.width * num;
					this.rect.height = 2f * rect.height * num * settings.relativeHeight / settings.relativeWidth;
				}
				else
				{
					this.rect.height = 2f * rect.height * num;
					this.rect.width = 2f * rect.width * num * settings.relativeWidth / settings.relativeHeight;
				}
				rt.sizeDelta = this.rect.size / 1f;
			}
			else
			{
				radius = rect.width * num;
				rt.sizeDelta = 2f * radius * Vector2.one / 1f;
			}
			UpdateBiomassDisplay();
		}

		public void SetShowLabels(bool val)
		{
			nameLabel.gameObject.SetActive(val);
			biomassLabel.gameObject.SetActive(val);
			numberPelletsLabel.gameObject.SetActive(val);
		}

		public void UpdateBiomass()
		{
			UpdateMaterial();
			UpdateBiomassDisplay();
		}

		private void UpdateMaterial()
		{
			mat.SetInt(Ring, settings.isRing ? 1 : 0);
			mat.SetInt(Rect, settings.isRect ? 1 : 0);
			mat.SetFloat(InsideRadius, settings.insideRadius.val);
			float value = Mathf.Log10(settings.fertility.val);
			float a = Mathf.Log10(settings.fertility.minValue);
			float b = Mathf.Log10(settings.fertility.maxValue);
			float value2 = Mathf.Log10(settings.biomassDensity.val);
			float a2 = Mathf.Log10(settings.biomassDensity.minValue);
			float b2 = Mathf.Log10(settings.biomassDensity.maxValue);
			float num = 1f - 0.9f * Mathf.Pow(Mathf.InverseLerp(a, b, value) - 1f, 2f);
			float num2 = 1f - 0.9f * Mathf.Pow(Mathf.InverseLerp(a2, b2, value2) - 1f, 2f);
			mat.SetFloat(Opacity, (num + num2) / 2f);
			Color color = biomassLabel.text.color;
			color.a = num;
			nameLabel.color = color;
			biomassLabel.text.color = color;
			numberPelletsLabel.text.color = color;
			Material material = mat;
			material.SetFloat(value: settings.distribution.val switch
			{
				SpawnDistribution.Flat => 0f, 
				SpawnDistribution.FlatRing => 0f, 
				SpawnDistribution.Rect => 0f, 
				SpawnDistribution.ExteriorGradual => -1f, 
				_ => 1f, 
			}, nameID: PelletSpawnCoefficient);
		}

		private void UpdateSpawnMaterial()
		{
			bool active = settings.spawnMaterial.val != null;
			biomassLabel.gameObject.SetActive(active);
			numberPelletsLabel.gameObject.SetActive(active);
		}

		public void UpdateBiomassDisplay()
		{
			biomassLabel.UpdateValue(settings.maxBiomass);
			UpdatePelletsDisplay();
		}

		private void UpdatePelletsDisplay()
		{
			numberPelletsLabel.UpdateValue(settings.estimatedPellets);
		}

		private void OnDestroy()
		{
			Retire();
		}
	}
}
