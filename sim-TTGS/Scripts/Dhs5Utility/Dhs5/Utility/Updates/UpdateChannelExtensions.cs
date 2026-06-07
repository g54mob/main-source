using System;
using Dhs5.Utility.Databases;

namespace Dhs5.Utility.Updates
{
	public static class UpdateChannelExtensions
	{
		public static IUpdateChannel GetValue(this EUpdateChannel e)
		{
			return Database.Get<UpdaterDatabase>().GetDataAtIndex<UpdaterDatabaseElement>((int)e);
		}

		public static Type GetChannelType(this EUpdateChannel e)
		{
			return e switch
			{
				EUpdateChannel.CLASSIC => typeof(CLASSIC_UpdateChannel), 
				EUpdateChannel.GAME_PLAYING => typeof(GAME_PLAYING_UpdateChannel), 
				EUpdateChannel.MOVEMENT => typeof(MOVEMENT_UpdateChannel), 
				EUpdateChannel.SENSORS => typeof(SENSORS_UpdateChannel), 
				EUpdateChannel.DAY_CYCLE => typeof(DAY_CYCLE_UpdateChannel), 
				EUpdateChannel.AI => typeof(AI_UpdateChannel), 
				_ => typeof(Updater.DefaultUpdateChannel), 
			};
		}

		public static bool Contains(this EUpdateChannelFlags flag, EUpdateChannel e)
		{
			return ((uint)flag & (uint)(1 << (int)e)) != 0;
		}

		public static bool Contains(this EUpdateChannelFlags flag, EUpdateChannelFlags other)
		{
			return (flag & other) != 0;
		}
	}
}
