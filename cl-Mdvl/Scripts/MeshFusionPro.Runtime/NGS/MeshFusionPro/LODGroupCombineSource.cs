using System;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class LODGroupCombineSource : ICombineSource<CombinedLODGroup, CombinedLODGroupPart>, ICombineSource
	{
		private Bounds _bounds;

		private LODGroupSettings _settings;

		private CombineSource[][] _sources;

		public Vector3 Position { get; private set; }

		public Bounds Bounds => _bounds;

		public LODGroup LODGroup { get; private set; }

		public LODGroupSettings Settings => _settings;

		public CombineSource[][] BaseSources => _sources;

		public event Action<ICombinedObject, ICombinedObjectPart> onCombined;

		public event Action<ICombinedObject, string> onCombineError;

		public event Action<ICombinedObject> onCombineFailed;

		public event Action<CombinedLODGroup, CombinedLODGroupPart> onCombinedTyped;

		public event Action<CombinedLODGroup, string> onCombineErrorTyped;

		public event Action<CombinedLODGroup> onCombineFailedTyped;

		public LODGroupCombineSource(LODGroup group)
		{
			LODGroup = group;
			Position = group.transform.position;
			LOD[] lODs = group.GetLODs();
			_settings = new LODGroupSettings(group);
			_sources = new CombineSource[_settings.lodCount][];
			_bounds = new Bounds(group.localReferencePoint + Position, Vector3.zero);
			for (int i = 0; i < lODs.Length; i++)
			{
				Renderer[] renderers = lODs[i].renderers;
				CreateSourcesArray(i, renderers);
				FillSources(i, renderers);
			}
		}

		public void Combined(CombinedLODGroup root, CombinedLODGroupPart part)
		{
			this.onCombined?.Invoke(root, part);
			this.onCombinedTyped?.Invoke(root, part);
		}

		public void CombineError(CombinedLODGroup root, string errorMessage)
		{
			if (this.onCombineError == null && this.onCombineErrorTyped == null)
			{
				Debug.Log("Combine error occured : " + root.name + ", reason : " + errorMessage);
				return;
			}
			this.onCombineError?.Invoke(root, errorMessage);
			this.onCombineErrorTyped?.Invoke(root, errorMessage);
		}

		public void CombineFailed(CombinedLODGroup root)
		{
			this.onCombineFailed?.Invoke(root);
			this.onCombineFailedTyped?.Invoke(root);
		}

		private void CreateSourcesArray(int level, Renderer[] renderers)
		{
			int num = 0;
			for (int i = 0; i < renderers.Length; i++)
			{
				Renderer renderer = renderers[i];
				if (!(renderer == null) && renderer is MeshRenderer)
				{
					MeshFilter component = renderer.GetComponent<MeshFilter>();
					if (!(component == null) && !(component.sharedMesh == null))
					{
						num += renderers[i].sharedMaterials.Length;
					}
				}
			}
			_sources[level] = new CombineSource[num];
		}

		private void FillSources(int level, Renderer[] renderers)
		{
			int num = 0;
			foreach (Renderer renderer in renderers)
			{
				if (renderer == null || !(renderer is MeshRenderer))
				{
					continue;
				}
				MeshFilter component = renderer.GetComponent<MeshFilter>();
				if (!(component == null) && !(component.sharedMesh == null))
				{
					Mesh sharedMesh = renderer.GetComponent<MeshFilter>().sharedMesh;
					for (int j = 0; j < sharedMesh.subMeshCount; j++)
					{
						_sources[level][num] = new CombineSource(sharedMesh, (MeshRenderer)renderer, j);
						num++;
					}
					_bounds.Encapsulate(renderer.bounds);
				}
			}
		}
	}
}
