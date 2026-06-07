using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public abstract class StaticTextureRenderBase : BookletTextureRender
	{
		[Header("Path and naming")]
		[Tooltip("Destination path must exist and it's relative to the project (Assets/...")]
		public string destinationPath = "Assets";

		public string texturesBaseName = "generated_tex";

		public bool writeToFile;

		[InspectorButton("GenerateStaticPagesTextures", true, true)]
		public bool generateStaticPagesTexturesDebug;

		public void GenerateStaticPagesTextures()
		{
			TemplatePaperData[] staticTemplatePaperData = GetStaticTemplatePaperData();
			if (staticTemplatePaperData != null && staticTemplatePaperData.Length != 0)
			{
				GenerateTextures(staticTemplatePaperData);
				if (writeToFile)
				{
					base.TexturesGenerated += OnTexturesGenerated;
				}
			}
		}

		protected abstract TemplatePaperData[] GetStaticTemplatePaperData();

		public static byte[] EncodeGenericTextureToPNG(Texture texture)
		{
			if (texture is Texture2D)
			{
				return (texture as Texture2D).EncodeToPNG();
			}
			if (texture is RenderTexture)
			{
				RenderTexture renderTexture = texture as RenderTexture;
				bool flag = false;
				if (renderTexture.format != RenderTextureFormat.ARGB32)
				{
					RenderTexture temporary = RenderTexture.GetTemporary(renderTexture.width, renderTexture.height, 0, RenderTextureFormat.ARGB32);
					Graphics.Blit(renderTexture, temporary);
					renderTexture = temporary;
					flag = true;
				}
				RenderTexture.active = renderTexture;
				Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height);
				texture2D.ReadPixels(new Rect(0f, 0f, texture2D.width, texture2D.height), 0, 0);
				RenderTexture.active = null;
				byte[] result = texture2D.EncodeToPNG();
				Object.Destroy(texture2D);
				if (flag)
				{
					renderTexture.Release();
				}
				return result;
			}
			return null;
		}

		private void OnTexturesGenerated(Texture[] generatedTextures, BookletTextureRender _)
		{
			base.TexturesGenerated -= OnTexturesGenerated;
		}
	}
}
