using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	public static class HabitsEditorUtility
	{
		private static HabitsYearProfile cozyHabitsProfile;

		private static CozyHabits cozyHabits;

		public static GUIStyle toolbarButtonIcon = new GUIStyle(GUI.skin.GetStyle("ToolbarButton"))
		{
			padding = new RectOffset(-5, -5, -5, -5),
			fixedWidth = 15f,
			fixedHeight = 15f
		};

		public static GUIStyle nextPreviousButtonStyle = new GUIStyle(GUI.skin.GetStyle("Button"))
		{
			padding = new RectOffset(-5, -5, -5, -5),
			fixedWidth = 30f,
			fixedHeight = 30f
		};

		public static HabitsYearProfile habitsProfile
		{
			get
			{
				if (cozyHabitsProfile == null)
				{
					cozyHabitsProfile = CozyWeather.instance.GetModule<CozyHabits>().profile;
				}
				return cozyHabitsProfile;
			}
			set
			{
				cozyHabitsProfile = value;
			}
		}

		public static CozyHabits habits
		{
			get
			{
				if (cozyHabits == null)
				{
					cozyHabits = CozyWeather.instance.GetModule<CozyHabits>();
				}
				return cozyHabits;
			}
			set
			{
				cozyHabits = value;
			}
		}

		public static string CapitalizeFirstLetter(string str)
		{
			if (!string.IsNullOrEmpty(str))
			{
				return char.ToUpper(str[0]) + str.Substring(1);
			}
			return str;
		}
	}
}
