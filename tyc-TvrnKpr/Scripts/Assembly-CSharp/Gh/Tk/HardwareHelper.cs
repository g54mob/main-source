using System;
using System.Runtime.InteropServices;

namespace Gh.Tk
{
	public static class HardwareHelper
	{
		[StructLayout((LayoutKind)0, CharSet = CharSet.Auto)]
		public struct MEMORYSTATUSEX
		{
			public uint dwLength;

			public uint dwMemoryLoad;

			public ulong ullTotalPhys;

			public ulong ullAvailPhys;

			public ulong ullTotalPageFile;

			public ulong ullAvailPageFile;

			public ulong ullTotalVirtual;

			public ulong ullAvailVirtual;

			public ulong ullAvailExtendedVirtual;

			public void Init()
			{
			}
		}

		[StructLayout((LayoutKind)2)]
		private struct SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX
		{
			[FieldOffset(0)]
			public LOGICAL_PROCESSOR_RELATIONSHIP Relationship;

			[FieldOffset(4)]
			public uint Size;
		}

		private enum LOGICAL_PROCESSOR_RELATIONSHIP : uint
		{
			RelationProcessorCore = 0u,
			RelationNumaNode = 1u,
			RelationCache = 2u,
			RelationProcessorPackage = 3u,
			RelationGroup = 4u,
			RelationAll = 65535u
		}

		private struct SYSTEM_POWER_STATUS
		{
			public byte ACLineStatus;

			public byte BatteryFlag;

			public byte BatteryLifePercent;

			public byte Reserved1;

			public int BatteryLifeTime;

			public int BatteryFullLifeTime;
		}

		private const uint FILE_SUPPORTS_USN_JOURNAL = 33554432u;

		private const int ERROR_INSUFFICIENT_BUFFER = 122;

		private static int _physicalCoreCount;

		[PreserveSig]
		public static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

		public static ulong GetFreeRamInMB()
		{
			return 0uL;
		}

		[PreserveSig]
		private static extern bool GetVolumeInformation(string lpRootPathName, IntPtr lpVolumeNameBuffer, uint nVolumeNameSize, IntPtr lpVolumeSerialNumber, IntPtr lpMaximumComponentLength, out uint lpFileSystemFlags, IntPtr lpFileSystemNameBuffer, uint nFileSystemNameSize);

		[PreserveSig]
		private static extern uint GetDriveType(string lpRootPathName);

		[PreserveSig]
		private static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);

		public static bool IsDriveFast(string folderPath)
		{
			return false;
		}

		public static ulong GetFreeSpace(string folderPath)
		{
			return 0uL;
		}

		[PreserveSig]
		private static extern bool GetLogicalProcessorInformationEx(LOGICAL_PROCESSOR_RELATIONSHIP relationshipType, IntPtr buffer, ref uint returnedLength);

		public static int GetPhysicalCoreCount()
		{
			return 0;
		}

		[PreserveSig]
		private static extern bool GetSystemPowerStatus(out SYSTEM_POWER_STATUS sps);

		public static bool HasBattery()
		{
			return false;
		}

		public static bool? IsPluggedIn()
		{
			return null;
		}
	}
}
