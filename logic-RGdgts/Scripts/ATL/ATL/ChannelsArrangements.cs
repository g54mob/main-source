namespace ATL
{
	public class ChannelsArrangements
	{
		public class ChannelsArrangement
		{
			public string Description { get; set; }

			public int NbChannels { get; set; }

			public ChannelsArrangement(int nbChannels, string description)
			{
			}

			public ChannelsArrangement(int nbChannels)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public static readonly ChannelsArrangement UNKNOWN;

		public static readonly ChannelsArrangement ISO_1_0_0;

		public static readonly ChannelsArrangement MONO;

		public static readonly ChannelsArrangement ISO_2_0_0;

		public static readonly ChannelsArrangement STEREO;

		public static readonly ChannelsArrangement ISO_3_0_0;

		public static readonly ChannelsArrangement ISO_3_1_0;

		public static readonly ChannelsArrangement ISO_3_2_0;

		public static readonly ChannelsArrangement ISO_3_2_1;

		public static readonly ChannelsArrangement ISO_5_2_1;

		public static readonly ChannelsArrangement ISO_1_1;

		public static readonly ChannelsArrangement DUAL_MONO;

		public static readonly ChannelsArrangement ISO_2_1_0;

		public static readonly ChannelsArrangement ISO_2_2_0;

		public static readonly ChannelsArrangement QUAD;

		public static readonly ChannelsArrangement ISO_3_3_1;

		public static readonly ChannelsArrangement ISO_3_4_1;

		public static readonly ChannelsArrangement ISO_11_11_2;

		public static readonly ChannelsArrangement JOINT_STEREO;

		public static readonly ChannelsArrangement JOINT_STEREO_INTENSITY;

		public static readonly ChannelsArrangement JOINT_STEREO_LEFT_SIDE;

		public static readonly ChannelsArrangement JOINT_STEREO_RIGHT_SIDE;

		public static readonly ChannelsArrangement JOINT_STEREO_MID_SIDE;

		public static readonly ChannelsArrangement STEREO_LEFT_RIGHT_TOTAL;

		public static readonly ChannelsArrangement LRCS;

		public static readonly ChannelsArrangement LRCLFE;

		public static readonly ChannelsArrangement DVD_5;

		public static readonly ChannelsArrangement DVD_11;

		public static readonly ChannelsArrangement DVD_18;

		public static readonly ChannelsArrangement LRCLFECrLssRss;

		public static readonly ChannelsArrangement LRCLFELrRrLssRss;

		public static readonly ChannelsArrangement LRLcRcCS;

		public static readonly ChannelsArrangement STEREO_SUM_DIFFERENCE;

		public static readonly ChannelsArrangement CLCRLRSLSR;

		public static readonly ChannelsArrangement CLRLRRRO;

		public static readonly ChannelsArrangement CFCRLFRFLRRR;

		public static readonly ChannelsArrangement CLCCRLRSLSR;

		public static readonly ChannelsArrangement CLCRLRSLSR_LFE;

		public static readonly ChannelsArrangement CLRLRRRO_LFE;

		public static readonly ChannelsArrangement CFCRLFRFLRRR_LFE;

		public static readonly ChannelsArrangement CLCRLRSL1SL2SR1SR2;

		public static readonly ChannelsArrangement CLCCRLRSLSSR;

		public static readonly ChannelsArrangement CLCCRLRSLSR_LFE;

		public static readonly ChannelsArrangement CLCRLRSL1SL2SR1SR2_LFE;

		public static readonly ChannelsArrangement CLCCRLRSLSSR_LFE;

		public static readonly ChannelsArrangement STEREO_XY;

		public static readonly ChannelsArrangement STEREO_BINAURAL;

		public static readonly ChannelsArrangement AMBISONIC_B;

		public static readonly ChannelsArrangement PENTAGONAL;

		public static readonly ChannelsArrangement HEXAGONAL;

		public static readonly ChannelsArrangement OCTAGONAL;

		public static readonly ChannelsArrangement CUBE;

		public static readonly ChannelsArrangement MPEG_6_1;

		public static readonly ChannelsArrangement MPEG_7_1;

		public static readonly ChannelsArrangement SMPTE_DTV;

		public static readonly ChannelsArrangement ITU_2_1;

		public static readonly ChannelsArrangement ITU_2_2;

		public static readonly ChannelsArrangement DVD_4;

		public static readonly ChannelsArrangement DVD_6;

		public static readonly ChannelsArrangement DVD_10;

		public static readonly ChannelsArrangement AUDIOUNIT_6_0;

		public static readonly ChannelsArrangement AUDIOUNIT_7_0;

		public static readonly ChannelsArrangement AAC_6_0;

		public static readonly ChannelsArrangement AAC_6_1;

		public static readonly ChannelsArrangement AAC_7_0;

		public static readonly ChannelsArrangement AAC_OCTAGONAL;

		public static readonly ChannelsArrangement TMH_10_2_STD;

		public static readonly ChannelsArrangement TMH_10_2_FULL;

		public static ChannelsArrangement GuessFromChannelNumber(int nbChannels)
		{
			return null;
		}
	}
}
