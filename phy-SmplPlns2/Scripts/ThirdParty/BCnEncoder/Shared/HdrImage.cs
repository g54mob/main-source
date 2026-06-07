using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using CommunityToolkit.HighPerformance;

namespace BCnEncoder.Shared
{
	public class HdrImage
	{
		public enum ColorSpace
		{
			Rgbe = 0,
			Xyze = 1
		}

		public float exposure = -1f;

		public float gamma = -1f;

		public int width;

		public int height;

		public ColorRgbFloat[] pixels;

		public Span2D<ColorRgbFloat> PixelSpan => new Span2D<ColorRgbFloat>(pixels, height, width);

		public Memory2D<ColorRgbFloat> PixelMemory => new Memory2D<ColorRgbFloat>(pixels, height, width);

		public HdrImage()
		{
		}

		public HdrImage(int width, int height, float exposure = 0f, float gamma = 0f)
		{
			this.width = width;
			this.height = height;
			this.exposure = exposure;
			this.gamma = gamma;
			pixels = new ColorRgbFloat[width * height];
		}

		public HdrImage(Span2D<ColorRgbFloat> pixels, float exposure = 0f, float gamma = 0f)
		{
			width = pixels.Width;
			height = pixels.Height;
			this.exposure = exposure;
			this.gamma = gamma;
			this.pixels = new ColorRgbFloat[width * height];
			pixels.CopyTo(this.pixels);
		}

		private static string ReadFromStream(Stream stream)
		{
			int length = 0;
			char[] array = new char[512];
			char c;
			do
			{
				int num = stream.ReadByte();
				if (num == -1)
				{
					return null;
				}
				c = (char)num;
				array[length++] = c;
			}
			while (c != '\n');
			return new string(array.AsSpan().Slice(0, length)).Trim();
		}

		private static void WriteLineToStream(BinaryWriter br, string s)
		{
			for (int i = 0; i < s.Length; i++)
			{
				byte value = (byte)s[i];
				br.Write(value);
			}
			br.Write((byte)10);
		}

		public static HdrImage Read(string filename)
		{
			using FileStream stream = File.OpenRead(filename);
			return Read(stream);
		}

		public static HdrImage Read(Stream stream)
		{
			HdrImage hdrImage = new HdrImage();
			switch (ReadFromStream(stream))
			{
			default:
				throw new FileLoadException("Correct file type specifier was not found.");
			case "#?RGBE":
			case "#?RADIANCE":
			case "#?AUTOPANO":
			{
				ColorSpace colorSpace = ColorSpace.Rgbe;
				while (true)
				{
					string text = ReadFromStream(stream);
					if (text == null)
					{
						throw new FileLoadException("Reached end of stream.");
					}
					text = text.Trim();
					if (text == "")
					{
						break;
					}
					if (!text.StartsWith("#"))
					{
						if (text == "FORMAT=32-bit_rle_rgbe")
						{
							colorSpace = ColorSpace.Rgbe;
						}
						else if (text == "FORMAT=32-bit_rle_xyze")
						{
							colorSpace = ColorSpace.Xyze;
						}
						else if (text.StartsWith("EXPOSURE="))
						{
							hdrImage.exposure = float.Parse(text.Replace("EXPOSURE=", "").Trim(), CultureInfo.InvariantCulture);
						}
						else if (text.StartsWith("GAMMA="))
						{
							hdrImage.gamma = float.Parse(text.Replace("GAMMA=", "").Trim(), CultureInfo.InvariantCulture);
						}
					}
				}
				if ((double)hdrImage.exposure < 1E-06)
				{
					hdrImage.exposure = 1f;
				}
				if ((double)hdrImage.gamma < 1E-06)
				{
					hdrImage.gamma = 1f;
				}
				string[] array = ReadFromStream(stream).Split(' ');
				_ = array[0];
				hdrImage.height = int.Parse(array[1]);
				_ = array[2];
				hdrImage.width = int.Parse(array[3]);
				ReadPixels(hdrImage, stream);
				if (colorSpace == ColorSpace.Xyze)
				{
					Span<ColorXyz> span = MemoryMarshal.Cast<ColorRgbFloat, ColorXyz>(hdrImage.pixels.AsSpan());
					for (int i = 0; i < span.Length; i++)
					{
						hdrImage.pixels[i] = span[i].ToColorRgbFloat();
					}
				}
				return hdrImage;
			}
			}
		}

		private static void RleReadChannel(BinaryReader br, Span<byte> dest, int width)
		{
			int num = 0;
			byte[] array = new byte[2];
			while (num < width)
			{
				if (br.Read(array) == 0)
				{
					throw new FileLoadException("Not enough data in RLE");
				}
				if (array[0] > 128)
				{
					for (int num2 = array[0] - 128; num2 > 0; num2--)
					{
						dest[num++] = array[1];
					}
					continue;
				}
				dest[num++] = array[1];
				int num3 = array[0] - 1;
				if (num3 > 0)
				{
					if (br.Read(dest.Slice(num, num3)) == 0)
					{
						throw new FileLoadException("Not enough data in RLE");
					}
					num += num3;
				}
			}
			if (num != width)
			{
				throw new FileLoadException("Scanline size was different from width");
			}
		}

		private static void ReadPixels(HdrImage destImage, Stream stream)
		{
			int num = destImage.height;
			int num2 = destImage.width;
			destImage.pixels = new ColorRgbFloat[destImage.height * destImage.width];
			Span<byte> destination = new byte[destImage.width * 4];
			using BinaryReader binaryReader = new BinaryReader(stream, Encoding.ASCII, leaveOpen: true);
			byte[] array = new byte[4];
			for (int i = 0; i < num; i++)
			{
				binaryReader.Read(array);
				if (array[0] == 2 && array[1] == 2 && (array[2] << 8) + array[3] == num2)
				{
					for (int j = 0; j < 4; j++)
					{
						RleReadChannel(binaryReader, destination.Slice(num2 * j, num2), num2);
					}
					for (int k = 0; k < num2; k++)
					{
						ColorRgbe colorRgbe = new ColorRgbe(destination[k], destination[k + num2], destination[k + num2 * 2], destination[k + num2 * 3]);
						destImage.pixels[i * num2 + k] = colorRgbe.ToColorRgbFloat(destImage.exposure);
					}
				}
				else
				{
					binaryReader.Read(destination.Slice(4));
					array.CopyTo(destination);
					for (int l = 0; l < num2; l++)
					{
						ColorRgbe colorRgbe2 = new ColorRgbe(destination[4 * l], destination[4 * l + 1], destination[4 * l + 2], destination[4 * l + 3]);
						destImage.pixels[i * num2 + l] = colorRgbe2.ToColorRgbFloat(destImage.exposure);
					}
				}
			}
		}

		public void Write(Stream stream)
		{
			using BinaryWriter br = new BinaryWriter(stream, Encoding.ASCII, leaveOpen: true);
			WriteLineToStream(br, "#?RADIANCE");
			WriteLineToStream(br, "# BCnEncoder.Net HdrImage");
			WriteLineToStream(br, "FORMAT=32-bit_rle_rgbe");
			if (exposure > 0f)
			{
				WriteLineToStream(br, "EXPOSURE=" + exposure.ToString(CultureInfo.InvariantCulture));
			}
			if (gamma > 0f)
			{
				WriteLineToStream(br, "GAMMA=" + gamma.ToString(CultureInfo.InvariantCulture));
			}
			WriteLineToStream(br, "");
			WriteLineToStream(br, $"-Y {height} +X {width}");
			WritePixels(br);
		}

		private void WritePixels(BinaryWriter br)
		{
			byte[] array = new byte[4];
			Span2D<ColorRgbFloat> pixelSpan = PixelSpan;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					ColorRgbFloat color = pixelSpan[i, j];
					ColorRgbe colorRgbe = new ColorRgbe(color);
					array[0] = colorRgbe.r;
					array[1] = colorRgbe.g;
					array[2] = colorRgbe.b;
					array[3] = colorRgbe.e;
					br.Write(array);
				}
			}
		}
	}
}
