using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WallControls : MonoBehaviour
{
	public TextMeshProUGUI healthText;

	public TextMeshProUGUI allText;

	public TextMeshProUGUI singleText;

	public Image allButton;

	public Image singleButton;

	private static Color disabledColor;

	private static Color enabledColor;

	private bool _wallIsACEnabled;

	private bool suppress;

	private bool wallIsACEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private string GetText(bool enabled)
	{
		return null;
	}

	public void OnEnable()
	{
	}

	private void Refresh()
	{
	}

	public void OnToggleAll()
	{
	}

	public void OnToggleSingle()
	{
	}

	public void LateUpdate()
	{
	}

	private void FloodWalls(Wall wall, HashSet<Wall> wallsSet, bool val)
	{
	}
}
