using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Paint;
using Assets.Scripts.Settings;
using Assets.Scripts.Storage;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class ThemeScript
	{
		public static class ShaderPropertyIds
		{
			public static readonly int Glossiness = Shader.PropertyToID("_Glossiness");

			public static readonly int MaterialData = Shader.PropertyToID("_MaterialData");

			public static readonly int MaterialTextureMatrixData = Shader.PropertyToID("_MaterialTextureMatrixData");

			public static readonly int Metallic = Shader.PropertyToID("_Metallic");

			public static readonly int MetallicGlossMap = Shader.PropertyToID("_MetallicGlossMap");

			public static readonly int PaintOrigin = Shader.PropertyToID("_PaintOrigin");

			public static readonly int SinglePlaneTextureColorMask = Shader.PropertyToID("_SinglePlaneTextureColorMask");

			public static readonly int TriPlaneTextureColorMask = Shader.PropertyToID("_TriPlaneTextureColorMask");

			public static readonly int UseBakedPositionsAndNormals = Shader.PropertyToID("_UseBakedPositionsAndNormals");
		}

		private const int MaterialDataMaxCountPerMaterial = 10;

		private static readonly int _srcBlendProp = Shader.PropertyToID("_SrcBlend");

		private List<Material> _defaultHighlightMaterials;

		private List<Material> _defaultPartMaterialInstances;

		private bool _disposed;

		private Dictionary<int, Material> _highlightMaterials = new Dictionary<int, Material>();

		private Dictionary<int, Material> _highlightSelectedMaterials = new Dictionary<int, Material>();

		private CraftLoadContext _loadContext;

		private Vector4[] _materialData;

		private Matrix4x4[] _materialTextureMatrixData;

		private List<Material> _transparentPartMaterialInstances;

		public Material Material { get; private set; }

		public Material MaterialBdm { get; private set; }

		public Material MaterialOutline { get; private set; }

		public Material MaterialTransparent { get; private set; }

		public Material MaterialTransparentZWrite { get; private set; }

		public Material MaterialTutorialHighlight { get; private set; }

		public Material MaterialTutorialHighlightZTestAlways { get; private set; }

		public ThemeData Theme { get; set; }

		public ThemeScript(ThemeData theme, CraftLoadContext loadContext)
		{
			Theme = theme;
			_loadContext = loadContext;
			_materialData = new Vector4[500];
			_materialTextureMatrixData = new Matrix4x4[50];
			_defaultHighlightMaterials = new List<Material>();
			_defaultPartMaterialInstances = new List<Material>();
			_transparentPartMaterialInstances = new List<Material>();
			Game.Instance.Settings.Quality.Craft.Reflections.Changed += OnQualitySettingsChanged;
			InitializeMaterials();
		}

		public Material GetHighlightMaterial(Material regularMaterial)
		{
			int instanceID = regularMaterial.GetInstanceID();
			if (_highlightMaterials.ContainsKey(instanceID))
			{
				Material material = _highlightMaterials[instanceID];
				if (!(material == null))
				{
					return material;
				}
				return null;
			}
			return null;
		}

		public Material GetHighlightSelectedMaterial(Material regularMaterial)
		{
			int instanceID = regularMaterial.GetInstanceID();
			if (_highlightSelectedMaterials.ContainsKey(instanceID))
			{
				Material material = _highlightSelectedMaterials[instanceID];
				if (!(material == null))
				{
					return material;
				}
				return null;
			}
			return null;
		}

		public Material InitializeHighlightMaterial(Material material)
		{
			int instanceID = material.GetInstanceID();
			if (_highlightMaterials.ContainsKey(instanceID))
			{
				return _highlightMaterials[instanceID];
			}
			Material material2 = null;
			if (material == Material || material == MaterialBdm || material == MaterialTransparent || material == MaterialTransparentZWrite)
			{
				material2 = CreateDefaultHighlightMaterial(material, 0.1f);
				_highlightMaterials.Add(instanceID, material2);
			}
			else
			{
				material2 = CreateHighlightMaterial(material);
				_highlightMaterials.Add(instanceID, material2);
			}
			return material2;
		}

		public Material InitializeHighlightSelectedMaterial(Material material)
		{
			int instanceID = material.GetInstanceID();
			if (_highlightSelectedMaterials.ContainsKey(instanceID))
			{
				return _highlightSelectedMaterials[instanceID];
			}
			Material material2 = null;
			if (material == Material || material == MaterialBdm || material == MaterialTransparent || material == MaterialTransparentZWrite)
			{
				material2 = CreateDefaultHighlightMaterial(material, 0.3f);
				_highlightSelectedMaterials.Add(instanceID, material2);
			}
			else
			{
				material2 = CreateHighlightMaterial(material);
				_highlightSelectedMaterials.Add(instanceID, material2);
			}
			return material2;
		}

		public void OnDestroy()
		{
			_disposed = true;
			Game.Instance.Settings.Quality.Craft.Reflections.Changed -= OnQualitySettingsChanged;
			CleanupMaterials();
		}

		public void ReleaseDefaultPartMaterialInstance(Material material)
		{
			if (material == null)
			{
				return;
			}
			if (_disposed)
			{
				UnityEngine.Object.Destroy(material);
				return;
			}
			if (!_defaultPartMaterialInstances.Remove(material))
			{
				Debug.LogError("Unable to release default part material instance because it could not be found.", material);
				return;
			}
			if (_loadContext == CraftLoadContext.Designer)
			{
				int instanceID = material.GetInstanceID();
				if (_highlightMaterials.TryGetValue(instanceID, out var value))
				{
					UnityEngine.Object.Destroy(value);
					_highlightMaterials.Remove(instanceID);
				}
				if (_highlightSelectedMaterials.TryGetValue(instanceID, out var value2))
				{
					UnityEngine.Object.Destroy(value2);
					_highlightSelectedMaterials.Remove(instanceID);
				}
			}
			UnityEngine.Object.Destroy(material);
		}

		public void ReleaseTransparentPartMaterialInstance(Material material)
		{
			if (material == null)
			{
				return;
			}
			if (_disposed)
			{
				UnityEngine.Object.Destroy(material);
				return;
			}
			if (!_transparentPartMaterialInstances.Remove(material))
			{
				Debug.LogError("Unable to release transparent part material instance because it could not be found.", material);
				return;
			}
			if (_loadContext == CraftLoadContext.Designer)
			{
				int instanceID = material.GetInstanceID();
				if (_highlightMaterials.TryGetValue(instanceID, out var value))
				{
					UnityEngine.Object.Destroy(value);
					_highlightMaterials.Remove(instanceID);
				}
				if (_highlightSelectedMaterials.TryGetValue(instanceID, out var value2))
				{
					UnityEngine.Object.Destroy(value2);
					_highlightSelectedMaterials.Remove(instanceID);
				}
			}
			UnityEngine.Object.Destroy(material);
		}

		public Material ReplaceHighlightMaterial(Material originalRegularMaterial, Material newRegularMaterial)
		{
			int instanceID = originalRegularMaterial.GetInstanceID();
			if (_highlightMaterials.ContainsKey(instanceID))
			{
				UnityEngine.Object.Destroy(_highlightMaterials[instanceID]);
				_highlightMaterials.Remove(instanceID);
			}
			return InitializeHighlightMaterial(newRegularMaterial);
		}

		public Material RequestDefaultPartMaterialInstance()
		{
			if (Material == null || _disposed)
			{
				return null;
			}
			Material material = UnityEngine.Object.Instantiate(Material);
			material.name = "Part Material Default [Instance]";
			UpdateMaterialProperties(material);
			ApplyQualitySettings(Game.Instance.Settings.Quality, material);
			_defaultPartMaterialInstances.Add(material);
			return material;
		}

		public Material RequestTransparentPartMaterialInstance(bool zwrite)
		{
			return RequestTransparentPartMaterialInstance(zwrite, preserveSpecular: true);
		}

		public Material RequestTransparentPartMaterialInstance(bool zwrite, bool preserveSpecular)
		{
			if ((zwrite && MaterialTransparentZWrite == null) || (!zwrite && MaterialTransparent == null) || _disposed)
			{
				return null;
			}
			Material material = UnityEngine.Object.Instantiate(zwrite ? MaterialTransparentZWrite : MaterialTransparent);
			material.name = (zwrite ? "Part Material Transparent ZWrite (Instance)" : "Part Material Transparent (Instance)");
			if (preserveSpecular)
			{
				material.SetFloat(_srcBlendProp, 1f);
				material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
			}
			else
			{
				material.SetFloat(_srcBlendProp, 5f);
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
			}
			if (_loadContext == CraftLoadContext.Designer)
			{
				material.renderQueue = (zwrite ? 3001 : 3005);
			}
			UpdateMaterialProperties(material);
			ApplyQualitySettings(Game.Instance.Settings.Quality, material);
			_transparentPartMaterialInstances.Add(material);
			return material;
		}

		public Material UpdateHighlightMaterial(Material regularMaterial)
		{
			int instanceID = regularMaterial.GetInstanceID();
			if (!_highlightMaterials.ContainsKey(instanceID))
			{
				return null;
			}
			Material material = _highlightMaterials[instanceID];
			UpdateHighlightMaterial(regularMaterial, material);
			return material;
		}

		public void UpdateMaterialProperties()
		{
			UpdateMaterialProperties(Material);
			foreach (Material defaultPartMaterialInstance in _defaultPartMaterialInstances)
			{
				UpdateMaterialProperties(defaultPartMaterialInstance);
			}
			UpdateMaterialProperties(MaterialBdm);
			UpdateMaterialProperties(MaterialTransparent);
			UpdateMaterialProperties(MaterialTransparentZWrite);
			foreach (Material transparentPartMaterialInstance in _transparentPartMaterialInstances)
			{
				UpdateMaterialProperties(transparentPartMaterialInstance);
			}
			foreach (Material defaultHighlightMaterial in _defaultHighlightMaterials)
			{
				UpdateMaterialProperties(defaultHighlightMaterial);
			}
		}

		public void UpdateMaterials()
		{
			UpdateMaterialData();
			UpdateMaterialProperties();
		}

		public void UpdatePaintOrigin(Vector3 paintOrigin)
		{
			Matrix4x4 value = Matrix4x4.Translate(-paintOrigin);
			Material.SetMatrix(ShaderPropertyIds.PaintOrigin, value);
			foreach (Material defaultPartMaterialInstance in _defaultPartMaterialInstances)
			{
				defaultPartMaterialInstance.SetMatrix(ShaderPropertyIds.PaintOrigin, value);
			}
			MaterialTransparent.SetMatrix(ShaderPropertyIds.PaintOrigin, value);
			MaterialTransparentZWrite.SetMatrix(ShaderPropertyIds.PaintOrigin, value);
			foreach (Material transparentPartMaterialInstance in _transparentPartMaterialInstances)
			{
				transparentPartMaterialInstance.SetMatrix(ShaderPropertyIds.PaintOrigin, value);
			}
			foreach (Material defaultHighlightMaterial in _defaultHighlightMaterials)
			{
				defaultHighlightMaterial.SetMatrix(ShaderPropertyIds.PaintOrigin, value);
			}
		}

		private static void UpdateHighlightMaterial(Material regularMaterial, Material highlightMaterial)
		{
			try
			{
				highlightMaterial.EnableKeyword("_METALLICGLOSSMAP");
				highlightMaterial.EnableKeyword("_EMISSION");
				if (regularMaterial.HasProperty("_BaseColor"))
				{
					highlightMaterial.SetColor("_BaseColor", regularMaterial.color + new Color(0.5f, 0.5f, 0.5f));
				}
				else if (regularMaterial.HasProperty("_Color"))
				{
					highlightMaterial.SetColor("_Color", regularMaterial.color + new Color(0.5f, 0.5f, 0.5f));
				}
				if (regularMaterial.HasProperty("_EmissionColor"))
				{
					highlightMaterial.SetColor("_EmissionColor", regularMaterial.GetColor("_EmissionColor") + new Color(0.1f, 0.1f, 0.1f));
				}
			}
			catch (Exception innerException)
			{
				highlightMaterial.LogException(innerException, "An error occurred updating the highlight material for material '{0}'", regularMaterial.name);
			}
		}

		private void ApplyQualitySettings(IGameQualitySettings quality, Material material)
		{
			if (!(material == null))
			{
				bool flag = quality.Craft.Reflections.Value == CraftQualitySettings.CraftReflectionsQuality.None;
				material.SetLocalKeyword("USE_SIMPLE_LIGHTING", flag, logErrors: false);
				material.SetFloat("_UseSimpleLightingEnabled", flag ? 1 : 0);
			}
		}

		private void ApplyQualitySettings(IGameQualitySettings quality)
		{
			ApplyQualitySettings(quality, Material);
			ApplyQualitySettings(quality, MaterialTransparent);
			ApplyQualitySettings(quality, MaterialTransparentZWrite);
			ApplyQualitySettings(quality, MaterialBdm);
			ApplyQualitySettings(quality, MaterialOutline);
			ApplyQualitySettings(quality, MaterialTutorialHighlight);
			ApplyQualitySettings(quality, MaterialTutorialHighlightZTestAlways);
			foreach (Material defaultHighlightMaterial in _defaultHighlightMaterials)
			{
				ApplyQualitySettings(quality, defaultHighlightMaterial);
			}
			foreach (Material defaultPartMaterialInstance in _defaultPartMaterialInstances)
			{
				ApplyQualitySettings(quality, defaultPartMaterialInstance);
			}
			foreach (Material transparentPartMaterialInstance in _transparentPartMaterialInstances)
			{
				ApplyQualitySettings(quality, transparentPartMaterialInstance);
			}
		}

		private void CleanupMaterials()
		{
			DestroyMaterial(Material);
			DestroyMaterial(MaterialTransparent);
			DestroyMaterial(MaterialTransparentZWrite);
			DestroyMaterial(MaterialOutline);
			DestroyMaterial(MaterialTutorialHighlight);
			DestroyMaterial(MaterialTutorialHighlightZTestAlways);
			DestroyMaterial(MaterialBdm);
			Material = null;
			MaterialTransparent = null;
			MaterialTransparentZWrite = null;
			MaterialOutline = null;
			MaterialTutorialHighlight = null;
			MaterialTutorialHighlightZTestAlways = null;
			MaterialBdm = null;
			DestroyMaterials(_defaultPartMaterialInstances);
			DestroyMaterials(_transparentPartMaterialInstances);
			DestroyMaterials(_highlightMaterials.Values);
			DestroyMaterials(_highlightSelectedMaterials.Values);
			DestroyMaterials(_defaultHighlightMaterials);
			_defaultPartMaterialInstances.Clear();
			_transparentPartMaterialInstances.Clear();
			_highlightMaterials.Clear();
			_highlightSelectedMaterials.Clear();
			_defaultHighlightMaterials.Clear();
			static void DestroyMaterial(Material m)
			{
				if (m != null)
				{
					UnityEngine.Object.Destroy(m);
				}
			}
			static void DestroyMaterials(ICollection<Material> materials)
			{
				materials.Foreach(delegate(Material x)
				{
					DestroyMaterial(x);
				});
			}
		}

		private Material CreateDefaultHighlightMaterial(Material partMaterial, float emissionStrength)
		{
			Material material = new Material(partMaterial);
			material.SetFloat("_EmissiveOverride", 1f);
			material.SetFloat("_EmissiveOverrideNight", 1f);
			material.SetColor("_EmissionColor", new Color(emissionStrength, emissionStrength, emissionStrength));
			material.EnableKeyword("USE_EMISSION_COLOR");
			material.name = partMaterial.name + " (Highlight)";
			UpdateMaterialProperties(material);
			_defaultHighlightMaterials.Add(material);
			return material;
		}

		private Material CreateHighlightMaterial(Material regularMaterial)
		{
			Material material = new Material(regularMaterial);
			UpdateHighlightMaterial(regularMaterial, material);
			return material;
		}

		private void InitializeMaterials()
		{
			IResourceLoader resourceLoader = Game.Instance.ResourceLoader;
			Material = resourceLoader.InstantiateMaterial("Craft/Parts/Materials/PartMaterial");
			MaterialBdm = resourceLoader.InstantiateMaterial("Craft/Parts/Materials/PartMaterial");
			MaterialTransparent = resourceLoader.InstantiateMaterial("Craft/Parts/Materials/PartMaterialTransparent");
			MaterialTransparentZWrite = resourceLoader.InstantiateMaterial("Craft/Parts/Materials/PartMaterialTransparentZWrite");
			MaterialOutline = resourceLoader.InstantiateMaterial("Craft/Parts/Materials/PartMaterialOutline");
			MaterialTutorialHighlight = resourceLoader.InstantiateMaterial("Craft/Parts/Materials/PartMaterialTutorialHighlight");
			MaterialTutorialHighlightZTestAlways = resourceLoader.InstantiateMaterial("Craft/Parts/Materials/PartMaterialTutorialHighlightZTestAlways");
			Material.name = "Part Material Default (Shared)";
			MaterialBdm.name = "Part Material BDM (Shared)";
			MaterialTransparent.name = "Part Material Transparent (Shared)";
			MaterialTransparentZWrite.name = "Part Material Transparent ZWrite (Shared)";
			MaterialOutline.name = "Part Material Outline (Shared)";
			MaterialTutorialHighlight.name = "Part Material Tutorial Highlight (Shared)";
			MaterialTutorialHighlightZTestAlways.name = "Part Material Tutorial Highlight ZTest Always (Shared)";
			MaterialBdm.renderQueue = 1990;
			UpdateMaterials();
			ApplyQualitySettings(Game.Instance.Settings.Quality);
		}

		private void OnQualitySettingsChanged(object sender, EventArgs e)
		{
			ApplyQualitySettings(Game.Instance.Settings.Quality);
		}

		private void UpdateMaterialData()
		{
			IReadOnlyList<PartMaterial> allMaterials = Theme.AllMaterials;
			int num = Mathf.Min(50, allMaterials.Count);
			for (int i = 0; i < num; i++)
			{
				PartMaterial partMaterial = allMaterials[i];
				int num2 = i * 10;
				int num3 = 0;
				int num4 = partMaterial.Texture?.ColorCount ?? 1;
				float z = Mathf.Lerp(1f, 25f, (float)Math.Pow(1f - partMaterial.TextureBlend, 1.5));
				int num5 = ((num4 >= 4) ? 1 : 0);
				_materialData[num2 + num3++] = new Vector4((float)partMaterial.Style, partMaterial.Texture?.TextureIndex ?? (-1), z, ((int?)partMaterial.Texture?.NormalizationFlags).GetValueOrDefault());
				_materialData[num2 + num3++] = ((partMaterial.Style == PaintStyle.SinglePlaneTextureColorMask) ? new Vector4((float)partMaterial.TextureWrapMode[0], (float)partMaterial.TextureWrapMode[1], (float)partMaterial.TextureWrapMode[2], num5) : new Vector4(0f, 0f, 0f, num5));
				IPaintTexturePreset paintTexturePreset = partMaterial.Texture?.FindPreset(partMaterial.TexturePresetId ?? string.Empty);
				if (paintTexturePreset != null)
				{
					_materialTextureMatrixData[i] = Matrix4x4.Translate(new Vector3(0.5f, 0.5f, 0.5f)) * Matrix4x4.Scale(0.1f * Vector3.Scale(partMaterial.Texture?.Scale ?? Vector3.one, Vector3.Scale(partMaterial.TextureScale, paintTexturePreset.Scale))) * Matrix4x4.Translate(paintTexturePreset.Offset + partMaterial.TextureOffset) * Matrix4x4.Rotate(Quaternion.Euler(paintTexturePreset.Rotation) * Quaternion.Euler(partMaterial.TextureRotation));
				}
				else
				{
					_materialTextureMatrixData[i] = Matrix4x4.Translate(new Vector3(0.5f, 0.5f, 0.5f)) * Matrix4x4.Scale(0.1f * Vector3.Scale(partMaterial.Texture?.Scale ?? Vector3.one, partMaterial.TextureScale)) * Matrix4x4.Translate(partMaterial.TextureOffset) * Matrix4x4.Rotate(Quaternion.Euler(partMaterial.TextureRotation));
				}
				for (int j = 0; j < num4; j++)
				{
					PaintColorData paintColorData = partMaterial.ColorData[j];
					_materialData[num2 + num3++] = paintColorData.Color.linear;
					_materialData[num2 + num3++] = new Vector4(paintColorData.Metallic ?? partMaterial.Metallic, (paintColorData.Smoothness ?? partMaterial.Smoothness) + partMaterial.SmoothnessModifier, paintColorData.EmissionDay ?? partMaterial.EmissionDay, paintColorData.EmissionNight ?? partMaterial.EmissionNight);
				}
			}
		}

		private void UpdateMaterialProperties(Material material)
		{
			material.SetVectorArray(ShaderPropertyIds.MaterialData, _materialData);
			material.SetMatrixArray(ShaderPropertyIds.MaterialTextureMatrixData, _materialTextureMatrixData);
			material.SetInt(ShaderPropertyIds.UseBakedPositionsAndNormals, (_loadContext != CraftLoadContext.Designer) ? 1 : 0);
			material.SetTexture(ShaderPropertyIds.SinglePlaneTextureColorMask, Game.Instance.PaintTextureManager.GetTextureArray(PaintStyle.SinglePlaneTextureColorMask));
			material.SetTexture(ShaderPropertyIds.TriPlaneTextureColorMask, Game.Instance.PaintTextureManager.GetTextureArray(PaintStyle.TriPlaneTextureColorMask));
		}
	}
}
