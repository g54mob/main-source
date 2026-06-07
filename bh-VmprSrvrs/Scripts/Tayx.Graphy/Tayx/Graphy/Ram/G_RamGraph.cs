using Tayx.Graphy.Graph;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Ram
{
	public class G_RamGraph : G_Graph
	{
		[SerializeField]
		private Image m_imageAllocated;

		[SerializeField]
		private Image m_imageReserved;

		[SerializeField]
		private Image m_imageMono;

		[SerializeField]
		private Shader ShaderFull;

		[SerializeField]
		private Shader ShaderLight;

		[SerializeField]
		private bool m_isInitialized;

		private GraphyManager m_graphyManager;

		private G_RamMonitor m_ramMonitor;

		private int m_resolution;

		private G_GraphShader m_shaderGraphAllocated;

		private G_GraphShader m_shaderGraphReserved;

		private G_GraphShader m_shaderGraphMono;

		private float[] m_allocatedArray;

		private float[] m_reservedArray;

		private float[] m_monoArray;

		private float m_highestMemory;

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
