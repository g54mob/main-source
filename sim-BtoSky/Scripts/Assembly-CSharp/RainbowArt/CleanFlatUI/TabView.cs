using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
		private TabViewEvent onValueChanged = new TabViewEvent();

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
					SetCurrentIndex(value);
					onValueChanged.Invoke(currentIndex);
				}
			}
		}

		public TabViewEvent OnValueChanged
		{
			get
			{
				return onValueChanged;
			}
			set
			{
				onValueChanged = value;
			}
		}

		private void OnEnable()
		{
			InitAnimators();
			InitTabViews();
		}

		private void OnDisable()
		{
			for (int i = 0; i < tabViews.Length; i++)
			{
				tabViews[i].tab.GetComponent<Toggle>().onValueChanged.RemoveAllListeners();
			}
		}

		private void InitAnimators()
		{
			for (int i = 0; i < tabViews.Length; i++)
			{
				Animator component = tabViews[i].view.GetComponent<Animator>();
				ResetAnimation(component);
			}
		}

		public void InitTabViews()
		{
			SetCurrentIndex(startIndex);
			onValueChanged.Invoke(currentIndex);
			for (int i = 0; i < tabViews.Length; i++)
			{
				int index = i;
				Toggle component = tabViews[i].tab.GetComponent<Toggle>();
				component.onValueChanged.RemoveAllListeners();
				component.onValueChanged.AddListener(delegate(bool value)
				{
					TabValueChanged(index, value);
				});
			}
		}

		private void SetCurrentIndex(int newCurrentIndex)
		{
			for (int i = 0; i < tabViews.Length; i++)
			{
				TabViewItem tabViewItem = tabViews[i];
				Toggle component = tabViewItem.tab.GetComponent<Toggle>();
				if (i == newCurrentIndex)
				{
					component.SetIsOnWithoutNotify(value: true);
					Animator component2 = tabViewItem.tab.GetComponent<Animator>();
					Animator component3 = tabViewItem.view.GetComponent<Animator>();
					tabViewItem.view.SetActive(value: true);
					StartCoroutine(ForceScrollToTop(tabViewItem.view.GetComponentInChildren<ScrollRect>()));
					PlayAnimation(component2, "On Init");
					PlayAnimation(component3, "Init");
				}
				else
				{
					component.SetIsOnWithoutNotify(value: false);
					tabViewItem.view.SetActive(value: false);
					tabViewItem.tab.GetComponent<Tab>().UpdateStatusContent();
				}
			}
			currentIndex = newCurrentIndex;
		}

		public void TabValueChanged(int index, bool value)
		{
			TabViewItem tabViewItem = tabViews[index];
			Toggle component = tabViewItem.tab.GetComponent<Toggle>();
			tabViewItem.tab.GetComponent<Tab>();
			Animator component2 = tabViewItem.tab.GetComponent<Animator>();
			Animator component3 = tabViewItem.view.GetComponent<Animator>();
			if (component.isOn)
			{
				currentIndex = index;
				onValueChanged.Invoke(currentIndex);
				tabViewItem.view.SetActive(value: true);
				StartCoroutine(ForceScrollToTop(tabViewItem.view.GetComponentInChildren<ScrollRect>()));
				PlayAnimation(component2, "On");
				PlayAnimation(component3, "On");
			}
			else
			{
				tabViewItem.view.SetActive(value: false);
				PlayAnimation(component2, "Off");
				ResetAnimation(component3);
			}
		}

		private void PlayAnimation(Animator animator, string animStr)
		{
			if (animator != null)
			{
				if (!animator.enabled)
				{
					animator.enabled = true;
				}
				animator.Play(animStr, 0, 0f);
			}
		}

		private void ResetAnimation(Animator animator)
		{
			if (animator != null)
			{
				animator.enabled = false;
			}
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
			obj.alpha = alpha;
		}

		private IEnumerator ForceScrollToTop(ScrollRect scrollRect)
		{
			yield return null;
			yield return null;
			scrollRect.verticalNormalizedPosition = 1f;
			Canvas.ForceUpdateCanvases();
		}
	}
}
