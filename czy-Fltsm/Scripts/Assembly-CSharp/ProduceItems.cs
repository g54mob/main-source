using System;
using System.Collections;
using UnityEngine;

public class ProduceItems : TaskBase
{
	private Producer _producer;

	public override TaskType Type => TaskType.ProduceItem;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		int itterations = 0;
		_producer = project.Target.GetComponent<Producer>();
		_producer.IsProducingItems = true;
		QueuedRecipe queuedRecipe;
		while (_producer.TryReturnRestoredProducingRecipe(out queuedRecipe) || (agent.Community.ProjectRemainsPriority(project, agent) && _producer.TryReturnNextRecipeToProduce(out queuedRecipe)))
		{
			itterations++;
			if (agent.CurrentActivity != queuedRecipe.Activity)
			{
				_producer.AttachWorker(agent);
				agent.UpdateActivity(queuedRecipe.Activity);
			}
			float modifier = agent.Attributes.ReturnAttributeModifier(queuedRecipe.Attribute);
			agent.DrifterRig.MeshAnimator.Animator.SetFloat("Transition Time", queuedRecipe.ProductionTime / modifier);
			_producer.StartProducing(queuedRecipe, modifier);
			new AgentActionEvent(GameEventType.AgentActionStartedWorking, agent, queuedRecipe.Attribute).Dispatch();
			bool flag = _producer.ReturnCanRun();
			while (queuedRecipe.RecipeStage == QueuedRecipe.Stage.Producing && flag && _producer.QueuedRecipes.Contains(queuedRecipe))
			{
				ProductionRecipeProperties properties = queuedRecipe.Recipe.Properties;
				DrifterAttributes.AttributeType attribute = queuedRecipe.Attribute;
				_producer.Produce(queuedRecipe, modifier);
				_producer.AdvanceQueuedRecipeStage(queuedRecipe, !queuedRecipe.RequiresPerson);
				if (!_producer.QueuedRecipes.Contains(queuedRecipe))
				{
					new AgentActionRecipeEvent(GameEventType.AgentActionRecipeProduced, agent, properties, attribute).Dispatch();
				}
				yield return null;
				flag = _producer.ReturnCanRun();
			}
			_producer.StopProducing();
			new AgentActionEvent(GameEventType.AgentActionStoppedWorking, agent, queuedRecipe.Attribute).Dispatch();
			if (agent.Vitals.ReturnHasProject() || !flag)
			{
				break;
			}
		}
		if (itterations == 0)
		{
			Debug.LogException(new Exception("[BUG] ProduceItems task was started, but production loop was never entered!"));
		}
		_producer.DetachWorker(agent, GameManager.AgentManager.AgentParent);
		if (!agent.ReturnNavigator().AttachToTarget(project.Target.GetComponent<Construction>().Target))
		{
			agent.ReturnNavigator().AttachToTarget(agent.ReturnClosestWalkwayConstruction().Target);
		}
		_producer.IsProducingItems = false;
	}

	public override void Stop()
	{
		base.Stop();
		if (_producer != null && _agent != null)
		{
			_producer.IsProducingItems = false;
			_producer.StopProducing();
			_producer.DetachWorker(_agent, GameManager.AgentManager.AgentParent);
			_agent.transform.SetParent(GameManager.AgentManager.AgentParent);
			_agent.ReturnNavigator().AttachToTarget(_agent.ReturnClosestConstruction(onlyFinished: true).Target, overrideCheck: true);
		}
	}

	public override ProjectBlocker ReturnBlockers(Project project)
	{
		ProjectBlocker result = ProjectBlocker.None;
		if (!TryReturnTargetBuildableExtendable<Producer>(project, out var buildableExtendable))
		{
			return ProjectBlocker.BuildingNotAvailable;
		}
		if (!buildableExtendable.ReturnCanRun())
		{
			return ProjectBlocker.EnergyGridFull;
		}
		if (buildableExtendable.IsBlockedByImport || buildableExtendable.QueuedRecipes.IsNullOrEmpty() || !buildableExtendable.TryReturnNextRecipeToProduce(out var _))
		{
			return ProjectBlocker.UnableToProduce;
		}
		return result;
	}

	public override bool ReturnCanFinish(Project project)
	{
		if (TryReturnTargetBuildableExtendable<Producer>(project, out var buildableExtendable))
		{
			return buildableExtendable.ReturnCanRun();
		}
		return true;
	}

	protected override void OnGUI()
	{
		Header("Produce Items", 0, ReturnTypeColor());
		EditorGUI_HelpBox("Produces the recipes that are wait to be produced by the project target.");
	}
}
