using System;
using UnityEngine;

[Serializable]
public class ModdedColourScheme
{
	[Tooltip("Copy all data from this pre-existing interactable; so we can quickly make versions of different objects etc.")]
	public string copyDataFrom;

	public string presetName;

	public string primary1;

	public string secondary1;

	public string neutral;

	public string secondary2;

	public string primary2;

	[Tooltip("0 = old fashioned/conservative, 1 = modern/liberal: Driven by the design style")]
	public string modernity;

	[Tooltip("0 = informal/cosy, 1 = clean/souless: Driven by the room type.")]
	public string cleanness;

	[Tooltip("0 = understated/quiet, 1 = loud/bold: Driven by the owner's personality")]
	public string loudness;

	[Tooltip("0 = cold/hard, 1 = warm/sensitive: Driven by the owner's personality")]
	public string emotive;
}
