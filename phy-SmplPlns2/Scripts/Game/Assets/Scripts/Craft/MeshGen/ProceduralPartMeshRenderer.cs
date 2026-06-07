using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Bindings.Manifold;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.MeshGen
{
	public class ProceduralPartMeshRenderer : IDisposable
	{
		private readonly DecalTargetScript _decalTargetScript;

		private readonly MeshFilter _filter;

		private readonly List<float3> _levelToUV;

		private readonly CraftLoadContext _loadContext;

		private readonly bool _makeSubmeshes;

		private readonly Mesh _mesh;

		private readonly PartData _part;

		private readonly PartScript _partScript;

		private readonly MeshRenderer _renderer;

		private readonly TransparencyScript _transparencyScript;

		private PartMaterialScript.RendererMaterialMap _materialMap;

		private bool _rendererAdded;

		private bool _rendererAddedToDecalTarget;

		private bool _enableTransparency;

		private int[] _submeshToLevel;

		public bool ExcludeFromCombine { get; set; }

		public bool ExcludeFromDrag { get; set; }

		public DecalTargetScript DecalTargetScript => _decalTargetScript;

		public bool EnableTransparency
		{
			get
			{
				return _enableTransparency;
			}
			set
			{
				if (_enableTransparency != value)
				{
					_enableTransparency = value;
					if (!value)
					{
						AddRenderer(force: true);
						_renderer.shadowCastingMode = ShadowCastingMode.On;
					}
					else if (_transparencyScript != null)
					{
						_transparencyScript.Renderer = MeshRenderer;
						_transparencyScript.AssignMaterials();
						_renderer.shadowCastingMode = ShadowCastingMode.Off;
					}
				}
			}
		}

		public Mesh Mesh => _mesh;

		public MeshRenderer MeshRenderer => _renderer;

		public Transform Transform => _renderer.transform;

		public ProceduralPartMeshRenderer(PartScript partScript, string name, CraftLoadContext loadContext, bool makeSubmeshes = true, Transform parentOverride = null, DecalTargetScript decalTargetOverride = null, bool excludeFromCombine = false, bool excludeFromDrag = false)
		{
			_partScript = partScript;
			_part = partScript.Part;
			_levelToUV = new List<float3>();
			_loadContext = loadContext;
			ExcludeFromCombine = excludeFromCombine;
			ExcludeFromDrag = excludeFromDrag;
			_transparencyScript = partScript.GetModifier<TransparencyScript>();
			Transform transform = parentOverride;
			if (transform == null)
			{
				transform = partScript.transform;
			}
			GameObject gameObject = new GameObject(name + "-Renderer");
			gameObject.transform.SetParent(transform, worldPositionStays: false);
			gameObject.transform.SetLocalPositionAndRotation(default(Vector3), Quaternion.identity);
			gameObject.transform.localScale = Vector3.one;
			_mesh = new Mesh
			{
				name = name
			};
			_filter = gameObject.AddComponent<MeshFilter>();
			_filter.sharedMesh = _mesh;
			_renderer = gameObject.AddComponent<MeshRenderer>();
			_makeSubmeshes = makeSubmeshes;
			if (decalTargetOverride != null)
			{
				_decalTargetScript = decalTargetOverride;
				if (!decalTargetOverride.UseSharedMesh)
				{
					Debug.LogWarning($"decalTargetOverride {decalTargetOverride} provided to ProceduralPartMeshRenderer, with UseSharedMesh = false. Leaked meshes may ensue");
				}
			}
			else
			{
				_decalTargetScript = gameObject.AddComponent<DecalTargetScript>();
				_decalTargetScript.UseSharedMesh = true;
			}
			_decalTargetScript.AddRenderer(_renderer);
			_rendererAddedToDecalTarget = true;
		}

		public void Destroy()
		{
			if (_rendererAdded)
			{
				_partScript.PartMaterialScript.RemoveRenderer(_renderer);
				_rendererAdded = false;
			}
			if (_rendererAddedToDecalTarget)
			{
				if (_decalTargetScript != null)
				{
					_decalTargetScript.RemoveRenderer(_renderer);
				}
				_rendererAddedToDecalTarget = false;
			}
			UnityEngine.Object.Destroy(_renderer.gameObject);
			UnityEngine.Object.Destroy(_mesh);
		}

		public void Dispose()
		{
			UnityEngine.Object.Destroy(_mesh);
		}

		public void UpdateMesh(NativeMesh meshBuilder, bool calculateNormals = false)
		{
			PreUpdateMesh();
			meshBuilder.WriteToPartMeshData(_mesh, _levelToUV, _levelToUV[0], out var submeshToLevel, _makeSubmeshes);
			PostUpdateMesh(submeshToLevel, calculateNormals);
		}

		public void UpdateMesh(Manifold<Vertex> manifold, bool calculateNormals = false)
		{
			PreUpdateMesh();
			ManifoldUtils.ConvertManifoldToPartMesh(manifold, _mesh, _levelToUV, _levelToUV[0], out var submeshToLevel, _makeSubmeshes);
			PostUpdateMesh(submeshToLevel, calculateNormals);
		}

		private void PostUpdateMesh(int[] submeshToLevel, bool calculateNormals)
		{
			if (_mesh.subMeshCount == 0)
			{
				RemoveRenderer();
				_renderer.enabled = false;
				_submeshToLevel = null;
				return;
			}
			bool flag = _submeshToLevel == null || !submeshToLevel.SequenceEqual(_submeshToLevel);
			_submeshToLevel = submeshToLevel;
			if (calculateNormals)
			{
				_mesh.RecalculateNormals();
			}
			int num = -1;
			for (int i = 0; i < submeshToLevel.Length; i++)
			{
				num = math.max(num, submeshToLevel[i]);
			}
			int num2 = num + 1;
			List<int> materialIds = _part.MaterialIds;
			int item = materialIds[0];
			while (materialIds.Count < num2)
			{
				materialIds.Add(item);
			}
			if (materialIds.Count == 64 && num2 < 64)
			{
				materialIds.RemoveRange(num2, 64 - num2);
			}
			PartMaterialScript partMaterialScript = _partScript.PartMaterialScript;
			bool force = flag || (_makeSubmeshes && _renderer.sharedMaterials.Length != submeshToLevel.Length);
			AddRenderer(force);
			if (_loadContext == CraftLoadContext.Designer)
			{
				partMaterialScript.OnMeshChanged();
			}
			if (_transparencyScript != null && EnableTransparency)
			{
				_transparencyScript.AssignMaterials();
			}
			if (_rendererAddedToDecalTarget)
			{
				_decalTargetScript.RemoveRenderer(_renderer);
			}
			_decalTargetScript.AddRenderer(_renderer);
			_rendererAddedToDecalTarget = true;
		}

		private void RemoveRenderer()
		{
			PartMaterialScript partMaterialScript = _partScript.PartMaterialScript;
			if (_rendererAdded)
			{
				partMaterialScript.RemoveRenderer(_renderer);
			}
		}

		private void AddRenderer(bool force = false)
		{
			PartMaterialScript partMaterialScript = _partScript.PartMaterialScript;
			if (_rendererAdded)
			{
				if (!force)
				{
					return;
				}
				partMaterialScript.RemoveRenderer(_renderer);
			}
			if (_makeSubmeshes)
			{
				_renderer.sharedMaterials = new Material[_submeshToLevel.Length];
			}
			_materialMap = partMaterialScript.AddRenderer(_renderer, null, null, _makeSubmeshes ? _submeshToLevel : null, ExcludeFromCombine, ExcludeFromDrag);
			_materialMap.MeshIsUnique = true;
			_rendererAdded = true;
		}

		private void PreUpdateMesh()
		{
			List<float3> levelToUV = _levelToUV;
			List<int> materialIds = _part.MaterialIds;
			for (int i = levelToUV.Count; i < materialIds.Count; i++)
			{
				levelToUV.Add(0f);
			}
			if (levelToUV.Count == 0)
			{
				levelToUV.Add(0f);
			}
			float2 yz = math.float2(DecalLayers.DecalTargetIdToFloat(_decalTargetScript.DecalTargetId), _part.Id);
			for (int j = 0; j < levelToUV.Count; j++)
			{
				levelToUV[j] = math.float3((j < materialIds.Count) ? materialIds[j] : 0, yz);
			}
		}
	}
}
