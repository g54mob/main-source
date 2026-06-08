using Rhizomatic;
using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class CamPart : Part<CamPartConfig>
	{
		[JsonDataState(null)]
		public State<int> segments;

		[JsonDataState(null)]
		public State<float> radius;

		[JsonDataState(null)]
		public State<float> thickness;

		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<CurveData> curve;

		[JsonDataState(null)]
		public State<string> color;

		[JsonDataState(null)]
		public State<string> material;

		public StateSelector<Curve> curveValue;

		public StateSelector<Color> colorValue;

		public StateSelector<MaterialRowConfig> materialValue;

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
