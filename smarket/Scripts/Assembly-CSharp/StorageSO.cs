using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "StorageSection", menuName = "Scriptable Objects/Storage")]
public class StorageSO : ScriptableObject
{
	public int ID;

	public float Cost;

	public LocalizedString LocalizedName;

	public int RequiredStoreLevel;

	public int RequiredSectionID;

	public float DailyRentAddition;

	public string SectionName => null;
}
