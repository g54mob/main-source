using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarkVSector : MonoBehaviour
{
	public MarkVPane[] markVPanes;

	public GalaxyMissionPanel gmp;

	public GameSpace.CATEGORY category;

	public TMP_InputField seedWords;

	public GameObject prevButton;

	public MarkVPrevSeeds prevSeeds;

	public Toggle titansToggle;

	private static string[] greekLetters;

	private static string[] words;

	private Stack<string> wordStack;

	private string lastSeedWords;

	private bool suppressRefresh;

	private bool ignore;

	private string GetGUID(bool forceUpper)
	{
		return null;
	}

	public static bool ReadGUID(string GUID, out string baseGUID, out int metaData, out bool titans)
	{
		baseGUID = null;
		metaData = default(int);
		titans = default(bool);
		return false;
	}

	private void ApplyMetaData(int metaData)
	{
	}

	private void OnEnable()
	{
	}

	public void Update()
	{
	}

	public void SetSeedWords(string val)
	{
	}

	public void Refresh()
	{
	}

	public void OnRandomWords()
	{
	}

	public void OnEndEdit()
	{
	}

	public void OnTitansToggled(bool val)
	{
	}

	public void OnPrev()
	{
	}

	public void OnCopy()
	{
	}

	public void OnPaste()
	{
	}

	private string SetMission()
	{
		return null;
	}

	private string GetRandomWords()
	{
		return null;
	}
}
