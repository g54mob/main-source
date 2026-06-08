using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class TextPart : Part<TextPartConfig>, IColorable
	{
		[JsonDataState(null)]
		public State<string> text;

		[JsonDataState(null)]
		public State<float> size;

		[JsonDataState(null)]
		public State<float> depth;

		[JsonDataState(null)]
		public State<float> horizontal;

		[JsonDataState(null)]
		public State<float> vertical;

		[JsonDataState(null)]
		public State<string> color;

		[JsonDataState(null)]
		public State<string> material;

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
	}
}
