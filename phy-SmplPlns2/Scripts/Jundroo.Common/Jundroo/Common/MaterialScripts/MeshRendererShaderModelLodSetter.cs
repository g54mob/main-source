using UnityEngine;

namespace Jundroo.Common.MaterialScripts
{
	public class MeshRendererShaderModelLodSetter : MonoBehaviour
	{
		[SerializeField]
		private int _defaultLod = 100;

		[SerializeField]
		private int _shaderModel2Lod = 100;

		[SerializeField]
		private int _shaderModel3Lod = 200;

		[SerializeField]
		private bool _useSharedMesh = true;

		protected virtual void Awake()
		{
			int graphicsShaderLevel = SystemInfo.graphicsShaderLevel;
			int maximumLOD = _defaultLod;
			if (graphicsShaderLevel >= 30)
			{
				maximumLOD = _shaderModel3Lod;
			}
			else if (graphicsShaderLevel >= 20)
			{
				maximumLOD = _shaderModel2Lod;
			}
			MeshRenderer component = GetComponent<MeshRenderer>();
			Material[] array = (_useSharedMesh ? component.sharedMaterials : component.materials);
			for (int i = 0; i < array.Length; i++)
			{
				array[i].shader.maximumLOD = maximumLOD;
			}
		}
	}
}
