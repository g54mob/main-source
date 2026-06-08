using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	public class UiDebugVisibility : MonoBehaviour
	{
		[SerializeField]
		private bool shouldDisplayDebugImageInEditor = true;

		[SerializeField]
		private bool shouldUseOtherGameObject;

		[SerializeField]
		private GameObject debugGameObject;

		[SerializeField]
		private Image debugImage;

		private void OnValidate()
		{
			if (debugImage == null)
			{
				debugImage = GetComponent<Image>();
			}
			DisplayDebugInformation(shouldDisplayDebugImageInEditor);
		}

		private void Start()
		{
			DisplayDebugInformation(shouldDisplay: false);
		}

		private void DisplayDebugInformation(bool shouldDisplay)
		{
			if (shouldUseOtherGameObject)
			{
				if ((bool)debugGameObject)
				{
					debugGameObject.SetActive(shouldDisplay);
				}
			}
			else if ((bool)debugImage)
			{
				if (shouldDisplay)
				{
					debugImage.enabled = true;
				}
				else
				{
					Object.Destroy(debugImage);
				}
			}
			else
			{
				debugImage = base.gameObject.AddComponent(typeof(Image)) as Image;
				debugImage.color = Constants.UI.Colors.DebugSpacer;
			}
		}
	}
}
