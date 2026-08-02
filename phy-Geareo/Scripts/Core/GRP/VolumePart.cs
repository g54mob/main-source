using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class VolumePart : Part<VolumePartConfig>
	{
		[JsonDataState(null)]
		public State<string> key;

		[JsonDataState(null)]
		public State<float> width;

		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<float> depth;

		[JsonDataState(null)]
		public State<float> radius;

		[JsonDataState(null)]
		public State<ulong> connection;

		[JsonDataState(null)]
		public State<string> style;

		[JsonDataState(null)]
		public State<VolumeShapeType> shape;

		public StateSelector<Vector3> size;

		private string[] styles;

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
	}
}
