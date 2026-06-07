using System.Collections;
using Bolt;
using Ludiq;
using UnityEngine;

[UnitTitle("Tutorial Car Spawn")]
[UnitSubtitle("Initiate car spawning from SpawnCarsTutorial object")]
[UnitCategory("Trains")]
[TypeIcon(typeof(TrainCar))]
public class TutorialCarSpawnUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput spawnedTrigger;

	[DoNotSerialize]
	public ValueInput spawnerObject;

	[DoNotSerialize]
	public ValueInput derailCargoInput;

	[DoNotSerialize]
	public ValueInput bothOnCargoTrackInput;

	[DoNotSerialize]
	public ValueOutput spawnedLoco;

	[DoNotSerialize]
	public ValueOutput spawnedCargo;

	private new GraphReference graph;

	protected override void Definition()
	{
		spawnedTrigger = ControlOutput("Spawned");
		spawnerObject = ValueInput<GameObject>("Spawner", null);
		derailCargoInput = ValueInput("Derail cargo", @default: true);
		bothOnCargoTrackInput = ValueInput("Both on cargo track", @default: false);
		spawnedLoco = ValueOutput<GameObject>("Spawned loco", null);
		spawnedCargo = ValueOutput<GameObject>("Spawned cargo", null);
		inputTrigger = ControlInputCoroutine("Input", Routine);
	}

	private IEnumerator Routine(Flow flow)
	{
		GameObject value = flow.GetValue<GameObject>(spawnerObject);
		graph = flow.stack.AsReference();
		bool value2 = flow.GetValue<bool>(derailCargoInput);
		bool value3 = flow.GetValue<bool>(bothOnCargoTrackInput);
		bool spawned = false;
		SpawnCarsTutorial spawner = value.GetComponent<SpawnCarsTutorial>();
		spawner.SpawnTutorialCars(value2, value3, delegate
		{
			spawned = true;
		});
		while (!spawned)
		{
			yield return null;
		}
		spawner.spawnedLoco.GetComponentInChildren<TrainPhysicsLod>().LockHighestLOD();
		spawner.spawnedOtherCar.GetComponentInChildren<TrainPhysicsLod>().LockHighestLOD();
		flow.SetValue(spawnedLoco, spawner.spawnedLoco.gameObject);
		flow.SetValue(spawnedCargo, spawner.spawnedOtherCar.gameObject);
		yield return spawnedTrigger;
	}
}
