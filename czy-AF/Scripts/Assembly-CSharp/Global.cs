using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Global : MonoBehaviour
{
	public delegate void OnWindowResize();

	public static bool control = false;

	public static bool forceQuit = false;

	public static bool deluxe = false;

	public static string log;

	public static float tooltipTimer = 0f;

	public static Dictionary<string, Transform> elements = new Dictionary<string, Transform>();

	public static Texture2D[] cursors;

	public static string separator;

	public static bool uvmap = false;

	private Vector2 lastWindowSize;

	public static event OnWindowResize onWindowResize;

	[RuntimeInitializeOnLoadMethod]
	private static void RunOnStart()
	{
		Application.wantsToQuit += ApplicationQuit;
	}

	private void Awake()
	{
		char directorySeparatorChar = Path.DirectorySeparatorChar;
		separator = directorySeparatorChar.ToString();
		if (Application.CanStreamedLevelBeLoaded("Deluxe"))
		{
			deluxe = true;
		}
		GameObject.Find("deluxe").SetActive(deluxe);
		Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
		Application.targetFrameRate = 120;
		QualitySettings.vSyncCount = 0;
		elements["grid"] = GameObject.Find("grid").transform;
		elements["gizmo"] = GameObject.Find("gizmo").transform;
		elements["widget"] = GameObject.Find("widget").transform;
		elements["tooltip"] = GameObject.Find("tooltip").transform;
		elements["interface"] = GameObject.Find("interface").transform;
		elements["messages"] = GameObject.Find("messages").transform;
		elements["dynamics"] = GameObject.Find("dynamics").transform;
		elements["sidebar"] = GameObject.Find("sidebar").transform;
		elements["studio"] = GameObject.Find("studio").transform;
		elements["light"] = GameObject.Find("light").transform;
		elements["preview"] = GameObject.Find("preview").transform;
		elements["workbench"] = GameObject.Find("workbench").transform;
		elements["selector"] = GameObject.Find("selector").transform;
		elements["selection"] = GameObject.Find("selection").transform;
		elements["clipboard"] = GameObject.Find("clipboard").transform;
		elements["clipboard"].gameObject.SetActive(value: false);
		elements["cameraRender"] = GameObject.Find("cameraRender").transform.GetChild(0);
		elements["cameraRig"] = GameObject.Find("cameraRig").transform;
		elements["global"] = base.transform;
		elements["preview"].gameObject.SetActive(value: false);
		Screen.fullScreen = false;
		InvokeRepeating("WindowSize", 0f, 1f);
		lastWindowSize = new Vector2(Screen.width, Screen.height);
	}

	private void Update()
	{
		Tooltip();
		Hotkeys();
	}

	private static bool ApplicationQuit()
	{
		Preferences.SavePreferences();
		ShowDialog("save", elements["global"].gameObject, "quit");
		return forceQuit;
	}

	public static string GetDataFolder(string _folder = "")
	{
		if (_folder != "")
		{
			_folder += "/";
		}
		return $"{Application.dataPath}/../{_folder}";
	}

	public static void Log(string s)
	{
		log = log + s + "\n";
	}

	public void WindowSize()
	{
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		if (lastWindowSize != vector)
		{
			lastWindowSize = vector;
			if (Global.onWindowResize != null)
			{
				Global.onWindowResize();
			}
		}
	}

	public void Tooltip()
	{
		if (!control)
		{
			return;
		}
		PointerEventData eventData = new PointerEventData(EventSystem.current)
		{
			position = Input.mousePosition
		};
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, list);
		bool show = false;
		list.ForEach(delegate(RaycastResult result)
		{
			if ((bool)result.gameObject.transform.GetComponent<Tooltip>() && result.gameObject.transform.GetComponent<Tooltip>().enabled && ComponentDropdown.openDropdown == null)
			{
				elements["tooltip"].GetChild(0).GetComponent<Text>().text = result.gameObject.transform.GetComponent<Tooltip>().tip;
				show = true;
			}
		});
		if (!show)
		{
			tooltipTimer = 0f;
		}
		else
		{
			tooltipTimer += Time.deltaTime;
		}
		if (tooltipTimer >= 0.5f)
		{
			elements["tooltip"].gameObject.SetActive(value: true);
		}
		else
		{
			elements["tooltip"].gameObject.SetActive(value: false);
		}
		elements["tooltip"].position = new Vector3(Input.mousePosition.x + 15f, Input.mousePosition.y - 15f, 0f);
		tooltipTimer = Mathf.Clamp(tooltipTimer, 0f, 20f);
	}

	public void Hotkeys()
	{
		if (Hotkey.GetKeyDown("Edit/Cancel") && Interface.process == null && Sidebar.instance != null)
		{
			Sidebar.instance.Close();
		}
	}

	public static void ShowMessage(string text, float time = 2f)
	{
		foreach (Transform item in elements["messages"])
		{
			item.GetComponent<Message>().UpdatePosition(25f);
		}
		GameObject obj = UnityEngine.Object.Instantiate(Resources.Load("Interface/Prefabs/Message"), new Vector3(-10f, 0f, 0f), Quaternion.identity) as GameObject;
		obj.transform.SetParent(elements["messages"], worldPositionStays: false);
		obj.GetComponent<Message>().SetData(text, time);
		iTween.MoveBy(obj, iTween.Hash("x", 10f, "time", 0.1f, "easetype", "easeOutSine"));
	}

	public static void ShowDialog(string type, GameObject callback, string callbackAction, string description = null)
	{
		control = false;
		GameObject obj = UnityEngine.Object.Instantiate(Resources.Load("Interface/Prefabs/Dialog"), Vector3.zero, Quaternion.identity) as GameObject;
		obj.transform.SetParent(elements["interface"], worldPositionStays: false);
		Dialog component = obj.GetComponent<Dialog>();
		component.type = type;
		component.description = description;
		component.callback = callback;
		component.callbackAction = callbackAction;
	}

	public static List<Transform> SceneBlocks()
	{
		List<Transform> list = new List<Transform>();
		foreach (Transform item3 in elements["workbench"])
		{
			list.Add(item3);
		}
		foreach (Transform item4 in elements["selection"])
		{
			list.Add(item4);
		}
		return list;
	}

	public static void ToggleElements(string[] elementList, bool active)
	{
		foreach (string key in elementList)
		{
			elements[key].gameObject.SetActive(active);
		}
	}

	public static string UppercaseFirst(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return string.Empty;
		}
		return char.ToUpper(s[0]) + s.Substring(1);
	}

	public static Color Hex(string h)
	{
		if (h.Length > 1 && h[0] != "#"[0])
		{
			h = "#" + h;
		}
		ColorUtility.TryParseHtmlString(h, out var color);
		return color;
	}

	public static string Hex(Color c)
	{
		return ColorUtility.ToHtmlStringRGB(c);
	}

	public static Vector3 RoundVector(Vector3 v, float grid)
	{
		Vector3 zero = Vector3.zero;
		zero.x = grid * Mathf.Round(v.x / grid);
		zero.y = grid * Mathf.Round(v.y / grid);
		zero.z = grid * Mathf.Round(v.z / grid);
		return zero;
	}

	public static string Parse(string h, float min = 0f, float max = 1f)
	{
		try
		{
			return Mathf.Clamp(float.Parse(h), min, max).ToString();
		}
		catch
		{
			return min.ToString();
		}
	}

	public static int ParseInt(string h)
	{
		return int.Parse(h);
	}

	public static Vector2 ParseVector2(string source)
	{
		source = source.Replace("(", "").Replace(")", "");
		string[] array = source.Split(","[0]);
		Vector2 result = default(Vector2);
		result.x = float.Parse(array[0]);
		result.y = float.Parse(array[1]);
		return result;
	}

	public static Vector3 ParseVector3(string source)
	{
		source = source.Replace("(", "").Replace(")", "");
		string[] array = source.Split(","[0]);
		Vector3 result = default(Vector3);
		result.x = float.Parse(array[0]);
		result.y = float.Parse(array[1]);
		result.z = float.Parse(array[2]);
		return result;
	}

	public static Color ParseColor(string source)
	{
		source = source.Replace("RGBA(", "").Replace(")", "");
		string[] array = source.Split(","[0]);
		return new Color
		{
			r = float.Parse(array[0]),
			g = float.Parse(array[1]),
			b = float.Parse(array[2]),
			a = float.Parse(array[3])
		};
	}

	public static void SetLayerRecursively(Transform t, int layer)
	{
		t.gameObject.layer = layer;
		foreach (Transform item in t)
		{
			SetLayerRecursively(item, layer);
		}
	}

	public static void SetLayerRecursively(Transform t, string layer)
	{
		SetLayerRecursively(t, LayerMask.NameToLayer(layer));
	}

	public static Bounds GetBounds(List<Transform> selection)
	{
		Bounds bounds = selection[0].GetComponent<Renderer>().bounds;
		foreach (Transform item in selection)
		{
			Renderer component = item.GetComponent<Renderer>();
			if ((bool)component)
			{
				bounds.Encapsulate(component.bounds);
			}
			else
			{
				bounds.Encapsulate(GetBounds(item.gameObject));
			}
		}
		return bounds;
	}

	public static Bounds GetBounds(GameObject g)
	{
		Bounds result = GetRenderBounds(g);
		if (result.extents.x == 0f)
		{
			result = new Bounds(g.transform.position, Vector3.zero);
			foreach (Transform item in g.transform)
			{
				Renderer component = item.GetComponent<Renderer>();
				if ((bool)component)
				{
					result.Encapsulate(component.bounds);
				}
				else
				{
					result.Encapsulate(GetBounds(item.gameObject));
				}
			}
		}
		return result;
	}

	public static Bounds GetRenderBounds(GameObject g)
	{
		Renderer component = g.GetComponent<Renderer>();
		if (component != null)
		{
			return component.bounds;
		}
		return new Bounds(Vector3.zero, Vector3.zero);
	}

	public static IEnumerator Screenshot(bool ui = true)
	{
		yield return null;
		string time = DateTime.Now.ToString();
		time = time.Replace(":", ".");
		time = time.Replace("/", "-");
		time = time.Replace(" ", "_");
		Canvas canvas = UnityEngine.Object.FindObjectOfType<Canvas>();
		if (!ui)
		{
			canvas.enabled = false;
			Grid.instance.HideGrid();
			yield return new WaitForEndOfFrame();
		}
		ScreenCapture.CaptureScreenshot($"screenshot_{time}.png");
		if (!ui)
		{
			canvas.enabled = true;
			Grid.instance.ShowGrid();
		}
	}
}
