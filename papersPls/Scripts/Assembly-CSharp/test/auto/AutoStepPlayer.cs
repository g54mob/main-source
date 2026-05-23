using System;
using haxe.lang;

namespace test.auto
{
	public class AutoStepPlayer : haxe.lang.Enum
	{
		public static readonly AutoStepPlayer DragLoadScreenNewButtonOnscreen;

		public static readonly AutoStepPlayer ClickThroughIntro;

		public static readonly AutoStepPlayer RestoreFromStash;

		public static readonly AutoStepPlayer RestoreFromStash_WaitForResume;

		public static readonly AutoStepPlayer ProcessNews;

		public static readonly AutoStepPlayer RunAllEnds;

		public static readonly AutoStepPlayer ProcessDay;

		public static readonly AutoStepPlayer ProcessDay_Tutor;

		public static readonly AutoStepPlayer ProcessDay_ExploreInitialPapers;

		public static readonly AutoStepPlayer ProcessDay_CallNextTraveler;

		public static readonly AutoStepPlayer ProcessDay_WaitForTraveler;

		public static readonly AutoStepPlayer ProcessDay_After;

		public static readonly AutoStepPlayer ProcessEndlessResult;

		public static readonly AutoStepPlayer ProcessNight;

		public static readonly AutoStepPlayer ProcessNight_After;

		public static readonly AutoStepPlayer ClickThroughCredits;

		public static readonly AutoStepPlayer ClickThroughEndlessResult;

		public static readonly AutoStepPlayer AddAuditScreenshot;

		protected static readonly string[] __hx_constructs;

		protected AutoStepPlayer(int index)
			: base(0)
		{
		}

		public static AutoStepPlayer Basic(AutoStepBasic basicStep)
		{
			return null;
		}

		public static AutoStepPlayer WaitForScreen(System.Type gameScreenClass)
		{
			return null;
		}

		public static AutoStepPlayer FastForwardTo(object fastForwardStop)
		{
			return null;
		}

		public static AutoStepPlayer SkipToDay(int dayId)
		{
			return null;
		}

		public static AutoStepPlayer SkipToTraveler(string travelerId)
		{
			return null;
		}

		public static AutoStepPlayer SkipToEnd(string endId)
		{
			return null;
		}

		public static AutoStepPlayer ProcessDay_ProcessTraveler(AutoTraveler autoTraveler)
		{
			return null;
		}

		public static AutoStepPlayer ClickThroughEnd(bool returnToTitle)
		{
			return null;
		}
	}
}
