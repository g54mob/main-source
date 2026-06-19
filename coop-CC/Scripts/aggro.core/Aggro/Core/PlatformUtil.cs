using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections.LowLevel.Unsafe;

namespace Aggro.Core
{
	public static class PlatformUtil
	{
		private const int SAVE_BUFFER_SIZE = 4096;

		private const int LOAD_BUFFER_SIZE = 4096;

		public static async Task SaveGameAsync(string filepath, byte[] bytes)
		{
			string directoryName = Path.GetDirectoryName(filepath);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			FileStream sourceStream = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true);
			using (sourceStream)
			{
				await sourceStream.WriteAsync(bytes, 0, bytes.Length);
				await sourceStream.FlushAsync();
			}
			await Task.Yield();
		}

		public unsafe static async Task<byte[]> LoadGameAsync(string filepath)
		{
			FileStream sourceStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.None, 4096, useAsync: true);
			using (sourceStream)
			{
				byte[] buffer = new byte[4096];
				List<byte> bytes = new List<byte>();
				int num;
				do
				{
					num = await sourceStream.ReadAsync(buffer, 0, buffer.Length);
					if (num <= 0)
					{
						continue;
					}
					int num2 = 0;
					if (bytes.Count == 0)
					{
						byte[] preamble = Encoding.UTF8.GetPreamble();
						if (num >= preamble.Length)
						{
							byte[] array;
							try
							{
								array = preamble;
								byte* ptr = (byte*)((preamble != null && array.Length != 0) ? System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[0]) : null);
								byte[] array2;
								try
								{
									array2 = buffer;
									byte* ptr2 = (byte*)((buffer != null && array2.Length != 0) ? System.Runtime.CompilerServices.Unsafe.AsPointer(ref array2[0]) : null);
									if (UnsafeUtility.MemCmp(ptr, ptr2, preamble.Length) == 0)
									{
										num2 = preamble.Length;
									}
								}
								finally
								{
									array2 = null;
								}
							}
							finally
							{
								array = null;
							}
						}
					}
					for (int i = num2; i < num; i++)
					{
						bytes.Add(buffer[i]);
					}
				}
				while (num > 0);
				return bytes.ToArray();
			}
		}

		public static async Task DeleteSaveAsync(string filepath)
		{
			File.Delete(filepath);
			await Task.Yield();
		}

		public static bool DoesSaveExist(string filepath)
		{
			return File.Exists(filepath);
		}
	}
}
