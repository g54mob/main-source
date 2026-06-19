using Unity.Entities;
using UnityEngine.Scripting;

[DisableAutoCreation]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(SerializationSystemGroup))]
public class SaveClientSystem : SystemBase
{
	private float timeUntilSave;

	[Preserve]
	protected override void OnCreate()
	{
		if (CommandLineArgs.Has("-disableautosave"))
		{
			base.Enabled = false;
		}
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		timeUntilSave -= base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		if (timeUntilSave < 0f)
		{
			timeUntilSave = ((PlatformConfiguration.Instance != null) ? ((float)PlatformConfiguration.Instance.SessionConfiguration.AutoSaveInterval) : 60f);
			Manager.saves.WriteCharacter();
		}
	}

	[Preserve]
	public SaveClientSystem()
	{
	}
}
