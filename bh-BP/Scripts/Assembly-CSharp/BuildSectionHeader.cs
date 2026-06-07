using I2.Loc;
using TMPro;
using UnityEngine;

public class BuildSectionHeader : MonoBehaviour
{
	public Localize LocLabel;

	public TextMeshProUGUI TxtLabel;

	public static readonly string[] kEconomySubCatLabels;

	public static readonly string[] kWarfareSubCatLabels;

	public void Init(BuildingCat cat, int subCat)
	{
	}

	public void InitLocked()
	{
	}
}
