using System;
using System.Collections.Generic;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.State;

namespace NSMedieval.Construction
{
	public interface IFuelConsumer : IGoapTargetable, IGameDisposable, IDisposable
	{
		string ObjectId { get; }

		ZonePriority RefuelPriority { get; }

		List<ResourceGroups> DefaultFuelGroups { get; }

		bool Underwater { get; set; }

		bool CanStoreFuel(Resource blueprint);

		void SetRefuelPriority(ZonePriority priority);

		void AllowFuel(Resource resource, bool allowed);

		void PasteFuelConsumerSettings(IFuelConsumer originalFuelConsumer);
	}
}
