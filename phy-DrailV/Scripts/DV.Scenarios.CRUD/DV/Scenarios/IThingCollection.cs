using System.Collections;

namespace DV.Scenarios
{
	public interface IThingCollection
	{
		string TypeName { get; }

		IList Collection { get; }

		bool ShouldSortByName { get; }

		void FixData();

		void SortByName();

		string GetFirstAvailableName();
	}
}
