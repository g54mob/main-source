using Tayx.Graphy.Utils;
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

		private int m_updateRate = 4;

		private int m_frameCount;

		private float m_deltaTime;

		private float m_fps;

		private const string m_msStringFormat = "0.0";

		private void Awake()
		{
			Init();
		}

		private void Update()
		{
			m_deltaTime += Time.unscaledDeltaTime;
			m_frameCount++;
			if ((double)m_deltaTime > 1.0 / (double)m_updateRate)
			{
				m_fps = (float)m_frameCount / m_deltaTime;
				m_fpsText.text = m_fps.ToInt().ToStringNonAlloc();
				m_msText.text = (m_deltaTime / (float)m_frameCount * 1000f).ToStringNonAlloc("0.0");
				m_minFpsText.text = m_fpsMonitor.MinFPS.ToInt().ToStringNonAlloc();
				SetFpsRelatedTextColor(m_minFpsText, m_fpsMonitor.MinFPS);
				m_maxFpsText.text = m_fpsMonitor.MaxFPS.ToInt().ToStringNonAlloc();
				SetFpsRelatedTextColor(m_maxFpsText, m_fpsMonitor.MaxFPS);
				m_avgFpsText.text = m_fpsMonitor.AverageFPS.ToInt().ToStringNonAlloc();
				SetFpsRelatedTextColor(m_avgFpsText, m_fpsMonitor.AverageFPS);
				m_deltaTime = 0f;
				m_frameCount = 0;
			}
		}

		public void UpdateParameters()
		{
			m_updateRate = m_graphyManager.FpsTextUpdateRate;
		}

		private void SetFpsRelatedTextColor(Text text, float fps)
		{
			if (fps > (float)m_graphyManager.GoodFPSThreshold)
			{
				text.color = m_graphyManager.GoodFPSColor;
			}
			else if (fps > (float)m_graphyManager.CautionFPSThreshold)
			{
				text.color = m_graphyManager.CautionFPSColor;
			}
			else
			{
				text.color = m_graphyManager.CriticalFPSColor;
			}
		}

		private void Init()
		{
			if (!FloatString.Inited || FloatString.minValue > -1000f || FloatString.maxValue < 16384f)
			{
				FloatString.Init(-1001f, 16386f);
			}
			m_graphyManager = base.transform.root.GetComponentInChildren<GraphyManager>();
			m_fpsMonitor = GetComponent<FpsMonitor>();
			UpdateParameters();
		}
	}
}
