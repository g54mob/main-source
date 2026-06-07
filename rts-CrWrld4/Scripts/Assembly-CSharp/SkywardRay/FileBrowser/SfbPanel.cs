using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SkywardRay.FileBrowser
{
	public abstract class SfbPanel : MonoBehaviour, SfbIElement, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDropHandler
	{
		public Transform content;

		protected List<SfbEntry> entryPrefabs;

		protected SfbInternal fileBrowser;

		private SfbDraggable parentDraggable;

		protected Scrollbar scrollbar;

		protected ScrollRect scrollRect;

		private Stopwatch hoverTimer;

		private SfbEntry hoverChild;

		private PointerEventData hoverEvent;

		protected float lastScrollPosition;

		protected List<SfbEntryWrapper> wrappers;

		private Stopwatch clickStopwatch;

		private SfbEntryWrapper lastClickedWrapper;

		private SfbEntry selectedChild;

		private void Update()
		{
		}

		public IEnumerator UpdateScrollView()
		{
			return null;
		}

		protected void Repopulate(IEnumerable<SfbFileSystemEntry> entries, bool keepScrollPosition)
		{
		}

		public void UpdateContentsAndScrollView()
		{
		}

		private void CreateWrappers(IEnumerable<SfbFileSystemEntry> entries)
		{
		}

		protected void StartShowOnScreenEntries(float scrollPosition)
		{
		}

		private IEnumerator ShowOnScreenEntries(float scrollPosition)
		{
			return null;
		}

		private SfbEntry BrowserEntryFromFileSystemEntry(SfbEntryWrapper wrapper)
		{
			return null;
		}

		public List<SfbEntryWrapper> GetSelected()
		{
			return null;
		}

		private void Click(SfbEntryWrapper wrapper)
		{
		}

		private void DoubleClick(SfbEntryWrapper wrapper)
		{
		}

		public void DeselectChildren()
		{
		}

		public void PointerDownOnChild(SfbEntry child)
		{
		}

		public void PointerUpOnChild(SfbEntry child)
		{
		}

		public void DropOnChild(SfbEntry child)
		{
		}

		public void PointerEnterOnChild(SfbEntry child, PointerEventData eventData)
		{
		}

		public void PointerExitOnChild(SfbEntry child)
		{
		}

		private List<SfbEntryWrapper> GetChildRange(SfbEntryWrapper first, SfbEntryWrapper last)
		{
			return null;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public virtual void Init(SfbInternal fileBrowser)
		{
		}

		public void SetFocus()
		{
		}

		public void RecieveMessage(string message)
		{
		}

		public void OnDrop(PointerEventData eventData)
		{
		}
	}
}
