using System.Collections.Generic;
using UnityEngine;

public class ItemPane : MonoBehaviour
{
	public GameObject scrollArrowTop;

	public GameObject scrollBubTop;

	public GameObject scrollBubMid;

	public GameObject scrollBubBot;

	public GameObject scrollArrowBot;

	public GameObject tabs;

	public GameObject itemBoxes;

	private ItemType currentTab;

	private int numElements = 3;

	private int loadedElements;

	private List<GameObject> scrollList = new List<GameObject>();

	private ScalableUIContainer.LoadCallback callback;

	private float paneScaleInTime = 0.15f;

	private float paneScaleOutTime = 0.15f;

	private float scrollScaleInTime = 0.05f;

	private float scrollScaleOutTime = 0.05f;

	private Vector3 enabledScrollObjectScale = Vector3.one;

	private Vector3 disabledScrollObjectScale = new Vector3(0.5f, 0.5f, 0.5f);

	private Inchworm inchwormRef;

	public void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		scrollList.Clear();
		scrollList.Add(scrollArrowBot);
		scrollList.Add(scrollBubBot);
		scrollList.Add(scrollBubMid);
		scrollList.Add(scrollBubTop);
		scrollList.Add(scrollArrowTop);
		for (int i = 0; i < scrollList.Count; i++)
		{
			scrollList[i].transform.localScale = Vector3.zero;
		}
		callback = loadCallback;
		itemBoxes.GetComponent<ItemBoxes>().Preload();
		itemBoxes.GetComponent<ItemBoxes>().SetItemType(currentTab, refreshBoxes: false);
		Vector3 localScale = base.gameObject.transform.localScale;
		base.gameObject.transform.localScale = Vector3.zero;
		inchwormRef.RequestEaseToScale(base.gameObject, localScale, paneScaleInTime, Inchworm.EaseStyle.QuadraticOut, OnPaneLoadedCallback);
	}

	public void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		callback = unloadCallback;
		scrollList.Add(scrollArrowTop);
		scrollList.Add(scrollBubTop);
		scrollList.Add(scrollBubMid);
		scrollList.Add(scrollBubBot);
		scrollList.Add(scrollArrowBot);
		UnloadScroll();
		UnloadTabs();
		UnloadBoxes();
	}

	public void UpdateCurrentTab(ItemType newTabType)
	{
		currentTab = newTabType;
		itemBoxes.GetComponent<ItemBoxes>().SetItemType(currentTab);
	}

	public void ToggleScrollUp(bool toggleVal)
	{
		if (toggleVal)
		{
			scrollArrowTop.transform.localScale = enabledScrollObjectScale;
			Clickable component = scrollArrowTop.GetComponent<Clickable>();
			if (component == null)
			{
				component = scrollArrowTop.AddComponent<Clickable>();
				component.SetClickCallbackTime(Clickable.CallbackTime.CLICK_END);
				component.SetClickCallbacks(itemBoxes.GetComponent<ItemBoxes>().ScrollUp);
			}
		}
		else
		{
			Clickable component = scrollArrowTop.GetComponent<Clickable>();
			if (component != null)
			{
				component.ForceCancelEase();
				Object.Destroy(component);
			}
			scrollArrowTop.transform.localScale = disabledScrollObjectScale;
		}
	}

	public void ToggleScrollDown(bool toggleVal)
	{
		if (toggleVal)
		{
			scrollArrowBot.transform.localScale = enabledScrollObjectScale;
			Clickable component = scrollArrowBot.GetComponent<Clickable>();
			if (component == null)
			{
				component = scrollArrowBot.AddComponent<Clickable>();
				component.SetClickCallbackTime(Clickable.CallbackTime.CLICK_END);
				component.SetClickCallbacks(itemBoxes.GetComponent<ItemBoxes>().ScrollDown);
			}
		}
		else
		{
			Clickable component = scrollArrowBot.GetComponent<Clickable>();
			if (component != null)
			{
				component.ForceCancelEase();
				Object.Destroy(component);
			}
			scrollArrowBot.transform.localScale = disabledScrollObjectScale;
		}
	}

	public void ToggleBubs(bool toggleVal)
	{
		if (toggleVal)
		{
			scrollBubTop.transform.localScale = enabledScrollObjectScale;
			scrollBubMid.transform.localScale = enabledScrollObjectScale;
			scrollBubBot.transform.localScale = enabledScrollObjectScale;
		}
		else
		{
			scrollBubTop.transform.localScale = disabledScrollObjectScale;
			scrollBubMid.transform.localScale = disabledScrollObjectScale;
			scrollBubBot.transform.localScale = disabledScrollObjectScale;
		}
	}

	private void OnPaneLoadedCallback()
	{
		LoadTabs();
		LoadScroll();
		LoadBoxes();
	}

	private void OnPaneUnloadedCallback()
	{
		OnUnloadComplete();
	}

	private void LoadScroll()
	{
		if (scrollList.Count == 0)
		{
			OnElementLoaded();
			return;
		}
		GameObject objectToScale = scrollList[0];
		scrollList.RemoveAt(0);
		inchwormRef.RequestEaseToScale(objectToScale, Vector3.one, scrollScaleInTime, Inchworm.EaseStyle.QuadraticOut, LoadScroll);
	}

	private void LoadTabs()
	{
		tabs.GetComponent<ItemTabs>().Load(OnElementLoaded);
	}

	private void LoadBoxes()
	{
		itemBoxes.GetComponent<ItemBoxes>().Load(OnElementLoaded);
	}

	private void UnloadTabs()
	{
		tabs.GetComponent<ItemTabs>().Unload(OnElementUnloaded);
	}

	private void UnloadBoxes()
	{
		itemBoxes.GetComponent<ItemBoxes>().Unload(OnElementUnloaded);
	}

	private void UnloadScroll()
	{
		if (scrollList.Count == 0)
		{
			OnElementUnloaded();
			return;
		}
		Clickable component = scrollArrowTop.GetComponent<Clickable>();
		if (component != null)
		{
			component.ForceCancelEase();
			Object.Destroy(component);
		}
		component = scrollArrowBot.GetComponent<Clickable>();
		if (component != null)
		{
			component.ForceCancelEase();
			Object.Destroy(component);
		}
		GameObject objectToScale = scrollList[0];
		scrollList.RemoveAt(0);
		inchwormRef.RequestEaseToScale(objectToScale, Vector3.zero, scrollScaleOutTime, Inchworm.EaseStyle.QuadraticOut, UnloadScroll);
	}

	private void OnElementLoaded()
	{
		loadedElements++;
		if (loadedElements >= numElements)
		{
			OnLoadComplete();
		}
	}

	private void OnElementUnloaded()
	{
		loadedElements--;
		if (loadedElements <= 0)
		{
			inchwormRef.RequestEaseToScale(base.gameObject, Vector3.zero, paneScaleOutTime, Inchworm.EaseStyle.QuadraticOut, OnPaneUnloadedCallback);
		}
	}

	private void OnLoadComplete()
	{
		callback();
		callback = null;
		itemBoxes.GetComponent<ItemBoxes>().UpdateScrolling();
	}

	private void OnUnloadComplete()
	{
		callback();
		callback = null;
	}
}
