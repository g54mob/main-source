using Tayx.Graphy.Graph;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Audio
{
	public class AudioGraph : Tayx.Graphy.Graph.Graph
	{
		private GraphyManager m_graphyManager;

		private AudioMonitor m_audioMonitor;

		[SerializeField]
		private Image m_imageGraph;

		[SerializeField]
		private Image m_imageGraphHighestValues;

		private int m_resolution;

		private ShaderGraph m_shaderGraph;

		private ShaderGraph m_shaderGraphHighestValues;

		public Shader ShaderFull;

		public Shader ShaderLight;

		private float[] m_graphArray;

		private float[] m_graphArrayHighestValue;

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
