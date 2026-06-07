using ManagementScripts;
using Steamworks;
using UnityEngine;
using Utility;

namespace SteamIntegrations
{
	public class Achievement : IAchievement
	{
		public bool isSecret;

		public Sprite spriteAchieved;

		public Sprite spriteNotAchieved;

		protected string id_t;

		protected string title_t;

		protected string desc_t;

		protected bool achieved_t;

		public string id => id_t;

		public string title => title_t;

		public string desc => desc_t;

		public bool fullIconSet
		{
			get
			{
				if (spriteAchieved != null)
				{
					return spriteNotAchieved != null;
				}
				return false;
			}
		}

		public bool achieved => achieved_t;

		protected virtual bool achievedLocal
		{
			get
			{
				return PlayerPrefs.GetInt(id_t, 0) == 1;
			}
			set
			{
				PlayerPrefs.SetInt(id_t, value ? 1 : 0);
			}
		}

		public bool achievedSteam
		{
			get
			{
				bool pbAchieved = false;
				if (SteamManager.Initialized)
				{
					SteamUserStats.GetAchievement(id_t, out pbAchieved);
				}
				return pbAchieved;
			}
			set
			{
				if (SteamManager.Initialized)
				{
					if (value)
					{
						SteamUserStats.SetAchievement(id_t);
					}
					else
					{
						SteamUserStats.ClearAchievement(id_t);
					}
					AchievementManager.StoreStats();
				}
			}
		}

		protected Achievement()
		{
		}

		public Achievement(string achievementID, string achievementTitle, string achievementDesc, bool secret = false)
		{
			id_t = achievementID;
			title_t = achievementTitle;
			desc_t = achievementDesc;
			isSecret = secret;
		}

		public void Trigger(GameObject source = null)
		{
			PlayerPrefs.SetString(id_t + "_LAST_VERSION", Utility.Version.Present.ToString());
			if (!achieved)
			{
				achieved_t = true;
				achievedLocal = true;
				achievedSteam = true;
				TooltipSystem.TriggerAchievementPopup(this, source);
			}
		}

		public void Reset()
		{
			if (achieved)
			{
				achieved_t = false;
				achievedLocal = false;
				achievedSteam = false;
			}
		}

		public virtual void Sync()
		{
			bool flag = achievedSteam;
			bool flag2 = achievedLocal;
			if (flag && !flag2)
			{
				achievedLocal = true;
				achieved_t = true;
			}
			else if (flag2 && !flag)
			{
				achievedSteam = true;
				achieved_t = true;
			}
			else
			{
				achieved_t = achievedLocal;
			}
		}
	}
}
