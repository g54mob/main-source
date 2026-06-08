using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class PrismPart : Part<PrismPartConfig>, IColorable, ICreatedSize
	{
		[JsonDataState(null)]
		public State<float> width;

		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<float> depth;

		[JsonDataState(null)]
		public State<string> color;

		[JsonDataState(null)]
		public State<string> material;

		public StateSelector<Vector3> size;

		public StateSelector<Color> colorValue;

		public StateSelector<MaterialRowConfig> materialValue;

		public float slope
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

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
