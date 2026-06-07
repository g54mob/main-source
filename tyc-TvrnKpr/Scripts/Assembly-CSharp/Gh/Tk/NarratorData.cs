using System;

namespace Gh.Tk
{
	[PersistenceIgnoreParent]
	[PersistenceOptIn]
	public class NarratorData : IEquatable<NarratorData>, IPersistable
	{
		[PersistenceOptIn]
		public int StoryId { get; set; }

		[PersistenceOptIn]
		public string TextKey { get; set; }

		[PersistenceOptIn]
		public string VoTextKey { get; set; }

		[PersistenceOptIn]
		public bool IsAutoSkipped { get; set; }

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(NarratorData other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(NarratorData first, NarratorData second)
		{
			return false;
		}

		public static bool operator !=(NarratorData lhs, NarratorData rhs)
		{
			return false;
		}
	}
}
