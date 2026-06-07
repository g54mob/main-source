using System.Collections.Generic;
using UnityEngine.UI;

public class RadioButton : ActiveComponent
{
	public ChangeEvent ChangeEvent;

	private List<Toggle> toggles = new List<Toggle>();

	public void Change(int val)
	{
		ChangeEvent.Invoke(val);
		Logic.UpdateGameSaves();
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Switch");
	}

	public void ActiveButton(int id, bool active, bool activeValue)
	{
		toggles[id].onValueChanged.RemoveAllListeners();
		toggles[id].isOn = activeValue;
		toggles[id].gameObject.SetActive(active);
	}

	public void ReInit()
	{
		DisableListeners();
		EnableListeners();
	}

	public void EnableListeners()
	{
		int num = 0;
		foreach (Toggle toggle in toggles)
		{
			int buf = num;
			toggle.isOn = false;
			toggle.onValueChanged.AddListener(delegate
			{
				Change(buf);
			});
			num++;
		}
	}

	public void DisableListeners()
	{
		foreach (Toggle toggle in toggles)
		{
			toggle.onValueChanged.RemoveAllListeners();
		}
	}

	public new void Init()
	{
		Toggle[] componentsInChildren = base.gameObject.GetComponentsInChildren<Toggle>();
		foreach (Toggle item in componentsInChildren)
		{
			toggles.Add(item);
		}
		EnableListeners();
	}
}
