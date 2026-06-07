using UnityEngine;

namespace UMA
{
	public abstract class UMAMeshCombiner : MonoBehaviour
	{
		public abstract void UpdateUMAMesh(bool updatedAtlas, UMAData umaData, int atlasResolution);

		public virtual void Preprocess(UMAData umaData)
		{
		}
	}
}
