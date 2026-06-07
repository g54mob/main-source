using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Lachee.IO
{
	public class NamedPipeClientStream : Stream
	{
		private static class Native
		{
			private const string LIBRARY_NAME = "NativeNamedPipe";

			[PreserveSig]
			public static extern IntPtr CreateClient();

			[PreserveSig]
			public static extern void DestroyClient(IntPtr client);

			[PreserveSig]
			public static extern bool IsConnected(IntPtr client);

			[PreserveSig]
			public static extern int Open(IntPtr client, string pipename);

			[PreserveSig]
			public static extern void Close(IntPtr client);

			[PreserveSig]
			public static extern int ReadFrame(IntPtr client, IntPtr buffer, int length);

			[PreserveSig]
			public static extern int WriteFrame(IntPtr client, IntPtr buffer, int length);
		}

		private IntPtr ptr;

		private bool _isDisposed;

		private static readonly string s_pipePrefix;

		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length => 0L;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public bool IsConnected => false;

		public string PipeName { get; }

		public NamedPipeClientStream(string server, string pipeName)
		{
		}

		~NamedPipeClientStream()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private static string FormatPipe(string server, string pipeName)
		{
			return null;
		}

		public void Connect()
		{
		}

		public void Disconnect()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}

		public override void Flush()
		{
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}
	}
}
