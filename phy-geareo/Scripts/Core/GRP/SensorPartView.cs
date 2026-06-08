using UnityEngine;

namespace GRP
{
	public class SensorPartView : PartView<SensorPartViewable>
	{
		public HubTransmitterVisual transmitter;

		public Transform line;

		public SensorVisual visual;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}
	}
}
