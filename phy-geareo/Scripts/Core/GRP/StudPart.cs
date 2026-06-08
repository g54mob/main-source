using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class StudPart : Part<StudPartConfig>, IColorable, ICreatedSize
	{
		[JsonDataState(null)]
		public State<float> radius;

		[JsonDataState(null)]
		public State<float> shaftRadius;

		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<string> color;

		[JsonDataState(null)]
		public State<string> shaftColor;

		[JsonDataState(null)]
		public State<string> material;

		[JsonDataState(null)]
		public State<string> shaftMaterial;

		public StateSelector<Vector3> size;

		public StateSelector<Vector3> shaftSize;

		public StateSelector<Color> colorValue;

		public StateSelector<MaterialRowConfig> materialValue;

		public StateSelector<Color> shaftColorValue;

		public StateSelector<MaterialRowConfig> shaftMaterialValue;

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
