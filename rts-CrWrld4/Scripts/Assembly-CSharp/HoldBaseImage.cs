using UnityEngine;
using UnityEngine.UI;

public class HoldBaseImage : MonoBehaviour
{
	public Image background;

	public Image indicator;

	public static Color requiredColor;

	public static Color notRequiredColor;

	public static Color heldColor;

	public static Color lostColor;

	private bool _required;

	private bool _held;

	public bool required
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool held
	{
		get
		{
			return false;
		}
		set
		{
		}
	}
}
