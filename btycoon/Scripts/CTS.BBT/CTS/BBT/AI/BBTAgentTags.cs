using System.Collections.Generic;
using CTS.Core;

namespace CTS.BBT.AI
{
	public static class BBTAgentTags
	{
		public static StringKey CD_SlipOnPuddle;

		public static StringKey CD_Teleport;

		public static StringKey CD_Invisibility;

		public static StringKey CD_InvisibilityDuration;

		public static StringKey Oblivious { get; }

		public static StringKey NoReview { get; }

		public static StringKey ManualHypnosis { get; }

		public static StringKey StartedPanicking { get; }

		public static StringKey Investigate { get; }

		public static StringKey Investigating { get; }

		public static StringKey RandomMove { get; }

		public static StringKey ShotSomeone { get; }

		public static StringKey DestroyedMachine { get; }

		public static StringKey HunterTarget { get; }

		public static StringKey HunterRaiders { get; }

		public static HashSet<StringKey> DontSaveList { get; }

		static BBTAgentTags()
		{
			Oblivious = "Oblivious";
			NoReview = "NoReview";
			ManualHypnosis = "ManualHypnosis";
			StartedPanicking = "StartedPanicking";
			Investigate = "Investigate";
			Investigating = "Investigating";
			RandomMove = "RandomMove";
			ShotSomeone = "ShotSomeone";
			DestroyedMachine = "DestroyedMachine";
			HunterTarget = "HunterTarget";
			HunterRaiders = "HunterRaider";
			CD_SlipOnPuddle = "CD_SlipOnPuddle";
			CD_Teleport = "CD_Teleport";
			CD_Invisibility = "CD_Invisibility";
			CD_InvisibilityDuration = "CD_InvisibilityDuration";
			DontSaveList = new HashSet<StringKey>();
			DontSaveList.Add(HunterTarget);
		}

		public static TCollection FilterNotSave<TCollection>(this TCollection keys) where TCollection : ICollection<StringKey>
		{
			foreach (StringKey dontSave in DontSaveList)
			{
				keys.Remove(dontSave);
			}
			return keys;
		}
	}
}
