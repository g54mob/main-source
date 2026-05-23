using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Util
{
	public enum TriState
	{
		Unknown = 0,
		False = 1,
		True = 2
	}

	public class Damper
	{
		private float vel;

		public float val { get; private set; }

		public Damper(float val_ = 0f)
		{
			val = val_;
			vel = 0f;
		}

		public void Update(float target, float smoothTime)
		{
			val = Mathf.SmoothDamp(val, target, ref vel, smoothTime);
		}

		public void Reset(float val_, float vel_ = 0f)
		{
			val = val_;
			vel = vel_;
		}

		public static implicit operator float(Damper d)
		{
			return d.val;
		}
	}

	public class History
	{
		public readonly int maxLength;

		public List<float> values = new List<float>();

		public float average
		{
			get
			{
				if (values.Count == 0)
				{
					return 0f;
				}
				float num = 0f;
				foreach (float value in values)
				{
					float num2 = value;
					num += num2;
				}
				return num / (float)values.Count;
			}
		}

		public History(int maxLength_)
		{
			maxLength = maxLength_;
		}

		public void Add(float value)
		{
			if (values.Count >= maxLength)
			{
				values.RemoveAt(0);
			}
			values.Add(value);
		}

		public void DrawDebug(float valueMin, float valueMax)
		{
			DebugDrawer.Watch("Test", "est");
			DebugDrawer.Screen(new Rect(0f, valueMax, maxLength, 0f - (valueMax - valueMin)), new Rect(10f, 10f, 500f, 200f), delegate(DebugDrawer dd)
			{
				dd.DrawLine(Color.green, new Vector3(0f, 0f), new Vector3(maxLength, 0f));
				dd.DrawLine(Color.green, new Vector3(0f, valueMax), new Vector3(maxLength, valueMax));
				dd.DrawLine(Color.green, new Vector3(0f, 0f - valueMax), new Vector3(maxLength, 0f - valueMax));
				dd.DrawHistory(Color.red, this);
			});
		}
	}

	public static string editorTempDir
	{
		get
		{
			return Path.Combine(Application.dataPath, "../Temp/");
		}
	}

	public static void DestroyRenderTexture(RenderTexture renderTexture)
	{
		if (!(renderTexture == null))
		{
			if (RenderTexture.active == renderTexture)
			{
				RenderTexture.active = null;
			}
			if (Application.isEditor)
			{
				UnityEngine.Object.DestroyImmediate(renderTexture);
			}
			else
			{
				UnityEngine.Object.Destroy(renderTexture);
			}
		}
	}

	public static void DestroyMaterial(Material material)
	{
		if (!(material == null))
		{
			if (Application.isEditor)
			{
				UnityEngine.Object.DestroyImmediate(material);
			}
			else
			{
				UnityEngine.Object.Destroy(material);
			}
		}
	}

	public static float LerpScale(float input, float inputMin, float inputMax, float outputMin, float outputMax)
	{
		float t = Mathf.Max(0f, (input - inputMin) / (inputMax - inputMin));
		return Mathf.Lerp(outputMin, outputMax, t);
	}

	public static int MinMax(int t, int min, int max)
	{
		if (t < min)
		{
			return min;
		}
		if (t > max)
		{
			return max;
		}
		return t;
	}

	public static byte MinMax(byte t, byte min, byte max)
	{
		if (t < min)
		{
			return min;
		}
		if (t > max)
		{
			return max;
		}
		return t;
	}

	public static float MinMax(float t, float min, float max)
	{
		if (t < min)
		{
			return min;
		}
		if (t > max)
		{
			return max;
		}
		return t;
	}

	public static Matrix4x4 MakeDirMatrix(Vector3 dir)
	{
		return MakeDirMatrix(dir, Vector3.zero);
	}

	public static Matrix4x4 MakeDirMatrix(Vector3 dir, Vector3 pos)
	{
		return Matrix4x4.TRS(pos, Quaternion.LookRotation(dir, (!(Mathf.Abs(Vector3.Dot(dir, Vector3.up)) < 0.001f)) ? Vector3.up : Vector3.forward), Vector3.one);
	}

	public static Matrix4x4 MakeLookAtMatrix(Vector3 pos, Vector3 target)
	{
		return MakeLookAtMatrix(pos, target, Vector3.up);
	}

	public static Matrix4x4 MakeLookAtMatrix(Vector3 pos, Vector3 target, Vector3 up)
	{
		Vector3 normalized = (target - pos).normalized;
		return Matrix4x4.TRS(pos, Quaternion.LookRotation(normalized, up.normalized), Vector3.one);
	}

	public static Matrix4x4 MakeFlatMatrix(Matrix4x4 m)
	{
		return Matrix4x4.TRS(m.GetT(), Quaternion.LookRotation(new Vector3(m.GetZ().x, 0f, m.GetZ().y)), Vector3.one);
	}

	public static Matrix4x4 MakeComponentMatrix(Vector3 x, Vector3 y, Vector3 z, Vector3 t)
	{
		Matrix4x4 identity = Matrix4x4.identity;
		identity.SetColumn(0, x);
		identity.SetColumn(1, y);
		identity.SetColumn(2, z);
		identity.SetColumn(3, t.ToVector4(1f));
		return identity;
	}

	public static Quaternion QuaternionFromMatrix(Matrix4x4 m)
	{
		Quaternion result = new Quaternion
		{
			w = Mathf.Sqrt(Mathf.Max(0f, 1f + m[0, 0] + m[1, 1] + m[2, 2])) / 2f,
			x = Mathf.Sqrt(Mathf.Max(0f, 1f + m[0, 0] - m[1, 1] - m[2, 2])) / 2f,
			y = Mathf.Sqrt(Mathf.Max(0f, 1f - m[0, 0] + m[1, 1] - m[2, 2])) / 2f,
			z = Mathf.Sqrt(Mathf.Max(0f, 1f - m[0, 0] - m[1, 1] + m[2, 2])) / 2f
		};
		result.x *= Mathf.Sign(result.x * (m[2, 1] - m[1, 2]));
		result.y *= Mathf.Sign(result.y * (m[0, 2] - m[2, 0]));
		result.z *= Mathf.Sign(result.z * (m[1, 0] - m[0, 1]));
		return result;
	}

	public static Matrix4x4 LerpMatrix(Matrix4x4 a, Matrix4x4 b, float t)
	{
		Quaternion a2 = QuaternionFromMatrix(a);
		Quaternion b2 = QuaternionFromMatrix(b);
		Quaternion q = LerpNoClamp(a2, b2, t);
		Vector3 a3 = new Vector3(a.GetColumn(0).magnitude, a.GetColumn(1).magnitude, a.GetColumn(2).magnitude);
		Vector3 b3 = new Vector3(b.GetColumn(0).magnitude, b.GetColumn(1).magnitude, b.GetColumn(2).magnitude);
		Vector3 s = LerpNoClamp(a3, b3, t);
		Vector3 a4 = a.GetColumn(3);
		Vector3 b4 = b.GetColumn(3);
		Vector3 pos = LerpNoClamp(a4, b4, t);
		return Matrix4x4.TRS(pos, q, s);
	}

	public static bool GetMatch(Matrix4x4 a, Matrix4x4 b)
	{
		for (int i = 0; i < 4; i++)
		{
			Vector4 column = a.GetColumn(i);
			Vector4 column2 = b.GetColumn(i);
			if ((column - column2).sqrMagnitude > 0.001f)
			{
				return false;
			}
		}
		return true;
	}

	public static float BounceT(float t, float peakT, float peakMax)
	{
		return t;
	}

	public static float LerpNoClamp(float a, float b, float t)
	{
		return a + (b - a) * t;
	}

	public static Vector3 LerpNoClamp(Vector3 a, Vector3 b, float t)
	{
		return a + (b - a) * t;
	}

	public static Vector4 LerpNoClamp(Vector4 a, Vector4 b, float t)
	{
		return a + (b - a) * t;
	}

	public static Quaternion LerpNoClamp(Quaternion a, Quaternion b, float t)
	{
		Vector4 a2 = new Vector4(a.x, a.y, a.z, a.w);
		Vector4 b2 = new Vector4(b.x, b.y, b.z, b.w);
		Vector4 normalized = LerpNoClamp(a2, b2, t).normalized;
		return new Quaternion(normalized.x, normalized.y, normalized.z, normalized.w);
	}

	public static Bounds ToWorldBounds(Bounds localBounds, Matrix4x4 matrix)
	{
		Vector3 min = localBounds.min;
		Vector3 max = localBounds.max;
		Bounds result = new Bounds(matrix.MultiplyPoint(new Vector3(min.x, min.y, min.z)), Vector3.zero);
		result.Encapsulate(matrix.MultiplyPoint(new Vector3(min.x, min.y, max.z)));
		result.Encapsulate(matrix.MultiplyPoint(new Vector3(min.x, max.y, min.z)));
		result.Encapsulate(matrix.MultiplyPoint(new Vector3(min.x, max.y, max.z)));
		result.Encapsulate(matrix.MultiplyPoint(new Vector3(max.x, min.y, min.z)));
		result.Encapsulate(matrix.MultiplyPoint(new Vector3(max.x, min.y, max.z)));
		result.Encapsulate(matrix.MultiplyPoint(new Vector3(max.x, max.y, min.z)));
		result.Encapsulate(matrix.MultiplyPoint(new Vector3(max.x, max.y, max.z)));
		return result;
	}

	public static void Swap<T>(ref T a, ref T b)
	{
		T val = a;
		a = b;
		b = val;
	}

	public static bool IsUniform(Vector3 v)
	{
		return Mathf.Abs(v.x - v.y) < 0.001f && Mathf.Abs(v.x - v.z) < 0.001f;
	}

	public static void SaveTextureToFile(Texture2D texture, string fileName)
	{
		byte[] buffer = texture.EncodeToPNG();
		FileStream fileStream = File.Open(fileName, FileMode.Create);
		BinaryWriter binaryWriter = new BinaryWriter(fileStream);
		binaryWriter.Write(buffer);
		fileStream.Close();
		Debug.LogFormat("Saved texture {0}x{1} to file: {2}", texture.width, texture.height, fileName);
	}

	public static Vector3 ParseVector3(string s, Vector3 def)
	{
		string[] array = s.Split(new char[2] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length == 3)
		{
			return new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
		}
		return def;
	}

	public static string GetAttr(XmlNode node, string attrName, string def = null)
	{
		if (node.Attributes == null || node.Attributes[attrName] == null)
		{
			return def;
		}
		return node.Attributes[attrName].Value;
	}

	public static string GetAttrReq(XmlNode node, string attrName)
	{
		if (node.Attributes == null || node.Attributes[attrName] == null)
		{
			throw new UnityException("Missing required attribute: " + attrName + " (" + node.Name + ")");
		}
		return node.Attributes[attrName].Value;
	}

	public static float SmoothStepEdges(float edge0, float edge1, float x)
	{
		x = Mathf.Max(0f, Mathf.Min(1f, (x - edge0) / (edge1 - edge0)));
		return x * x * (3f - 2f * x);
	}

	public static string GetObjectPath(GameObject go)
	{
		if (go.transform.parent != null && go.transform.parent.gameObject.GetInstanceID() != go.GetInstanceID())
		{
			return GetObjectPath(go.transform.parent.gameObject) + "|" + go.name;
		}
		return go.name;
	}

	public static Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
		return new Color32(r, g, b, byte.MaxValue);
	}

	public static string ColorToHex(Color32 color)
	{
		return color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
	}

	public static void ClearRenderTexture(RenderTexture renderTexture, Color color, bool clearDepth = false)
	{
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = renderTexture;
		GL.Clear(clearDepth, true, color);
		RenderTexture.active = active;
	}

	public static bool IsDescendent(GameObject parent, GameObject go)
	{
		GameObject gameObject = go;
		while (gameObject != null)
		{
			if (gameObject == parent)
			{
				return true;
			}
			if (gameObject.transform.parent == null)
			{
				break;
			}
			gameObject = gameObject.transform.parent.gameObject;
		}
		return false;
	}

	public static Quaternion MayaRotationToUnity(Vector3 rotation)
	{
		Vector3 vector = new Vector3(rotation.x, 0f - rotation.y, 0f - rotation.z);
		Quaternion quaternion = Quaternion.AngleAxis(vector.x, Vector3.right);
		Quaternion quaternion2 = Quaternion.AngleAxis(vector.y, Vector3.up);
		Quaternion quaternion3 = Quaternion.AngleAxis(vector.z, Vector3.forward);
		return quaternion3 * quaternion2 * quaternion;
	}

	public static Vector3 MayaPositionToUnity(Vector3 position)
	{
		return new Vector3(0f - position.x, position.y, position.z);
	}

	public static float PowInv(float f, float p)
	{
		return 1f - Mathf.Pow(1f - f, p);
	}

	public static string[] SplitAndTrim(string str, char sep)
	{
		string[] array = str.Split(new char[1] { sep }, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = array[i].Trim();
		}
		return array;
	}

	public static List<T> FindAllInActiveScene<T>() where T : Component
	{
		return new List<T>(IterateAllInActiveScene<T>());
	}

	public static IEnumerable<T> IterateAllInActiveScene<T>() where T : Component
	{
		Scene activeScene = SceneManager.GetActiveScene();
		T[] array = Resources.FindObjectsOfTypeAll<T>();
		foreach (T t in array)
		{
			Component component = t;
			if (!(component == null) && !(component.gameObject.scene != activeScene))
			{
				yield return t;
			}
		}
	}

	public static List<T> FindAllInSameScene<T>(GameObject go) where T : Component
	{
		return new List<T>(IterateAllInScene<T>(go.scene));
	}

	public static IEnumerable<T> IterateAllInScene<T>(Scene scene) where T : Component
	{
		T[] array = Resources.FindObjectsOfTypeAll<T>();
		foreach (T t in array)
		{
			Component component = t;
			if (!(component == null) && !(component.gameObject.scene.path != scene.path))
			{
				yield return t;
			}
		}
	}
}
