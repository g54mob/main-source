using System.Collections;
using UnityEngine;

public class GenerateEnergy : TaskBase
{
	private EnergyManualProducer _producer;

	public override TaskType Type => TaskType.ManualEnergyGeneration;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		_producer = project.Target.GetComponent<EnergyManualProducer>();
		_producer.StartGenerating(agent);
		new AgentActionEvent(GameEventType.AgentActionStartedWorking, agent, _producer.GenerationAttribute).Dispatch();
		float timer = 0f;
		while (_producer.ReturnCanRun())
		{
			if (_producer.EnergyGrid.Storages.Count > 0)
			{
				if (_producer.EnergyGrid.IsFull)
				{
					break;
				}
			}
			else if (!_producer.EnergyGrid.IsHighestPriority(_producer) || !_producer.EnergyGrid.ReturnRequiresEnergyFromProducer(_producer))
			{
				break;
			}
			timer += Time.deltaTime;
			if (timer >= 1f)
			{
				new AgentActionEvent(GameEventType.AgentActionGeneratedEnergy, agent, _producer.GenerationAttribute).Dispatch();
				timer = 0f;
			}
			yield return null;
		}
		_producer.EndGenerating(agent);
		new AgentActionEvent(GameEventType.AgentActionStoppedWorking, agent, _producer.GenerationAttribute).Dispatch();
	}

	public override void Stop()
	{
		if (_producer != null && _agent != null)
		{
			_producer.EndGenerating(_agent);
		}
	}

	public override ProjectBlocker ReturnBlockers(Project project)
	{
		if (!TryReturnTargetBuildableExtendable<EnergyManualProducer>(project, out var buildableExtendable) || !buildableExtendable.IsHighestPriority())
		{
			return ProjectBlocker.BuildingNotAvailable;
		}
		if (buildableExtendable.EnergyGrid.ReturnRequiresEnergyFromProducer(buildableExtendable))
		{
			return ProjectBlocker.None;
		}
		if (buildableExtendable.EnergyGrid.IsFull)
		{
			return ProjectBlocker.EnergyGridRequiresNoEnergy;
		}
		return ProjectBlocker.Idle;
	}

	protected override void OnGUI()
	{
		Header("Generate Energy", 1, Color.blue);
		EditorGUI_HelpBox("Generates energy at a energy producer for the duration.");
	}
}
