using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EventWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GameObject ContentPanel;

	public GameObject EventElementPrefab;

	public List<EventElement> Events = new List<EventElement>();

	public Image ButtonIcon;

	public Color Important;

	public Color NotImportant;

	public void UpdateEvents()
	{
	}

	private void AddEventElement(string icon, string desc)
	{
		EventElement component = Object.Instantiate(EventElementPrefab).GetComponent<EventElement>();
		component.Icon = icon;
		component.Description.text = desc;
		component.transform.SetParent(ContentPanel.transform, false);
		Events.Add(component);
	}

	public void Serialize(WriteDictionary result)
	{
		result["UpEvents"] = Events.Select((EventElement x) => new string[2]
		{
			x.Icon,
			x.Description.text
		}).ToArray();
	}

	public void Deserialize(WriteDictionary result)
	{
		foreach (EventElement @event in Events)
		{
			Object.Destroy(@event.gameObject);
		}
		Events.Clear();
		string[][] array = result.Get("UpEvents", new string[0][]);
		foreach (string[] array2 in array)
		{
			AddEventElement(array2[0], array2[1]);
		}
	}
}
