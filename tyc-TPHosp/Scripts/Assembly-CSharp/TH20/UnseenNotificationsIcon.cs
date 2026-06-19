using TMPro;
using UnityEngine;

namespace TH20
{
	public class UnseenNotificationsIcon : MonoBehaviour
	{
		[SerializeField]
		private GameObject _rootGameObject;

		[SerializeField]
		private TMP_Text _numberText;

		[SerializeField]
		private TextMesh _numberTextMesh;

		public int UnseenNotifications
		{
			set
			{
				SetNumUnseenNotifications(value);
			}
		}

		private void SetNumUnseenNotifications(int value)
		{
			GameObjectUtils.SetActive(_rootGameObject, value > 0);
			if (_numberText != null)
			{
				_numberText.text = ((value >= 9) ? "9" : value.ToString());
			}
			if (_numberTextMesh != null)
			{
				_numberTextMesh.text = ((value >= 9) ? "9" : value.ToString());
			}
		}
	}
}
