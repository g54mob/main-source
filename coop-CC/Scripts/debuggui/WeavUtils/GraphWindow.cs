using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace WeavUtils
{
	public class GraphWindow : DebugGUIWindow
	{
		[Serializable]
		private class DataExport
		{
			public GraphContainer.DataExport[] data;
		}

		private struct DeferredLabel
		{
			public Vector2 position;

			public string label;

			public Color color;
		}

		private class GraphContainer
		{
			[Serializable]
			public class DataExport
			{
				public string name;

				public float[] values;

				public DataExport(string name, float[] values)
				{
					this.name = name;
					this.values = values;
				}
			}

			public Action OnLabelSizeChange;

			public string name = "<uninitialized>";

			public float max = 1f;

			public float min;

			public bool autoScale;

			public Color color;

			public readonly int group;

			private int currentIndex;

			private readonly float[] values;

			private readonly Vector2[] graphPoints;

			public string minString;

			public string maxString;

			public bool visible = true;

			public GraphContainer(int width, int group = 0)
			{
				this.group = group;
				values = new float[width];
				graphPoints = new Vector2[width];
				SetMinMax(min, max);
			}

			public Color GetModifiedColor(bool highlighted)
			{
				if (!highlighted && visible)
				{
					return color;
				}
				Color.RGBToHSV(color, out var H, out var S, out var V);
				if (!visible)
				{
					V *= 0.3f;
				}
				if (highlighted)
				{
					V *= ((V > 0.9f) ? 0.7f : 1.2f);
				}
				return Color.HSVToRGB(H, S, V);
			}

			public void SetMinMax(float min, float max)
			{
				OnLabelSizeChange?.Invoke();
				this.min = min;
				this.max = max;
				minString = min.ToString("F2");
				maxString = max.ToString("F2");
			}

			public void Push(float val)
			{
				if (autoScale && (val > max || val < min))
				{
					SetMinMax(Mathf.Min(val, min), Mathf.Max(val, max));
				}
				else
				{
					val = Mathf.Clamp(val, min, max);
				}
				values[currentIndex] = val;
				currentIndex = (currentIndex + 1) % values.Length;
			}

			public void Clear()
			{
				for (int i = 0; i < values.Length; i++)
				{
					values[i] = 0f;
				}
			}

			public void Draw(Rect rect)
			{
				GL.Begin(2);
				GL.Color(color);
				int num = values.Length;
				for (int i = 0; i < num; i++)
				{
					float value = values[Mod(currentIndex - i - 1, values.Length)];
					GL.Vertex3(rect.x + rect.width * ((float)i / (float)num), rect.y + Mathf.InverseLerp(max, min, value) * (float)DebugGUI.Settings.graphHeight, 0f);
				}
				GL.End();
			}

			public float GetValue(int index)
			{
				return values[Mod(currentIndex + index, values.Length)];
			}

			public DataExport AsDataExport()
			{
				return new DataExport(name, values);
			}

			private static int Mod(int n, int m)
			{
				return (n % m + m) % m;
			}
		}

		public class GraphAttributeKey
		{
			public MemberInfo memberInfo;

			public GraphAttributeKey(MemberInfo memberInfo)
			{
				this.memberInfo = memberInfo;
			}
		}

		private const int graphLabelFontSize = 12;

		private const int graphLabelPadding = 5;

		private const int graphBlockPadding = 3;

		private const int scrubberBackgroundWidth = 55;

		private List<GraphContainer> graphs = new List<GraphContainer>();

		private HashSet<MonoBehaviour> attributeContainers = new HashSet<MonoBehaviour>();

		private Dictionary<Type, int> typeInstanceCounts = new Dictionary<Type, int>();

		private Dictionary<object, GraphContainer> graphDictionary = new Dictionary<object, GraphContainer>();

		private Dictionary<MonoBehaviour, List<GraphAttributeKey>> attributeKeys = new Dictionary<MonoBehaviour, List<GraphAttributeKey>>();

		private Dictionary<Type, HashSet<FieldInfo>> debugGUIGraphFields = new Dictionary<Type, HashSet<FieldInfo>>();

		private Dictionary<Type, HashSet<PropertyInfo>> debugGUIGraphProperties = new Dictionary<Type, HashSet<PropertyInfo>>();

		private SortedDictionary<int, List<GraphContainer>> graphGroups = new SortedDictionary<int, List<GraphContainer>>();

		private bool freezeGraphs;

		private float graphLabelBoxWidth;

		private GUIStyle graphLabelStyle;

		private GraphContainer lastPressedGraphLabel;

		private List<DeferredLabel> deferredLabels = new List<DeferredLabel>();

		protected void InitializeGUIStyles()
		{
			graphLabelStyle = new GUIStyle();
			graphLabelStyle.fontSize = 12;
		}

		public override void Init()
		{
			base.Init();
			InitializeGUIStyles();
			RegisterAttributes();
			rect.position = new Vector2((float)Screen.width - GetDraggableRect().width, 0f);
		}

		private void LateUpdate()
		{
			if (!Input.GetMouseButton(0))
			{
				freezeGraphs = false;
			}
			if (!freezeGraphs)
			{
				CleanUpDeletedAttributes();
				PollGraphAttributes();
			}
		}

		protected override void OnGUI()
		{
			base.OnGUI();
			int num = 0;
			foreach (List<GraphContainer> value in graphGroups.Values)
			{
				DrawGraphGroup(value, num);
				num++;
			}
			foreach (DeferredLabel deferredLabel in deferredLabels)
			{
				graphLabelStyle.normal.textColor = deferredLabel.color;
				Vector2 position = deferredLabel.position;
				string label = deferredLabel.label;
				GUIStyle style = graphLabelStyle;
				DrawLabel(position, label, default(Vector2), style);
			}
			deferredLabels.Clear();
		}

		public void Graph(object key, float val)
		{
			if (!graphDictionary.ContainsKey(key))
			{
				CreateGraph(key);
			}
			if (!freezeGraphs)
			{
				graphDictionary[key].Push(val);
				RecalculateGraphLabelWidth();
			}
		}

		public void CreateGraph(object key)
		{
			AddGraph(key, new GraphContainer(DebugGUI.Settings.graphWidth));
			RecalculateGraphLabelWidth();
		}

		public void ClearGraph(object key)
		{
			if (graphDictionary.ContainsKey(key))
			{
				graphDictionary[key].Clear();
			}
		}

		public void RemoveGraph(object key)
		{
			if (graphDictionary.ContainsKey(key))
			{
				GraphContainer graphContainer = graphDictionary[key];
				graphs.Remove(graphContainer);
				graphDictionary.Remove(key);
				graphGroups[graphContainer.group].Remove(graphContainer);
				if (graphGroups[graphContainer.group].Count == 0)
				{
					graphGroups.Remove(graphContainer.group);
				}
				RecalculateGraphLabelWidth();
			}
		}

		public void SetGraphProperties(object key, string label, float min, float max, int group, Color color, bool autoScale)
		{
			if (graphDictionary.ContainsKey(key))
			{
				RemoveGraph(key);
			}
			GraphContainer graphContainer = new GraphContainer(DebugGUI.Settings.graphWidth, group);
			AddGraph(key, graphContainer);
			graphContainer.name = label;
			graphContainer.SetMinMax(min, max);
			graphContainer.color = color;
			graphContainer.autoScale = autoScale;
		}

		public void ReinitializeAttributes()
		{
			List<object> list = new List<object>();
			foreach (object key in graphDictionary.Keys)
			{
				if (key is GraphAttributeKey)
				{
					list.Add(key);
				}
			}
			foreach (object item in list)
			{
				RemoveGraph(item);
			}
			attributeContainers = new HashSet<MonoBehaviour>();
			debugGUIGraphFields = new Dictionary<Type, HashSet<FieldInfo>>();
			debugGUIGraphProperties = new Dictionary<Type, HashSet<PropertyInfo>>();
			typeInstanceCounts = new Dictionary<Type, int>();
			attributeKeys = new Dictionary<MonoBehaviour, List<GraphAttributeKey>>();
			RegisterAttributes();
		}

		public string ToJson()
		{
			GraphContainer.DataExport[] array = new GraphContainer.DataExport[graphs.Count];
			for (int i = 0; i < graphs.Count; i++)
			{
				array[i] = graphs[i].AsDataExport();
			}
			return JsonUtility.ToJson(new DataExport
			{
				data = array
			});
		}

		public override Rect GetDraggableRect()
		{
			RefreshRect();
			return base.GetDraggableRect();
		}

		private void AddGraph(object key, GraphContainer graph)
		{
			graph.OnLabelSizeChange = (Action)Delegate.Combine(graph.OnLabelSizeChange, new Action(RefreshRect));
			graphDictionary.Add(key, graph);
			graphs.Add(graph);
			if (!graphGroups.ContainsKey(graph.group))
			{
				graphGroups.Add(graph.group, new List<GraphContainer>());
			}
			graphGroups[graph.group].Add(graph);
			RecalculateGraphLabelWidth();
		}

		private void PollGraphAttributes()
		{
			foreach (MonoBehaviour attributeContainer in attributeContainers)
			{
				if (!(attributeContainer != null) || !attributeKeys.ContainsKey(attributeContainer))
				{
					continue;
				}
				foreach (GraphAttributeKey item in attributeKeys[attributeContainer])
				{
					if (item.memberInfo is FieldInfo fieldInfo)
					{
						float? num = fieldInfo.GetValue(attributeContainer) as float?;
						if (num.HasValue)
						{
							graphDictionary[item].Push(num.Value);
						}
					}
					else if (item.memberInfo is PropertyInfo propertyInfo)
					{
						float? num2 = propertyInfo.GetValue(attributeContainer, null) as float?;
						if (num2.HasValue)
						{
							graphDictionary[item].Push(num2.Value);
						}
					}
				}
			}
		}

		private void DrawGraphGroup(List<GraphContainer> group, int groupNum)
		{
			Vector2 point = Input.mousePosition;
			point.y = (float)Screen.height - point.y;
			point -= base.rect.position;
			Vector2 vector = new Vector2(DebugGUI.Settings.graphWidth + 3, DebugGUI.Settings.graphHeight + 3);
			Vector2 vector2 = new Vector2(0f, vector.y * (float)groupNum);
			Rect rect = new Rect(vector2.x + graphLabelBoxWidth + 3f, vector2.y, DebugGUI.Settings.graphWidth, DebugGUI.Settings.graphHeight);
			DrawRect(new Rect(vector2.x, vector2.y, graphLabelBoxWidth, DebugGUI.Settings.graphHeight), DebugGUI.Settings.backgroundColor);
			DrawRect(new Rect(vector2.x + 3f + graphLabelBoxWidth, vector2.y, vector.x, DebugGUI.Settings.graphHeight), DebugGUI.Settings.backgroundColor);
			Vector2 vector3 = vector2 + new Vector2(0f, 14f);
			Vector2 vector4 = vector2 + new Vector2(graphLabelBoxWidth - 10f, 0f);
			foreach (GraphContainer item in group)
			{
				Vector2 multilineStringSize = GetMultilineStringSize(graphLabelStyle, in item.name);
				vector3.y += multilineStringSize.y;
				float num = Mathf.Max(GetMultilineStringSize(graphLabelStyle, in item.minString).x, GetMultilineStringSize(graphLabelStyle, in item.maxString).x);
				vector4 += Vector2.left * (num + 5f);
				Rect rect2 = new Rect(vector3 - multilineStringSize + new Vector2(graphLabelBoxWidth - 10f, 5f), multilineStringSize);
				bool flag = rect2.Contains(point);
				bool flag2 = flag && Input.GetMouseButton(0);
				if (lastPressedGraphLabel == item && !flag2 && flag)
				{
					item.visible = !item.visible;
				}
				if (flag2)
				{
					lastPressedGraphLabel = item;
				}
				else if (lastPressedGraphLabel == item)
				{
					lastPressedGraphLabel = null;
				}
				Color modifiedColor = item.GetModifiedColor(flag);
				DrawLabelDeferred(rect2.position, item.name, modifiedColor);
				DrawLabelDeferred(vector4, item.maxString, modifiedColor);
				DrawLabelDeferred(vector4 + new Vector2(0f, DebugGUI.Settings.graphHeight - 20), item.minString, modifiedColor);
				if (item.visible)
				{
					item.Draw(new Rect(rect.position + base.rect.position, rect.size));
				}
			}
			if (!rect.Contains(point))
			{
				return;
			}
			if (Input.GetMouseButton(0))
			{
				freezeGraphs = true;
			}
			Vector2 vector5 = new Vector2(point.x, vector2.y);
			if (point.x > rect.max.x - 55f)
			{
				vector5.x -= 55f;
			}
			Rect rect3 = new Rect(vector5.x, vector5.y, 55f, DebugGUI.Settings.graphHeight);
			DrawRect(rect3, DebugGUI.Settings.backgroundColor);
			DrawLine(new Vector2(point.x, vector2.y), new Vector2(point.x, vector2.y + (float)DebugGUI.Settings.graphHeight), DebugGUI.Settings.scrubberColor);
			Vector2 pos = vector5 + new Vector2(5f, 15f);
			float num2 = point.x - vector2.x;
			int index = (int)(rect.width - num2 + graphLabelBoxWidth + 3f);
			foreach (GraphContainer item2 in group)
			{
				string label = item2.GetValue(index).ToString("F3");
				DrawLabelDeferred(pos, label, item2.color);
				pos.y += GetMultilineStringSize(graphLabelStyle, in string.Empty).y;
			}
		}

		private Rect GetGraphWindowRect()
		{
			return new Rect(new Vector2(0f - graphLabelBoxWidth, 0f) + rect.position, new Vector2((float)DebugGUI.Settings.graphWidth + graphLabelBoxWidth + 3f, (DebugGUI.Settings.graphHeight + 3) * graphGroups.Count));
		}

		private void RegisterAttributes()
		{
			MonoBehaviour[] array = UnityEngine.Object.FindObjectsOfType<MonoBehaviour>();
			foreach (MonoBehaviour monoBehaviour in array)
			{
				Type type = monoBehaviour.GetType();
				HashSet<MonoBehaviour> hashSet = new HashSet<MonoBehaviour>();
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				for (int j = 0; j < fields.Length; j++)
				{
					if (!(Attribute.GetCustomAttribute(fields[j], typeof(DebugGUIGraphAttribute)) is DebugGUIGraphAttribute debugGUIGraphAttribute))
					{
						continue;
					}
					if (!(fields[j].GetValue(monoBehaviour) as float?).HasValue)
					{
						Debug.LogError("Cannot cast " + type.Name + "." + fields[j].Name + " to float. This member will be ignored.");
						continue;
					}
					hashSet.Add(monoBehaviour);
					if (!debugGUIGraphFields.ContainsKey(type))
					{
						debugGUIGraphFields.Add(type, new HashSet<FieldInfo>());
					}
					if (!debugGUIGraphProperties.ContainsKey(type))
					{
						debugGUIGraphProperties.Add(type, new HashSet<PropertyInfo>());
					}
					debugGUIGraphFields[type].Add(fields[j]);
					GraphContainer graphContainer = new GraphContainer(DebugGUI.Settings.graphWidth, debugGUIGraphAttribute.group)
					{
						name = fields[j].Name,
						max = debugGUIGraphAttribute.max,
						min = debugGUIGraphAttribute.min,
						autoScale = debugGUIGraphAttribute.autoScale
					};
					graphContainer.OnLabelSizeChange = (Action)Delegate.Combine(graphContainer.OnLabelSizeChange, new Action(RefreshRect));
					if (!debugGUIGraphAttribute.color.Equals(default(Color)))
					{
						graphContainer.color = debugGUIGraphAttribute.color;
					}
					GraphAttributeKey graphAttributeKey = new GraphAttributeKey(fields[j]);
					if (!attributeKeys.ContainsKey(monoBehaviour))
					{
						attributeKeys.Add(monoBehaviour, new List<GraphAttributeKey>());
					}
					attributeKeys[monoBehaviour].Add(graphAttributeKey);
					AddGraph(graphAttributeKey, graphContainer);
				}
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				for (int k = 0; k < properties.Length; k++)
				{
					if (!(Attribute.GetCustomAttribute(properties[k], typeof(DebugGUIGraphAttribute)) is DebugGUIGraphAttribute debugGUIGraphAttribute2))
					{
						continue;
					}
					if (!(properties[k].GetValue(monoBehaviour, null) as float?).HasValue)
					{
						Debug.LogError("Cannot cast " + type.Name + "." + properties[k].Name + " to float. This member will be ignored.");
						continue;
					}
					hashSet.Add(monoBehaviour);
					if (!debugGUIGraphFields.ContainsKey(type))
					{
						debugGUIGraphFields.Add(type, new HashSet<FieldInfo>());
					}
					if (!debugGUIGraphProperties.ContainsKey(type))
					{
						debugGUIGraphProperties.Add(type, new HashSet<PropertyInfo>());
					}
					debugGUIGraphProperties[type].Add(properties[k]);
					GraphContainer graphContainer2 = new GraphContainer(DebugGUI.Settings.graphWidth, debugGUIGraphAttribute2.group)
					{
						name = properties[k].Name,
						max = debugGUIGraphAttribute2.max,
						min = debugGUIGraphAttribute2.min,
						autoScale = debugGUIGraphAttribute2.autoScale
					};
					graphContainer2.OnLabelSizeChange = (Action)Delegate.Combine(graphContainer2.OnLabelSizeChange, new Action(RefreshRect));
					if (!debugGUIGraphAttribute2.color.Equals(default(Color)))
					{
						graphContainer2.color = debugGUIGraphAttribute2.color;
					}
					GraphAttributeKey graphAttributeKey2 = new GraphAttributeKey(properties[k]);
					if (!attributeKeys.ContainsKey(monoBehaviour))
					{
						attributeKeys.Add(monoBehaviour, new List<GraphAttributeKey>());
					}
					attributeKeys[monoBehaviour].Add(graphAttributeKey2);
					AddGraph(graphAttributeKey2, graphContainer2);
				}
				foreach (MonoBehaviour item in hashSet)
				{
					attributeContainers.Add(item);
					Type type2 = item.GetType();
					if (!typeInstanceCounts.ContainsKey(type2))
					{
						typeInstanceCounts.Add(type2, 0);
					}
					typeInstanceCounts[type2]++;
				}
			}
		}

		private void CleanUpDeletedAttributes()
		{
			foreach (MonoBehaviour attributeContainer in attributeContainers)
			{
				if (!(attributeContainer == null))
				{
					continue;
				}
				foreach (GraphAttributeKey item in attributeKeys[attributeContainer])
				{
					RemoveGraph(item);
				}
				attributeKeys.Remove(attributeContainer);
				Type type = attributeContainer.GetType();
				typeInstanceCounts[type]--;
				if (typeInstanceCounts[type] == 0)
				{
					if (debugGUIGraphFields.ContainsKey(type))
					{
						debugGUIGraphFields.Remove(type);
					}
					if (debugGUIGraphProperties.ContainsKey(type))
					{
						debugGUIGraphProperties.Remove(type);
					}
				}
			}
			attributeContainers.RemoveWhere((MonoBehaviour node) => node == null);
		}

		private void RefreshRect()
		{
			float width = rect.width;
			RecalculateGraphLabelWidth();
			rect.size = new Vector2((float)DebugGUI.Settings.graphWidth + graphLabelBoxWidth + 3f, (DebugGUI.Settings.graphHeight + 3) * graphGroups.Count);
			rect.position += new Vector2(width - rect.width, 0f);
		}

		private void RecalculateGraphLabelWidth()
		{
			float num = 0f;
			foreach (List<GraphContainer> value in graphGroups.Values)
			{
				float num2 = 5f;
				foreach (GraphContainer item in value)
				{
					num = Mathf.Max(GetMultilineStringSize(graphLabelStyle, in item.name).x, num);
					float num3 = Mathf.Max(GetMultilineStringSize(graphLabelStyle, in item.minString).x, GetMultilineStringSize(graphLabelStyle, in item.maxString).x);
					num2 += num3 + 5f;
				}
				num = Mathf.Max(num2, num);
			}
			graphLabelBoxWidth = num + 10f;
		}

		private void DrawLabelDeferred(Vector2 pos, string label, Color color)
		{
			deferredLabels.Add(new DeferredLabel
			{
				position = pos,
				label = label,
				color = color
			});
		}
	}
}
