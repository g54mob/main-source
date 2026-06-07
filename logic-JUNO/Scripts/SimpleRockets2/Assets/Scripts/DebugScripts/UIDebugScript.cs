using ModApi;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.DebugScripts
{
	public class UIDebugScript : MonoBehaviour
	{
		[ContextMenu("Count Images")]
		public void CountImages()
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			foreach (GameObject rootGameObject in Utilities.GetRootGameObjects())
			{
				Image[] componentsInChildren = rootGameObject.GetComponentsInChildren<Image>(includeInactive: true);
				foreach (Image image in componentsInChildren)
				{
					num4++;
					CanvasRenderer component = image.GetComponent<CanvasRenderer>();
					if (!(component != null))
					{
						continue;
					}
					if (image.gameObject.activeInHierarchy)
					{
						num3++;
					}
					if (!component.cullTransparentMesh || image.color.a > 0f)
					{
						num5++;
						RectTransform component2 = image.GetComponent<RectTransform>();
						if (component2.rect.width > 0f && component2.rect.height > 0f)
						{
							num2 += component2.rect.width * component2.rect.height;
						}
						num += component2.sizeDelta.x * component2.sizeDelta.y;
					}
				}
			}
			Debug.Log(string.Format("Results: {0} images, {1} non-culled images, {2} visible images, {3} pixels squared (size delta), {4} pixels squared", num4, num5, num3, num.ToString("n0"), num2.ToString("n0")));
		}
	}
}
