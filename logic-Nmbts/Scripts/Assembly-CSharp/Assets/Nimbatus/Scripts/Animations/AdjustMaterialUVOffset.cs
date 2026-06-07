using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class AdjustMaterialUVOffset : MonoBehaviour
	{
		private Renderer rend;

		public Vector2 scrollSpeed;

		private Vector2 offset;

		private void Start()
		{
			rend = GetComponent<Renderer>();
		}

		private void Update()
		{
			offset += scrollSpeed * Time.deltaTime;
			rend.material.SetTextureOffset("_MainTex", offset);
		}
	}
}
