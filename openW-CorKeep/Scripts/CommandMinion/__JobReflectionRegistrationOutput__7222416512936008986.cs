using System;
using CommandMinion;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__7222416512936008986
{
	public static void CreateJobReflectionData()
	{
		try
		{
			JobChunkExtensions.EarlyJobInit<SelectEnemyToAttackForMinionCommandSystem.RecordMinionJob>();
			JobChunkExtensions.EarlyJobInit<SelectEnemyToAttackForMinionCommandSystem.SelectEnemyToAttackForMinionCommandJob>();
			JobChunkExtensions.EarlyJobInit<SelectEnemyToAttackForMinionCommandSystem.ClearTooFarAwayCommandMinionTargetJob>();
		}
		catch (Exception ex)
		{
			EarlyInitHelpers.JobReflectionDataCreationFailed(ex);
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
