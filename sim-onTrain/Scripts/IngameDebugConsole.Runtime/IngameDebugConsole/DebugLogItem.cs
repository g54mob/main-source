using System;
using System.Text;
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
		private Text logText;

		[SerializeField]
		private Image logTypeImage;

		[SerializeField]
		private GameObject logCountParent;

		[SerializeField]
		private Text logCountText;

		[SerializeField]
		private RectTransform copyLogButton;

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
			copyLogButtonHeight = copyLogButton.anchoredPosition.y + copyLogButton.sizeDelta.y + 2f;
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
				logText.horizontalOverflow = HorizontalWrapMode.Wrap;
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
				logText.horizontalOverflow = HorizontalWrapMode.Overflow;
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
			logTypeImage.sprite = logEntry.logTypeSpriteRepresentation;
		}

		public void ShowCount()
		{
			logCountText.text = logEntry.count.ToString();
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
			if (!logEntryTimestamp.HasValue || (!isExpanded && !listView.manager.alwaysDisplayTimestamps))
			{
				logText.text = (isExpanded ? logEntry.ToString() : logEntry.logString);
				return;
			}
			StringBuilder sharedStringBuilder = listView.manager.sharedStringBuilder;
			sharedStringBuilder.Length = 0;
			if (isExpanded)
			{
				logEntryTimestamp.Value.AppendFullTimestamp(sharedStringBuilder);
				sharedStringBuilder.Append(": ").Append(logEntry.ToString());
			}
			else
			{
				logEntryTimestamp.Value.AppendTime(sharedStringBuilder);
				sharedStringBuilder.Append(" ").Append(logEntry.logString);
			}
			logText.text = sharedStringBuilder.ToString();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			listView.OnLogItemClicked(this);
		}

		public void CopyLog()
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
			HorizontalWrapMode horizontalOverflow = logText.horizontalOverflow;
			SetText(logEntry, logEntryTimestamp, isExpanded: true);
			logText.horizontalOverflow = HorizontalWrapMode.Wrap;
			float b = logText.preferredHeight + copyLogButtonHeight;
			logText.text = text;
			logText.horizontalOverflow = horizontalOverflow;
			return Mathf.Max(listView.ItemHeight, b);
		}

		public override string ToString()
		{
			return logEntry.ToString();
		}
	}
}
