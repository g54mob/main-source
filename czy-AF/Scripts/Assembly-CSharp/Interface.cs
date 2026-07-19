using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
	public static Texture2D[] cursors;

	public static bool drag;

	public static GameObject process;

	public static GameObject block;

	private void Awake()
	{
		LoadCursors();
		block = GameObject.Find("interface/block");
	}

	private void LoadCursors()
	{
		cursors = Resources.LoadAll<Texture2D>("Interface/Cursors");
	}

	public static void SetCursor(string _name = null)
	{
		if (_name == null)
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}
		Texture2D[] array = cursors;
		foreach (Texture2D texture2D in array)
		{
			if (texture2D.name == _name)
			{
				Cursor.SetCursor(texture2D, new Vector2(16f, 8f), CursorMode.Auto);
				break;
			}
		}
	}

	public static void ProcessingDisplay()
	{
		process = Object.Instantiate(Resources.Load<GameObject>("Interface/Prefabs/Processing"), Vector3.zero, Quaternion.identity);
		process.transform.SetParent(Global.elements["dynamics"], worldPositionStays: false);
		process.name = "processing";
	}

	public static void ProcessingSet(string _text)
	{
		process.GetComponentInChildren<Text>().text = _text;
	}

	public static void ProcessingHide()
	{
		if (!(process == null))
		{
			Object.Destroy(process);
			process = null;
		}
	}

	public static void Block()
	{
		block.SetActive(value: true);
	}

	public static void Unblock()
	{
		block.SetActive(value: false);
	}
}
