using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class BevelGearPart : Part<BevelGearPartConfig>, IColorable, IPartBound, ICreatedSize
	{
		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<int> teeth;

		[JsonDataState(null)]
		public State<int> skip;

		[JsonDataState(null)]
		public State<float> innerRadius;

		[JsonDataState(null)]
		public State<float> angle;

		[JsonDataState(null)]
		public State<string> color;

		[JsonDataState(null)]
		public State<string> material;

		[JsonDataState(null)]
		public State<string> inlay;

		[JsonDataState(null)]
		public State<bool> hole;

		[JsonDataState(null)]
		public State<int> module;

		public StateSelector<Vector3> size;

		public StateSelector<float> radius;

		public StateSelector<int> minTeeth;

		public StateSelector<float> maxInnerRadius;

		public StateSelector<GearModule> moduleValue;

		public StateSelector<Color> colorValue;

		public StateSelector<MaterialRowConfig> materialValue;

		public float diameter => 0f;

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

		public Vector3 GetPartSize()
		{
			return default(Vector3);
		}

		public void CreatedChangeSize(Vector2 change)
		{
		}

		public override void BuildExhibit(ExhibitBuilder builder)
		{
		}
	}
}
