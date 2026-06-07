using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Fps
{
	public class FpsText : MonoBehaviour
	{
		private GraphyManager m_graphyManager;

		private FpsMonitor m_fpsMonitor;

		[SerializeField]
		private Text m_fpsText;

		[SerializeField]
		private Text m_msText;

		[SerializeField]
		private Text m_avgFpsText;

		[SerializeField]
		private Text m_minFpsText;

		[SerializeField]
		private Text m_maxFpsText;

		private int m_updateRate;

		private int m_frameCount;

		private float m_deltaTime;

		private float m_fps;

		private const string m_msStringFormat = "0.0";

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void UpdateParameters()
		{
		}

		private void SetFpsRelatedTextColor(Text text, float fps)
		{
		}

		private void Init()
		{
		}
	}
}
