using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator
{
	[Settings("Excel Databases", Scope.Project)]
	public class ExcelDatabaseSettings : CustomSettings<ExcelDatabaseSettings>
	{
		[Header("References")]
		[SerializeField]
		private EnumValues<EExcelDatabase, ExcelDatabase> m_references;

		public static ExcelDatabase GetDatabase(EExcelDatabase type)
		{
			return CustomSettings<ExcelDatabaseSettings>.I.m_references[type];
		}
	}
}
