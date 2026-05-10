using FishNet.Managing.Statistic;
using UnityEngine;

namespace FishNet.Component.Utility
{
	[AddComponentMenu("FishNet/Component/BandwidthDisplay")]
	public class BandwidthDisplay : MonoBehaviour
	{
		private enum Corner
		{
			TopLeft = 0,
			TopRight = 1,
			BottomLeft = 2,
			BottomRight = 3
		}

		[SerializeField]
		[Tooltip("Color for text.")]
		private Color _color;

		[SerializeField]
		[Tooltip("Which corner to display network statistics in.")]
		private Corner _placement;

		[Tooltip("True to show outgoing data bytes.")]
		[SerializeField]
		private bool _showOutgoing;

		[SerializeField]
		[Tooltip("True to show incoming data bytes.")]
		private bool _showIncoming;

		private GUIStyle _style;

		private string _clientText;

		private string _serverText;

		private NetworkTraficStatistics _networkTrafficStatistics;

		private ulong peakBytesSentByServer;

		public void SetShowOutgoing(bool value)
		{
		}

		public void SetShowIncoming(bool value)
		{
		}
	}
}
