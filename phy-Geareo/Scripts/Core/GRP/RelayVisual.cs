using UnityEngine;

namespace GRP
{
	public class RelayVisual : MonoBehaviour
	{
		public SignalVisual signalReceive;

		public SignalVisual signalSend;

		public Renderer renderer;

		private MaterialPropertyBlock materialBlock;

		public void Setup(RelayPart part)
		{
		}

		public void Tick(float receive, float send)
		{
		}
	}
}
