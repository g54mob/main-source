using UnityEngine;

namespace CW.Common
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(1000)]
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwRenderTextureManager")]
	[AddComponentMenu("Common/CW Render Texture Manager")]
	public class CwRenderTextureManager : MonoBehaviour
	{
		[SerializeField]
		private int lifetime;

		public int Lifetime
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static RenderTexture GetTemporary(RenderTextureDescriptor desc, string title)
		{
			return null;
		}

		public static RenderTexture ReleaseTemporary(RenderTexture renderTexture)
		{
			return null;
		}
	}
}
