using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;
using UnityEngine;

namespace GRP
{
	public class BracePart : Part<BracePartConfig>, IColorable, ICreatedSize
	{
		[JsonDataState(null)]
		public State<float> size;

		[JsonDataState(null)]
		public State<ulong> brace;

		[JsonDataState(null)]
		public State<string> color;

		public StateSelector<BracePart> braceValue;

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

		public override void BuildExhibit(ExhibitBuilder builder)
		{
		}

		public void GetColors(ColorBuilder builder)
		{
		}

		protected override void Load(JsonData data)
		{
		}

		public void CreatedChangeSize(Vector2 change)
		{
		}
	}
}
