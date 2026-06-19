using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using IdSharp.Tagging.ID3v2;

namespace IdSharp.Inspection
{
	internal sealed class BasicLameTagReader
	{
		private const byte Info1Offset = 13;

		private const byte Info2Offset = 21;

		private const byte Info3Offset = 36;

		private const byte LAMETagOffset = 119;

		private LameTag m_Tag;

		private LamePreset m_PresetGuess;

		private bool m_IsPresetGuessNonBitrate;

		private bool m_IsLameTagFound;

		private ushort m_Preset;

		private string m_VersionString;

		private string m_VersionStringNonLameTag;

		public string VersionString => m_VersionString;

		public string VersionStringNonLameTag => m_VersionStringNonLameTag;

		public byte EncodingMethod => m_Tag.TagRevision_EncodingMethod;

		public ushort Preset => m_Preset;

		public LamePreset PresetGuess => m_PresetGuess;

		public byte Bitrate => m_Tag.Bitrate;

		public bool IsPresetGuessNonBitrate => m_IsPresetGuessNonBitrate;

		public bool IsLameTagFound => m_IsLameTagFound;

		public BasicLameTagReader(string path)
		{
			m_IsLameTagFound = true;
			m_Tag = default(LameTag);
			using (BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read)))
			{
				int tagSize = ID3v2Helper.GetTagSize(binaryReader.BaseStream);
				binaryReader.BaseStream.Seek(tagSize, SeekOrigin.Begin);
				StartOfFile startOfFile = StartOfFile.FromBinaryReader(binaryReader);
				binaryReader.BaseStream.Seek(tagSize, SeekOrigin.Begin);
				string text = Encoding.ASCII.GetString(startOfFile.Info1);
				string text2 = Encoding.ASCII.GetString(startOfFile.Info2);
				string text3 = Encoding.ASCII.GetString(startOfFile.Info3);
				if (text == "Xing" || text == "Info")
				{
					binaryReader.BaseStream.Seek(13L, SeekOrigin.Current);
				}
				else if (text2 == "Xing" || text2 == "Info")
				{
					binaryReader.BaseStream.Seek(21L, SeekOrigin.Current);
				}
				else if (text3 == "Xing" || text3 == "Info")
				{
					binaryReader.BaseStream.Seek(36L, SeekOrigin.Current);
				}
				else
				{
					m_IsLameTagFound = true;
				}
				binaryReader.BaseStream.Seek(119L, SeekOrigin.Current);
				m_Tag = LameTag.FromBinaryReader(binaryReader);
				binaryReader.BaseStream.Seek(-Marshal.SizeOf(typeof(LameTag)), SeekOrigin.Current);
				OldLameHeader oldLameHeader = OldLameHeader.FromBinaryReader(binaryReader);
				m_VersionStringNonLameTag = Encoding.ASCII.GetString(oldLameHeader.VersionString);
			}
			if (m_Tag.VersionString[1] == 46)
			{
				byte[] array = new byte[6];
				int i;
				for (i = 0; i < 4 || (i == 4 && m_Tag.VersionString[i] == 98); i++)
				{
					array[i] = m_Tag.VersionString[i];
				}
				Array.Resize(ref array, i);
				m_VersionString = Encoding.ASCII.GetString(array);
			}
			else
			{
				m_VersionString = "";
			}
			if (Encoding.ASCII.GetString(m_Tag.Encoder) != "LAME")
			{
				m_IsLameTagFound = false;
			}
			m_Preset = (ushort)(((m_Tag.Surround_Preset[0] << 8) + m_Tag.Surround_Preset[1]) & 0x7FF);
			m_PresetGuess = new PresetGuesser().GuessPreset(VersionStringNonLameTag, m_Tag.Bitrate, m_Tag.Quality, m_Tag.TagRevision_EncodingMethod, m_Tag.NoiseShaping, m_Tag.StereoMode, m_Tag.EncodingFlags_ATHType, m_Tag.Lowpass, out m_IsPresetGuessNonBitrate);
		}
	}
}
