using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Fps
{
	public class G_FpsText : MonoBehaviour
	{
		[SerializeField]
		private Text m_fpsText;

		[SerializeField]
		private Text m_msText;

		[SerializeField]
		private Text m_avgFpsText;

		[SerializeField]
		private Text m_onePercentFpsText;

		[SerializeField]
		private Text m_zero1PercentFpsText;

		private GraphyManager m_graphyManager;

		private G_FpsMonitor m_fpsMonitor;

		private int m_updateRate;

		private int m_frameCount;

		private float m_deltaTime;

		private float m_fps;

		private float m_ms;

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
