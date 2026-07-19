using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
	public enum Orientation
	{
		Horizontal = 0,
		Vertical = 1
	}

	[Header("Settings")]
	public Skin.Style style;

	public Orientation orientation = Orientation.Vertical;

	private int margin = 6;

	private float offset;

	private Vector2 offsetVector;

	private Dictionary<string, Transform> content = new Dictionary<string, Transform>();

	public static Panel target;

	public static Transform caller;

	public static Panel SetTarget(Panel p)
	{
		target = p;
		return p;
	}

	public static Panel SetTarget(Transform t)
	{
		target = t.GetComponent<Panel>();
		return target;
	}

	public static Transform CreateComponent(string name, string component, Hashtable options)
	{
		if (options["label"] != null)
		{
			CreateComponent(name + "_label", "label", new Hashtable
			{
				{
					"text",
					options["label"] as string
				},
				{ "margin", true }
			});
		}
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Interface/Components/Component" + component), target.transform);
		gameObject.name = name;
		if (!target.content.ContainsKey(gameObject.name))
		{
			target.content.Add(gameObject.name, gameObject.transform);
		}
		if ((bool)gameObject.GetComponent<ComponentBase>())
		{
			ComponentBase component2 = gameObject.GetComponent<ComponentBase>();
			component2.panel = target;
			component2.type = component;
			if (options["callback"] != null)
			{
				component2.callback = (GameObject)options["callback"];
			}
			component2.data = options;
		}
		RectTransform component3 = gameObject.GetComponent<RectTransform>();
		if (target.orientation == Orientation.Horizontal)
		{
			component3.anchoredPosition = new Vector2(target.offsetVector.x, 0f);
			component3.anchorMin = new Vector2(0f, 1f);
			component3.anchorMax = new Vector2(0f, 1f);
			component3.pivot = new Vector2(0f, 1f);
			int num = 100;
			if (options["width"] != null)
			{
				num = (int)options["width"];
			}
			component3.sizeDelta = new Vector2(num, 24f);
			target.offsetVector.x += num + target.margin;
		}
		else
		{
			component3.anchoredPosition = new Vector2(0f, 0f - target.offsetVector.y);
			float x = 0f;
			if (options["label"] != null)
			{
				x = 0.35f;
			}
			if (options["horizontal"] != null)
			{
				x = (float)options["horizontal"];
			}
			if (options["fill"] == null)
			{
				component3.anchorMin = new Vector2(x, 1f);
				component3.anchorMax = new Vector2(1f, 1f);
				component3.pivot = new Vector2(0f, 1f);
			}
			else
			{
				component3.anchorMin = new Vector2(0f, 0f);
				component3.anchorMax = new Vector2(1f, 1f);
				component3.pivot = new Vector2(0.5f, 0.5f);
				component3.offsetMin = new Vector2(0f, 0f);
				component3.offsetMax = new Vector2(0f, 0f - target.offsetVector.y);
			}
			if (options["margin"] == null)
			{
				target.offsetVector.y += component3.sizeDelta.y + (float)target.margin;
			}
		}
		if (options["height"] != null)
		{
			component3.sizeDelta = new Vector2(component3.sizeDelta.x, (int)options["height"]);
		}
		gameObject.SendMessage("SetData", options, SendMessageOptions.DontRequireReceiver);
		if (options["value"] != null)
		{
			target.SetValue(gameObject.name, options["value"]);
		}
		if (options["restrict"] != null)
		{
			gameObject.GetComponent<InputField>().contentType = (InputField.ContentType)options["restrict"];
		}
		if (options["placeholder"] != null)
		{
			gameObject.transform.Find("placeholder").GetComponent<Text>().text = (string)options["placeholder"];
		}
		if (options["list"] != null)
		{
			gameObject.SendMessage("SetList", (List<string>)options["list"]);
		}
		if (options["size"] != null)
		{
			gameObject.SendMessage("SetSize", (float)options["size"]);
		}
		if (options["visible"] != null)
		{
			gameObject.SetActive((bool)options["visible"]);
		}
		if (options["template"] != null)
		{
			if (component == "pages")
			{
				gameObject.GetComponent<ComponentPages>().SetTemplate((Transform)options["template"]);
			}
			if (component == "list")
			{
				gameObject.GetComponent<ComponentList>().SetTemplate((Transform)options["template"]);
			}
		}
		if (options["modifier"] != null && component == "input")
		{
			gameObject.transform.Find("modifier").GetComponent<Text>().text = (string)options["modifier"];
		}
		if (options["tooltip"] != null)
		{
			Button componentInChildren = gameObject.GetComponentInChildren<Button>();
			if (componentInChildren != null)
			{
				componentInChildren.gameObject.AddComponent<Tooltip>().tip = (string)options["tooltip"];
			}
			RawImage componentInChildren2 = gameObject.GetComponentInChildren<RawImage>();
			if (componentInChildren2 != null)
			{
				componentInChildren2.gameObject.AddComponent<Tooltip>().tip = (string)options["tooltip"];
			}
		}
		if (component == "label" || component == "button")
		{
			gameObject.transform.GetComponentsInChildren<Text>()[0].text = options["text"] as string;
		}
		gameObject.SendMessage("Prepare", SendMessageOptions.DontRequireReceiver);
		if (target.style != Skin.Style.Default)
		{
			Skin[] componentsInChildren = gameObject.GetComponentsInChildren<Skin>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].SetSkin(target.style);
			}
		}
		return gameObject.transform;
	}

	public void SetValue(string target, object value)
	{
		if (!content.ContainsKey(target))
		{
			return;
		}
		string type = content[target].GetComponent<ComponentBase>().type;
		content[target].gameObject.SendMessage("SetValue", value, SendMessageOptions.DontRequireReceiver);
		switch (type)
		{
		case "label":
		case "button":
			content[target].GetComponentInChildren<Text>().text = value.ToString();
			break;
		case "color":
			content[target].GetComponent<ComponentColor>().SetValue((Color)value);
			break;
		case "vector3":
		{
			ComponentVector3 component = content[target].GetComponent<ComponentVector3>();
			component.SetValue(value.ToString());
			if (value is Vector3 vector)
			{
				component.SetVector(vector);
			}
			break;
		}
		}
	}

	public object GetValue(string target)
	{
		object result = null;
		if (content.ContainsKey(target))
		{
			string type = content[target].GetComponent<ComponentBase>().type;
			if (type == "input")
			{
				result = content[target].GetComponent<InputField>().text;
			}
			if (type == "dropdown")
			{
				result = content[target].GetComponent<ComponentDropdown>().index;
			}
			if (type == "checkbox")
			{
				result = content[target].GetComponent<ComponentCheckbox>().toggle.activeSelf;
			}
		}
		return result;
	}

	public void DisableElement(string target)
	{
		if (content.ContainsKey(target))
		{
			content[target].gameObject.SetActive(value: false);
			if (content.ContainsKey(target + "_label"))
			{
				content[target + "_label"].gameObject.SetActive(value: false);
			}
		}
	}

	public void EnableElement(string target)
	{
		if (content.ContainsKey(target))
		{
			content[target].gameObject.SetActive(value: true);
			if (content.ContainsKey(target + "_label"))
			{
				content[target + "_label"].gameObject.SetActive(value: true);
			}
		}
	}

	public Transform Component(string target)
	{
		if (content.ContainsKey(target))
		{
			return content[target];
		}
		return null;
	}

	public static void CreateDivider(bool visible = true)
	{
		if (target.orientation == Orientation.Horizontal)
		{
			int num = 40;
			if (!visible)
			{
				num = 20;
			}
			CreateComponent("divider", "dividerVertical", new Hashtable
			{
				{ "visible", visible },
				{ "width", num }
			});
		}
		else
		{
			CreateComponent("divider", "divider", new Hashtable { { "visible", visible } });
		}
	}

	public void Enable()
	{
		foreach (Transform item in base.transform)
		{
			item.gameObject.SetActive(value: true);
		}
	}

	public void Disable()
	{
		foreach (Transform item in base.transform)
		{
			item.gameObject.SetActive(value: false);
		}
	}

	public void Center()
	{
		base.transform.gameObject.AddComponent<HorizontalLayoutGroup>().spacing = 5f;
	}
}
