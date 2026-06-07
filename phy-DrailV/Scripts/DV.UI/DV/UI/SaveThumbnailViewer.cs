using DV.Common;
using DV.UIFramework;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI
{
	public class SaveThumbnailViewer : NullCheckingUIBehaviour
	{
		[Header("UI elements")]
		[NullCheck]
		public RawImage mainImage;

		private bool flipped;

		private ISaveGame shownSave;

		protected override void Awake()
		{
			base.Awake();
			if (mainImage.texture == null)
			{
				Hide();
			}
		}

		public void Show(ISaveGame save)
		{
			if (save == null)
			{
				Hide();
				return;
			}
			if (!save.IsThumbnailLoaded)
			{
				save.LoadThumbnail();
			}
			if (save.Thumbnail == null)
			{
				Hide();
				return;
			}
			Show(save.Thumbnail, flipped: false, save != shownSave);
			shownSave = save;
		}

		public void Show(Texture tex, bool flipped = false, bool unloadSave = true)
		{
			if (tex != null)
			{
				if (unloadSave)
				{
					UnloadSaveThumbnail();
				}
				mainImage.texture = tex;
				base.gameObject.SetActive(value: true);
				this.flipped = flipped;
				UpdateCrop();
			}
			else
			{
				Hide();
			}
		}

		private void UpdateCrop()
		{
			float num = mainImage.rectTransform.rect.width / mainImage.rectTransform.rect.height;
			float num2 = (float)mainImage.texture.width / (float)mainImage.texture.height;
			Rect uvRect;
			if (num > num2)
			{
				float num3 = num2 / num;
				float num4 = (1f - num3) * 0.5f;
				uvRect = new Rect(0f, num4, 1f, 1f - num4 * 2f);
			}
			else
			{
				float num5 = num / num2;
				float num6 = (1f - num5) * 0.5f;
				uvRect = new Rect(num6, 0f, 1f - num6 * 2f, 1f);
			}
			if (flipped)
			{
				float yMin = uvRect.yMin;
				float yMax = uvRect.yMax;
				float num7 = (uvRect.yMax = yMin);
				num7 = (uvRect.yMin = yMax);
			}
			mainImage.uvRect = uvRect;
		}

		protected override void OnRectTransformDimensionsChange()
		{
			if (mainImage.texture != null)
			{
				UpdateCrop();
			}
		}

		public void Hide()
		{
			UnloadSaveThumbnail();
			mainImage.texture = null;
			base.gameObject.SetActive(value: false);
		}

		private void UnloadSaveThumbnail()
		{
			if (shownSave != null)
			{
				shownSave.UnloadThumbnail();
				shownSave = null;
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			mainImage.texture = null;
			UnloadSaveThumbnail();
		}
	}
}
