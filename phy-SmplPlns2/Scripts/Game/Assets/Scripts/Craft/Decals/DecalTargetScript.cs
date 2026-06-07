using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Jundroo.Common.Utils;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Decals
{
	public class DecalTargetScript : MonoBehaviour
	{
		private static class Profile
		{
			public const string Prefix = "DecalTargetScript";

			public static readonly ProfilerMarker Initialize = new ProfilerMarker("DecalTargetScript.Initialize");

			public static readonly ProfilerMarker InitializeRenderer = new ProfilerMarker("DecalTargetScript.InitializeRenderer");

			public static readonly ProfilerMarker OnDecalAssigned = new ProfilerMarker("DecalTargetScript.OnDecalAssigned");

			public static readonly ProfilerMarker OnDecalUnassigned = new ProfilerMarker("DecalTargetScript.OnDecalUnassigned");

			public static readonly ProfilerMarker ReinitializeRenderers = new ProfilerMarker("DecalTargetScript.ReinitializeRenderers");
		}

		private bool _allocatedId;

		private bool _awakeExecuted;

		private CraftDecalManager _decalManager;

		private List<PartMeshDecalObject> _decalObjects;

		private List<ICraftDecal> _decals;

		private uint _decalTargetId;

		private bool _initialized;

		private PartScript _partScript;

		[SerializeField]
		private List<MeshRenderer> _renderers;

		private Transform _transform;

		[SerializeField]
		private bool _useSharedMesh;

		public IReadOnlyList<PartMeshDecalObject> DecalObjects => _decalObjects;

		public IReadOnlyList<ICraftDecal> Decals => _decals;

		public uint DecalTargetId
		{
			get
			{
				if (!_allocatedId)
				{
					AwakeIfNecessary();
					_decalTargetId = _decalManager.RequestDecalTargetID();
					_allocatedId = true;
				}
				return _decalTargetId;
			}
			private set
			{
				_decalTargetId = value;
				_allocatedId = true;
			}
		}

		public Matrix4x4? DecalToTargetMatrix { get; private set; }

		public PartScript PartScript => _partScript;

		public bool UseSharedMesh
		{
			get
			{
				return _useSharedMesh;
			}
			set
			{
				_useSharedMesh = value;
			}
		}

		public void AddRenderer(MeshRenderer renderer)
		{
			AwakeIfNecessary();
			if (_renderers.IndexOf(renderer) >= 0)
			{
				Debug.LogError("Attempted to add a renderer to a decal target but the renderer has already been added to the target", this);
				return;
			}
			_renderers.Add(renderer);
			if (_initialized)
			{
				InitializeRenderer(renderer);
			}
		}

		public void ClearRenderers()
		{
			_renderers.Clear();
		}

		public void Initialize(PartScript partScript)
		{
			_partScript = partScript;
			bool flag = partScript.LoadContext == CraftLoadContext.Designer;
			if (!flag && partScript.Part.Decals.Count == 0)
			{
				UnityEngine.Object.Destroy(this);
				return;
			}
			using (Profile.Initialize.Auto())
			{
				_initialized = true;
				AwakeIfNecessary();
				partScript.RegisterDecalTarget(this);
				if (!_allocatedId)
				{
					DecalTargetId = _decalManager.RequestDecalTargetID();
				}
				if (!flag)
				{
					Matrix4x4 targetToAncestorTransformMatrix = UnityTransformUtility.GetTargetToAncestorTransformMatrix(base.transform, partScript.transform);
					DecalToTargetMatrix = (partScript.PartToCraftOriginMatrix * targetToAncestorTransformMatrix).inverse;
				}
				foreach (MeshRenderer renderer in _renderers)
				{
					InitializeRenderer(renderer);
				}
				foreach (ICraftDecal decal in partScript.Part.Decals)
				{
					OnDecalAssigned(decal);
				}
			}
		}

		public void OnDecalAssigned(ICraftDecal decal)
		{
			using (Profile.OnDecalAssigned.Auto())
			{
				if (_decals.IndexOf(decal) != -1)
				{
					Debug.LogError("Attempted to assign a decal to a decal target but the decal is already assigned with the target", this);
					return;
				}
				if (decal.DecalType == CraftDecalType.Texture)
				{
					PartMeshDecalProjector partMeshDecalProjector = _decalManager.RequestDecalProjector((ICraftTextureDecal)decal, this);
					_decals.Add(decal);
					_decalObjects.Add(partMeshDecalProjector);
					partMeshDecalProjector.Transform.SetParent(_transform, worldPositionStays: false);
					partMeshDecalProjector.RefreshRenderer();
					return;
				}
				if (decal.DecalType == CraftDecalType.Text)
				{
					PartMeshDecalText partMeshDecalText = _decalManager.RequestDecalText((ICraftTextDecal)decal, this);
					_decals.Add(decal);
					_decalObjects.Add(partMeshDecalText);
					partMeshDecalText.Transform.SetParent(_transform, worldPositionStays: false);
					partMeshDecalText.RefreshRenderer();
					return;
				}
				throw new NotSupportedException($"Decal type of '{decal.DecalType}' is not yet supported");
			}
		}

		public void OnDecalUnassigned(ICraftDecal decal)
		{
			using (Profile.OnDecalUnassigned.Auto())
			{
				int num = _decals.IndexOf(decal);
				if (num < -1)
				{
					Debug.LogError("Attempted to unassign a decal from a decal target but the decal was not found on the target", this);
				}
				else
				{
					UnassignDecal(num);
				}
			}
		}

		public void ReinitializeRenderers()
		{
			using (Profile.ReinitializeRenderers.Auto())
			{
				foreach (MeshRenderer renderer in _renderers)
				{
					InitializeRenderer(renderer);
				}
			}
		}

		public void RemoveRenderer(MeshRenderer renderer)
		{
			if (!_renderers.Remove(renderer))
			{
				Debug.LogError("Attempted to remove a renderer from a decal target but the renderer was not found on the target", this);
			}
		}

		protected virtual void Awake()
		{
			AwakeIfNecessary();
		}

		protected virtual void OnDestroy()
		{
			if (_decals != null && _decals.Count > 0)
			{
				for (int num = _decals.Count - 1; num >= 0; num--)
				{
					UnassignDecal(num);
				}
			}
			if (_allocatedId && _decalTargetId != 0)
			{
				_decalManager.ReleaseDecalTargetID(_decalTargetId);
				_decalTargetId = 0u;
			}
			if (_initialized)
			{
				_partScript.UnregisterDecalTarget(this);
			}
		}

		protected virtual void Start()
		{
			if (!_initialized)
			{
				PartScript componentInParent = GetComponentInParent<PartScript>(includeInactive: true);
				Initialize(componentInParent);
			}
		}

		private void AwakeIfNecessary()
		{
			if (!_awakeExecuted)
			{
				_awakeExecuted = true;
				_decalManager = Game.Instance.CraftDecalManager;
				if (_renderers == null)
				{
					_renderers = new List<MeshRenderer>();
				}
				_decals = new List<ICraftDecal>();
				_decalObjects = new List<PartMeshDecalObject>();
				_transform = base.transform;
			}
		}

		private void InitializeRenderer(MeshRenderer renderer)
		{
			using (Profile.InitializeRenderer.Auto())
			{
				if (!renderer.TryGetComponent<MeshFilter>(out var component))
				{
					Debug.LogError("Unable to find mesh filter for decal target renderer '" + renderer.name + "'", renderer);
					return;
				}
				Mesh mesh = (_useSharedMesh ? component.sharedMesh : component.mesh);
				NativeArray<Vector3> nativeArray = new NativeArray<Vector3>(mesh.vertexCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(mesh);
				if (meshDataArray[0].HasVertexAttribute(VertexAttribute.TexCoord1))
				{
					meshDataArray[0].GetUVs(1, nativeArray);
				}
				float y = DecalLayers.DecalTargetIdToFloat(DecalTargetId);
				for (int i = 0; i < nativeArray.Length; i++)
				{
					nativeArray[i] = new Vector3(nativeArray[i].x, y, nativeArray[i].z);
				}
				mesh.SetUVs(1, nativeArray);
				meshDataArray.Dispose();
			}
		}

		private void UnassignDecal(int decalIndex)
		{
			ICraftDecal craftDecal = _decals[decalIndex];
			if (craftDecal.DecalType == CraftDecalType.Texture)
			{
				PartMeshDecalObject partMeshDecalObject = _decalObjects[decalIndex];
				if (craftDecal != partMeshDecalObject.Decal || !(partMeshDecalObject is PartMeshDecalProjector))
				{
					Debug.LogError("DecalTargetScript._decals is out of sync with DecalTargetScript._decalObjects. " + $"Unable to unassign decal at index {decalIndex}", this);
					return;
				}
				_decals.RemoveAt(decalIndex);
				_decalObjects.RemoveAt(decalIndex);
				_decalManager.ReleaseDecalProjector((PartMeshDecalProjector)partMeshDecalObject);
				return;
			}
			if (craftDecal.DecalType == CraftDecalType.Text)
			{
				PartMeshDecalObject partMeshDecalObject2 = _decalObjects[decalIndex];
				if (craftDecal != partMeshDecalObject2.Decal || !(partMeshDecalObject2 is PartMeshDecalText))
				{
					Debug.LogError("DecalTargetScript._decals is out of sync with DecalTargetScript._decalObjects. " + $"Unable to unassign decal at index {decalIndex}", this);
					return;
				}
				_decals.RemoveAt(decalIndex);
				_decalObjects.RemoveAt(decalIndex);
				_decalManager.ReleaseDecalText((PartMeshDecalText)partMeshDecalObject2);
				return;
			}
			throw new NotSupportedException($"Decal type of '{craftDecal.DecalType}' is not yet supported");
		}
	}
}
