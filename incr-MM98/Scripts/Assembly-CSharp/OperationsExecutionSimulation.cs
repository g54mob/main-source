using System.Linq;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = "Data/Simulation/Operations Execution", fileName = "OperationsExecutionSimulation")]
public class OperationsExecutionSimulation : ScriptableObject, IIncrementalSimulation
{
	private UIRegistry? _registry;

	public void Registered(UIRegistry? registry)
	{
		_registry = registry;
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		foreach (OperationInstance allActiveOperation in Database.State.Operations.AllActiveOperations)
		{
			allActiveOperation.AdvanceTime(deltaTime);
			_registry?.footer.operations.UpdateOperationProgress(allActiveOperation);
		}
		foreach (OperationInstance item in Database.State.Operations.AllActiveOperations.Where((OperationInstance x) => x.Done).ToList())
		{
			OperationExecuted(item);
		}
	}

	private void OperationExecuted(OperationInstance instance)
	{
		_registry?.footer.operations.ClearOperationProgress(instance);
		if (instance.Operation == Operation.ReleaseGame)
		{
			Database.Commands.LaunchGame();
			return;
		}
		Database.Commands.Operations.CompleteOperation(instance);
		Database.Commands.IRC.Print(IRCSystem.Operation, delegate(LocalizedString localized)
		{
			localized["operation_title"] = instance.Operation.Data().TitleLocalized;
		});
	}
}
