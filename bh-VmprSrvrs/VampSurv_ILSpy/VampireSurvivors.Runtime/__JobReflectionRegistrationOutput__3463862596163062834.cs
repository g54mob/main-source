using Unity.Jobs;
using VampireSurvivors.Framework;

internal class __JobReflectionRegistrationOutput__3463862596163062834
{
	public static void CreateJobReflectionData()
	{
		IJobParallelForExtensions.ParallelForJobStruct<EnemiesManager.EnemyVelocityCalcJob>.Initialize();
	}

	public static void EarlyInit()
	{
		CreateJobReflectionData();
	}
}
