using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class SpringPart : Part<SpringPartConfig>, IColorable, ICreatedSize
	{
		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<float> spring;

		[JsonDataState(null)]
		public State<float> damper;

		[JsonDataState(null)]
		public State<float> charge;

		[JsonDataState(null)]
		public State<float> radius;

		[JsonDataState(null)]
		public State<string> topColor;

		[JsonDataState(null)]
		public State<string> bottomColor;

		[JsonDataState(null)]
		public State<string> springColor;

		[JsonDataState(null)]
		public State<string> material;

		public StateSelector<Vector3> size;

		public StateSelector<Vector3> bodySize;

		public StateSelector<Vector3> springSize;

		public StateSelector<Color> topColorValue;

		public StateSelector<Color> bottomColorValue;

		public StateSelector<Color> springColorValue;

		public StateSelector<MaterialRowConfig> materialValue;

		public float springValue => 0f;

		public float maxRadius => 0f;

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

		public void GetColors(ColorBuilder builder)
		{
		}

		public void CreatedChangeSize(Vector2 change)
		{
		}

		public override void BuildExhibit(ExhibitBuilder builder)
		{
		}
	}
}
