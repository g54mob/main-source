using System;
using System.ComponentModel;

namespace ModIO
{
	[Serializable]
	[TypeConverter(typeof(ModIdConverter))]
	public struct ModId
	{
		public static readonly ModId Null;

		private long _id;

		public long id
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public ModId(long id)
		{
			_id = 0L;
		}

		public static implicit operator long(ModId id)
		{
			return 0L;
		}

		public static explicit operator ModId(long id)
		{
			return default(ModId);
		}
	}
}
