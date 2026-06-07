using System.Collections;
using System.Linq;
using DV.Utils;
using UnityEngine;

public class ScreenResolutionOptions : SingletonBehaviour<ScreenResolutionOptions>
{
	private int currentIndex = -1;

	private Vector2Int[] supportedResolutions;

	private Coroutine coro;

	public int CurrentIndex
	{
		get
		{
			Initialize();
			return currentIndex;
		}
	}

	public Vector2Int[] SupportedResolutions
	{
		get
		{
			Initialize();
			return supportedResolutions;
		}
	}

	public new static string AllowAutoCreate()
	{
		return "[ScreenResolutionOptions]";
	}

	private void Start()
	{
		if (!VRManager.IsVREnabled())
		{
			Initialize();
			SetupListeners(on: true);
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		SetupListeners(on: false);
	}

	private void SetupListeners(bool on)
	{
		GamePreferences.RegisterToUpdateIfEligible(Preferences.ScreenResolutionWidth, OnPreferenceUpdated, on);
		GamePreferences.RegisterToUpdateIfEligible(Preferences.ScreenResolutionHeight, OnPreferenceUpdated, on);
	}

	private void OnPreferenceUpdated()
	{
		if (coro == null)
		{
			coro = StartCoroutine(UpdateResolutionAtEndOfFrame());
		}
	}

	private IEnumerator UpdateResolutionAtEndOfFrame()
	{
		yield return WaitFor.EndOfFrame;
		coro = null;
		ChangeResolutionToValueFromPreferences(forced: true);
	}

	private new void Initialize()
	{
		if (currentIndex < 0 || supportedResolutions == null)
		{
			supportedResolutions = (from res in Screen.resolutions
				group res by new { res.width, res.height } into g
				select g.FirstOrDefault() into res
				select new Vector2Int(res.width, res.height) into resWidthHeight
				where resWidthHeight.x >= 800
				select resWidthHeight).ToArray();
			Debug.Log("Supported resolutions: \n" + string.Join("\n", supportedResolutions.Select((Vector2Int res) => $"{res.x} x {res.y}")));
			ChangeResolutionToValueFromPreferences();
		}
	}

	private (int index, bool foundExact) GetMatchingIndexToValueInPreferences()
	{
		int num = GamePreferences.Get<int>(Preferences.ScreenResolutionWidth);
		int num2 = GamePreferences.Get<int>(Preferences.ScreenResolutionHeight);
		Vector2Int[] array = supportedResolutions;
		for (int i = 0; i < array.Length; i++)
		{
			Vector2Int vector2Int = array[i];
			if (vector2Int.x == num && vector2Int.y == num2)
			{
				return (index: i, foundExact: true);
			}
		}
		Vector2Int vector2Int2 = array[array.Length - 1];
		Debug.LogWarning($"Resolution stored in preferences {num}x{num2} is not supported anymore, will use max resolution supported {vector2Int2.x}x{vector2Int2.y} instead");
		return (index: array.Length - 1, foundExact: false);
	}

	public void ChangeResolutionToValueFromPreferences(bool forced = false)
	{
		if (Screen.fullScreen || forced)
		{
			(int index, bool foundExact) matchingIndexToValueInPreferences = GetMatchingIndexToValueInPreferences();
			int item = matchingIndexToValueInPreferences.index;
			bool item2 = matchingIndexToValueInPreferences.foundExact;
			currentIndex = item;
			Vector2Int vector2Int = supportedResolutions[currentIndex];
			if (!item2)
			{
				Debug.Log($"Overwriting resolution in preferences to {vector2Int.x}x{vector2Int.y}");
				GamePreferences.Set(Preferences.ScreenResolutionWidth, vector2Int.x);
				GamePreferences.Set(Preferences.ScreenResolutionHeight, vector2Int.y);
			}
			Debug.Log($"Changing screen resolution to {vector2Int.x}x{vector2Int.y}");
			Screen.SetResolution(vector2Int.x, vector2Int.y, Screen.fullScreen);
		}
	}
}
