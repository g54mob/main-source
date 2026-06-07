using System;
using System.Runtime.InteropServices;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
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
			options = OutputReportOptions.TCGihQKDgeeGtvEXifcuojmabzj;
		}

		public void Clear()
		{
			reportId = 0;
			buffer = IntPtr.Zero;
			bufferLength = 0;
			reportLength = 0;
			options = OutputReportOptions.TCGihQKDgeeGtvEXifcuojmabzj;
		}

		public override string ToString()
		{
			string text = "OutputReport:\n";
			object[] array4 = default(object[]);
			object obj3 = default(object);
			object[] array3 = default(object[]);
			object obj = default(object);
			object[] array2 = default(object[]);
			object obj2 = default(object);
			int num2 = default(int);
			object[] array = default(object[]);
			while (true)
			{
				int num = -1719234095;
				while (true)
				{
					switch (num ^ -1719234111)
					{
					case 5:
						break;
					case 9:
						array4[0] = obj3;
						array4[1] = "bufferLength = ";
						num = -1719234106;
						continue;
					case 6:
					{
						array4[3] = "\n";
						text = string.Concat(array4);
						object obj4 = text;
						array3 = new object[4] { obj4, null, null, null };
						num = -1719234097;
						continue;
					}
					case 7:
						array4[2] = bufferLength;
						num = -1719234105;
						continue;
					case 3:
						obj3 = text;
						array4 = new object[4];
						num = -1719234104;
						continue;
					case 0:
						text = string.Concat(array3);
						obj = text;
						array2 = new object[4];
						num = -1719234109;
						continue;
					case 2:
						array2[0] = obj;
						array2[1] = "options = ";
						array2[2] = (int)options;
						num = -1719234098;
						continue;
					case 16:
						obj2 = text;
						num = -1719234101;
						continue;
					case 14:
						array3[1] = "reportLength = ";
						array3[2] = reportLength;
						array3[3] = "\n";
						num = -1719234111;
						continue;
					case 13:
					{
						int num3;
						if (num2 >= reportLength)
						{
							num = -1719234102;
							num3 = num;
						}
						else
						{
							num = -1719234112;
							num3 = num;
						}
						continue;
					}
					case 10:
						array = new object[4];
						num = -1719234096;
						continue;
					case 1:
						text += Marshal.ReadByte(buffer, num2).ToString("x2");
						if (num2 < reportLength - 1)
						{
							text += ", ";
							num = -1719234099;
							continue;
						}
						goto case 12;
					case 15:
						array2[3] = "\n";
						text = string.Concat(array2);
						if (buffer != IntPtr.Zero)
						{
							text += "Buffer data:\n";
							num = -1719234103;
							continue;
						}
						goto default;
					case 12:
						num2++;
						num = -1719234100;
						continue;
					case 17:
						array[0] = obj2;
						array[1] = "reportId = ";
						array[2] = reportId;
						num = -1719234107;
						continue;
					case 4:
						array[3] = "\n";
						text = string.Concat(array);
						text = text + "buffer = " + ((buffer == IntPtr.Zero) ? "NULL" : ("Is Valid (" + buffer + ")")) + "\n";
						num = -1719234110;
						continue;
					case 8:
						num2 = 0;
						num = -1719234100;
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
