using System.IO;

namespace NAudio.Midi
{
	public class MetaEvent : MidiEvent
	{
		private MetaEventType metaEvent;

		internal int metaDataLength;

		public MetaEventType MetaEventType => default(MetaEventType);

		protected MetaEvent()
		{
		}

		public MetaEvent(MetaEventType metaEventType, int metaDataLength, long absoluteTime)
		{
		}

		public override MidiEvent Clone()
		{
			return null;
		}

		public static MetaEvent ReadMetaEvent(BinaryReader br)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public override void Export(ref long absoluteTime, BinaryWriter writer)
		{
		}
	}
}
