using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Aura2API
{
	public static class Aura
	{
		private static AuraResourcesCollection _auraResourcesCollection;

		private static bool _hasCheckedCompatibility;

		private static bool _isCompatible;

		public static bool IsCompatible
		{
			get
			{
				if (!_hasCheckedCompatibility)
				{
					_isCompatible = true;
					List<string> list = new List<string>();
					if (!SystemInfo.supports2DArrayTextures)
					{
						_isCompatible = false;
						list.Add("2D Texture Arrays not supported");
					}
					if (!SystemInfo.supports3DTextures)
					{
						_isCompatible = false;
						list.Add("3D Textures not supported");
					}
					if (!SystemInfo.supports3DRenderTextures)
					{
						_isCompatible = false;
						list.Add("3D Render Textures not supported");
					}
					if (!SystemInfo.supportsComputeShaders)
					{
						_isCompatible = false;
						list.Add("Compute Shaders not supported");
					}
					if (!SystemInfo.supportsRawShadowDepthSampling)
					{
						_isCompatible = false;
						list.Add("Raw Shadow Maps not supported");
					}
					if (!_isCompatible)
					{
						string text = "Aura 2 is not supported for this target";
						text = text + " (" + Application.platform.ToString() + ")";
						text += " and will be disabled.";
						text = text + "\nReason" + ((list.Count > 1) ? "s" : "") + " : ";
						for (int i = 0; i < list.Count; i++)
						{
							text += list[i];
							if (i != list.Count - 1)
							{
								text += ", ";
							}
						}
						Debug.LogWarning(text);
					}
					_hasCheckedCompatibility = true;
				}
				return _isCompatible;
			}
		}

		public static AuraResourcesCollection ResourcesCollection
		{
			get
			{
				if (_auraResourcesCollection == null)
				{
					_auraResourcesCollection = Resources.Load<AuraResourcesCollection>("AuraResourcesCollection");
				}
				return _auraResourcesCollection;
			}
		}

		public static AuraCamera[] GetAuraCameras(int minAmount = 0)
		{
			AuraCamera[] array = Object.FindObjectsOfType<AuraCamera>();
			if (minAmount > array.Length)
			{
				AuraCamera[] array2 = new AuraCamera[minAmount - array.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = AuraCamera.CreateGameObject("Aura Camera").GetComponent<AuraCamera>();
				}
				array = array.Append(array2);
			}
			return array;
		}

		public static AuraVolume[] GetAuraVolumes()
		{
			return Object.FindObjectsOfType<AuraVolume>();
		}

		public static AuraVolume[] SortOutByType(this AuraVolume[] volumes, VolumeType type)
		{
			return volumes.Where((AuraVolume x) => x.volumeShape.shape == type).ToArray();
		}

		public static AuraLight[] GetAuraLights()
		{
			return Object.FindObjectsOfType<AuraLight>();
		}

		public static AuraLight[] SortOutByType(this AuraLight[] auraLights, LightType type)
		{
			return auraLights.Where((AuraLight x) => x.Type == type).ToArray();
		}

		public static AuraLight[] GetAuraLights(LightType type, int minAmount = 0)
		{
			AuraLight[] array = GetAuraLights().SortOutByType(type);
			if (minAmount > array.Length)
			{
				AuraLight[] array2 = new AuraLight[minAmount - array.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = AuraLight.CreateGameObject("Aura " + type.ToString() + " Light", type).GetComponent<AuraLight>();
				}
				array = array.Append(array2);
			}
			return array;
		}

		public static void ApplyPreset(Presets preset)
		{
			AuraPreset.ApplyPreset(preset);
		}

		public static AuraCamera[] AddAuraToCameras(int amountToCreateIfNone = 0)
		{
			Camera[] array = Object.FindObjectsOfType<Camera>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].GetComponent<AuraCamera>() == null)
				{
					array[i].gameObject.AddComponent<AuraCamera>();
				}
			}
			return GetAuraCameras(amountToCreateIfNone);
		}

		public static AuraLight[] AddAuraToDirectionalLights(int amountToCreateIfNone = 0)
		{
			Light[] array = Object.FindObjectsOfType<Light>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].GetComponent<AuraLight>() == null && array[i].type == LightType.Directional)
				{
					array[i].gameObject.AddComponent<AuraLight>();
				}
			}
			return GetAuraLights(LightType.Directional, amountToCreateIfNone);
		}

		public static AuraLight[] AddAuraToSpotLights(int amountToCreateIfNone = 0)
		{
			Light[] array = Object.FindObjectsOfType<Light>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].GetComponent<AuraLight>() == null && array[i].type == LightType.Spot)
				{
					array[i].gameObject.AddComponent<AuraLight>();
				}
			}
			return GetAuraLights(LightType.Spot, amountToCreateIfNone);
		}

		public static AuraLight[] AddAuraToPointLights(int amountToCreateIfNone = 0)
		{
			Light[] array = Object.FindObjectsOfType<Light>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].GetComponent<AuraLight>() == null && array[i].type == LightType.Point)
				{
					array[i].gameObject.AddComponent<AuraLight>();
				}
			}
			return GetAuraLights(LightType.Point, amountToCreateIfNone);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnDomainReload()
		{
			_auraResourcesCollection = null;
		}
	}
}
