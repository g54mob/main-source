using UnityEngine;
using UnityEngine.UI;

public class WarningDisplay : MonoBehaviour
{
	private static WarningDisplay inst;

	public Image image;

	public Sprite failImage;

	public Sprite warningImage;

	public Canvas canvas;

	public Text warningText;

	public string prefix;

	private void Awake()
	{
	}

	public static void Show(string s)
	{
	}

	public static void CircuitError(string s)
	{
	}

	public static void Reset()
	{
	}
}
