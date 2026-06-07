using UnityEngine;

public class WorkshopPreview
{
	private class Crc32
	{
		private static uint[] crcTable;

		public static uint Compute(byte[] stream, int offset, int length, uint crc)
		{
			return 0u;
		}
	}

	public SerializedGadgetMetaData metadata;

	public Texture2D preview;

	public static ushort SwapUInt16(ushort v)
	{
		return 0;
	}

	public static uint SwapUInt32(uint v)
	{
		return 0u;
	}

	public static byte[] Generate(Texture2D preview, SerializedGadgetMetaData metadata)
	{
		return null;
	}

	public WorkshopPreview(byte[] pngData)
	{
	}

	public void Dispose()
	{
	}
}
