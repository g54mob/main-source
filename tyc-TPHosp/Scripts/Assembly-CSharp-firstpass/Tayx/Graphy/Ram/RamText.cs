using Tayx.Graphy.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Ram
{
	public class RamText : MonoBehaviour
	{
		private GraphyManager m_graphyManager;

		private RamMonitor m_ramMonitor;

		[SerializeField]
		private Text m_allocatedSystemMemorySizeText;

		[SerializeField]
		private Text m_reservedSystemMemorySizeText;

		[SerializeField]
		private Text m_monoSystemMemorySizeText;

		private float m_updateRate = 4f;

		private float m_deltaTime;

		private readonly string m_memoryStringFormat = "0.0";

		private void Awake()
		{
			Init();
		}

		private void Update()
		{
			m_deltaTime += Time.unscaledDeltaTime;
			if ((double)m_deltaTime > 1.0 / (double)m_updateRate)
			{
				m_allocatedSystemMemorySizeText.text = m_ramMonitor.AllocatedRam.ToStringNonAlloc(m_memoryStringFormat);
				m_reservedSystemMemorySizeText.text = m_ramMonitor.ReservedRam.ToStringNonAlloc(m_memoryStringFormat);
				m_monoSystemMemorySizeText.text = m_ramMonitor.MonoRam.ToStringNonAlloc(m_memoryStringFormat);
				m_deltaTime = 0f;
			}
		}

		public void UpdateParameters()
		{
			m_allocatedSystemMemorySizeText.color = m_graphyManager.AllocatedRamColor;
			m_reservedSystemMemorySizeText.color = m_graphyManager.ReservedRamColor;
			m_monoSystemMemorySizeText.color = m_graphyManager.MonoRamColor;
			m_updateRate = m_graphyManager.RamTextUpdateRate;
		}

		private void Init()
		{
			if (!FloatString.Inited || FloatString.minValue > -1000f || FloatString.maxValue < 16384f)
			{
				FloatString.Init(-1001f, 16386f);
			}
			m_graphyManager = base.transform.root.GetComponentInChildren<GraphyManager>();
			m_ramMonitor = GetComponent<RamMonitor>();
			UpdateParameters();
		}
	}
}
