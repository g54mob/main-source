using System.ComponentModel;
using DV.Common;

namespace DV.Scenarios.Common
{
	public interface ICar : IScenariosThing, IThing, INotifyPropertyChanged
	{
		bool Reversed { get; set; }

		string CargoType { get; set; }
	}
}
