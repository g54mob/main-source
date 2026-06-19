using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class AudioText : IAudioText, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private string m_MimeType;

		private string m_EquivalentText;

		private byte[] m_AudioData;

		private bool m_IsMpegOrAac;

		private static readonly byte[] m_ScrambleTable;

		public EncodingType TextEncoding
		{
			get
			{
				return m_TextEncoding;
			}
			set
			{
				m_TextEncoding = value;
				FirePropertyChanged("TextEncoding");
			}
		}

		public string MimeType
		{
			get
			{
				return m_MimeType;
			}
			set
			{
				m_MimeType = value;
				FirePropertyChanged("MimeType");
			}
		}

		public string EquivalentText
		{
			get
			{
				return m_EquivalentText;
			}
			set
			{
				m_EquivalentText = value;
				FirePropertyChanged("EquivalentText");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		static AudioText()
		{
			m_ScrambleTable = new byte[127];
			m_ScrambleTable[0] = 254;
			int num = 0;
			while (true)
			{
				byte b = NextByte(m_ScrambleTable[num]);
				if (b == 254)
				{
					break;
				}
				m_ScrambleTable[num + 1] = b;
				num++;
			}
		}

		public AudioText()
		{
			m_FrameHeader = new FrameHeader();
		}

		public void SetAudioData(string mimeType, byte[] audioData, bool isMpegOrAac)
		{
			MimeType = mimeType;
			m_IsMpegOrAac = isMpegOrAac;
			if (audioData == null)
			{
				m_AudioData = null;
			}
			else if (m_IsMpegOrAac)
			{
				m_AudioData = Utils.ConvertToUnsynchronized(m_AudioData);
			}
			else
			{
				m_AudioData = Scramble(m_AudioData);
			}
			FirePropertyChanged("AudioData");
		}

		public byte[] GetAudioData(AudioScramblingMode audioScramblingMode)
		{
			if (audioScramblingMode == AudioScramblingMode.Default)
			{
				audioScramblingMode = (m_IsMpegOrAac ? AudioScramblingMode.Unsynchronization : AudioScramblingMode.Scrambling);
			}
			switch (audioScramblingMode)
			{
			case AudioScramblingMode.Scrambling:
				return Scramble(m_AudioData);
			case AudioScramblingMode.Unsynchronization:
				return Utils.ReadUnsynchronized(m_AudioData);
			default:
				if (m_AudioData == null)
				{
					return null;
				}
				return (byte[])m_AudioData.Clone();
			}
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "ATXT";
			case ID3v2TagVersion.ID3v22:
				return null;
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
			if (bytesLeft > 0)
			{
				TextEncoding = (EncodingType)Utils.ReadByte(stream, ref bytesLeft);
				if (bytesLeft > 0)
				{
					MimeType = Utils.ReadString(EncodingType.ISO88591, stream, ref bytesLeft);
					if (bytesLeft > 1)
					{
						byte b = Utils.ReadByte(stream, ref bytesLeft);
						m_IsMpegOrAac = (b & 1) == 0;
						EquivalentText = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
						if (bytesLeft > 0)
						{
							m_AudioData = Utils.Read(stream, bytesLeft);
							bytesLeft = 0;
						}
					}
					else
					{
						EquivalentText = null;
						m_AudioData = null;
					}
				}
				else
				{
					MimeType = null;
					EquivalentText = null;
					m_AudioData = null;
				}
			}
			else
			{
				TextEncoding = EncodingType.ISO88591;
				MimeType = null;
				EquivalentText = null;
				m_AudioData = null;
			}
			if (bytesLeft > 0)
			{
				stream.Seek(bytesLeft, SeekOrigin.Current);
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (m_AudioData == null || m_AudioData.Length == 0)
			{
				return new byte[0];
			}
			string frameID = GetFrameID(tagVersion);
			if (frameID == null)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			byte[] stringBytes = Utils.GetStringBytes(tagVersion, EncodingType.ISO88591, MimeType, isTerminated: true);
			byte[] stringBytes2 = Utils.GetStringBytes(tagVersion, TextEncoding, EquivalentText, isTerminated: true);
			memoryStream.Write(stringBytes, 0, stringBytes.Length);
			memoryStream.WriteByte((!m_IsMpegOrAac) ? ((byte)1) : ((byte)0));
			memoryStream.Write(stringBytes2, 0, stringBytes2.Length);
			memoryStream.Write(m_AudioData, 0, m_AudioData.Length);
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, frameID);
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private static byte[] Scramble(byte[] audioData)
		{
			byte[] array = new byte[audioData.Length];
			int num = 0;
			int num2 = 0;
			while (num < audioData.Length)
			{
				array[num] = (byte)(audioData[num] ^ m_ScrambleTable[num2]);
				if (num2 == 126)
				{
					num2 = -1;
				}
				num++;
				num2++;
			}
			return array;
		}

		private static byte NextByte(byte n)
		{
			byte b = (byte)((n >> 7) & 1);
			byte b2 = (byte)((n >> 6) & 1);
			byte b3 = (byte)((n >> 5) & 1);
			byte b4 = (byte)((n >> 4) & 1);
			byte b5 = (byte)((n >> 3) & 1);
			byte b6 = (byte)((n >> 2) & 1);
			byte b7 = (byte)((n >> 1) & 1);
			byte b8 = (byte)(n & 1);
			return (byte)(((b2 ^ b3) << 7) + ((b3 ^ b4) << 6) + ((b4 ^ b5) << 5) + ((b5 ^ b6) << 4) + ((b6 ^ b7) << 3) + ((b7 ^ b8) << 2) + ((b ^ b3) << 1) + (b2 ^ b4));
		}
	}
}
