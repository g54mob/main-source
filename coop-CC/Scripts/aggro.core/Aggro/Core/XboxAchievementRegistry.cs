using System.Collections.Generic;
using Unity.XGamingRuntime;

namespace Aggro.Core
{
	public static class XboxAchievementRegistry
	{
		public class XboxAchievement
		{
			public string XblId;

			public int Threshold;

			private bool _isUnlocked;

			private uint _Progress;

			public bool IsUnlocked
			{
				get
				{
					return _isUnlocked;
				}
				set
				{
					_isUnlocked = value;
				}
			}

			public uint Progress
			{
				get
				{
					return _Progress;
				}
				set
				{
					if (value > _Progress)
					{
						_Progress = value;
					}
				}
			}

			public XboxAchievement(string id, int threshold)
			{
				XblId = id;
				Threshold = threshold;
				_isUnlocked = false;
				_Progress = 0u;
			}
		}

		internal const string STAT_CRASHOUT_COUNT = "stat_crashout_count";

		internal const string STAT_BOOST_COUNT = "stat_boost_count";

		internal const string STAT_BOXES_SHIPPED = "stat_shipped_boxes";

		internal const string STAT_EXPLOSIVES_SHIPPED = "stat_shipped_explosives";

		internal const string STAT_ANIMALS_SHIPPED = "stat_shipped_animals";

		internal const string STAT_DRIFT_DISTANCE = "stat_drift_distance";

		internal const string STAT_FIRE_EXTINGUISHED = "stat_fires_extinguished";

		internal const string STAT_TRASH_DESTROYED = "stat_junk_destroyed";

		internal const string STAT_TRASH_MONEY = "stat_trash_money";

		internal const string STAT_BONUS_SHIPPED = "stat_bonus_shipped";

		internal const string STAT_BANANA_SLIPS = "stat_banana_slips";

		internal const string STAT_MESSES_CLEANED = "stat_messes_cleaned";

		internal const string STAT_CLOWNS_RELEASED = "stat_clowns_released";

		internal const string STAT_TIPTAP_MINUTES = "stat_tiptap_minutes";

		public static readonly Dictionary<string, XboxAchievement> Achievements = new Dictionary<string, XboxAchievement>
		{
			{
				"stat_crashout_count",
				new XboxAchievement("1", 1)
			},
			{
				"stat_boost_count",
				new XboxAchievement("2", 100)
			},
			{
				"ach_solve_toycube",
				new XboxAchievement("3", 1)
			},
			{
				"stat_shipped_boxes",
				new XboxAchievement("4", 100)
			},
			{
				"ach_placed_shelf",
				new XboxAchievement("5", 1)
			},
			{
				"ach_hoarder",
				new XboxAchievement("6", 1)
			},
			{
				"ach_modifier_faultywiring",
				new XboxAchievement("7", 1)
			},
			{
				"ach_modifier_coldstorage",
				new XboxAchievement("8", 1)
			},
			{
				"ach_modifier_heavyimpact",
				new XboxAchievement("9", 1)
			},
			{
				"ach_modifier_shiftingsands",
				new XboxAchievement("10", 1)
			},
			{
				"ach_modifier_overnightshipping",
				new XboxAchievement("11", 1)
			},
			{
				"ach_modifier_heatedflooring",
				new XboxAchievement("12", 1)
			},
			{
				"ach_modifier_hayfever",
				new XboxAchievement("13", 1)
			},
			{
				"ach_modifier_bombs",
				new XboxAchievement("14", 1)
			},
			{
				"ach_forklift_upgraded",
				new XboxAchievement("15", 1)
			},
			{
				"ach_forklift_superupgarded",
				new XboxAchievement("16", 1)
			},
			{
				"stat_drift_distance",
				new XboxAchievement("17", 5000)
			},
			{
				"ach_nocrashout_shift",
				new XboxAchievement("18", 1)
			},
			{
				"ach_nocrashout_contract",
				new XboxAchievement("19", 1)
			},
			{
				"ach_unlocked_all_contracts",
				new XboxAchievement("20", 1)
			},
			{
				"ach_unlocked_all_costumes",
				new XboxAchievement("21", 1)
			},
			{
				"ach_bells_50",
				new XboxAchievement("22", 1)
			},
			{
				"ach_bells_all",
				new XboxAchievement("23", 1)
			},
			{
				"ach_solve_toycube_meteor",
				new XboxAchievement("24", 1)
			},
			{
				"stat_shipped_animals",
				new XboxAchievement("25", 100)
			},
			{
				"stat_shipped_explosives",
				new XboxAchievement("26", 100)
			},
			{
				"ach_shelf_full",
				new XboxAchievement("27", 1)
			},
			{
				"stat_fires_extinguished",
				new XboxAchievement("28", 100)
			},
			{
				"stat_bonus_shipped",
				new XboxAchievement("29", 25)
			},
			{
				"ach_zookeeper",
				new XboxAchievement("30", 1)
			},
			{
				"ach_chicken_jockey",
				new XboxAchievement("31", 1)
			},
			{
				"stat_banana_slips",
				new XboxAchievement("32", 50)
			},
			{
				"ach_bee_keepaway",
				new XboxAchievement("33", 1)
			},
			{
				"stat_junk_destroyed",
				new XboxAchievement("34", 200)
			},
			{
				"stat_trash_money",
				new XboxAchievement("35", 500)
			},
			{
				"stat_messes_cleaned",
				new XboxAchievement("36", 100)
			},
			{
				"stat_clowns_released",
				new XboxAchievement("37", 100)
			},
			{
				"ach_tiptap_share",
				new XboxAchievement("38", 1)
			},
			{
				"ach_tiptap_first",
				new XboxAchievement("39", 1)
			},
			{
				"stat_tiptap_minutes",
				new XboxAchievement("40", 20)
			},
			{
				"ach_tiptap_pro",
				new XboxAchievement("41", 1)
			},
			{
				"ach_breakroom_goal",
				new XboxAchievement("42", 1)
			},
			{
				"ach_srank_first",
				new XboxAchievement("43", 1)
			},
			{
				"ach_srank_last",
				new XboxAchievement("44", 1)
			},
			{
				"ach_bingbong",
				new XboxAchievement("45", 1)
			}
		};

		public static void InitProgress(List<XblAchievement> xblAchievements)
		{
			foreach (XblAchievement xblAchievement in xblAchievements)
			{
				XboxAchievement xboxAchievement = null;
				foreach (XboxAchievement value in Achievements.Values)
				{
					if (value.XblId == xblAchievement.Id)
					{
						xboxAchievement = value;
						break;
					}
				}
				if (xboxAchievement == null)
				{
					continue;
				}
				if (xblAchievement.ProgressState == XblAchievementProgressState.Achieved)
				{
					xboxAchievement.IsUnlocked = true;
					xboxAchievement.Progress = 100u;
				}
				else
				{
					if (xblAchievement.ProgressState != XblAchievementProgressState.InProgress)
					{
						continue;
					}
					XblAchievementRequirement[] requirements = xblAchievement.Progression.Requirements;
					foreach (XblAchievementRequirement xblAchievementRequirement in requirements)
					{
						if (xblAchievementRequirement.TargetProgressValue == "100" && int.TryParse(xblAchievementRequirement.CurrentProgressValue, out var result) && result >= 0)
						{
							xboxAchievement.Progress = (uint)result;
							break;
						}
					}
				}
			}
		}
	}
}
