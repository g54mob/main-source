using UnityEngine;

namespace ToonyColorsPro.Demo
{
	public class TCP2_Demo_Interactive_Environment : MonoBehaviour
	{
		public Material skybox;

		public void ApplyEnvironment()
		{
			TCP2_Demo_Interactive_Environment[] componentsInChildren = base.transform.parent.GetComponentsInChildren<TCP2_Demo_Interactive_Environment>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].gameObject.SetActive(value: false);
			}
			base.gameObject.SetActive(value: true);
			RenderSettings.skybox = skybox;
			RenderSettings.customReflection = (Cubemap)skybox.GetTexture("_Tex");
			if (Application.isPlaying)
			{
				DynamicGI.UpdateEnvironment();
			}
		}
	}
}
