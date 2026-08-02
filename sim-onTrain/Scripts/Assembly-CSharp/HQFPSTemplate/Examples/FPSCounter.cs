using UnityEngine;
using UnityEngine.UI;

namespace HQFPSTemplate.Examples
{
	[RequireComponent(typeof(Text))]
	public class FPSCounter : MonoBehaviour
	{
		[SerializeField]
		[Range(30f, 1000f)]
		private float m_RequiredFPS;

		[SerializeField]
		private Gradient m_ColorGradient;

		private const float fpsMeasurePeriod = 0.5f;

		private int m_FpsAccumulator;

		private float m_FpsNextPeriod;

		private int m_CurrentFps;

		private const string display = "{0} Avg FPS";

		private Text m_Text;

		private void Start()
		{
			m_FpsNextPeriod = Time.realtimeSinceStartup + 0.5f;
			m_Text = GetComponent<Text>();
		}

		private void Update()
		{
			m_FpsAccumulator++;
			if (Time.realtimeSinceStartup > m_FpsNextPeriod)
			{
				m_CurrentFps = (int)((float)m_FpsAccumulator / 0.5f);
				m_FpsAccumulator = 0;
				m_FpsNextPeriod += 0.5f;
				m_Text.text = $"{m_CurrentFps} Avg FPS";
				m_Text.color = m_ColorGradient.Evaluate((float)m_CurrentFps / m_RequiredFPS);
			}
		}
	}
}
