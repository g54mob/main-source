using Rhizomatic.ImUI;
using Rhizomatic.Reactive;

namespace GRP
{
	public class CoggiePart : Part<CoggiePartConfig>
	{
		[JsonDataState(null)]
		public State<string> key;

		[JsonDataState(null)]
		public State<float> scale;

		[JsonDataState(null)]
		public State<CoggieShapeType> shape;

		[JsonDataState(null)]
		public State<bool> follow;

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

		public override void BuildExhibit(ExhibitBuilder builder)
		{
		}
	}
}
