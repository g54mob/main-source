using UnityEngine;

namespace JetFistGames.RetroTVFX
{
	[ExecuteInEditMode]
	public class LoResEffect : MonoBehaviour
	{
		public int ScreenResX = 320;

		public int ScreenResY = 240;

		public bool PointFilter = true;

		public bool OverrideAspect;

		public float CamAspect = 1f;

		public Camera MainCam;

		public Camera[] CamArray;

		private RenderTexture tempTex;

		private void OnDestroy()
		{
			cleanupTempTex();
		}

		private void cleanupTempTex()
		{
			if (tempTex != null)
			{
				if (Application.isPlaying)
				{
					Object.Destroy(tempTex);
				}
				else
				{
					Object.DestroyImmediate(tempTex);
				}
			}
		}

		private void createTempTex(int depth, RenderTextureFormat format)
		{
			cleanupTempTex();
			tempTex = new RenderTexture(ScreenResX, ScreenResY, depth, format);
		}

		private void OnRenderImage(RenderTexture src, RenderTexture dest)
		{
			if (MainCam == null)
			{
				Graphics.Blit(src, dest);
				return;
			}
			if (tempTex == null || tempTex.width != ScreenResX || tempTex.height != ScreenResY)
			{
				createTempTex(src.depth, src.format);
			}
			float num = (float)ScreenResX / (float)ScreenResY;
			float aspect = (OverrideAspect ? CamAspect : num);
			tempTex.filterMode = ((!PointFilter) ? FilterMode.Bilinear : FilterMode.Point);
			MainCam.aspect = aspect;
			MainCam.targetTexture = tempTex;
			MainCam.Render();
			if (CamArray != null)
			{
				for (int i = 0; i < CamArray.Length; i++)
				{
					CamArray[i].aspect = aspect;
					CamArray[i].targetTexture = tempTex;
					CamArray[i].Render();
				}
			}
			Graphics.Blit(tempTex, dest);
		}
	}
}
