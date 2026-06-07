using Battle;
using TMPro;
using UnityEngine;

namespace UI
{
	public class AvatorTalkCanvas : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text talkText;

		[SerializeField]
		private TextShake textShake;

		private bool _talking;

		public void StartTalk(string message)
		{
		}

		public void StopTalk()
		{
		}

		private void SetText(string message)
		{
		}
	}
}
