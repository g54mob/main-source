using UnityEngine;

namespace CTS
{
	public class RenderTargetAsTexture : MonoBehaviour
	{
		[SerializeField]
		private string _textureName = "NewTexture";

		[SerializeField]
		private int _number;

		private static Texture2D ToTexture2D(RenderTexture rTex)
		{
			Texture2D texture2D = new Texture2D(rTex.width, rTex.height, TextureFormat.ARGB32, mipChain: false);
			RenderTexture.active = rTex;
			texture2D.ReadPixels(new Rect(0f, 0f, rTex.width, rTex.height), 0, 0);
			texture2D.Apply();
			return texture2D;
		}
	}
}
