using System.Collections.Generic;
using DV.Scenarios.Common;
using UnityEngine;

namespace DV.Scenarios
{
	public class TrainCollection : ThingCollection<ITrain>
	{
		public override ITrain Create()
		{
			Train train = new Train();
			_AfterCreate(train);
			return train;
		}

		protected override void _FixData<T2>(T2 thing)
		{
			if (thing is Train train && train.Cars == null)
			{
				Debug.LogError("Train.Cars is null for train '" + thing.Name + "' (logging this just to see if it's even possible)");
			}
			base._FixData(thing);
		}

		public TrainCollection(string newThingName, CollectionManager manager, Dictionary<string, string> localizationDictionary)
			: base(newThingName, manager, true, localizationDictionary)
		{
		}
	}
}
