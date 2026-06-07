using UnityEngine;

namespace Gh.Tk
{
	[PersistenceOptIn]
	public class ItemSnapping : AttachedBehaviour
	{
		[Header("Config")]
		public bool Target;

		public bool Point;

		public string Tag;
	}
}
