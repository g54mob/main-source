using UnityEngine;
using UnityEngine.UI;

public class ControlsGeneralSettings : MonoBehaviour
{
	public ControlsManager controlsManager;

	public Toggle rightClickNone;

	public Toggle rightClickCancels;

	public Toggle rightClickMovesMap;

	public Toggle rightClickRotatesMap;

	public Toggle middleClickNone;

	public Toggle middleClickCancels;

	public Toggle middleClickMovesMap;

	public Toggle middleClickRotatesMap;

	public Toggle mouseWheelNone;

	public Toggle mouseWheelZooms;

	public Toggle dragRotate;

	public Slider keyboardScrollRate;

	public Slider bumpScrollRate;

	public void OnKeyboardScrollRateChange(float val)
	{
	}

	public void OnBumpScrollRateChange(float val)
	{
	}

	public void OnRightClickNone(bool val)
	{
	}

	public void OnRightClickCancels(bool val)
	{
	}

	public void OnRightClickMovesMap(bool val)
	{
	}

	public void OnRightClickRotatesMap(bool val)
	{
	}

	public void OnMiddleClickNone(bool val)
	{
	}

	public void OnMiddleClickCancels(bool val)
	{
	}

	public void OnMiddleClickMovesMap(bool val)
	{
	}

	public void OnMiddleClickRotatesMap(bool val)
	{
	}

	public void OnWheelNone(bool val)
	{
	}

	public void OnWheelZooms(bool val)
	{
	}
}
