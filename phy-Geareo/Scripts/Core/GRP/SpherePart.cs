using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class SpherePart : Part<SpherePartConfig>, IColorable, IPartBound, ICreatedSize
	{
		[JsonDataState(null)]
		public State<float> radius;

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
	}
}
