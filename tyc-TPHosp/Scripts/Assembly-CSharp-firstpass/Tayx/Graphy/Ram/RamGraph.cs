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

		private int m_resolution = 150;

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
			Init();
		}

		private void Update()
		{
			UpdateGraph();
		}

		public void UpdateParameters()
		{
			switch (m_graphyManager.GraphyMode)
			{
			case GraphyManager.Mode.FULL:
				m_shaderGraphAllocated.ArrayMaxSize = 512;
				m_shaderGraphReserved.ArrayMaxSize = 512;
				m_shaderGraphMono.ArrayMaxSize = 512;
				m_shaderGraphAllocated.Image.material = new Material(ShaderFull);
				m_shaderGraphReserved.Image.material = new Material(ShaderFull);
				m_shaderGraphMono.Image.material = new Material(ShaderFull);
				break;
			case GraphyManager.Mode.LIGHT:
				m_shaderGraphAllocated.ArrayMaxSize = 128;
				m_shaderGraphReserved.ArrayMaxSize = 128;
				m_shaderGraphMono.ArrayMaxSize = 128;
				m_shaderGraphAllocated.Image.material = new Material(ShaderLight);
				m_shaderGraphReserved.Image.material = new Material(ShaderLight);
				m_shaderGraphMono.Image.material = new Material(ShaderLight);
				break;
			}
			m_shaderGraphAllocated.InitializeShader();
			m_shaderGraphReserved.InitializeShader();
			m_shaderGraphMono.InitializeShader();
			m_resolution = m_graphyManager.RamGraphResolution;
			CreatePoints();
		}

		protected override void UpdateGraph()
		{
			float allocatedRam = m_ramMonitor.AllocatedRam;
			float reservedRam = m_ramMonitor.ReservedRam;
			float monoRam = m_ramMonitor.MonoRam;
			m_highestMemory = 0f;
			for (int i = 0; i <= m_resolution - 1; i++)
			{
				if (i >= m_resolution - 1)
				{
					m_allocatedArray[i] = allocatedRam;
					m_reservedArray[i] = reservedRam;
					m_monoArray[i] = monoRam;
				}
				else
				{
					m_allocatedArray[i] = m_allocatedArray[i + 1];
					m_reservedArray[i] = m_reservedArray[i + 1];
					m_monoArray[i] = m_monoArray[i + 1];
				}
				if (m_highestMemory < m_reservedArray[i])
				{
					m_highestMemory = m_reservedArray[i];
				}
			}
			for (int j = 0; j <= m_resolution - 1; j++)
			{
				m_shaderGraphAllocated.Array[j] = m_allocatedArray[j] / m_highestMemory;
				m_shaderGraphReserved.Array[j] = m_reservedArray[j] / m_highestMemory;
				m_shaderGraphMono.Array[j] = m_monoArray[j] / m_highestMemory;
			}
			m_shaderGraphAllocated.UpdatePoints();
			m_shaderGraphReserved.UpdatePoints();
			m_shaderGraphMono.UpdatePoints();
		}

		protected override void CreatePoints()
		{
			m_shaderGraphAllocated.Array = new float[m_resolution];
			m_shaderGraphReserved.Array = new float[m_resolution];
			m_shaderGraphMono.Array = new float[m_resolution];
			m_allocatedArray = new float[m_resolution];
			m_reservedArray = new float[m_resolution];
			m_monoArray = new float[m_resolution];
			for (int i = 0; i < m_resolution; i++)
			{
				m_shaderGraphAllocated.Array[i] = 0f;
				m_shaderGraphReserved.Array[i] = 0f;
				m_shaderGraphMono.Array[i] = 0f;
			}
			m_shaderGraphAllocated.GoodColor = m_graphyManager.AllocatedRamColor;
			m_shaderGraphAllocated.CautionColor = m_graphyManager.AllocatedRamColor;
			m_shaderGraphAllocated.CriticalColor = m_graphyManager.AllocatedRamColor;
			m_shaderGraphAllocated.UpdateColors();
			m_shaderGraphReserved.GoodColor = m_graphyManager.ReservedRamColor;
			m_shaderGraphReserved.CautionColor = m_graphyManager.ReservedRamColor;
			m_shaderGraphReserved.CriticalColor = m_graphyManager.ReservedRamColor;
			m_shaderGraphReserved.UpdateColors();
			m_shaderGraphMono.GoodColor = m_graphyManager.MonoRamColor;
			m_shaderGraphMono.CautionColor = m_graphyManager.MonoRamColor;
			m_shaderGraphMono.CriticalColor = m_graphyManager.MonoRamColor;
			m_shaderGraphMono.UpdateColors();
			m_shaderGraphAllocated.GoodThreshold = 0f;
			m_shaderGraphAllocated.CautionThreshold = 0f;
			m_shaderGraphAllocated.UpdateThresholds();
			m_shaderGraphReserved.GoodThreshold = 0f;
			m_shaderGraphReserved.CautionThreshold = 0f;
			m_shaderGraphReserved.UpdateThresholds();
			m_shaderGraphMono.GoodThreshold = 0f;
			m_shaderGraphMono.CautionThreshold = 0f;
			m_shaderGraphMono.UpdateThresholds();
			m_shaderGraphAllocated.UpdateArray();
			m_shaderGraphReserved.UpdateArray();
			m_shaderGraphMono.UpdateArray();
			m_shaderGraphAllocated.Average = 0f;
			m_shaderGraphReserved.Average = 0f;
			m_shaderGraphMono.Average = 0f;
			m_shaderGraphAllocated.UpdateAverage();
			m_shaderGraphReserved.UpdateAverage();
			m_shaderGraphMono.UpdateAverage();
		}

		private void Init()
		{
			m_graphyManager = base.transform.root.GetComponentInChildren<GraphyManager>();
			m_ramMonitor = GetComponent<RamMonitor>();
			m_shaderGraphAllocated = new ShaderGraph();
			m_shaderGraphReserved = new ShaderGraph();
			m_shaderGraphMono = new ShaderGraph();
			m_shaderGraphAllocated.Image = m_imageAllocated;
			m_shaderGraphReserved.Image = m_imageReserved;
			m_shaderGraphMono.Image = m_imageMono;
			UpdateParameters();
		}
	}
}
