namespace I2.Loc
{
	public static class ScriptLocalization
	{
		public static class CUSTOMIZATION
		{
			public static string MIRROR_OFF
			{
				get
				{
					return Get("CUSTOMIZATION/MIRROR_OFF");
				}
			}

			public static string MIRROR_ON
			{
				get
				{
					return Get("CUSTOMIZATION/MIRROR_ON");
				}
			}

			public static string TIP_MANIPULATE
			{
				get
				{
					return Get("CUSTOMIZATION/TIP_MANIPULATE");
				}
			}

			public static string TIP_MASK
			{
				get
				{
					return Get("CUSTOMIZATION/TIP_MASK");
				}
			}

			public static string TIP_PAINT
			{
				get
				{
					return Get("CUSTOMIZATION/TIP_PAINT");
				}
			}

			public static string PartBody
			{
				get
				{
					return Get("CUSTOMIZATION/PartBody");
				}
			}

			public static string PartHead
			{
				get
				{
					return Get("CUSTOMIZATION/PartHead");
				}
			}

			public static string PartUpper
			{
				get
				{
					return Get("CUSTOMIZATION/PartUpper");
				}
			}

			public static string PartLower
			{
				get
				{
					return Get("CUSTOMIZATION/PartLower");
				}
			}
		}

		public static class TUTORIAL
		{
			public static string COOP
			{
				get
				{
					return Get("TUTORIAL/COOP");
				}
			}

			public static string CHEAT
			{
				get
				{
					return Get("TUTORIAL/CHEAT");
				}
			}

			public static string CAMERADISABLED
			{
				get
				{
					return Get("TUTORIAL/CAMERADISABLED");
				}
			}

			public static string RECORDERDISABLED
			{
				get
				{
					return Get("TUTORIAL/RECORDERDISABLED");
				}
			}

			public static string SAVING
			{
				get
				{
					return Get("TUTORIAL/SAVING");
				}
			}

			public static string LOADING
			{
				get
				{
					return Get("TUTORIAL/LOADING");
				}
			}
		}

		public static class MULTIPLAYER
		{
			public static string Relayed
			{
				get
				{
					return Get("MULTIPLAYER/Relayed");
				}
			}
		}

		public static string Get(string Term)
		{
			return Get(Term, false, 0);
		}

		public static string Get(string Term, bool FixForRTL)
		{
			return Get(Term, FixForRTL, 0);
		}

		public static string Get(string Term, bool FixForRTL, int maxLineLengthForRTL)
		{
			return LocalizationManager.GetTermTranslation(Term);
		}
	}
}
