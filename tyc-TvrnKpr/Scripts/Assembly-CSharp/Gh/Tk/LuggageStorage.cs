using System.Collections.Generic;

namespace Gh.Tk
{
	public class LuggageStorage : Prop
	{
		public static HashSet<LuggageStorage> AllLuggageStorages;

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
