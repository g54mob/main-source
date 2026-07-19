using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
	public Text dialogText;

	public string type = "save";

	public string description;

	public GameObject callback;

	public string callbackAction;

	private Panel panel;

	private void Start()
	{
		panel = Panel.SetTarget(GetComponentInChildren<Panel>());
		if (type == "save")
		{
			dialogText.text = "Your model has been modified, do you wish to save the changes you made?";
			Panel.CreateComponent("save", "button", new Hashtable
			{
				{ "text", "Save" },
				{ "callback", base.gameObject }
			});
			Panel.CreateComponent("dontSave", "button", new Hashtable
			{
				{ "text", "Don't save" },
				{ "callback", base.gameObject }
			});
			Panel.CreateComponent("cancel", "button", new Hashtable
			{
				{ "text", "Cancel" },
				{ "callback", base.gameObject }
			});
			panel.Center();
		}
		if (type == "error")
		{
			dialogText.text = description;
			Panel.CreateComponent("okay", "button", new Hashtable
			{
				{ "text", "Okay" },
				{ "callback", base.gameObject }
			});
			panel.Center();
		}
	}

	private void cancelCallback(Transform t)
	{
		Close();
	}

	private void okayCallback(Transform t)
	{
		Close();
	}

	private void saveCallback(Transform t)
	{
		callback.SendMessage("CallbackSave", callbackAction, SendMessageOptions.DontRequireReceiver);
		Close();
	}

	private void dontSaveCallback(Transform t)
	{
		callback.SendMessage("CallbackDontSave", callbackAction, SendMessageOptions.DontRequireReceiver);
		Close();
	}

	private void Close()
	{
		Global.control = true;
		Object.Destroy(base.gameObject);
	}
}
