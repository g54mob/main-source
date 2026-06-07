using System;
using UnityEngine;
using UnityEngine.Events;

namespace RainbowArt.CleanFlatUI
{
	public class TabView : MonoBehaviour
	{
		[Serializable]
		public class TabViewItem
		{
			public GameObject tab;

			public GameObject view;
		}

		[Serializable]
		public class TabViewEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private int startIndex;

		[SerializeField]
		private TabViewItem[] tabViews;

		[SerializeField]
		private TabViewEvent onValueChanged;

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

		public TabViewEvent OnValueChanged
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

		private void InitAnimators()
		{
		}

		public void InitTabViews()
		{
		}

		private void SetCurrentIndex(int newCurrentIndex)
		{
		}

		public void TabValueChanged(int index, bool value)
		{
		}

		private void PlayAnimation(Animator animator, string animStr)
		{
		}

		private void ResetAnimation(Animator animator)
		{
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
		}
	}
}
