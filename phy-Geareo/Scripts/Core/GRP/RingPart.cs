using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;
using UnityEngine;

namespace GRP
{
	public class RingPart : Part<RingPartConfig>, ICreatedSize, IColorable
	{
		[JsonDataState(null)]
		public State<int> segments;

		[JsonDataState(null)]
		public State<float> topRadius;

		[JsonDataState(null)]
		public State<float> bottomRadius;

		[JsonDataState(null)]
		public State<float> topThickness;

		[JsonDataState(null)]
		public State<float> bottomThickness;

		[JsonDataState(null)]
		public State<float> arc;

		[JsonDataState(null)]
		public State<float> arcOffset;

		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<int> snapPoint;

		[JsonDataState(null)]
		public State<string> color;

		[JsonDataState(null)]
		public State<string> material;

		public StateSelector<float> radius;

		public StateSelector<float> thickness;

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

		public void CreatedChangeSize(Vector2 change)
		{
		}

		public void GetColors(ColorBuilder builder)
		{
		}

		public override void BuildExhibit(ExhibitBuilder builder)
		{
		}

		protected override void Load(JsonData data)
		{
		}
	}
}
