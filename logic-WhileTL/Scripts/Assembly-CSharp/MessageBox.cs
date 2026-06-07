using System.Collections.Generic;
using Unity.Components.SoundsManager;
using UnityEngine;
using UnityEngine.UI;

public static class MessageBox
{
	public enum Return
	{
		Yes = 0,
		No = 1,
		Maybe = 2,
		None = 3
	}

	public enum Features
	{
		None = 0,
		DontShowNextTime = 1,
		Confirm = 2
	}

	public class Result
	{
		public Return Value;

		public Result(Return r = Return.Maybe)
		{
			Value = r;
		}

		public bool Yes()
		{
			if (Value == Return.Yes)
			{
				Value = Return.Maybe;
				return true;
			}
			return false;
		}

		public bool No()
		{
			if (Value == Return.No)
			{
				Value = Return.Maybe;
				return true;
			}
			return false;
		}
	}

	private static GameObject parent = null;

	private static Object messageboxPrefab = null;

	private static GameObject messageboxInstance = null;

	private static int messageboxHash = 0;

	private static Result messageboxResult = null;

	private static Dictionary<int, bool> messageboxVisibility = new Dictionary<int, bool>();

	private static float magicScaleConst = 0.7085924f;

	public static Result Warning(string textID, string infoID = null, Features features = Features.DontShowNextTime)
	{
		return Show("WARNING", textID, infoID, features);
	}

	public static Result Info(string textID, string infoID = null, Features features = Features.DontShowNextTime)
	{
		return Show("INFO", textID, infoID, features);
	}

	public static bool IsVisible()
	{
		return messageboxInstance != null;
	}

	public static Result Show(string captionID, string textID, string infoID = null, Features features = Features.DontShowNextTime)
	{
		if (messageboxInstance != null)
		{
			return new Result(Return.None);
		}
		messageboxHash = textID.GetHashCode();
		bool value = true;
		if (!messageboxVisibility.TryGetValue(messageboxHash, out value))
		{
			value = true;
		}
		if (!value)
		{
			return new Result(Return.Yes);
		}
		if (parent == null)
		{
			parent = GameObject.Find("Canvas");
		}
		if (messageboxPrefab == null)
		{
			messageboxPrefab = Resources.Load("Prefabs/MessageBox");
		}
		messageboxInstance = Object.Instantiate(messageboxPrefab, parent.transform) as GameObject;
		Button[] componentsInChildren = messageboxInstance.GetComponentsInChildren<Button>();
		messageboxInstance.gameObject.transform.localScale = new Vector3(magicScaleConst, magicScaleConst, magicScaleConst);
		Button[] array = componentsInChildren;
		foreach (Button b in array)
		{
			if (b.name == "Accept")
			{
				b.onClick.AddListener(delegate
				{
					OnYes(b.name);
				});
			}
			else if (b.name == "Cancel")
			{
				b.onClick.AddListener(delegate
				{
					OnNo(b.name);
				});
			}
		}
		LocalizedText[] componentsInChildren2 = messageboxInstance.GetComponentsInChildren<LocalizedText>();
		foreach (LocalizedText localizedText in componentsInChildren2)
		{
			if (localizedText.name == "Caption")
			{
				localizedText.ID = captionID;
				if (!(captionID == "WARNING"))
				{
					if (captionID == "INFO")
					{
						localizedText.colorID = "WARNING";
					}
					else
					{
						localizedText.colorID = "WHITE";
					}
				}
				else
				{
					localizedText.colorID = "RED";
				}
			}
			else if (localizedText.name == "Message")
			{
				localizedText.ID = textID;
			}
			else if (localizedText.name == "Info")
			{
				if (infoID != null)
				{
					localizedText.ID = infoID;
				}
				else
				{
					localizedText.enabled = false;
				}
			}
		}
		Transform transform = messageboxInstance.transform.Find("Hide");
		if (transform != null)
		{
			Toggle component = transform.gameObject.GetComponent<Toggle>();
			component.isOn = features == Features.DontShowNextTime;
			transform.gameObject.SetActive(component.isOn);
		}
		Transform transform2 = messageboxInstance.transform.Find("Confirm");
		if (transform2 != null)
		{
			transform2.gameObject.SetActive(features == Features.Confirm);
			messageboxInstance.transform.Find("Accept").gameObject.SetActive(!transform2.gameObject.activeSelf);
			messageboxInstance.transform.Find("AcceptNA").gameObject.SetActive(transform2.gameObject.activeSelf);
			InputField i2 = transform2.gameObject.GetComponent<InputField>();
			i2.onValueChanged.AddListener(delegate
			{
				OnConfirmChanged(i2.text);
			});
		}
		messageboxResult = new Result();
		return messageboxResult;
	}

	public static void OnYes(string name)
	{
		Close();
		messageboxResult.Value = Return.Yes;
		Sound.PlayUI("Monokanal/WhileTrueLearn_MouseClick");
	}

	public static void OnNo(string name)
	{
		Close();
		messageboxResult.Value = Return.No;
		Sound.PlayUI("Monokanal/WhileTrueLearn_MouseClick");
	}

	public static void OnConfirmChanged(string text)
	{
		bool flag = text == "YES";
		Transform transform = messageboxInstance.transform.Find("Accept");
		Transform transform2 = messageboxInstance.transform.Find("AcceptNA");
		transform.gameObject.SetActive(flag);
		transform2.gameObject.SetActive(!flag);
	}

	public static void DropVisiblityStates()
	{
		messageboxVisibility.Clear();
	}

	private static void Close()
	{
		SetVisibilityState(messageboxInstance);
		Object.Destroy(messageboxInstance);
		messageboxInstance = null;
		messageboxHash = 0;
	}

	private static void SetVisibilityState(GameObject messageBox)
	{
		Toggle componentInChildren = messageBox.GetComponentInChildren<Toggle>();
		bool value = !componentInChildren || !componentInChildren.isOn;
		if (!messageboxVisibility.TryAdd(messageboxHash, value))
		{
			messageboxVisibility[messageboxHash] = value;
		}
	}
}
