using System;
using System.IO;
using System.Text;
using IdSharp.Tagging.ID3v1;
using IdSharp.Tagging.ID3v2;

namespace IdSharp.Inspection
{
	internal sealed class MpegAudio
	{
		private const int MaxMpegFrameLength = 1729;

		private static readonly string[] MPEG_VERSION = new string[4] { "MPEG 2.5", "MPEG ?", "MPEG 2", "MPEG 1" };

		private static readonly string[] MPEG_LAYER = new string[4] { "Layer ?", "Layer III", "Layer II", "Layer I" };

		private static readonly ushort[][] MPEG_SAMPLE_RATE;

		private static readonly ushort[][][] BitrateTable;

		private long m_FileLength;

		private string m_VendorID;

		private VBRData m_VBR;

		private FrameData m_Frame;

		public string Version => MPEG_VERSION[(uint)m_Frame.VersionID];

		public string Layer => MPEG_LAYER[(uint)m_Frame.LayerID];

		public string Encoder
		{
			get
			{
				string text = "";
				string text2 = GetEncoderID().ToString();
				if (!string.IsNullOrEmpty(m_VBR.VendorID))
				{
					text = m_VBR.VendorID;
				}
				if (!string.IsNullOrEmpty(m_VendorID))
				{
					text = m_VendorID;
				}
				if (GetEncoderID() == MpegEncoder.LAME && text.Length >= 8 && char.IsDigit(text, 4) && text[5] == '.' && char.IsDigit(text, 6) && char.IsDigit(text, 7))
				{
					text2 = text2 + " " + text.Substring(4, 4);
				}
				return text2;
			}
		}

		public MpegAudio(string path)
		{
			ResetData();
			using (BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read)))
			{
				int tagSize = ID3v2Helper.GetTagSize(binaryReader.BaseStream);
				m_FileLength = binaryReader.BaseStream.Length;
				binaryReader.BaseStream.Seek(tagSize, SeekOrigin.Begin);
				byte[] array = binaryReader.ReadBytes(3458);
				FindFrame(array, ref m_VBR);
				m_VendorID = FindVendorID(array);
				if (!m_Frame.Found)
				{
					binaryReader.BaseStream.Seek((m_FileLength - tagSize) / 2, SeekOrigin.Begin);
					array = binaryReader.ReadBytes(3458);
					FindFrame(array, ref m_VBR);
				}
				if (m_Frame.Found && string.IsNullOrEmpty(m_VendorID))
				{
					binaryReader.BaseStream.Seek(-(array.Length + ID3v1Helper.GetTagSize(binaryReader.BaseStream)), SeekOrigin.End);
					array = binaryReader.ReadBytes(3458);
					FindFrame(array, ref m_VBR);
					m_VendorID = FindVendorID(array);
				}
			}
			if (!m_Frame.Found)
			{
				ResetData();
			}
		}

		private void ResetData()
		{
			m_FileLength = 0L;
			m_VendorID = "";
			m_Frame.VersionID = MpegVersion.Unknown;
			m_Frame.SampleRateID = SampleRateLevel.Unknown;
			m_Frame.ModeID = MpegChannel.Unknown;
			m_Frame.ModeExtensionID = JointStereoExtensionMode.Unknown;
			m_Frame.EmphasisID = Emphasis.Unknown;
		}

		private void FindFrame(byte[] data, ref VBRData vbrHeader)
		{
			byte[] array = new byte[4];
			Buffer.BlockCopy(data, 0, array, 0, 4);
			int num = data.Length - 4;
			for (int i = 0; i < num; i++)
			{
				if (IsFrameHeader(array))
				{
					DecodeHeader(array);
					int num2 = i + GetFrameLength(m_Frame);
					if (num2 < num && ValidFrameAt(num2, data))
					{
						m_Frame.Found = true;
						m_Frame.Position = i;
						m_Frame.Size = GetFrameLength(m_Frame);
						m_Frame.Xing = IsXing(i + array.Length, data);
						vbrHeader = FindVBR(i + GetVBRFrameOffset(m_Frame), data);
						break;
					}
				}
				array[0] = array[1];
				array[1] = array[2];
				array[2] = array[3];
				array[3] = data[4 + i];
			}
		}

		private bool IsFrameHeader(byte[] headerData)
		{
			if ((headerData[0] & 0xFF) != 255 || (headerData[1] & 0xE0) != 224 || ((headerData[1] >> 3) & 3) == 1 || ((headerData[1] >> 1) & 3) == 0 || (headerData[2] & 0xF0) == 240 || (headerData[2] & 0xF0) == 0 || ((headerData[2] >> 2) & 3) == 3 || (headerData[3] & 3) == 2)
			{
				return false;
			}
			return true;
		}

		private void DecodeHeader(byte[] headerData)
		{
			m_Frame.Data = new byte[headerData.Length];
			Buffer.BlockCopy(headerData, 0, m_Frame.Data, 0, headerData.Length);
			m_Frame.VersionID = (MpegVersion)((headerData[1] >> 3) & 3);
			m_Frame.LayerID = (MpegLayer)((headerData[1] >> 1) & 3);
			m_Frame.ProtectionBit = (headerData[1] & 1) != 1;
			m_Frame.BitRateID = (byte)(headerData[2] >> 4);
			m_Frame.SampleRateID = (SampleRateLevel)((headerData[2] >> 2) & 3);
			m_Frame.PaddingBit = ((headerData[2] >> 1) & 1) == 1;
			m_Frame.PrivateBit = (headerData[2] & 1) == 1;
			m_Frame.ModeID = (MpegChannel)((headerData[3] >> 6) & 3);
			m_Frame.ModeExtensionID = (JointStereoExtensionMode)((headerData[3] >> 4) & 3);
			m_Frame.CopyrightBit = ((headerData[3] >> 3) & 1) == 1;
			m_Frame.OriginalBit = ((headerData[3] >> 2) & 1) == 1;
			m_Frame.EmphasisID = (Emphasis)(headerData[3] & 3);
		}

		private bool ValidFrameAt(int index, byte[] data)
		{
			return IsFrameHeader(new byte[4]
			{
				data[index],
				data[index + 1],
				data[index + 2],
				data[index + 3]
			});
		}

		private ushort GetFrameLength(FrameData frame)
		{
			ushort coefficient = GetCoefficient(frame);
			ushort bitRate = GetBitRate(frame);
			ushort sampleRate = GetSampleRate(frame);
			ushort padding = GetPadding(frame);
			return (ushort)(coefficient * bitRate * 1000 / sampleRate + padding);
		}

		private bool IsXing(int index, byte[] data)
		{
			return data[index] == 0 && data[index + 1] == 0 && data[index + 2] == 0 && data[index + 3] == 0 && data[index + 4] == 0 && data[index + 5] == 0;
		}

		private VBRData FindVBR(int index, byte[] data)
		{
			string text = $"{(char)data[index]}{(char)data[index + 1]}{(char)data[index + 2]}{(char)data[index + 3]}";
			if (text == VBRHeaderID.Xing)
			{
				return GetXingInfo(index, data);
			}
			if (text == VBRHeaderID.FhG)
			{
				return GetFhGInfo(index, data);
			}
			return default(VBRData);
		}

		private byte GetVBRFrameOffset(FrameData Frame)
		{
			if (Frame.VersionID == MpegVersion.Version1)
			{
				if (Frame.ModeID != MpegChannel.Mono)
				{
					return 36;
				}
				return 21;
			}
			if (Frame.ModeID != MpegChannel.Mono)
			{
				return 21;
			}
			return 13;
		}

		private byte GetCoefficient(FrameData Frame)
		{
			if (Frame.VersionID == MpegVersion.Version1)
			{
				if (Frame.LayerID == MpegLayer.LayerI)
				{
					return 48;
				}
				return 144;
			}
			if (Frame.LayerID == MpegLayer.LayerI)
			{
				return 24;
			}
			if (Frame.LayerID == MpegLayer.LayerII)
			{
				return 144;
			}
			return 72;
		}

		private ushort GetBitRate(FrameData Frame)
		{
			return BitrateTable[(uint)Frame.VersionID][(uint)(Frame.LayerID - 1)][Frame.BitRateID - 1];
		}

		private ushort GetSampleRate(FrameData Frame)
		{
			return MPEG_SAMPLE_RATE[(uint)Frame.VersionID][(uint)Frame.SampleRateID];
		}

		private byte GetPadding(FrameData Frame)
		{
			if (Frame.PaddingBit)
			{
				if (Frame.LayerID == MpegLayer.LayerI)
				{
					return 4;
				}
				return 1;
			}
			return 0;
		}

		private VBRData GetXingInfo(int index, byte[] data)
		{
			VBRData result = default(VBRData);
			result.Found = true;
			result.ID = Encoding.ASCII.GetBytes(VBRHeaderID.Xing);
			result.Frames = data[index + 8] * 16777216 + data[index + 9] * 65536 + data[index + 10] * 256 + data[index + 11];
			result.Bytes = data[index + 12] * 16777216 + data[index + 13] * 65536 + data[index + 14] * 256 + data[index + 15];
			result.Scale = data[index + 119];
			result.VendorID = $"{(char)data[index + 120]}{(char)data[index + 121]}{(char)data[index + 122]}{(char)data[index + 123]}{(char)data[index + 124]}{(char)data[index + 125]}{(char)data[index + 126]}{(char)data[index + 127]}";
			return result;
		}

		private VBRData GetFhGInfo(int index, byte[] data)
		{
			return new VBRData
			{
				Found = true,
				ID = Encoding.ASCII.GetBytes(VBRHeaderID.FhG),
				Scale = data[index + 9],
				Bytes = data[index + 10] * 16777216 + data[index + 11] * 65536 + data[index + 12] * 256 + data[index + 13],
				Frames = data[index + 14] * 16777216 + data[index + 15] * 65536 + data[index + 16] * 256 + data[index + 17]
			};
		}

		private string FindVendorID(byte[] data)
		{
			string result = "";
			int num = data.Length;
			for (int i = 0; i <= num - 8; i++)
			{
				string text = $"{(char)data[num - i - 8]}{(char)data[num - i - 7]}{(char)data[num - i - 6]}{(char)data[num - i - 5]}";
				if (text == VBRVendorID.LAME)
				{
					result = text + $"{(char)data[num - i - 4]}{(char)data[num - i - 3]}{(char)data[num - i - 2]}{(char)data[num - i - 1]}";
					break;
				}
				if (text == VBRVendorID.GoGoNew)
				{
					result = text;
					break;
				}
			}
			return result;
		}

		private MpegEncoder GetEncoderID()
		{
			MpegEncoder result = MpegEncoder.Unknown;
			if (m_Frame.Found)
			{
				result = ((!m_VBR.Found) ? GetCBREncoderID() : GetVBREncoderID());
			}
			return result;
		}

		private MpegEncoder GetVBREncoderID()
		{
			MpegEncoder result = MpegEncoder.Unknown;
			string text = m_VBR.VendorID.Substring(0, 4);
			if (text == VBRVendorID.LAME)
			{
				result = MpegEncoder.LAME;
			}
			if (text == VBRVendorID.GoGoNew)
			{
				result = MpegEncoder.GoGo;
			}
			if (text == VBRVendorID.GoGoOld)
			{
				result = MpegEncoder.GoGo;
			}
			if (Encoding.ASCII.GetString(m_VBR.ID) == VBRHeaderID.Xing && text != VBRVendorID.LAME && text != VBRVendorID.GoGoNew && text != VBRVendorID.GoGoOld)
			{
				result = MpegEncoder.Xing;
			}
			if (Encoding.ASCII.GetString(m_VBR.ID) == VBRHeaderID.FhG)
			{
				result = MpegEncoder.FhG;
			}
			if (text == VBRVendorID.LAME)
			{
				result = MpegEncoder.LAME;
			}
			return result;
		}

		private MpegEncoder GetCBREncoderID()
		{
			MpegEncoder result = MpegEncoder.FhG;
			string text = ((string.IsNullOrEmpty(m_VendorID) || m_VendorID.Length < 4) ? "" : m_VendorID.Substring(0, 4));
			if (m_Frame.OriginalBit && m_Frame.ProtectionBit)
			{
				result = MpegEncoder.LAME;
			}
			if (GetBitRate(m_Frame) <= 160 && m_Frame.ModeID == MpegChannel.Stereo)
			{
				result = MpegEncoder.Blade;
			}
			if (m_Frame.CopyrightBit && m_Frame.OriginalBit && !m_Frame.ProtectionBit)
			{
				result = MpegEncoder.Xing;
			}
			if (m_Frame.Xing && m_Frame.OriginalBit)
			{
				result = MpegEncoder.Xing;
			}
			if (m_Frame.LayerID == MpegLayer.LayerII)
			{
				result = MpegEncoder.QDesign;
			}
			if (m_Frame.ModeID == MpegChannel.DualChannel && m_Frame.ProtectionBit)
			{
				result = MpegEncoder.Shine;
			}
			if (text == VBRVendorID.LAME)
			{
				result = MpegEncoder.LAME;
			}
			if (text == VBRVendorID.GoGoNew)
			{
				result = MpegEncoder.GoGo;
			}
			return result;
		}

		static MpegAudio()
		{
			ushort[][] array = new ushort[4][]
			{
				new ushort[4] { 11025, 12000, 8000, 0 },
				null,
				null,
				null
			};
			ushort[] array2 = new ushort[4];
			array[1] = array2;
			array[2] = new ushort[4] { 22050, 24000, 16000, 0 };
			array[3] = new ushort[4] { 44100, 48000, 32000, 0 };
			MPEG_SAMPLE_RATE = array;
			ushort[][][] array3 = new ushort[4][][]
			{
				new ushort[3][]
				{
					new ushort[14]
					{
						8, 16, 24, 32, 40, 48, 56, 64, 80, 96,
						112, 128, 144, 160
					},
					new ushort[14]
					{
						8, 16, 24, 32, 40, 48, 56, 64, 80, 96,
						112, 128, 144, 160
					},
					new ushort[14]
					{
						32, 48, 56, 64, 80, 96, 112, 128, 144, 160,
						176, 192, 224, 256
					}
				},
				null,
				null,
				null
			};
			ushort[][] array4 = new ushort[3][];
			ushort[] array5 = new ushort[14];
			array4[0] = array5;
			ushort[] array6 = new ushort[14];
			array4[1] = array6;
			ushort[] array7 = new ushort[14];
			array4[2] = array7;
			array3[1] = array4;
			array3[2] = new ushort[3][]
			{
				new ushort[14]
				{
					8, 16, 24, 32, 40, 48, 56, 64, 80, 96,
					112, 128, 144, 160
				},
				new ushort[14]
				{
					8, 16, 24, 32, 40, 48, 56, 64, 80, 96,
					112, 128, 144, 160
				},
				new ushort[14]
				{
					32, 48, 56, 64, 80, 96, 112, 128, 144, 160,
					176, 192, 224, 256
				}
			};
			array3[3] = new ushort[3][]
			{
				new ushort[14]
				{
					32, 40, 48, 56, 64, 80, 96, 112, 128, 160,
					192, 224, 256, 320
				},
				new ushort[14]
				{
					32, 48, 56, 64, 80, 96, 112, 128, 160, 192,
					224, 256, 320, 384
				},
				new ushort[14]
				{
					32, 64, 96, 128, 160, 192, 224, 256, 288, 320,
					352, 384, 416, 448
				}
			};
			BitrateTable = array3;
		}
	}
}
