using TMPro;
using UnityEngine;

namespace UI
{
	[RequireComponent(typeof(TMP_Text))]
	public class GeneralMessageSetter : MonoBehaviour
	{
		[SerializeField]
		private eMessageId displayMessage;

		private TMP_Text _text;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void SetDisplayMessage(eMessageId messageId)
		{
		}
	}
}
