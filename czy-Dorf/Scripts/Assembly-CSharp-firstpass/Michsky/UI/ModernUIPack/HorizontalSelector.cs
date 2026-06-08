using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.UI.ModernUIPack
{
	public class HorizontalSelector : MonoBehaviour
	{
		[Serializable]
		public class SelectorEvent : UnityEvent<int>
		{
		}

		[Serializable]
		public class Item
		{
			public string itemTitle = "Item Title";

			public UnityEvent onValueChanged = new UnityEvent();
		}

		public TextMeshProUGUI label;

		public TextMeshProUGUI labelHelper;

		public Transform indicatorParent;

		public GameObject indicatorObject;

		private Animator selectorAnimator;

		private string newItemTitle;

		public bool saveValue;

		public string selectorTag = "Tag Text";

		public bool enableIndicators = true;

		public bool invokeAtStart;

		public bool invertAnimation;

		public bool loopSelection;

		public int defaultIndex;

		public int index;

		public List<Item> itemList = new List<Item>();

		public SelectorEvent selectorEvent;

		private void Start()
		{
			selectorAnimator = base.gameObject.GetComponent<Animator>();
			try
			{
				if (label == null)
				{
					label = base.transform.Find("Text").GetComponent<TextMeshProUGUI>();
				}
				if (labelHelper == null)
				{
					labelHelper = base.transform.Find("Text Helper").GetComponent<TextMeshProUGUI>();
				}
			}
			catch
			{
				Debug.LogError("Horizontal Selector - Cannot initalize the object due to missing resources.", this);
			}
			if (label != null && labelHelper != null)
			{
				SetupSelector();
			}
			if (invokeAtStart)
			{
				itemList[index].onValueChanged.Invoke();
				selectorEvent.Invoke(index);
			}
		}

		public void SetupSelector()
		{
			if (itemList.Count == 0)
			{
				return;
			}
			if (saveValue)
			{
				if (PlayerPrefs.HasKey(selectorTag + "HSelectorValue"))
				{
					defaultIndex = PlayerPrefs.GetInt(selectorTag + "HSelectorValue");
				}
				else
				{
					PlayerPrefs.SetInt(selectorTag + "HSelectorValue", defaultIndex);
				}
			}
			label.text = itemList[defaultIndex].itemTitle;
			labelHelper.text = label.text;
			index = defaultIndex;
			if (enableIndicators)
			{
				foreach (Transform item in indicatorParent)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
				for (int i = 0; i < itemList.Count; i++)
				{
					GameObject obj = UnityEngine.Object.Instantiate(indicatorObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
					obj.transform.SetParent(indicatorParent, worldPositionStays: false);
					obj.name = itemList[i].itemTitle;
					Transform transform = obj.transform.Find("On");
					Transform transform2 = obj.transform.Find("Off");
					if (i == index)
					{
						transform.gameObject.SetActive(value: true);
						transform2.gameObject.SetActive(value: false);
					}
					else
					{
						transform.gameObject.SetActive(value: false);
						transform2.gameObject.SetActive(value: true);
					}
				}
			}
			else
			{
				UnityEngine.Object.Destroy(indicatorParent.gameObject);
			}
		}

		public void PreviousClick()
		{
			if (!loopSelection)
			{
				if (index != 0)
				{
					labelHelper.text = label.text;
					if (index == 0)
					{
						index = itemList.Count - 1;
					}
					else
					{
						index--;
					}
					label.text = itemList[index].itemTitle;
					try
					{
						itemList[index].onValueChanged.Invoke();
					}
					catch
					{
					}
					selectorEvent.Invoke(index);
					selectorAnimator.Play(null);
					selectorAnimator.StopPlayback();
					if (invertAnimation)
					{
						selectorAnimator.Play("Forward");
					}
					else
					{
						selectorAnimator.Play("Previous");
					}
					if (saveValue)
					{
						PlayerPrefs.SetInt(selectorTag + "HSelectorValue", index);
					}
				}
			}
			else
			{
				labelHelper.text = label.text;
				if (index == 0)
				{
					index = itemList.Count - 1;
				}
				else
				{
					index--;
				}
				label.text = itemList[index].itemTitle;
				try
				{
					itemList[index].onValueChanged.Invoke();
				}
				catch
				{
				}
				selectorEvent.Invoke(index);
				selectorAnimator.Play(null);
				selectorAnimator.StopPlayback();
				if (invertAnimation)
				{
					selectorAnimator.Play("Forward");
				}
				else
				{
					selectorAnimator.Play("Previous");
				}
				if (saveValue)
				{
					PlayerPrefs.SetInt(selectorTag + "HSelectorValue", index);
				}
			}
			if (saveValue)
			{
				PlayerPrefs.SetInt(selectorTag + "HSelectorValue", index);
			}
			if (!enableIndicators)
			{
				return;
			}
			for (int i = 0; i < itemList.Count; i++)
			{
				GameObject obj3 = indicatorParent.GetChild(i).gameObject;
				Transform transform = obj3.transform.Find("On");
				Transform transform2 = obj3.transform.Find("Off");
				if (i == index)
				{
					transform.gameObject.SetActive(value: true);
					transform2.gameObject.SetActive(value: false);
				}
				else
				{
					transform.gameObject.SetActive(value: false);
					transform2.gameObject.SetActive(value: true);
				}
			}
		}

		public void ForwardClick()
		{
			if (!loopSelection)
			{
				if (index != itemList.Count - 1)
				{
					labelHelper.text = label.text;
					if (index + 1 >= itemList.Count)
					{
						index = 0;
					}
					else
					{
						index++;
					}
					label.text = itemList[index].itemTitle;
					try
					{
						itemList[index].onValueChanged.Invoke();
					}
					catch
					{
					}
					selectorEvent.Invoke(index);
					selectorAnimator.Play(null);
					selectorAnimator.StopPlayback();
					if (invertAnimation)
					{
						selectorAnimator.Play("Previous");
					}
					else
					{
						selectorAnimator.Play("Forward");
					}
					if (saveValue)
					{
						PlayerPrefs.SetInt(selectorTag + "HSelectorValue", index);
					}
				}
			}
			else
			{
				labelHelper.text = label.text;
				if (index + 1 >= itemList.Count)
				{
					index = 0;
				}
				else
				{
					index++;
				}
				label.text = itemList[index].itemTitle;
				try
				{
					itemList[index].onValueChanged.Invoke();
				}
				catch
				{
				}
				selectorEvent.Invoke(index);
				selectorAnimator.Play(null);
				selectorAnimator.StopPlayback();
				if (invertAnimation)
				{
					selectorAnimator.Play("Previous");
				}
				else
				{
					selectorAnimator.Play("Forward");
				}
				if (saveValue)
				{
					PlayerPrefs.SetInt(selectorTag + "HSelectorValue", index);
				}
			}
			if (saveValue)
			{
				PlayerPrefs.SetInt(selectorTag + "HSelectorValue", index);
			}
			if (!enableIndicators)
			{
				return;
			}
			for (int i = 0; i < itemList.Count; i++)
			{
				GameObject obj3 = indicatorParent.GetChild(i).gameObject;
				Transform transform = obj3.transform.Find("On");
				Transform transform2 = obj3.transform.Find("Off");
				if (i == index)
				{
					transform.gameObject.SetActive(value: true);
					transform2.gameObject.SetActive(value: false);
				}
				else
				{
					transform.gameObject.SetActive(value: false);
					transform2.gameObject.SetActive(value: true);
				}
			}
		}

		public void CreateNewItem(string title)
		{
			Item item = new Item();
			newItemTitle = title;
			item.itemTitle = newItemTitle;
			itemList.Add(item);
		}

		public void AddNewItem()
		{
			Item item = new Item();
			itemList.Add(item);
		}

		public void UpdateUI()
		{
			label.text = itemList[index].itemTitle;
			if (!enableIndicators)
			{
				return;
			}
			foreach (Transform item in indicatorParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < itemList.Count; i++)
			{
				GameObject obj = UnityEngine.Object.Instantiate(indicatorObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				obj.transform.SetParent(indicatorParent, worldPositionStays: false);
				obj.name = itemList[i].itemTitle;
				Transform transform = obj.transform.Find("On");
				Transform transform2 = obj.transform.Find("Off");
				if (i == index)
				{
					transform.gameObject.SetActive(value: true);
					transform2.gameObject.SetActive(value: false);
				}
				else
				{
					transform.gameObject.SetActive(value: false);
					transform2.gameObject.SetActive(value: true);
				}
			}
		}
	}
}
