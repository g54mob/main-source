using UnityEngine;

namespace Utilities
{
	[RequireComponent(typeof(Renderer))]
	public class MaterialAutoTiling : MonoBehaviour
	{
		private Renderer rend;

		private Vector3 lastScale;

		private void Start()
		{
			rend = GetComponent<Renderer>();
			lastScale = base.transform.localScale;
			UpdateTiling();
		}

		private void Update()
		{
			if (base.transform.localScale != lastScale)
			{
				UpdateTiling();
				lastScale = base.transform.localScale;
			}
		}

		private void UpdateTiling()
		{
			Vector3 localScale = base.transform.localScale;
			rend.material.mainTextureScale = new Vector2(localScale.x, localScale.z);
		}
	}
}
