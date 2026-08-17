using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.UI;

[Serializable]
public class UIPopupContentData
{
	public List<UnityAction> ButtonCallbacks;

	public List<string> ButtonLabels;

	public List<string> ButtonNames;

	public List<string> Labels;

	public List<Sprite> Sprites;

	public UIPopupContentData()
	{
		List<UnityAction> buttonCallbacks = new List<UnityAction>();
		ButtonCallbacks = buttonCallbacks;
		List<string> buttonLabels = new List<string>();
		ButtonLabels = buttonLabels;
		List<string> buttonNames = new List<string>();
		ButtonNames = buttonNames;
		List<string> labels = new List<string>();
		Labels = labels;
		List<Sprite> sprites = new List<Sprite>();
		Sprites = sprites;
	}
}
