namespace IdSharp.Inspection
{
	internal sealed class DescriptiveLameTagReader
	{
		private BasicLameTagReader m_BasicReader;

		private UsePresetGuess m_UsePresetGuess;

		private MpegAudio m_Mpeg;

		private string m_Preset;

		private string m_PresetGuess;

		public bool IsLameTagFound => m_BasicReader.IsLameTagFound;

		public string VersionString => m_BasicReader.VersionString;

		public string VersionStringNonLameTag => m_BasicReader.VersionStringNonLameTag;

		public UsePresetGuess UsePresetGuess => m_UsePresetGuess;

		public bool IsPresetGuessNonBitrate => m_BasicReader.IsPresetGuessNonBitrate;

		public string Preset => m_Preset;

		public string PresetGuess => m_PresetGuess;

		public string LameTagInfoVersion => m_Mpeg.Version + " " + m_Mpeg.Layer;

		public string LameTagInfoEncoder
		{
			get
			{
				string text;
				if (!IsLameTagFound)
				{
					text = m_Mpeg.Encoder;
				}
				else
				{
					text = "LAME";
					if (string.Compare(VersionString, "3.90") < 0)
					{
						if (!string.IsNullOrEmpty(VersionStringNonLameTag) && VersionStringNonLameTag[1] == '.')
						{
							text = text + " " + VersionStringNonLameTag;
						}
					}
					else if (!string.IsNullOrEmpty(VersionString))
					{
						text = text + " " + VersionString;
					}
				}
				return text;
			}
		}

		public string LameTagInfoPreset
		{
			get
			{
				string result = "";
				if (IsLameTagFound && string.Compare(VersionString, "3.90") >= 0)
				{
					result = Preset;
					if (UsePresetGuess == UsePresetGuess.UseGuess)
					{
						result = ((!IsPresetGuessNonBitrate) ? (PresetGuess + " (guessed)") : (PresetGuess + " (modified)"));
					}
				}
				return result;
			}
		}

		public DescriptiveLameTagReader(string path)
		{
			m_Mpeg = new MpegAudio(path);
			m_BasicReader = new BasicLameTagReader(path);
			DeterminePresetRelatedValues();
		}

		private void DeterminePresetRelatedValues()
		{
			m_Preset = DeterminePreset(out m_UsePresetGuess);
			if (m_UsePresetGuess == UsePresetGuess.NotNeeded)
			{
				m_PresetGuess = "";
				return;
			}
			m_PresetGuess = DeterminePresetGuess(ref m_UsePresetGuess);
			if (m_BasicReader.IsPresetGuessNonBitrate)
			{
				m_PresetGuess += $" -b {m_BasicReader.Bitrate}";
			}
		}

		private string DeterminePreset(out UsePresetGuess usePresetGuess)
		{
			usePresetGuess = UsePresetGuess.NotNeeded;
			int preset = m_BasicReader.Preset;
			string text;
			if (preset >= 8 && preset <= 320)
			{
				text = preset.ToString();
				if (m_BasicReader.EncodingMethod == 1)
				{
					text = "cbr " + text;
				}
				usePresetGuess = UsePresetGuess.UseGuess;
			}
			else
			{
				switch (preset)
				{
				case 0:
					text = "<not stored>";
					usePresetGuess = UsePresetGuess.UseGuess;
					break;
				case 410:
					text = "V9";
					break;
				case 420:
					text = "V8";
					break;
				case 430:
					text = "V7";
					break;
				case 440:
					text = "V6";
					break;
				case 450:
					text = "V5";
					break;
				case 460:
					text = "V4: preset medium";
					break;
				case 470:
					text = "V3";
					break;
				case 480:
					text = "V2: preset standard";
					break;
				case 490:
					text = "V1";
					break;
				case 500:
					text = "V0: preset extreme";
					break;
				case 1000:
					text = "r3mix";
					break;
				case 1001:
					text = "--alt-preset standard";
					break;
				case 1002:
					text = "--alt-preset extreme";
					break;
				case 1003:
					text = "--alt-preset insane";
					break;
				case 1004:
					text = "--alt-preset fast standard";
					break;
				case 1005:
					text = "--alt-preset fast extreme";
					break;
				case 1006:
					text = "preset medium";
					break;
				case 1007:
					text = "preset fast medium";
					break;
				case 1010:
					text = "preset portable";
					break;
				case 1015:
					text = "preset radio";
					break;
				default:
					text = $"<unrecognised value {preset}>";
					usePresetGuess = UsePresetGuess.UseGuess;
					break;
				}
			}
			if (m_BasicReader.EncodingMethod == 4 && (preset == 410 || preset == 420 || preset == 430 || preset == 440 || preset == 450 || preset == 460 || preset == 470 || preset == 480 || preset == 490 || preset == 500))
			{
				text += " (fast mode)";
			}
			return text;
		}

		private string DeterminePresetGuess(ref UsePresetGuess usePresetGuess)
		{
			string result;
			switch (m_BasicReader.PresetGuess)
			{
			case LamePreset.Insane:
				result = "--alt-preset insane";
				break;
			case LamePreset.Extreme:
				result = "--alt-preset extreme";
				break;
			case LamePreset.FastExtreme:
				result = "--alt-preset fast extreme";
				break;
			case LamePreset.Standard:
				result = "--alt-preset standard";
				break;
			case LamePreset.FastStandard:
				result = "--alt-preset fast standard";
				break;
			case LamePreset.Medium:
				result = "preset medium";
				break;
			case LamePreset.FastMedium:
				result = "preset fast medium";
				break;
			case LamePreset.R3mix:
				result = "r3mix";
				break;
			case LamePreset.Studio:
				result = "preset studio";
				break;
			case LamePreset.CD:
				result = "preset cd";
				break;
			case LamePreset.Hifi:
				result = "preset hifi";
				break;
			case LamePreset.Tape:
				result = "preset tape";
				break;
			case LamePreset.Radio:
				result = "preset radio";
				break;
			case LamePreset.FM:
				result = "preset fm";
				break;
			case LamePreset.TapeRadioFM:
				result = "preset tape OR preset radio OR preset fm";
				break;
			case LamePreset.Voice:
				result = "preset voice";
				break;
			case LamePreset.MWUS:
				result = "preset mw-us";
				break;
			case LamePreset.MWEU:
				result = "preset phon+ OR preset lw OR preset mw-eu OR preset sw";
				break;
			case LamePreset.Phone:
				result = "preset phone";
				break;
			default:
				result = "";
				if (m_BasicReader.Preset == 0)
				{
					usePresetGuess = UsePresetGuess.UnableToGuess;
				}
				else
				{
					usePresetGuess = UsePresetGuess.NotNeeded;
				}
				break;
			}
			return result;
		}
	}
}
