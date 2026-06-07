using System;
using System.IO;
using ThreeDISevenZeroR.UnityGifDecoder.Decode;
using ThreeDISevenZeroR.UnityGifDecoder.Model;
using UnityEngine;

namespace ThreeDISevenZeroR.UnityGifDecoder
{
	public class GifStream : IDisposable
	{
		public enum Token
		{
			Header = 0,
			Palette = 1,
			GraphicsControl = 2,
			ImageDescriptor = 3,
			Image = 4,
			Comment = 5,
			PlainText = 6,
			NetscapeExtension = 7,
			ApplicationExtension = 8,
			EndOfFile = 9
		}

		private Stream currentStream;

		private long headerStartPosition;

		private long firstFrameStartPosition;

		private GifHeader header;

		private GifGraphicControl graphicControl;

		private GifImageDescriptor imageDescriptor;

		private GifCanvas canvas;

		private GifLzwDictionary lzwDictionary;

		private GifBitBlockReader blockReader;

		private Color32[] globalColorTable;

		private Color32[] localColorTable;

		private readonly byte[] headerBuffer;

		private readonly byte[] colorTableBuffer;

		private readonly byte[] extensionApplicationBuffer;

		private bool nextPaletteIsGlobal;

		private const int ExtensionBlock = 33;

		private const int ImageDescriptorBlock = 44;

		private const int EndOfFile = 59;

		private const int PlainTextLabel = 1;

		private const int GraphicControlLabel = 249;

		private const int commentLabel = 254;

		private const int applicationExtensionLabel = 255;

		public bool FlipVertically
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DrawPlainTextBackground { get; set; }

		public GifHeader Header => default(GifHeader);

		public bool HasMoreData => false;

		public Token CurrentToken { get; private set; }

		public Stream BaseStream
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GifStream()
		{
		}

		public GifStream(Stream stream)
		{
		}

		public GifStream(byte[] gifBytes)
		{
		}

		public GifStream(string path)
		{
		}

		public void SetStream(Stream stream, bool disposePrevious = false)
		{
		}

		public void Dispose()
		{
		}

		public void SkipToken()
		{
		}

		public void Reset(bool skipHeader = true, bool resetCanvas = true)
		{
		}

		public GifHeader ReadHeader()
		{
			return default(GifHeader);
		}

		public GifPalette ReadPalette()
		{
			return default(GifPalette);
		}

		public GifGraphicControl ReadGraphicsControl()
		{
			return default(GifGraphicControl);
		}

		public GifImageDescriptor ReadImageDescriptor()
		{
			return default(GifImageDescriptor);
		}

		public GifImage ReadImage()
		{
			return null;
		}

		public string ReadComment()
		{
			return null;
		}

		public void SkipComment()
		{
		}

		public GifPlainText ReadPlainText()
		{
			return default(GifPlainText);
		}

		public void SkipPlainText()
		{
		}

		public GifNetscapeExtension ReadNetscapeExtension()
		{
			return default(GifNetscapeExtension);
		}

		public void SkipNetscapeExtension()
		{
		}

		public GifApplicationExtension ReadApplicationExtension()
		{
			return null;
		}

		public void SkipApplicationExtension()
		{
		}

		private void DecodeLzwImageToCanvas(int lzwMinCodeSize, int x, int y, int width, int height, Color32[] colorTable, int transparentColorIndex, bool isInterlaced, GifDisposalMethod disposalMethod)
		{
		}

		private Token DetermineNextToken()
		{
			return default(Token);
		}

		private Token SetCurrentToken(Token token)
		{
			return default(Token);
		}

		private void FillPlainTextBackground(GifPlainText text)
		{
		}

		private void AssertToken(Token token)
		{
		}

		private void SkipBlock(Token token)
		{
		}
	}
}
