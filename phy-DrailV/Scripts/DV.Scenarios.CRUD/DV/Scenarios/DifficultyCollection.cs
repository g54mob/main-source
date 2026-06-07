using System.Collections.Generic;
using DV.Scenarios.Common;

namespace DV.Scenarios
{
	public class DifficultyCollection : ThingCollection<IDifficulty>
	{
		public override IDifficulty Create()
		{
			Difficulty difficulty = new Difficulty();
			_AfterCreate(difficulty);
			return difficulty;
		}

		protected override void _FixData<T2>(T2 thing)
		{
			base._FixData(thing);
		}

		public DifficultyCollection(string newThingName, CollectionManager manager, Dictionary<string, string> localizationDictionary)
			: base(newThingName, manager, false, localizationDictionary)
		{
		}
	}
}
