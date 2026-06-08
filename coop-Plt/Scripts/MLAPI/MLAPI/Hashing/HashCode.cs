namespace MLAPI.Hashing
{
	internal static class HashCode
	{
		private const uint FNV_offset_basis32 = 2166136261u;

		private const uint FNV_prime32 = 16777619u;

		private const ulong FNV_offset_basis64 = 14695981039346656037uL;

		private const ulong FNV_prime64 = 1099511628211uL;

		internal static ushort GetStableHash16(this string txt)
		{
			uint stableHash = txt.GetStableHash32();
			return (ushort)((stableHash >> 16) ^ stableHash);
		}

		internal static uint GetStableHash32(this string txt)
		{
			uint num = 2166136261u;
			foreach (uint num2 in txt)
			{
				num *= 16777619;
				num ^= num2;
			}
			return num;
		}

		internal static ulong GetStableHash64(this string txt)
		{
			ulong num = 14695981039346656037uL;
			foreach (ulong num2 in txt)
			{
				num *= 1099511628211L;
				num ^= num2;
			}
			return num;
		}

		internal static ushort GetStableHash16(this byte[] bytes)
		{
			uint stableHash = bytes.GetStableHash32();
			return (ushort)((stableHash >> 16) ^ stableHash);
		}

		internal static uint GetStableHash32(this byte[] bytes)
		{
			uint num = 2166136261u;
			foreach (uint num2 in bytes)
			{
				num *= 16777619;
				num ^= num2;
			}
			return num;
		}

		internal static ulong GetStableHash64(this byte[] bytes)
		{
			ulong num = 14695981039346656037uL;
			foreach (ulong num2 in bytes)
			{
				num *= 1099511628211L;
				num ^= num2;
			}
			return num;
		}
	}
}
