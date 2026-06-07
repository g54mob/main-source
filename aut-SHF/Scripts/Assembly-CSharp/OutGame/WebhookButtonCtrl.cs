using UnityEngine;
using UnityEngine.UI;

namespace OutGame
{
	[RequireComponent(typeof(Button))]
	public class WebhookButtonCtrl : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private string URL;

		[SerializeField]
		private bool isTrial;

		[SerializeField]
		private bool showAlways;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void OnClickButton()
		{
		}
	}
}
