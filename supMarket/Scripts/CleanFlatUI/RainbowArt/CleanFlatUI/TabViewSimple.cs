using System;
using UnityEngine;
using UnityEngine.Events;

namespace RainbowArt.CleanFlatUI
{
	public class TabViewSimple : MonoBehaviour
	{
		[Serializable]
		public class TabViewSimpleItem
		{
			public GameObject tab;

			public GameObject view;
		}

		[Serializable]
		public class TabViewSimpleEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private int startIndex;

		[SerializeField]
		private TabViewSimpleItem[] TabViewSimples;

		[SerializeField]
		private TabViewSimpleEvent onValueChanged;

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

		public TabViewSimpleEvent OnValueChanged
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void InitTabViewSimples()
		{
		}

		private void SetCurrentIndex(int newCurrentIndex)
		{
		}

		public void TabValueChanged(int index, bool value)
		{
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
		}
	}
}
