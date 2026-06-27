using System.Collections;
using Helpers.Ranges;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters
{
	public class GUI_InternetSlowImageLoader : MonoBehaviour
	{
		[SerializeField]
		private RectTransform maskTransform;

		[SerializeField]
		private RectTransform targetImageTransform;

		[SerializeField]
		private Image targetImage;

		[SerializeField]
		private float loadedLinesShowSpeed = 1f;

		private Coroutine imageShowingCoroutine;

		private void OnDisable()
		{
			StopImageLoadingAnimation();
		}

		public void StartImageLoadingAnimation(Sprite image, IntRange initialChunkSizeRange, IntRange chunkSizeRange, FloatRange delayBetweenChunksRange)
		{
			if (imageShowingCoroutine != null)
			{
				StopCoroutine(imageShowingCoroutine);
			}
			targetImage.sprite = image;
			imageShowingCoroutine = StartCoroutine(ImageShowingCoroutine(initialChunkSizeRange, chunkSizeRange, delayBetweenChunksRange));
		}

		public void StopImageLoadingAnimation()
		{
			if (imageShowingCoroutine != null)
			{
				StopCoroutine(imageShowingCoroutine);
				imageShowingCoroutine = null;
			}
		}

		private IEnumerator ImageShowingCoroutine(IntRange initialChunkSizeRange, IntRange chunkSizeRange, FloatRange delayBetweenChunksRange)
		{
			maskTransform.sizeDelta = new Vector2(maskTransform.sizeDelta.x, initialChunkSizeRange.GetRandom());
			while (maskTransform.sizeDelta.y < targetImageTransform.sizeDelta.y)
			{
				int random = chunkSizeRange.GetRandom();
				Vector2 sizeDelta = maskTransform.sizeDelta;
				sizeDelta = new Vector2(sizeDelta.x, sizeDelta.y + (float)random);
				maskTransform.sizeDelta = sizeDelta;
				float random2 = delayBetweenChunksRange.GetRandom();
				yield return new WaitForSeconds(random2);
			}
			imageShowingCoroutine = null;
		}
	}
}
