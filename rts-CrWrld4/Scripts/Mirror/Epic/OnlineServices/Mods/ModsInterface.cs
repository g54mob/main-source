using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Mods
{
	public sealed class ModsInterface : Handle
	{
		public const int CopymodinfoApiLatest = 1;

		public const int EnumeratemodsApiLatest = 1;

		public const int InstallmodApiLatest = 1;

		public const int ModIdentifierApiLatest = 1;

		public const int ModinfoApiLatest = 1;

		public const int UninstallmodApiLatest = 1;

		public const int UpdatemodApiLatest = 1;

		public ModsInterface()
		{
		}

		public ModsInterface(IntPtr innerHandle)
		{
		}

		public Result CopyModInfo(CopyModInfoOptions options, out ModInfo outEnumeratedMods)
		{
			outEnumeratedMods = null;
			return default(Result);
		}

		public void EnumerateMods(EnumerateModsOptions options, object clientData, OnEnumerateModsCallback completionDelegate)
		{
		}

		public void InstallMod(InstallModOptions options, object clientData, OnInstallModCallback completionDelegate)
		{
		}

		public void UninstallMod(UninstallModOptions options, object clientData, OnUninstallModCallback completionDelegate)
		{
		}

		public void UpdateMod(UpdateModOptions options, object clientData, OnUpdateModCallback completionDelegate)
		{
		}

		internal static void OnEnumerateModsCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnInstallModCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnUninstallModCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnUpdateModCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern Result EOS_Mods_CopyModInfo(IntPtr handle, IntPtr options, ref IntPtr outEnumeratedMods);

		[PreserveSig]
		internal static extern void EOS_Mods_EnumerateMods(IntPtr handle, IntPtr options, IntPtr clientData, OnEnumerateModsCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Mods_InstallMod(IntPtr handle, IntPtr options, IntPtr clientData, OnInstallModCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Mods_ModInfo_Release(IntPtr modInfo);

		[PreserveSig]
		internal static extern void EOS_Mods_UninstallMod(IntPtr handle, IntPtr options, IntPtr clientData, OnUninstallModCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Mods_UpdateMod(IntPtr handle, IntPtr options, IntPtr clientData, OnUpdateModCallbackInternal completionDelegate);
	}
}
