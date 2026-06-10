using System;
using System.Collections.Generic;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Services;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public static class IGraphAssignableExtensions
	{
		public static Graph CheckInstance(this IGraphAssignable assignable)
		{
			if (assignable.subGraph == assignable.currentInstance)
			{
				return assignable.currentInstance;
			}
			Graph value = null;
			if (assignable.instances == null)
			{
				assignable.instances = new Dictionary<Graph, Graph>();
			}
			if (!assignable.instances.TryGetValue(assignable.subGraph, out value))
			{
				value = Graph.Clone(assignable.subGraph, assignable.graph);
				assignable.instances[assignable.subGraph] = value;
			}
			assignable.subGraph = value;
			assignable.currentInstance = value;
			return value;
		}

		public static bool TryStartSubGraph(this IGraphAssignable assignable, Component agent, Action<bool> callback = null)
		{
			assignable.currentInstance = assignable.CheckInstance();
			if (assignable.currentInstance != null)
			{
				assignable.TryWriteAndBindMappedVariables();
				assignable.currentInstance.StartGraph(agent, assignable.graph.blackboard.parent, Graph.UpdateMode.Manual, delegate(bool result)
				{
					if (assignable.status == Status.Running)
					{
						assignable.TryReadAndUnbindMappedVariables();
					}
					if (callback != null)
					{
						callback(result);
					}
				});
				return true;
			}
			return false;
		}

		public static bool TryStopSubGraph(this IGraphAssignable assignable)
		{
			if (assignable.currentInstance != null)
			{
				assignable.currentInstance.Stop();
				return true;
			}
			return false;
		}

		public static bool TryPauseSubGraph(this IGraphAssignable assignable)
		{
			if (assignable.currentInstance != null)
			{
				assignable.currentInstance.Pause();
				return true;
			}
			return false;
		}

		public static bool TryResumeSubGraph(this IGraphAssignable assignable)
		{
			if (assignable.currentInstance != null)
			{
				assignable.currentInstance.Resume();
				return true;
			}
			return false;
		}

		public static bool TryUpdateSubGraph(this IGraphAssignable assignable)
		{
			if (assignable.currentInstance != null && assignable.currentInstance.isRunning)
			{
				assignable.currentInstance.UpdateGraph(assignable.graph.deltaTime);
				return true;
			}
			return false;
		}

		public static void TryWriteAndBindMappedVariables(this IGraphAssignable assignable)
		{
			if (!assignable.currentInstance.allowBlackboardOverrides || assignable.variablesMap == null)
			{
				return;
			}
			for (int i = 0; i < assignable.variablesMap.Count; i++)
			{
				BBMappingParameter bBMappingParameter = assignable.variablesMap[i];
				if (bBMappingParameter.isNone)
				{
					continue;
				}
				Variable variableByID = assignable.currentInstance.blackboard.GetVariableByID(bBMappingParameter.targetSubGraphVariableID);
				if (variableByID != null && variableByID.isExposedPublic && !variableByID.isPropertyBound)
				{
					if (bBMappingParameter.canWrite)
					{
						variableByID.value = bBMappingParameter.value;
					}
					if (bBMappingParameter.canRead)
					{
						variableByID.onValueChanged -= bBMappingParameter.SetValue;
						variableByID.onValueChanged += bBMappingParameter.SetValue;
					}
				}
			}
		}

		public static void TryReadAndUnbindMappedVariables(this IGraphAssignable assignable)
		{
			if (!assignable.currentInstance.allowBlackboardOverrides || assignable.variablesMap == null)
			{
				return;
			}
			for (int i = 0; i < assignable.variablesMap.Count; i++)
			{
				BBMappingParameter bBMappingParameter = assignable.variablesMap[i];
				if (bBMappingParameter.isNone)
				{
					continue;
				}
				Variable variableByID = assignable.currentInstance.blackboard.GetVariableByID(bBMappingParameter.targetSubGraphVariableID);
				if (variableByID != null && variableByID.isExposedPublic && !variableByID.isPropertyBound)
				{
					if (bBMappingParameter.canRead)
					{
						bBMappingParameter.value = variableByID.value;
					}
					variableByID.onValueChanged -= bBMappingParameter.SetValue;
				}
			}
		}

		public static void ValidateSubGraphAndParameters(this IGraphAssignable assignable)
		{
			if (!Threader.applicationIsPlaying && (assignable.subGraph == null || !assignable.subGraph.allowBlackboardOverrides || assignable.subGraph.blackboard.variables.Count == 0))
			{
				assignable.variablesMap = null;
			}
		}
	}
}
