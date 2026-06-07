using UnityEngine;

public class GamepadSelector : MonoBehaviour
{
	public static GamepadSelector Instance;

	public GamepadImageType _activeGamepadImageType;

	public GamepadImageType activeGamepadImageType
	{
		get
		{
			return _activeGamepadImageType;
		}
		set
		{
			_activeGamepadImageType = value;
			UpdateButtonImages();
		}
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	private void UpdateButtonImages()
	{
		ControllerButtonImage[] array = Object.FindObjectsOfType<ControllerButtonImage>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UpdateButtonImage();
		}
	}
}
