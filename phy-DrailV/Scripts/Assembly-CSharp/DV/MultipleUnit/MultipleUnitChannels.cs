using System;
using System.Collections.ObjectModel;
using DV.Utils;

namespace DV.MultipleUnit
{
	public class MultipleUnitChannels : SingletonBehaviour<MultipleUnitChannels>
	{
		public const int NUM_OF_CHANNELS = 8;

		private readonly MultipleUnitRemoteChannel[] channels = new MultipleUnitRemoteChannel[8];

		public ReadOnlyCollection<MultipleUnitRemoteChannel> Channels { get; private set; }

		public new static string AllowAutoCreate()
		{
			return "[MultipleUnitChannels]";
		}

		protected override void Awake()
		{
			base.Awake();
			for (int i = 0; i < channels.Length; i++)
			{
				channels[i] = new MultipleUnitRemoteChannel();
			}
			Channels = Array.AsReadOnly(channels);
		}
	}
}
