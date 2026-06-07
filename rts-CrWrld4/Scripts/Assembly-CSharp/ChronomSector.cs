using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChronomSector : MonoBehaviour
{
	public Toggle toggle0;

	public Toggle toggle1;

	public Toggle toggle2;

	public Toggle toggle3;

	public Toggle toggle4;

	public TextMeshProUGUI toggle0Text;

	public TextMeshProUGUI toggle1Text;

	public TextMeshProUGUI toggle2Text;

	public TextMeshProUGUI toggle3Text;

	public TextMeshProUGUI toggle4Text;

	public Image toggle0Image;

	public Image toggle1Image;

	public Image toggle2Image;

	public Image toggle3Image;

	public Image toggle4Image;

	public GalaxyMissionPanel gmp;

	public GameSpace.CATEGORY category;

	private static DateTime now;

	private static string[] months;

	public static string GetGUID(int dateOffset)
	{
		return null;
	}

	private static string GetDateString(int dateOffset, bool lineBreak)
	{
		return null;
	}

	private void OnEnable()
	{
	}

	public void Update()
	{
	}

	private void Refresh()
	{
	}

	public static void UpdateNow()
	{
	}

	public void OnToggle(int num)
	{
	}

	private void SetMission(int dateOffset)
	{
	}
}
