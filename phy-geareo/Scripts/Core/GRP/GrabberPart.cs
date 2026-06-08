using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GRP
{
	public class GrabberPart : Part<GrabberPartConfig>, IControllable
	{
		[JsonDataState(null)]
		public State<float> width;

		[JsonDataState(null)]
		public State<float> depth;

		[JsonDataState(null)]
		public State<GrabberMode> mode;

		[JsonDataState(null)]
		public State<int> channel;

		[JsonDataState(null)]
		public State<Key> key;

		public StateSelector<Vector3> bodySize;

		public StateSelector<Vector3> headSize;

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

		public void GetKeys(KeyBuilder builder)
		{
		}

		public override void BuildExhibit(ExhibitBuilder builder)
		{
		}
	}
}
