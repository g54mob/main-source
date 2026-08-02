using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine.InputSystem;

namespace GRP
{
	public class GatePart : Part<GatePartConfig>, IWithTransmitter
	{
		[JsonDataState(null)]
		public State<TransmitterState> transmitter;

		[JsonDataState(null)]
		public State<GateMode> gate;

		[JsonDataState(null)]
		public State<int> channel;

		[JsonDataState(null)]
		public State<Key> aKey;

		[JsonDataState(null)]
		public State<Key> bKey;

		[JsonDataState(null)]
		public State<Key> cKey;

		protected override PartViewable DoCreateViewable()
		{
			return null;
		}

		public override void OnContext()
		{
		}

		public override void OnExpositorUI(ImUIBuilder ui)
		{
		}

		public State<TransmitterState> GetTransmitterState()
		{
			return null;
		}

		public override void BuildExhibit(ExhibitBuilder builder)
		{
		}
	}
}
