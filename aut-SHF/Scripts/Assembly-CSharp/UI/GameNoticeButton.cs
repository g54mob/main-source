using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class GameNoticeButton : MonoBehaviour
	{
		public TMP_Text noticeTitle;

		public Image noticeIcon;

		public Transform animationGroup;

		public float entrySecond;

		public float backSecond;

		public GameObject shortcutButton;

		private double _timeCount;

		public NoticeParam NoticeParam { get; private set; }

		public bool IsDisplayed { get; private set; }

		public event UnityAction OnClickAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void InitComponent(NoticeParam param)
		{
		}

		public void DisplayNotice()
		{
		}

		private void Update()
		{
		}

		public void OnClick()
		{
		}
	}
}
