using System;
using Unity.Jobs;
using UnityEngine;
using Vectrosity;

[Unity.Jobs.DOTSCompilerGenerated]
internal class __JobReflectionRegistrationOutput__4006067698
{
	public static void CreateJobReflectionData()
	{
		try
		{
			IJobExtensions.EarlyJobInit<VectorLine.Draw3DJob>();
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
