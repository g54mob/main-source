using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using RngBuf2n;

namespace PIEHid64Net
{
	public class PIEDevice
	{
		private const int READ_BUFFER_COUNT = 512;

		private const int WRITE_BUFFER_COUNT = 512;

		private string path;

		private long vid;

		private long pid;

		private long version;

		private long hidUsage;

		private long hidUsagePage;

		private bool connected;

		public bool suppressDuplicateReports;

		private int inputReportSize;

		private int outputReportSize;

		private RngBuf2 writeRing;

		private RngBuf2 readRing;

		private SafeFileHandle readFileHandle;

		private SafeFileHandle writeFileHandle;

		private PIEDataHandler registeredDataHandler;

		private PIEErrorHandler registeredErrorHandler;

		public bool callNever;

		private IntPtr readFileH;

		private int errCodeR;

		private int errCodeRE;

		private int errCodeW;

		private int errCodeWE;

		private bool holdDataThreadOpen;

		private bool holdErrorThreadOpen;

		private FileIOApiDeclarations.SECURITY_ATTRIBUTES securityAttrUnused = default(FileIOApiDeclarations.SECURITY_ATTRIBUTES);

		private IntPtr readEvent;

		private IntPtr writeEvent;

		private Thread readThreadHandle;

		private Thread dataThreadHandle;

		private Thread writeThreadHandle;

		private Thread errorThreadHandle;

		private bool readThreadActive;

		private bool writeThreadActive;

		private bool dataThreadActive;

		private bool errorThreadActive;

		private string manufacturersString;

		private string productString;

		private string serialnumberString;

		protected static ushort[] convertToSplatModeSausages = new ushort[6] { 7, 5, 4, 3, 2, 1 };

		protected static ushort[] ledSausages = new ushort[6] { 7, 3, 1, 6, 4, 2 };

		public string Path => path;

		public long Vid => vid;

		public long Pid => pid;

		public long Version => version;

		public long HidUsage => hidUsage;

		public long HidUsagePage => hidUsagePage;

		public long ReadLength => inputReportSize;

		public long WriteLength => outputReportSize;

		public string ManufacturersString => manufacturersString;

		public string ProductString => productString;

		public string SerialNumberString => serialnumberString;

		public PIEDevice(string path, long vid, long pid, long version, long hidUsage, long hidUsagePage, long readSize, long writeSize, string ManufacturersString, string ProductString, string SerialNumberString)
		{
			this.path = path;
			this.vid = vid;
			this.pid = pid;
			this.version = version;
			this.hidUsage = hidUsage;
			this.hidUsagePage = hidUsagePage;
			inputReportSize = (int)readSize;
			outputReportSize = (int)writeSize;
			manufacturersString = ManufacturersString;
			productString = ProductString;
			securityAttrUnused.bInheritHandle = 1;
			serialnumberString = SerialNumberString;
		}

		public string GetErrorString(int errNumb)
		{
			int[] array = new int[100];
			string[] array2 = new string[100];
			array[0] = 0;
			array2[0] = "000 Success";
			array[1] = 101;
			array2[1] = "101 ";
			array[2] = 102;
			array2[2] = "102 ";
			array[4] = 104;
			array2[4] = "104 ";
			array[5] = 105;
			array2[5] = "105 ";
			array[6] = 106;
			array2[6] = "106 ";
			array[7] = 107;
			array2[7] = "107 ";
			array[8] = 108;
			array2[8] = "108 ";
			array[9] = 109;
			array2[9] = "109 ";
			array[10] = 110;
			array2[10] = "110 ";
			array[11] = 111;
			array2[11] = "111 ";
			array[12] = 112;
			array2[12] = "112 ";
			array[13] = 201;
			array2[13] = "201 ";
			array[14] = 202;
			array2[14] = "202 ";
			array[53] = 203;
			array2[53] = "203 Already Connected";
			array[15] = 207;
			array2[15] = "207 Cannot open read handle";
			array[16] = 204;
			array2[16] = "204 ";
			array[17] = 205;
			array2[17] = "205 ";
			array[18] = 208;
			array2[18] = "208 Cannot open write handle";
			array[19] = 209;
			array2[19] = "209 Cannot open either handle";
			array[20] = 210;
			array2[20] = "210 ";
			array[21] = 301;
			array2[21] = "301 Bad interface handle";
			array[22] = 302;
			array2[22] = "302 readSize is zero";
			array[23] = 303;
			array2[23] = "303 Interface not valid";
			array[24] = 304;
			array2[24] = "304 Ring buffer empty.";
			array[25] = 305;
			array2[25] = "305 ";
			array[26] = 307;
			array2[26] = "307 ";
			array[27] = 308;
			array2[27] = "308 Device disconnected";
			array[28] = 309;
			array2[28] = "309 Read error. ( unplugged )";
			array[29] = 310;
			array2[29] = "310 Bytes read not equal readSize";
			array[30] = 311;
			array2[30] = "311 dest.Length<ReportSize";
			array[31] = 401;
			array2[31] = "401 ";
			array[32] = 402;
			array2[32] = "402 Write length is zero";
			array[33] = 403;
			array2[33] = "403 wData.Length<ReportSize";
			array[34] = 404;
			array2[34] = "404 WriteBuffer full--retry";
			array[35] = 405;
			array2[35] = "405 No write buffer";
			array[36] = 406;
			array2[36] = "406 Interface not valid";
			array[37] = 407;
			array2[37] = "407 No writeBuffer";
			array[38] = 408;
			array2[38] = "408 Device disconnected";
			array[55] = 409;
			array2[55] = "409 Unknown write error";
			array[56] = 410;
			array2[56] = "410 byteCount != writeSize";
			array[57] = 411;
			array2[57] = "411 Timed out in write.";
			array[58] = 412;
			array2[58] = "412 Report ID error";
			array[39] = 501;
			array2[39] = "501 ";
			array[40] = 502;
			array2[40] = "502 Read length is zero";
			array[41] = 503;
			array2[41] = "503 dest.Length<ReportSize";
			array[42] = 504;
			array2[42] = "504 No data yet.";
			array[43] = 507;
			array2[43] = "507 Interface not valid.";
			array[44] = 601;
			array2[44] = "601 ";
			array[45] = 602;
			array2[45] = "602 ";
			array[46] = 701;
			array2[46] = "701 ";
			array[47] = 702;
			array2[47] = "702 Interface not valid";
			array[48] = 703;
			array2[48] = "703 Input ReportSize Zero";
			array[49] = 704;
			array2[49] = "704 Data Handler Already Exists";
			array[50] = 801;
			array2[50] = "801 ";
			array[51] = 802;
			array2[51] = "802 Interface not valid";
			array[52] = 803;
			array2[52] = "803 ";
			array[54] = 804;
			array2[54] = "804 Error Handler Already Exists";
			string result = "Unknown Error" + errNumb;
			for (int i = 0; i < 59; i++)
			{
				if (array[i] == errNumb)
				{
					result = array2[i];
					break;
				}
			}
			return result;
		}

		protected void ErrorThread()
		{
			while (errorThreadActive)
			{
				if (errCodeRE != 0)
				{
					holdDataThreadOpen = true;
					registeredErrorHandler.HandlePIEHidError(this, errCodeRE);
					holdDataThreadOpen = false;
				}
				if (errCodeWE != 0)
				{
					holdErrorThreadOpen = true;
					registeredErrorHandler.HandlePIEHidError(this, errCodeWE);
					holdErrorThreadOpen = false;
				}
				errCodeRE = 0;
				errCodeWE = 0;
				Thread.Sleep(25);
			}
		}

		protected void WriteThread()
		{
			IntPtr intPtr = FileIOApiDeclarations.CreateEvent(ref securityAttrUnused, 1, 0, "");
			FileIOApiDeclarations.OVERLAPPED lpOverlapped = new FileIOApiDeclarations.OVERLAPPED
			{
				Offset = 0,
				OffsetHigh = 0,
				hEvent = intPtr,
				Internal = IntPtr.Zero,
				InternalHigh = IntPtr.Zero
			};
			if (outputReportSize == 0)
			{
				return;
			}
			byte[] array = new byte[outputReportSize];
			GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			int lpNumberOfBytesWritten = 0;
			errCodeW = 0;
			errCodeWE = 0;
			while (writeThreadActive)
			{
				if (writeRing == null)
				{
					errCodeW = 407;
					errCodeWE = 407;
					break;
				}
				while (writeRing.get(array) == 0)
				{
					if (FileIOApiDeclarations.WriteFile(writeFileHandle, gCHandle.AddrOfPinnedObject(), outputReportSize, ref lpNumberOfBytesWritten, ref lpOverlapped) == 0)
					{
						int lastWin32Error = Marshal.GetLastWin32Error();
						switch (lastWin32Error)
						{
						case 87:
							errCodeW = 412;
							errCodeWE = 412;
							break;
						default:
							errCodeW = lastWin32Error;
							errCodeWE = 408;
							break;
						case 997:
							if (FileIOApiDeclarations.WaitForSingleObject(intPtr, 1000) == 0)
							{
								continue;
							}
							errCodeW = 411;
							errCodeWE = 411;
							break;
						}
						goto end_IL_0181;
					}
					if ((long)lpNumberOfBytesWritten != outputReportSize)
					{
						errCodeW = 410;
						errCodeWE = 410;
					}
				}
				FileIOApiDeclarations.WaitForSingleObject(writeEvent, 100);
				FileIOApiDeclarations.ResetEvent(writeEvent);
				continue;
				end_IL_0181:
				break;
			}
			gCHandle.Free();
		}

		protected void ReadThread()
		{
			IntPtr intPtr = FileIOApiDeclarations.CreateEvent(ref securityAttrUnused, 1, 0, "");
			FileIOApiDeclarations.OVERLAPPED lpOverlapped = new FileIOApiDeclarations.OVERLAPPED
			{
				Offset = 0,
				OffsetHigh = 0,
				hEvent = intPtr,
				Internal = IntPtr.Zero,
				InternalHigh = IntPtr.Zero
			};
			if (inputReportSize == 0)
			{
				errCodeR = 302;
				errCodeRE = 302;
				return;
			}
			errCodeR = 0;
			errCodeRE = 0;
			byte[] array = new byte[inputReportSize];
			GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			while (readThreadActive)
			{
				int lpNumberOfBytesRead = 0;
				if (readFileHandle.IsInvalid)
				{
					errCodeRE = (errCodeR = 320);
					break;
				}
				if (FileIOApiDeclarations.ReadFile(readFileHandle, gCHandle.AddrOfPinnedObject(), inputReportSize, ref lpNumberOfBytesRead, ref lpOverlapped) == 0)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					if (lastWin32Error != 997)
					{
						if (readFileHandle.IsInvalid)
						{
							errCodeRE = (errCodeR = 321);
							break;
						}
						errCodeR = lastWin32Error;
						errCodeRE = 308;
						break;
					}
					while (readThreadActive)
					{
						if (FileIOApiDeclarations.WaitForSingleObject(intPtr, 50) != 0)
						{
							continue;
						}
						goto IL_013e;
					}
					continue;
				}
				goto IL_0187;
				IL_0187:
				if (lpNumberOfBytesRead != inputReportSize)
				{
					errCodeR = 310;
					errCodeRE = 310;
					break;
				}
				if (suppressDuplicateReports)
				{
					if (readRing.putIfDiff(array) == 0)
					{
						FileIOApiDeclarations.SetEvent(readEvent);
					}
				}
				else
				{
					readRing.put(array);
					FileIOApiDeclarations.SetEvent(readEvent);
				}
				continue;
				IL_013e:
				if (FileIOApiDeclarations.GetOverlappedResult(readFileHandle, ref lpOverlapped, ref lpNumberOfBytesRead, 0) == 0)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					if (lastWin32Error == 6 || lastWin32Error == 1167)
					{
						errCodeR = 309;
						errCodeRE = 309;
						break;
					}
				}
				goto IL_0187;
			}
			FileIOApiDeclarations.CancelIo(readFileHandle);
			readFileHandle = null;
			gCHandle.Free();
		}

		protected void DataEventThread()
		{
			byte[] array = new byte[inputReportSize];
			while (dataThreadActive && readRing != null)
			{
				if (!callNever)
				{
					if (errCodeR != 0)
					{
						Array.Clear(array, 0, inputReportSize);
						holdDataThreadOpen = true;
						registeredDataHandler.HandlePIEHidData(array, this, errCodeR);
						holdDataThreadOpen = false;
						dataThreadActive = false;
					}
					else if (readRing.get(array) == 0)
					{
						holdDataThreadOpen = true;
						registeredDataHandler.HandlePIEHidData(array, this, 0);
						holdDataThreadOpen = false;
					}
					if (readRing.IsEmpty())
					{
						FileIOApiDeclarations.ResetEvent(readEvent);
					}
				}
				FileIOApiDeclarations.WaitForSingleObject(readEvent, 100);
			}
		}

		public long SetupInterface()
		{
			int num = 0;
			int num2 = 0;
			if (connected)
			{
				return 203L;
			}
			if (inputReportSize > 0)
			{
				readFileH = FileIOApiDeclarations.CreateFile(path, 2147483648u, 3u, IntPtr.Zero, 3, 1073741824u, 0);
				readFileHandle = new SafeFileHandle(readFileH, ownsHandle: true);
				if (readFileHandle.IsInvalid)
				{
					readRing = null;
					num = 207;
				}
				else
				{
					readEvent = FileIOApiDeclarations.CreateEvent(ref securityAttrUnused, 1, 0, "");
					readRing = new RngBuf2(128, inputReportSize);
					readThreadHandle = new Thread(ReadThread);
					readThreadHandle.IsBackground = true;
					readThreadHandle.Name = "PIEHidReadThread for " + pid;
					readThreadActive = true;
					readThreadHandle.Start();
				}
			}
			if (outputReportSize > 0)
			{
				IntPtr preexistingHandle = FileIOApiDeclarations.CreateFile(path, 1073741824u, 3u, IntPtr.Zero, 3, 1073741824u, 0);
				writeFileHandle = new SafeFileHandle(preexistingHandle, ownsHandle: true);
				if (writeFileHandle.IsInvalid)
				{
					writeRing = null;
					num2 = 208;
					goto IL_01d6;
				}
				writeEvent = FileIOApiDeclarations.CreateEvent(ref securityAttrUnused, 1, 0, "");
				writeRing = new RngBuf2(128, outputReportSize);
				writeThreadHandle = new Thread(WriteThread);
				writeThreadHandle.IsBackground = true;
				writeThreadHandle.Name = "PIEHidWriteThread for " + pid;
				writeThreadActive = true;
				writeThreadHandle.Start();
			}
			connected = true;
			goto IL_01d6;
			IL_01d6:
			if (num == 0 && num2 == 0)
			{
				return 0L;
			}
			if (num == 207 && num2 == 208)
			{
				return 209L;
			}
			return num + num2;
		}

		public void CloseInterface()
		{
			if (holdErrorThreadOpen || holdDataThreadOpen)
			{
				return;
			}
			if (dataThreadActive)
			{
				dataThreadActive = false;
				FileIOApiDeclarations.SetEvent(readEvent);
				int num = 0;
				if (dataThreadHandle != null)
				{
					while (dataThreadHandle.IsAlive)
					{
						Thread.Sleep(10);
						num++;
						if (num == 10)
						{
							dataThreadHandle.Abort();
							break;
						}
					}
					dataThreadHandle = null;
				}
			}
			if (readThreadActive)
			{
				readThreadActive = false;
				if (readThreadHandle != null)
				{
					int num2 = 0;
					while (readThreadHandle.IsAlive)
					{
						Thread.Sleep(10);
						num2++;
						if (num2 == 10)
						{
							readThreadHandle.Abort();
							break;
						}
					}
					readThreadHandle = null;
				}
			}
			if (writeThreadActive)
			{
				writeThreadActive = false;
				FileIOApiDeclarations.SetEvent(writeEvent);
				if (writeThreadHandle != null)
				{
					int num3 = 0;
					while (writeThreadHandle.IsAlive)
					{
						Thread.Sleep(10);
						num3++;
						if (num3 == 10)
						{
							writeThreadHandle.Abort();
							break;
						}
					}
					writeThreadHandle = null;
				}
			}
			if (errorThreadActive)
			{
				errorThreadActive = false;
				if (errorThreadHandle != null)
				{
					int num4 = 0;
					while (errorThreadHandle.IsAlive)
					{
						Thread.Sleep(10);
						num4++;
						if (num4 == 10)
						{
							errorThreadHandle.Abort();
							break;
						}
					}
					errorThreadHandle = null;
				}
			}
			if (writeRing != null)
			{
				writeRing = null;
			}
			if (readRing != null)
			{
				readRing = null;
			}
			if ((255 != pid && 254 != pid && 253 != pid && 252 != pid && 251 != pid) || version > 272)
			{
				if (readFileHandle != null && !readFileHandle.IsInvalid)
				{
					readFileHandle.Close();
				}
				if (writeFileHandle != null && !writeFileHandle.IsInvalid)
				{
					writeFileHandle.Close();
				}
			}
			connected = false;
		}

		public long SetDataCallback(PIEDataHandler handler)
		{
			if (!connected)
			{
				return 702L;
			}
			if (inputReportSize == 0)
			{
				return 703L;
			}
			if (registeredDataHandler == null)
			{
				registeredDataHandler = handler;
				dataThreadHandle = new Thread(DataEventThread);
				dataThreadHandle.IsBackground = true;
				dataThreadHandle.Name = "PIEHidEventThread for " + pid;
				dataThreadActive = true;
				dataThreadHandle.Start();
				return 0L;
			}
			return 704L;
		}

		public long SetErrorCallback(PIEErrorHandler handler)
		{
			if (!connected)
			{
				return 802L;
			}
			if (registeredErrorHandler == null)
			{
				registeredErrorHandler = handler;
				errorThreadHandle = new Thread(ErrorThread);
				errorThreadHandle.IsBackground = true;
				errorThreadHandle.Name = "PIEHidErrorThread for " + pid;
				errorThreadActive = true;
				errorThreadHandle.Start();
				return 0L;
			}
			return 804L;
		}

		public int ReadLast(ref byte[] dest)
		{
			if (inputReportSize == 0)
			{
				return 502;
			}
			if (!connected)
			{
				return 507;
			}
			if (dest == null)
			{
				dest = new byte[inputReportSize];
			}
			if (dest.Length < inputReportSize)
			{
				return 503;
			}
			if (readRing.getlast(dest) != 0)
			{
				return 504;
			}
			return 0;
		}

		public int ReadData(ref byte[] dest)
		{
			if (!connected)
			{
				return 303;
			}
			if (dest == null)
			{
				dest = new byte[inputReportSize];
			}
			if (dest.Length < inputReportSize)
			{
				return 311;
			}
			if (readRing.get(dest) != 0)
			{
				return 304;
			}
			return 0;
		}

		public int BlockingReadData(ref byte[] dest, int maxMillis)
		{
			long ticks = DateTime.UtcNow.Ticks;
			int num = 304;
			int num2 = maxMillis;
			while (num2 > 0 && num == 304 && (num = ReadData(ref dest)) != 0)
			{
				long ticks2 = DateTime.UtcNow.Ticks;
				num2 = maxMillis - (int)(ticks2 - ticks) / 10000;
				Thread.Sleep(10);
			}
			return num;
		}

		public int WriteData(byte[] wData)
		{
			if (outputReportSize == 0)
			{
				return 402;
			}
			if (!connected)
			{
				return 406;
			}
			if (wData.Length < outputReportSize)
			{
				return 403;
			}
			if (writeRing == null)
			{
				return 405;
			}
			if (errCodeW != 0)
			{
				return errCodeW;
			}
			if (writeRing.putIfCan(wData) == 3)
			{
				Thread.Sleep(1);
				return 404;
			}
			FileIOApiDeclarations.SetEvent(writeEvent);
			return 0;
		}

		public static PIEDevice[] EnumeratePIE()
		{
			return EnumeratePIE(1523L);
		}

		public static PIEDevice[] EnumeratePIE(long vid)
		{
			LinkedList<PIEDevice> linkedList = new LinkedList<PIEDevice>();
			Guid HidGuid = Guid.Empty;
			HidApiDeclarations.HidD_GetHidGuid(ref HidGuid);
			IntPtr deviceInfoSet = DeviceManagementApiDeclarations.SetupDiGetClassDevs(ref HidGuid, null, IntPtr.Zero, 18);
			DeviceManagementApiDeclarations.SP_DEVICE_INTERFACE_DATA DeviceInterfaceData = default(DeviceManagementApiDeclarations.SP_DEVICE_INTERFACE_DATA);
			DeviceInterfaceData.cbSize = Marshal.SizeOf((object)DeviceInterfaceData);
			LinkedList<string> linkedList2 = new LinkedList<string>();
			for (int i = 0; DeviceManagementApiDeclarations.SetupDiEnumDeviceInterfaces(deviceInfoSet, 0, ref HidGuid, i, ref DeviceInterfaceData) != 0; i++)
			{
				int RequiredSize = 0;
				DeviceManagementApiDeclarations.SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref DeviceInterfaceData, IntPtr.Zero, 0, ref RequiredSize, IntPtr.Zero);
				IntPtr intPtr = Marshal.AllocHGlobal(RequiredSize);
				if (IntPtr.Size == 8)
				{
					Marshal.WriteInt64(intPtr, Marshal.SizeOf(typeof(IntPtr)));
				}
				else
				{
					Marshal.WriteInt64(intPtr, 4 + Marshal.SystemDefaultCharSize);
				}
				if (DeviceManagementApiDeclarations.SetupDiGetDeviceInterfaceDetail(deviceInfoSet, ref DeviceInterfaceData, intPtr, RequiredSize, ref RequiredSize, IntPtr.Zero))
				{
					linkedList2.AddLast(Marshal.PtrToStringAuto(new IntPtr(intPtr.ToInt64() + 4)));
				}
			}
			DeviceManagementApiDeclarations.SetupDiDestroyDeviceInfoList(deviceInfoSet);
			FileIOApiDeclarations.SECURITY_ATTRIBUTES sECURITY_ATTRIBUTES = default(FileIOApiDeclarations.SECURITY_ATTRIBUTES);
			sECURITY_ATTRIBUTES.lpSecurityDescriptor = IntPtr.Zero;
			sECURITY_ATTRIBUTES.bInheritHandle = Convert.ToInt32(value: true);
			sECURITY_ATTRIBUTES.nLength = Marshal.SizeOf((object)sECURITY_ATTRIBUTES);
			LinkedList<string>.Enumerator enumerator = linkedList2.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				IntPtr preexistingHandle = FileIOApiDeclarations.CreateFile(current, 1073741824u, 3u, IntPtr.Zero, 3, 0u, 0);
				SafeFileHandle safeFileHandle = new SafeFileHandle(preexistingHandle, ownsHandle: true);
				if (safeFileHandle.IsInvalid)
				{
					continue;
				}
				try
				{
					HidApiDeclarations.HIDD_ATTRIBUTES Attributes = default(HidApiDeclarations.HIDD_ATTRIBUTES);
					Attributes.Size = Marshal.SizeOf((object)Attributes);
					if (HidApiDeclarations.HidD_GetAttributes(safeFileHandle, ref Attributes) == 0 || Attributes.VendorID != vid)
					{
						continue;
					}
					IntPtr PreparsedData = default(IntPtr);
					if (!HidApiDeclarations.HidD_GetPreparsedData(safeFileHandle, ref PreparsedData))
					{
						continue;
					}
					HidApiDeclarations.HIDP_CAPS Capabilities = default(HidApiDeclarations.HIDP_CAPS);
					if (HidApiDeclarations.HidP_GetCaps(PreparsedData, ref Capabilities) == 0)
					{
						continue;
					}
					byte[] array = new byte[128];
					string text = "";
					if (HidApiDeclarations.HidD_GetManufacturerString(safeFileHandle, ref array[0], 128) != 0)
					{
						for (int j = 0; j < 64; j++)
						{
							byte[] array2 = new byte[2]
							{
								array[2 * j],
								array[2 * j + 1]
							};
							if (array2[0] == 0)
							{
								break;
							}
							text += Encoding.Unicode.GetString(array2);
						}
					}
					byte[] array3 = new byte[128];
					string text2 = "";
					if (HidApiDeclarations.HidD_GetProductString(safeFileHandle, ref array3[0], 128) != 0)
					{
						for (int k = 0; k < 64; k++)
						{
							byte[] array4 = new byte[2]
							{
								array3[2 * k],
								array3[2 * k + 1]
							};
							if (array4[0] == 0)
							{
								break;
							}
							text2 += Encoding.Unicode.GetString(array4);
						}
					}
					byte[] array5 = new byte[128];
					string text3 = "";
					if (HidApiDeclarations.HidD_GetSerialNumberString(safeFileHandle, ref array5[0], 128) != 0)
					{
						for (int l = 0; l < 64; l++)
						{
							byte[] array6 = new byte[2]
							{
								array5[2 * l],
								array5[2 * l + 1]
							};
							if (array6[0] == 0)
							{
								break;
							}
							text3 += Encoding.Unicode.GetString(array6);
						}
					}
					linkedList.AddLast(new PIEDevice(current, Attributes.VendorID, Attributes.ProductID, Attributes.VersionNumber, Capabilities.Usage, Capabilities.UsagePage, Capabilities.InputReportByteLength, Capabilities.OutputReportByteLength, text, text2, text3));
				}
				catch (Exception)
				{
				}
				finally
				{
					safeFileHandle.Close();
				}
			}
			PIEDevice[] array7 = new PIEDevice[linkedList.Count];
			linkedList.CopyTo(array7, 0);
			return array7;
		}

		protected long SendSausageCommands(ushort[] commandSequence)
		{
			if (outputReportSize != 2 || hidUsagePage != 1 || hidUsage != 6)
			{
				return 1302L;
			}
			FileIOApiDeclarations.SECURITY_ATTRIBUTES sECURITY_ATTRIBUTES = default(FileIOApiDeclarations.SECURITY_ATTRIBUTES);
			sECURITY_ATTRIBUTES.lpSecurityDescriptor = IntPtr.Zero;
			sECURITY_ATTRIBUTES.bInheritHandle = Convert.ToInt32(value: true);
			sECURITY_ATTRIBUTES.nLength = Marshal.SizeOf((object)sECURITY_ATTRIBUTES);
			IntPtr preexistingHandle = FileIOApiDeclarations.CreateFile(path, 1073741824u, 3u, IntPtr.Zero, 3, 0u, 0);
			SafeFileHandle safeFileHandle = new SafeFileHandle(preexistingHandle, ownsHandle: true);
			if (safeFileHandle.IsInvalid)
			{
				return 1301L;
			}
			FileIOApiDeclarations.OVERLAPPED lpOverlapped = new FileIOApiDeclarations.OVERLAPPED
			{
				hEvent = IntPtr.Zero,
				Offset = 0,
				OffsetHigh = 0
			};
			foreach (ushort num in commandSequence)
			{
				uint lpInBuffer = (uint)(num << 16);
				uint lpBytesReturned = 0u;
				if (!DeviceManagementApiDeclarations.DeviceIoControl(safeFileHandle, 720904u, ref lpInBuffer, 4u, IntPtr.Zero, 0u, ref lpBytesReturned, ref lpOverlapped))
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					return lastWin32Error;
				}
			}
			safeFileHandle.Close();
			return 0L;
		}

		public long ConvertToSplatMode()
		{
			return SendSausageCommands(convertToSplatModeSausages);
		}

		public long SendLEDSausage()
		{
			return SendSausageCommands(ledSausages);
		}

		public static void DongleCheck2(int k0, int k1, int k2, int k3, int a0, int a1, int a2, int a3, out int r0, out int r1, out int r2, out int r3)
		{
			uint num = (uint)(((k0 & 0xFF) << 24) | ((k1 & 0xFF) << 16) | ((k2 & 0xFF) << 8) | (k3 & 0xFF));
			uint num2 = (uint)(((a0 & 0xFF) << 24) | ((a1 & 0xFF) << 16) | ((a2 & 0xFF) << 8) | (a3 & 0xFF));
			ulong num3 = num ^ num2;
			num3 *= num3;
			num3 >>= 16;
			r3 = (int)(num3 & 0xFF);
			num3 >>= 8;
			r2 = (int)(num3 & 0xFF);
			num3 >>= 8;
			r1 = (int)(num3 & 0xFF);
			num3 >>= 8;
			r0 = (int)(num3 & 0xFF);
		}
	}
}
