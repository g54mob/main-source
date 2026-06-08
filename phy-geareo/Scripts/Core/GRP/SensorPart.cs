using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine.InputSystem;

namespace GRP
{
	public class SensorPart : Part<SensorPartConfig>, IWithTransmitter, IControllable
	{
		[JsonDataState(null)]
		public State<TransmitterState> transmitter;

		[JsonDataState(null)]
		public State<float> distance;

		[JsonDataState(null)]
		public State<bool> analog;

		[JsonDataState(null)]
		public State<int> channel;

		[JsonDataState(null)]
		public State<Key> key;

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

		public override void BuildExhibit(ExhibitBuilder builder)
		{
		}
	}
}
