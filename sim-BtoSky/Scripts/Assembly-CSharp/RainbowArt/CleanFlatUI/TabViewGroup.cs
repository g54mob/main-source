using System;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class TabViewGroup : MonoBehaviour
	{
		[Serializable]
		public class TabViewGroupItem
		{
			public GameObject tabGroup;

			public GameObject viewGroup;
		}

		[SerializeField]
		private Button buttonPrevious;

		[SerializeField]
		private Button buttonNext;

		[SerializeField]
		private int startIndex;

		public TabViewGroupItem[] tabViewGroups;

		private int currentIndex;

		public int StartIndex
		{
			get
			{
				return startIndex;
			}
			set
			{
				startIndex = value;
			}
		}

		public int CurrentIndex
		{
			get
			{
				return currentIndex;
			}
			set
			{
				if (currentIndex != value)
				{
					currentIndex = value;
				}
			}
		}

		private void Start()
		{
			Initviews();
			InitButtons();
			UpdateButtons();
		}

		private void Initviews()
		{
			currentIndex = startIndex;
			UpdateViews();
		}

		private void InitButtons()
		{
			if (buttonPrevious != null)
			{
				buttonPrevious.onClick.RemoveAllListeners();
				buttonPrevious.onClick.AddListener(OnButtonClickPrevious);
			}
			if (buttonNext != null)
			{
				buttonNext.onClick.RemoveAllListeners();
				buttonNext.onClick.AddListener(OnButtonClickNext);
			}
		}

		private void UpdateButtons()
		{
			if (currentIndex == tabViewGroups.Length - 1)
			{
				buttonPrevious.gameObject.SetActive(value: true);
				buttonNext.gameObject.SetActive(value: false);
			}
			else if (currentIndex == 0)
			{
				buttonPrevious.gameObject.SetActive(value: false);
				buttonNext.gameObject.SetActive(value: true);
			}
			else
			{
				buttonPrevious.gameObject.SetActive(value: true);
				buttonNext.gameObject.SetActive(value: true);
			}
		}

		public void OnButtonClickPrevious()
		{
			SetViews(bNext: false);
		}

		public void OnButtonClickNext()
		{
			SetViews(bNext: true);
		}

		private void SetViews(bool bNext)
		{
			if (bNext)
			{
				currentIndex++;
			}
			else
			{
				currentIndex--;
			}
			UpdateViews();
			UpdateButtons();
		}

		private void UpdateViews()
		{
			for (int i = 0; i < tabViewGroups.Length; i++)
			{
				if (i == currentIndex)
				{
					tabViewGroups[i].tabGroup.SetActive(value: true);
					tabViewGroups[i].viewGroup.SetActive(value: true);
					tabViewGroups[i].tabGroup.GetComponent<TabView>().InitTabViews();
				}
				else
				{
					tabViewGroups[i].tabGroup.SetActive(value: false);
					tabViewGroups[i].viewGroup.SetActive(value: false);
				}
			}
		}
	}
}
