using UnityEngine;

public class NameGenerator : MonoBehaviour
{
	private static NameGenerator _instance;

	public static NameGenerator Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public string GenerateName(string prefixList, float prefixChance, string mainList, float mainChance, string suffixList, float suffixChance, string useCustomSeed = "")
	{
		return null;
	}

	public string GenerateName(string prefixList, float prefixChance, string mainList, float mainChance, string suffixList, float suffixChance, out string prefixOutput, out string mainOutput, out string suffixOutput, out bool needsSuffixForShortName, out string alternateTags, string useCustomSeed = "")
	{
		prefixOutput = null;
		mainOutput = null;
		suffixOutput = null;
		needsSuffixForShortName = default(bool);
		alternateTags = null;
		return null;
	}

	public string GenerateName(string prefixList, float prefixChance, string mainList, float mainChance, string suffixList, float suffixChance, bool mainIsCitizenName, int prefixMainAlliterationWeight, int mainSuffixAlliterationWeight, out string prefixOutput, out string mainOutput, out string suffixOutput, out bool needsSuffixForShortName, out string alternateTags, string useCustomSeed = "")
	{
		prefixOutput = null;
		mainOutput = null;
		suffixOutput = null;
		needsSuffixForShortName = default(bool);
		alternateTags = null;
		return null;
	}
}
