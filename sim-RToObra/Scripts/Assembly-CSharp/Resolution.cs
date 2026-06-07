using UnityEngine;

public class Resolution
{
	public const double bufferS = 1.25;

	private const int _bufferBaseW = 640;

	private const int _bufferBaseH = 360;

	public const int targetOutputW = 1600;

	public const int targetOutputH = 900;

	public static int bufferW
	{
		get
		{
			return 800;
		}
	}

	public static int bufferH
	{
		get
		{
			return 450;
		}
	}

	public static int screenW
	{
		get
		{
			return Screen.width;
		}
	}

	public static int screenH
	{
		get
		{
			return Screen.height;
		}
	}

	public static int nativeResW
	{
		get
		{
			return Screen.resolutions[Screen.resolutions.Length - 1].width;
		}
	}

	public static int nativeResH
	{
		get
		{
			return Screen.resolutions[Screen.resolutions.Length - 1].height;
		}
	}

	public static Vector2 ToBuffer(Vector2 screen)
	{
		Vector2 result = screen;
		result.x = screen.x * (float)bufferW / (float)screenW;
		result.y = screen.y * (float)bufferH / (float)screenH;
		return result;
	}

	public static bool IsInBuffer(Vector2 pos)
	{
		return pos.x > 0f && pos.x < (float)bufferW && pos.y > 0f && pos.y < (float)bufferH;
	}
}
