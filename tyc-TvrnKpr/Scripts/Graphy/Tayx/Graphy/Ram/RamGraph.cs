using Tayx.Graphy.Graph;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Ram
{
	public class RamGraph : Tayx.Graphy.Graph.Graph
	{
		private GraphyManager m_graphyManager;

		private RamMonitor m_ramMonitor;

		[SerializeField]
		private Image m_imageAllocated;

		[SerializeField]
		private Image m_imageReserved;

		[SerializeField]
		private Image m_imageMono;

		private int m_resolution;

		private ShaderGraph m_shaderGraphAllocated;

		private ShaderGraph m_shaderGraphReserved;

		private ShaderGraph m_shaderGraphMono;

		public Shader ShaderFull;

		public Shader ShaderLight;

		private float[] m_allocatedArray;

		private float[] m_reservedArray;

		private float[] m_monoArray;

		private float m_highestMemory;

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
