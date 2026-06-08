using UnityEngine;

namespace GRP
{
	public class GateVisual : MonoBehaviour
	{
		public Renderer renderer;

		public SignalVisual signalA;

		public SignalVisual signalB;

		public SignalVisual signalC;

		private MaterialPropertyBlock materialBlock;

		public void Setup(GatePart part, float value)
		{
		}

		public void Tick(bool a, bool b, bool c)
		{
		}
	}
}
