using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace PWCommon5
{
	public class Utils : MonoBehaviour
	{
		public static string FixFileName(string sourceFileName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in sourceFileName)
			{
				if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_')
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		public static FileStream OpenRead(string path)
		{
			return new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
		}

		public static string ReadAllText(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("Argument_EmptyPath");
			}
			using StreamReader streamReader = new StreamReader(path, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, 1024);
			return streamReader.ReadToEnd();
		}

		public static void WriteAllText(string path, string contents)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("Argument_EmptyPath");
			}
			if (path == null)
			{
				throw new ArgumentNullException("contents");
			}
			if (contents.Length == 0)
			{
				throw new ArgumentException("Argument_EmptyContents");
			}
			using StreamWriter streamWriter = new StreamWriter(path, append: false, Encoding.UTF8, 1024);
			streamWriter.Write(contents);
		}

		public static byte[] ReadAllBytes(string path)
		{
			using FileStream fileStream = OpenRead(path);
			long length = fileStream.Length;
			if (length > int.MaxValue)
			{
				throw new IOException("Reading more than 2GB with this call is not supported");
			}
			int num = 0;
			int num2 = (int)length;
			byte[] array = new byte[length];
			while (num2 > 0)
			{
				int num3 = fileStream.Read(array, num, num2);
				if (num3 == 0)
				{
					throw new IOException("Unexpected end of stream");
				}
				num += num3;
				num2 -= num3;
			}
			return array;
		}

		public static void WriteAllBytes(string path, byte[] bytes)
		{
			using Stream stream = File.Create(path);
			stream.Write(bytes, 0, bytes.Length);
		}

		public static string GetEditorScriptsPath(AppConfig appConfig)
		{
			return GetAppsSubfolder(appConfig.Folder, appConfig.EditorScriptsFolder);
		}

		public static string GetAppsSubfolder(string appFolder, string subfolderPath)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo("Assets");
			if (!directoryInfo.Exists)
			{
				Debug.LogWarning("Search root does not exist: Assets");
				return null;
			}
			List<DirectoryInfo> list = new List<DirectoryInfo>(directoryInfo.GetDirectories());
			while (list.Count > 0)
			{
				List<DirectoryInfo> list2 = new List<DirectoryInfo>();
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].Name == appFolder)
					{
						string text = Path.Combine(list[i].FullName, subfolderPath);
						if (Directory.Exists(text))
						{
							text = text.Replace(directoryInfo.FullName, "Assets");
							return text.Replace("\\", "/");
						}
					}
					list2.AddRange(list[i].GetDirectories());
				}
				list = list2;
			}
			Debug.LogWarning("Unable to locate directory: '" + appFolder + "/" + subfolderPath + "'");
			return null;
		}

		public static bool Math_ApproximatelyEqual(float a, float b, float threshold)
		{
			if (a == b || Mathf.Abs(a - b) < threshold)
			{
				return true;
			}
			return false;
		}

		public static bool Math_ApproximatelyEqual(float a, float b)
		{
			return Math_ApproximatelyEqual(a, b, float.Epsilon);
		}

		public static bool Math_IsPowerOf2(int value)
		{
			return (value & (value - 1)) == 0;
		}

		public static float Math_Clamp(float min, float max, float value)
		{
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}

		public static float Math_Modulo(float value, float mod)
		{
			return value - mod * (float)Math.Floor(value / mod);
		}

		public static int Math_Modulo(int value, int mod)
		{
			return (int)((float)value - (float)mod * (float)Math.Floor((float)value / (float)mod));
		}

		public static float Math_InterpolateLinear(float value1, float value2, float fraction)
		{
			return value1 * (1f - fraction) + value2 * fraction;
		}

		public static float Math_InterpolateSmooth(float value1, float value2, float fraction)
		{
			fraction = ((!(fraction < 0.5f)) ? (1f - 2f * (fraction - 1f) * (fraction - 1f)) : (2f * fraction * fraction));
			return value1 * (1f - fraction) + value2 * fraction;
		}

		public static float Math_Distance(float x1, float y1, float x2, float y2)
		{
			return Mathf.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
		}

		public static float Math_InterpolateSmooth2(float v1, float v2, float fraction)
		{
			float num = fraction * fraction;
			fraction = 3f * num - 2f * fraction * num;
			return v1 * (1f - fraction) + v2 * fraction;
		}

		public static float Math_InterpolateCubic(float v0, float v1, float v2, float v3, float fraction)
		{
			float num = v3 - v2 - (v0 - v1);
			float num2 = v0 - v1 - num;
			float num3 = v2 - v0;
			float num4 = fraction * fraction;
			return num * fraction * num4 + num2 * num4 + num3 * fraction + v1;
		}

		public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angle)
		{
			Vector3 vector = point - pivot;
			vector = Quaternion.Euler(angle) * vector;
			point = vector + pivot;
			return point;
		}

		public static Vector3 GetNearestVertice(Vector3 sourcePosition, GameObject targetObject)
		{
			float num = float.MaxValue;
			Vector3 vector = targetObject.transform.position;
			Vector3 vector2 = vector;
			Vector3 localScale = targetObject.transform.localScale;
			Vector3 eulerAngles = targetObject.transform.eulerAngles;
			MeshFilter[] componentsInChildren = targetObject.GetComponentsInChildren<MeshFilter>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Mesh sharedMesh = componentsInChildren[i].sharedMesh;
				if (!(sharedMesh != null))
				{
					continue;
				}
				int num2 = sharedMesh.vertices.Length;
				Vector3[] vertices = sharedMesh.vertices;
				for (int j = 0; j < num2; j++)
				{
					Vector3 vector3 = vector2 + Quaternion.Euler(eulerAngles) * Vector3.Scale(vertices[j], localScale);
					float num3 = Vector3.Distance(sourcePosition, vector3);
					if (num3 < num)
					{
						num = num3;
						vector = vector3;
					}
				}
			}
			return vector;
		}

		public static int GetFrapoch()
		{
			return (int)(DateTime.UtcNow - new DateTime(2018, 1, 1)).TotalSeconds;
		}

		public static int TimeToFrapoch(DateTime time)
		{
			return (int)(time - new DateTime(2018, 1, 1)).TotalSeconds;
		}

		public static DateTime FrapochToLocalDate(int seconds)
		{
			return FrapochToLocalDate((double)seconds);
		}

		public static DateTime FrapochToLocalDate(double seconds)
		{
			return new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(seconds).ToLocalTime();
		}

		public static bool IsInLayerMask(GameObject obj, LayerMask mask)
		{
			return (mask.value & (1 << obj.layer)) > 0;
		}

		public static bool IsSameTexture(Texture2D tex1, Texture2D tex2, bool checkID = false)
		{
			if (tex1 == null || tex2 == null)
			{
				return false;
			}
			if (checkID)
			{
				if (tex1.GetInstanceID() != tex2.GetInstanceID())
				{
					return false;
				}
				return true;
			}
			if (tex1.name != tex2.name)
			{
				return false;
			}
			if (tex1.width != tex2.width)
			{
				return false;
			}
			if (tex1.height != tex2.height)
			{
				return false;
			}
			return true;
		}

		public static SRP GetActivePipeline()
		{
			return SRP.BuiltIn;
		}

		public static bool IsSameGameObject(GameObject go1, GameObject go2, bool checkID = false)
		{
			if (go1 == null || go2 == null)
			{
				return false;
			}
			if (checkID)
			{
				if (go1.GetInstanceID() != go2.GetInstanceID())
				{
					return false;
				}
				return true;
			}
			if (go1.name != go2.name)
			{
				return false;
			}
			return true;
		}

		public static Type GetType(string TypeName)
		{
			Type type = Type.GetType(TypeName);
			if ((object)type != null)
			{
				return type;
			}
			if (TypeName.Contains("."))
			{
				string assemblyString = TypeName.Substring(0, TypeName.IndexOf('.'));
				try
				{
					Assembly assembly = Assembly.Load(assemblyString);
					if ((object)assembly == null)
					{
						return null;
					}
					type = assembly.GetType(TypeName);
					if ((object)type != null)
					{
						return type;
					}
				}
				catch (Exception)
				{
				}
			}
			Assembly callingAssembly = Assembly.GetCallingAssembly();
			if ((object)callingAssembly != null)
			{
				type = callingAssembly.GetType(TypeName);
				if ((object)type != null)
				{
					return type;
				}
			}
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.GetLength(0); i++)
			{
				type = assemblies[i].GetType(TypeName);
				if ((object)type != null)
				{
					return type;
				}
			}
			AssemblyName[] referencedAssemblies = callingAssembly.GetReferencedAssemblies();
			AssemblyName[] array = referencedAssemblies;
			foreach (AssemblyName assemblyRef in array)
			{
				Assembly assembly2 = Assembly.Load(assemblyRef);
				if ((object)assembly2 != null)
				{
					type = assembly2.GetType(TypeName);
					if ((object)type != null)
					{
						return type;
					}
				}
			}
			return null;
		}

		public static string AddParametersToURL(string url, AppConfig appConfig, URLParameters overrideParameters)
		{
			URLParameters uRLParameters = new URLParameters();
			uRLParameters.m_product = appConfig.Name;
			uRLParameters.m_version = appConfig.Version;
			uRLParameters.m_unityVersion = Application.unityVersion;
			uRLParameters.m_pipeline = GetActivePipeline().ToString();
			if (overrideParameters != null)
			{
				uRLParameters.m_product = ((!(overrideParameters.m_product == "")) ? overrideParameters.m_product : uRLParameters.m_product);
				uRLParameters.m_version = ((!(overrideParameters.m_version == "")) ? overrideParameters.m_version : uRLParameters.m_version);
				uRLParameters.m_unityVersion = ((!(overrideParameters.m_unityVersion == "")) ? overrideParameters.m_unityVersion : uRLParameters.m_unityVersion);
				uRLParameters.m_pipeline = ((!(overrideParameters.m_pipeline == "")) ? overrideParameters.m_pipeline : uRLParameters.m_pipeline);
			}
			url += $"?product={UnityWebRequest.EscapeURL(uRLParameters.m_product)}&version={UnityWebRequest.EscapeURL(uRLParameters.m_version)}&unity={UnityWebRequest.EscapeURL(uRLParameters.m_unityVersion)}&pipeline={UnityWebRequest.EscapeURL(uRLParameters.m_pipeline)}";
			return url;
		}
	}
}
