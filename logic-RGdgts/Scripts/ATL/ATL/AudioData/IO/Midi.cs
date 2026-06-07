using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ATL.AudioData.IO
{
	internal class Midi : MetaDataIO, IAudioDataIO
	{
		private sealed class MidiEvent
		{
			public long TickOffset;

			public int Type;

			public bool isMetaEvent;

			public int Channel;

			public int Param0;

			public int Param1;

			public string Description;

			public MidiEvent(long tickOffset, int type, int channel, int param0, int param1 = 0)
			{
			}
		}

		private sealed class MidiTrack
		{
			public long Duration;

			public long Ticks;

			public long LastSignificantEventTicks;

			public MidiEvent LastEvent;

			public IList<MidiEvent> events;

			public void Add(MidiEvent evt)
			{
			}
		}

		private IList<MidiTrack> tracks;

		private int timebase;

		private long tempo;

		private byte type;

		private static readonly string[] instrumentList;

		private static readonly byte[] MIDI_FILE_HEADER;

		private StringBuilder comment;

		private double duration;

		private double bitrate;

		private AudioDataManager.SizeInfo sizeInfo;

		private readonly string filePath;

		public int SampleRate => 0;

		public bool IsVBR => false;

		public Format AudioFormat { get; }

		public int CodecFamily => 0;

		public string FileName => null;

		public double BitRate => 0.0;

		public int BitDepth => 0;

		public double Duration => 0.0;

		public ChannelsArrangements.ChannelsArrangement ChannelsArrangement => null;

		public long AudioDataOffset { get; set; }

		public long AudioDataSize { get; set; }

		public bool IsMetaSupported(MetaDataIOFactory.TagType metaDataType)
		{
			return false;
		}

		protected override MetaDataIOFactory.TagType getImplementedTagType()
		{
			return default(MetaDataIOFactory.TagType);
		}

		protected override TagData.Field getFrameMapping(string zone, string ID, byte tagVersion)
		{
			return default(TagData.Field);
		}

		protected void resetData()
		{
		}

		public Midi(string filePath, Format format)
		{
		}

		private double getDuration()
		{
			return 0.0;
		}

		public bool Read(Stream source, AudioDataManager.SizeInfo sizeInfo, ReadTagParams readTagParams)
		{
			return false;
		}

		public static bool IsValidHeader(byte[] data)
		{
			return false;
		}

		public static bool FindValidHeader(Stream source)
		{
			return false;
		}

		protected override bool read(Stream source, ReadTagParams readTagParams)
		{
			return false;
		}

		private MidiTrack parseTrack(byte[] data, int trackNumber)
		{
			return null;
		}

		private int readVarLen(ref byte[] data, ref int pos)
		{
			return 0;
		}
	}
}
