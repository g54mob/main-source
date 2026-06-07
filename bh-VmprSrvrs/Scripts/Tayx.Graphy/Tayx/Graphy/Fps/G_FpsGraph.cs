using Tayx.Graphy.Graph;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Fps
{
	public class G_FpsGraph : G_Graph
	{
		[SerializeField]
		private Image m_imageGraph;

		[SerializeField]
		private Shader ShaderFull;

		[SerializeField]
		private Shader ShaderLight;

		[SerializeField]
		private bool m_isInitialized;

		private GraphyManager m_graphyManager;

		private G_FpsMonitor m_fpsMonitor;

		private int m_resolution;

		private G_GraphShader m_shaderGraph;

		private int[] m_fpsArray;

		private int m_highestFps;

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
