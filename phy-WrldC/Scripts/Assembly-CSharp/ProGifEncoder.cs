using System;
using System.IO;
using UnityEngine;

internal class ProGifEncoder
{
	protected int m_Width;

	protected int m_Height;

	protected int m_Repeat = -1;

	protected int m_FrameDelay;

	protected bool m_HasStarted;

	protected FileStream m_FileStream;

	protected Frame m_CurrentFrame;

	protected byte[] m_Pixels;

	protected byte[] m_PixelsAlpha;

	protected byte[] m_IndexedPixels;

	protected int m_ColorDepth;

	protected byte[] m_ColorTab;

	protected bool[] m_UsedEntry = new bool[256];

	protected int m_PaletteSize = 7;

	protected int m_DisposalCode = -1;

	protected bool m_ShouldCloseStream;

	protected bool m_IsFirstFrame = true;

	protected bool m_IsSizeSet;

	protected int m_SampleInterval = 10;

	protected int m_TransparentColorIndex;

	protected int m_TransparentFlag;

	protected Color32 m_TransparentColor;

	public bool m_AutoTransparent;

	protected bool m_HasTransparentPixel;

	public ProGifEncoder()
		: this(-1, 10)
	{
	}

	public ProGifEncoder(int repeat, int quality)
	{
		if (repeat >= 0)
		{
			m_Repeat = repeat;
		}
		m_SampleInterval = Mathf.Clamp(quality, 1, 100);
	}

	public void SetDelay(int ms)
	{
		m_FrameDelay = Mathf.RoundToInt((float)ms / 10f);
	}

	public void SetFrameRate(float fps)
	{
		if (fps > 0f)
		{
			m_FrameDelay = Mathf.RoundToInt(100f / fps);
		}
	}

	public void AddFrame(Frame frame)
	{
		if (frame == null)
		{
			throw new ArgumentNullException("Can't add a null frame to the gif.");
		}
		if (!m_HasStarted)
		{
			throw new InvalidOperationException("Call Start() before adding frames to the gif.");
		}
		if (!m_IsSizeSet)
		{
			SetSize(frame.Width, frame.Height);
		}
		m_AutoTransparent = true;
		m_CurrentFrame = frame;
		GetImagePixels();
		AnalyzePixels();
		if (m_IsFirstFrame)
		{
			WriteLSD();
			WritePalette();
			if (m_Repeat >= 0)
			{
				WriteNetscapeExt();
			}
		}
		WriteGraphicCtrlExt();
		WriteImageDesc();
		if (!m_IsFirstFrame)
		{
			WritePalette();
		}
		WritePixels();
		m_IsFirstFrame = false;
	}

	public void Start(FileStream os)
	{
		if (os == null)
		{
			throw new ArgumentNullException("Stream is null.");
		}
		m_ShouldCloseStream = false;
		m_FileStream = os;
		try
		{
			WriteString("GIF89a");
		}
		catch (IOException ex)
		{
			throw ex;
		}
		m_HasStarted = true;
	}

	public void Start(string file)
	{
		try
		{
			m_FileStream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
			Start(m_FileStream);
			m_ShouldCloseStream = true;
		}
		catch (IOException ex)
		{
			throw ex;
		}
	}

	public void Finish()
	{
		if (!m_HasStarted)
		{
			throw new InvalidOperationException("Can't finish a non-started gif.");
		}
		m_HasStarted = false;
		try
		{
			m_FileStream.WriteByte(59);
			m_FileStream.Flush();
			if (m_ShouldCloseStream)
			{
				m_FileStream.Close();
			}
		}
		catch (IOException ex)
		{
			throw ex;
		}
		m_FileStream = null;
		m_CurrentFrame = null;
		m_Pixels = null;
		m_PixelsAlpha = null;
		m_IndexedPixels = null;
		m_ColorTab = null;
		m_ShouldCloseStream = false;
		m_IsFirstFrame = true;
	}

	protected void SetSize(int w, int h)
	{
		m_Width = w;
		m_Height = h;
		m_IsSizeSet = true;
	}

	protected void GetImagePixels()
	{
		m_Pixels = new byte[3 * m_CurrentFrame.Width * m_CurrentFrame.Height];
		Color32[] data = m_CurrentFrame.Data;
		int num = 0;
		int num2 = 0;
		if (m_AutoTransparent)
		{
			m_PixelsAlpha = new byte[m_CurrentFrame.Width * m_CurrentFrame.Height];
			for (int num3 = m_CurrentFrame.Height - 1; num3 >= 0; num3--)
			{
				for (int i = 0; i < m_CurrentFrame.Width; i++)
				{
					Color32 color = data[num3 * m_CurrentFrame.Width + i];
					m_Pixels[num] = color.r;
					num++;
					m_Pixels[num] = color.g;
					num++;
					m_Pixels[num] = color.b;
					num++;
					m_PixelsAlpha[num2] = color.a;
					num2++;
					if (!m_HasTransparentPixel && color.a == 0)
					{
						m_HasTransparentPixel = true;
						m_TransparentFlag = 1;
					}
				}
			}
			return;
		}
		for (int num4 = m_CurrentFrame.Height - 1; num4 >= 0; num4--)
		{
			for (int j = 0; j < m_CurrentFrame.Width; j++)
			{
				Color32 color2 = data[num4 * m_CurrentFrame.Width + j];
				m_Pixels[num] = color2.r;
				num++;
				m_Pixels[num] = color2.g;
				num++;
				m_Pixels[num] = color2.b;
				num++;
			}
		}
	}

	protected void AnalyzePixels()
	{
		int num = m_Pixels.Length;
		int num2 = num / 3;
		m_IndexedPixels = new byte[num2];
		ProGifNeuQuant proGifNeuQuant = new ProGifNeuQuant(m_Pixels, num, m_SampleInterval, (m_AutoTransparent && m_HasTransparentPixel) ? true : false);
		m_ColorTab = proGifNeuQuant.Process();
		SetTransparencyIndexAndFlag(m_TransparentColor);
		int num3 = 0;
		for (int i = 0; i < num2; i++)
		{
			int num4 = proGifNeuQuant.Map(m_Pixels[num3++] & 0xFF, m_Pixels[num3++] & 0xFF, m_Pixels[num3++] & 0xFF);
			if (m_TransparentFlag == 1)
			{
				if (m_AutoTransparent && m_PixelsAlpha[i] == 0)
				{
					num4 = m_TransparentColorIndex;
				}
				else if (!m_AutoTransparent && m_Pixels[num3 - 3] == m_TransparentColor.r && m_Pixels[num3 - 2] == m_TransparentColor.g && m_Pixels[num3 - 1] == m_TransparentColor.b)
				{
					num4 = m_TransparentColorIndex;
				}
			}
			m_UsedEntry[num4] = true;
			m_IndexedPixels[i] = (byte)num4;
		}
		m_Pixels = null;
		m_PixelsAlpha = null;
		m_ColorDepth = 8;
		m_PaletteSize = 7;
	}

	public void SetTransparencyColor(Color32 c32)
	{
		m_TransparentColor = c32;
		m_TransparentFlag = 1;
		m_AutoTransparent = false;
	}

	protected void SetTransparencyIndexAndFlag(Color32 c32)
	{
		if (m_TransparentFlag != 1)
		{
			return;
		}
		int num = -1;
		int num2 = 255;
		int num3 = 255;
		int num4 = 255;
		int num5 = 255;
		int num6 = 255;
		int num7 = 255;
		for (int i = 0; i < m_ColorTab.Length; i += 3)
		{
			int num8 = 0;
			num5 = Mathf.Abs(c32.r - m_ColorTab[i]);
			if (num5 <= num2)
			{
				num8++;
			}
			num6 = Mathf.Abs(c32.g - m_ColorTab[i + 1]);
			if (num6 <= num3)
			{
				num8++;
			}
			num7 = Mathf.Abs(c32.b - m_ColorTab[i + 2]);
			if (num7 <= num4)
			{
				num8++;
			}
			if (num8 >= 2 && num5 + num6 + num7 <= num2 + num3 + num4)
			{
				num = i;
				num2 = num5;
				num3 = num6;
				num4 = num7;
			}
		}
		if (num != -1 && (Mathf.Abs(c32.r - m_ColorTab[num]) > 4 || Mathf.Abs(c32.g - m_ColorTab[num + 1]) > 4 || Mathf.Abs(c32.b - m_ColorTab[num + 2]) > 4))
		{
			num = -1;
		}
		m_TransparentColorIndex = ((num == -1) ? (-1) : (num / 3));
		if (m_TransparentColorIndex == -1 && m_AutoTransparent && m_HasTransparentPixel)
		{
			m_TransparentColorIndex = 255;
		}
		m_TransparentFlag = ((m_TransparentColorIndex != -1) ? 1 : 0);
	}

	protected void WriteGraphicCtrlExt()
	{
		m_FileStream.WriteByte(33);
		m_FileStream.WriteByte(249);
		m_FileStream.WriteByte(4);
		m_FileStream.WriteByte(Convert.ToByte(0 | ((m_TransparentFlag == 1) ? 8 : 0) | 0 | m_TransparentFlag));
		WriteShort(m_FrameDelay);
		m_FileStream.WriteByte(Convert.ToByte((m_TransparentColorIndex != -1) ? m_TransparentColorIndex : 0));
		m_FileStream.WriteByte(0);
	}

	protected void WriteImageDesc()
	{
		m_FileStream.WriteByte(44);
		WriteShort(0);
		WriteShort(0);
		WriteShort(m_Width);
		WriteShort(m_Height);
		if (m_IsFirstFrame)
		{
			m_FileStream.WriteByte(0);
		}
		else
		{
			m_FileStream.WriteByte(Convert.ToByte(0x80 | m_PaletteSize));
		}
	}

	protected void WriteLSD()
	{
		WriteShort(m_Width);
		WriteShort(m_Height);
		m_FileStream.WriteByte(Convert.ToByte(0xF0 | m_PaletteSize));
		m_FileStream.WriteByte(0);
		m_FileStream.WriteByte(0);
	}

	protected void WriteNetscapeExt()
	{
		m_FileStream.WriteByte(33);
		m_FileStream.WriteByte(byte.MaxValue);
		m_FileStream.WriteByte(11);
		WriteString("NETSCAPE2.0");
		m_FileStream.WriteByte(3);
		m_FileStream.WriteByte(1);
		WriteShort(m_Repeat);
		m_FileStream.WriteByte(0);
	}

	protected void WritePalette()
	{
		m_FileStream.Write(m_ColorTab, 0, m_ColorTab.Length);
		int num = 768 - m_ColorTab.Length;
		for (int i = 0; i < num; i++)
		{
			m_FileStream.WriteByte(0);
		}
	}

	protected void WritePixels()
	{
		new ProGifLzwEncoder(m_Width, m_Height, m_IndexedPixels, m_ColorDepth).Encode(m_FileStream);
	}

	protected void WriteShort(int value)
	{
		m_FileStream.WriteByte(Convert.ToByte(value & 0xFF));
		m_FileStream.WriteByte(Convert.ToByte((value >> 8) & 0xFF));
	}

	protected void WriteString(string s)
	{
		char[] array = s.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			m_FileStream.WriteByte((byte)array[i]);
		}
	}
}
