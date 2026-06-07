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

		private int entryIndex;

		private bool isExpanded;

		private Vector2 logTextOriginalPosition;

		private Vector2 logTextOriginalSize;

		private float copyLogButtonHeight;

		private DebugLogRecycledListView listView;

		public RectTransform Transform => null;

		public Image Image => null;

		public CanvasGroup CanvasGroup => null;

		public DebugLogEntry Entry => null;

		public DebugLogEntryTimestamp? Timestamp => null;

		public int Index => 0;

		public bool Expanded => false;

		public void Initialize(DebugLogRecycledListView listView)
		{
		}

		public void SetContent(DebugLogEntry logEntry, DebugLogEntryTimestamp? logEntryTimestamp, int entryIndex, bool isExpanded)
		{
		}

		public void ShowCount()
		{
		}

		public void HideCount()
		{
		}

		public void UpdateTimestamp(DebugLogEntryTimestamp timestamp)
		{
		}

		private void SetText(DebugLogEntry logEntry, DebugLogEntryTimestamp? logEntryTimestamp, bool isExpanded)
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		public void CopyLog()
		{
		}

		internal string GetCopyContent()
		{
			return null;
		}

		public float CalculateExpandedHeight(DebugLogEntry logEntry, DebugLogEntryTimestamp? logEntryTimestamp)
		{
			return 0f;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
