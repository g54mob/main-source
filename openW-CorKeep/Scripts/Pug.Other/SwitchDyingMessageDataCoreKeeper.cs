using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SwitchDyingMessageDataCoreKeeper
{
	[Tooltip("Used to determine the version of the data struct between crash reports.")]
	public int DataVersion;

	[Tooltip("The duration in seconds of the current in-game session.")]
	public uint CurrentSessionDurationSeconds;

	[Tooltip("The total uptime in seconds of the game process.")]
	public uint ProcessUptimeSeconds;

	[Tooltip("The amount of client-only in-game sessions the user has started during the game process.")]
	public byte ClientSessionsCount;

	[Tooltip("The amount of hosted in-game sessions the user has started during the game process.")]
	public byte HostSessionsCount;

	[Tooltip("The current player count.")]
	public byte CurrentSessionPlayerCount;

	[Tooltip("The amount of free memory in bytes.")]
	public long FreeMemoryBytes;

	[Tooltip("Which bosses have been defeated in the current world.")]
	public int BossesDefeatedCount;

	[Tooltip("The serialization size of the current world.")]
	public uint WorldSerializationBufferSizeBytes;

	[Tooltip("Various boolean flags for the current session.")]
	public DyingMessageSessionFlags SessionFlags;

	[Tooltip("The world seed number.")]
	public uint WorldSeed;

	[Tooltip("The free space in bytes in the user's save data area (maximum 64MB - journaling size, set in NMETA).")]
	public ulong SaveDataFreeSpaceBytes;

	[Tooltip("The world generation type for the current active world.")]
	public WorldGenerationType WorldGenerationType;

	[Header("Most objects in pool currently")]
	[Tooltip("Information for the largest pooled object pools (by current total count).")]
	public MemoryManager.PoolObjectInfo PoolObjectInfoByTotalCount_1;

	[Tooltip("Information for the largest pooled object pools (by current total count).")]
	public MemoryManager.PoolObjectInfo PoolObjectInfoByTotalCount_2;

	[Tooltip("Information for the largest pooled object pools (by current total count).")]
	public MemoryManager.PoolObjectInfo PoolObjectInfoByTotalCount_3;

	[Tooltip("Information for the largest pooled object pools (by current total count).")]
	public MemoryManager.PoolObjectInfo PoolObjectInfoByTotalCount_4;

	[Tooltip("Information for the largest pooled object pools (by current total count).")]
	public MemoryManager.PoolObjectInfo PoolObjectInfoByTotalCount_5;

	[Header("Most allocations/deallocations")]
	[Tooltip("Information for the largest pooled object pools (by the amount of allocations + deallocations in total).")]
	public MemoryManager.PoolObjectInfo PoolObjectInfoByAllocations_1;

	[Tooltip("Information for the largest pooled object pools (by the amount of allocations + deallocations in total).")]
	public MemoryManager.PoolObjectInfo PoolObjectInfoByAllocations_2;

	[Tooltip("Information for the largest pooled object pools (by the amount of allocations + deallocations in total).")]
	public MemoryManager.PoolObjectInfo PoolObjectInfoByAllocations_3;

	[Tooltip("Information for the largest pooled object pools (by the amount of allocations + deallocations in total).")]
	public MemoryManager.PoolObjectInfo PoolObjectInfoByAllocations_4;

	[Tooltip("Information for the largest pooled object pools (by the amount of allocations + deallocations in total).")]
	[Space]
	public MemoryManager.PoolObjectInfo PoolObjectInfoByAllocations_5;

	[Tooltip("The total amount of pool object allocations across all PoolSystems.")]
	public uint PooledObjectTotalAllocations;

	[Tooltip("The total amount of pool object deallocations across all PoolSystems.")]
	public uint PooledObjectTotalDeallocations;

	[Tooltip("The amount of SubMapCD component data in the server world.")]
	public int ServerWorldSubMapCount;

	public bool IsValid()
	{
		return FreeMemoryBytes > 0;
	}

	public unsafe override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = sizeof(SwitchDyingMessageDataCoreKeeper);
		stringBuilder.AppendLine(string.Format("{0} ({1} bytes):", "SwitchDyingMessageDataCoreKeeper", num));
		FieldInfo[] fields = typeof(SwitchDyingMessageDataCoreKeeper).GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			stringBuilder.AppendLine($"\t{fieldInfo.Name} - {fieldInfo.GetValue(this)}");
		}
		return stringBuilder.ToString();
	}
}
