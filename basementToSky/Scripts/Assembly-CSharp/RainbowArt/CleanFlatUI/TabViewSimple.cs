using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
		private TabViewSimpleEvent onValueChanged = new TabViewSimpleEvent();

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

		public TabViewSimpleEvent OnValueChanged
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
			InitTabViewSimples();
		}

		private void OnDisable()
		{
			for (int i = 0; i < TabViewSimples.Length; i++)
			{
				TabViewSimples[i].tab.GetComponent<Toggle>().onValueChanged.RemoveAllListeners();
			}
		}

		public void InitTabViewSimples()
		{
			SetCurrentIndex(startIndex);
			onValueChanged.Invoke(currentIndex);
			for (int i = 0; i < TabViewSimples.Length; i++)
			{
				int index = i;
				Toggle component = TabViewSimples[i].tab.GetComponent<Toggle>();
				component.onValueChanged.RemoveAllListeners();
				component.onValueChanged.AddListener(delegate(bool value)
				{
					TabValueChanged(index, value);
				});
			}
		}

		private void SetCurrentIndex(int newCurrentIndex)
		{
			for (int i = 0; i < TabViewSimples.Length; i++)
			{
				TabViewSimpleItem tabViewSimpleItem = TabViewSimples[i];
				Toggle component = tabViewSimpleItem.tab.GetComponent<Toggle>();
				if (i == newCurrentIndex)
				{
					component.SetIsOnWithoutNotify(value: true);
					CanvasGroup component2 = tabViewSimpleItem.view.GetComponent<CanvasGroup>();
					SetCanvasGroupAlpha(component2, 1f);
					tabViewSimpleItem.tab.GetComponent<TabSimple>().SetTabOn(bOn: true);
				}
				else
				{
					component.SetIsOnWithoutNotify(value: false);
					CanvasGroup component3 = tabViewSimpleItem.view.GetComponent<CanvasGroup>();
					SetCanvasGroupAlpha(component3, 0f);
					tabViewSimpleItem.tab.GetComponent<TabSimple>().UpdateStatusContent();
				}
			}
			currentIndex = newCurrentIndex;
		}

		public void TabValueChanged(int index, bool value)
		{
			TabViewSimpleItem tabViewSimpleItem = TabViewSimples[index];
			Toggle component = tabViewSimpleItem.tab.GetComponent<Toggle>();
			tabViewSimpleItem.tab.GetComponent<Tab>();
			if (component.isOn)
			{
				currentIndex = index;
				onValueChanged.Invoke(currentIndex);
				CanvasGroup component2 = tabViewSimpleItem.view.GetComponent<CanvasGroup>();
				SetCanvasGroupAlpha(component2, 1f);
				tabViewSimpleItem.tab.GetComponent<TabSimple>().SetTabOn(bOn: true);
			}
			else
			{
				CanvasGroup component3 = tabViewSimpleItem.view.GetComponent<CanvasGroup>();
				SetCanvasGroupAlpha(component3, 0f);
				tabViewSimpleItem.tab.GetComponent<TabSimple>().SetTabOn(bOn: false);
			}
		}

		private void SetCanvasGroupAlpha(CanvasGroup obj, float alpha)
		{
			obj.alpha = alpha;
		}
	}
}
