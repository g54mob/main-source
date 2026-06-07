using System;
using System.Collections.Generic;
using System.Linq;
using DV.Utils;

namespace DV.Common
{
	public class GameFeatureFlags : SingletonBehaviour<GameFeatureFlags>
	{
		[Flags]
		public enum Flag : uint
		{
			None = 0u,
			Movement = 1u,
			Look = 2u,
			TeleportGeneral = 4u,
			TeleportInLoco = 8u,
			Hotbar = 0x10u,
			Inventory = 0x20u,
			SaveGame = 0x40u,
			JunctionSwitching = 0x80u,
			QuickTutorialControl = 0x100u,
			FastTravel = 0x200u,
			UseJobValidator = 0x400u,
			UseCareerManager = 0x800u,
			UseServiceStations = 0x1000u,
			Sleep = 0x2000u,
			ItemGrab = 0x4000u,
			WorldInteraction = 0x8000u,
			MouseMode = 0x10000u,
			ExternalCam = 0x20000u,
			KeyboardDriving = 0x40000u,
			MountingGadgets = 0x80000u,
			SolderingGadgets = 0x100000u,
			WiringGadgets = 0x200000u,
			HammeringGadgets = 0x400000u,
			ALL = uint.MaxValue
		}

		public delegate void FlagStatusChangedHandler(Flag flag, bool allowed);

		public static readonly Flag[] AllFlags = new List<Flag>((Flag[])Enum.GetValues(typeof(Flag))).TakeWhile((Flag f) => f != Flag.ALL).ToArray();

		private FlagStatusChangedHandler[] listeners = new FlagStatusChangedHandler[Enum.GetValues(typeof(Flag)).Length];

		private Flag deniedFlags;

		public static Flag DeniedFlags
		{
			get
			{
				if (!SingletonBehaviour<GameFeatureFlags>.Instance)
				{
					return Flag.None;
				}
				return SingletonBehaviour<GameFeatureFlags>.Instance.deniedFlags;
			}
		}

		public new static string AllowAutoCreate()
		{
			return "[GameFeatureFlags]";
		}

		protected override void Initialize()
		{
			deniedFlags = Flag.None;
		}

		public static bool IsAllowed(Flag flag)
		{
			GameFeatureFlags instance = SingletonBehaviour<GameFeatureFlags>.Instance;
			if ((bool)instance)
			{
				return (instance.deniedFlags & flag) == 0;
			}
			return true;
		}

		public static void Allow(Flag flag)
		{
			GameFeatureFlags instance = SingletonBehaviour<GameFeatureFlags>.Instance;
			if ((instance.deniedFlags & flag) == 0)
			{
				return;
			}
			Flag flag2 = (instance.deniedFlags ^ ~flag) & flag;
			instance.deniedFlags &= ~flag;
			for (int i = 0; i < AllFlags.Length; i++)
			{
				if ((flag2 & AllFlags[i]) != Flag.None && instance.listeners[i] != null)
				{
					instance.listeners[i](AllFlags[i], allowed: true);
				}
			}
		}

		public static void Deny(Flag flag)
		{
			GameFeatureFlags instance = SingletonBehaviour<GameFeatureFlags>.Instance;
			if ((instance.deniedFlags & flag) != Flag.None)
			{
				return;
			}
			Flag flag2 = (instance.deniedFlags ^ flag) & flag;
			instance.deniedFlags |= flag;
			for (int i = 0; i < AllFlags.Length; i++)
			{
				if ((flag2 & AllFlags[i]) != Flag.None && instance.listeners[i] != null)
				{
					instance.listeners[i](AllFlags[i], allowed: false);
				}
			}
		}

		public static void RegisterListenerFor(Flag flag, FlagStatusChangedHandler handler)
		{
			for (int i = 0; i < AllFlags.Length; i++)
			{
				if ((flag & AllFlags[i]) != Flag.None)
				{
					ref FlagStatusChangedHandler reference = ref SingletonBehaviour<GameFeatureFlags>.Instance.listeners[i];
					reference = (FlagStatusChangedHandler)Delegate.Combine(reference, handler);
				}
			}
		}

		public static void UnregisterListenerFor(Flag flag, FlagStatusChangedHandler handler)
		{
			if (!SingletonBehaviour<GameFeatureFlags>.Instance)
			{
				return;
			}
			for (int i = 0; i < AllFlags.Length; i++)
			{
				if ((flag & AllFlags[i]) != Flag.None)
				{
					ref FlagStatusChangedHandler reference = ref SingletonBehaviour<GameFeatureFlags>.Instance.listeners[i];
					reference = (FlagStatusChangedHandler)Delegate.Remove(reference, handler);
				}
			}
		}
	}
}
