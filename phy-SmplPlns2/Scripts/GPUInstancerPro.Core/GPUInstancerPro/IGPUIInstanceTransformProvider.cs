using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

namespace GPUInstancerPro
{
	public interface IGPUIInstanceTransformProvider
	{
		int GetPrefabID(GameObject prefabObject);

		NativeArray<Matrix4x4> GetTransformMatrix(int prefabID);

		void SetTransformMatrixModified(int prefabID);

		TransformAccessArray GetTransformAccessArray(int prefabID);

		Transform[] GetInstanceTransforms(int prefabID);

		Transform GetInstanceTransform(int prefabID, int bufferIndex);

		Transform GetInstanceTransformWithRenderKey(int renderKey, int bufferIndex);

		int GetInstanceCount(int prefabID);
	}
}
