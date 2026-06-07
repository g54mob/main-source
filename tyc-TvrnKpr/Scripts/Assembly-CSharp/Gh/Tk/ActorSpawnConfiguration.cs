using UnityEngine;

namespace Gh.Tk
{
	public class ActorSpawnConfiguration : MonoBehaviour
	{
		[Header("Type-specific config")]
		public string type;

		[Header("Spawn pattern")]
		public AnimationCurve dayPatronSpawnPattern;

		internal float Rest { get; set; }

		internal float DaySpawnCurveSum { get; set; }
	}
}
