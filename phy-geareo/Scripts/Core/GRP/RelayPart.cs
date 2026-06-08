using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine.InputSystem;

namespace GRP
{
	public class RelayPart : Part<RelayPartConfig>, IWithTransmitter, IControllable, ICreatedInverted
	{
		[JsonDataState(null)]
		public State<TransmitterState> transmitter;

		[JsonDataState(null)]
		public State<bool> inverted;

		[JsonDataState(null)]
		public State<bool> analog;

		[JsonDataState(null)]
		public State<int> receiveChannel;

		[JsonDataState(null)]
		public State<Key> receiveKey;

		[JsonDataState(null)]
		public State<int> sendChannel;

		[JsonDataState(null)]
		public State<Key> sendKey;

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

		public void GetKeys(KeyBuilder builder)
		{
		}

		public bool CreatedCanToggleInverted()
		{
			return false;
		}

		public void CreatedToggleInverted()
		{
		}

		public override void BuildExhibit(ExhibitBuilder builder)
		{
		}
	}
}
