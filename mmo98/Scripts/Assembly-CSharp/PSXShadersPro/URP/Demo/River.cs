using UnityEngine;

namespace PSXShadersPro.URP.Demo
{
	public class River : MonoBehaviour
	{
		[SerializeField]
		private float flowSpeed;

		[SerializeField]
		private MeshRenderer renderer;

		private Material material;

		private Vector2 startOffset;

		private void Start()
		{
			material = renderer.material;
			startOffset = material.GetTextureOffset("_BaseMap");
		}

		private void Update()
		{
			float y = Time.time * flowSpeed;
			Vector2 value = startOffset + new Vector2(0f, y);
			material.SetTextureOffset("_BaseMap", value);
		}
	}
}
