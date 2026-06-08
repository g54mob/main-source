using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class LinearGearPart : Part<LinearGearPartConfig>, IColorable, IPartBound, ICreatedSize
	{
		[JsonDataState(null)]
		public State<int> teeth;

		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<float> width;

		[JsonDataState(null)]
		public State<string> color;

		[JsonDataState(null)]
		public State<string> material;

		[JsonDataState(null)]
		public State<int> module;

		public StateSelector<Vector3> size;

		public StateSelector<float> length;

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
