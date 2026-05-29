using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class FloorButton : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private TextMeshProUGUI _text;

		private Floor _assignedFloor;

		private void OnEnable()
		{
			FloorsManager.ChangingFloor += OnChangingFloor;
		}

		private void OnChangingFloor(Floor obj)
		{
			TextUpdate();
		}

		private void OnDisable()
		{
			FloorsManager.ChangingFloor -= OnChangingFloor;
		}

		private void TextUpdate()
		{
			if ((bool)_text)
			{
				_text.color = ((FloorsManager.CurrentFloor == _assignedFloor) ? Color.white : Color.grey);
			}
		}

		public void SetFloor(Floor p_floor)
		{
			_assignedFloor = p_floor;
			if ((bool)_text)
			{
				_text.text = _assignedFloor.name;
			}
			TextUpdate();
			_button.onClick.AddListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			if (!(FloorsManager.CurrentFloor == _assignedFloor))
			{
				MonoSingleton<FloorsManager>.Instance.ChangeCurrentFloor(_assignedFloor.FloorID);
			}
		}
	}
}
