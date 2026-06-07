using System.ComponentModel;
using DV.Common;
using DV.Scenarios.Common;
using DV.Util;
using Newtonsoft.Json;

namespace DV.Scenarios
{
	public class Train : Thing, ITrain, IScenariosThing, IThing, INotifyPropertyChanged
	{
		private bool _excludeFromRandomization;

		public override string FileExtension => "dvtrain";

		[JsonProperty]
		public ObservableCollectionExt<ICar> Cars { get; private set; } = new ObservableCollectionExt<ICar>();

		[JsonProperty]
		public bool ExcludeFromRandomization
		{
			get
			{
				return _excludeFromRandomization;
			}
			set
			{
				SetField(ref _excludeFromRandomization, value, "ExcludeFromRandomization");
			}
		}
	}
}
