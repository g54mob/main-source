using Rhizomatic.ImUI;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class GearPart : Part<GearPartConfig>
	{
		[JsonDataState(null)]
		public State<float> height;

		[JsonDataState(null)]
		public State<int> teeth;

		[JsonDataState(null)]
		public State<float> angle;

		public StateSelector<Vector3> visualSize;

		public StateSelector<Vector3> shapeSize;

		public bool isBevel => false;

		public float radius => 0f;

		public float spawnRadius => 0f;

		public float innerRadius => 0f;

		public float innerDiameter => 0f;

		public float shapeDiameter => 0f;

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
	}
}
