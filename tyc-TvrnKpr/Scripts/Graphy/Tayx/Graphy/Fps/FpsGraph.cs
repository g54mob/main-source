using Tayx.Graphy.Graph;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Fps
{
	public class FpsGraph : Tayx.Graphy.Graph.Graph
	{
		private GraphyManager m_graphyManager;

		private FpsMonitor m_fpsMonitor;

		[SerializeField]
		private Image m_imageGraph;

		private int m_resolution;

		private ShaderGraph m_shaderGraph;

		public Shader ShaderFull;

		public Shader ShaderLight;

		private int[] m_fpsArray;

		private int m_highestFps;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void UpdateParameters()
		{
		}

		protected override void UpdateGraph()
		{
		}

		protected override void CreatePoints()
		{
		}

		private void Init()
		{
		}
	}
}
