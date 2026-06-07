using System;
using System.Reflection;

namespace GAudio
{
	public class GATFilterParam
	{
		private PropertyInfo _propInfo;

		public string ParamName { get; private set; }

		public AGATMonoFilter Filter { get; private set; }

		public float ParamValue
		{
			get
			{
				return (float)_propInfo.GetValue(Filter, null);
			}
			set
			{
				_propInfo.SetValue(Filter, value, null);
			}
		}

		public GATFilterParam(AGATMonoFilter filter, string paramName)
		{
			Type type = filter.GetType();
			_propInfo = type.GetProperty(paramName, BindingFlags.Instance | BindingFlags.Public);
			if (_propInfo == null)
			{
				throw new GATException("No such filter!");
			}
			Filter = filter;
		}

		public GATFilterParam(int trackNb, int slotNb, string paramName, GATPlayer player = null)
		{
			if (player == null)
			{
				player = GATManager.DefaultPlayer;
			}
			GATTrack track = player.GetTrack(trackNb);
			if (track == null)
			{
				throw new GATException("Track " + trackNb + " does not exist.");
			}
			Filter = track.FiltersHandler.GetFilterAtSlot(slotNb);
			if (Filter == null)
			{
				throw new GATException("No filter found in slot " + slotNb + " of track " + trackNb);
			}
			Type type = Filter.GetType();
			_propInfo = type.GetProperty(paramName, BindingFlags.Instance | BindingFlags.Public);
			if (_propInfo == null)
			{
				throw new GATException("No such filter!");
			}
		}

		public GATFilterParam(int slotNb, string paramName, GATPlayer player = null)
		{
			if (player == null)
			{
				player = GATManager.DefaultPlayer;
			}
			Filter = player.FiltersHandler.GetFilterAtSlot(slotNb);
			if (Filter == null)
			{
				throw new GATException("No filter found in slot " + slotNb + " of player.");
			}
			Type type = Filter.GetType();
			_propInfo = type.GetProperty(paramName, BindingFlags.Instance | BindingFlags.Public);
			if (_propInfo == null)
			{
				throw new GATException("No such filter!");
			}
		}
	}
}
