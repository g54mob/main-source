using System;
using System.Collections.Generic;
using UnityEngine.Localization;

public static class IRCSystemDataExtension
{
	private static readonly Dictionary<IRCSystem, LocalizedString> data = new Dictionary<IRCSystem, LocalizedString>
	{
		{
			IRCSystem.Name,
			new LocalizedString(Guid.Parse("c51dab11-d919-7294-194a-1c79df3aa785"), 5699937111961600L)
		},
		{
			IRCSystem.Upgrade,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922866765824L)
		},
		{
			IRCSystem.Research,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922942263296L)
		},
		{
			IRCSystem.Operation,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457600L)
		},
		{
			IRCSystem.DatacenterOpened,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457601L)
		},
		{
			IRCSystem.DatacenterState,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457602L)
		},
		{
			IRCSystem.DebuggerHotfix,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457603L)
		},
		{
			IRCSystem.DebuggerPatch,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457604L)
		},
		{
			IRCSystem.DevelopmentStart,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457605L)
		},
		{
			IRCSystem.DevelopmentEnded,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457606L)
		},
		{
			IRCSystem.GameReleased,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457607L)
		},
		{
			IRCSystem.GameLaunched,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457608L)
		},
		{
			IRCSystem.ServerLoad90,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457609L)
		},
		{
			IRCSystem.ServerLoad100,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457610L)
		},
		{
			IRCSystem.ServerLoad110,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457611L)
		},
		{
			IRCSystem.Achievement,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 2922946457612L)
		},
		{
			IRCSystem.Rehired,
			new LocalizedString(Guid.Parse("fd979074-112c-a6e4-cbcb-87a66b5ff0e9"), 14044077375844352L)
		}
	};

	public static LocalizedString Value(this IRCSystem key)
	{
		return data[key];
	}
}
