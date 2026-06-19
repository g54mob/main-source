using System;
using UnityEngine;

namespace TH20.UI
{
	[Serializable]
	public class InfoMessageSourceBreakInfo : InfoMessageSourceStaffBreak
	{
		[SerializeField]
		private LocalisedString _doctorBreakInfo;

		[SerializeField]
		private LocalisedString _nursesBreakInfo;

		[SerializeField]
		private LocalisedString _assistantsBreakInfo;

		[SerializeField]
		private LocalisedString _janitorsBreakInfo;

		public override string GetMessage(Level level)
		{
			WorkLifeBalanceManager.BalanceData balanceData = level.WorkLifeBalanceManager.GetBalanceData(base.StaffType, -1);
			int num = balanceData.NumAllowedBreak();
			int count = balanceData.Staff.Count;
			float value = ((count != 0) ? ((float)num / (float)count) : 0f);
			return LocalisedString.Replace(base.StaffType switch
			{
				StaffDefinition.Type.Doctor => _doctorBreakInfo.Translation, 
				StaffDefinition.Type.Nurse => _nursesBreakInfo.Translation, 
				StaffDefinition.Type.Assistant => _assistantsBreakInfo.Translation, 
				StaffDefinition.Type.Janitor => _janitorsBreakInfo.Translation, 
				_ => throw new ArgumentOutOfRangeException(), 
			}, new SubPair[3]
			{
				new SubPair("{[ALLOWED]}", num.ToString()),
				new SubPair("{[TOTAL]}", count.ToString()),
				new SubPair("{[PERCENTAGE]}", StringUtils.FormatPercentageValue(value))
			});
		}
	}
}
