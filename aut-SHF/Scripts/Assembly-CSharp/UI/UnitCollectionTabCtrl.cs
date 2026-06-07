using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class UnitCollectionTabCtrl : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private Image offImage;

		[SerializeField]
		private Image onImage;

		private eWriterId writerId;

		private UnityAction<eWriterId> onClickAction;

		private bool isUnlock;

		public eWriterId WriterId => default(eWriterId);

		public bool IsUnlock => false;

		public void Init(eWriterId id, Sprite onImage, Sprite offImage, UnityAction<eWriterId> onClickAction)
		{
		}

		public void OnClickButton()
		{
		}

		public void SwitchImage(bool isOn)
		{
		}

		public void UpdateUI()
		{
		}
	}
}
