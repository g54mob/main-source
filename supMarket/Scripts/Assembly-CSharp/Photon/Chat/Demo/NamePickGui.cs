using UnityEngine;
using UnityEngine.UI;

namespace Photon.Chat.Demo
{
	[RequireComponent(typeof(ChatGui))]
	public class NamePickGui : MonoBehaviour
	{
		private const string UserNamePlayerPref = "NamePickUserName";

		public ChatGui chatNewComponent;

		public InputField idInput;

		public void Start()
		{
		}

		public void EndEditOnEnter()
		{
		}

		public void StartChat()
		{
		}
	}
}
