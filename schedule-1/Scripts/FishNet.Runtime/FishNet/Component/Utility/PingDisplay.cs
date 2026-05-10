using UnityEngine;

namespace FishNet.Component.Utility
{
	[AddComponentMenu("FishNet/Component/PingDisplay")]
	public class PingDisplay : MonoBehaviour
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

		[Tooltip("Which corner to display ping in.")]
		[SerializeField]
		private Corner _placement;

		[Tooltip("True to show the real ping. False to include tick rate latency within the ping.")]
		[SerializeField]
		private bool _hideTickRate;

		private GUIStyle _style;

		private void OnGUI()
		{
		}
	}
}
