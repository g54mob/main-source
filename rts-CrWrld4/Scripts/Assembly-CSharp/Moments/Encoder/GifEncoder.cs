using System.IO;

namespace Moments.Encoder
{
	public class GifEncoder
	{
		protected int m_Width;

		protected int m_Height;

		protected int m_Repeat;

		protected int m_FrameDelay;

		protected bool m_HasStarted;

		protected FileStream m_FileStream;

		protected GifFrame m_CurrentFrame;

		protected byte[] m_Pixels;

		protected byte[] m_IndexedPixels;

		protected int m_ColorDepth;

		protected byte[] m_ColorTab;

		protected bool[] m_UsedEntry;

		protected int m_PaletteSize;

		protected int m_DisposalCode;

		protected bool m_ShouldCloseStream;

		protected bool m_IsFirstFrame;

		protected bool m_IsSizeSet;

		protected int m_SampleInterval;

		public GifEncoder()
		{
		}

		public GifEncoder(int repeat, int quality)
		{
		}

		public void SetDelay(int ms)
		{
		}

		public void SetFrameRate(float fps)
		{
		}

		public void AddFrame(GifFrame frame)
		{
		}

		public void Start(FileStream os)
		{
		}

		public void Start(string file)
		{
		}

		public void Finish()
		{
		}

		protected void SetSize(int w, int h)
		{
		}

		protected void GetImagePixels()
		{
		}

		protected void AnalyzePixels()
		{
		}

		protected void WriteGraphicCtrlExt()
		{
		}

		protected void WriteImageDesc()
		{
		}

		protected void WriteLSD()
		{
		}

		protected void WriteNetscapeExt()
		{
		}

		protected void WritePalette()
		{
		}

		protected void WritePixels()
		{
		}

		protected void WriteShort(int value)
		{
		}

		protected void WriteString(string s)
		{
		}
	}
}
