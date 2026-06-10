using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

public class MultiSelectController : MonoBehaviour
{
	public delegate void Select();

	[Serializable]
	public class MultiSelectValue
	{
		public ButtonController button;

		public Color colourValue;

		public InterfaceControls.EvidenceColours evidenceColour;
	}

	[ReorderableList]
	[Header("Components")]
	public List<MultiSelectValue> optionButtons;

	[Header("State")]
	public string playerPrefsID;

	public int chosenIndex;

	public event Select OnSelect
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Start()
	{
	}

	public void SetChosen(int newIndex)
	{
	}

	public Color GetCurrentSelectedColourValue()
	{
		return default(Color);
	}

	public InterfaceControls.EvidenceColours GetCurrentSelectedEvidenceColourValue()
	{
		return default(InterfaceControls.EvidenceColours);
	}

	public void OnValueChanged()
	{
	}
}
