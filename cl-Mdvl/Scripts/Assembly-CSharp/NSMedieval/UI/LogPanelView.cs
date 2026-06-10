using System.Collections.Generic;
using System.Text;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Enums;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class LogPanelView : PopupView
	{
		private const int StringBuilderMaxCapacity = 50000;

		[SerializeField]
		private GameObject content;

		[SerializeField]
		private LifeEventType[] allowedFilters;

		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private SoundButton[] closeButtons;

		[SerializeField]
		private SoundButton devGenerateButton;

		[SerializeField]
		private TMP_Text logLabel;

		private LogPanelDebugView logPanelDebugView;

		private readonly List<LifeEventToggleItemView> typeToggles = new List<LifeEventToggleItemView>();

		[SerializeField]
		private LayoutGroupView toggleParent;

		private readonly HashSet<LifeEventType> typeFilter = new HashSet<LifeEventType>();

		private readonly List<LifeEventLogStruct> currentLog = new List<LifeEventLogStruct>();

		private readonly StringBuilder stringBuilder = new StringBuilder();

		public void SetDataAndShow(string title, LinkedList<LifeEventLogStruct> lifeEventLogs)
		{
			if (!IsShowing())
			{
				currentLog.Clear();
				currentLog.AddRange(lifeEventLogs);
				Show();
				this.title.SetText(title);
				RefreshLogs();
			}
		}

		private void RefreshLogs()
		{
			stringBuilder.Clear();
			foreach (LifeEventLogStruct item in currentLog)
			{
				if (typeFilter.Contains(item.Type) && stringBuilder.Length < 50000)
				{
					stringBuilder.AppendLine(item.LocalizedLog);
				}
			}
			stringBuilder.AppendLine();
			logLabel.SetText(stringBuilder.ToString());
		}

		private void Awake()
		{
			MainView = content;
			SoundButton[] array = closeButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].onClick.AddListener(OnClose);
			}
			LifeEventType[] array2 = allowedFilters;
			for (int i = 0; i < array2.Length; i++)
			{
				LifeEventType type = array2[i];
				if (!type.Equals(LifeEventType.None))
				{
					typeToggles.GetNext(toggleParent).SetData(type, OnTypeToggle);
				}
			}
			devGenerateButton.gameObject.SetActive(value: false);
			RefreshTypeFilter();
		}

		private void OnTypeToggle(bool isOn)
		{
			RefreshTypeFilter();
			RefreshLogs();
		}

		private void RefreshTypeFilter()
		{
			typeFilter.Clear();
			foreach (LifeEventToggleItemView typeToggle in typeToggles)
			{
				if (typeToggle.Toggle.isOn)
				{
					typeFilter.Add(typeToggle.LifeEventType);
				}
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			MonoSingleton<UIController>.Instance.LinkClickedEvent += OnLinkClicked;
		}

		protected override void OnHide()
		{
			base.OnHide();
			MonoSingleton<UIController>.Instance.LinkClickedEvent -= OnLinkClicked;
		}

		private void OnClose()
		{
			Hide();
		}

		private void OnLinkClicked(string obj)
		{
			OnClose();
		}
	}
}
