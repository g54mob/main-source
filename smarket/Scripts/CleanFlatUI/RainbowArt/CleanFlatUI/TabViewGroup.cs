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
				return 0;
			}
			set
			{
			}
		}

		public int CurrentIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		private void Initviews()
		{
		}

		private void InitButtons()
		{
		}

		private void UpdateButtons()
		{
		}

		public void OnButtonClickPrevious()
		{
		}

		public void OnButtonClickNext()
		{
		}

		private void SetViews(bool bNext)
		{
		}

		private void UpdateViews()
		{
		}
	}
}
