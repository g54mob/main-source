using System.Collections.Generic;
using Rhizomatic.ImUI;
using Rhizomatic.Utility;

namespace GRP
{
	public class MissionPart : Part<MissionPartConfig>
	{
		public OrbitCameraData camera;

		public List<MissionPartEntry> entries;

		protected override PartViewable DoCreateViewable()
		{
			return null;
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
	}
}
