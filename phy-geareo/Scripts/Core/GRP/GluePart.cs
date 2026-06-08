using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using Rhizomatic.Utility;

namespace GRP
{
	public class GluePart : Part<GluePartConfig>
	{
		[JsonDataState(null)]
		public State<float> size;

		public State<bool> soft;

		public override void OnContext()
		{
		}

		public override void OnExpositorUI(ImUIBuilder ui)
		{
		}

		protected override void Save(JsonData data)
		{
		}

		protected override void Load(JsonData data)
		{
		}

		protected override void LoadDiff(JsonData data)
		{
		}

		protected override PartViewable DoCreateViewable()
		{
			return null;
		}
	}
}
