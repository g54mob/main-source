using System;
using System.Text;
using UnityEngine;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Pathfinding Debugger")]
	[ExecuteInEditMode]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_astar_debugger.php")]
	public class AstarDebugger : VersionedMonoBehaviour
	{
		private struct GraphPoint
		{
			public float fps;

			public float memory;

			public bool collectEvent;
		}

		private struct PathTypeDebug
		{
			private string name;

			private Func<int> getSize;

			private Func<int> getTotalCreated;

			public PathTypeDebug(string name, Func<int> getSize, Func<int> getTotalCreated)
			{
				this.name = null;
				this.getSize = null;
				this.getTotalCreated = null;
			}

			public void Print(StringBuilder text)
			{
			}
		}

		public int yOffset;

		public bool show;

		public bool showInEditor;

		public bool showFPS;

		public bool showPathProfile;

		public bool showMemProfile;

		public bool showGraph;

		public int graphBufferSize;

		public Font font;

		public int fontSize;

		private StringBuilder text;

		private string cachedText;

		private float lastUpdate;

		private GraphPoint[] graph;

		private float delayedDeltaTime;

		private float lastCollect;

		private float lastCollectNum;

		private float delta;

		private float lastDeltaTime;

		private int allocRate;

		private int lastAllocMemory;

		private float lastAllocSet;

		private int allocMem;

		private int collectAlloc;

		private int peakAlloc;

		private int fpsDropCounterSize;

		private float[] fpsDrops;

		private Rect boxRect;

		private GUIStyle style;

		private Camera cam;

		private float graphWidth;

		private float graphHeight;

		private float graphOffset;

		private int maxVecPool;

		private int maxNodePool;

		private PathTypeDebug[] debugTypes;

		public void Start()
		{
		}

		public void LateUpdate()
		{
		}

		private void DrawGraphLine(int index, Matrix4x4 m, float x1, float x2, float y1, float y2, Color color)
		{
		}

		public void OnGUI()
		{
		}
	}
}
