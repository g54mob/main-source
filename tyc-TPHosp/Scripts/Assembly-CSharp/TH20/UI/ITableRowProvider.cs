using UnityEngine;

namespace TH20.UI
{
	public interface ITableRowProvider
	{
		int NumOfRows { get; }

		void AssignTable(Table table);

		void ReleaseRow(int i);

		void SortColumn(int columnIndex, Table.SortDirection sortDirection);

		void SetRowsToOrginalOrder();

		RectTransform GetRow(int i);
	}
}
