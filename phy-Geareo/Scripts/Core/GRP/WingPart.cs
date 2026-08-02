using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class WingPart : Part<WingPartConfig>, ICreatedSize, IColorable
	{
		[JsonDataState(null)]
		public State<float> width;

		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<string> color;

		public StateSelector<Vector3> size;

		public StateSelector<Color> colorValue;

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
	}
}
