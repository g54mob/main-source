using System;
using System.IO;
using System.Runtime.InteropServices;
using GifEncoder;
using UnityEngine;

namespace Gif.Components
{
	public class AnimatedGifEncoder
	{
		protected int _width;

		protected int _height;

		protected int _transIndex;

		protected int _repeat = -1;

		protected int _delay;

		protected bool _started;

		protected Stream _fs;

		protected Texture2D _image;

		protected int _colorDepth;

		protected int _palSize = 7;

		protected int _dispose = -1;

		protected bool _closeStream;

		protected bool _firstFrame = true;

		protected bool _sizeSet;

		protected int _sample = 10;

		protected static byte[] _indexedPixels = null;

		protected static byte[] _colorTab = new byte[765];

		private const int DefaultWidth = 320;

		private const int DefaultHeight = 240;

		public void SetDelay(int ms)
		{
			_delay = (int)Math.Round((float)ms / 10f);
		}

		public void SetDispose(int code)
		{
			if (code >= 0)
			{
				_dispose = code;
			}
		}

		public void SetRepeat(int repeat)
		{
			if (repeat >= 0)
			{
				_repeat = repeat;
			}
		}

		public bool AddFrame(Texture2D im)
		{
			if (im == null || !_started)
			{
				return false;
			}
			bool result = true;
			try
			{
				if (!_sizeSet)
				{
					SetSize(im.width, im.height);
				}
				_image = im;
				AnalyzePixels();
				if (_firstFrame)
				{
					WriteLSD();
					WritePalette();
					if (_repeat >= 0)
					{
						WriteNetscapeExt();
					}
				}
				WriteGraphicCtrlExt();
				WriteImageDesc();
				if (!_firstFrame)
				{
					WritePalette();
				}
				WritePixels();
				_firstFrame = false;
			}
			catch (IOException)
			{
				result = false;
			}
			return result;
		}

		public bool AddComment(byte[] comment)
		{
			if (!_started)
			{
				return false;
			}
			_fs.WriteByte(33);
			_fs.WriteByte(254);
			int num = comment.Length;
			int num2;
			for (int i = 0; i < num; i += num2)
			{
				num2 = num - i;
				num2 = ((num2 > 255) ? 255 : num2);
				_fs.WriteByte((byte)num2);
				_fs.Write(comment, i, num2);
			}
			_fs.WriteByte(0);
			return true;
		}

		public bool Finish()
		{
			if (!_started)
			{
				return false;
			}
			bool result = true;
			_started = false;
			try
			{
				_fs.WriteByte(59);
				_fs.Flush();
				if (_closeStream)
				{
					_fs.Close();
				}
			}
			catch (IOException)
			{
				result = false;
			}
			_transIndex = 0;
			_fs = null;
			_image = null;
			_closeStream = false;
			_firstFrame = true;
			FreeBuffer();
			return result;
		}

		public void SetFrameRate(float fps)
		{
			if (fps != 0f)
			{
				_delay = (int)Math.Round(100f / fps);
			}
		}

		public void SetQuality(int quality)
		{
			if (quality < 1)
			{
				quality = 1;
			}
			_sample = quality;
		}

		public void SetSize(int w, int h)
		{
			if ((!_started || _firstFrame) && Diagnostics.Verify(!_sizeSet, "The size is already set! Finish this gif and start another instead."))
			{
				_width = w;
				_height = h;
				if (_width < 1)
				{
					_width = 320;
				}
				if (_height < 1)
				{
					_height = 240;
				}
				_sizeSet = true;
				AllocateBuffer(_width, _height);
				_indexedPixels = new byte[_width * _height * 3];
			}
		}

		public bool Start(Stream os)
		{
			if (os == null)
			{
				return false;
			}
			bool started = true;
			_closeStream = false;
			_fs = os;
			try
			{
				WriteString("GIF89a");
			}
			catch (IOException)
			{
				started = false;
			}
			_started = started;
			return _started;
		}

		public bool Start(string file)
		{
			bool started;
			try
			{
				_fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
				started = Start(_fs);
				_closeStream = true;
			}
			catch (IOException)
			{
				started = false;
			}
			_started = started;
			return _started;
		}

		protected void AnalyzePixels()
		{
			Color32[] pixels = _image.GetPixels32();
			GCHandle gCHandle = GCHandle.Alloc(_indexedPixels, GCHandleType.Pinned);
			GCHandle gCHandle2 = GCHandle.Alloc(_colorTab, GCHandleType.Pinned);
			GCHandle gCHandle3 = GCHandle.Alloc(pixels, GCHandleType.Pinned);
			QuantizeImage(gCHandle.AddrOfPinnedObject(), gCHandle2.AddrOfPinnedObject(), gCHandle3.AddrOfPinnedObject(), _firstFrame);
			gCHandle.Free();
			gCHandle2.Free();
			gCHandle3.Free();
			_colorDepth = 8;
			_palSize = 7;
		}

		protected void WriteGraphicCtrlExt()
		{
			_fs.WriteByte(33);
			_fs.WriteByte(249);
			_fs.WriteByte(4);
			if (_firstFrame)
			{
				_fs.WriteByte(0);
			}
			else
			{
				_fs.WriteByte(5);
			}
			WriteShort(_delay);
			_fs.WriteByte(byte.MaxValue);
			_fs.WriteByte(0);
		}

		protected void WriteImageDesc()
		{
			_fs.WriteByte(44);
			WriteShort(0);
			WriteShort(0);
			WriteShort(_width);
			WriteShort(_height);
			if (_firstFrame)
			{
				_fs.WriteByte(0);
			}
			else
			{
				_fs.WriteByte(Convert.ToByte(0x80 | _palSize));
			}
		}

		protected void WriteLSD()
		{
			WriteShort(_width);
			WriteShort(_height);
			_fs.WriteByte(Convert.ToByte(0xF0 | _palSize));
			_fs.WriteByte(0);
			_fs.WriteByte(0);
		}

		protected void WriteNetscapeExt()
		{
			_fs.WriteByte(33);
			_fs.WriteByte(byte.MaxValue);
			_fs.WriteByte(11);
			WriteString("NETSCAPE2.0");
			_fs.WriteByte(3);
			_fs.WriteByte(1);
			WriteShort(_repeat);
			_fs.WriteByte(0);
		}

		protected void WritePalette()
		{
			_fs.Write(_colorTab, 0, _colorTab.Length);
			int num = 768 - _colorTab.Length;
			for (int i = 0; i < num; i++)
			{
				_fs.WriteByte(0);
			}
		}

		protected void WritePixels()
		{
			new LZWEncoder(_width, _height, _indexedPixels, _colorDepth).Encode(_fs);
		}

		protected void WriteShort(int value)
		{
			_fs.WriteByte(Convert.ToByte(value & 0xFF));
			_fs.WriteByte(Convert.ToByte((value >> 8) & 0xFF));
		}

		protected void WriteString(string s)
		{
			char[] array = s.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				_fs.WriteByte((byte)array[i]);
			}
		}

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
		private static extern void QuantizeImage(IntPtr indexedPixels, IntPtr colorMap, IntPtr pixels, bool isFirstImage);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
		private static extern void AllocateBuffer(int imageWidth, int imageHeight);

		[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
		private static extern void FreeBuffer();
	}
}
