using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class SkinnedCombinedObject : BaseCombinedObject, ICombinedObject<SkinnedCombinedObjectPart, SkinnedCombineSource>, ICombinedObject
	{
		private SkinnedCombinedMesh _combinedMesh;

		private List<SkinnedCombinedObjectPart> _parts;

		private HashSet<SkinnedCombinedObjectPart> _destroyPartsQueue;

		private HashSet<CombinedMeshPart> _destroyMeshPartsQueue;

		private bool _recalculateBounds;

		IReadOnlyList<ICombinedObjectPart> ICombinedObject.Parts => _parts;

		public IReadOnlyList<SkinnedCombinedObjectPart> Parts => _parts;

		public SkinnedMeshRenderer Renderer { get; private set; }

		public RendererSettings RendererSettings { get; private set; }

		public override Bounds Bounds => Renderer.bounds;

		public Bounds LocalBounds => Renderer.localBounds;

		public int VertexCount => _combinedMesh.Mesh.vertexCount;

		public int BonesCount => _combinedMesh.Bones.Count;

		public static SkinnedCombinedObject Create(RendererSettings settings)
		{
			return new GameObject("Skinned Combined Object").AddComponent<SkinnedCombinedObject>().Construct(settings);
		}

		private SkinnedCombinedObject Construct(RendererSettings settings)
		{
			_combinedMesh = new SkinnedCombinedMesh();
			_parts = new List<SkinnedCombinedObjectPart>();
			_destroyPartsQueue = new HashSet<SkinnedCombinedObjectPart>();
			_destroyMeshPartsQueue = new HashSet<CombinedMeshPart>();
			Renderer = CreateRenderer(settings);
			RendererSettings = settings;
			Renderer.sharedMesh = _combinedMesh.Mesh;
			Renderer.bones = _combinedMesh.Bones.ToArray();
			return this;
		}

		private void Update()
		{
			if (_destroyPartsQueue.Count > 0)
			{
				_combinedMesh.Cut(_destroyMeshPartsQueue.ToArray());
				foreach (SkinnedCombinedObjectPart item in _destroyPartsQueue)
				{
					_parts.Remove(item);
				}
				_destroyPartsQueue.Clear();
				_destroyMeshPartsQueue.Clear();
			}
			if (_recalculateBounds)
			{
				RecalculateBoundsImmediate();
			}
			base.enabled = false;
		}

		private void OnDestroy()
		{
			_combinedMesh.Dispose();
		}

		public void Combine(IEnumerable<ICombineSource> sources)
		{
			Combine(sources.Select((ICombineSource s) => (SkinnedCombineSource)sources));
		}

		public void Combine(IEnumerable<SkinnedCombineSource> sources)
		{
			if (_parts.Count == 0)
			{
				base.transform.position = GetAveragePosition(sources);
			}
			SkinnedMeshCombineInfo[] array = new SkinnedMeshCombineInfo[sources.Count()];
			int num = 0;
			foreach (SkinnedCombineSource source in sources)
			{
				array[num] = source.CombineInfo;
				num++;
			}
			try
			{
				CombinedMeshPart[] array2 = _combinedMesh.Combine(array);
				Renderer.bones = _combinedMesh.Bones.ToArray();
				num = 0;
				foreach (SkinnedCombineSource source2 in sources)
				{
					SkinnedCombinedObjectPart skinnedCombinedObjectPart = new SkinnedCombinedObjectPart(this, array2[num]);
					_parts.Add(skinnedCombinedObjectPart);
					source2.Combined(this, skinnedCombinedObjectPart);
					num++;
				}
			}
			catch (Exception ex)
			{
				string errorMessage = ex.Message + ex.StackTrace;
				foreach (SkinnedCombineSource source3 in sources)
				{
					source3.CombineError(this, errorMessage);
					source3.CombineFailed(this);
				}
			}
		}

		public void RecalculateBounds()
		{
			_recalculateBounds = true;
			base.enabled = true;
		}

		public void RecalculateBoundsImmediate()
		{
			List<Transform> bones = _combinedMesh.Bones;
			if (bones.Count == 0)
			{
				return;
			}
			int num = 0;
			Bounds localBounds = default(Bounds);
			for (int i = 0; i < bones.Count; i++)
			{
				if (bones[i] != null)
				{
					num = i + 1;
					localBounds = new Bounds(Renderer.transform.InverseTransformPoint(bones[i].position), Vector3.zero);
					break;
				}
			}
			if (num == bones.Count)
			{
				return;
			}
			for (int j = num; j < bones.Count; j++)
			{
				if (!(bones[j] == null))
				{
					localBounds.Encapsulate(Renderer.transform.InverseTransformPoint(bones[j].position));
				}
			}
			Renderer.localBounds = localBounds;
		}

		public void Destroy(SkinnedCombinedObjectPart destroyPart)
		{
			if (_parts.Contains(destroyPart))
			{
				_destroyPartsQueue.Add(destroyPart);
				_destroyMeshPartsQueue.Add(destroyPart.MeshPart);
				base.enabled = true;
			}
		}

		private SkinnedMeshRenderer CreateRenderer(RendererSettings settings)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = base.gameObject.AddComponent<SkinnedMeshRenderer>();
			settings.ApplyTo(skinnedMeshRenderer);
			return skinnedMeshRenderer;
		}

		private Vector3 GetAveragePosition(IEnumerable<ICombineSource> sources)
		{
			Vector3 zero = Vector3.zero;
			int num = 0;
			foreach (ICombineSource source in sources)
			{
				zero += source.Position;
				num++;
			}
			return zero / num;
		}
	}
}
