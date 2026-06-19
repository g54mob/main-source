using System.Collections.Generic;
using UnityEngine;

public class ItemTabs : MonoBehaviour
{
	public GameObject tab_01;

	public GameObject tab_02;

	public GameObject tab_03;

	public List<ItemType> typeOrder = new List<ItemType>();

	private int activeTab;

	private int tabToSwitchTo;

	private int loadedTabIndex;

	private List<GameObject> itemTabs = new List<GameObject>();

	private int clickablesToUnload;

	private int clickablesToEase;

	private bool needsUnload;

	private bool switchingTabs;

	private ScalableUIContainer.LoadCallback callback;

	private float slideInTime = 0.35f;

	private float slideOutTime = 0.35f;

	private float tabSwitchTime = 0.05f;

	private bool needsDelayedEaseIn;

	private bool needsDelayedEaseOut;

	private float currentOffset;

	private float slideInOffset = 0.05f;

	private float slideOutOffset = 0.05f;

	private Vector3 easeVector = new Vector3(0f, -3f, 0f);

	private Vector3 inactiveOffset = new Vector3(0f, 0.3f, 0f);

	private Inchworm inchwormRef;

	private void Awake()
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		LoadTabsList();
		tab_01.SetActive(value: false);
		tab_02.SetActive(value: false);
		tab_03.SetActive(value: false);
	}

	private void Update()
	{
		CheckDelayedEases();
		if (needsUnload && !switchingTabs)
		{
			UnloadNextTab();
		}
	}

	private void LoadTabsList()
	{
		itemTabs.Add(tab_01);
		itemTabs.Add(tab_02);
		itemTabs.Add(tab_03);
	}

	private void CheckDelayedEases()
	{
		if (needsDelayedEaseIn)
		{
			currentOffset += Time.deltaTime;
			if (currentOffset >= slideInOffset)
			{
				LoadNextTab();
			}
		}
		else if (needsDelayedEaseOut)
		{
			currentOffset += Time.deltaTime;
			if (currentOffset >= slideOutOffset)
			{
				UnloadNextTab();
			}
		}
	}

	public void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		needsDelayedEaseIn = true;
		callback = loadCallback;
		LoadNextTab();
	}

	public void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		LoadTabsList();
		needsDelayedEaseOut = true;
		callback = unloadCallback;
		UnloadNextTab();
	}

	private void LoadNextTab()
	{
		List<GameObject> objectsToEase = new List<GameObject> { itemTabs[loadedTabIndex] };
		itemTabs[loadedTabIndex].SetActive(value: true);
		if (loadedTabIndex != activeTab)
		{
			itemTabs[loadedTabIndex].transform.localPosition -= inactiveOffset;
		}
		loadedTabIndex++;
		currentOffset = 0f;
		if (loadedTabIndex >= itemTabs.Count)
		{
			needsDelayedEaseIn = false;
			inchwormRef.RequestEase(objectsToEase, -easeVector, slideInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnLoadComplete, Inchworm.EasePriority.Normal, keepSameParent: true);
		}
		else
		{
			inchwormRef.RequestEase(objectsToEase, -easeVector, slideInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, null, Inchworm.EasePriority.Normal, keepSameParent: true);
		}
	}

	private void UnloadNextTab()
	{
		if (switchingTabs)
		{
			needsUnload = true;
			return;
		}
		needsUnload = false;
		loadedTabIndex--;
		List<GameObject> objectsToEase = new List<GameObject> { itemTabs[loadedTabIndex] };
		Clickable component = itemTabs[loadedTabIndex].GetComponent<Clickable>();
		if (component != null)
		{
			component.Unload();
		}
		currentOffset = 0f;
		if (loadedTabIndex <= 0)
		{
			needsDelayedEaseOut = false;
			inchwormRef.RequestEase(objectsToEase, easeVector, slideOutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnUnloadComplete, Inchworm.EasePriority.Normal, keepSameParent: true);
		}
		else
		{
			inchwormRef.RequestEase(objectsToEase, easeVector, slideOutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, null, Inchworm.EasePriority.Normal, keepSameParent: true);
		}
	}

	private void OnTabClicked(int i)
	{
		SetActiveTab(i);
	}

	private void ShowAppropriateItems(int index)
	{
		GetComponentInParent<ItemPane>().UpdateCurrentTab(typeOrder[index]);
	}

	private void SetActiveTab(int index)
	{
		if (index == activeTab)
		{
			return;
		}
		ShowAppropriateItems(index);
		switchingTabs = true;
		tabToSwitchTo = index;
		clickablesToUnload = itemTabs.Count - 1;
		for (int i = 0; i < itemTabs.Count; i++)
		{
			Clickable component = itemTabs[i].GetComponent<Clickable>();
			if (component != null)
			{
				component.DelayedUnload(OnTabClickableStopped);
			}
			if (i == tabToSwitchTo)
			{
				itemTabs[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
			}
			else
			{
				itemTabs[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = -i - 1;
			}
		}
	}

	private void OnTabClickableStopped()
	{
		clickablesToUnload--;
		if (clickablesToUnload != 0)
		{
			return;
		}
		for (int i = 0; i < itemTabs.Count; i++)
		{
			Clickable component = itemTabs[i].GetComponent<Clickable>();
			if (component != null)
			{
				component.Unload();
				Object.Destroy(component);
			}
		}
		int num = activeTab;
		activeTab = tabToSwitchTo;
		clickablesToEase = 2;
		for (int j = 0; j < itemTabs.Count; j++)
		{
			if (j == num || j == tabToSwitchTo)
			{
				List<GameObject> list = new List<GameObject>();
				list.Add(itemTabs[j]);
				Vector3 position = itemTabs[j].transform.position;
				itemTabs[j].transform.localPosition = new Vector3(itemTabs[j].transform.localPosition.x, 0f - inactiveOffset.y, itemTabs[j].transform.localPosition.z);
				Vector3 vector = position - itemTabs[j].transform.position;
				itemTabs[j].transform.position = position;
				if (j == num)
				{
					inchwormRef.RequestEase(list, -vector, tabSwitchTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnTabSwitched, Inchworm.EasePriority.Normal, keepSameParent: true);
				}
				else
				{
					inchwormRef.RequestEase(list, vector, tabSwitchTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnTabSwitched, Inchworm.EasePriority.Normal, keepSameParent: true);
				}
			}
		}
	}

	private void OnTabSwitched()
	{
		clickablesToEase--;
		if (clickablesToEase == 0)
		{
			AddClickables();
			switchingTabs = false;
		}
	}

	private void AddClickables()
	{
		for (int i = 0; i < itemTabs.Count; i++)
		{
			if (i != activeTab)
			{
				Clickable clickable = itemTabs[i].AddComponent<Clickable>();
				clickable.SetClickCallbacks(null, OnTabClicked, null, null, i);
				clickable.SetInteractType(Clickable.InteractType.SLIDE);
			}
		}
	}

	private void OnLoadComplete()
	{
		AddClickables();
		needsDelayedEaseIn = false;
		callback();
		callback = null;
	}

	private void OnUnloadComplete()
	{
		needsDelayedEaseOut = false;
		callback();
		callback = null;
	}
}
