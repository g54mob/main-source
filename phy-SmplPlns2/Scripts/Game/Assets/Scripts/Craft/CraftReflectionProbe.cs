using System;
using Assets.Scripts.Settings;
using Jundroo.Common.Settings;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft
{
	public class CraftReflectionProbe : MonoBehaviour
	{
		private EnumSetting<CraftQualitySettings.CraftReflectionsQuality> _reflectionQualitySetting;

		public AircraftScript Craft { get; private set; }

		public ReflectionProbe ReflectionProbe { get; private set; }

		public Transform Transform { get; private set; }

		public static CraftReflectionProbe Create(AircraftScript craft)
		{
			GameObject obj = new GameObject("CraftReflectionProbe");
			obj.transform.SetParent(craft.transform, worldPositionStays: false);
			obj.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			obj.SetActive(value: false);
			ReflectionProbe probe = obj.AddComponent<ReflectionProbe>();
			CraftReflectionProbe craftReflectionProbe = obj.AddComponent<CraftReflectionProbe>();
			craftReflectionProbe.Initialize(craft, probe);
			return craftReflectionProbe;
		}

		protected virtual void LateUpdate()
		{
			Transform.position = Craft.MainCockpit.transform.position;
		}

		protected virtual void OnDestroy()
		{
			if (_reflectionQualitySetting != null)
			{
				_reflectionQualitySetting.Changed -= OnReflectionSettingsChanged;
			}
		}

		private void ApplyReflectionSettings()
		{
			int num;
			if (_reflectionQualitySetting.Value == CraftQualitySettings.CraftReflectionsQuality.Realtime)
			{
				AircraftScript craft = Craft;
				if ((object)craft != null && craft.LoadContext == CraftLoadContext.Flight)
				{
					num = ((ReflectionProbe != null) ? 1 : 0);
					goto IL_0034;
				}
			}
			num = 0;
			goto IL_0034;
			IL_0034:
			bool active = (byte)num != 0;
			base.gameObject.SetActive(active);
		}

		private void Initialize(AircraftScript craft, ReflectionProbe probe)
		{
			Craft = craft;
			ReflectionProbe = probe;
			Transform = base.transform;
			_reflectionQualitySetting = Game.Instance.Settings.Quality.Craft.Reflections;
			_reflectionQualitySetting.Changed += OnReflectionSettingsChanged;
			probe.mode = ReflectionProbeMode.Realtime;
			probe.refreshMode = ReflectionProbeRefreshMode.EveryFrame;
			probe.timeSlicingMode = ReflectionProbeTimeSlicingMode.IndividualFaces;
			probe.clearFlags = ReflectionProbeClearFlags.Skybox;
			probe.renderDynamicObjects = true;
			probe.resolution = 256;
			probe.shadowDistance = 500f;
			probe.nearClipPlane = 0.1f;
			probe.farClipPlane = 40000f;
			probe.size = new Vector3(0.01f, 0.01f, 0.01f);
			probe.cullingMask = 9443345;
			ApplyReflectionSettings();
		}

		private void OnReflectionSettingsChanged(object sender, EventArgs e)
		{
			ApplyReflectionSettings();
		}
	}
}
