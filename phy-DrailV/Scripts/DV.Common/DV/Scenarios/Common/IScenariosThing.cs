using System.ComponentModel;
using DV.Common;

namespace DV.Scenarios.Common
{
	public interface IScenariosThing : IThing, INotifyPropertyChanged
	{
		SyncState SyncState { get; set; }

		string FileName { get; }

		string FileExtension { get; }

		bool IsReadOnly { get; }

		void SaveSnapshot();

		void RevertChanges();
	}
}
