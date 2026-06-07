using System;
using System.IO;

namespace UltimateReplay.Storage
{
	public sealed class ReplayFileStream : IDisposable
	{
		private Stream stream;

		private BinaryWriter writer;

		private BinaryReader reader;

		public bool IsReading => stream.CanRead;

		public bool IsWriting => stream.CanWrite;

		public BinaryWriter Writer
		{
			get
			{
				if (!IsWriting)
				{
					throw new InvalidOperationException("Failed to write to file stream. The stream is not writable in its current state");
				}
				return writer;
			}
		}

		public BinaryReader Reader
		{
			get
			{
				if (!IsReading)
				{
					throw new InvalidOperationException("Failed to read from file stream. The stream is not readable in its current state");
				}
				return reader;
			}
		}

		public int Position
		{
			get
			{
				DisposeCheck();
				return (int)stream.Position;
			}
		}

		public bool IsDisposed
		{
			get
			{
				try
				{
					DisposeCheck();
					return false;
				}
				catch (ObjectDisposedException)
				{
				}
				return true;
			}
		}

		public ReplayFileStream(string filepath, ReplayFileStreamMode mode, bool hiddenFile = false)
		{
			switch (mode)
			{
			case ReplayFileStreamMode.ReadOnly:
				stream = File.OpenRead(filepath);
				break;
			case ReplayFileStreamMode.WriteOnly:
				stream = File.OpenWrite(filepath);
				if (hiddenFile)
				{
					File.SetAttributes(filepath, File.GetAttributes(filepath) | FileAttributes.Hidden);
				}
				break;
			}
			if (IsReading)
			{
				reader = new BinaryReader(stream);
			}
			if (IsWriting)
			{
				writer = new BinaryWriter(stream);
			}
		}

		public void CopyTo(ReplayFileStream other)
		{
			DisposeCheck();
			if (!other.IsWriting)
			{
				throw new IOException("Expected writable stream. Target is not writable!");
			}
			byte[] array = new byte[4096];
			int num = 0;
			while ((num = stream.Read(array, 0, array.Length)) > 0)
			{
				other.stream.Write(array, 0, num);
			}
		}

		public void Write(byte[] bytes)
		{
			DisposeCheck();
			stream.Write(bytes, 0, bytes.Length);
		}

		public byte[] Read(int size)
		{
			DisposeCheck();
			byte[] array = new byte[size];
			int num = 0;
			while ((num += stream.Read(array, num, size)) < size)
			{
			}
			return array;
		}

		public void Seek(long offset, SeekOrigin origin)
		{
			DisposeCheck();
			stream.Seek(offset, origin);
		}

		public void Clear()
		{
			DisposeCheck();
			if (IsWriting)
			{
				stream.SetLength(0L);
			}
		}

		public void Dispose()
		{
			if (!IsDisposed)
			{
				if (IsReading)
				{
					reader.Close();
				}
				if (IsWriting)
				{
					writer.Close();
				}
				stream.Dispose();
				stream = null;
			}
		}

		private void DisposeCheck()
		{
			if (stream == null)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
		}
	}
}
