using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceOptIn]
	public class Snapping : AttachedBehaviour
	{
		public static HashSet<Snapping> AllSnappings;

		[Header("Config")]
		public SnappingType[] Types;

		public bool Target;

		public bool Point;

		public int[] TargetIndizes;

		public int[] PointIndizes;

		public bool IsOutside;

		public Transform OurTransform { get; private set; }

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
