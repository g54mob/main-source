using System;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class SkinnedCombineSource : ICombineSource<SkinnedCombinedObject, SkinnedCombinedObjectPart>, ICombineSource
	{
		public Vector3 Position { get; private set; }

		public Bounds Bounds { get; private set; }

		public SkinnedMeshCombineInfo CombineInfo { get; private set; }

		public RendererSettings RendererSettings { get; private set; }

		public event Action<ICombinedObject, ICombinedObjectPart> onCombined;

		public event Action<ICombinedObject, string> onCombineError;

		public event Action<ICombinedObject> onCombineFailed;

		public event Action<SkinnedCombinedObject, SkinnedCombinedObjectPart> onCombinedTyped;

		public event Action<SkinnedCombinedObject, string> onCombineErrorTyped;

		public event Action<SkinnedCombinedObject> onCombineFailedTyped;

		public SkinnedCombineSource(SkinnedMeshRenderer renderer, int submeshIndex)
		{
			if (renderer == null)
			{
				throw new ArgumentNullException("SkinnedMeshRenderer is null");
			}
			Mesh sharedMesh = renderer.sharedMesh;
			if (sharedMesh == null)
			{
				throw new ArgumentNullException("Mesh is null");
			}
			if (submeshIndex >= sharedMesh.subMeshCount)
			{
				throw new ArgumentException("'submeshIndex' is greater then submeshes count");
			}
			if (submeshIndex >= renderer.GetMaterialsCount())
			{
				throw new ArgumentException("'submeshIndex' is greater then materials count");
			}
			SkinnedMeshCombineInfo combineInfo = new SkinnedMeshCombineInfo(renderer, submeshIndex);
			RendererSettings rendererSettings = new RendererSettings(renderer, submeshIndex);
			CombineInfo = combineInfo;
			RendererSettings = rendererSettings;
			Position = renderer.transform.position;
			Bounds = renderer.bounds;
		}

		public void Combined(SkinnedCombinedObject root, SkinnedCombinedObjectPart part)
		{
			this.onCombined?.Invoke(root, part);
			this.onCombinedTyped?.Invoke(root, part);
		}

		public void CombineError(SkinnedCombinedObject root, string errorMessage)
		{
			if (this.onCombineError == null && this.onCombinedTyped == null)
			{
				Debug.Log("Error during combine " + root.name + ", reason :" + errorMessage);
				return;
			}
			this.onCombineError?.Invoke(root, errorMessage);
			this.onCombineErrorTyped?.Invoke(root, errorMessage);
		}

		public void CombineFailed(SkinnedCombinedObject root)
		{
			this.onCombineFailed?.Invoke(root);
			this.onCombineFailedTyped?.Invoke(root);
		}
	}
}
