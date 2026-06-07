using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.Paint;
using Assets.Scripts.Craft.Parts.Modifiers;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Coroutines;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts
{
	public class PartMaterialScript : MonoBehaviour
	{
		public class MaterialUpdateEventArgs : EventArgs
		{
			public Color? Color { get; set; }

			public bool EnableOutlineEffect { get; set; }

			public Material NormalMaterial { get; set; }

			public bool SetMaterialsNormally { get; set; }

			public MaterialUpdateEventArgs(Color? color, Material material)
			{
				Color = color;
				NormalMaterial = material;
				SetMaterialsNormally = false;
				EnableOutlineEffect = false;
			}
		}

		public class PaintedEventArgs : EventArgs
		{
			public bool UVsChanged { get; set; }

			public PaintedEventArgs(bool uvsChanged = false)
			{
				UVsChanged = uvsChanged;
			}
		}

		[Serializable]
		public class PartHighlightSettings
		{
			[field: SerializeField]
			public Color? Color { get; set; }

			[field: SerializeField]
			public Vector3 Scale { get; set; }

			public bool UseZTest { get; set; }

			public PartHighlightSettings(Color? color, Vector3 scale, bool useZTest)
			{
				Color = color;
				Scale = scale;
				UseZTest = useZTest;
			}

			public PartHighlightSettings Clone()
			{
				return new PartHighlightSettings(Color, Scale, UseZTest);
			}
		}

		public class PartMaterialEventArgs : EventArgs
		{
			public PartMaterialScript PartMaterial { get; }

			public PartMaterialEventArgs(PartMaterialScript partMaterial)
			{
				PartMaterial = partMaterial;
			}
		}

		public class RendererMaterialMap
		{
			private Action<RendererMaterialMap> _destroyMesh;

			private float? _emissiveOverride;

			private Func<RendererMaterialMap, Mesh> _getMesh;

			private MaterialPropertyBlock _materialPropertyBlock;

			private MeshFilter _meshFilter;

			public bool BakedMeshData { get; set; }

			public bool DontApplyMaterials { get; set; }

			public bool DontSetMaterials { get; set; }

			public PartDragType DragType { get; set; }

			public float? EmissiveOverride
			{
				get
				{
					return _emissiveOverride;
				}
				set
				{
					_emissiveOverride = value;
					UpdateMaterialPropertyBlock();
				}
			}

			public bool ExcludeFromMeshCombine { get; set; }

			public Material[] HighlightMaterials { get; set; }

			public bool IsPrimaryMaterial
			{
				get
				{
					if (SubmeshToLevelMap == null)
					{
						return true;
					}
					int[] submeshToLevelMap = SubmeshToLevelMap;
					for (int i = 0; i < submeshToLevelMap.Length; i++)
					{
						if (submeshToLevelMap[i] == 0)
						{
							return true;
						}
					}
					return false;
				}
			}

			public PartRendererMaterialType[] MaterialTypes { get; set; }

			public Mesh Mesh => _getMesh(this);

			public bool MeshIsUnique { get; set; }

			public Material[] OriginalMaterials { get; set; }

			public MeshRenderer Renderer { get; set; }

			public Material[] SelectedMaterials { get; set; }

			public int[] SubmeshToLevelMap { get; set; }

			public RendererMaterialMap(MeshRenderer renderer, Material[] originalMaterials, PartRendererMaterialType[] materialTypes, int[] levels, bool excludeFromCombine, PartDragType dragType, bool dontApplyMaterials, Material[] highlightMaterials, Material[] selectedMaterials)
			{
				Renderer = renderer;
				MaterialTypes = materialTypes;
				OriginalMaterials = originalMaterials;
				HighlightMaterials = highlightMaterials;
				SelectedMaterials = selectedMaterials;
				SubmeshToLevelMap = levels;
				ExcludeFromMeshCombine = excludeFromCombine;
				DragType = dragType;
				DontApplyMaterials = dontApplyMaterials;
				SetRendererMaterial(OriginalMaterials);
				if (renderer.TryGetComponent<MeshFilter>(out var component))
				{
					_meshFilter = component;
					_getMesh = (RendererMaterialMap x) => (!x.MeshIsUnique) ? x._meshFilter.mesh : x._meshFilter.sharedMesh;
					_destroyMesh = delegate(RendererMaterialMap x)
					{
						if (x.MeshIsUnique)
						{
							Mesh sharedMesh = x._meshFilter.sharedMesh;
							if (sharedMesh != null)
							{
								UnityEngine.Object.Destroy(sharedMesh);
							}
							x._meshFilter.sharedMesh = null;
						}
						else
						{
							Mesh mesh = x._meshFilter.mesh;
							if (mesh != null)
							{
								UnityEngine.Object.Destroy(mesh);
							}
							x._meshFilter.mesh = null;
						}
					};
				}
				else
				{
					_getMesh = (RendererMaterialMap x) => (Mesh)null;
					_destroyMesh = delegate
					{
					};
				}
			}

			public void OnDestroy()
			{
				_destroyMesh(this);
			}

			public void OnRemoved(PartMaterialScript partMaterialScript)
			{
				Material[] originalMaterials = OriginalMaterials;
				PartRendererMaterialType[] materialTypes = MaterialTypes;
				if (originalMaterials == null || materialTypes == null)
				{
					return;
				}
				for (int i = 0; i < originalMaterials.Length && i < materialTypes.Length; i++)
				{
					if (materialTypes[i] == PartRendererMaterialType.DefaultInstanced)
					{
						partMaterialScript._theme.ReleaseDefaultPartMaterialInstance(originalMaterials[i]);
					}
				}
			}

			public void SetRendererMaterial(Material material)
			{
				if (Renderer != null && !DontApplyMaterials)
				{
					Material[] array = new Material[OriginalMaterials.Length];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = material;
					}
					SetRendererMaterial(array);
				}
			}

			public void SetRendererMaterial(Material[] materials)
			{
				if (Renderer != null && !DontApplyMaterials)
				{
					Renderer.materials = materials;
				}
			}

			public void UpdateMaterialPropertyBlock()
			{
				bool flag = false;
				Func<MaterialPropertyBlock> func = () => _materialPropertyBlock ?? (_materialPropertyBlock = new MaterialPropertyBlock());
				if (_emissiveOverride.HasValue)
				{
					flag = true;
					MaterialPropertyBlock materialPropertyBlock = func();
					materialPropertyBlock.SetFloat("_EmissiveOverride", _emissiveOverride.Value);
					materialPropertyBlock.SetFloat("_EmissiveOverrideNight", _emissiveOverride.Value);
				}
				Renderer.SetPropertyBlock(flag ? _materialPropertyBlock : null);
			}

			public void UpdateRenderQueue(bool renderBeforeDepthMask)
			{
				if (!DontApplyMaterials)
				{
					int renderQueue = (renderBeforeDepthMask ? 1990 : (-1));
					for (int i = 0; i < Renderer.materials.Length; i++)
					{
						Renderer.materials[i].renderQueue = renderQueue;
					}
				}
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker BakePositionsAndNormals = new ProfilerMarker("PartMaterialScript.BakeMeshPositionsAndNormals");

			public static readonly ProfilerMarker SetMaterialNoEvents_AssignUVs = new ProfilerMarker("PartMaterialScript.SetMaterialNoEvents Assign UVs and Cleanup");

			public static readonly ProfilerMarker SetMaterialNoEvents_UpdateUVs = new ProfilerMarker("PartMaterialScript.SetMaterialNoEvents UpdateUVs");
		}

		private bool _bakedMeshNormals;

		private bool _bakedMeshPositions;

		private Matrix4x4 _bakeMeshDataPartToPaintOriginMatrix;

		private Material _collisionMaterial;

		private Material _customMaterial;

		private Material _disconnectedMaterial;

		private bool _foundAttachPoint;

		private Material _foundAttachPointMaterial;

		private bool _hasBeforeDepthMaskRenderer;

		private bool _hasColoredMaterialInstances;

		private Material _hiddenMaterial;

		private PartHighlightEffect _highlightEffect;

		private bool _isCollidingInDesigner;

		private bool _isDisconnected;

		private bool _isHidden;

		private bool _isHighlighted;

		private bool _isOutlined;

		private bool _isSelected;

		private bool _isSelectedSymmetric;

		private MaterialPropertyBlock _outlineMaterialPropertyBlock;

		private Material _overrideMaterial;

		private PartScript _part;

		private Material _partDamageMaterial;

		private List<Renderer> _partOutliningRenderers;

		private List<RendererMaterialMap> _rendererMaps;

		private List<Renderer> _renderersNotInMap = new List<Renderer>();

		private bool _showPartDamage;

		private ThemeScript _theme;

		private RunOnceOnNextUpdate _updateMaterial;

		private bool _visible = true;

		public Material CustomMaterial
		{
			get
			{
				return _customMaterial;
			}
			set
			{
				if (_customMaterial != value)
				{
					_customMaterial = value;
					_updateMaterial.Queue();
				}
			}
		}

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
				}
			}
		}

		public bool IsHidden
		{
			get
			{
				return _isHidden;
			}
			set
			{
				if (_isHidden != value)
				{
					_updateMaterial.Queue();
					_isHidden = value;
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
					this.HighlightedChanged?.Invoke(this, new PartMaterialEventArgs(this));
				}
			}
		}

		public bool IsOutlined
		{
			get
			{
				return _isOutlined;
			}
			set
			{
				if (_isOutlined != value)
				{
					_updateMaterial.Queue();
					_isOutlined = value;
				}
			}
		}

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			private set
			{
				if (_isSelected != value)
				{
					_updateMaterial.Queue();
					_isSelected = value;
					this.SelectedChanged?.Invoke(this, new PartMaterialEventArgs(this));
				}
			}
		}

		public bool IsSelectedSymmetric
		{
			get
			{
				return _isSelectedSymmetric;
			}
			private set
			{
				if (_isSelectedSymmetric != value)
				{
					_updateMaterial.Queue();
					_isSelectedSymmetric = value;
				}
			}
		}

		public int MaterialIdPrimary { get; set; }

		public int MaterialIdSecondary { get; set; }

		public Vector3 OutlineScale { get; set; } = new Vector3(1.1f, 1.1f, 1.1f);

		public Material OverrideMaterial
		{
			get
			{
				return _overrideMaterial;
			}
			set
			{
				if (_overrideMaterial != value)
				{
					_overrideMaterial = value;
					_updateMaterial.Queue();
				}
			}
		}

		public Material PartMaterial { get; set; }

		public Material PartMaterialBdm { get; set; }

		public List<RendererMaterialMap> RendererMaps
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

		public bool ShowPartDamage
		{
			get
			{
				return _showPartDamage;
			}
			set
			{
				if (_showPartDamage != value)
				{
					_updateMaterial.Queue();
					_showPartDamage = value;
				}
			}
		}

		public PartHighlightSettings TutorialHighlight { get; set; }

		public bool Visible
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
				foreach (RendererMaterialMap rendererMap in _rendererMaps)
				{
					if (rendererMap.Renderer != null)
					{
						rendererMap.Renderer.enabled = value;
					}
				}
				foreach (Renderer item in _renderersNotInMap)
				{
					item.enabled = value;
				}
			}
		}

		private PartMeshRenderQueue RenderQueue => _part.Part.RenderQueue;

		public event EventHandler<MaterialUpdateEventArgs> CustomMaterialUpdateCallback;

		public event EventHandler<PartMaterialEventArgs> HighlightedChanged;

		public event EventHandler<PaintedEventArgs> OnBeforePaintInDesigner;

		public event EventHandler<PaintedEventArgs> OnPaintedInDesigner;

		public event EventHandler<PartMaterialEventArgs> SelectedChanged;

		public void AddNonPartMaterialDataScriptRenderer(Renderer renderer)
		{
			_renderersNotInMap.Add(renderer);
		}

		public RendererMaterialMap AddRenderer(MeshRenderer renderer, Material[] originalMaterials, PartRendererMaterialType[] materialTypes, int[] levels, bool excludeFromCombine, bool excludeFromDrag, bool dontApplyMaterials = false)
		{
			return AddRenderer(renderer, originalMaterials, materialTypes, null, null, null, levels, excludeFromCombine, excludeFromDrag, dontApplyMaterials);
		}

		public RendererMaterialMap AddRenderer(MeshRenderer renderer, Material[] originalMaterials, PartRendererMaterialType[] materialTypes, Texture2D[] normalMaps, Texture2D[] occlusionMaps, Texture2D[] parallaxMaps, int[] levels, bool excludeFromCombine, bool excludeFromDrag, bool dontApplyMaterials = false)
		{
			bool flag = false;
			if (RenderQueue == PartMeshRenderQueue.BeforeDepthMask)
			{
				_hasBeforeDepthMaskRenderer = true;
				flag = true;
				excludeFromCombine = true;
			}
			if (originalMaterials == null)
			{
				originalMaterials = new Material[renderer.sharedMaterials.Length];
				for (int i = 0; i < originalMaterials.Length; i++)
				{
					if (flag)
					{
						originalMaterials[i] = PartMaterialBdm;
					}
					else
					{
						originalMaterials[i] = PartMaterial;
					}
				}
			}
			if (materialTypes == null)
			{
				materialTypes = new PartRendererMaterialType[renderer.sharedMaterials.Length];
				for (int j = 0; j < materialTypes.Length; j++)
				{
					materialTypes[j] = PartRendererMaterialType.DefaultShared;
				}
			}
			for (int k = 0; k < originalMaterials.Length && k < materialTypes.Length; k++)
			{
				if (materialTypes[k] == PartRendererMaterialType.DefaultInstanced)
				{
					originalMaterials[k] = _theme.RequestDefaultPartMaterialInstance();
					excludeFromCombine = true;
					if (((normalMaps != null) ? normalMaps.Length : 0) > k && normalMaps[k] != null)
					{
						originalMaterials[k].EnableKeyword("_NORMALMAP");
						originalMaterials[k].SetTexture("_BumpMap", normalMaps[k]);
					}
					if (((occlusionMaps != null) ? occlusionMaps.Length : 0) > k && occlusionMaps[k] != null)
					{
						originalMaterials[k].EnableKeyword("_OCCLUSIONMAP");
						originalMaterials[k].SetTexture("_OcclusionMap", occlusionMaps[k]);
					}
					if (((parallaxMaps != null) ? parallaxMaps.Length : 0) > k && parallaxMaps[k] != null)
					{
						originalMaterials[k].EnableKeyword("_PARALLAXMAP");
						originalMaterials[k].SetTexture("_ParallaxMap", parallaxMaps[k]);
					}
				}
			}
			if (!_hasColoredMaterialInstances)
			{
				PartRendererMaterialType[] array = materialTypes;
				for (int l = 0; l < array.Length; l++)
				{
					if (array[l] == PartRendererMaterialType.CustomWithThemeColors)
					{
						_hasColoredMaterialInstances = true;
					}
				}
			}
			Material[] array2 = null;
			if (_part.LoadContext == CraftLoadContext.Designer && originalMaterials != null)
			{
				array2 = new Material[originalMaterials.Length];
				for (int m = 0; m < originalMaterials.Length; m++)
				{
					array2[m] = _theme.InitializeHighlightMaterial(originalMaterials[m]);
				}
			}
			Material[] array3 = null;
			if (_part.LoadContext == CraftLoadContext.Designer && originalMaterials != null)
			{
				array3 = new Material[originalMaterials.Length];
				for (int n = 0; n < originalMaterials.Length; n++)
				{
					array3[n] = _theme.InitializeHighlightSelectedMaterial(originalMaterials[n]);
				}
			}
			PartDragType dragType = (excludeFromDrag ? PartDragType.None : _part.Part.DragType);
			RendererMaterialMap rendererMaterialMap = new RendererMaterialMap(renderer, originalMaterials, materialTypes, levels, excludeFromCombine, dragType, dontApplyMaterials, array2, array3);
			renderer.gameObject.layer = 21;
			renderer.probeAnchor = _part.Aircraft.ReflectionProbe?.transform;
			renderer.enabled = Visible;
			_rendererMaps.Add(rendererMaterialMap);
			_highlightEffect.Refresh();
			_updateMaterial?.Queue();
			return rendererMaterialMap;
		}

		public RendererMaterialMap AddRenderer(MeshRenderer renderer, bool excludeFromCombine = false, bool excludedFromDrag = false)
		{
			PartRendererScript component;
			bool flag = renderer.TryGetComponent<PartRendererScript>(out component);
			if (flag && component.ExcludeFromPartMaterials)
			{
				return null;
			}
			Material[] array = new Material[renderer.sharedMaterials.Length];
			for (int i = 0; i < array.Length; i++)
			{
				if (RenderQueue == PartMeshRenderQueue.BeforeDepthMask)
				{
					array[i] = PartMaterialBdm;
				}
				else
				{
					array[i] = PartMaterial;
				}
			}
			PartRendererMaterialType[] array2 = new PartRendererMaterialType[renderer.sharedMaterials.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = PartRendererMaterialType.DefaultShared;
			}
			bool dontApplyMaterials = false;
			int[] array3 = null;
			Texture2D[] array4 = null;
			Texture2D[] array5 = null;
			Texture2D[] array6 = null;
			if (flag)
			{
				excludeFromCombine = component.ExcludeFromMeshCombine;
				excludedFromDrag = component.ExcludeFromDragModel;
				dontApplyMaterials = component.ExcludeFromPartMaterialsAssignment;
				array3 = new int[component.Materials.Count];
				for (int k = 0; k < array3.Length; k++)
				{
					PartRendererScript.PartRendererMaterialConfiguration partRendererMaterialConfiguration = component.Materials[k];
					if (partRendererMaterialConfiguration.NormalMap != null)
					{
						if (array4 == null)
						{
							array4 = new Texture2D[array3.Length];
							for (int l = 0; l < array4.Length; l++)
							{
								array4[l] = null;
							}
						}
						array4[partRendererMaterialConfiguration.SubmeshIndex] = partRendererMaterialConfiguration.NormalMap;
					}
					if (partRendererMaterialConfiguration.OcclusionMap != null)
					{
						if (array5 == null)
						{
							array5 = new Texture2D[array3.Length];
							for (int m = 0; m < array5.Length; m++)
							{
								array5[m] = null;
							}
						}
						array5[partRendererMaterialConfiguration.SubmeshIndex] = partRendererMaterialConfiguration.OcclusionMap;
					}
					if (partRendererMaterialConfiguration.ParallaxMap != null)
					{
						if (array6 == null)
						{
							array6 = new Texture2D[array3.Length];
							for (int n = 0; n < array6.Length; n++)
							{
								array6[n] = null;
							}
						}
						array6[partRendererMaterialConfiguration.SubmeshIndex] = partRendererMaterialConfiguration.ParallaxMap;
					}
					array3[partRendererMaterialConfiguration.SubmeshIndex] = (int)partRendererMaterialConfiguration.MaterialLevel;
					array2[partRendererMaterialConfiguration.SubmeshIndex] = partRendererMaterialConfiguration.MaterialType;
					if (partRendererMaterialConfiguration.MaterialType == PartRendererMaterialType.CustomWithOriginalColors || partRendererMaterialConfiguration.MaterialType == PartRendererMaterialType.CustomWithThemeColors)
					{
						array[partRendererMaterialConfiguration.SubmeshIndex] = renderer.sharedMaterials[partRendererMaterialConfiguration.SubmeshIndex];
					}
				}
			}
			return AddRenderer(renderer, array, array2, array4, array5, array6, array3, excludeFromCombine, excludedFromDrag, dontApplyMaterials);
		}

		public void ApplyAllMaterials()
		{
			for (int i = 0; i < _part.Part.MaterialIds.Count; i++)
			{
				SetMaterialNoEvents(_part.Part.MaterialIds[i], i, initializingPartMaterial: false);
			}
		}

		public void ApplyReservedPaintStyle(PaintStyle style, Mesh mesh)
		{
			PartMaterial reservedMaterial = _theme.Theme.GetReservedMaterial(style);
			int materialIndex = _theme.Theme.GetMaterialIndex(reservedMaterial.Id);
			Vector3 value = new Vector3(materialIndex, DecalLayers.DefaultRenderingLayerFloat, _part.Part.Id);
			NativeArray<Vector3> uvs = new NativeArray<Vector3>(mesh.vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < uvs.Length; i++)
			{
				uvs[i] = value;
			}
			mesh.SetUVs(1, uvs);
		}

		public void BakeMeshData()
		{
			if (!_bakedMeshPositions && !_bakedMeshNormals)
			{
				return;
			}
			foreach (RendererMaterialMap rendererMap in _rendererMaps)
			{
				if (!rendererMap.BakedMeshData)
				{
					BakeMeshPositionsAndNormals(rendererMap);
				}
			}
		}

		public void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
		}

		public void ClearRenderers(bool destroy = false)
		{
			foreach (RendererMaterialMap rendererMap in _rendererMaps)
			{
				rendererMap.OnRemoved(this);
				if (destroy)
				{
					rendererMap.OnDestroy();
				}
			}
			_rendererMaps.Clear();
		}

		public void DrawOutlineForRenderer(Renderer renderer, bool outline, PartHighlightSettings partHighlight)
		{
			if (!renderer.TryGetComponent<MeshFilter>(out var component))
			{
				return;
			}
			Mesh sharedMesh = component.sharedMesh;
			Matrix4x4 localToWorldMatrix = component.transform.localToWorldMatrix;
			Material material = _theme.MaterialOutline;
			MaterialPropertyBlock materialPropertyBlock = _outlineMaterialPropertyBlock ?? (_outlineMaterialPropertyBlock = new MaterialPropertyBlock());
			materialPropertyBlock.Clear();
			if (outline)
			{
				materialPropertyBlock.SetVector("_Scale", OutlineScale);
			}
			else if (partHighlight != null)
			{
				material = (partHighlight.UseZTest ? _theme.MaterialTutorialHighlight : _theme.MaterialTutorialHighlightZTestAlways);
				materialPropertyBlock.SetVector("_Scale", partHighlight.Scale);
				if (partHighlight.Color.HasValue)
				{
					materialPropertyBlock.SetVector("_BaseColor", partHighlight.Color.Value);
				}
			}
			for (int i = 0; i < sharedMesh.subMeshCount; i++)
			{
				Graphics.DrawMesh(sharedMesh, localToWorldMatrix, material, 16, null, i, materialPropertyBlock);
			}
		}

		public void EndDesignerPaintEvents(bool uvChange = false)
		{
			this.OnPaintedInDesigner?.Invoke(this, new PaintedEventArgs(uvChange));
		}

		public List<Renderer> GetEligibleRenderersForCombine()
		{
			List<Renderer> list = new List<Renderer>();
			foreach (RendererMaterialMap rendererMap in RendererMaps)
			{
				if (!rendererMap.ExcludeFromMeshCombine)
				{
					list.Add(rendererMap.Renderer);
				}
			}
			return list;
		}

		public void Initialize(AircraftScript aircraft)
		{
			_hiddenMaterial = Game.Instance.ResourceLoader.LoadSharedMaterial("Designer/Materials/DesignerPartHidden");
			_collisionMaterial = Game.Instance.ResourceLoader.LoadSharedMaterial("Designer/Materials/DesignerPartCollision");
			_foundAttachPointMaterial = Game.Instance.ResourceLoader.LoadSharedMaterial("Designer/Materials/DesignerPartFoundAttachPoint");
			_disconnectedMaterial = Game.Instance.ResourceLoader.LoadSharedMaterial("Designer/Materials/DesignerPartDisconnected");
			_part = GetComponent<PartScript>();
			_theme = aircraft.Theme;
			_highlightEffect = new PartHighlightEffect(_part);
			if (_part.Part.MaterialIds.Count > 0)
			{
				MaterialIdPrimary = _theme.Theme.GetMaterialIndex(_part.Part.MaterialIds[0]);
			}
			if (_part.Part.MaterialIds.Count > 1)
			{
				MaterialIdSecondary = _theme.Theme.GetMaterialIndex(_part.Part.MaterialIds[1]);
			}
			_rendererMaps = new List<RendererMaterialMap>();
			UpdateRenderers();
			_part.Part.RenderQueueChanged += OnRenderQueueChanged;
			InitializeMaterial();
		}

		public void InitializeBakedMeshData(Transform originTransform)
		{
			if (_part.LoadContext == CraftLoadContext.Designer)
			{
				return;
			}
			_bakeMeshDataPartToPaintOriginMatrix = Matrix4x4.Translate(-_part.Aircraft.Aircraft.PaintOrigin) * UnityTransformUtility.GetTargetToAncestorTransformMatrix(_part.transform, _part.Aircraft.transform);
			for (int i = 0; i < _part.Part.MaterialIds.Count; i++)
			{
				int materialId = _part.Part.MaterialIds[i];
				PartMaterial material = _theme.Theme.GetMaterial(materialId);
				if (material != null)
				{
					if (material.Style == PaintStyle.SinglePlaneTextureColorMask)
					{
						_bakedMeshPositions = true;
					}
					else if (material.Style == PaintStyle.TriPlaneTextureColorMask)
					{
						_bakedMeshPositions = true;
						_bakedMeshNormals = true;
					}
				}
			}
		}

		public void InitializeMaterial(RendererMaterialMap rendererMap = null)
		{
			InitializeMaterial(async: false, rendererMap).Forget();
		}

		public async UniTask InitializeMaterial(bool async, RendererMaterialMap rendererMap = null)
		{
			int count = _part.Part.MaterialIds.Count;
			for (int i = 0; i < count; i++)
			{
				await SetMaterial(_part.Part.MaterialIds[i], i, initializingPartMaterial: true, async, rendererMap);
			}
			if (_updateMaterial == null)
			{
				_updateMaterial = new RunOnceOnNextUpdate(this, UpdateMaterial);
			}
			_updateMaterial.Queue();
		}

		public virtual void OnLateUpdate(in CraftUpdateFrameData frame)
		{
			if (IsOutlined || TutorialHighlight != null)
			{
				if (_partOutliningRenderers == null)
				{
					_partOutliningRenderers = new List<Renderer>(RendererMaps.Count);
				}
				else
				{
					_partOutliningRenderers.Clear();
				}
				foreach (PartModifierScript modifier in _part.Modifiers)
				{
					modifier.GetRenderersForHighlight(_partOutliningRenderers);
				}
				if (_partOutliningRenderers.Count == 0)
				{
					_partOutliningRenderers.AddRange(_rendererMaps.Select((RendererMaterialMap x) => x.Renderer));
				}
				foreach (Renderer partOutliningRenderer in _partOutliningRenderers)
				{
					if (partOutliningRenderer.gameObject.activeInHierarchy)
					{
						DrawOutlineForRenderer(partOutliningRenderer, IsOutlined, TutorialHighlight);
					}
				}
				_partOutliningRenderers.Clear();
			}
			_highlightEffect?.LateUpdate();
		}

		public void OnMeshChanged()
		{
			_highlightEffect.Refresh();
		}

		public void OnPartDamaged()
		{
			if (ShowPartDamage && _partDamageMaterial == null)
			{
				InitializePartDamageMaterial();
				foreach (RendererMaterialMap rendererMap in _rendererMaps)
				{
					rendererMap.SetRendererMaterial(_partDamageMaterial);
				}
			}
			if (_partDamageMaterial != null && _partDamageMaterial.HasProperty("_EmissionColor"))
			{
				float num = _part.PartDamage / _part.MaxHealth;
				Color value = _theme.Theme.PartDamageColor * num;
				_partDamageMaterial.SetColor("_EmissionColor", value);
			}
		}

		public unsafe void OnPartIdUpdated()
		{
			int id = _part.Part.Id;
			foreach (RendererMaterialMap rendererMap in _rendererMaps)
			{
				if (!(rendererMap.Renderer == null))
				{
					MeshFilter component = rendererMap.Renderer.GetComponent<MeshFilter>();
					Mesh mesh = (rendererMap.MeshIsUnique ? component.sharedMesh : component.mesh);
					Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(mesh);
					NativeArray<Vector3> nativeArray = new NativeArray<Vector3>(mesh.vertexCount, Allocator.Temp);
					Vector3* unsafeBufferPointerWithoutChecks = (Vector3*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(nativeArray);
					if (meshDataArray[0].HasVertexAttribute(VertexAttribute.TexCoord1))
					{
						meshDataArray[0].GetUVs(1, nativeArray);
					}
					for (int i = 0; i < nativeArray.Length; i++)
					{
						unsafeBufferPointerWithoutChecks[i].z = id;
					}
					mesh.SetUVs(1, nativeArray);
					meshDataArray.Dispose();
					nativeArray.Dispose();
				}
			}
		}

		public void OnThemeUpdated()
		{
			this.OnBeforePaintInDesigner?.Invoke(this, new PaintedEventArgs());
			if (_hasColoredMaterialInstances)
			{
				ApplyAllMaterials();
			}
			this.OnPaintedInDesigner?.Invoke(this, new PaintedEventArgs());
		}

		public void RemoveRenderer(MeshRenderer renderer, bool destroy = false)
		{
			for (int i = 0; i < _rendererMaps.Count; i++)
			{
				RendererMaterialMap rendererMaterialMap = _rendererMaps[i];
				if (rendererMaterialMap.Renderer == renderer)
				{
					rendererMaterialMap.OnRemoved(this);
					if (destroy)
					{
						rendererMaterialMap.OnDestroy();
					}
					_rendererMaps.RemoveAt(i);
					_highlightEffect.Refresh();
					break;
				}
			}
		}

		public void RestoreOriginalMaterials()
		{
			foreach (RendererMaterialMap rendererMap in _rendererMaps)
			{
				rendererMap.SetRendererMaterial(rendererMap.OriginalMaterials);
			}
		}

		public void SetMaterial(int material, int level, bool initializingPartMaterial, RendererMaterialMap targetRendererMap = null)
		{
			SetMaterial(material, level, initializingPartMaterial, async: false, targetRendererMap).Forget();
		}

		public async UniTask SetMaterial(int material, int level, bool initializingPartMaterial, bool async, RendererMaterialMap targetRendererMap = null)
		{
			this.OnBeforePaintInDesigner?.Invoke(this, new PaintedEventArgs(uvsChanged: true));
			await SetMaterialNoEvents(material, level, initializingPartMaterial, async, targetRendererMap);
			this.OnPaintedInDesigner?.Invoke(this, new PaintedEventArgs(uvsChanged: true));
		}

		public void SetMaterialNoEvents(int material, int level, bool initializingPartMaterial, RendererMaterialMap targetRendererMap = null)
		{
			SetMaterialNoEvents(material, level, initializingPartMaterial, async: false, targetRendererMap).Forget();
		}

		public async UniTask SetMaterialNoEvents(int material, int level, bool initializingPartMaterial, bool async, RendererMaterialMap targetRendererMap = null)
		{
			if (!initializingPartMaterial && _part.Part.MaterialIds[level] < 0)
			{
				material = _part.Part.MaterialIds[level];
			}
			else
			{
				_part.Part.MaterialIds[level] = material;
			}
			int materialIndex = _theme.Theme.GetMaterialIndex(material);
			switch (level)
			{
			case 0:
				MaterialIdPrimary = materialIndex;
				break;
			case 1:
				MaterialIdSecondary = materialIndex;
				break;
			}
			List<(Mesh Mesh, Mesh.MeshDataArray MeshDataArray, NativeArray<Vector3> Uvs, int SubmeshIndex, bool ResponsibleForDisposal)> uvUpdates = CollectionPool<List<(Mesh, Mesh.MeshDataArray, NativeArray<Vector3>, int, bool)>, (Mesh, Mesh.MeshDataArray, NativeArray<Vector3>, int, bool)>.Get();
			Dictionary<int, (Mesh.MeshDataArray, NativeArray<Vector3>)> value;
			using (CollectionPool<Dictionary<int, (Mesh.MeshDataArray, NativeArray<Vector3>)>, KeyValuePair<int, (Mesh.MeshDataArray, NativeArray<Vector3>)>>.Get(out value))
			{
				foreach (RendererMaterialMap rendererMap in _rendererMaps)
				{
					if ((targetRendererMap != null && rendererMap != targetRendererMap) || rendererMap.Renderer == null)
					{
						continue;
					}
					List<int> value2;
					using (CollectionPool<List<int>, int>.Get(out value2))
					{
						int[] submeshToLevelMap = rendererMap.SubmeshToLevelMap;
						if (submeshToLevelMap == null)
						{
							if (level < rendererMap.MaterialTypes.Length)
							{
								value2.Add(level);
							}
						}
						else
						{
							for (int i = 0; i < submeshToLevelMap.Length; i++)
							{
								if (submeshToLevelMap[i] == level)
								{
									value2.Add(i);
								}
							}
						}
						foreach (int item8 in value2)
						{
							PartRendererMaterialType partRendererMaterialType = rendererMap.MaterialTypes[item8];
							if (partRendererMaterialType == PartRendererMaterialType.DefaultShared || partRendererMaterialType == PartRendererMaterialType.DefaultInstanced)
							{
								MeshFilter component = rendererMap.Renderer.GetComponent<MeshFilter>();
								Mesh mesh = (rendererMap.MeshIsUnique ? component.sharedMesh : component.mesh);
								if (item8 >= mesh.subMeshCount)
								{
									continue;
								}
								bool item = false;
								if (!value.TryGetValue(mesh.GetInstanceID(), out var value3))
								{
									Mesh.MeshDataArray item2 = Mesh.AcquireReadOnlyMeshData(mesh);
									NativeArray<Vector3> nativeArray = new NativeArray<Vector3>(mesh.vertexCount, Allocator.TempJob);
									if (item2[0].HasVertexAttribute(VertexAttribute.TexCoord1))
									{
										item2[0].GetUVs(1, nativeArray);
									}
									value3 = (item2, nativeArray);
									value.Add(mesh.GetInstanceID(), value3);
									item = true;
								}
								uvUpdates.Add((mesh, value3.Item1, value3.Item2, item8, item));
							}
							else
							{
								if (rendererMap.MaterialTypes[item8] != PartRendererMaterialType.CustomWithThemeColors || material < 0)
								{
									continue;
								}
								Material material2 = rendererMap.Renderer.materials[item8];
								material2.color = _part.Aircraft.Theme.Theme.Materials[material].PrimaryColor;
								bool flag = rendererMap.HighlightMaterials != null && rendererMap.HighlightMaterials.Length >= rendererMap.OriginalMaterials.Length;
								if (rendererMap.OriginalMaterials[item8] != material2)
								{
									if (flag)
									{
										rendererMap.HighlightMaterials[item8] = _theme.ReplaceHighlightMaterial(rendererMap.OriginalMaterials[item8], material2);
									}
									rendererMap.OriginalMaterials[item8] = material2;
								}
								else if (flag)
								{
									rendererMap.HighlightMaterials[item8] = _theme.UpdateHighlightMaterial(material2);
								}
							}
						}
					}
				}
				if (uvUpdates.Count > 0)
				{
					if (async)
					{
						await UniTask.RunOnThreadPool(delegate
						{
							UpdateUVs(uvUpdates, materialIndex, _part.Part.Id);
						});
					}
					else
					{
						UpdateUVs(uvUpdates, materialIndex, _part.Part.Id);
					}
					foreach (var (mesh2, _, uvs, _, _) in uvUpdates)
					{
						using (Profile.SetMaterialNoEvents_AssignUVs.Auto())
						{
							mesh2.SetUVs(1, uvs);
						}
					}
					foreach (var item9 in uvUpdates)
					{
						Mesh.MeshDataArray item3 = item9.MeshDataArray;
						NativeArray<Vector3> item4 = item9.Uvs;
						if (item9.ResponsibleForDisposal)
						{
							item3.Dispose();
							item4.Dispose();
						}
					}
				}
				CollectionPool<List<(Mesh, Mesh.MeshDataArray, NativeArray<Vector3>, int, bool)>, (Mesh, Mesh.MeshDataArray, NativeArray<Vector3>, int, bool)>.Release(uvUpdates);
			}
			static void UpdateUVs(List<(Mesh Mesh, Mesh.MeshDataArray MeshData, NativeArray<Vector3> Uvs, int SubmeshIndex, bool ResponsibleForDisposal)> list, int num2, int partId)
			{
				using (Profile.SetMaterialNoEvents_UpdateUVs.Auto())
				{
					foreach (var item10 in list)
					{
						Mesh.MeshDataArray item5 = item10.MeshData;
						NativeArray<Vector3> item6 = item10.Uvs;
						int item7 = item10.SubmeshIndex;
						SubMeshDescriptor subMesh = item5[0].GetSubMesh(item7);
						int num = subMesh.indexStart + subMesh.indexCount;
						if (item5[0].indexFormat == IndexFormat.UInt16)
						{
							ReadOnlySpan<ushort> readOnlySpan = item5[0].GetIndexData<ushort>().AsReadOnlySpan();
							Span<Vector3> span = item6.AsSpan();
							for (int j = subMesh.indexStart; j < num; j++)
							{
								int index = readOnlySpan[j];
								span[index] = new Vector3(num2, (span[index].y != 0f) ? span[index].y : DecalLayers.DefaultRenderingLayerFloat, partId);
							}
						}
						else if (item5[0].indexFormat == IndexFormat.UInt32)
						{
							ReadOnlySpan<uint> readOnlySpan2 = item5[0].GetIndexData<uint>().AsReadOnlySpan();
							Span<Vector3> span2 = item6.AsSpan();
							for (int k = subMesh.indexStart; k < num; k++)
							{
								int index2 = (int)readOnlySpan2[k];
								span2[index2] = new Vector3(num2, (span2[index2].y != 0f) ? span2[index2].y : DecalLayers.DefaultRenderingLayerFloat, partId);
							}
						}
						else
						{
							Debug.LogError($"Unexpected index format {item5[0].indexFormat}.");
						}
					}
				}
			}
		}

		public void SetReflectionProbe(ReflectionProbe reflectionProbe)
		{
			Transform probeAnchor = reflectionProbe?.transform;
			foreach (RendererMaterialMap rendererMap in _rendererMaps)
			{
				if (rendererMap.Renderer != null)
				{
					rendererMap.Renderer.probeAnchor = probeAnchor;
				}
			}
			foreach (Renderer item in _renderersNotInMap)
			{
				if (item != null)
				{
					item.probeAnchor = probeAnchor;
				}
			}
		}

		public void SetSelected(bool selected, bool updateSymmetricParts)
		{
			IsSelected = selected;
			if (!updateSymmetricParts || _part.Part.SymmetryId == 0)
			{
				return;
			}
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				_part.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(_part.Part, value);
				foreach (PartData item in value)
				{
					item.PartScript.PartMaterialScript.IsSelectedSymmetric = selected;
				}
			}
		}

		public void StartDesignerPaintEvents(bool uvChange = false)
		{
			this.OnBeforePaintInDesigner?.Invoke(this, new PaintedEventArgs(uvChange));
		}

		public void UpdateRenderers()
		{
			PartMaterial = _theme.Material;
			PartMaterialBdm = _theme.MaterialBdm;
			_hasBeforeDepthMaskRenderer = RenderQueue == PartMeshRenderQueue.BeforeDepthMask;
			Transform probeAnchor = _part.Aircraft.ReflectionProbe?.transform;
			ClearRenderers();
			Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				renderer.probeAnchor = probeAnchor;
				if (renderer is MeshRenderer meshRenderer)
				{
					if (AddRenderer(meshRenderer) == null)
					{
						_renderersNotInMap.Add(meshRenderer);
					}
				}
				else
				{
					_renderersNotInMap.Add(renderer);
				}
			}
		}

		protected virtual void OnDestroy()
		{
			_part.Part.RenderQueueChanged -= OnRenderQueueChanged;
			_highlightEffect.OnDestroy();
			if (_partDamageMaterial != null)
			{
				UnityEngine.Object.Destroy(_partDamageMaterial);
			}
			foreach (RendererMaterialMap rendererMap in _rendererMaps)
			{
				try
				{
					rendererMap.OnRemoved(this);
					rendererMap.OnDestroy();
				}
				catch (Exception exception)
				{
					Debug.LogError($"Error destroying renderer map on part '{_part.Part.Name}' (ID: {_part.Part.Id})");
					Debug.LogException(exception);
				}
			}
		}

		private void BakeMeshPositionsAndNormals(RendererMaterialMap renderer)
		{
			if (renderer.Renderer == null || renderer.BakedMeshData)
			{
				return;
			}
			using (Profile.BakePositionsAndNormals.Auto())
			{
				renderer.BakedMeshData = true;
				Mesh mesh = renderer.Mesh;
				Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(mesh);
				Matrix4x4 targetToAncestorTransformMatrix = UnityTransformUtility.GetTargetToAncestorTransformMatrix(renderer.Renderer.transform, _part.transform);
				Matrix4x4 matrix4x = _bakeMeshDataPartToPaintOriginMatrix * targetToAncestorTransformMatrix;
				if (_bakedMeshPositions)
				{
					NativeArray<Vector3> nativeArray = new NativeArray<Vector3>(mesh.vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					meshDataArray[0].GetVertices(nativeArray);
					for (int i = 0; i < nativeArray.Length; i++)
					{
						nativeArray[i] = matrix4x.MultiplyPoint3x4(nativeArray[i]);
					}
					mesh.SetUVs(2, nativeArray);
					nativeArray.Dispose();
				}
				if (_bakedMeshNormals)
				{
					NativeArray<Vector3> nativeArray2 = new NativeArray<Vector3>(mesh.vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					meshDataArray[0].GetNormals(nativeArray2);
					Matrix4x4 transpose = matrix4x.inverse.transpose;
					for (int j = 0; j < nativeArray2.Length; j++)
					{
						nativeArray2[j] = transpose.MultiplyVector(nativeArray2[j]).normalized;
					}
					mesh.SetUVs(3, nativeArray2);
					nativeArray2.Dispose();
				}
				meshDataArray.Dispose();
			}
		}

		private void InitializePartDamageMaterial()
		{
			_part.PartGroup.DecombineMesh(_part);
			_partDamageMaterial = UnityEngine.Object.Instantiate(_theme.Material);
			_partDamageMaterial.EnableKeyword("USE_EMISSION_COLOR");
			_partDamageMaterial.EnableKeyword("_EMISSION");
			OnPartDamaged();
		}

		private void OnRenderQueueChanged(object sender, EventArgs e)
		{
			Debug.Log($"RenderQueueChanged: {_part.Part.RenderQueue}");
			UpdateRenderers();
		}

		private void SetRendererMaterial(Material material, bool updateRenderQueue)
		{
			foreach (RendererMaterialMap rendererMap in _rendererMaps)
			{
				rendererMap.SetRendererMaterial(material);
			}
			if (!updateRenderQueue)
			{
				return;
			}
			foreach (RendererMaterialMap rendererMap2 in _rendererMaps)
			{
				rendererMap2.UpdateRenderQueue(_hasBeforeDepthMaskRenderer);
			}
		}

		private void UpdateMaterial()
		{
			bool flag = true;
			if (this.CustomMaterialUpdateCallback != null)
			{
				Color? color = null;
				Material material = null;
				if (IsCollidingInDesigner)
				{
					material = _collisionMaterial;
					color = _collisionMaterial.color;
				}
				else if (FoundAttachPoint)
				{
					material = _foundAttachPointMaterial;
					color = _foundAttachPointMaterial.color;
				}
				else if (IsSelected)
				{
					color = new Color(1f, 1f, 1f, 0.2f);
				}
				else if (IsHidden)
				{
					material = _hiddenMaterial;
					color = _hiddenMaterial.color;
				}
				else if (IsHighlighted)
				{
					color = new Color(1f, 1f, 1f, 0.2f);
				}
				MaterialUpdateEventArgs e = new MaterialUpdateEventArgs(color, material);
				this.CustomMaterialUpdateCallback(this, e);
				if (!e.EnableOutlineEffect)
				{
					_highlightEffect.DisableHighlight();
				}
				flag = e.SetMaterialsNormally;
			}
			if (flag)
			{
				if ((bool)OverrideMaterial)
				{
					_highlightEffect.DisableHighlight();
					SetRendererMaterial(OverrideMaterial, updateRenderQueue: true);
				}
				else if (IsHidden)
				{
					_highlightEffect.DisableHighlight();
					SetRendererMaterial(_hiddenMaterial, updateRenderQueue: false);
				}
				else if (IsDisconnected)
				{
					SetRendererMaterial(_disconnectedMaterial, updateRenderQueue: true);
				}
				else if ((bool)CustomMaterial)
				{
					SetRendererMaterial(CustomMaterial, updateRenderQueue: false);
				}
				else if (ShowPartDamage)
				{
					if (_part.PartDamage > 0f)
					{
						if (_partDamageMaterial == null)
						{
							InitializePartDamageMaterial();
						}
						SetRendererMaterial(_partDamageMaterial, updateRenderQueue: false);
					}
				}
				else
				{
					RestoreOriginalMaterials();
				}
			}
			if (IsCollidingInDesigner)
			{
				_highlightEffect.EnableHighlight(1f, Color.red);
			}
			else if (FoundAttachPoint)
			{
				_highlightEffect.EnableHighlight(1f, Color.green);
			}
			else if (IsSelected)
			{
				_highlightEffect.EnableHighlight(1f, Constants.Colors.PrimaryLight);
			}
			else if (IsSelectedSymmetric)
			{
				_highlightEffect.EnableHighlight(1f, Constants.Colors.Symmetric);
			}
			else if (IsHighlighted)
			{
				_highlightEffect.EnableHighlight(0.5f, Constants.Colors.HighlightColor, -1);
			}
			else
			{
				_highlightEffect.DisableHighlight();
			}
		}
	}
}
