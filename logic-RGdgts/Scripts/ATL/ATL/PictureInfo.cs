using System.IO;
using ATL.AudioData;
using Commons;

namespace ATL
{
	public class PictureInfo
	{
		public enum PIC_TYPE
		{
			Unsupported = 99,
			Generic = 1,
			Front = 2,
			Back = 3,
			CD = 4,
			Icon = 5,
			Leaflet = 6,
			LeadArtist = 7,
			Artist = 8,
			Conductor = 9,
			Band = 10,
			Composer = 11,
			Lyricist = 12,
			RecordingLocation = 13,
			DuringRecording = 14,
			DuringPerformance = 15,
			MovieCapture = 16,
			Fishie = 17,
			Illustration = 18,
			BandLogo = 19,
			PublisherLogo = 20
		}

		public PIC_TYPE PicType { get; set; }

		public ImageFormat NativeFormat { get; set; }

		public int Position { get; set; }

		public MetaDataIOFactory.TagType TagType { get; set; }

		public int NativePicCode { get; set; }

		public string NativePicCodeStr { get; set; }

		public string Description { get; set; }

		public byte[] PictureData { get; private set; }

		public uint PictureHash { get; set; }

		public bool MarkedForDeletion { get; set; }

		public int TransientFlag { get; set; }

		public static PictureInfo fromBinaryData(byte[] data, PIC_TYPE picType = PIC_TYPE.Generic, MetaDataIOFactory.TagType tagType = MetaDataIOFactory.TagType.ANY, object nativePicCode = null, int position = 1)
		{
			return null;
		}

		public static PictureInfo fromBinaryData(Stream stream, int length, PIC_TYPE picType, MetaDataIOFactory.TagType tagType, object nativePicCode, int position = 1)
		{
			return null;
		}

		public PictureInfo(PictureInfo picInfo, bool copyPictureData = true)
		{
		}

		private PictureInfo(PIC_TYPE picType, MetaDataIOFactory.TagType tagType, object nativePicCode, int position, byte[] binaryData)
		{
		}

		public PictureInfo(PIC_TYPE picType, int position = 1)
		{
		}

		public PictureInfo(MetaDataIOFactory.TagType tagType, object nativePicCode, int position = 1)
		{
		}

		public uint ComputePicHash()
		{
			return 0u;
		}

		public override string ToString()
		{
			return null;
		}

		private string valueToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}
	}
}
