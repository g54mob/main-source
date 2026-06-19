#define TRACE
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class AttachedPicture : IAttachedPicture, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private string m_MimeType;

		private PictureType m_PictureType;

		private string m_Description;

		private byte[] m_PictureData;

		private Image m_Picture;

		private bool m_LoadingPicture;

		private bool m_ReadingTag;

		private bool m_PictureCached;

		public EncodingType TextEncoding
		{
			get
			{
				return m_TextEncoding;
			}
			set
			{
				if (m_TextEncoding != value)
				{
					m_TextEncoding = value;
					FirePropertyChanged("TextEncoding");
				}
			}
		}

		public string MimeType
		{
			get
			{
				return m_MimeType;
			}
			set
			{
				if (m_MimeType != value)
				{
					m_MimeType = value;
					FirePropertyChanged("MimeType");
				}
			}
		}

		public PictureType PictureType
		{
			get
			{
				return m_PictureType;
			}
			set
			{
				if (m_PictureType != value)
				{
					m_PictureType = value;
					FirePropertyChanged("PictureType");
				}
			}
		}

		public string Description
		{
			get
			{
				return m_Description;
			}
			set
			{
				if (m_Description != value)
				{
					m_Description = value;
					FirePropertyChanged("Description");
				}
			}
		}

		public byte[] PictureData
		{
			get
			{
				if (m_PictureData == null)
				{
					return null;
				}
				return (byte[])m_PictureData.Clone();
			}
			set
			{
				if (m_PictureData != value)
				{
					m_PictureData = value;
					if (value != null && !m_ReadingTag)
					{
						LoadPicture();
					}
					FirePropertyChanged("PictureData");
				}
			}
		}

		public string PictureExtension
		{
			get
			{
				if (m_Picture == null)
				{
					return null;
				}
				if (m_Picture.RawFormat.Equals(ImageFormat.Bmp))
				{
					return "bmp";
				}
				if (m_Picture.RawFormat.Equals(ImageFormat.Emf))
				{
					return "emf";
				}
				if (m_Picture.RawFormat.Equals(ImageFormat.Exif))
				{
					return null;
				}
				if (m_Picture.RawFormat.Equals(ImageFormat.Gif))
				{
					return "gif";
				}
				if (m_Picture.RawFormat.Equals(ImageFormat.Icon))
				{
					return "ico";
				}
				if (m_Picture.RawFormat.Equals(ImageFormat.Jpeg))
				{
					return "jpg";
				}
				if (m_Picture.RawFormat.Equals(ImageFormat.MemoryBmp))
				{
					return "bmp";
				}
				if (m_Picture.RawFormat.Equals(ImageFormat.Png))
				{
					return "png";
				}
				if (m_Picture.RawFormat.Equals(ImageFormat.Tiff))
				{
					return "tif";
				}
				if (m_Picture.RawFormat.Equals(ImageFormat.Wmf))
				{
					return "wmf";
				}
				return "";
			}
		}

		public Image Picture
		{
			get
			{
				if (!m_PictureCached)
				{
					LoadPicture();
				}
				if (m_Picture != null)
				{
					return (Image)m_Picture.Clone();
				}
				return null;
			}
			set
			{
				if (m_Picture != value)
				{
					if (m_Picture != null)
					{
						m_Picture.Dispose();
					}
					m_Picture = value;
					if (value == null)
					{
						m_PictureData = null;
					}
					else if (!m_LoadingPicture)
					{
						using (MemoryStream memoryStream = new MemoryStream())
						{
							value.Save(memoryStream, value.RawFormat);
							m_PictureData = memoryStream.ToArray();
						}
						SetMimeType();
					}
				}
				FirePropertyChanged("Picture");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public AttachedPicture()
		{
			m_FrameHeader = new FrameHeader();
			m_TextEncoding = EncodingType.Unicode;
			m_PictureType = PictureType.CoverFront;
		}

		private void SetMimeType()
		{
			if (m_Picture == null)
			{
				return;
			}
			if (m_Picture.RawFormat.Equals(ImageFormat.Bmp))
			{
				MimeType = "image/bmp";
			}
			else if (m_Picture.RawFormat.Equals(ImageFormat.Emf))
			{
				MimeType = "image/x-emf";
			}
			else
			{
				if (m_Picture.RawFormat.Equals(ImageFormat.Exif))
				{
					return;
				}
				if (m_Picture.RawFormat.Equals(ImageFormat.Gif))
				{
					MimeType = "image/gif";
				}
				else if (!m_Picture.RawFormat.Equals(ImageFormat.Icon))
				{
					if (m_Picture.RawFormat.Equals(ImageFormat.Jpeg))
					{
						MimeType = "image/jpeg";
					}
					else if (m_Picture.RawFormat.Equals(ImageFormat.MemoryBmp))
					{
						MimeType = "image/bmp";
					}
					else if (m_Picture.RawFormat.Equals(ImageFormat.Png))
					{
						MimeType = "image/png";
					}
					else if (m_Picture.RawFormat.Equals(ImageFormat.Tiff))
					{
						MimeType = "image/tiff";
					}
					else if (m_Picture.RawFormat.Equals(ImageFormat.Wmf))
					{
						MimeType = "image/x-wmf";
					}
				}
			}
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "APIC";
			case ID3v2TagVersion.ID3v22:
				return "PIC";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
			if (bytesLeft >= 6)
			{
				TextEncoding = (EncodingType)Utils.ReadByte(stream, ref bytesLeft);
				if (tagReadingInfo.TagVersion == ID3v2TagVersion.ID3v22)
				{
					Utils.ReadString(EncodingType.ISO88591, stream, 3);
					bytesLeft -= 3;
				}
				else
				{
					MimeType = Utils.ReadString(EncodingType.ISO88591, stream, ref bytesLeft);
				}
				PictureType = (PictureType)Utils.ReadByte(stream, ref bytesLeft);
				Description = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
				if (bytesLeft > 0)
				{
					byte[] pictureData = Utils.Read(stream, bytesLeft);
					bytesLeft = 0;
					m_ReadingTag = true;
					try
					{
						m_PictureCached = false;
						PictureData = pictureData;
					}
					finally
					{
						m_ReadingTag = false;
					}
				}
				else
				{
					PictureData = null;
				}
			}
			else
			{
				TextEncoding = EncodingType.ISO88591;
				Description = null;
				MimeType = null;
				PictureType = PictureType.CoverFront;
				PictureData = null;
			}
			if (bytesLeft > 0)
			{
				stream.Seek(bytesLeft, SeekOrigin.Current);
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (m_PictureData == null || m_PictureData.Length == 0)
			{
				return new byte[0];
			}
			TextEncoding = EncodingType.ISO88591;
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte((byte)m_TextEncoding);
			if (tagVersion == ID3v2TagVersion.ID3v22)
			{
				string text = PictureExtension;
				if (string.IsNullOrEmpty(text) || text.Length < 3)
				{
					text = "   ";
				}
				else if (text.Length > 3)
				{
					text = text.Substring(0, 3);
				}
				Utils.Write(memoryStream, Encoding.ASCII.GetBytes(text));
			}
			else
			{
				SetMimeType();
				Utils.Write(memoryStream, Utils.ISO88591GetBytes(m_MimeType));
				memoryStream.WriteByte(0);
			}
			memoryStream.WriteByte((byte)m_PictureType);
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, m_TextEncoding, m_Description, isTerminated: true));
			Utils.Write(memoryStream, m_PictureData);
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void LoadPicture()
		{
			m_PictureCached = true;
			if (m_PictureData == null)
			{
				Picture = null;
				return;
			}
			using MemoryStream stream = new MemoryStream(m_PictureData);
			bool flag = false;
			try
			{
				m_LoadingPicture = true;
				try
				{
					Picture = Image.FromStream(stream);
				}
				finally
				{
					m_LoadingPicture = false;
				}
			}
			catch (OutOfMemoryException)
			{
				string message = $"OutOfMemoryException caught in APIC's PictureData setter";
				Trace.WriteLine(message);
				flag = true;
			}
			catch (ArgumentException)
			{
				string message2 = $"ArgumentException caught in APIC's PictureData setter";
				Trace.WriteLine(message2);
				flag = true;
			}
			if (!flag)
			{
				return;
			}
			if (m_Picture != null)
			{
				m_Picture.Dispose();
			}
			m_Picture = null;
			try
			{
				string text = Utils.ISO88591GetString(m_PictureData);
				if (text.Contains("://"))
				{
					MimeType = "-->";
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
