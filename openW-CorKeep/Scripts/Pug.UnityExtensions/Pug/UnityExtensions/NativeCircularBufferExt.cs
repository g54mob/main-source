using System.Text;

namespace Pug.UnityExtensions
{
	public static class NativeCircularBufferExt
	{
		public static string FormatToString<T>(this NativeCircularBuffer<T>.DataView view, int alignment = 3) where T : unmanaged
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < view.Length; i++)
			{
				if (i != 0)
				{
					if (i % 16 == 0)
					{
						stringBuilder.Append($"\n{i:N8}: ");
					}
					else if (i % 8 == 0)
					{
						stringBuilder.Append("   ");
					}
					else
					{
						stringBuilder.Append(' ');
					}
				}
				stringBuilder.Append($"{view[i]}".PadLeft(alignment));
			}
			return stringBuilder.ToString();
		}
	}
}
