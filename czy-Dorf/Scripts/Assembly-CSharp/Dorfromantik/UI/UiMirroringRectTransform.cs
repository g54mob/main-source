using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	public class UiMirroringRectTransform : MonoBehaviour
	{
		[SerializeField]
		private RectTransform rectTransformToMirror;

		[SerializeField]
		private bool shouldMirrorSizeDelta = true;

		[SerializeField]
		private bool shouldMirrorAnchoredPosition = true;

		[SerializeField]
		private bool shouldMirrorPivot = true;

		[SerializeField]
		private bool shouldDisplayDebugInformationInEditor = true;

		[SerializeField]
		private Image debugImage;

		private RectTransform rectTransform;

		private void OnValidate()
		{
			if (rectTransform == null)
			{
				rectTransform = GetComponent<RectTransform>();
			}
			if (debugImage == null)
			{
				debugImage = GetComponent<Image>();
			}
			DisplayDebugInformation(shouldDisplayDebugInformationInEditor);
			UpdateRectTransformInformation();
		}

		private void Start()
		{
			DisplayDebugInformation(shouldDisplay: false);
			UpdateRectTransformInformation();
		}

		private void DisplayDebugInformation(bool shouldDisplay)
		{
			if ((bool)debugImage)
			{
				if (shouldDisplay)
				{
					debugImage.enabled = true;
				}
				else
				{
					Object.DestroyImmediate(debugImage);
				}
			}
			else
			{
				debugImage = base.gameObject.AddComponent(typeof(Image)) as Image;
				debugImage.color = Constants.UI.Colors.DebugMirroringPlaceholder;
			}
		}

		private void UpdateRectTransformInformation()
		{
			if (!(rectTransformToMirror == null))
			{
				if (shouldMirrorSizeDelta)
				{
					rectTransform.sizeDelta = rectTransformToMirror.sizeDelta;
				}
				if (shouldMirrorAnchoredPosition)
				{
					rectTransform.anchoredPosition = rectTransformToMirror.anchoredPosition;
				}
				if (shouldMirrorPivot)
				{
					rectTransform.pivot = rectTransformToMirror.pivot;
				}
			}
		}
	}
}
