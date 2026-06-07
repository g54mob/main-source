using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class ClickEffect : MonoBehaviour
	{
		private const string CLICK_IMAGE_NAME = "[image click]";

		private const float CLICK_ANIM_DURATION = 0.05f;

		private IClickable clickable;

		private Image clickImage;

		private void Awake()
		{
			clickable = GetComponent<IClickable>();
			clickImage = Util.FindInChildren<Image>(base.gameObject, "[image click]");
			clickImage.GetComponent<CanvasRenderer>().cullTransparentMesh = true;
			SetupListeners(on: true);
		}

		private void OnEnable()
		{
			clickImage.canvasRenderer.SetAlpha(0f);
			clickImage.gameObject.SetActive(value: false);
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				clickable.Clicked += OnClicked;
			}
			else
			{
				clickable.Clicked -= OnClicked;
			}
		}

		private void OnClicked(IClickable _ = null)
		{
			if (base.gameObject.activeInHierarchy)
			{
				clickImage.gameObject.SetActive(value: true);
				StartCoroutine(DisableAfterDelay(0.05f));
				clickImage.canvasRenderer.SetAlpha(1f);
				clickImage.CrossFadeAlpha(0f, 0.05f, ignoreTimeScale: true);
			}
		}

		private IEnumerator DisableAfterDelay(float hoverDuration)
		{
			yield return WaitFor.Seconds(hoverDuration);
			clickImage.gameObject.SetActive(value: false);
		}
	}
}
