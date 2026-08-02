using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;
using UnityEngine;

namespace GRP
{
	public class CylinderPart : Part<CylinderPartConfig>, IColorable, IPartBound, ICreatedSize
	{
		[JsonDataState(null)]
		public State<int> segments;

		[JsonDataState(null)]
		public State<int> snapPoint;

		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<float> topRadius;

		[JsonDataState(null)]
		public State<float> bottomRadius;

		[JsonDataState(null)]
		public State<string> color;

		[JsonDataState(null)]
		public State<string> material;

		public StateSelector<Vector3> size;

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

		protected override void Load(JsonData data)
		{
		}
	}
}
