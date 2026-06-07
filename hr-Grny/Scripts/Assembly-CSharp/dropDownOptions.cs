using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class dropDownOptions : MonoBehaviour
{
	public bool easyModeOn;

	public bool normalModeOn;

	public bool hardModeOn;

	public bool extremeModeOn;

	public bool practiseModeOn;

	public Dropdown dropdownOptions;

	public virtual void Start()
	{
	}

	public virtual void diffOptions()
	{
	}
}
