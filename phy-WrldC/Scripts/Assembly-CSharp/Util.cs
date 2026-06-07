using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using TriLib;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public static class Util
{
	public enum BlendMode
	{
		Opaque = 0,
		Cutout = 1,
		Fade = 2,
		Transparent = 3
	}

	private static System.Random random = new System.Random();

	private static readonly string[] invalidFileNames = new string[22]
	{
		"CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6",
		"COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7",
		"LPT8", "LPT9"
	};

	public static string PassPhrase { get; } = "mZq4t7w!z%C*F-JaNdRgUjXn2r5u8x/A";

	public static Vector3 DefaultGravity { get; } = new Vector3(0f, -9.81f, 0f);

	public static string RandomString(int length)
	{
		return new string((from i in Enumerable.Range(1, length)
			select "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".Length)]).ToArray());
	}

	public static string SemiRandomString(string baseName, int length)
	{
		string text = RandomString(length);
		string text2 = RemoveSpecialCharacters(baseName);
		return text + "_" + text2;
	}

	public static string RemoveSpecialCharacters(string str)
	{
		str = Regex.Replace(str, "\\s", "_");
		StringBuilder stringBuilder = new StringBuilder();
		string text = str;
		foreach (char c in text)
		{
			if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	public static bool IsValidFileName(string fileName)
	{
		if (string.IsNullOrEmpty(fileName) || string.IsNullOrWhiteSpace(fileName))
		{
			return false;
		}
		for (int i = 0; i < invalidFileNames.Length; i++)
		{
			if (fileName == invalidFileNames[i])
			{
				return false;
			}
		}
		if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
		{
			return false;
		}
		return true;
	}

	public static Vector3 ConvertMousePositionToRectTransform(Canvas canvas)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out var localPoint);
		return canvas.transform.TransformPoint(localPoint);
	}

	public static Vector3 ConvertPositionToRectTransform(Canvas canvas, Vector3 position)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, position, canvas.worldCamera, out var localPoint);
		return canvas.transform.TransformPoint(localPoint);
	}

	public static Vector2 Vector2Parser(string value)
	{
		string[] array = value.Trim().Replace("(", "").Replace(")", "")
			.Replace(",", "")
			.Split(' ');
		float x = float.Parse(array[0]);
		float y = float.Parse(array[1]);
		return new Vector2(x, y);
	}

	public static Vector3 Vector3Parser(string value)
	{
		string[] array = value.Trim().Replace("(", "").Replace(")", "")
			.Replace(",", "")
			.Split(' ');
		float x = float.Parse(array[0]);
		float y = float.Parse(array[1]);
		float z = float.Parse(array[2]);
		return new Vector3(x, y, z);
	}

	public static void DubleVector3Parser(string vectorString, List<Vector3> vectorList)
	{
		string[] array = vectorString.Trim().Split('\n');
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Trim().Split(' ');
			if (array2.Length == 6)
			{
				for (int j = 0; j < array2.Length; j += 6)
				{
					float x = float.Parse(array2[j]);
					float y = float.Parse(array2[j + 1]);
					float z = float.Parse(array2[j + 2]);
					float x2 = float.Parse(array2[j + 3]);
					float y2 = float.Parse(array2[j + 4]);
					float z2 = float.Parse(array2[j + 5]);
					vectorList.Add(new Vector3(x, y, z));
					vectorList.Add(new Vector3(x2, y2, z2));
				}
			}
		}
	}

	public static Vector3[] DubleVector3Parser(string vectorString)
	{
		List<Vector3> list = new List<Vector3>();
		DubleVector3Parser(vectorString, list);
		return list.ToArray();
	}

	public static void TripleVector3Parser(string vectorString, List<Vector3> vectorList)
	{
		string[] array = vectorString.Trim().Split('\n');
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Trim().Split(' ');
			if (array2.Length == 9)
			{
				for (int j = 0; j < array2.Length; j += 3)
				{
					float x = float.Parse(array2[j]);
					float y = float.Parse(array2[j + 1]);
					float z = float.Parse(array2[j + 2]);
					vectorList.Add(new Vector3(x, y, z));
				}
			}
		}
	}

	public static Vector3[] TripleVector3Parser(string vectorString)
	{
		List<Vector3> list = new List<Vector3>();
		TripleVector3Parser(vectorString, list);
		return list.ToArray();
	}

	public static Quaternion QuaternionParser(string value)
	{
		string[] array = value.Trim().Replace("(", "").Replace(")", "")
			.Split(',');
		float x = float.Parse(array[0]);
		float y = float.Parse(array[1]);
		float z = float.Parse(array[2]);
		float w = float.Parse(array[3]);
		return new Quaternion(x, y, z, w);
	}

	public static void NormalizeBlockScale(GameObject blockObject, float scaleFactor = 1f)
	{
		Renderer component = blockObject.GetComponent<Renderer>();
		float num = ((component.bounds.size.x >= component.bounds.size.y && component.bounds.size.x >= component.bounds.size.z) ? component.bounds.size.x : ((!(component.bounds.size.y >= component.bounds.size.z)) ? component.bounds.size.z : component.bounds.size.y));
		blockObject.transform.localScale = Vector3.one / num * scaleFactor;
	}

	public static void AddMouseOverUIEvents(GameObject panelObject, Action<bool> callback)
	{
		EventTrigger eventTrigger = panelObject.GetComponent<EventTrigger>();
		if (eventTrigger == null)
		{
			eventTrigger = panelObject.AddComponent<EventTrigger>();
		}
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener(delegate
		{
			callback(obj: true);
		});
		eventTrigger.triggers.Add(entry);
		entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerExit;
		entry.callback.AddListener(delegate
		{
			callback(obj: false);
		});
		eventTrigger.triggers.Add(entry);
	}

	public static void AddMouseUIEvent(GameObject uiObject, EventTriggerType eventTriggerType, UnityAction<BaseEventData> callback)
	{
		EventTrigger eventTrigger = uiObject.GetComponent<EventTrigger>();
		if (eventTrigger == null)
		{
			eventTrigger = uiObject.AddComponent<EventTrigger>();
		}
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = eventTriggerType;
		entry.callback.AddListener(callback);
		eventTrigger.triggers.Add(entry);
	}

	public static GameObject InstantiateForGUI(GameObject prefab, Transform parent, string name = "GameObject")
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(prefab);
		gameObject.name = name;
		if (parent != null)
		{
			gameObject.transform.SetParent(parent);
		}
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.SetLocalPositionZ(0f);
		return gameObject;
	}

	public static GameObject InstantiateForGUI(GameObject prefab, Transform parent, int siblingIndex, string name = "GameObject")
	{
		GameObject gameObject = InstantiateForGUI(prefab, parent, name);
		gameObject.transform.SetSiblingIndex(siblingIndex);
		return gameObject;
	}

	public static Mesh ImportMesh(string meshPath)
	{
		AssetLoader assetLoader = new AssetLoader();
		AssetLoaderOptions assetLoaderOptions = ScriptableObject.CreateInstance<AssetLoaderOptions>();
		assetLoaderOptions.UseOriginalPositionRotationAndScale = true;
		assetLoaderOptions.PostProcessSteps = AssimpPostProcessSteps.Triangulate;
		GameObject gameObject = assetLoader.LoadFromFile(meshPath, assetLoaderOptions);
		Mesh mesh = gameObject.GetComponentInChildren<MeshFilter>().mesh;
		FixImportedMeshCoordinates(mesh);
		UnityEngine.Object.Destroy(gameObject);
		return mesh;
	}

	public static void ImportMeshAsync(string meshPath, Action<Mesh> callbackResult)
	{
		using (AssetLoaderAsync assetLoaderAsync = new AssetLoaderAsync())
		{
			AssetLoaderOptions assetLoaderOptions = ScriptableObject.CreateInstance<AssetLoaderOptions>();
			assetLoaderOptions.UseOriginalPositionRotationAndScale = true;
			assetLoaderOptions.PostProcessSteps = AssimpPostProcessSteps.Triangulate;
			assetLoaderAsync.LoadFromFile(meshPath, assetLoaderOptions, null, delegate(GameObject importedObject)
			{
				Mesh mesh = importedObject.GetComponentInChildren<MeshFilter>().mesh;
				FixImportedMeshCoordinates(mesh);
				UnityEngine.Object.Destroy(importedObject);
				callbackResult?.Invoke(mesh);
			});
		}
	}

	public static Mesh[] ImportMeshes(string meshPath)
	{
		List<Mesh> list = new List<Mesh>();
		AssetLoader assetLoader = new AssetLoader();
		AssetLoaderOptions assetLoaderOptions = ScriptableObject.CreateInstance<AssetLoaderOptions>();
		assetLoaderOptions.UseOriginalPositionRotationAndScale = true;
		assetLoaderOptions.PostProcessSteps = AssimpPostProcessSteps.Triangulate;
		GameObject gameObject = assetLoader.LoadFromFile(meshPath, assetLoaderOptions);
		MeshFilter[] componentsInChildren = gameObject.GetComponentsInChildren<MeshFilter>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Mesh mesh = componentsInChildren[i].mesh;
			FixImportedMeshCoordinates(mesh);
			list.Add(mesh);
		}
		UnityEngine.Object.Destroy(gameObject);
		return list.ToArray();
	}

	public static void ImportCollidersMeshes(string meshPath, List<Mesh> meshColliders, List<Mesh> boxColliders)
	{
		AssetLoader assetLoader = new AssetLoader();
		AssetLoaderOptions assetLoaderOptions = ScriptableObject.CreateInstance<AssetLoaderOptions>();
		assetLoaderOptions.UseOriginalPositionRotationAndScale = true;
		assetLoaderOptions.PostProcessSteps = AssimpPostProcessSteps.Triangulate;
		GameObject gameObject = assetLoader.LoadFromFile(meshPath, assetLoaderOptions);
		MeshFilter[] componentsInChildren = gameObject.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter obj in componentsInChildren)
		{
			Mesh mesh = obj.mesh;
			FixImportedMeshCoordinates(mesh);
			if (obj.gameObject.name.Contains("box"))
			{
				boxColliders.Add(mesh);
			}
			else
			{
				meshColliders.Add(mesh);
			}
		}
		UnityEngine.Object.Destroy(gameObject);
	}

	public static void ImportCollidersMeshesAsync(string meshPath, Action<List<Mesh>, List<Mesh>> callbackResult)
	{
		using (AssetLoaderAsync assetLoaderAsync = new AssetLoaderAsync())
		{
			AssetLoaderOptions assetLoaderOptions = ScriptableObject.CreateInstance<AssetLoaderOptions>();
			assetLoaderOptions.UseOriginalPositionRotationAndScale = true;
			assetLoaderOptions.PostProcessSteps = AssimpPostProcessSteps.Triangulate;
			assetLoaderAsync.LoadFromFile(meshPath, assetLoaderOptions, null, delegate(GameObject importedObject)
			{
				List<Mesh> list = new List<Mesh>();
				List<Mesh> list2 = new List<Mesh>();
				MeshFilter[] componentsInChildren = importedObject.GetComponentsInChildren<MeshFilter>();
				foreach (MeshFilter obj in componentsInChildren)
				{
					Mesh mesh = obj.mesh;
					FixImportedMeshCoordinates(mesh);
					if (obj.gameObject.name.Contains("box"))
					{
						list2.Add(mesh);
					}
					else
					{
						list.Add(mesh);
					}
				}
				UnityEngine.Object.Destroy(importedObject);
				callbackResult?.Invoke(list, list2);
			});
		}
	}

	private static void FixImportedMeshCoordinates(Mesh mesh)
	{
		Vector3[] vertices = mesh.vertices;
		for (int i = 0; i < vertices.Length; i++)
		{
			vertices[i] = new Vector3(0f - vertices[i].x, vertices[i].y, vertices[i].z);
		}
		mesh.vertices = vertices;
		Vector3[] normals = mesh.normals;
		for (int j = 0; j < normals.Length; j++)
		{
			normals[j] = new Vector3(0f - normals[j].x, normals[j].y, normals[j].z);
		}
		mesh.normals = normals;
		for (int k = 0; k < mesh.subMeshCount; k++)
		{
			int[] triangles = mesh.GetTriangles(k);
			for (int l = 0; l < triangles.Length; l += 3)
			{
				int num = triangles[l];
				triangles[l] = triangles[l + 1];
				triangles[l + 1] = num;
			}
			mesh.SetTriangles(triangles, k);
		}
		mesh.RecalculateBounds();
		mesh.RecalculateTangents();
	}

	public static Texture2D LoadPNG(string texturePath)
	{
		Texture2D texture2D = null;
		if (File.Exists(texturePath))
		{
			byte[] data = File.ReadAllBytes(texturePath);
			texture2D = new Texture2D(2, 2);
			texture2D.LoadImage(data);
		}
		return texture2D;
	}

	public static int OutlineColorParser(Color color)
	{
		if (color == Color.green)
		{
			return 0;
		}
		if (color == Color.yellow || color == Color.blue)
		{
			return 1;
		}
		if (color == Color.red)
		{
			return 2;
		}
		return 0;
	}

	public static string TimeParser(float seconds, bool shouldIncludeMilliseconds = true)
	{
		if (seconds == float.PositiveInfinity)
		{
			if (!shouldIncludeMilliseconds)
			{
				return "--:--";
			}
			return "--:--:---";
		}
		TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
		if (shouldIncludeMilliseconds)
		{
			return $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}:{timeSpan.Milliseconds:D3}";
		}
		return $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
	}

	public static float LinearToDecibel(float linear)
	{
		if (linear == 0f)
		{
			return -80f;
		}
		return 20f * Mathf.Log10(linear);
	}

	public static void TurnStandardMaterialToFade(Material material)
	{
		material.color = new Color(material.color.r, material.color.g, material.color.b, 0.333f);
		material.SetFloat("_Mode", 2f);
		material.SetOverrideTag("RenderType", "Fade");
		material.SetInt("_SrcBlend", 5);
		material.SetInt("_DstBlend", 10);
		material.SetInt("_ZWrite", 0);
		material.DisableKeyword("_ALPHATEST_ON");
		material.EnableKeyword("_ALPHABLEND_ON");
		material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
		material.renderQueue = 3100;
	}

	public static void ChangeStandardMaterialRenderMode(Material material, BlendMode blendMode)
	{
		switch (blendMode)
		{
		case BlendMode.Opaque:
			if (material.GetFloat("_Mode") != 0f)
			{
				material.SetFloat("_Mode", 0f);
				material.SetOverrideTag("RenderType", "Opaque");
				material.SetInt("_SrcBlend", 1);
				material.SetInt("_DstBlend", 0);
				material.SetInt("_ZWrite", 1);
				material.DisableKeyword("_ALPHATEST_ON");
				material.DisableKeyword("_ALPHABLEND_ON");
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				material.renderQueue = -1;
			}
			break;
		case BlendMode.Cutout:
			if (material.GetFloat("_Mode") != 1f)
			{
				material.SetFloat("_Mode", 1f);
				material.SetOverrideTag("RenderType", "Cutout");
				material.SetInt("_SrcBlend", 1);
				material.SetInt("_DstBlend", 0);
				material.SetInt("_ZWrite", 1);
				material.EnableKeyword("_ALPHATEST_ON");
				material.DisableKeyword("_ALPHABLEND_ON");
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				material.renderQueue = 2450;
			}
			break;
		case BlendMode.Fade:
			if (material.GetFloat("_Mode") != 2f)
			{
				material.SetFloat("_Mode", 2f);
				material.SetOverrideTag("RenderType", "Fade");
				material.SetInt("_SrcBlend", 5);
				material.SetInt("_DstBlend", 10);
				material.SetInt("_ZWrite", 0);
				material.DisableKeyword("_ALPHATEST_ON");
				material.EnableKeyword("_ALPHABLEND_ON");
				material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
				material.renderQueue = 3000;
			}
			break;
		case BlendMode.Transparent:
			if (material.GetFloat("_Mode") != 3f)
			{
				material.SetFloat("_Mode", 3f);
				material.SetOverrideTag("RenderType", "Transparent");
				material.SetInt("_SrcBlend", 1);
				material.SetInt("_DstBlend", 10);
				material.SetInt("_ZWrite", 0);
				material.DisableKeyword("_ALPHATEST_ON");
				material.DisableKeyword("_ALPHABLEND_ON");
				material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
				material.renderQueue = 3000;
			}
			break;
		}
	}

	public static Color HexToColor(string htmlHexColor)
	{
		Color result = Color.white;
		if (ColorUtility.TryParseHtmlString(htmlHexColor, out var color))
		{
			result = color;
		}
		return result;
	}

	public static string ConvertKeyCodeToString(KeyCode key)
	{
		KeyCode keyCode = key;
		switch ((int)keyCode)
		{
		case 276:
			return "\uf060";
		case 275:
			return "\uf061";
		case 273:
			return "\uf062";
		case 274:
			return "\uf063";
		default:
		{
			KeyCode keyCode2 = keyCode;
			if (keyCode2 >= KeyCode.Alpha0 && keyCode2 <= KeyCode.Alpha9)
			{
				return ((int)(keyCode2 - 48)).ToString();
			}
			KeyCode keyCode3 = keyCode;
			if (keyCode3 < KeyCode.Keypad0 || keyCode3 > KeyCode.Keypad9)
			{
				switch ((int)keyCode)
				{
				case 267:
					return "Kp /";
				case 272:
					return "Kp =";
				case 269:
					return "Kp -";
				case 268:
					return "Kp *";
				case 266:
					return "Kp .";
				case 270:
					return "Kp +";
				case 44:
					return ",";
				case 59:
					return ";";
				case 46:
					return ".";
				default:
					return key.ToString();
				}
			}
			return "Kp " + (int)(keyCode3 - 256);
		}
		}
	}

	public static Sprite ConvertKeyCodeToSprite(KeyCode key)
	{
		string text;
		switch (key)
		{
		case KeyCode.JoystickButton0:
		case KeyCode.Joystick1Button0:
			text = "A";
			break;
		case KeyCode.JoystickButton1:
		case KeyCode.Joystick1Button1:
			text = "B";
			break;
		case KeyCode.JoystickButton2:
		case KeyCode.Joystick1Button2:
			text = "X";
			break;
		case KeyCode.JoystickButton3:
		case KeyCode.Joystick1Button3:
			text = "Y";
			break;
		case KeyCode.JoystickButton4:
		case KeyCode.Joystick1Button4:
			text = "LB";
			break;
		case KeyCode.JoystickButton5:
		case KeyCode.Joystick1Button5:
			text = "RB";
			break;
		case KeyCode.JoystickButton6:
		case KeyCode.Joystick1Button6:
			text = "Back";
			break;
		case KeyCode.JoystickButton7:
		case KeyCode.Joystick1Button7:
			text = "Start";
			break;
		case KeyCode.JoystickButton8:
		case KeyCode.Joystick1Button8:
			text = "LS_B";
			break;
		case KeyCode.JoystickButton9:
		case KeyCode.Joystick1Button9:
			text = "RS_B";
			break;
		default:
			text = "";
			break;
		}
		return Resources.Load<Sprite>("Sprites/XBOX/" + text);
	}

	public static Sprite ConvertAxisCodeToSprite(AxisCode axis)
	{
		if (axis == AxisCode.None)
		{
			return null;
		}
		return Resources.Load<Sprite>("Sprites/XBOX/" + axis);
	}

	public static bool IsAxisCodePositive(AxisCode axisCode)
	{
		if (axisCode == AxisCode.LS_r || axisCode == AxisCode.LS_d || axisCode == AxisCode.RS_r || axisCode == AxisCode.RS_d || axisCode == AxisCode.LT || axisCode == AxisCode.RT || axisCode == AxisCode.DPAD_r || axisCode == AxisCode.DPAD_u)
		{
			return true;
		}
		return false;
	}

	public static string GetInputKeyId(KeyCode key, AxisCode axis)
	{
		if (key == KeyCode.None)
		{
			return "a_" + axis;
		}
		return "k_" + key;
	}

	public static (Vector3, Vector3) NormalizedScaleAndCentroid(Bounds bounds, float scaleFactor)
	{
		float num = ((bounds.size.x >= bounds.size.y && bounds.size.x >= bounds.size.z) ? bounds.size.x : ((!(bounds.size.y >= bounds.size.z)) ? bounds.size.z : bounds.size.y));
		Vector3 item = Vector3.one / num * scaleFactor;
		Vector3 center = bounds.center;
		return (item, center);
	}

	public static string GetStarsScore(float score, int starQuantity = 5)
	{
		string text = "";
		int num = (int)score;
		bool flag = score - (float)num >= 0.5f;
		for (int i = 0; i < starQuantity; i++)
		{
			if (num > 0)
			{
				text += "\uf005";
				num--;
			}
			else if (num <= 0 && flag)
			{
				text += "\uf123";
				flag = false;
			}
			else
			{
				text += "\uf006";
			}
		}
		return text;
	}

	public static string GetHashSHA256(string text)
	{
		return BitConverter.ToString(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "");
	}

	public static (string goldIcon, string silverIcon) GetLevelStarsDefaultIcons(bool isAllBoth, bool isAllGold, bool isAllSilver)
	{
		string item = ((isAllBoth || (isAllGold && !isAllSilver)) ? "<#F7EC3D>\uf005" : ((isAllGold && isAllSilver) ? "<#F7EC3D>\uf123" : "<#F7EC3D4D>\uf006"));
		string item2 = ((isAllBoth || (!isAllGold && isAllSilver)) ? "<#787878>\uf005" : ((isAllGold && isAllSilver) ? "<#787878>\uf123" : "<#7878784D>\uf006"));
		return (goldIcon: item, silverIcon: item2);
	}
}
