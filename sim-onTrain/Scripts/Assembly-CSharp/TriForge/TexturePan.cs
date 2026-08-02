using UnityEngine;

namespace TriForge
{
	public class TexturePan : MonoBehaviour
	{
		public float scrollSpeed = 1f;

		private Renderer rend;

		private void Start()
		{
			rend = GetComponent<Renderer>();
		}

		private void Update()
		{
			float y = Time.time * scrollSpeed;
			rend.material.mainTextureOffset = new Vector2(0f, y);
		}
	}
}
