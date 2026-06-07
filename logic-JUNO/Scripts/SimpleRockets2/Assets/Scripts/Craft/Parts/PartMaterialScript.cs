using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers;
using ModApi;
using ModApi.Common.Coroutines;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Events;
using ModApi.Craft.Parts.Styles;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts
{
	public class PartMaterialScript : MonoBehaviour, IPartMaterialScript
	{
		public class RendererMaterialMap : IRendererMaterialMap
		{
			private static class ShaderPropertyIds
			{
				public static readonly int AlphaOverride = Shader.PropertyToID("_AlphaOverride");

				public static readonly int DecalTexture = Shader.PropertyToID("_DecalTexture");

				public static readonly int DecalTextureMaterialIds = Shader.PropertyToID("_DecalTextureMaterialIds");

				public static readonly int DecalTextureST = Shader.PropertyToID("_DecalTexture_ST");

				public static readonly int EmissiveOverride = Shader.PropertyToID("_EmissiveOverride");

				public static readonly int UseDecalTexture = Shader.PropertyToID("_UseDecalTexture");
			}

			private float _alphaOverride;

			private Material[] _currentMaterials;

			private float _emissiveOverride;

			private Func<Mesh> _getMesh;

			private MaterialPropertyBlock _materialPropertyBlock;

			private Material[] _materialSwapBuffer;

			private Action<RendererMaterialMap, Material[]> _setMaterials;

			private bool _tempRenderEnabledState;

			private bool _tempRenderInProgress;

			private int _tempRenderOriginalLayer;

			private Material[] _tempRenderOriginalMaterials;

			private bool[] _trimLevelsUsed;

			public float AlphaOverride
			{
				get
				{
					return _alphaOverride;
				}
				set
				{
					if (_alphaOverride != value)
					{
						_alphaOverride = value;
						PartMaterialScript._partGroupPartMaterialData?.PartGroup.OnAlphaOverrideChanged();
					}
				}
			}

			public int CombinedMeshVertexCount { get; set; }

			public int CombinedMeshVertexOffset { get; set; }

			public Texture2D DecalTexture { get; set; }

			public Vector4i DecalTextureMaterialLevels { get; set; }

			public Vector4 DecalTextureOffsetAndTiling { get; set; }

			public float EmissiveOverride
			{
				get
				{
					return _emissiveOverride;
				}
				set
				{
					if (_emissiveOverride != value)
					{
						_emissiveOverride = value;
						PartMaterialScript._partGroupPartMaterialData?.PartGroup.OnEmissiveOverrideChanged();
					}
				}
			}

			public bool ExcludeFromDragModel { get; private set; }

			public bool ExcludeFromMeshCombine { get; set; }

			public bool HasCustomMaterial { get; private set; }

			public bool HasDecal => (object)DecalTexture != null;

			public bool HasTransparency { get; set; }

			public bool IsTMProRenderer => MaterialKey != null;

			public string MaterialKey { get; private set; }

			public Mesh Mesh => _getMesh();

			public Material[] OriginalMaterials { get; private set; }

			public PartMaterialScript PartMaterialScript { get; private set; }

			IPartMaterialScript IRendererMaterialMap.PartMaterialScript => PartMaterialScript;

			public bool RenderBeforeDepthMask { get; set; }

			public Renderer Renderer { get; private set; }

			public bool[] TrimLevelsUsed => _trimLevelsUsed;

			public bool UsesAlphaOverride { get; set; }

			public bool UsesEmissiveOverride { get; set; }

			public bool WasMeshCombined { get; set; }

			public RendererMaterialMap(PartMaterialScript partMaterialScript, Renderer renderer, Material[] originalMaterials, bool excludeFromMeshCombine, bool excludeFromDrag, bool usesEmissiveOverride, bool usesAlphaOverride, string materialKey)
			{
				PartMaterialScript = partMaterialScript;
				Renderer = renderer;
				OriginalMaterials = originalMaterials;
				ExcludeFromMeshCombine = excludeFromMeshCombine;
				ExcludeFromDragModel = excludeFromDrag;
				UsesEmissiveOverride = usesEmissiveOverride;
				UsesAlphaOverride = usesAlphaOverride;
				MaterialKey = materialKey;
				AlphaOverride = -1f;
				EmissiveOverride = -1f;
				HasCustomMaterial = false;
				_trimLevelsUsed = new bool[5];
				if (renderer != null)
				{
					if (renderer.TryGetComponent<MeshFilter>(out var meshFilter))
					{
						if (materialKey != null)
						{
							_getMesh = () => meshFilter.sharedMesh;
						}
						else
						{
							_getMesh = () => meshFilter.mesh;
						}
					}
					else if (renderer is SkinnedMeshRenderer)
					{
						SkinnedMeshRenderer skinnedMesh = renderer as SkinnedMeshRenderer;
						skinnedMesh.sharedMesh = UnityEngine.Object.Instantiate(skinnedMesh.sharedMesh);
						_getMesh = () => skinnedMesh.sharedMesh;
					}
					else
					{
						_getMesh = () => (Mesh)null;
					}
					if (Mesh == null)
					{
						Debug.LogErrorFormat(renderer, "Unable to find mesh filter component for mesh renderer '{0}'", renderer.name);
					}
				}
				if (materialKey != null)
				{
					if (renderer.gameObject.TryGetComponent<TextMeshPro>(out var tmpro))
					{
						_setMaterials = delegate(RendererMaterialMap rendererMap, Material[] mats)
						{
							rendererMap.Renderer.materials = mats;
							if (tmpro.fontSharedMaterials.Length == mats.Length)
							{
								tmpro.fontSharedMaterials = mats;
							}
						};
					}
				}
				if (_setMaterials == null)
				{
					_setMaterials = delegate(RendererMaterialMap rendererMap, Material[] mats)
					{
						rendererMap.Renderer.materials = mats;
					};
				}
				_currentMaterials = new Material[originalMaterials.Length];
				_materialSwapBuffer = new Material[originalMaterials.Length];
				_tempRenderOriginalMaterials = new Material[originalMaterials.Length];
				for (int num = 0; num < originalMaterials.Length; num++)
				{
					_currentMaterials[num] = originalMaterials[num];
				}
			}

			public void ApplyDecalTexture()
			{
				PartMaterialScript.OnMaterialsChanged(this);
				UpdateAndApplyMaterialPropertyBlock();
			}

			public void ApplyEmissiveOverride()
			{
				UpdateAndApplyMaterialPropertyBlock();
			}

			public void ApplyMaterials()
			{
				if ((object)DecalTexture != null && !Game.InFlightScene)
				{
					UpdateAndApplyMaterialPropertyBlock();
				}
			}

			public void Destroy()
			{
				Renderer renderer = Renderer;
				if (!renderer.TryGetComponent<MeshCollider>(out var _))
				{
					UnityEngine.Object.Destroy(renderer.GetComponent<MeshFilter>());
				}
				UnityEngine.Object.Destroy(renderer);
				Mesh mesh = Mesh;
				if (mesh != null)
				{
					UnityEngine.Object.Destroy(mesh);
				}
				PartMaterialScript.RemoveRenderer(this);
			}

			public void EndTempRender()
			{
				if (!(Renderer == null) && _tempRenderInProgress)
				{
					_tempRenderInProgress = false;
					Renderer.gameObject.layer = _tempRenderOriginalLayer;
					Renderer.enabled = _tempRenderEnabledState;
					SetMaterials(_tempRenderOriginalMaterials, clearArray: true);
				}
			}

			public void ReplaceOriginalMaterials(Material material, bool setAsCurrent)
			{
				for (int i = 0; i < OriginalMaterials.Length; i++)
				{
					OriginalMaterials[i] = material;
				}
				if (setAsCurrent)
				{
					SetMaterials(OriginalMaterials);
				}
			}

			public void SetRendererMaterial(Material material)
			{
				if (!(Renderer == null))
				{
					for (int i = 0; i < _materialSwapBuffer.Length; i++)
					{
						_materialSwapBuffer[i] = material;
					}
					SetMaterials(_materialSwapBuffer, clearArray: true);
				}
			}

			public void SetRendererMaterial(Material[] materials)
			{
				if (!(Renderer != null))
				{
					return;
				}
				if (OriginalMaterials.Length != materials.Length)
				{
					for (int i = 0; i < _materialSwapBuffer.Length; i++)
					{
						_materialSwapBuffer[i] = materials[Math.Min(i, materials.Length - 1)];
					}
					SetMaterials(_materialSwapBuffer, clearArray: true);
				}
				else
				{
					SetMaterials(materials);
				}
			}

			public void StartTempRender(int layer, Material material)
			{
				if (Renderer == null)
				{
					return;
				}
				GameObject gameObject = Renderer.gameObject;
				if (!_tempRenderInProgress)
				{
					_tempRenderOriginalLayer = gameObject.layer;
					_tempRenderEnabledState = Renderer.enabled;
					Renderer.enabled = true;
					for (int i = 0; i < _currentMaterials.Length; i++)
					{
						_tempRenderOriginalMaterials[i] = _currentMaterials[i];
					}
					_tempRenderInProgress = true;
				}
				gameObject.layer = layer;
				if ((object)material != null)
				{
					for (int j = 0; j < _materialSwapBuffer.Length; j++)
					{
						_materialSwapBuffer[j] = material;
					}
					SetMaterials(_materialSwapBuffer, clearArray: true);
				}
			}

			public void UpdateMaterialPropertyBlock(MaterialPropertyBlock materialPropertyBlock)
			{
				materialPropertyBlock.SetFloat(ShaderPropertyIds.EmissiveOverride, EmissiveOverride);
				materialPropertyBlock.SetFloat(ShaderPropertyIds.AlphaOverride, AlphaOverride);
				if ((object)DecalTexture != null)
				{
					List<int> materialIds = PartMaterialScript._part.Data.MaterialIds;
					Vector4 value = new Vector4(materialIds[DecalTextureMaterialLevels.x], materialIds[DecalTextureMaterialLevels.y], materialIds[DecalTextureMaterialLevels.z], (DecalTextureMaterialLevels.w < 0) ? DecalTextureMaterialLevels.w : materialIds[DecalTextureMaterialLevels.w]);
					materialPropertyBlock.SetFloat(ShaderPropertyIds.UseDecalTexture, 1f);
					materialPropertyBlock.SetTexture(ShaderPropertyIds.DecalTexture, DecalTexture);
					materialPropertyBlock.SetVector(ShaderPropertyIds.DecalTextureST, DecalTextureOffsetAndTiling);
					materialPropertyBlock.SetVector(ShaderPropertyIds.DecalTextureMaterialIds, value);
				}
				else
				{
					materialPropertyBlock.SetFloat(ShaderPropertyIds.UseDecalTexture, 0f);
					materialPropertyBlock.SetTexture(ShaderPropertyIds.DecalTexture, Texture2D.blackTexture);
				}
			}

			private void SetMaterials(Material[] materials, bool clearArray = false)
			{
				_setMaterials(this, materials);
				for (int i = 0; i < _currentMaterials.Length; i++)
				{
					if (i < materials.Length)
					{
						_currentMaterials[i] = materials[i];
					}
				}
				if (clearArray)
				{
					for (int j = 0; j < materials.Length; j++)
					{
						materials[j] = null;
					}
				}
			}

			private void UpdateAndApplyMaterialPropertyBlock()
			{
				if (_materialPropertyBlock == null)
				{
					if (Game.InFlightScene)
					{
						Debug.LogError("Manually applying the material property block to a part renderer is not supported in the flight scene.");
					}
					_materialPropertyBlock = new MaterialPropertyBlock();
				}
				_materialPropertyBlock.Clear();
				UpdateMaterialPropertyBlock(_materialPropertyBlock);
				Renderer.SetPropertyBlock(_materialPropertyBlock);
			}
		}

		private static List<Vector4> _tempUVList = new List<Vector4>();

		private bool _foundAttachPoint;

		private bool _hasBeforeDepthMaskRenderer;

		private bool _isCollidingInDesigner;

		private bool _isDisabled;

		private bool _isDisconnected;

		private bool _isHighlighted;

		private bool _isSelected;

		private Material[] _overrideMaterials;

		private IPartScript _part;

		private PartGroupScript.MaterialPartData _partGroupPartMaterialData;

		private List<IRendererMaterialMap> _rendererMaps;

		private ThemeData _themeData;

		private RunOnceOnNextUpdate _updateMaterial;

		private bool _visible = true;

		public bool FoundAttachPoint
		{
			get
			{
				return _foundAttachPoint;
			}
			set
			{
				if (_foundAttachPoint != value)
				{
					_updateMaterial.Queue();
					_foundAttachPoint = value;
					this.StateChanged?.Invoke(this, new EventArgs());
				}
			}
		}

		public bool IsCollidingInDesigner
		{
			get
			{
				return _isCollidingInDesigner;
			}
			set
			{
				if (_isCollidingInDesigner != value)
				{
					_updateMaterial.Queue();
					_isCollidingInDesigner = value;
					this.StateChanged?.Invoke(this, new EventArgs());
				}
			}
		}

		public bool IsDisabled
		{
			get
			{
				return _isDisabled;
			}
			set
			{
				if (_isDisabled != value)
				{
					_updateMaterial.Queue();
					_isDisabled = value;
					this.StateChanged?.Invoke(this, new EventArgs());
				}
			}
		}

		public bool IsDisconnected
		{
			get
			{
				return _isDisconnected;
			}
			set
			{
				if (_isDisconnected != value)
				{
					_updateMaterial.Queue();
					_isDisconnected = value;
					this.StateChanged?.Invoke(this, new EventArgs());
				}
			}
		}

		public bool IsHighlighted
		{
			get
			{
				return _isHighlighted;
			}
			set
			{
				if (_isHighlighted != value)
				{
					_updateMaterial.Queue();
					_isHighlighted = value;
					if (_partGroupPartMaterialData != null)
					{
						_partGroupPartMaterialData.Outlined = value;
					}
					this.StateChanged?.Invoke(this, new EventArgs());
				}
			}
		}

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				if (_isSelected != value)
				{
					_updateMaterial.Queue();
					_isSelected = value;
					if (_partGroupPartMaterialData != null)
					{
						_partGroupPartMaterialData.Selected = value;
					}
					this.StateChanged?.Invoke(this, new EventArgs());
				}
			}
		}

		public bool IsVisible
		{
			get
			{
				return _visible;
			}
			set
			{
				if (_visible == value)
				{
					return;
				}
				_visible = value;
				foreach (IRendererMaterialMap rendererMap in _rendererMaps)
				{
					if (rendererMap.Renderer != null)
					{
						rendererMap.Renderer.enabled = value;
					}
				}
			}
		}

		public Material[] OverrideMaterials
		{
			get
			{
				return _overrideMaterials;
			}
			set
			{
				if (_overrideMaterials != value)
				{
					_overrideMaterials = value;
					_updateMaterial.Queue();
				}
			}
		}

		public PartGroupScript PartGroup { get; private set; }

		IPartGroupScript IPartMaterialScript.PartGroup => PartGroup;

		public List<IRendererMaterialMap> RendererMaps
		{
			get
			{
				return _rendererMaps;
			}
			private set
			{
				_rendererMaps = value;
			}
		}

		public event EventHandler<RendererEventArgs> RendererAdded;

		public event EventHandler<RendererEventArgs> RendererRemoved;

		public event EventHandler<EventArgs> StateChanged;

		public void AddRenderer(Renderer renderer, bool? excludeFromCombine = null, bool? excludeFromDrag = null, Material[] originalMaterials = null)
		{
			PartMeshScript partMeshScript = renderer.GetComponent<PartMeshScript>();
			if (partMeshScript == null && RenderQueue() == PartMeshRenderQueue.BeforeDepthMask)
			{
				partMeshScript = renderer.gameObject.AddComponent<PartMeshScript>();
				partMeshScript.ExcludeFromMeshCombine = true;
			}
			if (partMeshScript != null)
			{
				PartMeshRenderQueue partMeshRenderQueue = RenderQueue(partMeshScript.IsDepthmask);
				if (partMeshScript.RenderQueue != partMeshRenderQueue)
				{
					partMeshScript.RenderQueue = partMeshRenderQueue;
				}
				if (partMeshScript.ExcludeFromPartMaterials)
				{
					return;
				}
			}
			LabelData modifier = _part.Data.GetModifier<LabelData>();
			bool flag = modifier != null && renderer.GetComponent<TextMeshPro>() != null;
			string materialKey = null;
			bool flag2 = (object)partMeshScript != null && partMeshScript.RenderQueue == PartMeshRenderQueue.BeforeDepthMask && !_part.Data.Config.SupportsTransparency;
			flag2 = (_hasBeforeDepthMaskRenderer |= flag2);
			int num = renderer.sharedMaterials.Length;
			if (originalMaterials == null)
			{
				originalMaterials = new Material[num];
				for (int i = 0; i < num; i++)
				{
					Material[] array = _themeData.Theme.PartMaterialsDefault;
					if (flag)
					{
						materialKey = ((!flag2) ? ("TMPro_" + modifier.FontName) : ("TMPro_BDM_" + modifier.FontName));
						array = _themeData.Theme.GetDefaultPartTMProMaterial(materialKey);
					}
					else if (flag2)
					{
						array = _themeData.Theme.PartMaterialsBdm;
					}
					originalMaterials[i] = array[Math.Min(i, array.Length - 1)];
				}
			}
			bool valueOrDefault = excludeFromCombine == true;
			if (!excludeFromCombine.HasValue)
			{
				valueOrDefault = partMeshScript != null && partMeshScript.ExcludeFromMeshCombine;
				excludeFromCombine = valueOrDefault;
			}
			valueOrDefault = excludeFromDrag == true;
			if (!excludeFromDrag.HasValue)
			{
				valueOrDefault = partMeshScript != null && partMeshScript.ExcludeFromDragModel;
				excludeFromDrag = valueOrDefault;
			}
			bool usesEmissiveOverride = partMeshScript != null && partMeshScript.UsesEmissiveOverride;
			bool usesAlphaOverride = partMeshScript != null && partMeshScript.UsesAlphaOverride;
			RendererMaterialMap rendererMaterialMap = new RendererMaterialMap(this, renderer, originalMaterials, excludeFromCombine.Value, excludeFromDrag.Value, usesEmissiveOverride, usesAlphaOverride, materialKey);
			if (rendererMaterialMap.Mesh == null)
			{
				Debug.LogError("Part material renderer '" + renderer.name + "' will not be created because the renderer's mesh could not be obtained.");
				return;
			}
			rendererMaterialMap.RenderBeforeDepthMask = flag2;
			rendererMaterialMap.SetRendererMaterial(rendererMaterialMap.OriginalMaterials);
			Game.Instance.QualitySettings.Shadows.ConfigurePartRenderer(renderer);
			Game.Instance.QualitySettings.Crafts.ConfigurePartRenderer(renderer);
			if (rendererMaterialMap.IsTMProRenderer)
			{
				renderer.shadowCastingMode = ShadowCastingMode.Off;
			}
			ApplyMaterials(rendererMaterialMap);
			OnMaterialsChanged(rendererMaterialMap);
			UpdateTextureData(rendererMaterialMap);
			_rendererMaps.Add(rendererMaterialMap);
			this.RendererAdded?.Invoke(this, new RendererEventArgs(rendererMaterialMap));
		}

		public List<Renderer> GetEligibleRenderersForCombine()
		{
			List<Renderer> list = new List<Renderer>();
			foreach (IRendererMaterialMap rendererMap in RendererMaps)
			{
				if (!rendererMap.ExcludeFromMeshCombine)
				{
					list.Add(rendererMap.Renderer);
				}
			}
			return list;
		}

		public PartMaterial GetPartMaterial(int level)
		{
			return _themeData.GetMaterial(_part.Data.MaterialIds[level]);
		}

		public float GetPartMaterialIndex(int level)
		{
			return (float)level + _themeData.Theme.GetMaterialIndex(_part.Data.MaterialIds[level]);
		}

		public void Initialize(ICraftScript craftScript, IPartScript partScript)
		{
			_part = partScript;
			_part.Data.Config.RenderQueueChanged += OnRenderQueueChanged;
			_themeData = partScript.Data.ThemeData;
			_rendererMaps = new List<IRendererMaterialMap>();
			UpdateRenderers();
		}

		public void OnMaterialsChanged()
		{
			foreach (RendererMaterialMap item in RendererMaps.Cast<RendererMaterialMap>())
			{
				OnMaterialsChanged(item);
			}
		}

		public void OnMovedToNewPartScript(ICraftScript craftScript)
		{
		}

		public void OnPartGroupInitialized(PartGroupScript.MaterialPartData partMaterialData)
		{
			_partGroupPartMaterialData = partMaterialData;
			PartGroup = partMaterialData.PartGroup;
		}

		public void RemoveRenderer(Renderer renderer)
		{
			for (int i = 0; i < _rendererMaps.Count; i++)
			{
				IRendererMaterialMap rendererMaterialMap = _rendererMaps[i];
				if (rendererMaterialMap.Renderer == renderer)
				{
					_rendererMaps.RemoveAt(i);
					this.RendererRemoved?.Invoke(this, new RendererEventArgs(rendererMaterialMap));
					break;
				}
			}
		}

		public void RemoveRenderer(IRendererMaterialMap renderer)
		{
			_rendererMaps.Remove(renderer);
			this.RendererRemoved?.Invoke(this, new RendererEventArgs(renderer));
		}

		public void RestoreOriginalMaterials()
		{
			foreach (IRendererMaterialMap rendererMap in _rendererMaps)
			{
				rendererMap.SetRendererMaterial(rendererMap.OriginalMaterials);
			}
		}

		public void SetMaterial(int material, int level)
		{
			_part.Data.MaterialIds[level] = material;
			foreach (IRendererMaterialMap rendererMap in _rendererMaps)
			{
				ApplyMaterials(level, rendererMap);
			}
		}

		public void UpdateRenderers()
		{
			IRendererMaterialMap[] array = _rendererMaps.ToArray();
			_rendererMaps.Clear();
			IRendererMaterialMap[] array2 = array;
			foreach (IRendererMaterialMap renderer in array2)
			{
				this.RendererRemoved?.Invoke(this, new RendererEventArgs(renderer));
			}
			List<Renderer> list = new List<Renderer>();
			list.AddRange(GetComponentsInChildren<MeshRenderer>());
			list.AddRange(GetComponentsInChildren<SkinnedMeshRenderer>());
			_hasBeforeDepthMaskRenderer = RenderQueue() == PartMeshRenderQueue.BeforeDepthMask;
			foreach (Renderer item in list)
			{
				if (item.gameObject.layer != 10)
				{
					AddRenderer(item);
				}
			}
		}

		public void UpdateTextureData()
		{
			foreach (IRendererMaterialMap rendererMap in RendererMaps)
			{
				UpdateTextureData(rendererMap);
			}
		}

		protected virtual void OnDestroy()
		{
			IPartHighlighter partHighlighter = _part.CraftScript?.PartHighlighter;
			if (partHighlighter != null)
			{
				partHighlighter.RemovePartHighlight(_part);
				partHighlighter.RemovePartOutline(_part);
			}
		}

		private void ApplyMaterials(IRendererMaterialMap rendererMap)
		{
			if (rendererMap.IsTMProRenderer)
			{
				_part.GetModifier<LabelScript>()?.OnApplyMaterials();
				return;
			}
			Mesh mesh = rendererMap.Mesh;
			List<int> materialIds = _part.Data.MaterialIds;
			int count = materialIds.Count;
			float[] array = new float[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = _themeData.Theme.GetMaterialIndex(materialIds[i]);
			}
			bool[] trimLevelsUsed = rendererMap.TrimLevelsUsed;
			for (int j = 0; j < trimLevelsUsed.Length; j++)
			{
				trimLevelsUsed[j] = false;
			}
			mesh.GetUVs(0, _tempUVList);
			int count2 = _tempUVList.Count;
			for (int k = 0; k < count2; k++)
			{
				Vector4 value = _tempUVList[k];
				int num = (int)(value.w % 10f) % count;
				value.w = (float)(int)value.w + array[num];
				trimLevelsUsed[num] = true;
				_tempUVList[k] = value;
			}
			mesh.SetUVs(0, _tempUVList);
			rendererMap.ApplyMaterials();
		}

		private void ApplyMaterials(int level, IRendererMaterialMap rendererMap)
		{
			if (rendererMap.IsTMProRenderer)
			{
				_part.GetModifier<LabelScript>()?.OnApplyMaterials();
				return;
			}
			Mesh mesh = rendererMap.Mesh;
			int count = _part.Data.MaterialIds.Count;
			level %= count;
			int materialId = _part.Data.MaterialIds[level];
			float materialIndex = _themeData.Theme.GetMaterialIndex(materialId);
			bool[] trimLevelsUsed = rendererMap.TrimLevelsUsed;
			trimLevelsUsed[level] = false;
			mesh.GetUVs(0, _tempUVList);
			int count2 = _tempUVList.Count;
			for (int i = 0; i < count2; i++)
			{
				Vector4 value = _tempUVList[i];
				if ((int)(value.w % 10f) == level)
				{
					value.w = (float)(int)value.w + materialIndex;
					trimLevelsUsed[level] = true;
					_tempUVList[i] = value;
				}
			}
			mesh.SetUVs(0, _tempUVList);
			rendererMap.ApplyMaterials();
		}

		private void Awake()
		{
			_updateMaterial = new RunOnceOnNextUpdate(this, UpdateMaterial);
		}

		private Vector4 BuildTextureUVData(int subpartIndex)
		{
			IPartStyleManager partStyleManager = Game.Instance.PartStyleManager;
			PartStyleData partStyleData = _part.Data.Styles[subpartIndex];
			IPartTextureStyle partTextureStyle = partStyleData.TextureStyle;
			if (partTextureStyle == null)
			{
				partTextureStyle = partStyleManager.DefaultTextureStyle;
			}
			int detailTextureIndex = partStyleManager.GetDetailTextureIndex(partTextureStyle.DetailTextureId);
			int normalMapTextureIndex = partStyleManager.GetNormalMapTextureIndex(partTextureStyle.NormalMapTextureId);
			return new Vector4(partStyleData.TextureTiling.x, partStyleData.TextureTiling.y, Mathf.Clamp(partStyleData.TextureOffset.x % 1f, 0f, 0.999f) + (float)detailTextureIndex, Mathf.Clamp(partStyleData.TextureOffset.y % 1f, 0f, 0.999f) + (float)normalMapTextureIndex);
		}

		private bool HasAttachedMaterials()
		{
			return !HasCustomMaterials();
		}

		private bool HasCollisionMaterials()
		{
			return !HasCustomMaterials();
		}

		private bool HasCustomMaterials()
		{
			foreach (IRendererMaterialMap rendererMap in _rendererMaps)
			{
				if (rendererMap.HasCustomMaterial)
				{
					return true;
				}
			}
			return false;
		}

		private bool HasHighlightedMaterials()
		{
			if (Game.InDesignerScene)
			{
				return !HasCustomMaterials();
			}
			return false;
		}

		private bool HasSelectedMaterials()
		{
			if (Device.IsMobileBuild && Game.InDesignerScene && !HasCustomMaterials())
			{
				return _part.GetModifier<LabelScript>() == null;
			}
			return false;
		}

		private void OnMaterialsChanged(RendererMaterialMap rendererMap)
		{
			rendererMap.HasTransparency = false;
			if (rendererMap.RenderBeforeDepthMask || rendererMap.HasCustomMaterial || rendererMap.IsTMProRenderer || !_part.Data.Config.SupportsTransparency)
			{
				return;
			}
			bool[] trimLevelsUsed = rendererMap.TrimLevelsUsed;
			bool hasDecal = rendererMap.HasDecal;
			Vector4i decalTextureMaterialLevels = rendererMap.DecalTextureMaterialLevels;
			Material material = _themeData.Theme.PartMaterialsDefault[0];
			List<int> materialIds = _part.Data.MaterialIds;
			for (int i = 0; i < materialIds.Count; i++)
			{
				if (!trimLevelsUsed[i])
				{
					if (!hasDecal)
					{
						continue;
					}
					if (decalTextureMaterialLevels.w >= 0)
					{
						if (decalTextureMaterialLevels.w != i)
						{
							continue;
						}
					}
					else if (decalTextureMaterialLevels.x != i && decalTextureMaterialLevels.y != i && decalTextureMaterialLevels.z != i)
					{
						continue;
					}
				}
				int materialId = materialIds[i];
				if (_themeData.GetMaterial(materialId).TransparencyStrength != 0f || rendererMap.UsesAlphaOverride)
				{
					material = _themeData.Theme.PartMaterialsTransparent[0];
					rendererMap.HasTransparency = true;
					break;
				}
			}
			rendererMap.ReplaceOriginalMaterials(material, setAsCurrent: true);
		}

		private void OnRenderQueueChanged(object sender, EventArgs e)
		{
			UpdateRenderers();
		}

		private PartMeshRenderQueue RenderQueue(bool isMask = false)
		{
			if (!(_part.Data.Config.SupportsTransparency && isMask))
			{
				return _part.Data.Config.RenderQueue;
			}
			return PartMeshRenderQueue.Transparent;
		}

		private void SetRendererMaterials(Material[] partMaterials, bool renderBeforeDepthMask)
		{
			_themeData.Theme.UpdateMaterialRenderQueues(partMaterials, renderBeforeDepthMask ? PartMeshRenderQueue.BeforeDepthMask : PartMeshRenderQueue.Default);
			foreach (IRendererMaterialMap rendererMap in _rendererMaps)
			{
				rendererMap.SetRendererMaterial(partMaterials);
			}
		}

		private void UpdateMaterial()
		{
			if (OverrideMaterials != null)
			{
				SetRendererMaterials(OverrideMaterials, _hasBeforeDepthMaskRenderer);
			}
			else if (IsCollidingInDesigner && HasCollisionMaterials())
			{
				SetRendererMaterials(_themeData.Theme.PartMaterialsCollision, _hasBeforeDepthMaskRenderer);
			}
			else if (FoundAttachPoint && HasAttachedMaterials())
			{
				SetRendererMaterials(_themeData.Theme.PartMaterialsAttached, _hasBeforeDepthMaskRenderer);
			}
			else if (IsSelected && HasSelectedMaterials())
			{
				SetRendererMaterials(_themeData.Theme.PartMaterialsSelected, _hasBeforeDepthMaskRenderer);
			}
			else if (IsHighlighted && HasHighlightedMaterials())
			{
				SetRendererMaterials(_themeData.Theme.PartMaterialsHighlighted, _hasBeforeDepthMaskRenderer);
			}
			else if (IsDisabled)
			{
				SetRendererMaterials(_themeData.Theme.PartMaterialsHidden, renderBeforeDepthMask: false);
			}
			else if (IsDisconnected)
			{
				SetRendererMaterials(_themeData.Theme.PartMaterialsDisconnected, _hasBeforeDepthMaskRenderer);
			}
			else
			{
				RestoreOriginalMaterials();
			}
			IPartHighlighter partHighlighter = _part.CraftScript.PartHighlighter;
			partHighlighter.RemovePartHighlight(_part);
			partHighlighter.RemovePartOutline(_part);
			IPartStateColors partStateColors = _themeData.Theme?.PartStateColors;
			if (partStateColors == null)
			{
				_themeData = _part.Data.ThemeData;
				partStateColors = _themeData.Theme?.PartStateColors;
			}
			if (partStateColors == null)
			{
				return;
			}
			if (IsCollidingInDesigner)
			{
				if (!HasCollisionMaterials())
				{
					partHighlighter.HighlightColor = partStateColors.Colliding;
					partHighlighter.AddPartHighlight(_part);
				}
			}
			else if (FoundAttachPoint)
			{
				if (!HasAttachedMaterials())
				{
					partHighlighter.HighlightColor = partStateColors.Attached;
					partHighlighter.AddPartHighlight(_part);
				}
			}
			else if (IsSelected)
			{
				if (Game.InDesignerScene && !HasSelectedMaterials())
				{
					partHighlighter.HighlightColor = partStateColors.Selected;
					partHighlighter.AddPartHighlight(_part);
				}
			}
			else if (IsHighlighted)
			{
				partHighlighter.OutlineColor = partStateColors.Highlighted;
				partHighlighter.AddPartOutline(_part);
			}
		}

		private void UpdateTextureData(IRendererMaterialMap rendererMap)
		{
			if (!rendererMap.IsTMProRenderer)
			{
				Mesh mesh = rendererMap.Mesh;
				mesh.GetUVs(0, _tempUVList);
				int count = _part.Data.Styles.Count;
				Vector4[] array = new Vector4[count];
				for (int i = 0; i < count; i++)
				{
					array[i] = BuildTextureUVData(i);
				}
				int count2 = _tempUVList.Count;
				for (int j = 0; j < count2; j++)
				{
					int num = (int)(_tempUVList[j].w * 0.1f) % count;
					_tempUVList[j] = array[num];
				}
				mesh.SetUVs(1, _tempUVList);
			}
		}
	}
}
