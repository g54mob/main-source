using System.ComponentModel;
using DV.Common;
using DV.Scenarios.Common;
using Newtonsoft.Json;

namespace DV.Scenarios
{
	[ShouldCreateCopyInstanceInParentsList]
	public class Car : Thing, ICar, IScenariosThing, IThing, INotifyPropertyChanged
	{
		private bool _reversed;

		private string _cargoType;

		public override string FileExtension => null;

		[JsonProperty]
		public bool Reversed
		{
			get
			{
				return _reversed;
			}
			set
			{
				SetField(ref _reversed, value, "Reversed");
			}
		}

		[JsonProperty]
		public string CargoType
		{
			get
			{
				return _cargoType;
			}
			set
			{
				SetField(ref _cargoType, value, "CargoType");
			}
		}

		public override SyncState SyncState
		{
			get
			{
				return SyncState.Synced;
			}
			set
			{
			}
		}

		public override bool Equals(object other)
		{
			if (other is Thing b)
			{
				return Thing.GetMatchScore(this, b) > 0;
			}
			return false;
		}
	}
}
