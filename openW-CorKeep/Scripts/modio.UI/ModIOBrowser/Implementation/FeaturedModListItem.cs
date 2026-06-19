using System.Collections;
using ModIO;
using ModIO.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class FeaturedModListItem : ListItem
	{
		[SerializeField]
		private Image image;

		[SerializeField]
		private GameObject background;

		[SerializeField]
		private GameObject failedToLoad;

		public SubscribedProgressTab progressTab;

		public int rowIndex;

		public int profileIndex;

		private static float transitionTime = 0.5f;

		public AnimationCurve animationCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 2f), new Keyframe(1f, 1f));

		private IEnumerator transition;

		internal static int transitionCount = 0;

		public override void PlaceholderSetup()
		{
			base.PlaceholderSetup();
			image.color = Color.clear;
			background.SetActive(value: false);
			failedToLoad.SetActive(value: false);
		}

		public override void Setup(ModProfile profile)
		{
			base.Setup();
			progressTab.Setup(profile);
			image.color = Color.clear;
			background.SetActive(value: false);
			failedToLoad.SetActive(value: false);
			ModIOUnity.DownloadTexture(profile.logoImage_640x360, SetIcon);
		}

		private void SetIcon(ResultAnd<Texture2D> resultAndTexture)
		{
			if (resultAndTexture.result.Succeeded() && resultAndTexture != null)
			{
				SelfInstancingMonoSingleton<QueueRunner>.Instance.AddSpriteCreation(resultAndTexture.value, delegate(Sprite sprite)
				{
					image.sprite = sprite;
					image.color = Color.white;
					background.SetActive(value: true);
				});
			}
			else
			{
				failedToLoad.SetActive(value: true);
			}
		}

		public void Transition(RectTransform start, RectTransform end)
		{
			if (transition != null)
			{
				StopCoroutine(transition);
				bool num = start.position.x > end.position.x;
				bool flag = base.transform.position.x > end.position.x;
				if (num != flag)
				{
					transition = Transition(start.position, end);
				}
				else
				{
					transition = Transition(base.transform.position, end);
				}
				StartCoroutine(transition);
			}
			else
			{
				Transform obj = base.transform;
				Vector2 vector = start.position;
				obj.position = vector;
				((RectTransform)obj).sizeDelta = start.sizeDelta;
				transition = Transition(vector, end);
				StartCoroutine(transition);
			}
		}

		private IEnumerator Transition(Vector2 start, RectTransform end)
		{
			SelfInstancingMonoSingleton<Home>.Instance.HideFeaturedHighlight();
			transitionCount++;
			RectTransform rectTransform = (RectTransform)base.transform;
			Vector2 startingSize = rectTransform.sizeDelta;
			Vector2 distance = (Vector2)end.position - start;
			Vector2 growth = end.sizeDelta - startingSize;
			float timePassed = 0f;
			while (timePassed <= transitionTime)
			{
				timePassed += Time.fixedDeltaTime;
				float num = animationCurve.Evaluate(timePassed / transitionTime);
				Vector3 position = start + distance * num;
				position.y = base.transform.position.y;
				base.transform.position = position;
				rectTransform.sizeDelta = startingSize + growth * num;
				yield return new WaitForSecondsRealtime(0.01f);
			}
			yield return new WaitForSecondsRealtime(0.01f);
			transitionCount--;
			if (transitionCount == 0)
			{
				SelfInstancingMonoSingleton<Home>.Instance.ShowFeaturedHighlight();
			}
		}
	}
}
