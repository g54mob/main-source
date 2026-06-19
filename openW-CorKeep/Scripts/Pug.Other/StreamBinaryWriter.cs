using System;
using System.IO;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities.Serialization;
using Unity.Mathematics;
using UnityEngine;

public class StreamBinaryWriter : Unity.Entities.Serialization.BinaryWriter, IDisposable
{
	private static readonly byte[] WriteBuffer = new byte[1048576];

	private Stream _stream;

	private int _firstPositionToStream;

	private int _lastPositionToStream;

	private int _position;

	private int _lastStreamedPosition;

	public bool Failed { get; private set; }

	public long Position
	{
		get
		{
			return _position;
		}
		set
		{
			_position = (int)value;
		}
	}

	public StreamBinaryWriter(Stream stream, int firstPositionToStream = 0, int lastPositionToStream = int.MaxValue)
	{
		_stream = stream;
		_firstPositionToStream = firstPositionToStream;
		_lastPositionToStream = lastPositionToStream;
		_position = 0;
	}

	public void Dispose()
	{
	}

	public unsafe void WriteBytes(void* data, int bytes)
	{
		int i = math.max(_firstPositionToStream - _position, 0);
		int num = math.min(_lastPositionToStream - _position, bytes);
		if (i >= num)
		{
			_position += bytes;
			return;
		}
		if (_position < _lastStreamedPosition)
		{
			Debug.LogError($"Trying to stream data for position {_position + i}-{num}, but have already streamed data for position {_lastStreamedPosition}");
			Failed = true;
		}
		int num2;
		for (; i < num; i += num2)
		{
			num2 = math.min(WriteBuffer.Length, num - i);
			byte[] writeBuffer = WriteBuffer;
			fixed (byte* destination = writeBuffer)
			{
				UnsafeUtility.MemCpy(destination, (byte*)data + i, num2);
			}
			_stream.Write(writeBuffer, 0, num2);
		}
		_lastStreamedPosition = _position + num;
		_position += bytes;
	}
}
