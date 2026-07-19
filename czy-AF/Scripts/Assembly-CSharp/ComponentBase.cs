using System.Collections;
using UnityEngine;

public class ComponentBase : MonoBehaviour
{
	public Panel panel;

	public GameObject callback;

	public string type;

	public Hashtable data = new Hashtable();

	public object GetData(string d, object def = null)
	{
		if (data.ContainsKey(d))
		{
			return data[d];
		}
		return def;
	}

	public void Callback(Transform source)
	{
		if (callback == null)
		{
			panel.gameObject.SendMessage(source.name + "Callback", source, SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			callback.SendMessage(source.name + "Callback", source, SendMessageOptions.DontRequireReceiver);
		}
	}

	public void Callback(string name, object data, Transform source)
	{
		Panel.caller = source;
		if (!(panel == null))
		{
			if (callback == null)
			{
				panel.gameObject.SendMessage(name, data, SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				callback.SendMessage(name, data, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
