using System;
using UnityEngine;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors;

[Serializable]
public class GameplayButtonsDictionary : UnitySerializedDictionary<AutomationButtonsGameplay.GameplayButtons, GameObject>
{
	public GameplayButtonsDictionary()
	{
		((UnitySerializedDictionary<System.Int32Enum, object>)(object)this)._002Ector();
	}
}
