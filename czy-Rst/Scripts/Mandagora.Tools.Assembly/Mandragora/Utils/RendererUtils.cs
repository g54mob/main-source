using UnityEngine;

namespace Mandragora.Utils
{
	public class RendererUtils
	{
		public static void changeChildRenderersVisibility(GameObject targetObject, bool isVisible, bool isIncludeOwnObject = true)
		{
			Renderer[] components = targetObject.GetComponents<Renderer>();
			foreach (Renderer renderer in components)
			{
				renderer.enabled = isVisible || renderer.tag == "not_hidden";
			}
			components = targetObject.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer2 in components)
			{
				renderer2.enabled = isVisible || renderer2.tag == "not_hidden";
			}
		}
	}
}
