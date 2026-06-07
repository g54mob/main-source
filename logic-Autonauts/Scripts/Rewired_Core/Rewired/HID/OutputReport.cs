using System;
using System.Runtime.InteropServices;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct OutputReport
	{
		public int reportId;

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
			reportId = 0;
			this.buffer = buffer;
			this.bufferLength = bufferLength;
			this.reportLength = reportLength;
			options = OutputReportOptions.iOlZgcuFwLCPNAjSgaSDuxucio;
		}

		public void Clear()
		{
			reportId = 0;
			buffer = IntPtr.Zero;
			bufferLength = 0;
			reportLength = 0;
			options = OutputReportOptions.iOlZgcuFwLCPNAjSgaSDuxucio;
		}

		public override string ToString()
		{
			string text = "OutputReport:\n";
			object obj4 = default(object);
			int num2 = default(int);
			object[] array2 = default(object[]);
			object[] array4 = default(object[]);
			object[] array = default(object[]);
			object[] array3 = default(object[]);
			object obj2 = default(object);
			object obj = default(object);
			while (true)
			{
				int num = 2085678081;
				while (true)
				{
					switch (num ^ 0x7C50EC0A)
					{
					case 0:
						break;
					case 13:
						obj4 = text;
						num = 2085678091;
						continue;
					case 7:
						if (buffer != IntPtr.Zero)
						{
							text += "Buffer data:\n";
							num = 2085678095;
							continue;
						}
						goto default;
					case 14:
						num2++;
						num = 2085678094;
						continue;
					case 5:
						num2 = 0;
						num = 2085678094;
						continue;
					case 4:
					{
						int num3;
						if (num2 >= reportLength)
						{
							num = 2085678089;
							num3 = num;
						}
						else
						{
							num = 2085678083;
							num3 = num;
						}
						continue;
					}
					case 9:
						text += Marshal.ReadByte(buffer, num2).ToString("x2");
						if (num2 < reportLength - 1)
						{
							text += ", ";
							num = 2085678084;
							continue;
						}
						goto case 14;
					case 10:
						array2[3] = "\n";
						num = 2085678088;
						continue;
					case 1:
						array2 = new object[4] { obj4, "bufferLength = ", bufferLength, null };
						num = 2085678080;
						continue;
					case 15:
						text = string.Concat(array4);
						num = 2085678093;
						continue;
					case 8:
						array[3] = "\n";
						text = string.Concat(array);
						num = 2085678106;
						continue;
					case 12:
					{
						array3[0] = obj2;
						array3[1] = "reportLength = ";
						array3[2] = reportLength;
						array3[3] = "\n";
						text = string.Concat(array3);
						object obj3 = text;
						array4 = new object[4]
						{
							obj3,
							"options = ",
							(int)options,
							"\n"
						};
						num = 2085678085;
						continue;
					}
					case 2:
						text = string.Concat(array2);
						obj2 = text;
						array3 = new object[4];
						num = 2085678086;
						continue;
					case 6:
						array = new object[4] { obj, "reportId = ", reportId, null };
						num = 2085678082;
						continue;
					case 16:
						text = text + "buffer = " + ((buffer == IntPtr.Zero) ? "NULL" : ("Is Valid (" + buffer + ")")) + "\n";
						num = 2085678087;
						continue;
					case 11:
						obj = text;
						num = 2085678092;
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
