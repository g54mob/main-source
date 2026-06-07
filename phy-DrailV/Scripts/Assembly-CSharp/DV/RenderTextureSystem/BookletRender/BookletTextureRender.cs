using System;
using DV.Utils;
using UnityEngine;

namespace DV.RenderTextureSystem.BookletRender
{
	public abstract class BookletTextureRender : MonoBehaviour, IRenderJob
	{
		[Header("Render texture tweaking")]
		public float camSize = 783.7719f;

		public Vector2Int texSize = new Vector2Int(1220, 1580);

		public float mipMapBias = -0.7f;

		protected Texture[] outputTextures;

		protected int currentPage;

		private TemplatePaperData[] templatePaperData;

		private bool busy;

		private bool requestedRenderCancel;

		private float timeStart;

		public bool NeedsAlpha => false;

		public event Action<Texture[], BookletTextureRender> TexturesGenerated;

		public void GenerateTextures(TemplatePaperData[] templatePaperData)
		{
			if (busy)
			{
				Debug.LogError("Already busy generating booklet textures, can't generate new textures!", this);
			}
			timeStart = Time.realtimeSinceStartup;
			DisableTemplatePapers();
			busy = true;
			this.templatePaperData = templatePaperData;
			Texture[] array = new RenderTexture[templatePaperData.Length];
			outputTextures = array;
			currentPage = 0;
			ScheduleJob();
		}

		public Vector2Int GetTargetTextureSize()
		{
			return texSize;
		}

		public float GetMipMapBias()
		{
			return mipMapBias;
		}

		public float Prepare(Vector3 suggestedPosition, Quaternion suggestedRotation)
		{
			base.transform.SetPositionAndRotation(suggestedPosition, suggestedRotation);
			TemplatePaperDataFill(templatePaperData[currentPage]);
			return camSize;
		}

		public void RequestRenderCancel()
		{
			requestedRenderCancel = true;
		}

		public void OnRenderCompleted(Texture render)
		{
			DisableTemplatePapers();
			outputTextures[currentPage] = render;
			currentPage++;
			if (requestedRenderCancel)
			{
				for (int i = 0; i < currentPage; i++)
				{
					UnityEngine.Object.Destroy(outputTextures[i]);
				}
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			if (currentPage < templatePaperData.Length)
			{
				ScheduleJob();
			}
			else
			{
				try
				{
					this.TexturesGenerated?.Invoke(outputTextures, this);
				}
				catch (Exception ex)
				{
					Debug.LogError("Exception thrown in TexturesGenerated event: " + ex.Message);
					Debug.LogException(ex);
				}
				UnityEngine.Object.Destroy(base.gameObject);
				currentPage = 0;
				busy = false;
			}
			TemplatePapersCleanUp();
		}

		private void ScheduleJob()
		{
			SingletonBehaviour<RenderTextureSystem>.Instance.AddRenderJob(this);
		}

		protected abstract void TemplatePapersCleanUp();

		protected abstract void TemplatePaperDataFill(TemplatePaperData templateData);

		protected abstract void DisableTemplatePapers();
	}
}
