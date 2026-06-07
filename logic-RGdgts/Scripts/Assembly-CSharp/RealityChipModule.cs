using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using UnityEngine;

public class RealityChipModule : Module
{
	protected static class NativeWindowsMethods
	{
		public struct SystemProcessorPerformanceInformation
		{
			public long IdleTime;

			public long KernelTime;

			public long UserTime;

			public long Reserved0;

			public long Reserved1;

			public ulong Reserved2;
		}

		public enum SystemInformationClass
		{
			SystemBasicInformation = 0,
			SystemCpuInformation = 1,
			SystemPerformanceInformation = 2,
			SystemTimeOfDayInformation = 3,
			SystemProcessInformation = 5,
			SystemProcessorPerformanceInformation = 8
		}

		public struct MemoryStatusEx
		{
			public uint Length;

			public uint MemoryLoad;

			public ulong TotalPhysicalMemory;

			public ulong AvailablePhysicalMemory;

			public ulong TotalPageFile;

			public ulong AvailPageFile;

			public ulong TotalVirtual;

			public ulong AvailVirtual;

			public ulong AvailExtendedVirtual;
		}

		[PreserveSig]
		public static extern int NtQuerySystemInformation(SystemInformationClass informationClass, [Out] SystemProcessorPerformanceInformation[] informations, int structSize, out IntPtr returnLength);

		[PreserveSig]
		internal static extern bool GlobalMemoryStatusEx(ref MemoryStatusEx buffer);
	}

	public enum Commands
	{

	}

	private struct LoadedAsset
	{
		public string filename;

		public Asset asset;

		public LoadedAsset(string filename, Asset asset)
		{
			this.filename = null;
			this.asset = null;
		}
	}

	private abstract class Job
	{
		public abstract void Abort();
	}

	private class LoadAudioSampleJob : Job, IAsyncJob<AudioSampleAsset>, IGenericAsyncJob
	{
		private string filename;

		private RealityChipModule module;

		private bool abort;

		public bool isComplete;

		public AudioSampleAsset result;

		public Type ResultType => null;

		public LoadAudioSampleJob(string filename, RealityChipModule module)
		{
		}

		public void Execute()
		{
		}

		public bool IsComplete()
		{
			return false;
		}

		public override void Abort()
		{
		}

		public AudioSampleAsset GetResult()
		{
			return null;
		}
	}

	private class LoadSpriteSheetJob : Job, IAsyncJob<SpriteSheetAsset>, IGenericAsyncJob
	{
		private string filename;

		private RealityChipModule module;

		private Vector2Int gridSize;

		private bool abort;

		public bool isComplete;

		public SpriteSheetAsset result;

		public Type ResultType => null;

		public LoadSpriteSheetJob(string filename, RealityChipModule module, Vector2Int gridSize)
		{
		}

		public void Execute()
		{
		}

		public bool IsComplete()
		{
			return false;
		}

		public override void Abort()
		{
		}

		public SpriteSheetAsset GetResult()
		{
			return null;
		}
	}

	private ModuleProperty totalCpuUsageProperty;

	private ModuleProperty coresCpuUsageProperty;

	private ModuleProperty availableRamProperty;

	private ModuleProperty usedRamProperty;

	private ModuleProperty networkTotalReceivedProperty;

	private ModuleProperty networkTotalSentProperty;

	private ModuleProperty loadedAssetsProperty;

	private float cpuLoad;

	private long[] idleTimes;

	private long[] totalTimes;

	private Dictionary<string, IPv4InterfaceStatistics> networkInterfaceStats;

	private ulong usedMemory;

	private ulong availableMemory;

	private float memoryPercentual;

	private long networkTotalSent;

	private long networkTotalReceived;

	private float lastTime;

	private float updateInterval;

	private uint newId;

	private Dictionary<uint, LoadedAsset> loadedAssets;

	private List<Job> jobs;

	protected override void OnSetupFinished()
	{
	}

	private static bool GetWindowsCpuTimes(out long[] idle, out long[] total)
	{
		idle = null;
		total = null;
		return false;
	}

	private void UpdateInfo()
	{
	}

	public override void OnTurnOn()
	{
	}

	public override void OnTurnOff()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	public override void OnPostTickUpdate()
	{
	}

	private uint GetNewAssetId()
	{
		return 0u;
	}

	private void AddLoadedAsset(string filename, Asset asset)
	{
	}

	private void RemoveLoadedAsset(Asset asset, bool dispose = true)
	{
	}

	private Asset GetLoadedAssetFromFilename(string filename)
	{
		return null;
	}

	private T GetLoadedAssetFromFilename<T>(string filename) where T : Asset
	{
		return null;
	}

	private bool CheckFilename(ref string filename)
	{
		return false;
	}

	private LuaTableContent TimeToTable(DateTime dateTime)
	{
		return null;
	}

	public LuaTable GetDateTime_Script()
	{
		return null;
	}

	public LuaTable GetDateTimeUTC_Script()
	{
		return null;
	}

	public IAsyncJob<AudioSampleAsset> LoadAudioSample_Script(string filename)
	{
		return null;
	}

	public IAsyncJob<SpriteSheetAsset> LoadSpriteSheet_Script(string filename, int spritesWidth, int spritesHeight)
	{
		return null;
	}

	public void UnloadAsset_Script(string filename)
	{
	}

	public string[] ListDirectory_Script(string directory)
	{
		return null;
	}

	public LuaTable GetFileMetadata_Script(string filename)
	{
		return null;
	}
}
