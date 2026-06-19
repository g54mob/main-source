#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using System.Diagnostics;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using MessagePack;
using MessagePack.Resolvers;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	[AddComponentMenu("TH20/Character Behavior Tree")]
	public class CharacterBehaviorTree : BehaviorTree
	{
		public class SavedState
		{
			public List<KeyValuePair<string, object>> variables;

			public ByteArray serialisedInternalBTSavedState;
		}

		[MessagePackObject(false)]
		public class InternalBTSavedState
		{
			[Key(0)]
			public Dictionary<ulong, byte[]> tasks;

			[Key(1)]
			public ulong[][] activeStack;

			[Key(2)]
			public List<TaskStatus> nonInstantTaskStatus;

			[Key(3)]
			public ulong[] interruptionIndex;

			[Key(4)]
			public ConditionalReevaluateWithTaskIDs[] conditionalReevaluate;

			[Key(5)]
			public Dictionary<ulong, ConditionalReevaluateWithTaskIDs> conditionalReevaluateMap;

			[Key(6)]
			public ulong[] parentReevaluate;

			[Key(7)]
			public string behaviourName;
		}

		[MessagePackObject(false)]
		public struct ConditionalReevaluateWithTaskIDs
		{
			[Key(0)]
			public ulong ID;

			[Key(1)]
			public TaskStatus taskStatus;

			[Key(2)]
			public ulong compositeID;

			[Key(3)]
			public int stackIndex;
		}

		public delegate void FinishedEvent(bool success, GameObject owner);

		public FinishedEvent OnFinishedEvent;

		public CharacterBehaviorTree()
		{
			base.OnBehaviorEnd += delegate
			{
				if (OnFinishedEvent != null && base.gameObject.activeSelf)
				{
					bool success = base.ExecutionStatus == TaskStatus.Success;
					OnFinishedEvent(success, base.gameObject);
				}
			};
		}

		public override string ToString()
		{
			if (!(base.ExternalBehavior != null))
			{
				return "NULL";
			}
			return base.ExternalBehavior.name;
		}

		public void SetVariable(string variableName, object value)
		{
			SharedVariable variable = GetVariable(variableName);
			if (variable != null)
			{
				SetVariableValue(variableName, value, variable);
			}
		}

		public SavedState Save()
		{
			SavedState savedState = new SavedState();
			savedState.variables = new List<KeyValuePair<string, object>>();
			foreach (SharedVariable allVariable in GetAllVariables())
			{
				object value = allVariable.GetValue();
				if (value is ObjectRefBase objectRefBase)
				{
					objectRefBase.NullIfDestroyed();
				}
				savedState.variables.Add(new KeyValuePair<string, object>(allVariable.Name, value));
			}
			BehaviorManager.BehaviorTree behaviorTree = BehaviorManager.instance.GetBehaviorTree(this);
			InternalBTSavedState internalBTSavedState = new InternalBTSavedState();
			if (behaviorTree != null)
			{
				List<ulong> list = GenerateIndexToCombinedIDMapping(behaviorTree);
				internalBTSavedState.nonInstantTaskStatus = behaviorTree.nonInstantTaskStatus;
				internalBTSavedState.activeStack = new ulong[behaviorTree.activeStack.Count][];
				for (int i = 0; i < behaviorTree.activeStack.Count; i++)
				{
					Stack<int> stack = behaviorTree.activeStack[i];
					ulong[] array = new ulong[stack.Count];
					int num = 0;
					foreach (int item in stack)
					{
						array[num] = list[item];
						num++;
					}
					internalBTSavedState.activeStack[i] = array;
				}
				internalBTSavedState.interruptionIndex = new ulong[behaviorTree.interruptionIndex.Count];
				for (int j = 0; j < behaviorTree.interruptionIndex.Count; j++)
				{
					internalBTSavedState.interruptionIndex[j] = IndexToIDOrInvalid(behaviorTree.interruptionIndex[j], list);
				}
				internalBTSavedState.parentReevaluate = new ulong[behaviorTree.parentReevaluate.Count];
				for (int k = 0; k < behaviorTree.parentReevaluate.Count; k++)
				{
					internalBTSavedState.parentReevaluate[k] = list[behaviorTree.parentReevaluate[k]];
				}
				internalBTSavedState.conditionalReevaluate = new ConditionalReevaluateWithTaskIDs[behaviorTree.conditionalReevaluate.Count];
				for (int l = 0; l < behaviorTree.conditionalReevaluate.Count; l++)
				{
					BehaviorManager.BehaviorTree.ConditionalReevaluate conditionalReevaluate = behaviorTree.conditionalReevaluate[l];
					internalBTSavedState.conditionalReevaluate[l] = new ConditionalReevaluateWithTaskIDs
					{
						ID = list[conditionalReevaluate.index],
						taskStatus = conditionalReevaluate.taskStatus,
						compositeID = IndexToIDOrInvalid(conditionalReevaluate.compositeIndex, list),
						stackIndex = conditionalReevaluate.stackIndex
					};
				}
				internalBTSavedState.conditionalReevaluateMap = new Dictionary<ulong, ConditionalReevaluateWithTaskIDs>(behaviorTree.conditionalReevaluateMap.Count);
				foreach (KeyValuePair<int, BehaviorManager.BehaviorTree.ConditionalReevaluate> item2 in behaviorTree.conditionalReevaluateMap)
				{
					internalBTSavedState.conditionalReevaluateMap.Add(list[item2.Key], new ConditionalReevaluateWithTaskIDs
					{
						ID = list[item2.Value.index],
						taskStatus = item2.Value.taskStatus,
						compositeID = IndexToIDOrInvalid(item2.Value.compositeIndex, list),
						stackIndex = item2.Value.stackIndex
					});
				}
				internalBTSavedState.tasks = new Dictionary<ulong, byte[]>(behaviorTree.taskList.Count);
				for (int m = 0; m < behaviorTree.taskList.Count; m++)
				{
					Task.BaseSaveState baseSaveState = behaviorTree.taskList[m].CreateSaveState();
					if (baseSaveState != null)
					{
						byte[] value2 = MessagePackSerializer.Serialize((object)baseSaveState, TypelessContractlessStandardResolver.Instance);
						internalBTSavedState.tasks.Add(list[m], value2);
					}
				}
				internalBTSavedState.behaviourName = base.ExternalBehavior.name;
				savedState.serialisedInternalBTSavedState.Bytes = MessagePackSerializer.Serialize(internalBTSavedState);
			}
			return savedState;
		}

		public void Load(SavedState save)
		{
			bool num = base.isActiveAndEnabled;
			EnableBehavior();
			if (!num)
			{
				DisableBehavior();
			}
			foreach (KeyValuePair<string, object> variable in save.variables)
			{
				SetVariable(variable.Key, variable.Value);
			}
			BehaviorManager.BehaviorTree behaviorTree = BehaviorManager.instance.GetBehaviorTree(this);
			if (behaviorTree == null || save.serialisedInternalBTSavedState.Bytes == null)
			{
				return;
			}
			InternalBTSavedState internalBTSavedState = MessagePackSerializer.Deserialize<InternalBTSavedState>(save.serialisedInternalBTSavedState.Bytes);
			if (internalBTSavedState.behaviourName != null && internalBTSavedState.behaviourName != base.ExternalBehavior.name)
			{
				Logging.Error("Mismatched behaviour trees when loading character BT - saved data is for {0} but BT is currently {1}", internalBTSavedState.behaviourName, base.ExternalBehavior.name);
			}
			Dictionary<ulong, int> dictionary = GeneratCombinedIDToIndexMapping(behaviorTree);
			foreach (KeyValuePair<ulong, byte[]> task2 in internalBTSavedState.tasks)
			{
				ulong key = task2.Key;
				if (!dictionary.ContainsKey(key))
				{
					Logging.Error("Serialised CharacterBehaviourTree contains task with ID that doesn't exist in the BT asset. ID: {0}. BT: {1}. Bailing out early.", key, base.ExternalBehavior.name);
					return;
				}
			}
			behaviorTree.nonInstantTaskStatus = internalBTSavedState.nonInstantTaskStatus;
			behaviorTree.activeStack = new List<Stack<int>>(internalBTSavedState.activeStack.Length);
			for (int i = 0; i < internalBTSavedState.activeStack.Length; i++)
			{
				ulong[] array = internalBTSavedState.activeStack[i];
				Stack<int> stack = new Stack<int>(array.Length);
				for (int num2 = array.Length - 1; num2 >= 0; num2--)
				{
					stack.Push(dictionary[array[num2]]);
				}
				behaviorTree.activeStack.Add(stack);
			}
			behaviorTree.interruptionIndex = new List<int>(internalBTSavedState.interruptionIndex.Length);
			for (int j = 0; j < internalBTSavedState.interruptionIndex.Length; j++)
			{
				behaviorTree.interruptionIndex.Add(IDToIndexOrInvalid(internalBTSavedState.interruptionIndex[j], dictionary));
			}
			behaviorTree.parentReevaluate = new List<int>(internalBTSavedState.parentReevaluate.Length);
			for (int k = 0; k < internalBTSavedState.parentReevaluate.Length; k++)
			{
				behaviorTree.parentReevaluate.Add(dictionary[internalBTSavedState.parentReevaluate[k]]);
			}
			behaviorTree.conditionalReevaluate = new List<BehaviorManager.BehaviorTree.ConditionalReevaluate>(internalBTSavedState.conditionalReevaluate.Length);
			for (int l = 0; l < internalBTSavedState.conditionalReevaluate.Length; l++)
			{
				ConditionalReevaluateWithTaskIDs conditionalReevaluateWithTaskIDs = internalBTSavedState.conditionalReevaluate[l];
				behaviorTree.conditionalReevaluate.Add(new BehaviorManager.BehaviorTree.ConditionalReevaluate
				{
					index = dictionary[conditionalReevaluateWithTaskIDs.ID],
					taskStatus = conditionalReevaluateWithTaskIDs.taskStatus,
					compositeIndex = IDToIndexOrInvalid(conditionalReevaluateWithTaskIDs.compositeID, dictionary),
					stackIndex = conditionalReevaluateWithTaskIDs.stackIndex
				});
			}
			foreach (KeyValuePair<ulong, ConditionalReevaluateWithTaskIDs> item in internalBTSavedState.conditionalReevaluateMap)
			{
				behaviorTree.conditionalReevaluateMap.Add(dictionary[item.Key], new BehaviorManager.BehaviorTree.ConditionalReevaluate
				{
					index = dictionary[item.Value.ID],
					taskStatus = item.Value.taskStatus,
					compositeIndex = IDToIndexOrInvalid(item.Value.compositeID, dictionary),
					stackIndex = item.Value.stackIndex
				});
			}
			foreach (KeyValuePair<ulong, byte[]> task3 in internalBTSavedState.tasks)
			{
				ulong key2 = task3.Key;
				byte[] value = task3.Value;
				Task task = behaviorTree.taskList[dictionary[key2]];
				Task.BaseSaveState baseSaveState = (Task.BaseSaveState)MessagePackSerializer.Deserialize<object>(value, TypelessContractlessStandardResolver.Instance);
				task.RestoreFromSaveState(baseSaveState);
			}
			foreach (Task task4 in behaviorTree.taskList)
			{
				if (task4 is CharacterAction characterAction)
				{
					characterAction.RestoreFromSave();
				}
				if (task4 is CharacterDecorator characterDecorator)
				{
					characterDecorator.RestoreFromSave();
				}
			}
		}

		private static List<ulong> GenerateIndexToCombinedIDMapping(BehaviorManager.BehaviorTree internalBehaviorTree)
		{
			List<ulong> list = new List<ulong>(internalBehaviorTree.taskList.Count);
			for (int i = 0; i < internalBehaviorTree.taskList.Count; i++)
			{
				Task task = internalBehaviorTree.taskList[i];
				ulong item = GenerateTaskCombinedID(internalBehaviorTree, i, task);
				list.Add(item);
			}
			return list;
		}

		private static Dictionary<ulong, int> GeneratCombinedIDToIndexMapping(BehaviorManager.BehaviorTree internalBehaviorTree)
		{
			Dictionary<ulong, int> dictionary = new Dictionary<ulong, int>(internalBehaviorTree.taskList.Count);
			for (int i = 0; i < internalBehaviorTree.taskList.Count; i++)
			{
				Task task = internalBehaviorTree.taskList[i];
				ulong key = GenerateTaskCombinedID(internalBehaviorTree, i, task);
				dictionary.Add(key, i);
			}
			return dictionary;
		}

		private static ulong GenerateTaskCombinedID(BehaviorManager.BehaviorTree internalBehaviorTree, int index, Task task)
		{
			ulong num = 0uL;
			num |= (ushort)internalBehaviorTree.taskList[index].ID;
			if (task.IndexOfParentOfOwningBehaviourReferenceNode >= 0)
			{
				num |= (ulong)(ushort)task.IdOfOwningBehaviourReferenceNode << 8;
				Task task2 = internalBehaviorTree.taskList[task.IndexOfParentOfOwningBehaviourReferenceNode];
				if (task2.IndexOfParentOfOwningBehaviourReferenceNode >= 0)
				{
					num |= (ulong)(ushort)task2.IdOfOwningBehaviourReferenceNode << 16;
					Task task3 = internalBehaviorTree.taskList[task2.IndexOfParentOfOwningBehaviourReferenceNode];
					if (task3.IndexOfParentOfOwningBehaviourReferenceNode >= 0)
					{
						num |= (ulong)(ushort)task3.IdOfOwningBehaviourReferenceNode << 24;
						_ = internalBehaviorTree.taskList[task3.IndexOfParentOfOwningBehaviourReferenceNode];
					}
				}
			}
			return num;
		}

		private static ulong IndexToIDOrInvalid(int index, List<ulong> indexToIdMapping)
		{
			if (index >= 0)
			{
				return indexToIdMapping[index];
			}
			return ulong.MaxValue;
		}

		private static int IDToIndexOrInvalid(ulong id, Dictionary<ulong, int> IdToIndexMapping)
		{
			if (id != ulong.MaxValue)
			{
				return IdToIndexMapping[id];
			}
			return -1;
		}

		[Conditional("PROFILE_CHARACTER_BT_SAVE_LOAD")]
		private static void ProfilerBeginSample(string name)
		{
		}

		[Conditional("PROFILE_CHARACTER_BT_SAVE_LOAD")]
		private static void ProfilerEndSample()
		{
		}
	}
}
