using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceOptIn]
	public class Stage : Prop
	{
		public const string UNIQUE_KEY = "stage";

		public static HashSet<Stage> AllStages;

		private Vector3 _previousPosition;

		private Quaternion _previousRotation;

		[PersistenceOptIn]
		private Dictionary<int, List<string>> _bookedEntertainers;

		public override void Start()
		{
		}

		public Dictionary<int, List<string>> GetBookedActs()
		{
			return null;
		}

		public override void OnDestroy()
		{
		}

		public override Job UseService(Actor actor, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float fallbackDuration = -1f)
		{
			return null;
		}
	}
}
