using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Settings;
using ModApi.Settings.Core;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft
{
	[GameLoopExecutionOrder(-4800)]
	public class PartGroupScript : MonoBehaviourBase, IPartGroupScript, IFlightLateUpdate, IGameLoopItem, IFlightLateUpdatePaused
	{
		private struct MeshData
		{
			public List<Vector3> Normals;

			public List<Vector4> Tangents;

			public List<int> Triangles;

			public List<Vector4> UV1;

			public List<Vector4> UV2;

			public int VertexCount;

			public List<Vector3> Vertices;

			public void Init()
			{
				Vertices = new List<Vector3>();
				Normals = new List<Vector3>();
				Tangents = new List<Vector4>();
				UV1 = new List<Vector4>();
				UV2 = new List<Vector4>();
				Triangles = new List<int>();
			}

			public void PrepareCombineSource(Mesh mesh)
			{
				VertexCount = mesh.vertexCount;
				mesh.GetVertices(Vertices);
				mesh.GetNormals(Normals);
				mesh.GetTangents(Tangents);
				mesh.GetUVs(0, UV1);
				mesh.GetUVs(1, UV2);
				mesh.GetTriangles(Triangles, 0);
				if (Normals.Count != VertexCount)
				{
					if (Normals.Count == 0)
					{
						Debug.LogError("Mesh '" + mesh.name + "' does not have any 'Normals' data.");
					}
					else
					{
						Debug.LogError("The vertex count and 'Normals' count for mesh '" + mesh.name + "' do not match.");
					}
					Normals.AddRange(Enumerable.Repeat(Vector3.one, VertexCount));
				}
				if (Tangents.Count != VertexCount)
				{
					if (Tangents.Count == 0)
					{
						Debug.LogError("Mesh '" + mesh.name + "' does not have any 'Tangents' data.");
					}
					else
					{
						Debug.LogError("The vertex count and 'Tangents' count for mesh '" + mesh.name + "' do not match.");
					}
					Tangents.AddRange(Enumerable.Repeat(Vector4.one, VertexCount));
				}
				if (UV1.Count != VertexCount)
				{
					if (UV1.Count == 0)
					{
						Debug.LogError("Mesh '" + mesh.name + "' does not have any 'UV1' data.");
					}
					else
					{
						Debug.LogError("The vertex count and 'UV1' count for mesh '" + mesh.name + "' do not match.");
					}
					UV1.AddRange(Enumerable.Repeat(Vector4.zero, VertexCount));
				}
				if (UV2.Count != VertexCount)
				{
					if (UV2.Count == 0)
					{
						Debug.LogError("Mesh '" + mesh.name + "' does not have any 'UV2' data.");
					}
					else
					{
						Debug.LogError("The vertex count and 'UV2' count for mesh '" + mesh.name + "' do not match.");
					}
					UV2.AddRange(Enumerable.Repeat(Vector4.zero, VertexCount));
				}
			}

			public void PrepareCombineTarget(int vertexCount)
			{
				VertexCount = vertexCount;
				Vertices.Resize(vertexCount);
				Normals.Resize(vertexCount);
				Tangents.Resize(vertexCount);
				UV1.Resize(vertexCount);
				UV2.Resize(vertexCount);
				Triangles.Clear();
			}
		}

		private struct RendererInfo
		{
			public IPartScript Part;

			public int PartGroupPartId;

			public IRendererMaterialMap RendererMaterialMap;

			public RendererInfo(int partGroupPartId, IPartScript part, IRendererMaterialMap rendererMaterialMap)
			{
				Part = part;
				PartGroupPartId = partGroupPartId;
				RendererMaterialMap = rendererMaterialMap;
			}
		}

		public class MaterialPartData
		{
			private bool _outlined;

			private bool _selected;

			public int Index { get; private set; }

			public bool Outlined
			{
				get
				{
					return _outlined;
				}
				set
				{
					if (_outlined != value)
					{
						_outlined = value;
						PartGroup.OnPartOutliningChanged(Index, _selected, _outlined);
					}
				}
			}

			public PartGroupScript PartGroup { get; }

			public PartMaterialScript PartMaterial { get; }

			public bool Selected
			{
				get
				{
					return _selected;
				}
				set
				{
					if (_selected != value)
					{
						_selected = value;
						PartGroup.OnPartSelectedChanged(Index, _selected, _outlined);
					}
				}
			}

			public MaterialPartData(int index, PartGroupScript partGroup, PartMaterialScript partMaterialScript)
			{
				Index = index;
				PartGroup = partGroup;
				PartMaterial = partMaterialScript;
			}
		}

		private static class ShaderPropertyIds
		{
			public static readonly int AlphaOverride = Shader.PropertyToID("_AlphaOverride");

			public static readonly int EmissiveColorOverride = Shader.PropertyToID("_EmissiveOverride");

			public static readonly int EmissiveOverride = Shader.PropertyToID("_EmissiveOverride");

			public static readonly int PartData = Shader.PropertyToID("_PartData");
		}

		private class PartGroupRendererMaterialMap : IRendererMaterialMap
		{
			private bool _tempRenderEnabledState;

			private bool _tempRenderInProgress;

			private int _tempRenderOriginalLayer;

			private Material _tempRenderOriginalMaterial;

			public float AlphaOverride { get; set; }

			public int CombinedMeshVertexCount { get; set; }

			public int CombinedMeshVertexOffset { get; set; }

			public Texture2D DecalTexture { get; set; }

			public Vector4i DecalTextureMaterialLevels { get; set; }

			public Vector4 DecalTextureOffsetAndTiling { get; set; }

			public Vector3 EmissiveColorOverride { get; set; }

			public float EmissiveOverride { get; set; }

			public bool ExcludeFromDragModel => false;

			public bool ExcludeFromMeshCombine
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool HasCustomMaterial => false;

			public bool HasDecal => false;

			public bool HasTransparency => false;

			public bool IsTMProRenderer => false;

			public Mesh Mesh { get; private set; }

			public Material[] OriginalMaterials { get; private set; }

			public IPartMaterialScript PartMaterialScript => null;

			public bool RenderBeforeDepthMask { get; private set; }

			public Renderer Renderer { get; private set; }

			public bool[] TrimLevelsUsed
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public bool UsesAlphaOverride { get; set; }

			public bool UsesEmissiveOverride { get; set; }

			public bool WasMeshCombined { get; set; }

			public PartGroupRendererMaterialMap(MeshRenderer renderer, Mesh mesh, Material material)
			{
				Renderer = renderer;
				Mesh = mesh;
				EmissiveOverride = -1f;
				AlphaOverride = -1f;
				EmissiveColorOverride = new Vector3(-1f, 0f, 0f);
				OriginalMaterials = new Material[1] { material };
			}

			public void ApplyDecalTexture()
			{
				Debug.LogError("Manually applying the decal texture to the part group renderer is not supported.");
			}

			public void ApplyEmissiveOverride()
			{
				Debug.LogError("Manually applying the emissive override value to the part group renderer is not supported.");
			}

			public void ApplyMaterials()
			{
				Debug.LogError("Manually applying the materials to the part group renderer is not supported.");
			}

			public void Destroy()
			{
			}

			public void EndTempRender()
			{
				if (!(Renderer == null) && _tempRenderInProgress)
				{
					_tempRenderInProgress = false;
					Renderer.gameObject.layer = _tempRenderOriginalLayer;
					Renderer.enabled = _tempRenderEnabledState;
					Renderer.material = _tempRenderOriginalMaterial;
				}
			}

			public void ReplaceOriginalMaterials(Material material, bool setAsCurrent)
			{
				OriginalMaterials[0] = material;
				if (setAsCurrent && Renderer != null)
				{
					Renderer.material = material;
				}
			}

			public void SetRendererMaterial(Material[] materials)
			{
				if (!(Renderer == null))
				{
					Renderer.material = materials[0];
				}
			}

			public void SetRendererMaterial(Material material)
			{
				if (!(Renderer == null))
				{
					Renderer.material = material;
				}
			}

			public void StartTempRender(int layer, Material material)
			{
				if (!(Renderer == null))
				{
					GameObject gameObject = Renderer.gameObject;
					if (!_tempRenderInProgress)
					{
						_tempRenderOriginalMaterial = Renderer.sharedMaterial;
						_tempRenderOriginalLayer = gameObject.layer;
						_tempRenderEnabledState = Renderer.enabled;
						Renderer.enabled = true;
						_tempRenderInProgress = true;
					}
					gameObject.layer = layer;
					if (material != null)
					{
						Renderer.material = material;
					}
				}
			}

			public void UpdateMaterialPropertyBlock(MaterialPropertyBlock materialPropertyBlock)
			{
				Debug.LogError("Manually updating the material property block on the part group renderer is not supported.");
			}
		}

		public const int MaxPartsPerPartGroup = 25;

		private static MeshData _combineSource;

		private static MeshData _combineTarget;

		private static Vector4[] _defaultShaderPartData;

		private Mesh _combinedMesh;

		private bool _initialized;

		private Material _material;

		private Material _materialBdm;

		private MaterialPropertyBlock _materialPropertyBlock;

		private MaterialPropertyBlock _materialPropertyBlockDecals;

		private Material _materialTransparency;

		private int _outlinedPartCount;

		private List<IPartScript> _outlinedParts;

		private bool _partDataDirty;

		private PartGroupRendererMaterialMap _partGroupRenderer;

		private List<IPartMaterialScript> _partMaterialScripts;

		private Material _partOutlineMaterial;

		private List<IPartScript> _partScripts;

		private EnumSetting<ImageEffectsQualitySettings.ReEntryQuality> _reentryQuality;

		private int _selectedPartCount;

		private Vector4[] _shaderPartData;

		private ITheme _theme;

		public IBodyScript BodyScript { get; set; }

		public MeshFilter CombinedMeshFilter { get; private set; }

		public IReadOnlyList<PartScript> CombinedMeshParts { get; private set; }

		public MeshRenderer CombinedMeshRenderer { get; private set; }

		public PartGroupData Data { get; private set; }

		public GameObject GameObject => base.gameObject;

		public int Id { get; set; }

		public Material Material => _material;

		public Material MaterialTransparency => _materialTransparency;

		public Dictionary<IPartScript, int> MeshVertexOffsets { get; set; }

		public IReadOnlyList<IPartScript> OutlinedParts => _outlinedParts;

		public IRendererMaterialMap PartGroupRenderer => _partGroupRenderer;

		public event PartGroupDisconnectedHandler Disconnected;

		public event IPartGroupScript.PartGroupDelegate Initialized
		{
			add
			{
				if (_initialized)
				{
					value(this);
				}
				else
				{
					_initializedEvent += value;
				}
			}
			remove
			{
				_initializedEvent -= value;
			}
		}

		private event IPartGroupScript.PartGroupDelegate _initializedEvent;

		static PartGroupScript()
		{
			_defaultShaderPartData = new Vector4[25];
			_combineSource.Init();
			_combineTarget.Init();
		}

		void IFlightLateUpdate.FlightLateUpdate(in FlightFrameData frame)
		{
			if (_initialized)
			{
				UpdateMaterialPartData();
			}
		}

		void IFlightLateUpdatePaused.FlightLateUpdatePaused(in FlightFrameData frame)
		{
			if (_initialized)
			{
				UpdateMaterialPartData();
			}
		}

		public MaterialPropertyBlock GetMaterialPropertyBlockForNonCombinedMesh(IRendererMaterialMap rendererMaterialMap)
		{
			_materialPropertyBlock.SetFloat(ShaderPropertyIds.EmissiveOverride, rendererMaterialMap.EmissiveOverride);
			_materialPropertyBlock.SetFloat(ShaderPropertyIds.AlphaOverride, rendererMaterialMap.AlphaOverride);
			return _materialPropertyBlock;
		}

		public Material GetPartOutlineMaskMaterial()
		{
			if (_partOutlineMaterial == null)
			{
				_partOutlineMaterial = UnityEngine.Object.Instantiate(Game.Instance.ResourceLoader.LoadMaterial("Craft/Parts/Materials/PartMaterialOutlineMask"));
				_partOutlineMaterial.SetVectorArray(ShaderPropertyIds.PartData, _defaultShaderPartData);
			}
			return _partOutlineMaterial;
		}

		public void Initialize()
		{
			if (!_initialized)
			{
				List<PartData> parts = Data.Parts;
				int count = parts.Count;
				_partScripts = new List<IPartScript>(count);
				_partMaterialScripts = new List<IPartMaterialScript>(count);
				for (int i = 0; i < count; i++)
				{
					IPartScript partScript = parts[i].PartScript;
					_partScripts.Add(partScript);
					_partMaterialScripts.Add(partScript.PartMaterialScript);
				}
				CreateMaterial();
				UpdateMaterialPartData();
				ProcessMeshes();
				if (CombinedMeshRenderer != null)
				{
					_partGroupRenderer = new PartGroupRendererMaterialMap(CombinedMeshRenderer, CombinedMeshFilter.sharedMesh, _material);
				}
				_initialized = true;
				OnPartGroupInitialized();
				this._initializedEvent?.Invoke(this);
			}
		}

		public void OnAlphaOverrideChanged()
		{
			_partDataDirty = true;
		}

		public void OnBeingDisconnected(bool isExploding)
		{
			this.Disconnected?.Invoke(this, isExploding);
		}

		public void OnEmissiveOverrideChanged()
		{
			_partDataDirty = true;
		}

		public void RemovePart(PartData part)
		{
			Data.Parts.Remove(part);
		}

		protected virtual void Awake()
		{
			Data = new PartGroupData();
			base.gameObject.layer = 31;
			_outlinedParts = new List<IPartScript>();
			_reentryQuality = Game.Instance.QualitySettings.ImageEffects.ReEntry;
		}

		protected virtual void OnDestroy()
		{
			if (!_initialized)
			{
				return;
			}
			if (_combinedMesh != null)
			{
				UnityEngine.Object.Destroy(_combinedMesh);
				_combinedMesh = null;
			}
			if (_theme != null)
			{
				_theme.ReleaseDefaultPartMaterialInstance(_material);
				if (_materialBdm != null)
				{
					_theme.ReleaseDefaultPartMaterialInstance(_materialBdm);
				}
				if (_materialTransparency != null)
				{
					_theme.ReleaseTransparentPartMaterialInstance(_materialTransparency);
				}
			}
			else if (_material == null)
			{
				Debug.LogError("Part group is unable to release material instance because the theme could not be found.");
			}
			else
			{
				UnityEngine.Object.Destroy(_material);
			}
			_material = null;
			_materialBdm = null;
			if (_partOutlineMaterial != null)
			{
				UnityEngine.Object.Destroy(_partOutlineMaterial);
				_partOutlineMaterial = null;
			}
		}

		private void CleanupCombinedRenderers(List<RendererInfo> renderers)
		{
			foreach (RendererInfo renderer in renderers)
			{
				renderer.RendererMaterialMap.Destroy();
			}
		}

		private void CombineMeshes(List<RendererInfo> renderers, int vertexCount)
		{
			Matrix4x4 inverse = base.transform.localToWorldMatrix.inverse;
			int num = 0;
			_combineTarget.PrepareCombineTarget(vertexCount);
			foreach (RendererInfo renderer in renderers)
			{
				Mesh mesh = renderer.RendererMaterialMap.Mesh;
				_combineSource.PrepareCombineSource(mesh);
				int num2 = num;
				int partGroupPartId = renderer.PartGroupPartId;
				Matrix4x4 matrix4x = inverse * renderer.RendererMaterialMap.Renderer.transform.localToWorldMatrix;
				for (int i = 0; i < _combineSource.VertexCount; i++)
				{
					Vector4 value = _combineSource.UV1[i];
					value.w = (float)partGroupPartId + value.w % 1f;
					_combineTarget.Vertices[num2] = matrix4x.MultiplyPoint3x4(_combineSource.Vertices[i]);
					_combineTarget.Normals[num2] = matrix4x.MultiplyVector(_combineSource.Normals[i]).normalized;
					_combineTarget.Tangents[num2] = matrix4x.MultiplyVector(_combineSource.Tangents[i]).normalized.ToVector4(_combineSource.Tangents[i].w);
					_combineTarget.UV1[num2] = value;
					_combineTarget.UV2[num2] = _combineSource.UV2[i];
					num2++;
				}
				List<int> triangles = _combineSource.Triangles;
				int count = triangles.Count;
				for (int j = 0; j < count; j++)
				{
					triangles[j] += num;
				}
				_combineTarget.Triangles.AddRange(triangles);
				num = num2;
			}
			Mesh mesh2 = (_combinedMesh = new Mesh());
			mesh2.name = $"PartGroup_CombinedMesh_{BodyScript.Data.Id}_{Id}";
			mesh2.indexFormat = ((vertexCount >= 65535) ? IndexFormat.UInt32 : IndexFormat.UInt16);
			mesh2.SetVertices(_combineTarget.Vertices);
			mesh2.SetNormals(_combineTarget.Normals);
			mesh2.SetTangents(_combineTarget.Tangents);
			mesh2.SetUVs(0, _combineTarget.UV1);
			mesh2.SetUVs(1, _combineTarget.UV2);
			mesh2.SetTriangles(_combineTarget.Triangles, 0);
			mesh2.UploadMeshData(markNoLongerReadable: true);
			List<PartScript> list = (List<PartScript>)(CombinedMeshParts = new List<PartScript>());
			foreach (RendererInfo renderer2 in renderers)
			{
				PartScript partScript = renderer2.Part as PartScript;
				if (partScript != null && !list.Contains(partScript))
				{
					list.Add(partScript);
				}
			}
			SwitchToCombinedMesh(mesh2, renderers);
		}

		private void CreateMaterial()
		{
			_theme = Data.Parts[0].ThemeData.Theme;
			_materialPropertyBlock = new MaterialPropertyBlock();
			_materialPropertyBlockDecals = new MaterialPropertyBlock();
			_shaderPartData = new Vector4[Data.Parts.Count];
			_material = _theme.RequestDefaultPartMaterialInstance();
			_material.name = $"PartMaterial_Default_PG{Id}";
			_material.SetColor("_Color", _theme.PartStateColors.Selected);
			_materialBdm = _theme.RequestDefaultPartMaterialInstance();
			_materialBdm.name = $"PartMaterial_BDM_PG{Id}";
			_materialBdm.renderQueue = 1990;
			_materialBdm.SetColor("_Color", _theme.PartStateColors.Selected);
			_materialTransparency = _theme.RequestTransparentPartMaterialInstance();
			_materialTransparency.name = $"PartMaterial_Transparent_PG{Id}";
			_materialTransparency.SetColor("_Color", _theme.PartStateColors.Selected);
			_partDataDirty = true;
		}

		private void OnPartGroupInitialized()
		{
			List<PartData> parts = Data.Parts;
			int count = parts.Count;
			for (int i = 0; i < count; i++)
			{
				PartMaterialScript partMaterialScript = (PartMaterialScript)parts[i].PartScript.PartMaterialScript;
				partMaterialScript.OnPartGroupInitialized(new MaterialPartData(i, this, partMaterialScript));
			}
		}

		private void OnPartOutliningChanged(int partGroupPartId, bool selected, bool outlined)
		{
			_shaderPartData[partGroupPartId].x = (selected ? 1f : (outlined ? 0.1f : 0f));
			_partDataDirty = true;
			if (outlined)
			{
				_outlinedPartCount++;
				_outlinedParts.Add(Data.Parts[partGroupPartId].PartScript);
			}
			else
			{
				_outlinedPartCount--;
				_outlinedParts.Remove(Data.Parts[partGroupPartId].PartScript);
			}
		}

		private void OnPartSelectedChanged(int partGroupPartId, bool selected, bool outlined)
		{
			_shaderPartData[partGroupPartId].x = (selected ? 1f : (outlined ? 0.1f : 0f));
			_partDataDirty = true;
			if (selected)
			{
				_selectedPartCount++;
				if (_selectedPartCount == 1)
				{
					_material?.EnableKeyword("RIMSHADE_ON");
					_materialBdm?.EnableKeyword("RIMSHADE_ON");
					_materialTransparency?.EnableKeyword("RIMSHADE_ON");
				}
			}
			else
			{
				_selectedPartCount--;
				if (_selectedPartCount == 0)
				{
					_material?.DisableKeyword("RIMSHADE_ON");
					_materialBdm?.DisableKeyword("RIMSHADE_ON");
					_materialTransparency?.DisableKeyword("RIMSHADE_ON");
				}
			}
		}

		private void ProcessMeshes()
		{
			List<PartData> parts = Data.Parts;
			int count = parts.Count;
			List<RendererInfo> list = new List<RendererInfo>();
			List<RendererInfo> list2 = new List<RendererInfo>();
			int num = 0;
			int num2 = (SystemInfo.supports32bitsIndexBuffer ? int.MaxValue : 65535);
			for (int i = 0; i < count; i++)
			{
				PartData partData = parts[i];
				List<IRendererMaterialMap> rendererMaps = partData.PartScript.PartMaterialScript.RendererMaps;
				bool includeInDrag = partData.Config.IncludeInDrag;
				foreach (IRendererMaterialMap item2 in rendererMaps)
				{
					RendererInfo item = new RendererInfo(i, partData.PartScript, item2);
					Mesh mesh = item2.Mesh;
					if (item2.HasTransparency || item2.HasDecal || item2.ExcludeFromMeshCombine || !item2.Renderer.gameObject.activeInHierarchy || !includeInDrag || !partData.Config.CastShadows || mesh.subMeshCount > 1)
					{
						list2.Add(item);
						continue;
					}
					int num3 = num + mesh.vertexCount;
					if (num3 >= num2)
					{
						list2.Add(item);
						continue;
					}
					if (item2.ExcludeFromDragModel)
					{
						Debug.LogWarning("Combining mesh (PartType: " + partData.PartType.Id + ") that should be excluded from drag. This is not supported.");
					}
					num = num3;
					list.Add(item);
					item2.WasMeshCombined = true;
					item2.CombinedMeshVertexCount = mesh.vertexCount;
					item2.CombinedMeshVertexOffset = num3 - mesh.vertexCount;
				}
			}
			if (list.Count > 0)
			{
				CombineMeshes(list, num);
			}
			foreach (RendererInfo item3 in list2)
			{
				ProcessUncombinedMesh(item3);
			}
		}

		private void ProcessUncombinedMesh(RendererInfo renderer)
		{
			if (renderer.RendererMaterialMap.IsTMProRenderer)
			{
				return;
			}
			int partGroupPartId = renderer.PartGroupPartId;
			Mesh mesh = renderer.RendererMaterialMap.Mesh;
			int vertexCount = mesh.vertexCount;
			List<Vector4> uV = _combineSource.UV1;
			mesh.GetUVs(0, uV);
			if (uV.Count < vertexCount)
			{
				Debug.LogErrorFormat(renderer.RendererMaterialMap?.Renderer, "Part mesh does not have UVs: {0}.{1}", renderer.Part?.Data?.PartType?.Name, renderer.RendererMaterialMap?.Renderer?.name);
				return;
			}
			for (int i = 0; i < vertexCount; i++)
			{
				Vector4 value = uV[i];
				value.w = (float)partGroupPartId + value.w % 1f;
				uV[i] = value;
			}
			mesh.SetUVs(0, uV);
			if (renderer.RendererMaterialMap.RenderBeforeDepthMask)
			{
				renderer.RendererMaterialMap.ReplaceOriginalMaterials(_materialBdm, setAsCurrent: true);
			}
			else if (renderer.RendererMaterialMap.HasTransparency)
			{
				renderer.RendererMaterialMap.ReplaceOriginalMaterials(_materialTransparency, setAsCurrent: true);
			}
			else
			{
				renderer.RendererMaterialMap.ReplaceOriginalMaterials(_material, setAsCurrent: true);
			}
			mesh.UploadMeshData(markNoLongerReadable: true);
		}

		private void SwitchToCombinedMesh(Mesh mesh, List<RendererInfo> renderers)
		{
			MeshFilter meshFilter = base.gameObject.AddComponent<MeshFilter>();
			MeshRenderer meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			meshFilter.mesh = mesh;
			meshRenderer.material = _material;
			Game.Instance.QualitySettings.Shadows.ConfigurePartRenderer(meshRenderer);
			Game.Instance.QualitySettings.Crafts.ConfigurePartRenderer(meshRenderer);
			CleanupCombinedRenderers(renderers);
			CombinedMeshFilter = meshFilter;
			CombinedMeshRenderer = meshRenderer;
		}

		private void UpdateMaterialPartData()
		{
			if ((ImageEffectsQualitySettings.ReEntryQuality)_reentryQuality != ImageEffectsQualitySettings.ReEntryQuality.Off)
			{
				float num = (Game.Instance.FlightScene.VaporTrailsVisible ? 1f : 0f);
				_partDataDirty = true;
				int count = _partScripts.Count;
				for (int i = 0; i < count; i++)
				{
					IPartScript partScript = _partScripts[i];
					_shaderPartData[i].y = partScript.ReEntryEffectStrength;
					_shaderPartData[i].z = partScript.VaporTrailStrength * num;
				}
			}
			if (!_partDataDirty)
			{
				return;
			}
			_materialPropertyBlock.SetFloat(ShaderPropertyIds.EmissiveOverride, _partGroupRenderer?.EmissiveOverride ?? (-1f));
			_materialPropertyBlock.SetFloat(ShaderPropertyIds.AlphaOverride, _partGroupRenderer?.AlphaOverride ?? (-1f));
			_materialPropertyBlock.SetVectorArray(ShaderPropertyIds.PartData, _shaderPartData);
			CombinedMeshRenderer?.SetPropertyBlock(_materialPropertyBlock);
			bool flag = false;
			int count2 = _partMaterialScripts.Count;
			for (int j = 0; j < count2; j++)
			{
				foreach (IRendererMaterialMap rendererMap in _partMaterialScripts[j].RendererMaps)
				{
					if (rendererMap == null)
					{
						continue;
					}
					if (rendererMap.HasDecal)
					{
						if (!flag)
						{
							_materialPropertyBlockDecals.SetVectorArray(ShaderPropertyIds.PartData, _shaderPartData);
							flag = true;
						}
						rendererMap.UpdateMaterialPropertyBlock(_materialPropertyBlockDecals);
						rendererMap.Renderer.SetPropertyBlock(_materialPropertyBlockDecals);
					}
					else
					{
						_materialPropertyBlock.SetFloat(ShaderPropertyIds.EmissiveOverride, rendererMap.EmissiveOverride);
						_materialPropertyBlock.SetFloat(ShaderPropertyIds.AlphaOverride, rendererMap.AlphaOverride);
						rendererMap.Renderer.SetPropertyBlock(_materialPropertyBlock);
					}
				}
			}
		}
	}
}
