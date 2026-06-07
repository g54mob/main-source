using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Ram
{
	public class G_RamText : MonoBehaviour
	{
		[SerializeField]
		private Text m_allocatedSystemMemorySizeText;

		[SerializeField]
		private Text m_reservedSystemMemorySizeText;

		[SerializeField]
		private Text m_monoSystemMemorySizeText;

		private GraphyManager m_graphyManager;

		private G_RamMonitor m_ramMonitor;

		private float m_updateRate;

		private float m_deltaTime;

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
