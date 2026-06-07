using System.Collections.Generic;
using UI.Common;
using UI.Elements;
using UnityEngine;
using UnityEngine.Localization.Tables;

namespace UI
{
	public class UISettingBar : MonoBehaviour
	{
		public UIButton backButton;

		public UIButton learnButton;

		public GameObject pastAppsButtonPrefab;

		public Transform buttonBar;

		public List<UIButton> appHistoryButtons;

		[SerializeField]
		private UIText title;

		[SerializeField]
		private UIText time;

		private UIClock clock;

		public UIErrorBar errorBar;

		public void Init()
		{
		}

		public void SetTitle(string title)
		{
		}

		public void GoBackToLastApp()
		{
		}

		public void AddPastAppButton(MultiToolAppTypes appType)
		{
		}

		public void RemoveIcon(int i)
		{
		}

		public void OnOpen()
		{
		}

		public void OnClose()
		{
		}

		private void OpenDocumentation()
		{
		}

		private void OpenDocumentationConfirm(bool confirm)
		{
		}

		public void GiveErrorMessage(TableReference tableRef, TableEntryReference messageEntryRef, MiniTool.MessageType messageType)
		{
		}

		public void StopShowingError()
		{
		}
	}
}
