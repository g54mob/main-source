using System.Collections.Generic;
using System.Linq;
using CTS.Utilities;
using NorskaLib.GoogleSheetsDatabase;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "Level01 Prestige Data", menuName = "BBT/Prestige/Level01 Prestige Settings")]
	public class Level01PrestigeData : PrestigeLevelsData, IRevert
	{
		[PageName("PrestigeLevelingLevel1")]
		[HideInInspector]
		public List<PrestigeLevelData> _level01ImportedData = new List<PrestigeLevelData>();

		protected override void LoadData()
		{
			base.PrestigeSteps.Clear();
			foreach (PrestigeLevelData item in _level01ImportedData.OrderBy((PrestigeLevelData x) => x.PrestigeRequired).ToList())
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
