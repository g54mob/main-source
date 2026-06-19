using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace IngameDebugConsole
{
	public class DebugLogItem : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private RectTransform transformComponent;

		[SerializeField]
		private Image imageComponent;

		[SerializeField]
		private CanvasGroup canvasGroupComponent;

		[SerializeField]
		private TextMeshProUGUI logText;

		[SerializeField]
		private Image logTypeImage;

		[SerializeField]
		private GameObject logCountParent;

		[SerializeField]
		private TextMeshProUGUI logCountText;

		[SerializeField]
		private Button copyLogButton;

		private DebugLogEntry logEntry;

		private DebugLogEntryTimestamp? logEntryTimestamp;

		[NonSerialized]
		public int Index;

		private bool isExpanded;

		private Vector2 logTextOriginalPosition;

		private Vector2 logTextOriginalSize;

		private float copyLogButtonHeight;

		private DebugLogRecycledListView listView;

		public RectTransform Transform => transformComponent;

		public Image Image => imageComponent;

		public CanvasGroup CanvasGroup => canvasGroupComponent;

		public DebugLogEntry Entry => logEntry;

		public DebugLogEntryTimestamp? Timestamp => logEntryTimestamp;

		public bool Expanded => isExpanded;

		public void Initialize(DebugLogRecycledListView listView)
		{
			this.listView = listView;
			logTextOriginalPosition = logText.rectTransform.anchoredPosition;
			logTextOriginalSize = logText.rectTransform.sizeDelta;
			copyLogButtonHeight = (copyLogButton.transform as RectTransform).anchoredPosition.y + (copyLogButton.transform as RectTransform).sizeDelta.y + 2f;
			if (listView.manager.logItemFontOverride != null)
			{
				logText.font = listView.manager.logItemFontOverride;
			}
			copyLogButton.onClick.AddListener(CopyLog);
		}

		public void SetContent(DebugLogEntry logEntry, DebugLogEntryTimestamp? logEntryTimestamp, int entryIndex, bool isExpanded)
		{
			this.logEntry = logEntry;
			this.logEntryTimestamp = logEntryTimestamp;
			Index = entryIndex;
			this.isExpanded = isExpanded;
			Vector2 sizeDelta = transformComponent.sizeDelta;
			if (isExpanded)
			{
				sizeDelta.y = listView.SelectedItemHeight;
				if (!copyLogButton.gameObject.activeSelf)
				{
					copyLogButton.gameObject.SetActive(value: true);
					logText.rectTransform.anchoredPosition = new Vector2(logTextOriginalPosition.x, logTextOriginalPosition.y + copyLogButtonHeight * 0.5f);
					logText.rectTransform.sizeDelta = logTextOriginalSize - new Vector2(0f, copyLogButtonHeight);
				}
			}
			else
			{
				sizeDelta.y = listView.ItemHeight;
				if (copyLogButton.gameObject.activeSelf)
				{
					copyLogButton.gameObject.SetActive(value: false);
					logText.rectTransform.anchoredPosition = logTextOriginalPosition;
					logText.rectTransform.sizeDelta = logTextOriginalSize;
				}
			}
			transformComponent.sizeDelta = sizeDelta;
			SetText(logEntry, logEntryTimestamp, isExpanded);
			logTypeImage.sprite = listView.manager.logSpriteRepresentations[(int)logEntry.logType];
		}

		public void ShowCount()
		{
			logCountText.SetText("{0}", logEntry.count);
			if (!logCountParent.activeSelf)
			{
				logCountParent.SetActive(value: true);
			}
		}

		public void HideCount()
		{
			if (logCountParent.activeSelf)
			{
				logCountParent.SetActive(value: false);
			}
		}

		public void UpdateTimestamp(DebugLogEntryTimestamp timestamp)
		{
			logEntryTimestamp = timestamp;
			if (isExpanded || listView.manager.alwaysDisplayTimestamps)
			{
				SetText(logEntry, timestamp, isExpanded);
			}
		}

		private void SetText(DebugLogEntry logEntry, DebugLogEntryTimestamp? logEntryTimestamp, bool isExpanded)
		{
			string text = (isExpanded ? logEntry.ToString() : logEntry.logString);
			int num = (isExpanded ? listView.manager.maxExpandedLogLength : listView.manager.maxCollapsedLogLength);
			if (!logEntryTimestamp.HasValue || (!isExpanded && !listView.manager.alwaysDisplayTimestamps))
			{
				if (text.Length <= num)
				{
					logText.text = text;
					return;
				}
				if (listView.manager.textBuffer.Length < num)
				{
					listView.manager.textBuffer = new char[num];
				}
				text.CopyTo(0, listView.manager.textBuffer, 0, num);
				logText.SetText(listView.manager.textBuffer, 0, num);
				return;
			}
			StringBuilder sharedStringBuilder = listView.manager.sharedStringBuilder;
			sharedStringBuilder.Length = 0;
			if (isExpanded)
			{
				logEntryTimestamp.Value.AppendFullTimestamp(sharedStringBuilder);
				sharedStringBuilder.Append(": ").Append(text, 0, Mathf.Min(text.Length, num - sharedStringBuilder.Length));
			}
			else
			{
				logEntryTimestamp.Value.AppendTime(sharedStringBuilder);
				sharedStringBuilder.Append(" ").Append(text, 0, Mathf.Min(text.Length, num - sharedStringBuilder.Length));
			}
			if (listView.manager.textBuffer.Length < sharedStringBuilder.Length)
			{
				listView.manager.textBuffer = new char[sharedStringBuilder.Length];
			}
			sharedStringBuilder.CopyTo(0, listView.manager.textBuffer, 0, sharedStringBuilder.Length);
			logText.SetText(listView.manager.textBuffer, 0, sharedStringBuilder.Length);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			listView.OnLogItemClicked(this);
		}

		private void CopyLog()
		{
			string copyContent = GetCopyContent();
			if (!string.IsNullOrEmpty(copyContent))
			{
				GUIUtility.systemCopyBuffer = copyContent;
			}
		}

		internal string GetCopyContent()
		{
			if (!logEntryTimestamp.HasValue)
			{
				return logEntry.ToString();
			}
			StringBuilder sharedStringBuilder = listView.manager.sharedStringBuilder;
			sharedStringBuilder.Length = 0;
			logEntryTimestamp.Value.AppendFullTimestamp(sharedStringBuilder);
			sharedStringBuilder.Append(": ").Append(logEntry.ToString());
			return sharedStringBuilder.ToString();
		}

		public float CalculateExpandedHeight(DebugLogEntry logEntry, DebugLogEntryTimestamp? logEntryTimestamp)
		{
			string text = logText.text;
			Vector2 sizeDelta = (base.transform as RectTransform).sizeDelta;
			(base.transform as RectTransform).sizeDelta = new Vector2(sizeDelta.x, 10000f);
			SetText(logEntry, logEntryTimestamp, isExpanded: true);
			logText.ForceMeshUpdate();
			float b = logText.GetRenderedValues(onlyVisibleCharacters: true).y + copyLogButtonHeight;
			(base.transform as RectTransform).sizeDelta = sizeDelta;
			logText.text = text;
			return Mathf.Max(listView.ItemHeight, b);
		}

		public override string ToString()
		{
			return logEntry.ToString();
		}
	}
}
