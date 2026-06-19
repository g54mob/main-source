using System.Collections.Generic;

namespace IdSharp.Inspection
{
	internal sealed class PresetGuesser
	{
		private static List<PresetGuessRow> m_PresetGuessTable;

		static PresetGuesser()
		{
			m_PresetGuessTable = new List<PresetGuessRow>();
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, byte.MaxValue, 58, 1, 1, 3, 2, 205, LamePreset.Insane));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3902_391, LameVersionGroup.lvg3931_3903up, byte.MaxValue, 58, 1, 1, 3, 2, 206, LamePreset.Insane));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg394up, byte.MaxValue, 57, 1, 1, 3, 4, 205, LamePreset.Insane));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, 0, 78, 3, 2, 3, 2, 195, LamePreset.Extreme));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3902_391, 0, 78, 3, 2, 3, 2, 196, LamePreset.Extreme));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3931_3903up, 0, 78, 3, 1, 3, 2, 196, LamePreset.Extreme));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, 0, 78, 4, 2, 3, 2, 195, LamePreset.FastExtreme));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3902_391, LameVersionGroup.lvg3931_3903up, 0, 78, 4, 2, 3, 2, 196, LamePreset.FastExtreme));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, LameVersionGroup.lvg3902_391, 0, 78, 3, 2, 3, 4, 190, LamePreset.Standard));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3931_3903up, 0, 78, 3, 1, 3, 4, 190, LamePreset.Standard));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, LameVersionGroup.lvg3902_391, LameVersionGroup.lvg3931_3903up, 0, 78, 4, 2, 3, 4, 190, LamePreset.FastStandard));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3931_3903up, 0, 68, 3, 2, 3, 4, 180, LamePreset.Medium));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3931_3903up, 0, 68, 4, 2, 3, 4, 180, LamePreset.FastMedium));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, 0, 88, 4, 1, 3, 3, 195, LamePreset.R3mix));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3902_391, LameVersionGroup.lvg3931_3903up, 0, 88, 4, 1, 3, 3, 196, LamePreset.R3mix));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, LameVersionGroup.lvg3902_391, byte.MaxValue, 99, 1, 1, 1, 2, 0, LamePreset.Studio));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3931_3903up, byte.MaxValue, 58, 2, 1, 3, 2, 206, LamePreset.Studio));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg393, byte.MaxValue, 58, 2, 1, 3, 2, 205, LamePreset.Studio));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg394up, byte.MaxValue, 57, 2, 1, 3, 4, 205, LamePreset.Studio));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, LameVersionGroup.lvg3902_391, 192, 88, 1, 1, 1, 2, 0, LamePreset.CD));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3931_3903up, 192, 58, 2, 2, 3, 2, 196, LamePreset.CD));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg393, 192, 58, 2, 2, 3, 2, 195, LamePreset.CD));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg394up, 192, 57, 2, 1, 3, 4, 195, LamePreset.CD));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, LameVersionGroup.lvg3902_391, 160, 78, 1, 1, 3, 2, 180, LamePreset.Hifi));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg393, LameVersionGroup.lvg3931_3903up, 160, 58, 2, 2, 3, 2, 180, LamePreset.Hifi));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg394up, 160, 57, 2, 1, 3, 4, 180, LamePreset.Hifi));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, LameVersionGroup.lvg3902_391, 128, 67, 1, 1, 3, 2, 180, LamePreset.Tape));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, LameVersionGroup.lvg3902_391, 128, 67, 1, 1, 3, 2, 150, LamePreset.Radio));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, LameVersionGroup.lvg3902_391, 112, 67, 1, 1, 3, 2, 150, LamePreset.FM));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg393, LameVersionGroup.lvg3931_3903up, 112, 58, 2, 2, 3, 2, 160, LamePreset.TapeRadioFM));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg394up, 112, 57, 2, 1, 3, 4, 160, LamePreset.TapeRadioFM));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg393, LameVersionGroup.lvg3931_3903up, 56, 58, 2, 2, 0, 2, 100, LamePreset.Voice));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg394up, 56, 57, 2, 1, 0, 4, 150, LamePreset.Voice));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg390_3901_392, 40, 65, 1, 1, 0, 2, 75, LamePreset.MWUS));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3902_391, 40, 65, 1, 1, 0, 2, 76, LamePreset.MWUS));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg393, LameVersionGroup.lvg3931_3903up, 40, 58, 2, 2, 0, 2, 70, LamePreset.MWUS));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg394up, 40, 57, 2, 1, 0, 4, 105, LamePreset.MWUS));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3931_3903up, 24, 58, 2, 2, 0, 2, 40, LamePreset.MWEU));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg393, 24, 58, 2, 2, 0, 2, 39, LamePreset.MWEU));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg394up, 24, 57, 2, 1, 0, 4, 59, LamePreset.MWEU));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg3931_3903up, 16, 58, 2, 2, 0, 2, 38, LamePreset.Phone));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg393, 16, 58, 2, 2, 0, 2, 37, LamePreset.Phone));
			m_PresetGuessTable.Add(new PresetGuessRow(LameVersionGroup.lvg394up, 16, 57, 2, 1, 0, 4, 56, LamePreset.Phone));
		}

		public LamePreset GuessPreset(string AVersionString, byte ABitrate, byte AQuality, byte AEncodingMethod, byte ANoiseShaping, byte AStereoMode, byte AATHType, byte ALowpassDiv100, out bool ANonBitrate)
		{
			string text = AVersionString.Substring(0, 4);
			string text2 = AVersionString.Substring(0, 5);
			LamePreset result;
			if ((text == "3.90" && text2 != "3.90.") || text == "3.92")
			{
				result = GuessForVersion(LameVersionGroup.lvg390_3901_392, ABitrate, AQuality, AEncodingMethod, ANoiseShaping, AStereoMode, AATHType, ALowpassDiv100, out ANonBitrate);
			}
			else if (text2 == "3.90.")
			{
				result = BestGuessTwoVersions(LameVersionGroup.lvg3902_391, LameVersionGroup.lvg3931_3903up, ABitrate, AQuality, AEncodingMethod, ANoiseShaping, AStereoMode, AATHType, ALowpassDiv100, out ANonBitrate);
			}
			else if (text == "3.91")
			{
				result = GuessForVersion(LameVersionGroup.lvg3902_391, ABitrate, AQuality, AEncodingMethod, ANoiseShaping, AStereoMode, AATHType, ALowpassDiv100, out ANonBitrate);
			}
			else if (text == "3.93")
			{
				result = BestGuessTwoVersions(LameVersionGroup.lvg3931_3903up, LameVersionGroup.lvg393, ABitrate, AQuality, AEncodingMethod, ANoiseShaping, AStereoMode, AATHType, ALowpassDiv100, out ANonBitrate);
			}
			else if (string.Compare(text, "3.94") >= 0)
			{
				result = GuessForVersion(LameVersionGroup.lvg394up, ABitrate, AQuality, AEncodingMethod, ANoiseShaping, AStereoMode, AATHType, ALowpassDiv100, out ANonBitrate);
			}
			else
			{
				result = LamePreset.Unknown;
				ANonBitrate = false;
			}
			return result;
		}

		private LamePreset GuessForVersion(LameVersionGroup AVersionGroup, byte ABitrate, byte AQuality, byte AEncodingMethod, byte ANoiseShaping, byte AStereoMode, byte AATHType, byte ALowpassDiv100, out bool ANonBitrate)
		{
			LamePreset lamePreset = LamePreset.Unknown;
			LamePreset lamePreset2 = LamePreset.Unknown;
			ANonBitrate = false;
			foreach (PresetGuessRow item in m_PresetGuessTable)
			{
				if (item.HasVersionGroup(AVersionGroup) && item.TVs[1] == AQuality && item.TVs[2] == AEncodingMethod && item.TVs[3] == ANoiseShaping && item.TVs[4] == AStereoMode && item.TVs[5] == AATHType && item.TVs[6] == ALowpassDiv100)
				{
					if (item.TVs[0] == ABitrate)
					{
						lamePreset = item.Res;
						break;
					}
					if (AEncodingMethod == 3 || AEncodingMethod == 4)
					{
						lamePreset2 = item.Res;
					}
				}
			}
			if (lamePreset == LamePreset.Unknown && lamePreset2 != LamePreset.Unknown)
			{
				ANonBitrate = true;
				lamePreset = lamePreset2;
			}
			return lamePreset;
		}

		private LamePreset BestGuessTwoVersions(LameVersionGroup AGroup1, LameVersionGroup AGroup2, byte ABitrate, byte AQuality, byte AEncodingMethod, byte ANoiseShaping, byte AStereoMode, byte AATHType, byte ALowpassDiv100, out bool ANonBitrate)
		{
			LamePreset lamePreset = GuessForVersion(AGroup1, ABitrate, AQuality, AEncodingMethod, ANoiseShaping, AStereoMode, AATHType, ALowpassDiv100, out ANonBitrate);
			bool flag = ANonBitrate;
			LamePreset lamePreset2 = GuessForVersion(AGroup2, ABitrate, AQuality, AEncodingMethod, ANoiseShaping, AStereoMode, AATHType, ALowpassDiv100, out ANonBitrate);
			bool flag2 = ANonBitrate;
			LamePreset result;
			if (lamePreset == LamePreset.Unknown || (flag && lamePreset2 != LamePreset.Unknown))
			{
				result = lamePreset2;
				ANonBitrate = flag2;
			}
			else
			{
				result = lamePreset;
				ANonBitrate = flag;
			}
			return result;
		}
	}
}
