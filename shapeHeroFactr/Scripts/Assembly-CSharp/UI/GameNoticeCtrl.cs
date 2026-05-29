using System.Collections.Generic;
using Libs;
using UnityEngine;

namespace UI
{
	public class GameNoticeCtrl : SingletonMonoBehaviour<GameNoticeCtrl>
	{
		public GameNoticeButton gameNoticeButton;

		public RectTransform contents;

		private List<GameNoticeButton> _noticeList;

		private bool _isInitialize;

		public bool IsNotice => false;

		public bool IsReactionNotice => false;

		private void Awake()
		{
		}

		public void Init()
		{
		}

		private GameNoticeButton CreateChild()
		{
			return null;
		}

		public void CreateNotice(NoticeParam data)
		{
		}

		public void ClearNotice()
		{
		}

		public void ClearNotice(eMessageId id)
		{
		}

		public void ClearNotice(params eMessageId[] idArray)
		{
		}

		private bool CheckDuplication(NoticeParam data)
		{
			return false;
		}

		public void OnPushNotice(eMessageId id)
		{
		}

		public void ClearReserve()
		{
		}

		public void DisplayNotice(bool on)
		{
		}

		private void Update()
		{
		}
	}
}
