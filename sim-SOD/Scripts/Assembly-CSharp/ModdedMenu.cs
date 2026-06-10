using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ModdedMenu
{
	[Tooltip("Copy all data from this pre-existing interactable; so we can quickly make versions of different objects etc.")]
	public string copyDataFrom;

	public string presetName;

	public List<string> itemsSold;

	public string createReceipt;

	public string syncDiskSlots;

	public List<string> fromManufacturers;

	public List<string> syncDisks;
}
