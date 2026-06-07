using UnityEngine;
using UnityEngine.UI;

namespace CreativeMode
{
	public class RestartItemsPosionUI : MonoBehaviour
	{
		[SerializeField]
		private ConfirmationWindowUI confirmationWindow;

		private Button button;

		private void Awake()
		{
			button = base.transform.GetComponent<Button>();
			button.onClick.AddListener(ConfirmationWindowActivation);
		}

		private void ConfirmationWindowActivation()
		{
			confirmationWindow.ShowRestartItemWindow(this);
		}

		private void OnDestroy()
		{
			button.onClick.RemoveAllListeners();
		}

		public void RestartItemsPosition()
		{
			ItemCreatingSystem.Instance.RestartItemsOnLevel();
		}
	}
}
