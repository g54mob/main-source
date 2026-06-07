using System;
using System.IO;
using System.Text;

namespace Crosstales.NAudio.Midi
{
	public class MetaEvent : MidiEvent
	{
		private MetaEventType metaEvent;

		internal int metaDataLength;

		private byte[] data;

		public MetaEventType MetaEventType => metaEvent;

		protected MetaEvent()
		{
		}

		public MetaEvent(MetaEventType metaEventType, int metaDataLength, long absoluteTime)
			: base(absoluteTime, 1, MidiCommandCode.MetaEvent)
		{
			metaEvent = metaEventType;
			this.metaDataLength = metaDataLength;
		}

		public static MetaEvent ReadMetaEvent(BinaryReader br)
		{
			MetaEventType metaEventType = (MetaEventType)br.ReadByte();
			int num = MidiEvent.ReadVarInt(br);
			MetaEvent metaEvent = new MetaEvent();
			if (metaEventType <= MetaEventType.SetTempo)
			{
				if (metaEventType <= MetaEventType.DeviceName)
				{
					if (metaEventType != MetaEventType.TrackSequenceNumber)
					{
						if (metaEventType - 1 > MetaEventType.ProgramName)
						{
							goto IL_00a6;
						}
						metaEvent = new TextEvent(br, num);
					}
					else
					{
						metaEvent = new TrackSequenceNumberEvent(br, num);
					}
				}
				else if (metaEventType != MetaEventType.EndTrack)
				{
					if (metaEventType != MetaEventType.SetTempo)
					{
						goto IL_00a6;
					}
					metaEvent = new TempoEvent(br, num);
				}
				else if (num != 0)
				{
					throw new FormatException("End track length");
				}
			}
			else if (metaEventType <= MetaEventType.TimeSignature)
			{
				if (metaEventType != MetaEventType.SmpteOffset)
				{
					if (metaEventType != MetaEventType.TimeSignature)
					{
						goto IL_00a6;
					}
					metaEvent = new TimeSignatureEvent(br, num);
				}
				else
				{
					metaEvent = new SmpteOffsetEvent(br, num);
				}
			}
			else if (metaEventType != MetaEventType.KeySignature)
			{
				if (metaEventType != MetaEventType.SequencerSpecific)
				{
					goto IL_00a6;
				}
				metaEvent = new SequencerSpecificEvent(br, num);
			}
			else
			{
				metaEvent = new KeySignatureEvent(br, num);
			}
			goto IL_00c9;
			IL_00c9:
			metaEvent.metaEvent = metaEventType;
			metaEvent.metaDataLength = num;
			return metaEvent;
			IL_00a6:
			metaEvent.data = br.ReadBytes(num);
			if (metaEvent.data.Length != num)
			{
				throw new FormatException("Failed to read metaevent's data fully");
			}
			goto IL_00c9;
		}

		public override string ToString()
		{
			if (data == null)
			{
				return $"{base.AbsoluteTime} {metaEvent}";
			}
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array = data;
			foreach (byte b in array)
			{
				stringBuilder.AppendFormat("{0:X2} ", b);
			}
			return $"{base.AbsoluteTime} {metaEvent}\r\n{stringBuilder.ToString()}";
		}

		public override void Export(ref long absoluteTime, BinaryWriter writer)
		{
			base.Export(ref absoluteTime, writer);
			writer.Write((byte)metaEvent);
			MidiEvent.WriteVarInt(writer, metaDataLength);
			if (data != null)
			{
				writer.Write(data, 0, data.Length);
			}
		}
	}
}
