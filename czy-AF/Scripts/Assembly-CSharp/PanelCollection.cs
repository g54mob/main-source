using System.Collections;
using UnityEngine;

public class PanelCollection : MonoBehaviour
{
	public static Transform collectionFilter;

	public static Transform collectionList;

	private int initialCollection = 3;

	private void Start()
	{
		Panel.SetTarget(base.transform);
		Panel.CreateComponent("collection", "dropdown", new Hashtable
		{
			{
				"list",
				Collections.collectionsList
			},
			{ "value", initialCollection }
		});
		collectionFilter = Panel.CreateComponent("search", "search", new Hashtable { { "placeholder", "All" } });
		collectionList = Panel.CreateComponent("list", "pages", new Hashtable
		{
			{ "fill", true },
			{
				"template",
				Resources.Load<Transform>("Interface/Prefabs/Item")
			}
		});
		Cache.onLoadingComplete += LoadingComplete;
	}

	private void LoadingComplete()
	{
		collectionSelect(initialCollection);
		Tips.Hide();
	}

	private void collectionSelect(int index)
	{
		string text = Collections.collections[index].name;
		if (text == "Recently used" || text == "Favorites")
		{
			Collections.instance.LoadCollectionDynamic(index);
		}
		else
		{
			Collections.instance.LoadCollection(index);
		}
		collectionFilter.GetComponent<ComponentSearch>().Clear();
		Tips.Show("collections");
	}

	private void searchChange(string s)
	{
		ComponentPages component = collectionList.GetComponent<ComponentPages>();
		component.page = 0;
		foreach (Hashtable datum in component.data)
		{
			string text = (string)datum["name"];
			datum["enabled"] = text.ToLower().Contains(s.ToLower());
		}
		component.UpdateDisplay();
	}
}
