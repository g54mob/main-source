using System.Collections.Generic;

namespace Gh.Tk
{
	public class PatronStorage : Prop
	{
		public static HashSet<PatronStorage> AllPatronStorages;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public bool IsReserved { get; set; }

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}
	}
}
