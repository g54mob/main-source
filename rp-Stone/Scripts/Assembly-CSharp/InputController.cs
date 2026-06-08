using UnityEngine;

public class InputController
{
	private static InputController instance;

	private const string SCROLL_SPEED = "settings_input_scroll_speed";

	private const string SCROLL_INVERT = "settings_input_scroll_invert";

	public static InputController Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new InputController();
			}
			return instance;
		}
	}

	public float ScrollSpeed { get; set; }

	public bool InvertScroll { get; set; }

	public float AdjustedScrollSpeed => ScrollSpeed * (InvertScroll ? (-1f) : 1f);

	private void Load()
	{
		if (PlayerPrefs.HasKey("settings_input_scroll_speed"))
		{
			ScrollSpeed = PlayerPrefs.GetFloat("settings_input_scroll_speed");
		}
		else
		{
			ScrollSpeed = 26f;
		}
		if (PlayerPrefs.HasKey("settings_input_scroll_invert"))
		{
			InvertScroll = PlayerPrefs.GetInt("settings_input_scroll_invert") != 0;
		}
		else
		{
			InvertScroll = false;
		}
	}

	public InputController()
	{
		Load();
	}
}
