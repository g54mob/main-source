using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public abstract class ScrollableDisplayScreen : DisplayScreen, IScrollableDisplayScreen, IDisplayScreen
	{
		public GameObject scrollUpArrow;

		public GameObject scrollDownArrow;

		protected IntIterator selector;

		protected int activeSlotCount;

		public int CurrentSelection => selector?.Current ?? 0;

		public int IndexOfFirstDisplayedEntry { get; protected set; }

		protected abstract int TotalSlotCount { get; }

		protected int HighestFirstDisplayEntryIndex => Mathf.Max(TotalSlotCount - activeSlotCount, 0);

		private void Start()
		{
			if (activeSlotCount == 0)
			{
				Debug.LogError(GetType().Name + ": activeSlotCount wasn't set in Awake! Scrolling will have undefined behaviour.");
			}
		}

		public void Scroll(int firstShownIndex, int highlightedIndex)
		{
			int current = selector.Current;
			IndexOfFirstDisplayedEntry = firstShownIndex;
			selector.Current = highlightedIndex;
			if (selector.HasElements)
			{
				HighlightSelected(selector.Current, current);
			}
			PopulateTextsFromIndex(IndexOfFirstDisplayedEntry);
		}

		protected void ScrollUp()
		{
			Scroll(up: true);
		}

		protected void ScrollDown()
		{
			Scroll(up: false);
		}

		private void Scroll(bool up)
		{
			int current = selector.Current;
			int indexOfFirstDisplayedEntry = IndexOfFirstDisplayedEntry;
			if (up)
			{
				if (!selector.IsFirst)
				{
					HighlightSelected(selector.Previous(), current);
				}
				else if (IndexOfFirstDisplayedEntry == 0)
				{
					if (!selector.isWrappable)
					{
						return;
					}
					int current2 = selector.Current;
					HighlightSelected(selector.Previous(), current2);
					IndexOfFirstDisplayedEntry = HighestFirstDisplayEntryIndex;
				}
				else
				{
					IndexOfFirstDisplayedEntry--;
				}
			}
			else if (!selector.IsLast)
			{
				HighlightSelected(selector.Next(), current);
			}
			else if (IndexOfFirstDisplayedEntry >= HighestFirstDisplayEntryIndex)
			{
				if (!selector.isWrappable)
				{
					return;
				}
				int current3 = selector.Current;
				HighlightSelected(selector.Next(), current3);
				IndexOfFirstDisplayedEntry = 0;
			}
			else
			{
				IndexOfFirstDisplayedEntry++;
			}
			if (indexOfFirstDisplayedEntry != IndexOfFirstDisplayedEntry)
			{
				PopulateTextsFromIndex(IndexOfFirstDisplayedEntry);
			}
		}

		protected void SetSelectorWithinBounds()
		{
			int num = Mathf.Min(TotalSlotCount, activeSlotCount);
			bool num2 = selector.Length < num;
			bool flag = selector.Length > num;
			if (num2 || flag)
			{
				int current = selector.Current;
				bool hasElements = selector.HasElements;
				selector.UpdateLength(num);
				if (!selector.HasElements)
				{
					HighlightSelected(-1, current);
				}
				else if (current > selector.Current)
				{
					HighlightSelected(selector.Current, current);
				}
				else if (!hasElements)
				{
					HighlightSelected(selector.Current);
				}
			}
		}

		protected void SetIndexOfFirstDisplayWithinBounds()
		{
			int highestFirstDisplayEntryIndex = HighestFirstDisplayEntryIndex;
			if (IndexOfFirstDisplayedEntry > 0 && IndexOfFirstDisplayedEntry > highestFirstDisplayEntryIndex)
			{
				IndexOfFirstDisplayedEntry = highestFirstDisplayEntryIndex;
			}
		}

		public virtual void PopulateTextsFromIndex(int startingIndex)
		{
			if (scrollUpArrow != null)
			{
				scrollUpArrow.SetActive(startingIndex > 0);
			}
			if (scrollDownArrow != null)
			{
				scrollDownArrow.SetActive(startingIndex < HighestFirstDisplayEntryIndex);
			}
		}

		public abstract void HighlightSelected(int newHighlight, int prevHighlighted = -1);

		public override void Disable()
		{
			HighlightSelected(-1, selector.Current);
			if (scrollUpArrow != null)
			{
				scrollUpArrow.SetActive(value: false);
			}
			if (scrollDownArrow != null)
			{
				scrollDownArrow.SetActive(value: false);
			}
		}
	}
}
