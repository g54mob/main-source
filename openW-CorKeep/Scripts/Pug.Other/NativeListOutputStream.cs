using System;
using System.IO;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

public class NativeListOutputStream : Stream
{
	private NativeList<byte> _list;

	private float _resizeFactor;

	private int _bytesWritten;

	public override bool CanRead => false;

	public override bool CanSeek => false;

	public override bool CanWrite => true;

	public override long Length => 0L;

	public override long Position
	{
		get
		{
			return 0L;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public NativeListOutputStream(NativeList<byte> list, float resizeFactor = 2f)
	{
		_list = list;
		_resizeFactor = resizeFactor;
		_bytesWritten = 0;
	}

	protected override void Dispose(bool disposing)
	{
		Flush();
	}

	public override void Flush()
	{
		_list.ResizeUninitialized(_bytesWritten);
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new NotSupportedException();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException();
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException();
	}

	public unsafe override void Write(byte[] buffer, int offset, int count)
	{
		if (_bytesWritten + count > _list.Capacity)
		{
			int num;
			for (num = math.max(_list.Capacity, 1); num < _bytesWritten + count; num = (int)math.ceil((float)num * _resizeFactor))
			{
			}
			_list.ResizeUninitialized(num);
		}
		fixed (byte* ptr = buffer)
		{
			UnsafeUtility.MemCpy(_list.GetUnsafePtr() + _bytesWritten, ptr + offset, count);
		}
		_bytesWritten += count;
	}
}
