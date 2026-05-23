using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class CombinedObject : MonoBehaviour, ICombinedObject<CombinedObjectPart, CombineSource>, ICombinedObject
	{
		private CombinedMesh _combinedMesh;

		private CombinedMeshDataInternal _meshData;

		private List<CombinedObjectPart> _parts;

		private List<CombinedMeshPart> _destroyedMeshParts;

		private RendererSettings _rendererSettings;

		private bool _updating;

		IReadOnlyList<ICombinedObjectPart> ICombinedObject.Parts => _parts;

		public IReadOnlyList<CombinedObjectPart> Parts => _parts;

		public RendererSettings RendererSettings => _rendererSettings;

		public Bounds Bounds
		{
			get
			{
				Bounds localBounds = LocalBounds;
				localBounds.center += base.transform.position;
				return localBounds;
			}
		}

		public Bounds LocalBounds => _combinedMesh.MeshData.GetBounds();

		public int VertexCount => _combinedMesh.MeshData.VertexCount;

		public bool Updating
		{
			get
			{
				return _updating;
			}
			set
			{
				_updating = value;
				base.enabled = value;
			}
		}

		private void Update()
		{
			if (!Updating)
			{
				base.enabled = false;
				return;
			}
			ForceUpdate();
			base.enabled = false;
		}

		private void OnDestroy()
		{
			_combinedMesh.Dispose();
		}

		public static CombinedObject Create(MeshType meshType, CombineMethod combineType, RendererSettings settings)
		{
			return Create(new CombinedMeshFactory(meshType, combineType), settings);
		}

		public static CombinedObject Create(ICombinedMeshFactory factory, RendererSettings settings)
		{
			return Create(factory.CreateCombinedMesh(), settings);
		}

		public static CombinedObject Create(CombinedMesh combinedMesh, RendererSettings settings)
		{
			CombinedObject combinedObject = new GameObject("Combined Object").AddComponent<CombinedObject>();
			combinedObject.Construct(combinedMesh, settings);
			return combinedObject;
		}

		private void Construct(CombinedMesh combinedMesh, RendererSettings settings)
		{
			_combinedMesh = combinedMesh;
			_meshData = (CombinedMeshDataInternal)_combinedMesh.MeshData;
			_parts = new List<CombinedObjectPart>();
			_destroyedMeshParts = new List<CombinedMeshPart>();
			_rendererSettings = settings;
			_updating = true;
			if (combinedMesh.MeshData.PartsCount > 0)
			{
				foreach (CombinedMeshPart part in combinedMesh.MeshData.GetParts())
				{
					_parts.Add(new CombinedObjectPart(this, part));
				}
			}
			CreateMeshFilter(_combinedMesh.Mesh);
			CreateMeshRenderer(settings);
		}

		public void ForceUpdate()
		{
			if (_destroyedMeshParts.Count > 0)
			{
				_combinedMesh.Cut(_destroyedMeshParts);
				_destroyedMeshParts.Clear();
			}
		}

		public Bounds GetLocalBounds(CombinedObjectPart part)
		{
			return _meshData.GetBounds(part.MeshPart);
		}

		public Bounds GetBounds(CombinedObjectPart part)
		{
			Bounds localBounds = GetLocalBounds(part);
			localBounds.center += base.transform.position;
			return localBounds;
		}

		public void Combine(IEnumerable<ICombineSource> sources)
		{
			Combine(sources.Select((ICombineSource s) => (CombineSource)s));
		}

		public void Combine(IEnumerable<CombineSource> sources)
		{
			if (_parts.Count == 0)
			{
				base.transform.position = GetAveragePosition(sources);
			}
			Vector3 position = base.transform.position;
			int num = sources.Count();
			int num2 = 0;
			MeshCombineInfo[] array = new MeshCombineInfo[num];
			foreach (CombineSource source in sources)
			{
				MeshCombineInfo combineInfo = source.CombineInfo;
				combineInfo.transformMatrix = combineInfo.transformMatrix.SetTranslation(source.Position - position);
				array[num2++] = combineInfo;
			}
			try
			{
				CombinedMeshPart[] array2 = _combinedMesh.Combine(array);
				num2 = 0;
				foreach (CombineSource source2 in sources)
				{
					CombinedObjectPart combinedObjectPart = new CombinedObjectPart(this, array2[num2]);
					_parts.Add(combinedObjectPart);
					source2.Combined(this, combinedObjectPart);
					num2++;
				}
			}
			catch (Exception ex)
			{
				string errorMessage = ex.Message + ex.StackTrace;
				foreach (CombineSource source3 in sources)
				{
					source3.CombineError(this, errorMessage);
					source3.CombineFailed(this);
				}
			}
		}

		public void Destroy(CombinedObjectPart part)
		{
			if (_parts.Remove(part))
			{
				_destroyedMeshParts.Add(part.MeshPart);
				base.enabled = true;
			}
		}

		private void CreateMeshFilter(Mesh mesh)
		{
			base.gameObject.AddComponent<MeshFilter>().sharedMesh = mesh;
		}

		private void CreateMeshRenderer(RendererSettings settings)
		{
			MeshRenderer meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			meshRenderer.sharedMaterial = settings.material;
			meshRenderer.shadowCastingMode = settings.shadowMode;
			meshRenderer.receiveShadows = settings.receiveShadows;
			meshRenderer.lightmapIndex = settings.lightmapIndex;
			meshRenderer.realtimeLightmapIndex = settings.realtimeLightmapIndex;
			meshRenderer.tag = settings.tag;
			meshRenderer.gameObject.layer = settings.layer;
		}

		private Vector3 GetAveragePosition(IEnumerable<CombineSource> sources)
		{
			Vector3 zero = Vector3.zero;
			int num = 0;
			foreach (CombineSource source in sources)
			{
				zero += source.Position;
				num++;
			}
			return zero / num;
		}
	}
}
