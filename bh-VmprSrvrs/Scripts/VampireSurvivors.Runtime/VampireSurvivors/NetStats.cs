using Coherence.Connection;
using Coherence.Toolkit;
using UnityEngine;

namespace VampireSurvivors
{
	public class NetStats : MonoBehaviour
	{
		public KeyCode toggleKey;

		private static NetStats _instance;

		private bool display;

		private bool registeredOnDisconnected;

		private const int PacketsGraph = 1;

		private const int BandwidthGraph = 2;

		private const int UpdatesGraph = 3;

		private const int EnemyCountGraph = 4;

		private const int PingGraph = 5;

		public static NetStats Instance => null;

		public void Toggle()
		{
		}

		private void Start()
		{
		}

		private void OnDisconnected(CoherenceBridge _, ConnectionCloseReason __)
		{
		}

		private void RegisterOnDisconnectedEvent()
		{
		}

		private void CheckDisplayToggle()
		{
		}

		private void DrawGraphs()
		{
		}

		private static void RemoveGraphs()
		{
		}

		private static void Graph(string key, string label, float min, float max, int graph, Color color, float value)
		{
		}
	}
}
