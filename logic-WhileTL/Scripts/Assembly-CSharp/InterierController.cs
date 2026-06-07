using System.Collections.Generic;
using App.Data;
using UnityEngine;

public class InterierController : ActiveComponent
{
	private Dictionary<int, List<GameObject>> interierObjects = new Dictionary<int, List<GameObject>>();

	private List<string> interierTags = new List<string>();

	[SceneBind("table/Chair")]
	private TechUIShowController techUIShowController;

	protected override void OnInit()
	{
		foreach (InteriorItem shopItem in ActiveComponent._staticData.ShopItems)
		{
			if (!interierTags.Contains(shopItem.Tag))
			{
				interierTags.Add(shopItem.Tag);
			}
		}
		foreach (UpgradeStats pCUpgrade in ActiveComponent._staticData.PCUpgrades)
		{
			if (!interierTags.Contains(pCUpgrade.Tag))
			{
				interierTags.Add(pCUpgrade.Tag);
			}
		}
		foreach (DateEvent dateEvent in ActiveComponent._staticData.DateEvents)
		{
			if (!interierTags.Contains(dateEvent.KeyName))
			{
				interierTags.Add(dateEvent.KeyName);
			}
		}
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		techUIShowController.Init();
		Transform[] componentsInChildren = base.transform.GetComponentsInChildren<Transform>();
		foreach (Transform transform in componentsInChildren)
		{
			if (interierTags.Contains(transform.tag))
			{
				if (!interierObjects.ContainsKey((transform.name + transform.tag).GetHashCode()))
				{
					interierObjects.Add((transform.name + transform.tag).GetHashCode(), new List<GameObject>());
				}
				interierObjects[(transform.name + transform.tag).GetHashCode()].Add(transform.gameObject);
				if (transform != base.transform && transform.gameObject.GetComponent<ActiveComponent>() != null)
				{
					transform.gameObject.GetComponent<ActiveComponent>().Init();
				}
			}
		}
		foreach (KeyValuePair<int, List<GameObject>> interierObject in interierObjects)
		{
			foreach (GameObject item in interierObject.Value)
			{
				item.SetActive(value: false);
			}
		}
		ActiveDataEvent();
	}

	private void ActiveDataEvent()
	{
		DateEvent curDateEvent = Logic.GetCurDateEvent();
		if (curDateEvent == null)
		{
			return;
		}
		foreach (KeyValuePair<int, List<GameObject>> interierObject in interierObjects)
		{
			foreach (GameObject item in interierObject.Value)
			{
				if (item.tag == curDateEvent.KeyName)
				{
					item.gameObject.SetActive(value: true);
				}
			}
		}
	}

	private void ActiveItemWithTag(string Tag, string keyName)
	{
		int hashCode = (keyName + Tag).GetHashCode();
		int hashCode2 = Tag.GetHashCode();
		foreach (KeyValuePair<int, List<GameObject>> interierObject in interierObjects)
		{
			if (interierObject.Value[0].tag.GetHashCode() != hashCode2)
			{
				continue;
			}
			foreach (GameObject item in interierObject.Value)
			{
				item.SetActive(value: false);
			}
		}
		if (interierObjects.ContainsKey(hashCode))
		{
			foreach (GameObject item2 in interierObjects[hashCode])
			{
				item2.SetActive(value: true);
			}
			return;
		}
		DisableDefaultsWithTag(Tag);
		int hashCode3 = (Logic.GetDefaultTag() + Tag).GetHashCode();
		if (!interierObjects.ContainsKey(hashCode3))
		{
			return;
		}
		foreach (GameObject item3 in interierObjects[hashCode3])
		{
			item3.SetActive(value: true);
		}
	}

	private void SetStateWithHash(int defhash, bool state)
	{
		if (!interierObjects.ContainsKey(defhash))
		{
			return;
		}
		foreach (GameObject item in interierObjects[defhash])
		{
			item.SetActive(state);
		}
	}

	private void DisableDefaultsWithTag(string Tag)
	{
		int hashCode = ("DEFAULT" + Tag).GetHashCode();
		SetStateWithHash(hashCode, state: false);
		foreach (DateEvent dateEvent in ActiveComponent._staticData.DateEvents)
		{
			hashCode = (dateEvent.KeyName + Tag).GetHashCode();
			SetStateWithHash(hashCode, state: false);
		}
	}

	public void Redraw()
	{
		techUIShowController.Redraw();
		foreach (string interierTag in interierTags)
		{
			Redraw(interierTag, Logic.GetDefaultTag());
		}
		foreach (InteriorItem shopItem in ActiveComponent._staticData.ShopItems)
		{
			string keyName = shopItem.KeyName;
			if (ActiveComponent.Model.P.activeInterierItem.ContainsKey(keyName) && ActiveComponent.Model.P.activeInterierItem[keyName] == 1)
			{
				Redraw(shopItem.Tag, shopItem.KeyName);
			}
		}
		foreach (UpgradeStats unlockedUpgrade in ActiveComponent.Model.P.unlockedUpgrades)
		{
			string keyName2 = unlockedUpgrade.KeyName;
			if (ActiveComponent.Model.P.activeInterierItem.ContainsKey(keyName2) && ActiveComponent.Model.P.activeInterierItem[keyName2] == 1)
			{
				Redraw(unlockedUpgrade.Tag, unlockedUpgrade.KeyName);
			}
		}
		ActiveDataEvent();
	}

	public void Redraw(string Tag, string keyName)
	{
		ActiveItemWithTag(Tag, keyName);
	}
}
