using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Audio
{
	public class G_AudioText : MonoBehaviour
	{
		[SerializeField]
		private Text m_DBText;

		private GraphyManager m_graphyManager;

		private G_AudioMonitor m_audioMonitor;

		private int m_updateRate;

		private float m_deltaTimeOffset;

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
