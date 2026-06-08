using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct SStartDayWarnings : IComponentData
	{
		public WarningLevel PopupsOpen;

		public WarningLevel SellingRequiredAppliance;

		public WarningLevel TableSize;

		public WarningLevel PlayersNotReady;

		public WarningLevel PostUnopened;

		public WarningLevel MoreThanOneTable;

		public WarningLevel PlayersInCraneMode;

		public static readonly List<StartDayWarning> Priority = new List<StartDayWarning>
		{
			StartDayWarning.Popup,
			StartDayWarning.TableSize,
			StartDayWarning.Post,
			StartDayWarning.SellingRequiredAppliance,
			StartDayWarning.MoreThanOneTable,
			StartDayWarning.PlayersInCraneMode,
			StartDayWarning.PlayersNotReady
		};

		public WarningLevel Level => (WarningLevel)Mathf.Max((int)PopupsOpen, (int)SellingRequiredAppliance, (int)TableSize, (int)PlayersNotReady, (int)PostUnopened, (int)MoreThanOneTable, (int)PlayersInCraneMode);

		public static SStartDayWarnings Unknown => default(SStartDayWarnings);

		public (StartDayWarning Type, WarningLevel Level) Primary
		{
			get
			{
				foreach (StartDayWarning item in Priority)
				{
					WarningLevel level = GetLevel(item);
					if (level.IsActive())
					{
						return (Type: item, Level: level);
					}
				}
				return (Type: StartDayWarning.Ready, Level: WarningLevel.Safe);
			}
		}

		public WarningLevel GetLevel(StartDayWarning type)
		{
			return type switch
			{
				StartDayWarning.PlayersNotReady => PlayersNotReady, 
				StartDayWarning.TableSize => TableSize, 
				StartDayWarning.Post => PostUnopened, 
				StartDayWarning.MoreThanOneTable => MoreThanOneTable, 
				StartDayWarning.Popup => PopupsOpen, 
				StartDayWarning.SellingRequiredAppliance => SellingRequiredAppliance, 
				StartDayWarning.PlayersInCraneMode => PlayersInCraneMode, 
				_ => WarningLevel.Unknown, 
			};
		}
	}
}
