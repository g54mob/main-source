using System.Collections.Generic;
using System.Linq;
using CTS.Utilities;
using NorskaLib.GoogleSheetsDatabase;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "Default Prestige Data", menuName = "BBT/Prestige/Default Prestige Settings")]
	public class DefaultPrestigeData : PrestigeLevelsData, IRevert
	{
		[PageName("PrestigeLevelingDefault")]
		[HideInInspector]
		public List<PrestigeLevelData> _defaultImportedData = new List<PrestigeLevelData>();

		protected override void LoadData()
		{
			base.PrestigeSteps.Clear();
			foreach (PrestigeLevelData item in _defaultImportedData.OrderBy((PrestigeLevelData x) => x.PrestigeRequired).ToList())
			{
				base.PrestigeSteps.Add(new PrestigeLevelData(item));
			}
			for (int num = 0; num < base.PrestigeSteps.Count; num++)
			{
				base.PrestigeSteps[num].Level = num + 1;
			}
		}
	}
}
