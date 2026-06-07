using UnityEngine;
using UnityEngine.UI;

namespace CreativeMode
{
	public class ClearItemsButtonUI : MonoBehaviour
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
			confirmationWindow.ShowClearItemsWindow(this);
		}

		private void OnDestroy()
		{
			button.onClick.RemoveAllListeners();
		}

		public void ClearAllItems()
		{
			ItemCreatingSystem.Instance.ClearAllItems();
		}
	}
}
