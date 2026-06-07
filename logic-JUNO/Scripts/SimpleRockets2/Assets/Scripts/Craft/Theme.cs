using System;
using System.Collections.Generic;
using ModApi.Common.Events;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Styles;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class Theme : ITheme, IDisposable
	{
		private static class ShaderPropertyIds
		{
			public static readonly int IsFlightScene = Shader.PropertyToID("_IsFlightScene");

			public static readonly int MaterialColors = Shader.PropertyToID("_MaterialColors");

			public static readonly int MaterialData = Shader.PropertyToID("_MaterialData");

			public static readonly int PartData = Shader.PropertyToID("_PartData");
		}

		private List<Material> _defaultPartMaterialInstances;

		private Dictionary<string, Material[]> _defaultPartTMProMaterials;

		private bool _disposed;

		private bool _inDesigner;

		private Vector4[] _materialColors;

		private Vector4[] _materialData;

		private EventHandler<EventArgs> _partMaterialsChanged;

		private Dictionary<string, List<Material>> _partTMProMaterialInstances;

		private ThemeData _themeData;

		private List<Material> _transparentPartMaterialInstances;

		public Material[] PartMaterialsAttached { get; private set; }

		public Material[] PartMaterialsBdm { get; private set; }

		public Material[] PartMaterialsCollision { get; private set; }

		public Material[] PartMaterialsDefault { get; private set; }

		public Material[] PartMaterialsDisconnected { get; private set; }

		public Material[] PartMaterialsHidden { get; private set; }

		public Material[] PartMaterialsHighlighted { get; private set; }

		public Material[] PartMaterialsSelected { get; private set; }

		public Material[] PartMaterialsTransparent { get; private set; }

		public IPartStateColors PartStateColors { get; private set; }

		public event EventHandler<EventArgs> PartMaterialsChanged
		{
			add
			{
				_partMaterialsChanged = (EventHandler<EventArgs>)Delegate.Combine(_partMaterialsChanged, WeakEventHandler.Create(value, delegate(EventHandler<EventArgs> x)
				{
					_partMaterialsChanged = (EventHandler<EventArgs>)Delegate.Remove(_partMaterialsChanged, x);
				}));
			}
			remove
			{
				_partMaterialsChanged = (EventHandler<EventArgs>)Delegate.Remove(_partMaterialsChanged, WeakEventHandler.FindUnregisterHandler(_partMaterialsChanged, value));
			}
		}

		public Theme(ThemeData themeData)
		{
			_themeData = themeData;
			_inDesigner = Game.InDesignerScene;
			_materialColors = new Vector4[50];
			_materialData = new Vector4[50];
			IGameQualitySettings qualitySettings = Game.Instance.QualitySettings;
			qualitySettings.Crafts.Changed += OnQualitySettingsChanged;
			qualitySettings.ImageEffects.ReEntry.Changed += OnQualitySettingsChanged;
			Game.Instance.PartStyleManager.TextureArraysChanged += OnQualitySettingsChanged;
			_defaultPartMaterialInstances = new List<Material>();
			_transparentPartMaterialInstances = new List<Material>();
			_defaultPartTMProMaterials = new Dictionary<string, Material[]>();
			_partTMProMaterialInstances = new Dictionary<string, List<Material>>();
			LoadPartStateColoringInfo();
			CreateOrUpdateMaterials();
			RefreshAll();
		}

		~Theme()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		public Material[] GetDefaultPartTMProMaterial(string materialKey)
		{
			if (!_defaultPartTMProMaterials.TryGetValue(materialKey, out var value))
			{
				if (!materialKey.StartsWith("TMPro_"))
				{
					Debug.LogError("Unable to get default TMPro part material with key '" + materialKey + "'");
					return null;
				}
				bool flag = materialKey.StartsWith("TMPro_BDM_");
				string text = materialKey.Substring(flag ? 10 : 6).Replace("/");
				value = CreateOrUpdateMaterials(null, "PartMaterialTMPro_" + text);
				if (flag)
				{
					value.Foreach(delegate(Material x)
					{
						x.renderQueue = 1990;
					});
				}
				UpdateMaterialProperties(value);
				ApplyQualitySettings(Game.Instance.QualitySettings, value);
				_defaultPartTMProMaterials[materialKey] = value;
			}
			return value;
		}

		public float GetMaterialIndex(int materialId)
		{
			if (materialId < 0)
			{
				materialId = _themeData.MaterialCount + Math.Max(materialId, -_themeData.MaterialCount);
			}
			if (materialId >= _themeData.MaterialCount)
			{
				Debug.LogError($"Material id '{materialId}' does not exist in the current theme. Unable to retrieve texture coordinates.");
				return 0f;
			}
			return (float)materialId * 0.01f + 0.003f;
		}

		public void RefreshAll()
		{
			RefreshMaterials();
			ApplyQualitySettings(Game.Instance.QualitySettings);
		}

		public void RefreshMaterialProperties()
		{
			UpdateMaterialProperties();
		}

		public void ReleaseDefaultPartMaterialInstance(Material material)
		{
			if (!_disposed)
			{
				if (!_defaultPartMaterialInstances.Remove(material))
				{
					Debug.LogError("Unable to release default part material instance because it could not be found.", material);
				}
				else
				{
					UnityEngine.Object.Destroy(material);
				}
			}
		}

		public void ReleasePartTMProMaterialInstance(string materialKey, Material material)
		{
			if (_disposed)
			{
				return;
			}
			if (_partTMProMaterialInstances.TryGetValue(materialKey, out var value))
			{
				if (!value.Remove(material))
				{
					Debug.LogError("Unable to release part text mesh pro material instance because it could not be found.", material);
				}
				else
				{
					UnityEngine.Object.Destroy(material);
				}
			}
			else
			{
				Debug.LogError("Unable to release part text mesh pro material instance because the list of materials with key '" + materialKey + "' could not be found.", material);
			}
		}

		public void ReleaseTransparentPartMaterialInstance(Material material)
		{
			if (!_disposed)
			{
				if (!_transparentPartMaterialInstances.Remove(material))
				{
					Debug.LogError("Unable to release transparent part material instance because it could not be found.", material);
				}
				else
				{
					UnityEngine.Object.Destroy(material);
				}
			}
		}

		public Material RequestDefaultPartMaterialInstance()
		{
			if (PartMaterialsDefault == null || PartMaterialsDefault.Length == 0 || _disposed)
			{
				return null;
			}
			Material material = UnityEngine.Object.Instantiate(PartMaterialsDefault[0]);
			UpdateMaterialProperties(material);
			ApplyQualitySettings(Game.Instance.QualitySettings, material);
			_defaultPartMaterialInstances.Add(material);
			return material;
		}

		public Material RequestPartTMProMaterialInstance(string materialKey)
		{
			if (_disposed)
			{
				return null;
			}
			Material material = UnityEngine.Object.Instantiate(GetDefaultPartTMProMaterial(materialKey)[0]);
			UpdateMaterialProperties(material);
			ApplyQualitySettings(Game.Instance.QualitySettings, material);
			_defaultPartMaterialInstances.Add(material);
			return material;
		}

		public Material RequestTransparentPartMaterialInstance()
		{
			if (PartMaterialsTransparent == null || PartMaterialsTransparent.Length == 0 || _disposed)
			{
				return null;
			}
			Material material = UnityEngine.Object.Instantiate(PartMaterialsTransparent[0]);
			UpdateMaterialProperties(material);
			ApplyQualitySettings(Game.Instance.QualitySettings, material);
			_transparentPartMaterialInstances.Add(material);
			return material;
		}

		public void UpdateMaterialRenderQueues(Material[] partMaterials, PartMeshRenderQueue renderQueue)
		{
			int renderQueue2 = ((renderQueue == PartMeshRenderQueue.Default) ? (-1) : 1990);
			for (int i = 0; i < partMaterials.Length; i++)
			{
				partMaterials[i].renderQueue = renderQueue2;
			}
		}

		public void UpdateThemeMaterial(int materialId)
		{
			RefreshMaterial(materialId, applyChange: true);
		}

		public void UpdateThemeMaterial(int materialId, Color color, float smoothness, float metallicness, float detailStrength, float emissionStrength)
		{
			_themeData.UpdateMaterial(materialId, color, smoothness, metallicness, detailStrength, emissionStrength);
			RefreshMaterial(materialId, applyChange: true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}
			IGameQualitySettings qualitySettings = Game.Instance.QualitySettings;
			qualitySettings.Crafts.Changed -= OnQualitySettingsChanged;
			qualitySettings.ImageEffects.ReEntry.Changed -= OnQualitySettingsChanged;
			Game.Instance.PartStyleManager.TextureArraysChanged -= OnQualitySettingsChanged;
			DestroyMaterials(PartMaterialsDefault);
			DestroyMaterials(PartMaterialsTransparent);
			DestroyMaterials(PartMaterialsBdm);
			DestroyMaterials(PartMaterialsSelected);
			DestroyMaterials(PartMaterialsHighlighted);
			DestroyMaterials(PartMaterialsAttached);
			DestroyMaterials(PartMaterialsCollision);
			DestroyMaterials(PartMaterialsDisconnected);
			PartMaterialsDefault = null;
			PartMaterialsTransparent = null;
			PartMaterialsBdm = null;
			PartMaterialsSelected = null;
			PartMaterialsHighlighted = null;
			PartMaterialsAttached = null;
			PartMaterialsCollision = null;
			PartMaterialsDisconnected = null;
			PartMaterialsHidden = null;
			for (int i = 0; i < _defaultPartMaterialInstances.Count; i++)
			{
				UnityEngine.Object.Destroy(_defaultPartMaterialInstances[i]);
			}
			_defaultPartMaterialInstances.Clear();
			for (int j = 0; j < _transparentPartMaterialInstances.Count; j++)
			{
				UnityEngine.Object.Destroy(_transparentPartMaterialInstances[j]);
			}
			_defaultPartTMProMaterials.Foreach(delegate(KeyValuePair<string, Material[]> x)
			{
				DestroyMaterials(x.Value);
			});
			_partTMProMaterialInstances.Foreach(delegate(KeyValuePair<string, List<Material>> x)
			{
				x.Value.Foreach(delegate(Material y)
				{
					UnityEngine.Object.Destroy(y);
				});
			});
			_defaultPartTMProMaterials.Clear();
			_partTMProMaterialInstances.Clear();
			_transparentPartMaterialInstances.Clear();
			_disposed = true;
		}

		private static Material LoadMaterial(string name, bool createCopy)
		{
			Material material = Game.Instance.ResourceLoader.LoadMaterial("Craft/Parts/Materials/" + name);
			if (!createCopy)
			{
				return material;
			}
			return new Material(material);
		}

		private void ApplyQualitySettings(IGameQualitySettings quality)
		{
			ApplyQualitySettings(quality, PartMaterialsDefault);
			ApplyQualitySettings(quality, PartMaterialsTransparent);
			ApplyQualitySettings(quality, PartMaterialsBdm);
			ApplyQualitySettings(quality, PartMaterialsSelected);
			foreach (Material defaultPartMaterialInstance in _defaultPartMaterialInstances)
			{
				ApplyQualitySettings(quality, defaultPartMaterialInstance);
			}
			foreach (Material transparentPartMaterialInstance in _transparentPartMaterialInstances)
			{
				ApplyQualitySettings(quality, transparentPartMaterialInstance);
			}
			_defaultPartTMProMaterials.Foreach(delegate(KeyValuePair<string, Material[]> x)
			{
				ApplyQualitySettings(quality, x.Value);
			});
			_partTMProMaterialInstances.Foreach(delegate(KeyValuePair<string, List<Material>> x)
			{
				x.Value.Foreach(delegate(Material y)
				{
					ApplyQualitySettings(quality, y);
				});
			});
			if (_inDesigner)
			{
				ApplyQualitySettings(quality, PartMaterialsHighlighted);
				ApplyQualitySettings(quality, PartMaterialsAttached);
				ApplyQualitySettings(quality, PartMaterialsCollision);
			}
		}

		private void ApplyQualitySettings(IGameQualitySettings quality, params Material[] materials)
		{
			CraftQualitySettings.DetailTextureQuality value = quality.Crafts.DetailTextures.Value;
			CraftQualitySettings.NormalMapQuality value2 = quality.Crafts.NormalMaps.Value;
			ImageEffectsQualitySettings.ReEntryQuality value3 = quality.ImageEffects.ReEntry.Value;
			bool inFlightScene = Game.InFlightScene;
			foreach (Material material in materials)
			{
				if (value != CraftQualitySettings.DetailTextureQuality.Disabled)
				{
					material.EnableKeyword("DETAIL_TEXTURES_ON");
				}
				else
				{
					material.DisableKeyword("DETAIL_TEXTURES_ON");
				}
				if (value2 != CraftQualitySettings.NormalMapQuality.Disabled)
				{
					material.EnableKeyword("NORMAL_MAPS_ON");
				}
				else
				{
					material.DisableKeyword("NORMAL_MAPS_ON");
				}
				if (value3 != ImageEffectsQualitySettings.ReEntryQuality.Off && inFlightScene)
				{
					material.EnableKeyword("CRAFT_MASK_RENDER_ON");
				}
				else
				{
					material.DisableKeyword("CRAFT_MASK_RENDER_ON");
				}
			}
		}

		private Material[] CreateOrUpdateMaterials(Material[] partMaterials, string materialNameBase)
		{
			string name = materialNameBase + GetPartMaterialQualitySuffix();
			if (partMaterials == null)
			{
				partMaterials = new Material[1] { LoadMaterial(name, createCopy: true) };
			}
			else
			{
				Material material = LoadMaterial(name, createCopy: false);
				for (int i = 0; i < partMaterials.Length; i++)
				{
					partMaterials[i].shader = material.shader;
					partMaterials[i].CopyPropertiesFromMaterial(material);
				}
			}
			return partMaterials;
		}

		private void CreateOrUpdateMaterials()
		{
			PartMaterialsDefault = CreateOrUpdateMaterials(PartMaterialsDefault, "PartMaterialDefault");
			PartMaterialsTransparent = CreateOrUpdateMaterials(PartMaterialsTransparent, "PartMaterialTransparent");
			PartMaterialsSelected = CreateOrUpdateMaterials(PartMaterialsSelected, "PartMaterialSelected");
			PartMaterialsHighlighted = CreateOrUpdateMaterials(PartMaterialsHighlighted, "PartMaterialHighlighted");
			PartMaterialsAttached = CreateOrUpdateMaterials(PartMaterialsAttached, "PartMaterialAttached");
			PartMaterialsCollision = CreateOrUpdateMaterials(PartMaterialsCollision, "PartMaterialCollision");
			PartMaterialsBdm = CreateOrUpdateMaterials(PartMaterialsBdm, "PartMaterialDefault");
			Material[] partMaterialsBdm = PartMaterialsBdm;
			for (int i = 0; i < partMaterialsBdm.Length; i++)
			{
				partMaterialsBdm[i].renderQueue = 1990;
			}
			if (PartMaterialsHidden == null)
			{
				PartMaterialsHidden = new Material[1] { LoadMaterial("PartMaterialHidden", createCopy: false) };
			}
			if (PartMaterialsDisconnected == null)
			{
				PartMaterialsDisconnected = new Material[1] { LoadMaterial("PartMaterialDisconnected", createCopy: true) };
			}
			UpdateMaterialColors();
		}

		private void DestroyMaterials(Material[] materials)
		{
			if (materials != null)
			{
				for (int i = 0; i < materials.Length; i++)
				{
					UnityEngine.Object.Destroy(materials[i]);
				}
			}
		}

		private string GetPartMaterialQualitySuffix()
		{
			return string.Empty;
		}

		private void LoadPartStateColoringInfo()
		{
			PartStateColors = Game.Instance.ResourceLoader.LoadScriptableObject<IPartStateColors>("Craft/Parts/PartColors");
		}

		private void OnQualitySettingsChanged(object sender, EventArgs e)
		{
			CreateOrUpdateMaterials();
			UpdateMaterialProperties();
			ApplyQualitySettings(Game.Instance.QualitySettings);
		}

		private void RefreshMaterial(int materialId, bool applyChange)
		{
			PartMaterial material = _themeData.GetMaterial(materialId);
			Color linear = material.Color.linear;
			linear.a = 1f - material.TransparencyStrength;
			_materialColors[materialId] = linear;
			_materialData[materialId] = new Vector4(material.Metallic, material.Smoothness + material.SmoothnessModifier, material.DetailStrength * 2f, material.EmissionStrength);
			if (applyChange)
			{
				UpdateMaterialProperties();
				_partMaterialsChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		private void RefreshMaterials()
		{
			for (int i = 0; i < _themeData.MaterialCount; i++)
			{
				RefreshMaterial(i, applyChange: false);
			}
			UpdateMaterialProperties();
			_partMaterialsChanged?.Invoke(this, EventArgs.Empty);
		}

		private void UpdateMaterialColors()
		{
			UpdateMaterialColors(PartMaterialsSelected, PartStateColors.Selected.linear);
			UpdateMaterialColors(PartMaterialsHighlighted, PartStateColors.Highlighted.linear);
			UpdateMaterialColors(PartMaterialsAttached, PartStateColors.Attached.linear);
			UpdateMaterialColors(PartMaterialsCollision, PartStateColors.Colliding.linear);
			PartMaterialsDisconnected[0].color = PartStateColors.DisconnectedPrimary.linear;
		}

		private void UpdateMaterialColors(Material[] partMaterials, Color color)
		{
			for (int i = 0; i < partMaterials.Length; i++)
			{
				partMaterials[i].color = color;
			}
		}

		private void UpdateMaterialProperties()
		{
			UpdateMaterialProperties(PartMaterialsDefault);
			UpdateMaterialProperties(PartMaterialsTransparent);
			UpdateMaterialProperties(PartMaterialsBdm);
			UpdateMaterialProperties(PartMaterialsSelected);
			foreach (Material defaultPartMaterialInstance in _defaultPartMaterialInstances)
			{
				UpdateMaterialProperties(defaultPartMaterialInstance);
			}
			foreach (Material transparentPartMaterialInstance in _transparentPartMaterialInstances)
			{
				UpdateMaterialProperties(transparentPartMaterialInstance);
			}
			_defaultPartTMProMaterials.Foreach(delegate(KeyValuePair<string, Material[]> x)
			{
				UpdateMaterialProperties(x.Value);
			});
			_partTMProMaterialInstances.Foreach(delegate(KeyValuePair<string, List<Material>> x)
			{
				x.Value.Foreach(delegate(Material y)
				{
					UpdateMaterialProperties(y);
				});
			});
			if (_inDesigner)
			{
				UpdateMaterialProperties(PartMaterialsHighlighted);
				UpdateMaterialProperties(PartMaterialsAttached);
				UpdateMaterialProperties(PartMaterialsCollision);
			}
		}

		private void UpdateMaterialProperties(params Material[] materials)
		{
			IPartStyleManager partStyleManager = Game.Instance.PartStyleManager;
			bool inFlightScene = Game.InFlightScene;
			foreach (Material material in materials)
			{
				material.SetTexture("_DetailTextures", partStyleManager.DetailTextures);
				material.SetTexture("_NormalMapTextures", partStyleManager.NormalMapTextures);
				material.SetVectorArray(ShaderPropertyIds.MaterialColors, _materialColors);
				material.SetVectorArray(ShaderPropertyIds.MaterialData, _materialData);
				if (inFlightScene)
				{
					material.SetFloat(ShaderPropertyIds.IsFlightScene, 1f);
				}
				else
				{
					material.SetFloat(ShaderPropertyIds.IsFlightScene, 0f);
				}
			}
		}
	}
}
