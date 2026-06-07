using UnityEngine;

namespace RLD
{
	public static class RTMeshCompiler
	{
		public static void CompileEntireScene()
		{
			GameObject[] sceneObjects = MonoSingleton<RTScene>.Get.GetSceneObjects();
			for (int i = 0; i < sceneObjects.Length; i++)
			{
				CompileForObject(sceneObjects[i]);
			}
		}

		public static bool CompileForObject(GameObject gameObject)
		{
			if (gameObject.isStatic)
			{
				return false;
			}
			Mesh mesh = gameObject.GetMesh();
			if (mesh == null)
			{
				return false;
			}
			RTMesh rTMesh = Singleton<RTMeshDb>.Get.GetRTMesh(mesh);
			if (rTMesh == null)
			{
				return false;
			}
			if (!rTMesh.IsTreeBuilt)
			{
				rTMesh.BuildTree();
			}
			return true;
		}
	}
}
