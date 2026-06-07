using System.ComponentModel;
using DV.Common;
using DV.Util;

namespace DV.Scenarios.Common
{
	public interface ITrain : IScenariosThing, IThing, INotifyPropertyChanged
	{
		ObservableCollectionExt<ICar> Cars { get; }

		bool ExcludeFromRandomization { get; set; }
	}
}
