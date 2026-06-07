using UnityEngine;
using UnityEngine.UI;

namespace Shaders
{
	public class HighlightShader : MonoBehaviour
	{
		private void Start()
		{
			Image component = GetComponent<Image>();
			if (component != null && component.material != null)
			{
				component.material.SetColor("_LineColor", component.color);
			}
		}
	}
}
