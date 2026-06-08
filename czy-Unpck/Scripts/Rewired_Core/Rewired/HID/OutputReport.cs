using System;
using System.Runtime.InteropServices;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct OutputReport
	{
		public IntPtr buffer;

		public int bufferLength;

		public int reportLength;

		public OutputReportOptions options;

		public bool IsValid
		{
			get
			{
				if (buffer != IntPtr.Zero && bufferLength > 0)
				{
					return reportLength > 0;
				}
				return false;
			}
		}

		public OutputReport(IntPtr buffer, int bufferLength, int reportLength)
		{
			this.buffer = buffer;
			this.bufferLength = bufferLength;
			this.reportLength = reportLength;
			options = OutputReportOptions.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
		}

		public void Clear()
		{
			buffer = IntPtr.Zero;
			bufferLength = 0;
			reportLength = 0;
			options = OutputReportOptions.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
		}

		public override string ToString()
		{
			string text = "OutputReport:\n";
			text = text + "buffer = " + ((buffer == IntPtr.Zero) ? "NULL" : ("Is Valid (" + buffer + ")")) + "\n";
			object obj = text;
			text = string.Concat(obj, "bufferLength = ", bufferLength, "\n");
			object obj2 = default(object);
			object[] array = default(object[]);
			int num2 = default(int);
			while (true)
			{
				int num = -441112480;
				while (true)
				{
					switch (num ^ -441112474)
					{
					case 0:
						break;
					case 6:
						obj2 = text;
						array = new object[4];
						num = -441112475;
						continue;
					case 2:
					{
						int num3;
						if (num2 < reportLength)
						{
							num = -441112477;
							num3 = num;
						}
						else
						{
							num = -441112473;
							num3 = num;
						}
						continue;
					}
					case 3:
					{
						array[0] = obj2;
						array[1] = "reportLength = ";
						array[2] = reportLength;
						array[3] = "\n";
						text = string.Concat(array);
						object obj3 = text;
						text = string.Concat(obj3, "options = ", (int)options, "\n");
						if (buffer != IntPtr.Zero)
						{
							text += "Buffer data:\n";
							num2 = 0;
							num = -441112476;
							continue;
						}
						goto default;
					}
					case 5:
						text += Marshal.ReadByte(buffer, num2).ToString("X2");
						if (num2 < reportLength - 1)
						{
							text += ", ";
							num = -441112478;
							continue;
						}
						goto case 4;
					case 4:
						num2++;
						num = -441112476;
						continue;
					default:
						return text;
					}
					break;
				}
			}
		}
	}
}
