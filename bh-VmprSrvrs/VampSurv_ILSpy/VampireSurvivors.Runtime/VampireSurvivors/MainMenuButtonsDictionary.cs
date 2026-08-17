using System;
using UnityEngine;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors;

[Serializable]
public class MainMenuButtonsDictionary : UnitySerializedDictionary<AutomationButtonsMainMenu.MainMenuButtons, GameObject>
{
	public MainMenuButtonsDictionary()
	{
		((UnitySerializedDictionary<System.Int32Enum, object>)(object)this)._002Ector();
	}
}
