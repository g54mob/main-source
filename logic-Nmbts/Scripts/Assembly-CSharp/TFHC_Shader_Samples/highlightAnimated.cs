using UnityEngine;

namespace TFHC_Shader_Samples
{
	public class highlightAnimated : MonoBehaviour
	{
		private Material mat;

		private void Start()
		{
			mat = GetComponent<Renderer>().material;
		}

		private void OnMouseEnter()
		{
			switchhighlighted(true);
		}

		private void OnMouseExit()
		{
			switchhighlighted(false);
		}

		private void switchhighlighted(bool highlighted)
		{
			mat.SetFloat("_Highlighted", highlighted ? 1f : 0f);
		}
	}
}
