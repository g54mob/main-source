using System.Collections.Generic;
using System.Linq;
using LocoSim.Attributes;
using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations.Test
{
	public abstract class SimDataDisplayBase : MonoBehaviour
	{
		private class PortSimData
		{
			private const int UPDATE_VALUE_SCALER_PERIOD = 30;

			private const float GRAPH_DESIRED_SIZE_PERCENTAGE = 0.7f;

			private const float GRAPH_DESIRED_PERCENTAGE_OFFSET_FOR_MIN_MAX_VALUE = 0.15f;

			public List<float> data;

			public readonly string portId;

			public float valueScaler = 1f;

			public float zeroValueOffset;

			public float maxValue;

			public float minValue;

			private int updateValueScaleCounter;

			private int queueSize;

			public PortSimData(string portId, int queueSize)
			{
				this.queueSize = queueSize;
				data = new List<float>();
				this.portId = portId;
			}

			public void FeedData(float value)
			{
				int count = data.Count;
				if (count == queueSize)
				{
					for (int i = 0; i < count - 1; i++)
					{
						data[i] = data[i + 1];
					}
					data[count - 1] = value;
				}
				else
				{
					data.Add(value);
				}
				updateValueScaleCounter++;
				if (updateValueScaleCounter != 30)
				{
					return;
				}
				float num = float.PositiveInfinity;
				float num2 = float.NegativeInfinity;
				for (int j = 0; j < count; j++)
				{
					if (data[j] < num)
					{
						num = data[j];
					}
					if (data[j] > num2)
					{
						num2 = data[j];
					}
				}
				minValue = num;
				maxValue = num2;
				valueScaler = 1f;
				float num3 = 0f;
				bool flag = num < 0f;
				bool flag2 = num2 < 0f;
				if (flag && !flag2 && num != num2)
				{
					num3 = num2 - num;
				}
				else if (flag && flag2)
				{
					num3 = Mathf.Abs(num);
				}
				else if (num2 != 0f)
				{
					num3 = Mathf.Abs(num2);
				}
				if (num3 != 0f)
				{
					valueScaler = 105f / num3;
				}
				zeroValueOffset = 22.5f / valueScaler;
				if (num < 0f)
				{
					zeroValueOffset += Mathf.Abs(num);
				}
				updateValueScaleCounter = 0;
			}
		}

		private const string VALUE_FORMAT = "F3";

		private const int windowID = 99;

		private const float TOTAL_WINDOW_HEIGHT = 700f;

		private const float TOTAL_WINDOW_WIDTH = 1020f;

		private const float X_WINDOW_MARGIN = 10f;

		private const float Y_WINDOW_MARGIN = 40f;

		private const float RECORD_DATA_CHECKBOX_WIDTH = 100f;

		private const float RECORD_DATA_CHECKBOX_HEIGHT = 30f;

		private const float RECORD_DATA_CHECKBOX_X_OFFSET = 10f;

		private const float RECORD_DATA_CHECKBOX_Y_OFFSET = 0f;

		private const float CLOSE_GRAPH_BUTTON_SIZE = 17.5f;

		private const float CLOSE_GRAPH_BUTTON_X_OFFSET = 1001.25f;

		private const float CLOSE_GRAPH_BUTTON_Y_OFFSET = 0f;

		private const float SCROLL_VIEW_HEIGHT = 620f;

		private const float SCROLL_VIEW_WIDTH = 1000f;

		private const float SCROLL_X_WINDOW_MARGIN = 100f;

		private const float SCROLL_Y_WINDOW_MARGIN = 10f;

		private const float SCROLL_Y_WINDOW_OFFSET = 40f;

		private const int NUMBER_OF_DISPLAYED_GRAPHS = 4;

		private const float GRAPH_COMPONENT_WIDTH = 800f;

		private const float GRAPH_COMPONENT_HEIGHT = 150f;

		private const float GRAPH_X_OFFSET = 100f;

		private const float GRAPH_Y_OFFSET = 40f;

		private const float TEXT_WIDTH = 800f;

		private const float TEXT_HEIGHT = 20f;

		private const float TITLE_AND_VALUE_TEXT_OFFSET = 10f;

		private const float GRAPH_VALUE_MARKER_TEXT_WIDTH = 80f;

		private const float CENTERED_TEXT_OFFSET = 10f;

		private const int FONT_SIZE = 16;

		private const int GRAPH_VALUES_FONT_SIZE = 12;

		public int dataQueueSize = 4000;

		public int sampleTickRate = 5;

		public bool recordData = true;

		public bool displayGraph = true;

		[PortId(null, null, false)]
		public List<string> portIdsToPlot;

		protected SimulationFlow simFlow;

		private List<PortSimData> portData;

		private List<Port> trackedPorts;

		private int tickCounter;

		private Rect windowRect = new Rect(10f, 0f, 1020f, 700f);

		private Vector2 scrollPos;

		private float xStepSize = 200f;

		private GUIStyle valueMarkerLabelStyle;

		public abstract SimConnectionDefinition SimDef { get; }

		protected abstract void InitializeSimulation();

		private void Start()
		{
			InitializeSimulation();
			simFlow.TickEvent += OnTick;
			InitTrackedPorts();
			xStepSize = 800f / (float)dataQueueSize;
		}

		public void InitTrackedPorts()
		{
			Dictionary<string, Port> dictionary = new Dictionary<string, Port>();
			for (int i = 0; i < simFlow.OrderedSimComps.Count; i++)
			{
				SimComponent simComponent = simFlow.OrderedSimComps[i];
				foreach (Port allPort in simComponent.GetAllPorts())
				{
					dictionary[allPort.id] = allPort;
				}
				foreach (PortReference allPortReference in simComponent.GetAllPortReferences())
				{
					Port port = allPortReference.port;
					dictionary[allPortReference.id] = port;
				}
			}
			portData = new List<PortSimData>();
			if (portIdsToPlot != null && portIdsToPlot.Count != 0)
			{
				trackedPorts = new List<Port>();
				{
					foreach (string item in portIdsToPlot)
					{
						if (dictionary.TryGetValue(item, out var value))
						{
							trackedPorts.Add(value);
							portData.Add(new PortSimData(value.id, dataQueueSize));
						}
						else
						{
							Debug.LogError("Couldn't find port: " + item + ". Skipping");
						}
					}
					return;
				}
			}
			trackedPorts = dictionary.Values.OrderBy((Port p) => p.id).ToList();
			foreach (Port trackedPort in trackedPorts)
			{
				portData.Add(new PortSimData(trackedPort.id, dataQueueSize));
			}
		}

		private void OnTick()
		{
			if (!recordData)
			{
				return;
			}
			tickCounter++;
			if (tickCounter % sampleTickRate == 0)
			{
				int count = trackedPorts.Count;
				for (int i = 0; i < count; i++)
				{
					portData[i].FeedData(trackedPorts[i].Value);
				}
			}
		}

		private void OnGUI()
		{
			if (!displayGraph)
			{
				GUILayout.BeginVertical();
				if (GUILayout.Button("Graph"))
				{
					displayGraph = !displayGraph;
				}
				GUILayout.EndVertical();
			}
			else
			{
				windowRect = GUILayout.Window(99, windowRect, Window, "Loco simulation graph");
			}
		}

		private void Window(int id)
		{
			if (valueMarkerLabelStyle == null)
			{
				valueMarkerLabelStyle = new GUIStyle(GUI.skin.label)
				{
					fontSize = 12,
					alignment = TextAnchor.MiddleRight
				};
			}
			Rect position = new Rect(10f, 0f, 100f, 30f);
			recordData = GUI.Toggle(position, recordData, "Record data");
			if (GUI.Button(new Rect(1001.25f, 0f, 17.5f, 17.5f), "x"))
			{
				displayGraph = !displayGraph;
			}
			GUI.skin.label.fontSize = 16;
			Rect position2 = new Rect(0f, 40f, 1000f, 620f);
			scrollPos = GUI.BeginScrollView(position2, scrollPos, new Rect(0f, 40f, 800f, (float)portData.Count * 150f), alwaysShowHorizontal: false, alwaysShowVertical: true);
			GUILayout.BeginVertical();
			int count = portData.Count;
			for (int i = 0; i < count && !((float)(i + 1) * 150f > 620f + scrollPos.y); i++)
			{
				if (!((float)(i + 1) * 150f < scrollPos.y))
				{
					int count2 = portData[i].data.Count;
					if (count2 != 0)
					{
						float zeroValueOffset = portData[i].zeroValueOffset;
						float valueScaler = portData[i].valueScaler;
						float maxValue = portData[i].maxValue;
						float minValue = portData[i].minValue;
						float num = 40f + (float)i * 150f;
						float num2 = num - 10f;
						float num3 = 150f - zeroValueOffset * valueScaler;
						GUI.Label(new Rect(0f, num2 + num3, 80f, 20f), "0", valueMarkerLabelStyle);
						float num4 = 150f - (zeroValueOffset + maxValue) * valueScaler;
						GUI.Label(new Rect(0f, num2 + num4, 80f, 20f), maxValue.ToString("F3"), valueMarkerLabelStyle);
						float num5 = 150f - (zeroValueOffset + minValue) * valueScaler;
						GUI.Label(new Rect(0f, num2 + num5, 80f, 20f), minValue.ToString("F3"), valueMarkerLabelStyle);
						Rect position3 = new Rect(100f, num, 800f, 150f);
						GUI.Box(position3, GUIContent.none);
						GUI.BeginClip(position3);
						GUI.Label(new Rect(10f, 0f, 800f, 20f), portData[i].portId + ": " + portData[i].data[count2 - 1].ToString("F3"));
						GUI.EndClip();
					}
				}
			}
			GUILayout.EndVertical();
			GUI.EndScrollView();
		}
	}
}
