using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_ReviewCounter : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _counter;

		[SerializeField]
		private Image _reviewImage;

		[SerializeField]
		private Image _statImage;

		private int _currentValue;

		public int CurrentValue
		{
			get
			{
				return _currentValue;
			}
			set
			{
				_currentValue = value;
				_counter.text = _currentValue.ToString();
			}
		}

		public void Init(Sprite sprite)
		{
			_reviewImage.sprite = sprite;
			CurrentValue = 0;
		}
	}
}
