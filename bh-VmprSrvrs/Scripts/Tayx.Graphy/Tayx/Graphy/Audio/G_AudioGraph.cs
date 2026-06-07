using Tayx.Graphy.Graph;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Audio
{
	public class G_AudioGraph : G_Graph
	{
		[SerializeField]
		private Image m_imageGraph;

		[SerializeField]
		private Image m_imageGraphHighestValues;

		[SerializeField]
		private Shader ShaderFull;

		[SerializeField]
		private Shader ShaderLight;

		[SerializeField]
		private bool m_isInitialized;

		private GraphyManager m_graphyManager;

		private G_AudioMonitor m_audioMonitor;

		private int m_resolution;

		private G_GraphShader m_shaderGraph;

		private G_GraphShader m_shaderGraphHighestValues;

		private float[] m_graphArray;

		private float[] m_graphArrayHighestValue;

		private void OnEnable()
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
