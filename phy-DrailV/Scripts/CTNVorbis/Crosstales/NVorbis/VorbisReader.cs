using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Crosstales.NVorbis.Ogg;

namespace Crosstales.NVorbis
{
	public class VorbisReader : IDisposable
	{
		private int _streamIdx;

		private IContainerReader _containerReader;

		private List<VorbisStreamDecoder> _decoders;

		private VorbisStreamDecoder ActiveDecoder
		{
			get
			{
				if (_decoders == null)
				{
					throw new ObjectDisposedException("VorbisReader");
				}
				return _decoders[_streamIdx];
			}
		}

		public int Channels => ActiveDecoder._channels;

		public int SampleRate => ActiveDecoder._sampleRate;

		public int UpperBitrate => ActiveDecoder._upperBitrate;

		public int NominalBitrate => ActiveDecoder._nominalBitrate;

		public int LowerBitrate => ActiveDecoder._lowerBitrate;

		public string Vendor => ActiveDecoder._vendor;

		public string[] Comments => ActiveDecoder._comments;

		public bool IsParameterChange => ActiveDecoder.IsParameterChange;

		public long ContainerOverheadBits => ActiveDecoder.ContainerBits;

		public bool ClipSamples { get; set; }

		public IVorbisStreamStatus[] Stats => _decoders.Select((VorbisStreamDecoder d) => d).Cast<IVorbisStreamStatus>().ToArray();

		public int StreamIndex => _streamIdx;

		public int StreamCount => _decoders.Count;

		public TimeSpan DecodedTime
		{
			get
			{
				return TimeSpan.FromSeconds((double)ActiveDecoder.CurrentPosition / (double)SampleRate);
			}
			set
			{
				ActiveDecoder.SeekTo((long)(value.TotalSeconds * (double)SampleRate));
			}
		}

		public long DecodedPosition
		{
			get
			{
				return ActiveDecoder.CurrentPosition;
			}
			set
			{
				ActiveDecoder.SeekTo(value);
			}
		}

		public TimeSpan TotalTime
		{
			get
			{
				VorbisStreamDecoder activeDecoder = ActiveDecoder;
				if (activeDecoder.CanSeek)
				{
					return TimeSpan.FromSeconds((double)activeDecoder.GetLastGranulePos() / (double)activeDecoder._sampleRate);
				}
				return TimeSpan.MaxValue;
			}
		}

		public long TotalSamples
		{
			get
			{
				VorbisStreamDecoder activeDecoder = ActiveDecoder;
				if (activeDecoder.CanSeek)
				{
					return activeDecoder.GetLastGranulePos();
				}
				return long.MaxValue;
			}
		}

		private VorbisReader()
		{
			ClipSamples = false;
			_decoders = new List<VorbisStreamDecoder>();
		}

		public VorbisReader(string fileName)
			: this(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read), closeStreamOnDispose: true)
		{
		}

		public VorbisReader(Stream stream, bool closeStreamOnDispose)
			: this()
		{
			ContainerReader containerReader = new ContainerReader(stream, closeStreamOnDispose);
			if (!LoadContainer(containerReader))
			{
				stream.Close();
				throw new InvalidDataException("Could not determine container type!");
			}
			_containerReader = containerReader;
			if (_decoders.Count == 0)
			{
				throw new InvalidDataException("No Vorbis data found!");
			}
		}

		public VorbisReader(IContainerReader containerReader)
			: this()
		{
			if (!LoadContainer(containerReader))
			{
				throw new InvalidDataException("Container did not initialize!");
			}
			_containerReader = containerReader;
			if (_decoders.Count == 0)
			{
				throw new InvalidDataException("No Vorbis data found!");
			}
		}

		public VorbisReader(IPacketProvider packetProvider)
			: this()
		{
			NewStreamEventArgs e = new NewStreamEventArgs(packetProvider);
			NewStream(this, e);
			if (e.IgnoreStream)
			{
				throw new InvalidDataException("No Vorbis data found!");
			}
		}

		private bool LoadContainer(IContainerReader containerReader)
		{
			containerReader.NewStream += NewStream;
			if (!containerReader.Init())
			{
				containerReader.NewStream -= NewStream;
				return false;
			}
			return true;
		}

		private void NewStream(object sender, NewStreamEventArgs ea)
		{
			VorbisStreamDecoder vorbisStreamDecoder = new VorbisStreamDecoder(ea.PacketProvider);
			if (vorbisStreamDecoder.TryInit())
			{
				_decoders.Add(vorbisStreamDecoder);
			}
			else
			{
				ea.IgnoreStream = true;
			}
		}

		public void Dispose()
		{
			if (_decoders != null)
			{
				foreach (VorbisStreamDecoder decoder in _decoders)
				{
					decoder.Dispose();
				}
				_decoders.Clear();
				_decoders = null;
			}
			if (_containerReader != null)
			{
				_containerReader.NewStream -= NewStream;
				_containerReader.Dispose();
				_containerReader = null;
			}
		}

		public int ReadSamples(float[] buffer, int offset, int count)
		{
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			if (count < 0 || offset + count > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			int num = ActiveDecoder.ReadSamples(buffer, offset, count);
			if (ClipSamples)
			{
				VorbisStreamDecoder vorbisStreamDecoder = _decoders[_streamIdx];
				int num2 = 0;
				while (num2 < num)
				{
					buffer[offset] = Utils.ClipValue(buffer[offset], ref vorbisStreamDecoder._clipped);
					num2++;
					offset++;
				}
			}
			return num;
		}

		public void ClearParameterChange()
		{
			ActiveDecoder.IsParameterChange = false;
		}

		public bool FindNextStream()
		{
			if (_containerReader == null)
			{
				return false;
			}
			return _containerReader.FindNextStream();
		}

		public bool SwitchStreams(int index)
		{
			if (index < 0 || index >= StreamCount)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_decoders == null)
			{
				throw new ObjectDisposedException("VorbisReader");
			}
			if (_streamIdx == index)
			{
				return false;
			}
			VorbisStreamDecoder vorbisStreamDecoder = _decoders[_streamIdx];
			_streamIdx = index;
			VorbisStreamDecoder vorbisStreamDecoder2 = _decoders[_streamIdx];
			if (vorbisStreamDecoder._channels == vorbisStreamDecoder2._channels)
			{
				return vorbisStreamDecoder._sampleRate != vorbisStreamDecoder2._sampleRate;
			}
			return true;
		}
	}
}
