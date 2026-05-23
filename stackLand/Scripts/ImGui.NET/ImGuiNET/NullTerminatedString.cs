using System.Text;

namespace ImGuiNET
{
	public struct NullTerminatedString
	{
		public unsafe readonly byte* Data;

		public unsafe NullTerminatedString(byte* data)
		{
			Data = data;
		}

		public unsafe override string ToString()
		{
			int num = 0;
			for (byte* ptr = Data; *ptr != 0; ptr++)
			{
				num++;
			}
			return Encoding.ASCII.GetString(Data, num);
		}

		public static implicit operator string(NullTerminatedString nts)
		{
			return nts.ToString();
		}
	}
}
