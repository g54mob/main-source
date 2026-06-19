using Tayx.Graphy.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Audio
{
	public class AudioText : MonoBehaviour
	{
		private GraphyManager m_graphyManager;

		private AudioMonitor m_audioMonitor;

		[SerializeField]
		private Text m_DBText;

		private int m_updateRate = 4;

		private float m_deltaTimeOffset;

		private void Awake()
		{
			Init();
		}

		private void Update()
		{
			if (m_audioMonitor.SpectrumDataAvailable)
			{
				if (m_deltaTimeOffset > 1f / (float)m_updateRate)
				{
					m_deltaTimeOffset = 0f;
					m_DBText.text = Mathf.Clamp(m_audioMonitor.MaxDB, -80f, 0f).ToStringNonAlloc();
				}
				else
				{
					m_deltaTimeOffset += Time.deltaTime;
				}
			}
		}

		public void UpdateParameters()
		{
			m_updateRate = m_graphyManager.AudioTextUpdateRate;
		}

		private void Init()
		{
			if (!FloatString.Inited || FloatString.minValue > -1000f || FloatString.maxValue < 16384f)
			{
				FloatString.Init(-1001f, 16386f);
			}
			m_graphyManager = base.transform.root.GetComponentInChildren<GraphyManager>();
			m_audioMonitor = GetComponent<AudioMonitor>();
			UpdateParameters();
		}
	}
}
