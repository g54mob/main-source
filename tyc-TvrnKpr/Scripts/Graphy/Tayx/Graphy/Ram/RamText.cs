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

		private float m_updateRate;

		private float m_deltaTime;

		private readonly string m_memoryStringFormat;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void UpdateParameters()
		{
		}

		private void Init()
		{
		}
	}
}
