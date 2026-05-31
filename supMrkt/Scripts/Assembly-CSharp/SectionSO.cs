using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Section", menuName = "Scriptable Objects/Section")]
public class SectionSO : ScriptableObject
{
	public int ID;

	public float Cost;

	public LocalizedString LocalizedName;

	public int RequiredStoreLevel;

	public int RequiredSectionID;

	public float DailyRentAddition;

	public string SectionName => null;
}
