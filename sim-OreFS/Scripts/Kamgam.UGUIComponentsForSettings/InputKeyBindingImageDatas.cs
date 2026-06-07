using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputKeyBindingImageDatas", menuName = "ZGS/UI/InputKeyBindingImageDatas")]
public class InputKeyBindingImageDatas : ScriptableObject
{
	[Serializable]
	public class KeyboardBindingData
	{
		public string keyboardString;

		public Sprite keyboardSprite;
	}

	[Serializable]
	public class GamepadBindingData
	{
		public string gamepadString;

		public Sprite xboxSprite;

		public Sprite playStationSprite;

		public Sprite steamDeckSprite;
	}

	[Serializable]
	public class MouseBindingData
	{
		public string mouseString;

		public Sprite mouseSprite;
	}

	public Sprite unknownSprite;

	public List<KeyboardBindingData> keyboardList = new List<KeyboardBindingData>();

	public List<GamepadBindingData> gamepadList = new List<GamepadBindingData>();

	public List<MouseBindingData> mouseList = new List<MouseBindingData>();
}
