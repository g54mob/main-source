using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

public class DebugGUI : MonoBehaviour
{
	private class AttributeKey
	{
		public MemberInfo memberInfo;

		public AttributeKey(MemberInfo memberInfo)
		{
		}
	}

	private struct TransientLog
	{
		public string text;

		public float expiryTime;

		public TransientLog(string text, float duration)
		{
			this.text = null;
			expiryTime = 0f;
		}
	}

	[Serializable]
	private class GraphContainer
	{
		public string name;

		public float max;

		private float defaultMax;

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
		}

		public void SetMinMax(float min, float max, bool isDefault)
		{
		}

		public GraphContainer(int width, int height)
		{
		}

		public void Push(float val)
		{
		}

		public void Clear()
		{
		}

		public void Draw(Rect rect)
		{
		}

		public float GetValue(int index)
		{
			return 0f;
		}

		private void RegenerateGraph()
		{
		}

		private static int Mod(int n, int m)
		{
			return 0;
		}

		private void DrawLine(Texture2D tex, int x0, int y0, int x1, int y1, Color col)
		{
		}

		public void DestroyTextures()
		{
		}
	}

	private static DebugGUI _instance;

	private const int graphWidth = 600;

	private const int graphHeight = 100;

	private const float temporaryLogLifetime = 5f;

	[SerializeField]
	private bool drawInBuild;

	[SerializeField]
	private bool displayGraphs;

	[SerializeField]
	private bool displayLogs;

	[SerializeField]
	private Color backgroundColor;

	[Header("Runtime Debugging Only")]
	[SerializeField]
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

	private static DebugGUI Instance => null;

	private static bool LogsEnabled => false;

	private static bool GraphsEnabled => false;

	public static void LogPersistent(object key, object message)
	{
	}

	public static void RemovePersistent(object key)
	{
	}

	public static void ClearPersistent()
	{
	}

	public static void Log(object message)
	{
	}

	public static void SetGraphsOnRight(bool isOnRight)
	{
	}

	public static void SetGraphProperties(object key, string label, float min, float max, int group, Color color, bool autoScale)
	{
	}

	public static bool GetGraphExists(object key)
	{
		return false;
	}

	public static void Graph(object key, float val)
	{
	}

	public static void RemoveGraph(object key)
	{
	}

	public static void ClearGraph(object key)
	{
	}

	private void InstanceLogPersistent(object key, object message)
	{
	}

	private void InstanceRemovePersistent(object key)
	{
	}

	private void InstanceClearPersistent()
	{
	}

	private void InstanceRemoveGraph(object key)
	{
	}

	private void InstanceClearGraph(object key)
	{
	}

	private void InstanceLog(string str)
	{
	}

	private void InstanceGraph(object key, float val)
	{
	}

	private void InstanceSetGraphProperties(object key, string label, float min, float max, int group, Color color, bool autoScale)
	{
	}

	private bool InstanceGetGraphExists(object key)
	{
		return false;
	}

	private void InstanceCreateGraph(object key)
	{
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnGUI()
	{
	}

	private void InitializeGUIStyles()
	{
	}

	private void DrawLogs()
	{
	}

	private void DrawLabel(string label)
	{
	}

	private void DrawGraphs()
	{
	}

	public static void ForceReinitializeAttributes()
	{
	}

	private void RegisterAttributes()
	{
	}

	private void CleanUpDeletedAtributes()
	{
	}

	private void OnDestroy()
	{
	}
}
