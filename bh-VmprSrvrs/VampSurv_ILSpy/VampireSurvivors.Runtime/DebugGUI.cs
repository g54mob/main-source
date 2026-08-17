using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using UnityEngine;

public class DebugGUI : MonoBehaviour
{
	private class AttributeKey(MemberInfo memberInfo)
	{
		public MemberInfo memberInfo = memberInfo;
	}

	private struct TransientLog
	{
		public string text;

		public float expiryTime;

		public TransientLog(string text, float duration)
		{
			//IL_001d: Expected O, but got F4
			this.text = text;
			object obj = Time.realtimeSinceStartup;
			object obj2 = default(object);
			float num = (float)obj2 + duration;
			expiryTime = num;
		}
	}

	[Serializable]
	private class GraphContainer
	{
		public string name;

		public float max = 1f;

		private float defaultMax = 1f;

		public float min;

		private float defaultMin;

		public bool autoScale;

		public Color color;

		public int group;

		private Texture2D tex0;

		private Texture2D tex1;

		private bool texFlipFlop;

		private int currentIndex;

		private float[] values;

		private static Color32[] clearColorArray;

		public void SetDefaultMinMax()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018694B105h\"");
			if (min == defaultMin)
			{
				bool flag = max == defaultMax;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018694B105h\"");
				if (flag)
				{
					return;
				}
			}
			RegenerateGraph();
			min = defaultMin;
			max = defaultMax;
		}

		public void SetMinMax(float min, float max, bool isDefault)
		{
			if (isDefault)
			{
				defaultMin = min;
				defaultMax = max;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018694B170h\"");
			if (this.min == min)
			{
				bool flag = this.max == max;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018694B170h\"");
				if (flag)
				{
					return;
				}
			}
			RegenerateGraph();
			this.min = min;
			this.max = max;
		}

		public GraphContainer(int width, int height)
		{
			float[] array = new float[width];
			values = array;
			Texture2D texture2D = new Texture2D(width, height);
			tex0 = texture2D;
			tex0.SetPixels32(clearColorArray);
			Texture2D texture2D2 = new Texture2D(width, height);
			tex1 = texture2D2;
			tex1.SetPixels32(clearColorArray);
		}

		public unsafe void Push(float val)
		{
			//IL_0106: Expected O, but got I4
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Expected I4, but got Unknown
			//IL_0177: Expected I4, but got O
			//IL_015e: Expected I4, but got O
			//IL_01f5: Expected O, but got I4
			//IL_0223: Expected O, but got Ref
			//IL_0223: Expected O, but got I4
			//IL_023b: Expected F4, but got I4
			//IL_0243: Expected O, but got Ref
			//IL_025d: Expected F4, but got I4
			//IL_0296: Expected O, but got I4
			//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a5: Expected O, but got Unknown
			//IL_0448: Expected I4, but got O
			//IL_0319: Invalid comparison between I4 and F4
			//IL_046c: Expected O, but got Ref
			//IL_046c: Expected O, but got I4
			int num5;
			int srcY = default(int);
			int srcWidth = default(int);
			int srcHeight = default(int);
			Texture dst = default(Texture);
			object obj2 = default(object);
			float num8 = default(float);
			float[] array2;
			object obj4;
			int y;
			do
			{
				if (autoScale)
				{
					float num;
					if (!(val > max))
					{
						num = min;
						if (!(min > val))
						{
							goto IL_03a4;
						}
					}
					float num2 = min;
					if (min > val)
					{
						num2 = val;
					}
					float num3 = max;
					if (val > max)
					{
						num3 = val;
					}
					float num4 = min;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018694B476h\"");
					if (min == num2)
					{
						num4 = max;
						bool flag = max == num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018694B476h\"");
						num = max;
						if (flag)
						{
							goto IL_03a4;
						}
					}
					RegenerateGraph();
					min = num2;
					max = num3;
					num = num4;
				}
				goto IL_03a4;
				IL_03a4:
				float[] array = values;
				object obj = currentIndex + 1;
				array[currentIndex = obj % array.Length] = val;
				bool flag2 = !texFlipFlop;
				Texture texture;
				if (!flag2)
				{
					num5 = (int)tex1;
					texture = tex0;
				}
				else
				{
					num5 = (int)tex0;
					texture = tex1;
				}
				texFlipFlop = flag2;
				int width = texture.width;
				int height = texture.height;
				int dstMip = width - 1;
				Graphics.CopyTexture(texture, 0, 0, 0, srcY, srcWidth, srcHeight, dst, 0, dstMip, height, num5);
				Color color = (Color)0;
				int num6 = 0;
				int num7 = 0;
				while (true)
				{
					int value = ((int*)num5)->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v583 @ rdx_v13 (System.Int32)+1A8] (should have been resolved before IL gen)");
					if (num7 >= (nint)obj2)
					{
						break;
					}
					((Texture2D)num5).SetPixel(0, 0, (Color)(&num8));
					int num9 = 0 + 1;
					num8 = 0f;
					color = (Color)(&num8);
					num6 = 0;
					num7 = num9;
					float num = 0f;
				}
				array2 = values;
				int num10 = currentIndex % array2.Length;
				object obj3 = array2.Length + num10;
				obj4 = obj3 % array2.Length;
				bool flag3 = min == max;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018694B682h\"");
				if (!flag3)
				{
					float num11 = max - min;
					float num12 = array2[obj4] - min;
					float num13 = num12 / num11;
					if (!(0f > num13) && !(num13 > 1f))
					{
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
				bool flag4 = (nint)values < 100;
				y = (int)values;
				if (!flag4)
				{
					y = 99;
				}
			}
			while (!(min > array2[obj4]) && array2[obj4] > max);
			((Texture2D)num5).SetPixel(0, y, (Color)(&num8));
		}

		public void Clear()
		{
			//IL_0055: Expected F4, but got I4
			float[] array = values;
			int num = 0;
			int num2 = 0;
			while (num < array.Length)
			{
				float[] array2 = values;
				int num3 = num2 + 1;
				array2[num2] = 0f;
				array = values;
				num = num3;
				num2 = num3;
			}
			currentIndex = 0;
			tex0.SetPixels32(clearColorArray);
			tex1.SetPixels32(clearColorArray);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018694B85Eh\"");
			if (min == defaultMin)
			{
				bool flag = max == defaultMax;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018694B85Eh\"");
				if (flag)
				{
					return;
				}
			}
			RegenerateGraph();
			min = defaultMin;
			max = defaultMax;
		}

		public unsafe void Draw(Rect rect)
		{
			//IL_0057: Expected native int or pointer, but got O
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected F4, but got Unknown
			//IL_007e: Expected native int or pointer, but got O
			//IL_0095: Expected O, but got Ref
			Texture2D texture2D = ((!texFlipFlop) ? tex0 : tex1);
			texture2D.Apply(updateMipmaps: true, makeNoLongerReadable: false);
			float xMin = rect.m_Width + rect.m_XMin;
			((Rect*)(nint)rect)->m_XMin = xMin;
			float width = rect.m_Width;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float width2 = width ^ 0;
			((Rect*)(nint)rect)->m_Width = width2;
			object obj = default(object);
			GUI.DrawTexture((Rect)(&obj), texture2D);
		}

		public float GetValue(int index)
		{
			//IL_0019: Expected O, but got I4
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Expected O, but got Unknown
			float[] array = values;
			object obj = currentIndex + index;
			object obj2 = obj % array.Length;
			object obj3 = array.Length + obj2;
			object obj4 = obj3 % array.Length;
			return array[obj4];
		}

		private unsafe void RegenerateGraph()
		{
			//IL_0091: Expected O, but got I4
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected O, but got Unknown
			//IL_018b: Expected O, but got Ref
			//IL_0132: Invalid comparison between I4 and F4
			Texture2D texture2D = ((!texFlipFlop) ? tex1 : tex0);
			tex0.SetPixels32(clearColorArray);
			tex1.SetPixels32(clearColorArray);
			float[] array = values;
			int num = 0;
			Color color = default(Color);
			for (int num2 = 0; num2 < array.Length; num2 = num)
			{
				float[] array2 = values;
				object obj = currentIndex - num;
				object obj2 = obj % array2.Length;
				object obj3 = array2.Length + obj2;
				object obj4 = obj3 % array2.Length;
				bool flag = min == max;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018694BB83h\"");
				if (!flag)
				{
					float num3 = array2[obj4] - min;
					float num4 = max - min;
					float num5 = num3 / num4;
					if (!(0f > num5) && !(num5 > 1f))
					{
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm1\"");
				texture2D.SetPixel(num, 0, (Color)(&color));
				array = values;
				num++;
				color = this.color;
			}
		}

		private static int Mod(int n, int m)
		{
			//IL_001a: Expected O, but got I4
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected I4, but got Unknown
			int num = n % m;
			object obj = m + num;
			return obj % m;
		}

		private unsafe void DrawLine(Texture2D tex, int x0, int y0, int x1, int y1, Color col)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Expected O, but got Unknown
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0250: Expected O, but got Unknown
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Expected O, but got Unknown
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Expected O, but got Unknown
			//IL_0377: Unknown result type (might be due to invalid IL or missing references)
			//IL_037c: Expected O, but got Unknown
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Expected O, but got Unknown
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e9: Expected O, but got Unknown
			//IL_032d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Expected I4, but got Unknown
			//IL_0362: Expected O, but got Ref
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Expected I4, but got Unknown
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Expected I4, but got Unknown
			//IL_02d7: Expected O, but got Ref
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Expected I4, but got Unknown
			object obj2 = default(object);
			object obj = obj2 - y0;
			object obj4 = default(object);
			object obj3 = obj4 - x0;
			object obj5 = obj >> 31;
			object obj6 = obj5 & -2;
			object obj7 = obj6 + 1;
			object obj8 = obj3 >> 31;
			object obj9 = y0 - obj2;
			object obj10 = obj8 & -2;
			object obj11 = obj10 + 1;
			if ((nint)obj < 0)
			{
				obj = obj9;
			}
			object obj12 = x0 - obj4;
			object obj13 = obj + obj;
			if ((nint)obj3 >= 0)
			{
				obj12 = obj3;
			}
			object obj14 = obj12 + obj12;
			object obj15 = default(object);
			Color color = (Color)(obj15 - 88);
			_ = 0;
			tex.SetPixel(x0, y0, color);
			object obj20;
			object obj21 = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
			{
				object obj16 = obj13 >> 1;
				object obj17 = obj14 - obj16;
				object obj18 = obj2 - y0;
				object obj19 = obj17;
				obj20 = obj21;
				int num = x0;
				int num2 = y0;
				while (true)
				{
					object obj22 = num2 - obj2;
					if (num2 <= (nint)obj2)
					{
						obj22 = obj18;
					}
					if ((nint)obj22 > 1)
					{
						if ((nint)obj19 >= 0)
						{
							num += obj11;
							obj19 -= obj13;
						}
						num2 += obj7;
						obj18 -= obj7;
						obj19 += obj14;
						((Texture2D)col).SetPixel(num, num2, (Color)(&obj20));
						continue;
					}
					break;
				}
				return;
			}
			object obj23 = obj14 >> 1;
			object obj24 = obj13 - obj23;
			object obj25 = obj4 - x0;
			object obj26 = obj24;
			obj20 = obj21;
			int num3 = x0;
			object obj27 = obj4;
			int num4 = y0;
			while (true)
			{
				object obj28 = num3 - obj27;
				if (num3 <= (nint)obj27)
				{
					obj28 = obj25;
				}
				if ((nint)obj28 > 1)
				{
					if ((nint)obj26 >= 0)
					{
						num4 += obj7;
						obj26 -= obj14;
					}
					num3 += obj11;
					obj25 -= obj11;
					obj26 += obj13;
					((Texture2D)col).SetPixel(num3, num4, (Color)(&obj20));
					obj27 = obj4;
					continue;
				}
				break;
			}
		}

		public void DestroyTextures()
		{
			UnityEngine.Object.Destroy(tex0, 0f);
			UnityEngine.Object.Destroy(tex1, 0f);
		}

		static GraphContainer()
		{
			Color32[] array = new Color32[60000];
			clearColorArray = array;
		}
	}

	private static DebugGUI _instance;

	private const int graphWidth = 600;

	private const int graphHeight = 100;

	private const float temporaryLogLifetime = 5f;

	private bool drawInBuild;

	private bool displayGraphs;

	private bool displayLogs;

	private Color backgroundColor;

	private List<GraphContainer> graphs;

	private Dictionary<object, string> persistentLogs;

	private Queue<TransientLog> transientLogs;

	private Dictionary<object, GraphContainer> graphDictionary;

	private GUIStyle minMaxTextStyle;

	private GUIStyle boxStyle;

	private bool freezeGraphs;

	private bool isOnRight;

	private Texture2D boxTexture;

	private const float minMaxTextHeight = 8f;

	private const float nextLineHeight = 15f;

	private GUIContent labelGuiContent;

	private float textWidth;

	private Rect textRect;

	private HashSet<int> graphGroupBoxesDrawn;

	private float graphLabelWidth;

	private StringBuilder stringBuilder;

	private List<MonoBehaviour> attributeContainers;

	private Dictionary<Type, HashSet<FieldInfo>> debugGUIPrintFields;

	private Dictionary<Type, HashSet<PropertyInfo>> debugGUIPrintProperties;

	private Dictionary<Type, HashSet<FieldInfo>> debugGUIGraphFields;

	private Dictionary<Type, HashSet<PropertyInfo>> debugGUIGraphProperties;

	private Dictionary<Type, int> typeInstanceCounts;

	private Dictionary<MonoBehaviour, List<AttributeKey>> attributeKeys;

	private static DebugGUI Instance
	{
		get
		{
			//IL_012e: Expected O, but got I4
			DebugGUI instance = _instance;
			if ((object)_instance == null || ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0)
			{
				DebugGUI instance2 = UnityEngine.Object.FindObjectOfType<DebugGUI>();
				_instance = instance2;
				DebugGUI instance3 = _instance;
				if ((object)_instance == null || ((UnityEngine.Object)instance3).m_CachedPtr == (IntPtr)0)
				{
					object obj = Application.isPlaying;
					if (obj != null)
					{
						GameObject gameObject = new GameObject("DebugGUI");
						DebugGUI instance4 = gameObject.AddComponent<DebugGUI>();
						_instance = instance4;
					}
				}
			}
			return _instance;
		}
	}

	private static bool LogsEnabled
	{
		get
		{
			//IL_008e: Expected I4, but got O
			DebugGUI instance = Instance;
			if ((object)instance != null)
			{
				if (instance.displayLogs)
				{
					DebugGUI instance2 = Instance;
					if ((object)instance2 == null)
					{
						goto IL_0080;
					}
					if (instance2.drawInBuild)
					{
						return true;
					}
				}
				return false;
			}
			goto IL_0080;
			IL_0080:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private static bool GraphsEnabled
	{
		get
		{
			//IL_008e: Expected I4, but got O
			DebugGUI instance = Instance;
			if ((object)instance != null)
			{
				if (instance.displayGraphs)
				{
					DebugGUI instance2 = Instance;
					if ((object)instance2 == null)
					{
						goto IL_0080;
					}
					if (instance2.drawInBuild)
					{
						return true;
					}
				}
				return false;
			}
			goto IL_0080;
			IL_0080:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public static void LogPersistent(object key, object message)
	{
		if (LogsEnabled)
		{
			DebugGUI instance = Instance;
			int num = instance.persistentLogs.FindEntry(key);
			System.Collections.Generic.InsertionBehavior behavior;
			object value;
			if (num < 0)
			{
				string text = message.ToString();
				behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
				value = text;
			}
			else
			{
				string text2 = message.ToString();
				behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
				value = text2;
			}
			bool flag = ((Dictionary<object, object>)(object)instance.persistentLogs).TryInsert(key, value, behavior);
		}
	}

	public static void RemovePersistent(object key)
	{
		if (LogsEnabled)
		{
			DebugGUI instance = Instance;
			int num = instance.persistentLogs.FindEntry(key);
			if (num >= 0)
			{
				bool flag = ((Dictionary<object, object>)(object)instance.persistentLogs).Remove(key);
			}
		}
	}

	public static void ClearPersistent()
	{
		if (LogsEnabled)
		{
			DebugGUI instance = Instance;
			instance.persistentLogs.Clear();
		}
	}

	public static void Log(object message)
	{
		if (LogsEnabled)
		{
			DebugGUI instance = Instance;
			string str = message.ToString();
			instance.InstanceLog(str);
		}
	}

	public static void SetGraphsOnRight(bool isOnRight)
	{
		DebugGUI instance = Instance;
		instance.isOnRight = isOnRight;
	}

	public static void SetGraphProperties(object key, string label, float min, float max, int group, Color color, bool autoScale)
	{
		if (!GraphsEnabled)
		{
			return;
		}
		DebugGUI instance = Instance;
		int num = instance.graphDictionary.FindEntry(key);
		if (num < 0)
		{
			instance.InstanceCreateGraph(key);
		}
		GraphContainer graphContainer = instance.graphDictionary.get_Item(key);
		graphContainer.name = label;
		graphContainer.defaultMin = min;
		graphContainer.defaultMax = max;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186943189h\"");
		if (graphContainer.min == min)
		{
			bool flag = graphContainer.max == max;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186943189h\"");
			if (flag)
			{
				goto IL_0153;
			}
		}
		graphContainer.RegenerateGraph();
		graphContainer.min = min;
		graphContainer.max = max;
		goto IL_0153;
		IL_0153:
		int num2 = default(int);
		bool flag2 = num2 < 0;
		int num3 = 0;
		if (!flag2)
		{
			num3 = num2;
		}
		graphContainer.group = num3;
		bool autoScale2 = default(bool);
		graphContainer.autoScale = autoScale2;
		object color2 = default(object);
		graphContainer.color = (Color)color2;
	}

	public static bool GetGraphExists(object key)
	{
		//IL_008c: Expected I4, but got O
		bool graphsEnabled = GraphsEnabled;
		if (!graphsEnabled)
		{
			return graphsEnabled;
		}
		DebugGUI instance = Instance;
		if ((object)instance != null && instance.graphDictionary != null)
		{
			int num = instance.graphDictionary.FindEntry(key);
			int num2 = num >> 31;
			return (byte)(num2 ^ 1) != 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static void Graph(object key, float val)
	{
		if (GraphsEnabled)
		{
			DebugGUI instance = Instance;
			int num = instance.graphDictionary.FindEntry(key);
			if (num < 0)
			{
				instance.InstanceCreateGraph(key);
			}
			if (!instance.freezeGraphs)
			{
				GraphContainer graphContainer = instance.graphDictionary.get_Item(key);
				graphContainer.Push(val);
			}
		}
	}

	public static void RemoveGraph(object key)
	{
		if (GraphsEnabled)
		{
			DebugGUI instance = Instance;
			instance.InstanceRemoveGraph(key);
		}
	}

	public static void ClearGraph(object key)
	{
		//IL_00db: Expected F4, but got I4
		if (!GraphsEnabled)
		{
			return;
		}
		DebugGUI instance = Instance;
		int num = instance.graphDictionary.FindEntry(key);
		if (num < 0)
		{
			return;
		}
		GraphContainer graphContainer = instance.graphDictionary.get_Item(key);
		float[] values = graphContainer.values;
		int num2 = 0;
		int num3 = 0;
		while (num2 < values.Length)
		{
			float[] values2 = graphContainer.values;
			int num4 = num3 + 1;
			values2[num3] = 0f;
			values = graphContainer.values;
			num2 = num4;
			num3 = num4;
		}
		graphContainer.currentIndex = 0;
		graphContainer.tex0.SetPixels32(GraphContainer.clearColorArray);
		graphContainer.tex1.SetPixels32(GraphContainer.clearColorArray);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186943570h\"");
		if (graphContainer.min == graphContainer.defaultMin)
		{
			bool flag = graphContainer.max == graphContainer.defaultMax;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186943570h\"");
			if (flag)
			{
				return;
			}
		}
		graphContainer.RegenerateGraph();
		graphContainer.min = graphContainer.defaultMin;
		graphContainer.max = graphContainer.defaultMax;
	}

	private void InstanceLogPersistent(object key, object message)
	{
		int num = persistentLogs.FindEntry(key);
		System.Collections.Generic.InsertionBehavior behavior;
		object value;
		if (num < 0)
		{
			string text = message.ToString();
			behavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
			value = text;
		}
		else
		{
			string text2 = message.ToString();
			behavior = System.Collections.Generic.InsertionBehavior.OverwriteExisting;
			value = text2;
		}
		bool flag = ((Dictionary<object, object>)(object)persistentLogs).TryInsert(key, value, behavior);
	}

	private void InstanceRemovePersistent(object key)
	{
		int num = persistentLogs.FindEntry(key);
		if (num >= 0)
		{
			bool flag = ((Dictionary<object, object>)(object)persistentLogs).Remove(key);
		}
	}

	private void InstanceClearPersistent()
	{
		persistentLogs.Clear();
	}

	private void InstanceRemoveGraph(object key)
	{
		int num = graphDictionary.FindEntry(key);
		if (num >= 0)
		{
			GraphContainer graphContainer = graphDictionary.get_Item(key);
			UnityEngine.Object.Destroy(graphContainer.tex0, 0f);
			UnityEngine.Object.Destroy(graphContainer.tex1, 0f);
			bool flag = ((List<object>)(object)graphs).Remove((object)graphContainer);
			bool flag2 = ((Dictionary<object, object>)(object)graphDictionary).Remove(key);
		}
	}

	private void InstanceClearGraph(object key)
	{
		//IL_00a5: Expected F4, but got I4
		int num = graphDictionary.FindEntry(key);
		if (num < 0)
		{
			return;
		}
		GraphContainer graphContainer = graphDictionary.get_Item(key);
		float[] values = graphContainer.values;
		int num2 = 0;
		int num3 = 0;
		while (num2 < values.Length)
		{
			float[] values2 = graphContainer.values;
			int num4 = num3 + 1;
			values2[num3] = 0f;
			values = graphContainer.values;
			num2 = num4;
			num3 = num4;
		}
		graphContainer.currentIndex = 0;
		graphContainer.tex0.SetPixels32(GraphContainer.clearColorArray);
		graphContainer.tex1.SetPixels32(GraphContainer.clearColorArray);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186943B70h\"");
		if (graphContainer.min == graphContainer.defaultMin)
		{
			bool flag = graphContainer.max == graphContainer.defaultMax;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186943B70h\"");
			if (flag)
			{
				return;
			}
		}
		graphContainer.RegenerateGraph();
		graphContainer.min = graphContainer.defaultMin;
		graphContainer.max = graphContainer.defaultMax;
	}

	private void InstanceLog(string str)
	{
		//IL_018a: Expected O, but got F4
		//IL_001a: Expected O, but got I
		//IL_00db: Expected O, but got I
		//IL_00f6: Expected O, but got I
		//IL_005e: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_011d: Expected O, but got I
		//IL_0133: Expected O, but got I
		//IL_0157: Expected O, but got I4
		Queue<TransientLog> queue = transientLogs;
		object obj = Time.realtimeSinceStartup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v2 (System.Collections.Generic.Queue`1<DebugGUI+TransientLog>)+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v2 (System.Collections.Generic.Queue`1<DebugGUI+TransientLog>)+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rax_v13+18]");
		if (num == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v2 (System.Collections.Generic.Queue`1<DebugGUI+TransientLog>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v25+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v25+18]");
			int num3 = (int)(num2 + 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v25+18]");
			object obj4 = (nint)0 + (nint)4;
			if (num3 < (nint)obj4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v25+18]");
				num3 = (int)((nint)0 + (nint)4);
			}
			queue.SetCapacity(num3);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v2 (System.Collections.Generic.Queue`1<DebugGUI+TransientLog>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v2 (System.Collections.Generic.Queue`1<DebugGUI+TransientLog>)+1C]");
		object obj6 = (nint)0 + (nint)2;
		object obj7 = obj6 + obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v2 (System.Collections.Generic.Queue`1<DebugGUI+TransientLog>)+10]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v2 (System.Collections.Generic.Queue`1<DebugGUI+TransientLog>)+1C]");
		object obj9 = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v20+18]");
		bool flag = obj9 == null;
		object obj10 = 0;
		if (!flag)
		{
			obj10 = obj9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v2 (System.Collections.Generic.Queue`1<DebugGUI+TransientLog>)+20]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rbx_v2 (System.Collections.Generic.Queue`1<DebugGUI+TransientLog>)+24]");
		_ = (nint)0 + (nint)1;
	}

	private void InstanceGraph(object key, float val)
	{
		int num = graphDictionary.FindEntry(key);
		if (num < 0)
		{
			InstanceCreateGraph(key);
		}
		if (!freezeGraphs)
		{
			GraphContainer graphContainer = graphDictionary.get_Item(key);
			graphContainer.Push(val);
		}
	}

	private void InstanceSetGraphProperties(object key, string label, float min, float max, int group, Color color, bool autoScale)
	{
		int num = graphDictionary.FindEntry(key);
		if (num < 0)
		{
			InstanceCreateGraph(key);
		}
		GraphContainer graphContainer = graphDictionary.get_Item(key);
		graphContainer.name = label;
		float num2 = default(float);
		graphContainer.defaultMax = num2;
		graphContainer.defaultMin = min;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186943FADh\"");
		if (graphContainer.min == min)
		{
			bool flag = graphContainer.max == num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186943FADh\"");
			if (flag)
			{
				goto IL_0119;
			}
		}
		graphContainer.RegenerateGraph();
		graphContainer.min = min;
		graphContainer.max = num2;
		goto IL_0119;
		IL_0119:
		int num3 = default(int);
		bool flag2 = num3 < 0;
		int num4 = 0;
		if (!flag2)
		{
			num4 = num3;
		}
		graphContainer.group = num4;
		bool autoScale2 = default(bool);
		graphContainer.autoScale = autoScale2;
		object color2 = default(object);
		graphContainer.color = (Color)color2;
	}

	private bool InstanceGetGraphExists(object key)
	{
		//IL_0047: Expected I4, but got O
		if (graphDictionary != null)
		{
			int num = graphDictionary.FindEntry(key);
			int num2 = num >> 31;
			return (byte)(num2 ^ 1) != 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void InstanceCreateGraph(object key)
	{
		GraphContainer value = new GraphContainer(600, 100);
		bool flag = ((Dictionary<object, object>)(object)graphDictionary).TryInsert(key, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		GraphContainer key2 = graphDictionary.get_Item(key);
		GraphContainer graphContainer = ((Dictionary<object, GraphContainer>)(object)graphs).get_Item((object)key2);
	}

	private void Awake()
	{
		//IL_0013: Expected I, but got O
		if (!drawInBuild)
		{
			nint num = (nint)typeof(Application);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rcx_v4 (Il2CppClass<UnityEngine.Application>)+E4]");
			if ((nint)0 != 0)
			{
			}
		}
		else
		{
			InitializeGUIStyles();
			RegisterAttributes();
		}
	}

	private unsafe void Update()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0c16: Expected O, but got Ref
		//IL_0c28: Expected O, but got Ref
		//IL_0044: Expected I, but got O
		//IL_02d1: Expected O, but got I4
		//IL_02d6: Expected I, but got O
		//IL_009d: Expected O, but got I4
		//IL_0cf8: Expected I, but got O
		//IL_00ac: Expected I, but got O
		//IL_00fc: Expected O, but got I
		//IL_0c63: Expected O, but got F4
		//IL_0c76: Expected I, but got O
		//IL_015b: Expected I, but got O
		//IL_018a: Expected O, but got I
		//IL_0416: Expected I, but got O
		//IL_0211: Expected O, but got I
		//IL_0234: Expected O, but got I
		//IL_025f: Expected O, but got I
		//IL_029f: Expected I, but got O
		//IL_02c3: Expected O, but got I4
		//IL_04c2: Expected I, but got O
		//IL_0558: Expected O, but got I
		//IL_0575: Expected F4, but got I
		//IL_0595: Expected O, but got Ref
		//IL_0d53: Expected O, but got Ref
		//IL_05bd: Expected O, but got I
		//IL_05ee: Expected O, but got I
		//IL_0629: Expected I, but got O
		//IL_0639: Expected O, but got I
		//IL_0931: Expected O, but got I
		//IL_0939: Expected I, but got O
		//IL_0947: Expected I, but got O
		//IL_0957: Expected O, but got I
		//IL_0675: Expected O, but got I
		//IL_0993: Expected O, but got I
		//IL_09d8: Expected O, but got I
		//IL_09e8: Expected O, but got I
		//IL_09f8: Expected O, but got I
		//IL_06db: Expected O, but got I
		//IL_06eb: Expected O, but got I
		//IL_0a29: Expected O, but got I
		//IL_0a39: Expected O, but got I
		//IL_0a49: Expected O, but got I
		//IL_0723: Expected O, but got I
		//IL_0a8d: Expected O, but got I4
		//IL_075c: Expected O, but got I
		//IL_0772: Unknown result type (might be due to invalid IL or missing references)
		//IL_0777: Expected O, but got Unknown
		//IL_0a7f: Expected O, but got I4
		//IL_0d81: Expected O, but got I
		//IL_0d99: Expected I, but got O
		//IL_0f4b: Expected O, but got I
		//IL_0f5b: Expected O, but got I
		//IL_0f73: Expected I, but got O
		//IL_07ef: Expected O, but got I
		//IL_0804: Expected O, but got Ref
		//IL_0814: Expected O, but got I
		//IL_081d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0822: Expected O, but got Unknown
		//IL_0ad2: Expected O, but got I
		//IL_0ae2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae7: Expected O, but got Unknown
		//IL_0af7: Expected O, but got I
		//IL_0b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b05: Expected O, but got Unknown
		//IL_0dd0: Expected O, but got I
		//IL_0e76: Expected O, but got I
		//IL_087d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Expected O, but got Unknown
		//IL_089d: Expected O, but got I4
		//IL_0b60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b65: Expected O, but got Unknown
		//IL_0b80: Expected O, but got I4
		//IL_0e16: Expected O, but got I
		//IL_086f: Expected O, but got I4
		//IL_0ebc: Expected O, but got I
		//IL_0b52: Expected O, but got I4
		//IL_08d4: Expected O, but got I
		//IL_0bb7: Expected O, but got I
		//IL_0902: Expected F4, but got I
		//IL_0917: Expected F4, but got I
		//IL_091c: Expected I, but got O
		//IL_011c->IL0c07: Incompatible stack heights: 1 vs 0
		//IL_0c80->IL0c55: Incompatible stack heights: 2 vs 0
		//IL_0175->IL0c07: Incompatible stack heights: 2 vs 0
		//IL_03e3->IL0c07: Incompatible stack heights: 1 vs 0
		//IL_01cb->IL0c07: Incompatible stack heights: 3 vs 0
		//IL_027f->IL0c07: Incompatible stack heights: 4 vs 0
		//IL_0cd4->IL0c07: Incompatible stack heights: 4 vs 0
		//IL_0d45->IL0f15: Incompatible stack heights: 2 vs 0
		//IL_02c8->IL0cd9: Incompatible stack heights: 4 vs 0
		//IL_0469->IL0c07: Incompatible stack heights: 2 vs 0
		//IL_04ea->IL0c07: Incompatible stack heights: 2 vs 0
		//IL_0523->IL0c07: Incompatible stack heights: 2 vs 0
		//IL_0c01->IL0d32: Incompatible stack heights: 3 vs 2
		//IL_060e->IL0d45: Incompatible stack heights: 3 vs 2
		//IL_097e->IL0d45: Incompatible stack heights: 3 vs 2
		//IL_09bb->IL0d45: Incompatible stack heights: 3 vs 2
		//IL_07df->IL07df: Incompatible stack heights: 7 vs 6
		//IL_0ac2->IL0ac2: Incompatible stack heights: 5 vs 4
		//IL_0e3c->IL0d45: Incompatible stack heights: 6 vs 2
		//IL_0eea->IL0d45: Incompatible stack heights: 4 vs 2
		//IL_0921->IL0d45: Incompatible stack heights: 8 vs 2
		//IL_0bda->IL08f2: Incompatible stack heights: 6 vs 8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		object obj4 = default(object);
		object obj3 = (object)(&obj4);
		_ = ref obj4;
		_ = ref obj4;
		object obj5 = default(object);
		obj = (object)(&obj5);
		_ = ref obj5;
		_ = ref obj5;
		_ = 0;
		_ = 0;
		if (LogsEnabled || GraphsEnabled)
		{
			CleanUpDeletedAtributes();
			nint num = unchecked((nint)null);
		}
		nint num2;
		if (LogsEnabled)
		{
			Queue<TransientLog> queue = transientLogs;
			if (transientLogs == null)
			{
				goto IL_0c07;
			}
			object obj6 = 0;
			object obj9 = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v127 (System.Collections.Generic.Queue`1<DebugGUI+TransientLog>)+20]");
				bool flag = (nint)0 <= (nint)0;
				num2 = unchecked((nint)null);
				if (flag)
				{
					break;
				}
				nint num3 = (nint)transientLogs;
				if (transientLogs != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+20]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+10]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+18]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rcx_v94+18]");
						bool flag3 = num4 >= 0;
						object obj8 = Time.realtimeSinceStartup;
						bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9);
						num2 = unchecked((nint)null);
						if (flag4)
						{
							break;
						}
						num3 = (nint)transientLogs;
						if (transientLogs != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+10]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+20]");
							bool flag5 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+18]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v95+18]");
								bool flag6 = num5 >= 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+18]");
								object obj11 = (nint)0 + (nint)2;
								object obj12 = obj11 + obj11;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+18]");
								List<AttributeKey> list = (List<AttributeKey>)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+18]");
								nint num = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+10]");
								object obj13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+10]");
								if ((nint)0 != 0)
								{
									nint num6 = num;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v97+18]");
									bool flag7 = num6 == 0;
									nint num7 = unchecked((nint)null);
									if (!flag7)
									{
										num7 = num;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+20]");
									_ = -1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+24]");
									_ = (nint)0 + (nint)1;
									queue = transientLogs;
									if (transientLogs != null)
									{
										obj6 = 0;
										continue;
									}
								}
							}
						}
					}
				}
				goto IL_0c07;
			}
		}
		else
		{
			object obj6 = 0;
			num2 = unchecked((nint)null);
		}
		DebugGUI instance = Instance;
		if ((object)instance != null)
		{
			if (!instance.displayGraphs)
			{
				return;
			}
			DebugGUI instance2 = Instance;
			if ((object)instance2 != null)
			{
				if (!instance2.drawInBuild || freezeGraphs)
				{
					return;
				}
				nint num8 = num2;
				object obj14 = default(object);
				object obj26 = default(object);
				object obj46 = default(object);
				while (true)
				{
					List<MonoBehaviour> list2 = attributeContainers;
					if (attributeContainers == null)
					{
						break;
					}
					if (num8 >= list2._size)
					{
						return;
					}
					bool flag8 = num8 >= list2._size;
					MonoBehaviour[] items = list2._items;
					if (list2._items == null)
					{
						break;
					}
					bool flag9 = num8 >= items.Length;
					nint num9 = (nint)items[num8];
					if ((object)items[num8] != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ r14_v11 (Il2CppMethodInfo)+10]");
						if ((nint)0 != 0)
						{
							bool flag10 = attributeKeys == null;
							if (flag10)
							{
								break;
							}
							int num10 = attributeKeys.FindEntry(items[num8]);
							nint num3 = 0;
							if (!flag10)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1852F1400");
								bool flag11 = obj14 == null;
								num3 = 0;
								nint num = unchecked((nint)null);
								if (!flag11)
								{
									if (attributeKeys == null)
									{
										break;
									}
									List<AttributeKey> list3 = attributeKeys.get_Item(items[num8]);
									if (list3 == null)
									{
										break;
									}
									_ = 0;
									_ = list3._version;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+8]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+18]");
									float num11 = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+18]");
									_ = 0;
									object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
									List<AttributeKey> list = list3;
									num3 = 0;
									while (true)
									{
										List<AttributeKey>.Enumerator enumerator = (List<AttributeKey>.Enumerator)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
										if (!((List<AttributeKey>.Enumerator*)enumerator)->MoveNext())
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+30]");
										object obj16 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+30]");
										bool flag12 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1487 @ rdi_v12 (System.Object)+10]");
										object obj17 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1487 @ rdi_v12 (System.Object)+10]");
										if ((nint)0 == 0)
										{
											continue;
										}
										object obj18 = obj17;
										nint num12 = (nint)typeof(FieldInfo);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1070 @ rdx_v25 (Il2CppClass<System.Reflection.FieldInfo>)+130]");
										object obj19 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1696 @ r8_v16+130]");
										nint num13 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1070 @ rdx_v25 (Il2CppClass<System.Reflection.FieldInfo>)+130]");
										GraphContainer graphContainer;
										if (num13 >= 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1696 @ r8_v16+C8]");
											object obj20 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1072 @ rax_v84+FFFFFFF8+v1697 @ rax_v54*8]");
											if (0 == (nint)typeof(FieldInfo))
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1487 @ rdi_v12 (System.Object)+10]");
												nint num14 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1487 @ rdi_v12 (System.Object)+10]");
												bool flag13 = (nint)0 == 0;
												list = (List<AttributeKey>)num14;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1070 @ rdx_v25 (Il2CppClass<System.Reflection.FieldInfo>)+130]");
												object obj21 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ r9_v16 (System.Collections.Generic.List`1<DebugGUI+AttributeKey>)+130]");
												nint num15 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1070 @ rdx_v25 (Il2CppClass<System.Reflection.FieldInfo>)+130]");
												bool flag14 = num15 < 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1596 @ r9_v16 (System.Collections.Generic.List`1<DebugGUI+AttributeKey>)+C8]");
												object obj22 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ rax_v86+FFFFFFF8+v1073 @ rax_v85*8]");
												bool flag15 = 0 != (nint)typeof(FieldInfo);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1070 @ rdx_v25 (Il2CppClass<System.Reflection.FieldInfo>)+130]");
												object obj23 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ rax_v86+FFFFFFF8+v1750 @ rcx_v65*8]");
												object obj24 = 0 - typeof(FieldInfo);
												bool flag16 = obj24 == null;
												bool flag17 = !flag16;
												nint num16 = num2;
												if (!flag17)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1487 @ rdi_v12 (System.Object)+10]");
													num16 = 0;
												}
												object obj25 = num16;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1777 @ r8_v28+2C8] (should have been resolved before IL gen)");
												nint num17 = (nint)typeof(float?);
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												if (obj26 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rbx_v17 (Il2CppClass<System.Nullable`1<System.Single>>)+40]");
													bool flag18 = obj26 != null;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rbx_v17 (Il2CppClass<System.Nullable`1<System.Single>>)+80]");
												object obj27 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1825 @ rcx_v70+38]");
												object obj28 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj4));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1825 @ rcx_v70+30]");
												object obj29 = 0;
												object obj30 = obj28 - 16;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1828 @ rax_v91+28]");
												if ((nint)0 >= (nint)0)
												{
													obj30 = obj28;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rbx_v17 (Il2CppClass<System.Nullable`1<System.Single>>)+40]");
												object obj31 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1854 @ rax_v92+F8]");
												nint num18 = -16;
												object obj32;
												if (obj26 == null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
													num3 = num18;
													obj32 = 0;
												}
												else
												{
													object obj33 = obj26 + 16;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
													num3 = num18;
													obj32 = 1;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+38]");
												object obj34 = 0;
												obj34 = obj32;
												if (obj3 == null)
												{
													continue;
												}
												bool flag19 = graphDictionary == null;
												Dictionary<object, GraphContainer> dictionary = graphDictionary;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+30]");
												graphContainer = dictionary.get_Item((object)0);
												bool flag20 = graphContainer == null;
												goto IL_08f2;
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1487 @ rdi_v12 (System.Object)+10]");
										object obj35 = 0;
										num3 = (nint)obj35;
										nint num19 = (nint)typeof(PropertyInfo);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1386 @ rdx_v26 (Il2CppClass<System.Reflection.PropertyInfo>)+130]");
										object obj36 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+130]");
										nint num20 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1386 @ rdx_v26 (Il2CppClass<System.Reflection.PropertyInfo>)+130]");
										if (num20 < 0)
										{
											continue;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ r8_v11 (Il2CppMethodInfo)+C8]");
										object obj37 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1606 @ rax_v58+FFFFFFF8+v1605 @ rax_v57*8]");
										if (0 != (nint)typeof(PropertyInfo))
										{
											continue;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1487 @ rdi_v12 (System.Object)+10]");
										nint num21 = 0;
										object obj38 = num21;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1386 @ rdx_v26 (Il2CppClass<System.Reflection.PropertyInfo>)+130]");
										object obj39 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1735 @ rax_v59+C8]");
										object obj40 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1388 @ rax_v60+FFFFFFF8+v1390 @ rcx_v47*8]");
										bool flag21 = 0 != (nint)typeof(PropertyInfo);
										object obj41 = num21;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1386 @ rdx_v26 (Il2CppClass<System.Reflection.PropertyInfo>)+130]");
										object obj42 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1736 @ rax_v61+C8]");
										object obj43 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1738 @ rax_v62+FFFFFFF8+v1737 @ rcx_v48*8]");
										object obj44 = ((0 != (nint)typeof(PropertyInfo)) ? ((object)0) : ((object)1));
										bool flag22 = obj44 == null;
										IntPtr intPtr = num2;
										if (!flag22)
										{
											intPtr = num21;
										}
										object obj45 = (nint)intPtr;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1807 @ r9_v14+300]");
										list = (List<AttributeKey>)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1807 @ r9_v14+2F8] (should have been resolved before IL gen)");
										nint num22 = (nint)typeof(float?);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										if (obj46 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1141 @ rbx_v15 (Il2CppClass<System.Nullable`1<System.Single>>)+40]");
											bool flag23 = obj46 != null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1141 @ rbx_v15 (Il2CppClass<System.Nullable`1<System.Single>>)+80]");
										object obj47 = 0;
										object obj48 = obj;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1879 @ rcx_v53+38]");
										object obj49 = obj48 + 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1879 @ rcx_v53+30]");
										object obj50 = 0;
										object obj51 = obj49 - 16;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1883 @ rax_v68+28]");
										if ((nint)0 >= (nint)0)
										{
											obj51 = obj49;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1141 @ rbx_v15 (Il2CppClass<System.Nullable`1<System.Single>>)+40]");
										object obj52 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1903 @ rax_v69+F8]");
										nint num23 = -16;
										object obj53;
										if (obj46 == null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
											num3 = num23;
											obj53 = 0;
										}
										else
										{
											object obj54 = obj46 + 16;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
											num3 = num23;
											obj53 = 1;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+40]");
										object obj55 = 0;
										obj55 = obj53;
										object obj56 = obj;
										if (obj56 == null)
										{
											continue;
										}
										bool flag24 = graphDictionary == null;
										Dictionary<object, GraphContainer> dictionary2 = graphDictionary;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+30]");
										graphContainer = dictionary2.get_Item((object)0);
										bool flag25 = graphContainer == null;
										goto IL_08f2;
										IL_08f2:
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+D4]");
										num11 = 0f;
										GraphContainer graphContainer2 = graphContainer;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+D4]");
										graphContainer2.Push(0f);
										num3 = unchecked((nint)null);
									}
									bool flag26 = num2 != 0;
									num = 0;
								}
							}
						}
					}
					num8++;
				}
			}
		}
		goto IL_0c07;
		IL_0c07:
		throw new NullReferenceException();
	}

	private void OnGUI()
	{
		Color value = default(Color);
		GUI.set_color_Injected(ref value);
		if (LogsEnabled)
		{
			DrawLogs();
		}
		if (GraphsEnabled)
		{
			DrawGraphs();
		}
	}

	private void InitializeGUIStyles()
	{
		//IL_00d9: Expected O, but got I
		//IL_0164: Expected O, but got I4
		//IL_0198: Expected I4, but got O
		GUIStyle gUIStyle = new GUIStyle();
		minMaxTextStyle = gUIStyle;
		if (minMaxTextStyle != null)
		{
			minMaxTextStyle.fontSize = 10;
			if (minMaxTextStyle != null)
			{
				minMaxTextStyle.fontStyle = FontStyle.Bold;
				Color[] array = new Color[4];
				if (array != null)
				{
					nint num = 0;
					nint num2 = 0;
					while (num < array.Length)
					{
						if (num2 < array.Length)
						{
							object obj = num2 + 2;
							object obj2 = obj + obj;
							num2++;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
							_ = 0;
							num = num2;
							continue;
						}
						throw new IndexOutOfRangeException();
					}
					Texture2D texture2D = new Texture2D(2, 2);
					boxTexture = texture2D;
					if ((object)boxTexture != null)
					{
						GUIStyle gUIStyle2 = (GUIStyle)boxTexture.width;
						int height = boxTexture.height;
						int blockHeight = default(int);
						Color[] colors = default(Color[]);
						int miplevel = default(int);
						boxTexture.SetPixels(0, 0, (int)gUIStyle2, blockHeight, colors, miplevel);
						if ((object)boxTexture != null)
						{
							boxTexture.Apply(updateMipmaps: true, makeNoLongerReadable: false);
							GUIStyle gUIStyle3 = new GUIStyle();
							IntPtr ptr = GUIStyle.Internal_Create(gUIStyle3);
							gUIStyle3.m_Ptr = ptr;
							boxStyle = gUIStyle3;
							if (boxStyle != null)
							{
								GUIStyleState normal = boxStyle.normal;
								Texture2D texture2D2 = boxTexture;
								if (normal != null)
								{
									bool flag = ((GUIStyle)(object)normal).m_Ptr == (IntPtr)0;
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ rcx_v35 (Il2CppMethodInfo)+38]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
									}
									bool flag2 = (object)boxTexture == null;
									nint num4 = 0;
									if (!flag2)
									{
										num4 = ((UnityEngine.Object)texture2D2).m_CachedPtr;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 427 ConditionalJump @-1, v494 @ ZF_v27 (System.Boolean) --- -1 Nop");
									/*Error: End of method reached without returning.*/;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void DrawLogs()
	{
		//IL_0041: Expected O, but got Ref
		//IL_08e0: Expected O, but got I4
		//IL_0af0: Expected F4, but got I4
		//IL_0b0e: Expected F4, but got I4
		//IL_0b18: Expected O, but got I4
		//IL_0b22: Expected O, but got I4
		//IL_0b30: Expected O, but got I4
		//IL_0053: Invalid comparison between F4 and I4
		//IL_0077: Invalid comparison between F4 and I4
		//IL_00c3: Invalid comparison between F4 and I4
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Expected O, but got Unknown
		//IL_062e: Expected O, but got Ref
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0684: Unknown result type (might be due to invalid IL or missing references)
		//IL_0689: Expected O, but got Unknown
		//IL_0b74: Expected O, but got I4
		//IL_06b7: Expected O, but got I
		//IL_06e7: Expected I, but got O
		//IL_06f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f9: Expected I, but got Unknown
		//IL_02d5: Expected O, but got I4
		//IL_021b: Expected F4, but got I4
		//IL_0236: Expected native int or pointer, but got F4
		//IL_024d: Expected native int or pointer, but got F4
		//IL_0426: Expected O, but got I4
		//IL_0396: Expected I, but got O
		//IL_03a8: Expected I, but got O
		//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dc: Expected O, but got Unknown
		//IL_0803: Unknown result type (might be due to invalid IL or missing references)
		//IL_0808: Expected O, but got Unknown
		//IL_00b4->IL08b6: Incompatible stack heights: 1 vs 0
		//IL_0925->IL0b3d: Incompatible stack heights: 2 vs 0
		//IL_061c->IL08b6: Incompatible stack heights: 3 vs 0
		//IL_05ad->IL08b6: Incompatible stack heights: 3 vs 0
		//IL_056b->IL0990: Incompatible stack heights: 5 vs 2
		//IL_0584->IL09a9: Incompatible stack heights: 5 vs 0
		//IL_0177->IL08b6: Incompatible stack heights: 2 vs 0
		//IL_093f->IL08b6: Incompatible stack heights: 2 vs 0
		//IL_01cf->IL08b6: Incompatible stack heights: 2 vs 0
		//IL_01ff->IL08b6: Incompatible stack heights: 2 vs 0
		//IL_088b->IL08b6: Incompatible stack heights: 5 vs 0
		//IL_032e->IL08b6: Incompatible stack heights: 2 vs 0
		//IL_035e->IL08b6: Incompatible stack heights: 2 vs 0
		//IL_0add->IL08b6: Incompatible stack heights: 5 vs 0
		//IL_075a->IL0a30: Incompatible stack heights: 8 vs 3
		//IL_07a2->IL08b6: Incompatible stack heights: 6 vs 0
		//IL_0832->IL08b6: Incompatible stack heights: 7 vs 0
		//IL_0ab9->IL0b66: Incompatible stack heights: 7 vs 5
		Color value = default(Color);
		GUI.set_backgroundColor_Injected(ref value);
		GUIContent content = GUIContent.Temp("");
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		GUI.Box((Rect)(&enumerator), content, boxStyle);
		GUIContent gUIContent = (GUIContent)Screen.width;
		float num = Screen.height;
		Rect rect = default(Rect);
		textRect = rect;
		textWidth = 0f;
		float num2 = 0f;
		HashSet<object>.Enumerator enumerator2 = (HashSet<object>.Enumerator)0;
		HashSet<object>.Enumerator enumerator3 = (HashSet<object>.Enumerator)0;
		HashSet<PropertyInfo> hashSet = null;
		enumerator = (HashSet<object>.Enumerator)0;
		GUIContent gUIContent2 = gUIContent;
		object obj2 = default(object);
		Type type = default(Type);
		object obj4 = default(object);
		string text2 = default(string);
		object obj6 = default(object);
		object obj7 = default(object);
		HashSet<object>.Enumerator enumerator4 = default(HashSet<object>.Enumerator);
		object obj8 = default(object);
		object obj9 = default(object);
		HashSet<object>.Enumerator enumerator5 = default(HashSet<object>.Enumerator);
		GUIContent gUIContent4 = default(GUIContent);
		object obj10 = default(object);
		GUIStyle gUIStyle2 = default(GUIStyle);
		string label3 = default(string);
		GUIStyle gUIStyle6 = default(GUIStyle);
		object obj13 = default(object);
		string text6 = default(string);
		int[] array = default(int[]);
		while (true)
		{
			List<MonoBehaviour> list = attributeContainers;
			if (attributeContainers == null)
			{
				break;
			}
			if (num2 < (float)list._size)
			{
				bool flag = !(num2 < (float)list._size);
				MonoBehaviour[] items = list._items;
				if (list._items == null)
				{
					break;
				}
				bool flag2 = !(num2 < (float)items.Length);
				UnityEngine.Object obj = items[num2];
				if ((object)items[num2] != null && obj.m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1852F1400");
					if (obj2 != null)
					{
						object obj3 = obj + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
						bool flag3 = debugGUIPrintFields == null;
						if (flag3)
						{
							break;
						}
						int num3 = debugGUIPrintFields.FindEntry(type);
						string text = (string)obj4;
						object obj5 = text2;
						gUIContent2 = (GUIContent)(object)type;
						if (!flag3)
						{
							if (debugGUIPrintFields == null)
							{
								break;
							}
							HashSet<FieldInfo> hashSet2 = debugGUIPrintFields.get_Item(type);
							if (hashSet2 == null)
							{
								break;
							}
							HashSet<FieldInfo> hashSet3 = hashSet2;
							while (enumerator3.MoveNext())
							{
								float num4 = 0f;
								string text3 = ((UnityEngine.Object)items[num2]).GetName();
								float value2 = ((float*)(nint)num4)->m_value;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2996 @ rdx_v65 (System.Single)+1B8] (should have been resolved before IL gen)");
								float value3 = ((float*)(nint)num4)->m_value;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3001 @ r8_v61 (System.Single)+2C8] (should have been resolved before IL gen)");
								string label = $"{text3} {obj6}: {obj7}";
								DrawLabel(label);
								obj4 = obj6;
								text2 = text3;
								hashSet3 = (HashSet<FieldInfo>)obj7;
							}
							text = (string)obj4;
							obj5 = text2;
							enumerator3 = enumerator4;
							hashSet = (HashSet<PropertyInfo>)(object)hashSet3;
							enumerator = (HashSet<object>.Enumerator)0;
							gUIContent2 = (GUIContent)(object)type;
						}
						bool flag4 = debugGUIPrintProperties == null;
						if (flag4)
						{
							break;
						}
						int num5 = debugGUIPrintProperties.FindEntry((Type)(object)gUIContent2);
						obj4 = text;
						text2 = (string)obj5;
						if (!flag4)
						{
							if (debugGUIPrintProperties == null)
							{
								break;
							}
							HashSet<PropertyInfo> hashSet4 = debugGUIPrintProperties.get_Item((Type)(object)gUIContent2);
							if (hashSet4 == null)
							{
								break;
							}
							hashSet = hashSet4;
							while (enumerator2.MoveNext())
							{
								GUIContent gUIContent3 = null;
								string text4 = ((UnityEngine.Object)items[num2]).GetName();
								nint num6 = (nint)gUIContent3;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3011 @ rdx_v56 (Il2CppClass<UnityEngine.GUIContent>)+1B8] (should have been resolved before IL gen)");
								nint num7 = (nint)gUIContent3;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3016 @ r9_v26 (Il2CppClass<UnityEngine.GUIContent>)+2F8] (should have been resolved before IL gen)");
								string label2 = $"{text4} {obj8}: {obj9}";
								DrawLabel(label2);
								text = text4;
								obj5 = obj8;
								hashSet = (HashSet<PropertyInfo>)obj9;
								gUIContent2 = null;
							}
							enumerator2 = enumerator5;
							obj4 = text;
							text2 = (string)obj5;
							value = (Color)0;
						}
					}
				}
				num2++;
				continue;
			}
			if (persistentLogs == null)
			{
				break;
			}
			Dictionary<object, string>.ValueCollection values = persistentLogs.Values;
			if (values == null)
			{
				break;
			}
			while (true)
			{
				bool flag5 = gUIContent4 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ stack_-108_v16 (UnityEngine.GUIContent)+2C]");
				bool flag6 = obj10 != null;
				GUIStyle gUIStyle = gUIStyle2;
				while (true)
				{
					bool flag7 = gUIContent4 == null;
					GUIStyle gUIStyle3 = gUIStyle;
					string tooltip = gUIContent4.m_Tooltip;
					if (System.Runtime.CompilerServices.Unsafe.As<GUIStyle, UIntPtr>(ref gUIStyle3) < System.Runtime.CompilerServices.Unsafe.As<string, UIntPtr>(ref tooltip))
					{
						Dictionary<object, string> image = (Dictionary<object, string>)(object)gUIContent4.m_Image;
						gUIStyle2 = (GUIStyle)(gUIStyle + 1);
						bool flag8 = (object)gUIContent4.m_Image == null;
						GUIStyle gUIStyle4 = gUIStyle;
						Dictionary<object, string>.Entry[] entries = image._entries;
						bool flag9 = System.Runtime.CompilerServices.Unsafe.As<GUIStyle, UIntPtr>(ref gUIStyle4) >= System.Runtime.CompilerServices.Unsafe.As<Dictionary<object, string>.Entry[], UIntPtr>(ref entries);
						object obj11 = gUIStyle * 2;
						GUIStyle gUIStyle5 = (object)gUIStyle + obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1279 @ rcx_v68 (System.Collections.Generic.Dictionary`2<System.Object, System.String>)+20+v2343 @ r8_v39 (UnityEngine.GUIStyle)*8]");
						bool flag10 = (nint)0 < (nint)0;
						gUIStyle = gUIStyle2;
						if (!flag10)
						{
							goto IL_0570;
						}
						continue;
					}
					break;
				}
				break;
				IL_0570:
				DrawLabel(label3);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (DebugGUI)+88]");
			bool flag11 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186945AEBh\"");
			string text5 = (string)(object)gUIContent4;
			if (!flag11)
			{
				Queue<TransientLog> queue = transientLogs;
				if (transientLogs == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ rax_v105 (System.Collections.Generic.Queue`1<DebugGUI+TransientLog>)+20]");
				bool flag12 = (nint)0 == 0;
				text5 = (string)(object)gUIContent4;
				if (!flag12)
				{
					DrawLabel("-------------------");
					text5 = "-------------------";
				}
			}
			Dictionary<object, string> dictionary = (Dictionary<object, string>)(object)transientLogs;
			if (transientLogs == null)
			{
				break;
			}
			object obj12 = (object)(&gUIStyle6);
			while (true)
			{
				bool flag13 = gUIStyle6 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v722 @ stack_-F0_v16 (UnityEngine.GUIStyle)+24]");
				bool flag14 = obj13 != null;
				bool flag15 = (nint)array == -2;
				array = array;
				if (flag15)
				{
					break;
				}
				array = (int[])(array + 1);
				if ((object)array == gUIStyle6.m_Hover)
				{
					break;
				}
				dictionary = (Dictionary<object, string>)(nint)gUIStyle6.m_Ptr;
				bool flag16 = gUIStyle6.m_Ptr == (IntPtr)0;
				nint num8 = (nint)((object)array + (object)gUIStyle6.m_Normal);
				nint num9 = num8 - dictionary._entries;
				if (num8 < (nint)dictionary._entries)
				{
					num9 = num8;
				}
				bool flag17 = num9 >= (nint)dictionary._entries;
				bool flag18 = (nint)array < 0;
				DrawLabel(text6);
				text5 = text6;
			}
			_ = 4294967294L;
			_ = 0;
			while (true)
			{
				HashSet<object>.Enumerator enumerator6 = (HashSet<object>.Enumerator)Screen.height;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (DebugGUI)+88]");
				if (0 > (nint)enumerator6)
				{
					Queue<TransientLog> queue2 = transientLogs;
					if (transientLogs == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v966 @ rax_v79 (System.Collections.Generic.Queue`1<DebugGUI+TransientLog>)+20]");
					if ((nint)0 <= (nint)0)
					{
						return;
					}
					dictionary = (Dictionary<object, string>)(object)transientLogs;
					if (transientLogs == null)
					{
						break;
					}
					int[] buckets = dictionary._buckets;
					bool flag19 = dictionary._count == 0;
					if (dictionary._buckets == null)
					{
						break;
					}
					bool flag20 = (nint)dictionary._entries >= buckets.Length;
					object obj14 = dictionary._entries + 2;
					object obj15 = obj14 + obj14;
					_ = 0;
					text5 = (string)(dictionary._entries + 1);
					array = dictionary._buckets;
					if (dictionary._buckets == null)
					{
						break;
					}
					bool flag21 = (nint)text5 == array.Length;
					string entries2 = null;
					if (!flag21)
					{
						entries2 = text5;
					}
					dictionary._entries = (Dictionary<object, string>.Entry[])(object)entries2;
					int count = dictionary._count - 1;
					dictionary._count = count;
					int freeList = dictionary._freeList + 1;
					dictionary._freeList = freeList;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (DebugGUI)+88]");
					float num10 = 0f - 15f;
					continue;
				}
				return;
			}
			break;
		}
		throw new NullReferenceException();
	}

	private unsafe void DrawLabel(string label)
	{
		//IL_0029: Expected O, but got Ref
		//IL_0050: Expected O, but got F4
		//IL_0080: Invalid comparison between F4 and O
		//IL_00ae: Expected F4, but got O
		labelGuiContent.text = label;
		Rect rect = default(Rect);
		GUI.Label((Rect)(&rect), labelGuiContent);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (DebugGUI)+88]");
		float num = 0f + 15f;
		Vector2 vector = (Vector2)textWidth;
		GUIStyle none = GUIStyle.none;
		Vector2 vector2 = none.Internal_CalcSize(labelGuiContent);
		float num2 = textWidth;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2))
		{
			vector = vector2;
		}
		textWidth = (float)vector;
	}

	private unsafe void DrawGraphs()
	{
		//IL_0050: Expected F4, but got I4
		//IL_0d4d: Expected O, but got I4
		//IL_0d5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5f: Expected O, but got Unknown
		//IL_0d69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6e: Expected O, but got Unknown
		//IL_0115: Expected O, but got I
		//IL_0125: Expected O, but got I
		//IL_014c: Expected O, but got I
		//IL_00b0: Expected O, but got Ref
		//IL_00c1: Expected O, but got F4
		//IL_0183: Expected F4, but got O
		//IL_01ef: Expected O, but got I
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_02f4: Expected O, but got I4
		//IL_0e2e: Expected O, but got Ref
		//IL_02c9: Expected O, but got Ref
		//IL_02d2: Expected O, but got I4
		//IL_0805: Expected O, but got I
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_0ed8: Expected O, but got I4
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Expected O, but got Unknown
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Expected O, but got Unknown
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		//IL_0433: Expected F4, but got I4
		//IL_0443: Expected F4, but got I4
		//IL_088a: Expected O, but got I
		//IL_0898: Unknown result type (might be due to invalid IL or missing references)
		//IL_089d: Expected O, but got Unknown
		//IL_08ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f3: Expected O, but got Unknown
		//IL_0909: Unknown result type (might be due to invalid IL or missing references)
		//IL_090e: Expected O, but got Unknown
		//IL_0946: Invalid comparison between F4 and O
		//IL_08db: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e0: Expected O, but got Unknown
		//IL_0985: Invalid comparison between O and F4
		//IL_050e: Expected O, but got Ref
		//IL_1003: Expected O, but got I4
		//IL_064d: Expected O, but got Ref
		//IL_06bf: Expected O, but got Ref
		//IL_06cd: Expected O, but got Ref
		//IL_06e9: Expected O, but got I
		//IL_0aaa: Expected O, but got I
		//IL_0792: Expected O, but got Ref
		//IL_0ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abd: Expected O, but got Unknown
		//IL_07a9: Expected O, but got I
		//IL_07c2: Expected O, but got I
		//IL_07d2: Expected O, but got I
		//IL_0b0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b13: Expected O, but got Unknown
		//IL_0b29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2e: Expected O, but got Unknown
		//IL_0afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b00: Expected O, but got Unknown
		//IL_0b68: Expected O, but got Ref
		//IL_0b9d: Expected O, but got Ref
		//IL_0c80: Expected O, but got Ref
		//IL_0c8e: Expected O, but got Ref
		//IL_0c98: Expected I4, but got F4
		//IL_0cf5: Expected O, but got Ref
		//IL_0e34->IL0e34: Incompatible stack heights: 2 vs 0
		//IL_07ef->IL0ea8: Incompatible stack heights: 4 vs 2
		//IL_049a->IL0e53: Incompatible stack heights: 5 vs 4
		//IL_0958->IL0f22: Incompatible stack heights: 6 vs 4
		//IL_0997->IL0f22: Incompatible stack heights: 6 vs 4
		//IL_09ce->IL0f22: Incompatible stack heights: 6 vs 4
		//IL_0a15->IL0f22: Incompatible stack heights: 6 vs 4
		//IL_0d24->IL0d24: Incompatible stack heights: 8 vs 6
		//IL_07e2->IL0e53: Incompatible stack heights: 9 vs 4
		//IL_0d1f->IL0fae: Incompatible stack heights: 8 vs 6
		//IL_0d10->IL0f88: Incompatible stack heights: 11 vs 8
		float num;
		float num2;
		if (!isOnRight)
		{
			num = 5f;
			num2 = 0f;
		}
		else
		{
			object obj = Screen.width;
			object obj2 = obj + 4294966696L;
			object obj3 = obj2 - graphLabelWidth;
			num2 = (float)obj3 - 5f;
			num = 5f;
		}
		Color color = backgroundColor;
		Color value = default(Color);
		GUI.set_backgroundColor_Injected(ref value);
		HashSet<int>.Enumerator enumerator = default(HashSet<int>.Enumerator);
		float num5 = default(float);
		float num6 = default(float);
		while (enumerator.MoveNext())
		{
			float num3 = graphLabelWidth;
			float num4 = 0f * 103f;
			GUIContent content = GUIContent.Temp("");
			GUI.Box((Rect)(&num5), content, boxStyle);
			num6 = num2;
			color = (Color)num4;
		}
		graphLabelWidth = 0f;
		HashSet<int> hashSet = graphGroupBoxesDrawn;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1007 @ rbx_v3 (System.Collections.Generic.HashSet`1<System.Int32>)+24]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1007 @ rbx_v3 (System.Collections.Generic.HashSet`1<System.Int32>)+18]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1007 @ rbx_v3 (System.Collections.Generic.HashSet`1<System.Int32>)+24]");
			Array.Clear((Array)num7, 0, 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1007 @ rbx_v3 (System.Collections.Generic.HashSet`1<System.Int32>)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1007 @ rbx_v3 (System.Collections.Generic.HashSet`1<System.Int32>)+10]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1232 @ r8_v76+18]");
			Array.Clear((Array)num8, 0, 0);
			_ = 0;
			_ = 4294967295L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1007 @ rbx_v3 (System.Collections.Generic.HashSet`1<System.Int32>)+38]");
		_ = (nint)0 + (nint)1;
		Dictionary<object, GraphContainer>.ValueCollection values = graphDictionary.Values;
		float num9 = (float)color;
		IntPtr intPtr = default(IntPtr);
		object obj5 = default(object);
		object obj7 = default(object);
		object obj11 = default(object);
		object obj13 = default(object);
		float num12 = default(float);
		Color value2 = default(Color);
		Color value3 = default(Color);
		Dictionary<object, GraphContainer> value4 = default(Dictionary<object, GraphContainer>);
		Color value5 = default(Color);
		float num21 = default(float);
		Dictionary<object, GraphContainer>.ValueCollection.Enumerator enumerator2 = default(Dictionary<object, GraphContainer>.ValueCollection.Enumerator);
		Color color2 = default(Color);
		float num25 = default(float);
		Dictionary<object, GraphContainer> dictionary2 = default(Dictionary<object, GraphContainer>);
		Dictionary<object, GraphContainer>.ValueCollection.Enumerator enumerator3 = default(Dictionary<object, GraphContainer>.ValueCollection.Enumerator);
		float num36 = default(float);
		Dictionary<object, GraphContainer> dictionary3 = default(Dictionary<object, GraphContainer>);
		GraphContainer graphContainer2 = default(GraphContainer);
		float num41 = default(float);
		while (true)
		{
			bool flag = intPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ stack_-1C8_v4 (Il2CppMethodInfo)+2C]");
			bool flag2 = obj5 != null;
			object obj6 = obj7;
			bool flag3;
			do
			{
				object obj8 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ stack_-1C8_v4 (Il2CppMethodInfo)+20]");
				if ((nint)obj8 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ stack_-1C8_v4 (Il2CppMethodInfo)+18]");
					Dictionary<object, GraphContainer> dictionary = (Dictionary<object, GraphContainer>)0;
					obj7 = obj6 + 1;
					object obj9 = obj6 * 2;
					object obj10 = obj6 + obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v878 @ rcx_v145 (System.Collections.Generic.Dictionary`2<System.Object, DebugGUI+GraphContainer>)+20+v1377 @ r8_v65*8]");
					flag3 = (nint)0 < (nint)0;
					obj6 = obj7;
					continue;
				}
				nint num10 = intPtr;
				HashSet<int> hashSet2 = graphGroupBoxesDrawn;
				while (true)
				{
					bool flag4 = (object)enumerator == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ stack_-220_v2 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>)+38]");
					bool flag5 = obj11 != null;
					object obj12 = obj13;
					while (true)
					{
						object obj14 = obj12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ stack_-220_v2 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>)+24]");
						if ((nint)obj14 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ stack_-220_v2 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>)+18]");
							num10 = 0;
							object obj15 = obj12 * 2;
							object obj16 = obj12 + obj15;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1228 @ rdx_v12 (Il2CppMethodInfo)+20+v3527 @ rax_v168*4]");
							if ((nint)0 >= (nint)0)
							{
								break;
							}
							obj12++;
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ stack_-220_v2 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>)+24]");
						object obj17 = (nint)0 + (nint)1;
						Dictionary<object, GraphContainer> ret;
						Input.get_mousePosition_Injected(out *(Vector3*)(&ret));
						object obj18 = Screen.height;
						float num11 = (float)obj18 - num12;
						if (freezeGraphs)
						{
							bool mouseButton = Input.GetMouseButton(0);
							if (!mouseButton)
							{
								freezeGraphs = mouseButton;
							}
						}
						object obj19 = obj17;
						while (true)
						{
							bool flag6 = (object)enumerator == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ stack_-220_v2 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>)+38]");
							bool flag7 = obj11 != null;
							while (true)
							{
								object obj20 = obj19;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ stack_-220_v2 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>)+24]");
								if ((nint)obj20 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ stack_-220_v2 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>)+18]");
									object obj21 = 0;
									object obj22 = obj19 * 2;
									object obj23 = obj19 + obj22;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1230 @ rdx_v17+20+v5718 @ rax_v61*4]");
									if ((nint)0 >= (nint)0)
									{
										break;
									}
									obj19++;
									continue;
								}
								return;
							}
							object obj24 = obj19 * 2;
							object obj25 = obj19 + obj24;
							obj19++;
							float num13 = num2 + 600f;
							float num14 = num13 + graphLabelWidth;
							float num15 = num14 + num;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num15) <= System.Runtime.CompilerServices.Unsafe.As<Dictionary<object, GraphContainer>, UIntPtr>(ref ret))
							{
								continue;
							}
							float num16 = graphLabelWidth + num2;
							float num17 = num16 + num;
							if (System.Runtime.CompilerServices.Unsafe.As<Dictionary<object, GraphContainer>, UIntPtr>(ref ret) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num17))
							{
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1230 @ rdx_v17+28+v5141 @ rax_v63*4]");
							float num18 = 0f * 103f;
							if (num11 > num18)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1230 @ rdx_v17+28+v5141 @ rax_v63*4]");
								float num19 = 0f * 103f;
								float num20 = num19 + 100f;
								if (num20 > num11)
								{
									break;
								}
							}
						}
						object obj26 = Input.GetMouseButtonDown(0);
						if (obj26 != null)
						{
							freezeGraphs = true;
						}
						hashSet2 = graphGroupBoxesDrawn;
						object obj27 = obj19;
						while (true)
						{
							bool flag8 = (object)enumerator == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ stack_-220_v2 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>)+38]");
							bool flag9 = obj11 != null;
							object obj28 = obj27;
							while (true)
							{
								object obj29 = obj28;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ stack_-220_v2 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>)+24]");
								if ((nint)obj29 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ stack_-220_v2 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>)+18]");
									object obj30 = 0;
									object obj31 = obj28 * 2;
									object obj32 = obj28 + obj31;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6203 @ rdx_v21+20+v7745 @ rax_v78*4]");
									if ((nint)0 >= (nint)0)
									{
										break;
									}
									obj28++;
									continue;
								}
								return;
							}
							object obj33 = obj28 * 2;
							object obj34 = obj28 + obj33;
							object obj35 = obj28 + 1;
							GUI.set_backgroundColor_Injected(ref value2);
							GUI.set_color_Injected(ref value3);
							GUIContent content2 = GUIContent.Temp("");
							GUI.Box((Rect)(&value4), content2, boxStyle);
							GUI.set_backgroundColor_Injected(ref value5);
							GUI.set_color_Injected(ref *(Color*)(&value4));
							GUIContent content3 = GUIContent.Temp("");
							GUI.Box((Rect)(&num21), content3, boxStyle);
							float num22 = graphLabelWidth + num2;
							float num23 = num22 + num;
							float num24 = (float)ret - num23;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm0\"");
							Dictionary<object, GraphContainer>.ValueCollection values2 = graphDictionary.Values;
							while (enumerator2.MoveNext())
							{
								GraphContainer graphContainer = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6203 @ rdx_v21+28+v8153 @ rax_v80*4]");
								if ((nint)0 == graphContainer.group)
								{
									bool flag10 = minMaxTextStyle == null;
									GUIStyleState normal = minMaxTextStyle.normal;
									bool flag11 = normal == null;
									normal.textColor = (Color)(&color2);
									GUI.color = (Color)(&hashSet2);
									float value6 = ((GraphContainer)null).GetValue((int)num24);
									string text = num25.ToString("F3");
									bool flag12 = labelGuiContent == null;
									labelGuiContent.text = text;
									GUI.Label((Rect)(&dictionary2), labelGuiContent, minMaxTextStyle);
									color2 = graphContainer.color;
								}
							}
							obj27 = obj35;
						}
					}
					object obj36 = obj12 * 2;
					object obj37 = obj12 + obj36;
					obj13 = obj12 + 1;
					Dictionary<object, GraphContainer>.ValueCollection values3 = graphDictionary.Values;
					float num26 = 0f;
					while (enumerator3.MoveNext())
					{
						float num27 = 0f;
						bool flag13 = labelGuiContent == null;
						labelGuiContent.text = "";
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rsi_v8 (System.Single)+3C]");
						nint num28 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1228 @ rdx_v12 (Il2CppMethodInfo)+28+v4712 @ rax_v170*4]");
						if (num28 == 0)
						{
							bool flag14 = minMaxTextStyle == null;
							GUIStyleState normal2 = minMaxTextStyle.normal;
							bool flag15 = normal2 == null;
							bool flag16 = normal2.m_Ptr == (IntPtr)0;
							GUIStyleState.set_textColor_Injected(normal2.m_Ptr, ref *(Color*)(&value4));
							GUI.color = (Color)(&value3);
							string text2 = ((float*)32)->ToString("F2");
							string text3 = ((float*)24)->ToString("F2");
							bool flag17 = minMaxTextStyle == null;
							Vector2 vector = minMaxTextStyle.Internal_CalcSize(labelGuiContent);
							labelGuiContent.text = text2;
							labelGuiContent.text = text3;
							Vector2 vector2 = minMaxTextStyle.Internal_CalcSize(labelGuiContent);
							bool flag18 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2);
							Vector2 vector3 = vector;
							if (!flag18)
							{
								vector3 = vector2;
							}
							string text4 = ((float*)24)->ToString("F2");
							labelGuiContent.text = text4;
							float num29 = (float)vector3 + num;
							num26 += num29;
							float num30 = graphLabelWidth + num2;
							float num31 = num30 + num;
							float num32 = num31 - num26;
							GUI.Label((Rect)(&num6), labelGuiContent, minMaxTextStyle);
							string text5 = ((float*)32)->ToString("F2");
							labelGuiContent.text = text5;
							float num33 = graphLabelWidth + num2;
							float num34 = num33 + num;
							float num35 = num34 - num26;
							GUI.Label((Rect)(&num36), labelGuiContent, minMaxTextStyle);
							GUI.color = (Color)(&value2);
							GUIContent gUIContent = labelGuiContent;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rsi_v8 (System.Single)+10]");
							gUIContent.text = (string)0;
							GUIStyle none = GUIStyle.none;
							Vector2 vector4 = none.Internal_CalcSize(labelGuiContent);
							num9 = (float)vector4 + num;
							float num37 = Mathf.Max(new float[3] { num9, graphLabelWidth, num26 });
							graphLabelWidth = num37;
							GUI.Label((Rect)(&dictionary3), labelGuiContent);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rsi_v8 (System.Single)+2C]");
							value2 = (Color)0;
							num36 = num35;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
							value3 = (Color)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2195 @ rsi_v8 (System.Single)+2C]");
							value4 = (Dictionary<object, GraphContainer>)0;
							num6 = num32;
						}
					}
					num10 = 0;
				}
			}
			while (flag3);
			object obj38;
			float num39;
			if (graphGroupBoxesDrawn.AddIfNotPresent(graphContainer2.group))
			{
				num9 = (float)graphContainer2.group * 103f;
				float num38 = graphLabelWidth + num2;
				float num3 = num38 + num;
				GUI.Box((Rect)(&num6), "", boxStyle);
				obj38 = 0;
				num39 = 103f;
				num6 = num3;
			}
			else
			{
				obj38 = 0;
				num39 = 103f;
			}
			float num40 = (float)graphContainer2.group * num39;
			num12 = num40 + (float)obj38;
			graphContainer2.Draw((Rect)(&num41));
		}
	}

	public unsafe static void ForceReinitializeAttributes()
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_0119: Expected O, but got Ref
		//IL_012f: Expected I, but got O
		//IL_013d: Expected I, but got O
		//IL_014d: Expected O, but got I
		//IL_017b: Expected O, but got Ref
		//IL_0199: Expected O, but got I
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Expected O, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_03ae: Expected I, but got O
		//IL_03bc: Expected I, but got O
		//IL_03cc: Expected O, but got I
		//IL_0411: Expected O, but got I
		List<object> list = new List<object>();
		DebugGUI instance = Instance;
		Dictionary<object, GraphContainer>.KeyCollection keys = instance.graphDictionary.Keys;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj11 = default(object);
		object obj12 = default(object);
		object obj14 = default(object);
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		object obj21 = default(object);
		object obj24 = default(object);
		while (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ stack_-68_v19+2C]");
			Dictionary<object, GraphContainer> dictionary;
			if (obj2 == null)
			{
				object obj3 = obj4;
				object obj6;
				bool flag;
				do
				{
					object obj5 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ stack_-68_v19+20]");
					if ((nint)obj5 < 0)
					{
						obj6 = obj3 + 1;
						object obj7 = obj3 * 2;
						object obj8 = obj3 + obj7;
						object obj9 = obj8 * 8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ stack_-68_v19+18]");
						object obj10 = 0 + obj9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v993 @ rax_v188+20]");
						flag = (nint)0 < (nint)0;
						obj3 = obj6;
						continue;
					}
					while (enumerator.MoveNext())
					{
						DebugGUI instance2 = Instance;
						bool flag2 = (object)instance2 == null;
						dictionary = null;
						if (!flag2)
						{
							instance2.InstanceRemoveGraph(null);
							continue;
						}
						throw new NullReferenceException();
					}
					int version = list._version + 1;
					list._version = version;
					list._size = 0;
					if (list._size > 0)
					{
						Array.Clear(list._items, 0, list._size);
					}
					DebugGUI instance3 = Instance;
					Dictionary<object, string>.KeyCollection keys2 = instance3.persistentLogs.Keys;
					while (obj11 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_-80_v20+2C]");
						Dictionary<object, object> dictionary2;
						if (obj12 == null)
						{
							object obj13 = obj14;
							object obj16;
							bool flag3;
							do
							{
								object obj15 = obj13;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_-80_v20+20]");
								if ((nint)obj15 < 0)
								{
									obj16 = obj13 + 1;
									object obj17 = obj13 * 2;
									object obj18 = obj13 + obj17;
									object obj19 = obj18 * 8;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_-80_v20+18]");
									object obj20 = 0 + obj19;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1709 @ rax_v162+20]");
									flag3 = (nint)0 < (nint)0;
									obj13 = obj16;
									continue;
								}
								while (enumerator2.MoveNext())
								{
									DebugGUI instance4 = Instance;
									bool flag4 = (object)instance4 == null;
									dictionary2 = null;
									if (!flag4)
									{
										if (instance4.persistentLogs != null)
										{
											bool flag5 = ((Dictionary<object, object>)(object)instance4.persistentLogs).Remove((object)null);
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								DebugGUI instance5 = Instance;
								List<MonoBehaviour> list2 = new List<MonoBehaviour>();
								instance5.attributeContainers = list2;
								DebugGUI instance6 = Instance;
								Dictionary<Type, HashSet<FieldInfo>> dictionary3 = new Dictionary<Type, HashSet<FieldInfo>>();
								instance6.debugGUIPrintFields = dictionary3;
								DebugGUI instance7 = Instance;
								Dictionary<Type, HashSet<PropertyInfo>> dictionary4 = new Dictionary<Type, HashSet<PropertyInfo>>();
								instance7.debugGUIPrintProperties = dictionary4;
								DebugGUI instance8 = Instance;
								Dictionary<Type, HashSet<FieldInfo>> dictionary5 = new Dictionary<Type, HashSet<FieldInfo>>();
								instance8.debugGUIGraphFields = dictionary5;
								DebugGUI instance9 = Instance;
								Dictionary<Type, HashSet<PropertyInfo>> dictionary6 = new Dictionary<Type, HashSet<PropertyInfo>>();
								instance9.debugGUIGraphProperties = dictionary6;
								DebugGUI instance10 = Instance;
								Dictionary<Type, int> dictionary7 = new Dictionary<Type, int>();
								instance10.typeInstanceCounts = dictionary7;
								DebugGUI instance11 = Instance;
								Dictionary<MonoBehaviour, List<AttributeKey>> dictionary8 = new Dictionary<MonoBehaviour, List<AttributeKey>>();
								instance11.attributeKeys = dictionary8;
								DebugGUI instance12 = Instance;
								instance12.RegisterAttributes();
								return;
							}
							while (flag3);
							bool flag6 = obj21 == null;
							obj14 = obj16;
							if (flag6)
							{
								continue;
							}
							nint num = (nint)obj21;
							nint num2 = (nint)typeof(AttributeKey);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1640 @ r8_v70 (Il2CppClass<DebugGUI+AttributeKey>)+130]");
							Dictionary<object, string> dictionary9 = (Dictionary<object, string>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1642 @ r9_v23 (Il2CppClass<System.Object>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1640 @ r8_v70 (Il2CppClass<DebugGUI+AttributeKey>)+130]");
							bool flag7 = num3 < 0;
							obj14 = obj16;
							if (flag7)
							{
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1642 @ r9_v23 (Il2CppClass<System.Object>)+C8]");
							object obj22 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1647 @ rax_v166+FFFFFFF8+v1646 @ rax_v165 (System.Collections.Generic.Dictionary`2<System.Object, System.String>)*8]");
							bool flag8 = 0 != (nint)typeof(AttributeKey);
							obj14 = obj16;
							if (!flag8)
							{
								object obj23 = null;
								obj23 = obj21;
								bool flag9 = obj23 == null;
								obj14 = obj16;
								if (!flag9)
								{
									list.Add(obj21);
									obj14 = obj16;
								}
							}
							continue;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						dictionary2 = null;
						break;
					}
					throw new NullReferenceException();
				}
				while (flag);
				bool flag10 = obj24 == null;
				obj4 = obj6;
				dictionary = (Dictionary<object, GraphContainer>)(&obj24);
				if (flag10)
				{
					continue;
				}
				nint num4 = (nint)obj24;
				nint num5 = (nint)typeof(AttributeKey);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ r8_v82 (Il2CppClass<DebugGUI+AttributeKey>)+130]");
				Dictionary<object, GraphContainer> dictionary10 = (Dictionary<object, GraphContainer>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ r9_v25 (Il2CppClass<System.Object>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ r8_v82 (Il2CppClass<DebugGUI+AttributeKey>)+130]");
				bool flag11 = num6 < 0;
				obj4 = obj6;
				dictionary = (Dictionary<object, GraphContainer>)(&obj24);
				if (flag11)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ r9_v25 (Il2CppClass<System.Object>)+C8]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rax_v192+FFFFFFF8+v786 @ rax_v191 (System.Collections.Generic.Dictionary`2<System.Object, DebugGUI+GraphContainer>)*8]");
				bool flag12 = 0 != (nint)typeof(AttributeKey);
				obj4 = obj6;
				if (!flag12)
				{
					bool flag13 = obj24 == null;
					obj4 = obj6;
					if (!flag13)
					{
						list.Add(obj24);
						obj4 = obj6;
					}
				}
				continue;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			dictionary = null;
			break;
		}
		throw new NullReferenceException();
	}

	private unsafe void RegisterAttributes()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0046: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_1692: Expected O, but got Ref
		//IL_1b19: Expected O, but got Ref
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_16ac: Expected O, but got I
		//IL_00f7: Expected I, but got O
		//IL_011a: Expected O, but got I4
		//IL_0b73: Expected I, but got O
		//IL_0b8f: Expected O, but got I4
		//IL_160c: Expected O, but got I
		//IL_1621: Expected O, but got I
		//IL_176b: Expected O, but got I
		//IL_01a7: Expected O, but got I
		//IL_01cf: Expected O, but got I
		//IL_17df: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e4: Expected O, but got Unknown
		//IL_0c1c: Expected O, but got I
		//IL_0c44: Expected O, but got I
		//IL_01e5: Expected I, but got O
		//IL_01f3: Expected I, but got O
		//IL_0203: Expected O, but got I
		//IL_0231: Expected O, but got I
		//IL_182c: Expected O, but got I4
		//IL_0c5a: Expected I, but got O
		//IL_0c68: Expected I, but got O
		//IL_0c78: Expected O, but got I
		//IL_0ca6: Expected O, but got I
		//IL_044c: Expected O, but got I
		//IL_024f: Expected O, but got I
		//IL_027e: Expected O, but got I
		//IL_046c: Expected I4, but got O
		//IL_047c: Expected O, but got I
		//IL_0ebc: Expected O, but got I
		//IL_0cc4: Expected O, but got I
		//IL_0cf3: Expected O, but got I
		//IL_0b61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b66: Expected O, but got Unknown
		//IL_0edc: Expected I, but got O
		//IL_0eec: Expected O, but got I
		//IL_0492: Expected I, but got O
		//IL_04a0: Expected I, but got O
		//IL_04b0: Expected O, but got I
		//IL_15ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f1: Expected O, but got Unknown
		//IL_0540: Expected O, but got I4
		//IL_0f02: Expected I, but got O
		//IL_0f10: Expected I, but got O
		//IL_0f20: Expected O, but got I
		//IL_0f56: Expected O, but got I
		//IL_04ec: Expected O, but got I
		//IL_0fd7: Expected I, but got O
		//IL_0fe0: Expected O, but got I4
		//IL_1b56: Expected I4, but got O
		//IL_0f74: Expected O, but got I
		//IL_0fa3: Expected O, but got I
		//IL_052a: Expected O, but got I4
		//IL_03e2: Expected O, but got I
		//IL_0fca: Expected O, but got I4
		//IL_0e52: Expected O, but got I
		//IL_0589: Expected O, but got I
		//IL_05ae: Expected I, but got O
		//IL_1029: Expected O, but got I
		//IL_060c: Expected O, but got I
		//IL_0629: Expected O, but got I
		//IL_0639: Expected O, but got I
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		//IL_104e: Expected I, but got O
		//IL_1993: Expected O, but got I
		//IL_19a9: Expected O, but got I
		//IL_10ac: Expected O, but got I
		//IL_10c9: Expected O, but got I
		//IL_10d9: Expected O, but got I
		//IL_10e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e7: Expected O, but got Unknown
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Expected O, but got Unknown
		//IL_06b2: Expected O, but got I4
		//IL_1a63: Expected O, but got I
		//IL_1a79: Expected O, but got I
		//IL_19d9: Expected O, but got I
		//IL_068c: Expected O, but got I4
		//IL_113a: Unknown result type (might be due to invalid IL or missing references)
		//IL_113f: Expected O, but got Unknown
		//IL_1152: Expected O, but got I4
		//IL_0abe: Expected I, but got O
		//IL_1aa9: Expected O, but got I
		//IL_112c: Expected O, but got I4
		//IL_0b07: Expected O, but got I
		//IL_1595: Expected O, but got I
		//IL_15d6: Expected I, but got O
		//IL_07ec: Expected O, but got I
		//IL_128c: Expected O, but got I
		//IL_0848: Expected O, but got I
		//IL_12e8: Expected O, but got I
		//IL_0886: Expected F4, but got I
		//IL_089b: Expected F4, but got I
		//IL_08d5: Expected O, but got I
		//IL_08f6: Expected O, but got Ref
		//IL_0904: Expected O, but got Ref
		//IL_1326: Expected F4, but got I
		//IL_133b: Expected F4, but got I
		//IL_1375: Expected O, but got I
		//IL_1396: Expected O, but got Ref
		//IL_13a4: Expected O, but got Ref
		//IL_0943: Expected O, but got I
		//IL_0958: Expected O, but got I
		//IL_096e: Expected O, but got I
		//IL_13e3: Expected O, but got I
		//IL_13f8: Expected O, but got I
		//IL_0988: Expected O, but got I
		//IL_099f: Expected O, but got I
		//IL_140e: Expected O, but got I
		//IL_1428: Expected O, but got I
		//IL_143f: Expected O, but got I
		//IL_09ff: Expected O, but got I
		//IL_09ff: Expected O, but got I
		//IL_0a13: Expected O, but got I
		//IL_0a8b: Expected O, but got I
		//IL_0a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a99: Expected O, but got Unknown
		//IL_0aa2: Expected O, but got I4
		//IL_149f: Expected O, but got I
		//IL_149f: Expected O, but got I
		//IL_14b3: Expected O, but got I
		//IL_152c: Expected O, but got I
		//IL_1535: Unknown result type (might be due to invalid IL or missing references)
		//IL_153a: Expected O, but got Unknown
		//IL_1543: Expected O, but got I4
		//IL_154b: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		object obj3 = default(object);
		_ = ref obj3;
		object obj4 = default(object);
		_ = ref obj4;
		_ = 0;
		_ = 0;
		_ = 0;
		MonoBehaviour[] array = UnityEngine.Object.FindObjectsOfType<MonoBehaviour>();
		HashSet<MonoBehaviour> hashSet = (HashSet<MonoBehaviour>)(object)new HashSet<object>();
		obj = hashSet;
		_ = 0;
		object obj5 = 0;
		Color color = (Color)0;
		Dictionary<Type, HashSet<FieldInfo>> dictionary = null;
		nint num = 0;
		MonoBehaviour[] array2 = array;
		Dictionary<Type, HashSet<FieldInfo>> dictionary2 = null;
		object obj7 = default(object);
		nint num8 = default(nint);
		Dictionary<Type, HashSet<FieldInfo>> dictionary5 = default(Dictionary<Type, HashSet<FieldInfo>>);
		string text = default(string);
		object obj31 = default(object);
		object arg = default(object);
		object arg2 = default(object);
		Dictionary<Type, HashSet<FieldInfo>> dictionary9 = default(Dictionary<Type, HashSet<FieldInfo>>);
		string text3 = default(string);
		object obj57 = default(object);
		string text5 = default(string);
		object key5 = default(object);
		while (true)
		{
			if ((nint)dictionary2 < array2.Length)
			{
				if ((nint)dictionary >= array2.Length)
				{
					break;
				}
				MonoBehaviour monoBehaviour = array2[(object)dictionary];
				_ = array2[(object)dictionary];
				object obj6 = monoBehaviour + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				nint num2 = (nint)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1585 @ r8_v27 (Il2CppClass<System.Object>)+6D8]");
				System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1585 @ r8_v27 (Il2CppClass<System.Object>)+6D8] (should have been resolved before IL gen)");
				object obj8 = 0;
				dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)obj7;
				while (true)
				{
					object obj9 = obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+18]");
					if ((nint)obj9 >= 0)
					{
						break;
					}
					object obj10 = obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+18]");
					if ((nint)obj10 >= 0)
					{
						goto end_IL_006c;
					}
					Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(DebugGUIPrintAttribute));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+20+v384 @ rsi_v15*8]");
					Attribute customAttribute = Attribute.GetCustomAttribute((MemberInfo)0, typeFromHandle, inherit: true);
					bool flag = customAttribute == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+20+v384 @ rsi_v15*8]");
					dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)0;
					if (!flag)
					{
						nint num3 = (nint)customAttribute;
						nint num4 = (nint)typeof(DebugGUIPrintAttribute);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rdx_v170 (Il2CppClass<DebugGUIPrintAttribute>)+130]");
						Dictionary<Type, HashSet<FieldInfo>> dictionary3 = (Dictionary<Type, HashSet<FieldInfo>>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r8_v124 (Il2CppClass<System.Attribute>)+130]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rdx_v170 (Il2CppClass<DebugGUIPrintAttribute>)+130]");
						bool flag2 = num5 < 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+20+v384 @ rsi_v15*8]");
						dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)0;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r8_v124 (Il2CppClass<System.Attribute>)+C8]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rax_v235+FFFFFFF8+v1892 @ rax_v234 (System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.HashSet`1<System.Reflection.FieldInfo>>)*8]");
							bool flag3 = 0 != (nint)typeof(DebugGUIPrintAttribute);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rdx_v170 (Il2CppClass<DebugGUIPrintAttribute>)+130]");
							dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)0;
							if (!flag3)
							{
								bool flag4 = ((HashSet<object>)obj).AddIfNotPresent((object)monoBehaviour);
								int num6 = debugGUIPrintFields.FindEntry((Type)obj7);
								bool flag5 = num6 >= 0;
								nint num7 = num8;
								if (!flag5)
								{
									HashSet<FieldInfo> value = (HashSet<FieldInfo>)(object)new HashSet<object>();
									bool flag6 = ((Dictionary<object, object>)(object)debugGUIPrintFields).TryInsert(obj7, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									num7 = 0;
								}
								int num9 = debugGUIPrintProperties.FindEntry((Type)obj7);
								bool flag7 = num9 >= 0;
								num8 = num7;
								if (!flag7)
								{
									HashSet<PropertyInfo> value2 = (HashSet<PropertyInfo>)(object)new HashSet<object>();
									bool flag8 = ((Dictionary<object, object>)(object)debugGUIPrintProperties).TryInsert(obj7, (object)value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									num8 = 0;
								}
								dictionary2 = debugGUIPrintFields;
								HashSet<FieldInfo> hashSet2 = debugGUIPrintFields.get_Item((Type)obj7);
								object obj12 = obj8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+18]");
								if ((nint)obj12 >= 0)
								{
									goto end_IL_006c;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+20+v384 @ rsi_v15*8]");
								bool flag9 = ((HashSet<object>)(object)hashSet2).AddIfNotPresent((object)0);
								dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)(object)hashSet2;
							}
						}
					}
					object obj13 = obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+18]");
					if ((nint)obj13 >= 0)
					{
						goto end_IL_006c;
					}
					Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(DebugGUIGraphAttribute));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+20+v384 @ rsi_v15*8]");
					Attribute customAttribute2 = Attribute.GetCustomAttribute((MemberInfo)0, typeFromHandle2, inherit: true);
					bool flag10 = customAttribute2 == null;
					insertionBehavior = (System.Collections.Generic.InsertionBehavior)(int)customAttribute2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+20+v384 @ rsi_v15*8]");
					dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)0;
					if (flag10)
					{
						goto IL_0b58;
					}
					nint num10 = (nint)customAttribute2;
					nint num11 = (nint)typeof(DebugGUIGraphAttribute);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ r8_v90 (Il2CppClass<DebugGUIGraphAttribute>)+130]");
					dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2088 @ rax_v170 (Il2CppClass<System.Attribute>)+130]");
					nint num12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ r8_v90 (Il2CppClass<DebugGUIGraphAttribute>)+130]");
					object obj14;
					if (num12 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2088 @ rax_v170 (Il2CppClass<System.Attribute>)+C8]");
						Dictionary<Type, HashSet<FieldInfo>> dictionary4 = (Dictionary<Type, HashSet<FieldInfo>>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2157 @ rcx_v169 (System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.HashSet`1<System.Reflection.FieldInfo>>)+FFFFFFF8+v1149 @ rcx_v33 (System.Collections.Generic.Dictionary`2<System.Type, System.C…");
						bool flag11 = 0 != (nint)typeof(DebugGUIGraphAttribute);
						dictionary2 = dictionary4;
						if (!flag11)
						{
							obj14 = 1;
							dictionary2 = dictionary4;
							goto IL_1961;
						}
					}
					obj14 = 0;
					goto IL_1961;
					IL_0b58:
					obj8++;
					continue;
					IL_1961:
					bool flag12 = obj14 == null;
					Attribute attribute = null;
					if (!flag12)
					{
						attribute = customAttribute2;
					}
					bool flag13 = attribute == null;
					insertionBehavior = (System.Collections.Generic.InsertionBehavior)(int)customAttribute2;
					if (!flag13)
					{
						object obj15 = obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+18]");
						if ((nint)obj15 >= 0)
						{
							goto end_IL_006c;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+20+v384 @ rsi_v15*8]");
						object obj16 = 0;
						object obj17 = obj16;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2419 @ r8_v91+2C8] (should have been resolved before IL gen)");
						nint num13 = (nint)typeof(float?);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						if (dictionary5 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2424 @ r15_v33 (Il2CppClass<System.Nullable`1<System.Single>>)+40]");
							if (dictionary5 != null)
							{
								throw new InvalidCastException();
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2424 @ r15_v33 (Il2CppClass<System.Nullable`1<System.Single>>)+80]");
						object obj18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2505 @ rdx_v119+38]");
						nint num14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+40]");
						object obj19 = num14 + 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2505 @ rdx_v119+30]");
						object obj20 = 0;
						object obj21 = obj19 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2508 @ rcx_v126+28]");
						if ((nint)0 >= (nint)0)
						{
							obj21 = obj19;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2424 @ r15_v33 (Il2CppClass<System.Nullable`1<System.Single>>)+40]");
						object obj22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2543 @ rax_v176+F8]");
						object obj23 = -16;
						object obj24;
						if (dictionary5 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
							obj24 = 0;
						}
						else
						{
							object obj25 = dictionary5 + 16;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
							obj24 = 1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+40]");
						MemberInfo memberInfo = (MemberInfo)0;
						memberInfo = (MemberInfo)obj24;
						if (obj24 != null)
						{
							bool flag14 = ((HashSet<object>)obj).AddIfNotPresent((object)monoBehaviour);
							int num15 = debugGUIGraphFields.FindEntry((Type)obj7);
							if (num15 < 0)
							{
								HashSet<FieldInfo> value3 = (HashSet<FieldInfo>)(object)new HashSet<object>();
								bool flag15 = ((Dictionary<object, object>)(object)debugGUIGraphFields).TryInsert(obj7, (object)value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							}
							int num16 = debugGUIGraphProperties.FindEntry((Type)obj7);
							if (num16 < 0)
							{
								HashSet<PropertyInfo> value4 = (HashSet<PropertyInfo>)(object)new HashSet<object>();
								bool flag16 = ((Dictionary<object, object>)(object)debugGUIGraphProperties).TryInsert(obj7, (object)value4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							}
							HashSet<FieldInfo> hashSet3 = debugGUIGraphFields.get_Item((Type)obj7);
							object obj26 = obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+18]");
							bool flag17 = (nint)obj26 >= 0;
							dictionary2 = debugGUIGraphFields;
							if (flag17)
							{
								goto end_IL_006c;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+20+v384 @ rsi_v15*8]");
							bool flag18 = ((HashSet<object>)(object)hashSet3).AddIfNotPresent((object)0);
							GraphContainer graphContainer = new GraphContainer(600, 100);
							object obj27 = obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+18]");
							bool flag19 = (nint)obj27 >= 0;
							dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)(object)graphContainer;
							if (flag19)
							{
								goto end_IL_006c;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+20+v384 @ rsi_v15*8]");
							object obj28 = 0;
							object obj29 = obj28;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2902 @ rdx_v139+1B8] (should have been resolved before IL gen)");
							graphContainer.name = text;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v42 (System.Attribute)+14]");
							graphContainer.max = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v42 (System.Attribute)+10]");
							graphContainer.min = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v42 (System.Attribute)+28]");
							graphContainer.group = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v42 (System.Attribute)+2C]");
							graphContainer.autoScale = false;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v42 (System.Attribute)+18]");
							color = (Color)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v42 (System.Attribute)+18]");
							_ = 0;
							_ = 0;
							object obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
							dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182E4DC50");
							if (obj31 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v42 (System.Attribute)+18]");
								color = (Color)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rbx_v42 (System.Attribute)+18]");
								graphContainer.color = (Color)0;
							}
							object obj32 = obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+18]");
							if ((nint)obj32 >= 0)
							{
								goto end_IL_006c;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+20+v384 @ rsi_v15*8]");
							AttributeKey key = new AttributeKey((MemberInfo)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+D8]");
							MonoBehaviour key2 = (MonoBehaviour)0;
							Dictionary<MonoBehaviour, List<AttributeKey>> dictionary6 = attributeKeys;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+D8]");
							int num17 = dictionary6.FindEntry((MonoBehaviour)0);
							if (num17 < 0)
							{
								List<AttributeKey> list = new List<AttributeKey>();
								Dictionary<MonoBehaviour, List<AttributeKey>> dictionary7 = attributeKeys;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+D8]");
								nint num18 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+30]");
								bool flag20 = ((Dictionary<object, object>)(object)dictionary7).TryInsert((object)num18, (object)0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+D8]");
								key2 = (MonoBehaviour)0;
							}
							List<AttributeKey> list2 = attributeKeys.get_Item(key2);
							List<AttributeKey> list3 = ((Dictionary<MonoBehaviour, List<AttributeKey>>)(object)list2).get_Item((MonoBehaviour)(object)key);
							bool flag21 = ((Dictionary<object, object>)(object)graphDictionary).TryInsert((object)key, (object)graphContainer, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)(object)graphs;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A962A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+D8]");
							monoBehaviour = (MonoBehaviour)0;
							obj8++;
							obj5 = 0;
							insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
							num8 = 0;
							continue;
						}
						nint num19 = (nint)obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2658 @ rdx_v121 (Il2CppClass<System.Object>)+1B8] (should have been resolved before IL gen)");
						object obj33 = obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+18]");
						bool flag22 = (nint)obj33 >= 0;
						dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)obj7;
						if (flag22)
						{
							goto end_IL_006c;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rax_v59+20+v384 @ rsi_v15*8]");
						object obj34 = 0;
						object obj35 = obj34;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2683 @ rdx_v123+1B8] (should have been resolved before IL gen)");
						string text2 = $"Cannot cast {arg}.{arg2} to float. This member will be ignored.";
						Debug.LogError(text2);
						insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
						dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)(object)text2;
					}
					goto IL_0b58;
				}
				nint num20 = (nint)obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1721 @ r8_v31 (Il2CppClass<System.Object>)+848] (should have been resolved before IL gen)");
				num = 52;
				object obj36 = 0;
				dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)obj7;
				while (true)
				{
					object obj37 = obj36;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+18]");
					if ((nint)obj37 >= 0)
					{
						break;
					}
					object obj38 = obj36;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+18]");
					if ((nint)obj38 >= 0)
					{
						goto end_IL_006c;
					}
					Type typeFromHandle3 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(DebugGUIPrintAttribute));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+20+v386 @ rsi_v18*8]");
					Attribute customAttribute3 = Attribute.GetCustomAttribute((MemberInfo)0, typeFromHandle3, inherit: true);
					bool flag23 = customAttribute3 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+20+v386 @ rsi_v18*8]");
					dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)0;
					if (!flag23)
					{
						nint num21 = (nint)customAttribute3;
						nint num22 = (nint)typeof(DebugGUIPrintAttribute);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rdx_v90 (Il2CppClass<DebugGUIPrintAttribute>)+130]");
						Dictionary<Type, HashSet<FieldInfo>> dictionary8 = (Dictionary<Type, HashSet<FieldInfo>>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v70 (Il2CppClass<System.Attribute>)+130]");
						nint num23 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rdx_v90 (Il2CppClass<DebugGUIPrintAttribute>)+130]");
						bool flag24 = num23 < 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+20+v386 @ rsi_v18*8]");
						dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)0;
						if (!flag24)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r8_v70 (Il2CppClass<System.Attribute>)+C8]");
							object obj39 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v140+FFFFFFF8+v1974 @ rax_v139 (System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.HashSet`1<System.Reflection.FieldInfo>>)*8]");
							bool flag25 = 0 != (nint)typeof(DebugGUIPrintAttribute);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rdx_v90 (Il2CppClass<DebugGUIPrintAttribute>)+130]");
							dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)0;
							if (!flag25)
							{
								bool flag26 = ((HashSet<object>)obj).AddIfNotPresent((object)monoBehaviour);
								int num24 = debugGUIPrintFields.FindEntry((Type)obj7);
								bool flag27 = num24 >= 0;
								nint num25 = num8;
								if (!flag27)
								{
									HashSet<FieldInfo> value5 = (HashSet<FieldInfo>)(object)new HashSet<object>();
									bool flag28 = ((Dictionary<object, object>)(object)debugGUIPrintFields).TryInsert(obj7, (object)value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									num25 = 0;
								}
								int num26 = debugGUIPrintProperties.FindEntry((Type)obj7);
								bool flag29 = num26 >= 0;
								num8 = num25;
								if (!flag29)
								{
									HashSet<PropertyInfo> value6 = (HashSet<PropertyInfo>)(object)new HashSet<object>();
									bool flag30 = ((Dictionary<object, object>)(object)debugGUIPrintProperties).TryInsert(obj7, (object)value6, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									num8 = 0;
								}
								HashSet<PropertyInfo> hashSet4 = debugGUIPrintProperties.get_Item((Type)obj7);
								object obj40 = obj36;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+18]");
								bool flag31 = (nint)obj40 >= 0;
								dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)(object)debugGUIPrintProperties;
								if (flag31)
								{
									goto end_IL_006c;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+20+v386 @ rsi_v18*8]");
								bool flag32 = ((HashSet<object>)(object)hashSet4).AddIfNotPresent((object)0);
								dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)(object)hashSet4;
							}
						}
					}
					object obj41 = obj36;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+18]");
					if ((nint)obj41 >= 0)
					{
						goto end_IL_006c;
					}
					Type typeFromHandle4 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(DebugGUIGraphAttribute));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+20+v386 @ rsi_v18*8]");
					Attribute customAttribute4 = Attribute.GetCustomAttribute((MemberInfo)0, typeFromHandle4, inherit: true);
					bool flag33 = customAttribute4 == null;
					num = (nint)typeFromHandle4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+20+v386 @ rsi_v18*8]");
					dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)0;
					if (flag33)
					{
						goto IL_15e3;
					}
					nint num27 = (nint)customAttribute4;
					nint num28 = (nint)typeof(DebugGUIGraphAttribute);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ r8_v38 (Il2CppClass<DebugGUIGraphAttribute>)+130]");
					Type type = (Type)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2242 @ rax_v76 (Il2CppClass<System.Attribute>)+130]");
					nint num29 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ r8_v38 (Il2CppClass<DebugGUIGraphAttribute>)+130]");
					bool flag34 = num29 < 0;
					Type type2 = typeFromHandle4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ r8_v38 (Il2CppClass<DebugGUIGraphAttribute>)+130]");
					dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)0;
					object obj42;
					if (!flag34)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2242 @ rax_v76 (Il2CppClass<System.Attribute>)+C8]");
						dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1149 @ rcx_v33 (System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.HashSet`1<System.Reflection.FieldInfo>>)+FFFFFFF8+v2243 @ rcx_v51 (System.Type)*8]");
						bool flag35 = 0 != (nint)typeof(DebugGUIGraphAttribute);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ r8_v38 (Il2CppClass<DebugGUIGraphAttribute>)+130]");
						type2 = (Type)0;
						if (!flag35)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ r8_v38 (Il2CppClass<DebugGUIGraphAttribute>)+130]");
							num = 0;
							obj42 = 1;
							goto IL_1a25;
						}
					}
					num = (nint)type2;
					obj42 = 0;
					goto IL_1a25;
					IL_15e3:
					obj36++;
					continue;
					IL_1a25:
					bool flag36 = obj42 == null;
					Attribute attribute2 = null;
					if (!flag36)
					{
						attribute2 = customAttribute4;
					}
					if (attribute2 != null)
					{
						object obj43 = obj36;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+18]");
						if ((nint)obj43 >= 0)
						{
							goto end_IL_006c;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+20+v386 @ rsi_v18*8]");
						object obj44 = 0;
						object obj45 = obj44;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2522 @ r9_v27+2F8] (should have been resolved before IL gen)");
						nint num30 = (nint)typeof(float?);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						if (dictionary9 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2528 @ r15_v18 (Il2CppClass<System.Nullable`1<System.Single>>)+40]");
							if (dictionary9 != null)
							{
								throw new InvalidCastException();
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2528 @ r15_v18 (Il2CppClass<System.Nullable`1<System.Single>>)+80]");
						object obj46 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2598 @ rdx_v42+38]");
						nint num31 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+48]");
						Dictionary<Type, HashSet<FieldInfo>> dictionary10 = (Dictionary<Type, HashSet<FieldInfo>>)(num31 + 0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2598 @ rdx_v42+30]");
						object obj47 = 0;
						Dictionary<Type, HashSet<FieldInfo>> dictionary11 = (Dictionary<Type, HashSet<FieldInfo>>)(dictionary10 - 16);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2601 @ rcx_v56+28]");
						if ((nint)0 >= (nint)0)
						{
							dictionary11 = dictionary10;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2528 @ r15_v18 (Il2CppClass<System.Nullable`1<System.Single>>)+40]");
						object obj48 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2628 @ rax_v82+F8]");
						object obj49 = -16;
						object obj50;
						if (dictionary9 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
							obj50 = 0;
						}
						else
						{
							object obj51 = dictionary9 + 16;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
							obj50 = 1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+48]");
						MemberInfo memberInfo2 = (MemberInfo)0;
						memberInfo2 = (MemberInfo)obj50;
						if (obj50 != null)
						{
							bool flag37 = ((HashSet<object>)obj).AddIfNotPresent((object)monoBehaviour);
							int num32 = debugGUIGraphFields.FindEntry((Type)obj7);
							if (num32 < 0)
							{
								HashSet<FieldInfo> value7 = (HashSet<FieldInfo>)(object)new HashSet<object>();
								bool flag38 = ((Dictionary<object, object>)(object)debugGUIGraphFields).TryInsert(obj7, (object)value7, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							}
							int num33 = debugGUIGraphProperties.FindEntry((Type)obj7);
							if (num33 < 0)
							{
								HashSet<PropertyInfo> value8 = (HashSet<PropertyInfo>)(object)new HashSet<object>();
								bool flag39 = ((Dictionary<object, object>)(object)debugGUIGraphProperties).TryInsert(obj7, (object)value8, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							}
							HashSet<PropertyInfo> hashSet5 = debugGUIGraphProperties.get_Item((Type)obj7);
							object obj52 = obj36;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+18]");
							bool flag40 = (nint)obj52 >= 0;
							dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)(object)debugGUIGraphProperties;
							if (flag40)
							{
								goto end_IL_006c;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+20+v386 @ rsi_v18*8]");
							bool flag41 = ((HashSet<object>)(object)hashSet5).AddIfNotPresent((object)0);
							GraphContainer graphContainer2 = new GraphContainer(600, 100);
							object obj53 = obj36;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+18]");
							bool flag42 = (nint)obj53 >= 0;
							dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)(object)graphContainer2;
							if (flag42)
							{
								goto end_IL_006c;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+20+v386 @ rsi_v18*8]");
							object obj54 = 0;
							object obj55 = obj54;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2911 @ rdx_v60+1B8] (should have been resolved before IL gen)");
							graphContainer2.name = text3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v25 (System.Attribute)+14]");
							graphContainer2.max = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v25 (System.Attribute)+10]");
							graphContainer2.min = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v25 (System.Attribute)+28]");
							graphContainer2.group = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v25 (System.Attribute)+2C]");
							graphContainer2.autoScale = false;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v25 (System.Attribute)+18]");
							color = (Color)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v25 (System.Attribute)+18]");
							_ = 0;
							_ = 0;
							object obj56 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
							dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182E4DC50");
							if (obj57 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v25 (System.Attribute)+18]");
								color = (Color)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rbx_v25 (System.Attribute)+18]");
								graphContainer2.color = (Color)0;
							}
							object obj58 = obj36;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+18]");
							if ((nint)obj58 >= 0)
							{
								goto end_IL_006c;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+20+v386 @ rsi_v18*8]");
							AttributeKey key3 = new AttributeKey((MemberInfo)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+D8]");
							MonoBehaviour key4 = (MonoBehaviour)0;
							Dictionary<MonoBehaviour, List<AttributeKey>> dictionary12 = attributeKeys;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+D8]");
							int num34 = dictionary12.FindEntry((MonoBehaviour)0);
							if (num34 < 0)
							{
								List<AttributeKey> list4 = new List<AttributeKey>();
								Dictionary<MonoBehaviour, List<AttributeKey>> dictionary13 = attributeKeys;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+D8]");
								nint num35 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+30]");
								bool flag43 = ((Dictionary<object, object>)(object)dictionary13).TryInsert((object)num35, (object)0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+D8]");
								key4 = (MonoBehaviour)0;
							}
							List<AttributeKey> list5 = attributeKeys.get_Item(key4);
							List<AttributeKey> list6 = ((Dictionary<MonoBehaviour, List<AttributeKey>>)(object)list5).get_Item((MonoBehaviour)(object)key3);
							bool flag44 = ((Dictionary<object, object>)(object)graphDictionary).TryInsert((object)key3, (object)graphContainer2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
							dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)(object)graphs;
							((HashSet<MonoBehaviour>)(object)graphs)._002Ector();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+D8]");
							monoBehaviour = (MonoBehaviour)0;
							obj36++;
							obj5 = 0;
							num = (nint)graphContainer2;
							num8 = 0;
							continue;
						}
						object obj59 = obj36;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+18]");
						bool flag45 = (nint)obj59 >= 0;
						dictionary2 = dictionary11;
						if (flag45)
						{
							goto end_IL_006c;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v64+20+v386 @ rsi_v18*8]");
						object obj60 = 0;
						object obj61 = obj60;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2718 @ rdx_v44+1B8] (should have been resolved before IL gen)");
						string text4 = "Cannot cast " + text5 + " to float. This member will be ignored.";
						Debug.LogError(text4);
						num = unchecked((nint)null);
						dictionary2 = (Dictionary<Type, HashSet<FieldInfo>>)(object)text4;
					}
					goto IL_15e3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+D0]");
				dictionary = (Dictionary<Type, HashSet<FieldInfo>>)((nint)0 + (nint)1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+50]");
				array2 = (MonoBehaviour[])0;
				dictionary2 = dictionary;
				continue;
			}
			object obj62 = obj;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ r9_v9+38]");
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+20]");
			_ = 0;
			_ = 0;
			object obj63 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
			while (true)
			{
				HashSet<object>.Enumerator enumerator = (HashSet<object>.Enumerator)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
				if (!((HashSet<object>.Enumerator*)enumerator)->MoveNext())
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+70]");
				object obj64 = 0;
				List<object> list7 = (List<object>)(object)attributeContainers;
				if (attributeContainers != null)
				{
					int version = list7._version + 1;
					list7._version = version;
					object[] items = list7._items;
					int size = list7._size;
					if (list7._items != null)
					{
						if (list7._size >= items.Length)
						{
							List<MonoBehaviour> list8 = attributeContainers;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+70]");
							((List<object>)(object)list8).AddWithResize((object)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+70]");
							size = 0;
						}
						else
						{
							int size2 = list7._size + 1;
							list7._size = size2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+70]");
						if ((nint)0 != 0)
						{
							object obj65 = obj64 + 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
							bool flag46 = typeInstanceCounts == null;
							if (!flag46)
							{
								int num36 = typeInstanceCounts.FindEntry((Type)key5);
								object obj66 = !flag46;
								if (obj66 == null)
								{
									if (typeInstanceCounts == null)
									{
										throw new NullReferenceException();
									}
									bool flag47 = ((Dictionary<object, int>)(object)typeInstanceCounts).TryInsert(key5, 0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								}
								if (typeInstanceCounts == null)
								{
									break;
								}
								int num37 = typeInstanceCounts.get_Item((Type)key5);
								int value9 = num37 + 1;
								bool flag48 = ((Dictionary<object, int>)(object)typeInstanceCounts).TryInsert(key5, value9, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			continue;
			end_IL_006c:
			break;
		}
		throw new IndexOutOfRangeException();
	}

	private void CleanUpDeletedAtributes()
	{
		//IL_0308: Expected O, but got I4
		//IL_00b8: Expected O, but got I4
		//IL_00bc: Expected O, but got I4
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		int num = 0;
		List<AttributeKey>.Enumerator enumerator = (List<AttributeKey>.Enumerator)0;
		Type key = default(Type);
		List<AttributeKey>.Enumerator enumerator2 = default(List<AttributeKey>.Enumerator);
		while (true)
		{
			List<MonoBehaviour> list = attributeContainers;
			if (num >= list._size)
			{
				return;
			}
			if (num >= list._size)
			{
				break;
			}
			MonoBehaviour[] items = list._items;
			MonoBehaviour monoBehaviour = items[num];
			if ((object)items[num] == null || ((UnityEngine.Object)monoBehaviour).m_CachedPtr == (IntPtr)0)
			{
				MonoBehaviour monoBehaviour2 = (MonoBehaviour)((Dictionary<Type, HashSet<PropertyInfo>>)(object)attributeContainers).Remove((Type)num);
				attributeContainers.RemoveAt(num);
				List<AttributeKey> list2 = attributeKeys.get_Item(monoBehaviour2);
				while (enumerator.MoveNext())
				{
					InstanceRemoveGraph(null);
				}
				bool flag = ((Dictionary<object, object>)(object)attributeKeys).Remove((object)monoBehaviour2);
				object obj = monoBehaviour2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				int num2 = typeInstanceCounts.get_Item(key);
				int value = num2 - 1;
				bool flag2 = ((Dictionary<object, int>)(object)typeInstanceCounts).TryInsert((object)key, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
				if (typeInstanceCounts.get_Item(key) == 0)
				{
					int num3 = debugGUIPrintFields.FindEntry(key);
					if (num3 >= 0)
					{
						bool flag3 = ((Dictionary<object, object>)(object)debugGUIPrintFields).Remove((object)key);
					}
					int num4 = debugGUIPrintProperties.FindEntry(key);
					if (num4 >= 0)
					{
						bool flag4 = ((Dictionary<object, object>)(object)debugGUIPrintProperties).Remove((object)key);
					}
					int num5 = debugGUIGraphFields.FindEntry(key);
					if (num5 >= 0)
					{
						bool flag5 = ((Dictionary<object, object>)(object)debugGUIGraphFields).Remove((object)key);
					}
					int num6 = debugGUIGraphProperties.FindEntry(key);
					if (num6 >= 0)
					{
						bool flag6 = ((Dictionary<object, object>)(object)debugGUIGraphProperties).Remove((object)key);
					}
				}
				num--;
				enumerator = enumerator2;
			}
			num++;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private void OnDestroy()
	{
		//IL_0034: Expected O, but got I4
		object obj = Application.isPlaying;
		if (obj != null)
		{
			UnityEngine.Object.Destroy(boxTexture, 0f);
		}
	}

	public DebugGUI()
	{
		//IL_01ad: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11E50]");
		backgroundColor = (Color)0;
		drawInBuild = true;
		displayLogs = true;
		List<GraphContainer> list = new List<GraphContainer>();
		graphs = list;
		Dictionary<object, string> dictionary = new Dictionary<object, string>();
		persistentLogs = dictionary;
		Queue<TransientLog> queue = null;
		TransientLog[] array = Array.Empty<TransientLog>();
		transientLogs = queue;
		Dictionary<object, GraphContainer> dictionary2 = new Dictionary<object, GraphContainer>();
		graphDictionary = dictionary2;
		isOnRight = true;
		GUIContent gUIContent = new GUIContent();
		labelGuiContent = gUIContent;
		HashSet<int> hashSet = new HashSet<int>();
		graphGroupBoxesDrawn = hashSet;
		StringBuilder stringBuilder = new StringBuilder();
		this.stringBuilder = stringBuilder;
		List<MonoBehaviour> list2 = new List<MonoBehaviour>();
		attributeContainers = list2;
		Dictionary<Type, HashSet<FieldInfo>> dictionary3 = new Dictionary<Type, HashSet<FieldInfo>>();
		debugGUIPrintFields = dictionary3;
		Dictionary<Type, HashSet<PropertyInfo>> dictionary4 = new Dictionary<Type, HashSet<PropertyInfo>>();
		debugGUIPrintProperties = dictionary4;
		Dictionary<Type, HashSet<FieldInfo>> dictionary5 = new Dictionary<Type, HashSet<FieldInfo>>();
		debugGUIGraphFields = dictionary5;
		Dictionary<Type, HashSet<PropertyInfo>> dictionary6 = new Dictionary<Type, HashSet<PropertyInfo>>();
		debugGUIGraphProperties = dictionary6;
		Dictionary<Type, int> dictionary7 = new Dictionary<Type, int>();
		typeInstanceCounts = dictionary7;
		Dictionary<MonoBehaviour, List<AttributeKey>> dictionary8 = new Dictionary<MonoBehaviour, List<AttributeKey>>();
		attributeKeys = dictionary8;
	}
}
