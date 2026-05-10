using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class CrossToggle : MonoBehaviour
	{
		[SerializeField]
		private GameObject _gamePanel;

		[field: SerializeField]
		public CTSToggle CTSTogle { get; private set; }

		public void SetUpGamePanel(GameObject gameObject)
		{
			_gamePanel = gameObject;
			_gamePanel.SetActive(CTSTogle.isOn);
		}

		public void ChangeValue(bool newValue)
		{
			if (_gamePanel != null)
			{
				_gamePanel.SetActive(newValue);
			}
		}
	}
}
