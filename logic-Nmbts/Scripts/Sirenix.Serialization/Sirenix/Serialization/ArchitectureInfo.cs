using System;
using UnityEngine;

namespace Sirenix.Serialization
{
	public static class ArchitectureInfo
	{
		public static readonly bool Architecture_Supports_Unaligned_Float32_Reads;

		public static bool Architecture_Supports_All_Unaligned_ReadWrites;

		unsafe static ArchitectureInfo()
		{
			try
			{
				byte[] array = new byte[8];
				fixed (byte* ptr = array)
				{
					for (int i = 0; i < 4; i++)
					{
						float num = *(float*)(ptr + i);
					}
					Architecture_Supports_Unaligned_Float32_Reads = true;
				}
			}
			catch (NullReferenceException)
			{
				Architecture_Supports_Unaligned_Float32_Reads = false;
			}
		}

		internal static void SetIsOnAndroid(string architecture)
		{
			if (!Architecture_Supports_Unaligned_Float32_Reads || architecture == "armv7l" || architecture == "armv7" || IntPtr.Size == 4)
			{
				Architecture_Supports_All_Unaligned_ReadWrites = false;
			}
			else
			{
				Architecture_Supports_All_Unaligned_ReadWrites = true;
			}
			Debug.Log(("OdinSerializer detected Android architecture '" + architecture + "' for determining unaligned read/write capabilities. Unaligned read/write support: all=" + Architecture_Supports_All_Unaligned_ReadWrites + ", float=" + Architecture_Supports_Unaligned_Float32_Reads) ?? "");
		}

		internal static void SetIsNotOnAndroid()
		{
			if (Architecture_Supports_Unaligned_Float32_Reads)
			{
				Architecture_Supports_All_Unaligned_ReadWrites = true;
			}
		}
	}
}
