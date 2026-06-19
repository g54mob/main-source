using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace BehaviorDesigner.Runtime
{
	[AddComponentMenu("Behavior Designer/Behavior Manager")]
	public class BehaviorManager : MonoBehaviour
	{
		public enum ExecutionsPerTickType
		{
			NoDuplicates = 0,
			Count = 1
		}

		public class BehaviorTree
		{
			public class ConditionalReevaluate
			{
				public int index;

				public TaskStatus taskStatus;

				public int compositeIndex = -1;

				public int stackIndex = -1;

				public void Initialize(int i, TaskStatus status, int stack, int composite)
				{
					index = i;
					taskStatus = status;
					stackIndex = stack;
					compositeIndex = composite;
				}
			}

			public List<Task> taskList = new List<Task>();

			public List<int> parentIndex = new List<int>();

			public List<List<int>> childrenIndex = new List<List<int>>();

			public List<int> relativeChildIndex = new List<int>();

			public List<Stack<int>> activeStack = new List<Stack<int>>();

			public List<TaskStatus> nonInstantTaskStatus = new List<TaskStatus>();

			public List<int> interruptionIndex = new List<int>();

			public List<ConditionalReevaluate> conditionalReevaluate = new List<ConditionalReevaluate>();

			public Dictionary<int, ConditionalReevaluate> conditionalReevaluateMap = new Dictionary<int, ConditionalReevaluate>();

			public List<int> parentReevaluate = new List<int>();

			public List<int> parentCompositeIndex = new List<int>();

			public List<List<int>> childConditionalIndex = new List<List<int>>();

			public int executionCount;

			public Behavior behavior;

			public bool destroyBehavior;

			public void Initialize(Behavior b)
			{
				behavior = b;
				for (int num = childrenIndex.Count - 1; num > -1; num--)
				{
					ObjectPool.Return(childrenIndex[num]);
				}
				for (int num2 = activeStack.Count - 1; num2 > -1; num2--)
				{
					ObjectPool.Return(activeStack[num2]);
				}
				for (int num3 = childConditionalIndex.Count - 1; num3 > -1; num3--)
				{
					ObjectPool.Return(childConditionalIndex[num3]);
				}
				taskList.Clear();
				parentIndex.Clear();
				childrenIndex.Clear();
				relativeChildIndex.Clear();
				activeStack.Clear();
				nonInstantTaskStatus.Clear();
				interruptionIndex.Clear();
				conditionalReevaluate.Clear();
				conditionalReevaluateMap.Clear();
				parentReevaluate.Clear();
				parentCompositeIndex.Clear();
				childConditionalIndex.Clear();
			}
		}

		public enum ThirdPartyObjectType
		{
			PlayMaker = 0,
			uScript = 1,
			DialogueSystem = 2,
			uSequencer = 3,
			ICode = 4
		}

		public class ThirdPartyTask
		{
			private Task task;

			private ThirdPartyObjectType thirdPartyObjectType;

			public Task Task
			{
				get
				{
					return task;
				}
				set
				{
					task = value;
				}
			}

			public ThirdPartyObjectType ThirdPartyObjectType => thirdPartyObjectType;

			public void Initialize(Task t, ThirdPartyObjectType objectType)
			{
				task = t;
				thirdPartyObjectType = objectType;
			}
		}

		public class ThirdPartyTaskComparer : IEqualityComparer<ThirdPartyTask>
		{
			public bool Equals(ThirdPartyTask a, ThirdPartyTask b)
			{
				if (a == null)
				{
					return false;
				}
				if (b == null)
				{
					return false;
				}
				return a.Task.Equals(b.Task);
			}

			public int GetHashCode(ThirdPartyTask obj)
			{
				return obj?.Task.GetHashCode() ?? 0;
			}
		}

		public class TaskAddData
		{
			public class OverrideFieldValue
			{
				private object value;

				private int depth;

				public object Value => value;

				public int Depth => depth;

				public void Initialize(object v, int d)
				{
					value = v;
					depth = d;
				}
			}

			public bool fromExternalTask;

			public ParentTask parentTask;

			public int parentIndex = -1;

			public int depth;

			public int compositeParentIndex = -1;

			public Dictionary<string, OverrideFieldValue> overrideFields;

			public HashSet<object> overiddenFields = new HashSet<object>();

			public int errorTask = -1;

			public string errorTaskName = "";

			public void Initialize()
			{
				if (overrideFields != null)
				{
					foreach (KeyValuePair<string, OverrideFieldValue> overrideField in overrideFields)
					{
						ObjectPool.Return(overrideField);
					}
				}
				ObjectPool.Return(overrideFields);
				fromExternalTask = false;
				parentTask = null;
				parentIndex = -1;
				depth = 0;
				compositeParentIndex = -1;
				overrideFields = null;
			}
		}

		public static BehaviorManager instance;

		[SerializeField]
		private UpdateIntervalType updateInterval;

		[SerializeField]
		private float updateIntervalSeconds;

		[SerializeField]
		private ExecutionsPerTickType executionsPerTick;

		[SerializeField]
		private int maxTaskExecutionsPerTick = 100;

		private WaitForSeconds updateWait;

		private List<BehaviorTree> behaviorTrees = new List<BehaviorTree>();

		private Dictionary<Behavior, BehaviorTree> pausedBehaviorTrees = new Dictionary<Behavior, BehaviorTree>();

		private Dictionary<Behavior, BehaviorTree> behaviorTreeMap = new Dictionary<Behavior, BehaviorTree>();

		private List<int> conditionalParentIndexes = new List<int>();

		private Dictionary<object, ThirdPartyTask> objectTaskMap = new Dictionary<object, ThirdPartyTask>();

		private Dictionary<ThirdPartyTask, object> taskObjectMap = new Dictionary<ThirdPartyTask, object>(new ThirdPartyTaskComparer());

		private ThirdPartyTask thirdPartyTaskCompare = new ThirdPartyTask();

		private static MethodInfo playMakerStopMethod;

		private static MethodInfo uScriptStopMethod;

		private static MethodInfo dialogueSystemStopMethod;

		private static MethodInfo uSequencerStopMethod;

		private static MethodInfo iCodeStopMethod;

		private static object[] invokeParameters;

		public UpdateIntervalType UpdateInterval
		{
			get
			{
				return updateInterval;
			}
			set
			{
				updateInterval = value;
				UpdateIntervalChanged();
			}
		}

		public float UpdateIntervalSeconds
		{
			get
			{
				return updateIntervalSeconds;
			}
			set
			{
				updateIntervalSeconds = value;
				UpdateIntervalChanged();
			}
		}

		public ExecutionsPerTickType ExecutionsPerTick
		{
			get
			{
				return executionsPerTick;
			}
			set
			{
				executionsPerTick = value;
			}
		}

		public int MaxTaskExecutionsPerTick
		{
			get
			{
				return maxTaskExecutionsPerTick;
			}
			set
			{
				maxTaskExecutionsPerTick = value;
			}
		}

		public List<BehaviorTree> BehaviorTrees => behaviorTrees;

		private static MethodInfo PlayMakerStopMethod
		{
			get
			{
				if (playMakerStopMethod == null)
				{
					playMakerStopMethod = TaskUtility.GetTypeWithinAssembly("BehaviorDesigner.Runtime.BehaviorManager_PlayMaker").GetMethod("StopPlayMaker");
				}
				return playMakerStopMethod;
			}
		}

		private static MethodInfo UScriptStopMethod
		{
			get
			{
				if (uScriptStopMethod == null)
				{
					uScriptStopMethod = TaskUtility.GetTypeWithinAssembly("BehaviorDesigner.Runtime.BehaviorManager_uScript").GetMethod("StopuScript");
				}
				return uScriptStopMethod;
			}
		}

		private static MethodInfo DialogueSystemStopMethod
		{
			get
			{
				if (dialogueSystemStopMethod == null)
				{
					dialogueSystemStopMethod = TaskUtility.GetTypeWithinAssembly("BehaviorDesigner.Runtime.BehaviorManager_DialogueSystem").GetMethod("StopDialogueSystem");
				}
				return dialogueSystemStopMethod;
			}
		}

		private static MethodInfo USequencerStopMethod
		{
			get
			{
				if (uSequencerStopMethod == null)
				{
					uSequencerStopMethod = TaskUtility.GetTypeWithinAssembly("BehaviorDesigner.Runtime.BehaviorManager_uSequencer").GetMethod("StopuSequencer");
				}
				return uSequencerStopMethod;
			}
		}

		private static MethodInfo ICodeStopMethod
		{
			get
			{
				if (iCodeStopMethod == null)
				{
					iCodeStopMethod = TaskUtility.GetTypeWithinAssembly("BehaviorDesigner.Runtime.BehaviorManager_ICode").GetMethod("StopICode");
				}
				return iCodeStopMethod;
			}
		}

		public BehaviorTree GetBehaviorTree(Behavior behavior)
		{
			if (behaviorTreeMap.TryGetValue(behavior, out var value))
			{
				return value;
			}
			if (pausedBehaviorTrees.TryGetValue(behavior, out value))
			{
				return value;
			}
			return null;
		}

		public void Awake()
		{
			instance = this;
			UpdateIntervalChanged();
		}

		private void UpdateIntervalChanged()
		{
			StopCoroutine("CoroutineUpdate");
			if (updateInterval == UpdateIntervalType.EveryFrame)
			{
				base.enabled = true;
			}
			else if (updateInterval == UpdateIntervalType.SpecifySeconds)
			{
				if (Application.isPlaying)
				{
					updateWait = new WaitForSeconds(updateIntervalSeconds);
					StartCoroutine("CoroutineUpdate");
				}
				base.enabled = false;
			}
			else
			{
				base.enabled = false;
			}
		}

		public void OnDestroy()
		{
			for (int num = behaviorTrees.Count - 1; num > -1; num--)
			{
				DisableBehavior(behaviorTrees[num].behavior);
			}
			ObjectPool.Clear();
			instance = null;
		}

		public void EnableBehavior(Behavior behavior)
		{
			if (IsBehaviorEnabled(behavior))
			{
				return;
			}
			if (pausedBehaviorTrees.TryGetValue(behavior, out var value))
			{
				behaviorTrees.Add(value);
				pausedBehaviorTrees.Remove(behavior);
				behavior.ExecutionStatus = TaskStatus.Running;
				for (int i = 0; i < value.taskList.Count; i++)
				{
					value.taskList[i].OnPause(paused: false);
				}
				return;
			}
			TaskAddData taskAddData = ObjectPool.Get<TaskAddData>();
			taskAddData.Initialize();
			behavior.CheckForSerialization();
			Task rootTask = behavior.GetBehaviorSource().RootTask;
			if (rootTask == null)
			{
				UnityEngine.Debug.LogError($"The behavior \"{behavior.GetBehaviorSource().behaviorName}\" on GameObject \"{behavior.gameObject.name}\" contains no root task. This behavior will be disabled.");
				return;
			}
			value = ObjectPool.Get<BehaviorTree>();
			value.Initialize(behavior);
			value.parentIndex.Add(-1);
			value.relativeChildIndex.Add(-1);
			value.parentCompositeIndex.Add(-1);
			bool hasExternalBehavior = behavior.ExternalBehavior != null;
			int num = AddToTaskList(value, rootTask, ref hasExternalBehavior, taskAddData, -1, -1);
			if (num < 0)
			{
				value = null;
				switch (num)
				{
				case -1:
					UnityEngine.Debug.LogError($"The behavior \"{behavior.GetBehaviorSource().behaviorName}\" on GameObject \"{behavior.gameObject.name}\" contains a parent task ({taskAddData.errorTaskName} (index {taskAddData.errorTask})) with no children. This behavior will be disabled.");
					break;
				case -2:
					UnityEngine.Debug.LogError($"The behavior \"{behavior.GetBehaviorSource().behaviorName}\" on GameObject \"{behavior.gameObject.name}\" cannot find the referenced external task. This behavior will be disabled.");
					break;
				case -3:
					UnityEngine.Debug.LogError($"The behavior \"{behavior.GetBehaviorSource().behaviorName}\" on GameObject \"{behavior.gameObject.name}\" contains a null task (referenced from parent task {taskAddData.errorTaskName} (index {taskAddData.errorTask})). This behavior will be disabled.");
					break;
				case -4:
					UnityEngine.Debug.LogError($"The behavior \"{behavior.GetBehaviorSource().behaviorName}\" on GameObject \"{behavior.gameObject.name}\" contains multiple external behavior trees at the root task or as a child of a parent task which cannot contain so many children (such as a decorator task). This behavior will be disabled.");
					break;
				case -5:
					UnityEngine.Debug.LogError($"The behavior \"{behavior.GetBehaviorSource().behaviorName}\" on GameObject \"{behavior.gameObject.name}\" contains a Behavior Tree Reference task ({taskAddData.errorTaskName} (index {taskAddData.errorTask})) that which has an element with a null value in the externalBehaviors array. This behavior will be disabled.");
					break;
				case -6:
					UnityEngine.Debug.LogError(string.Format("The behavior \"{0}\" on GameObject \"{1}\" contains a root task which is disabled. This behavior will be disabled.", behavior.GetBehaviorSource().behaviorName, behavior.gameObject.name, taskAddData.errorTaskName, taskAddData.errorTask));
					break;
				}
			}
			else
			{
				if (behavior.ResetValuesOnRestart)
				{
					behavior.SaveResetValues();
				}
				Stack<int> stack = ObjectPool.Get<Stack<int>>();
				stack.Clear();
				value.activeStack.Add(stack);
				value.interruptionIndex.Add(-1);
				value.nonInstantTaskStatus.Add(TaskStatus.Inactive);
				for (int j = 0; j < value.taskList.Count; j++)
				{
					value.taskList[j].OnAwake();
				}
				behaviorTrees.Add(value);
				behaviorTreeMap.Add(behavior, value);
				if (!value.taskList[0].Disabled)
				{
					value.behavior.OnBehaviorStarted();
					behavior.ExecutionStatus = TaskStatus.Running;
					PushTask(value, 0, 0);
				}
			}
		}

		private int AddToTaskList(BehaviorTree behaviorTree, Task task, ref bool hasExternalBehavior, TaskAddData data, int idOfOwningBehaviourReferenceNode, int indexOfParentOfOwningBehaviourReferenceNode)
		{
			if (task == null)
			{
				return -3;
			}
			task.GameObject = behaviorTree.behavior.gameObject;
			task.Transform = behaviorTree.behavior.transform;
			task.Owner = behaviorTree.behavior;
			if (idOfOwningBehaviourReferenceNode != -1 && indexOfParentOfOwningBehaviourReferenceNode != -1)
			{
				task.IdOfOwningBehaviourReferenceNode = idOfOwningBehaviourReferenceNode;
				task.IndexOfParentOfOwningBehaviourReferenceNode = indexOfParentOfOwningBehaviourReferenceNode;
			}
			if (task is BehaviorReference)
			{
				BehaviorSource[] array = null;
				if (!(task is BehaviorReference behaviorReference))
				{
					return -2;
				}
				ExternalBehavior[] array2 = null;
				if ((array2 = behaviorReference.GetExternalBehaviors()) == null)
				{
					return -2;
				}
				array = new BehaviorSource[array2.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					if (array2[i] == null)
					{
						data.errorTask = behaviorTree.taskList.Count;
						data.errorTaskName = ((!string.IsNullOrEmpty(task.FriendlyName)) ? task.FriendlyName : task.GetType().ToString());
						return -5;
					}
					array[i] = array2[i].BehaviorSource;
					array[i].Owner = array2[i];
				}
				if (array == null)
				{
					return -2;
				}
				ParentTask parentTask = data.parentTask;
				int parentIndex = data.parentIndex;
				int compositeParentIndex = data.compositeParentIndex;
				data.depth++;
				for (int j = 0; j < array.Length; j++)
				{
					BehaviorSource behaviorSource = ObjectPool.Get<BehaviorSource>();
					behaviorSource.Initialize(array[j].Owner);
					array[j].CheckForSerialization(force: true, behaviorSource);
					Task rootTask = behaviorSource.RootTask;
					if (rootTask != null)
					{
						rootTask.Disabled = task.Disabled;
						if (behaviorReference.variables != null)
						{
							for (int k = 0; k < behaviorReference.variables.Length; k++)
							{
								if (data.overrideFields == null)
								{
									data.overrideFields = ObjectPool.Get<Dictionary<string, TaskAddData.OverrideFieldValue>>();
									data.overrideFields.Clear();
								}
								if (data.overrideFields.ContainsKey(behaviorReference.variables[k].Value.name))
								{
									continue;
								}
								TaskAddData.OverrideFieldValue overrideFieldValue = ObjectPool.Get<TaskAddData.OverrideFieldValue>();
								overrideFieldValue.Initialize(behaviorReference.variables[k].Value, data.depth);
								if (behaviorReference.variables[k].Value != null)
								{
									NamedVariable value = behaviorReference.variables[k].Value;
									if (string.IsNullOrEmpty(value.name))
									{
										UnityEngine.Debug.LogWarning("Warning: Named variable on reference task " + behaviorReference.FriendlyName + " (id " + behaviorReference.ID + ") is null");
										continue;
									}
									if (value.value != null && data.overrideFields.TryGetValue(value.name, out var value2))
									{
										overrideFieldValue = value2;
									}
								}
								else if (behaviorReference.variables[k].Value != null)
								{
									GenericVariable value3 = behaviorReference.variables[k].Value;
									if (value3.value != null)
									{
										if (string.IsNullOrEmpty(value3.value.Name))
										{
											UnityEngine.Debug.LogWarning("Warning: Named variable on reference task " + behaviorReference.FriendlyName + " (id " + behaviorReference.ID + ") is null");
											continue;
										}
										if (data.overrideFields.TryGetValue(value3.value.Name, out var value4))
										{
											overrideFieldValue = value4;
										}
									}
								}
								data.overrideFields.Add(behaviorReference.variables[k].Value.name, overrideFieldValue);
							}
						}
						if (behaviorSource.Variables != null)
						{
							for (int l = 0; l < behaviorSource.Variables.Count; l++)
							{
								SharedVariable sharedVariable = null;
								if ((sharedVariable = behaviorTree.behavior.GetVariable(behaviorSource.Variables[l].Name)) == null)
								{
									sharedVariable = behaviorSource.Variables[l];
									behaviorTree.behavior.SetVariable(sharedVariable.Name, sharedVariable);
								}
								else
								{
									behaviorSource.Variables[l].SetValue(sharedVariable.GetValue());
								}
								if (data.overrideFields == null)
								{
									data.overrideFields = ObjectPool.Get<Dictionary<string, TaskAddData.OverrideFieldValue>>();
									data.overrideFields.Clear();
								}
								if (!data.overrideFields.ContainsKey(sharedVariable.Name))
								{
									TaskAddData.OverrideFieldValue overrideFieldValue2 = ObjectPool.Get<TaskAddData.OverrideFieldValue>();
									overrideFieldValue2.Initialize(sharedVariable, data.depth);
									data.overrideFields.Add(sharedVariable.Name, overrideFieldValue2);
								}
							}
						}
						ObjectPool.Return(behaviorSource);
						if (j > 0)
						{
							data.parentTask = parentTask;
							data.parentIndex = parentIndex;
							data.compositeParentIndex = compositeParentIndex;
							if (data.parentTask == null || j >= data.parentTask.MaxChildren())
							{
								return -4;
							}
							behaviorTree.parentIndex.Add(data.parentIndex);
							behaviorTree.relativeChildIndex.Add(data.parentTask.Children.Count);
							behaviorTree.parentCompositeIndex.Add(data.compositeParentIndex);
							behaviorTree.childrenIndex[data.parentIndex].Add(behaviorTree.taskList.Count);
							data.parentTask.AddChild(rootTask, data.parentTask.Children.Count);
						}
						hasExternalBehavior = true;
						bool fromExternalTask = data.fromExternalTask;
						data.fromExternalTask = true;
						int num = 0;
						if ((num = AddToTaskList(behaviorTree, rootTask, ref hasExternalBehavior, data, task.ID, parentIndex)) < 0)
						{
							return num;
						}
						data.fromExternalTask = fromExternalTask;
						continue;
					}
					ObjectPool.Return(behaviorSource);
					return -2;
				}
				if (data.overrideFields != null)
				{
					Dictionary<string, TaskAddData.OverrideFieldValue> dictionary = ObjectPool.Get<Dictionary<string, TaskAddData.OverrideFieldValue>>();
					dictionary.Clear();
					foreach (KeyValuePair<string, TaskAddData.OverrideFieldValue> overrideField in data.overrideFields)
					{
						if (overrideField.Value.Depth != data.depth)
						{
							dictionary.Add(overrideField.Key, overrideField.Value);
						}
					}
					ObjectPool.Return(data.overrideFields);
					data.overrideFields = dictionary;
				}
				data.depth--;
			}
			else
			{
				if (behaviorTree.taskList.Count == 0 && task.Disabled)
				{
					return -6;
				}
				task.ReferenceID = behaviorTree.taskList.Count;
				behaviorTree.taskList.Add(task);
				if (data.overrideFields != null)
				{
					OverrideFields(behaviorTree, data, task);
				}
				if (data.fromExternalTask)
				{
					int index = behaviorTree.relativeChildIndex[behaviorTree.relativeChildIndex.Count - 1];
					data.parentTask.ReplaceAddChild(task, index);
				}
				if (task is ParentTask)
				{
					ParentTask parentTask2 = task as ParentTask;
					if (parentTask2.Children == null || parentTask2.Children.Count == 0)
					{
						data.errorTask = behaviorTree.taskList.Count - 1;
						data.errorTaskName = ((!string.IsNullOrEmpty(behaviorTree.taskList[data.errorTask].FriendlyName)) ? behaviorTree.taskList[data.errorTask].FriendlyName : behaviorTree.taskList[data.errorTask].GetType().ToString());
						return -1;
					}
					int num2 = behaviorTree.taskList.Count - 1;
					List<int> list = ObjectPool.Get<List<int>>();
					list.Clear();
					behaviorTree.childrenIndex.Add(list);
					list = ObjectPool.Get<List<int>>();
					list.Clear();
					behaviorTree.childConditionalIndex.Add(list);
					int count = parentTask2.Children.Count;
					for (int m = 0; m < count; m++)
					{
						behaviorTree.parentIndex.Add(num2);
						behaviorTree.relativeChildIndex.Add(m);
						behaviorTree.childrenIndex[num2].Add(behaviorTree.taskList.Count);
						data.parentTask = task as ParentTask;
						data.parentIndex = num2;
						if (task is Composite)
						{
							data.compositeParentIndex = num2;
						}
						behaviorTree.parentCompositeIndex.Add(data.compositeParentIndex);
						int num3;
						if ((num3 = AddToTaskList(behaviorTree, parentTask2.Children[m], ref hasExternalBehavior, data, idOfOwningBehaviourReferenceNode, indexOfParentOfOwningBehaviourReferenceNode)) < 0)
						{
							if (num3 == -3)
							{
								data.errorTask = num2;
								data.errorTaskName = ((!string.IsNullOrEmpty(behaviorTree.taskList[data.errorTask].FriendlyName)) ? behaviorTree.taskList[data.errorTask].FriendlyName : behaviorTree.taskList[data.errorTask].GetType().ToString());
							}
							return num3;
						}
					}
				}
				else
				{
					behaviorTree.childrenIndex.Add(null);
					behaviorTree.childConditionalIndex.Add(null);
					if (task is Conditional)
					{
						int num4 = behaviorTree.taskList.Count - 1;
						int num5 = behaviorTree.parentCompositeIndex[num4];
						if (num5 != -1)
						{
							behaviorTree.childConditionalIndex[num5].Add(num4);
						}
					}
				}
			}
			return 0;
		}

		private void OverrideFields(BehaviorTree behaviorTree, TaskAddData data, object obj)
		{
			if (obj == null || object.Equals(obj, null))
			{
				return;
			}
			FieldInfo[] allFields = TaskUtility.GetAllFields(obj.GetType());
			for (int i = 0; i < allFields.Length; i++)
			{
				object value = allFields[i].GetValue(obj);
				if (value == null)
				{
					continue;
				}
				if (typeof(SharedVariable).IsAssignableFrom(allFields[i].FieldType))
				{
					SharedVariable sharedVariable = OverrideSharedVariable(behaviorTree, data, allFields[i].FieldType, value as SharedVariable);
					if (sharedVariable != null)
					{
						allFields[i].SetValue(obj, sharedVariable);
					}
				}
				else if (typeof(IList).IsAssignableFrom(allFields[i].FieldType))
				{
					Type fieldType;
					if ((!typeof(SharedVariable).IsAssignableFrom(fieldType = allFields[i].FieldType.GetElementType()) && (!allFields[i].FieldType.IsGenericType || !typeof(SharedVariable).IsAssignableFrom(fieldType = allFields[i].FieldType.GetGenericArguments()[0]))) || !(value is IList<SharedVariable> list))
					{
						continue;
					}
					for (int j = 0; j < list.Count; j++)
					{
						SharedVariable sharedVariable2 = OverrideSharedVariable(behaviorTree, data, fieldType, list[j]);
						if (sharedVariable2 != null)
						{
							list[j] = sharedVariable2;
						}
					}
				}
				else if (allFields[i].FieldType.IsClass && !allFields[i].FieldType.Equals(typeof(Type)) && !typeof(Delegate).IsAssignableFrom(allFields[i].FieldType) && !data.overiddenFields.Contains(value))
				{
					data.overiddenFields.Add(value);
					OverrideFields(behaviorTree, data, value);
					data.overiddenFields.Remove(value);
				}
			}
		}

		private SharedVariable OverrideSharedVariable(BehaviorTree behaviorTree, TaskAddData data, Type fieldType, SharedVariable sharedVariable)
		{
			SharedVariable sharedVariable2 = sharedVariable;
			if (sharedVariable is SharedGenericVariable)
			{
				sharedVariable = ((sharedVariable as SharedGenericVariable).GetValue() as GenericVariable).value;
			}
			else if (sharedVariable is SharedNamedVariable)
			{
				sharedVariable = ((sharedVariable as SharedNamedVariable).GetValue() as NamedVariable).value;
			}
			if (sharedVariable == null)
			{
				return null;
			}
			if (!string.IsNullOrEmpty(sharedVariable.Name) && data.overrideFields.TryGetValue(sharedVariable.Name, out var value))
			{
				SharedVariable sharedVariable3 = null;
				if (value.Value is SharedVariable)
				{
					sharedVariable3 = value.Value as SharedVariable;
				}
				else if (value.Value is NamedVariable)
				{
					sharedVariable3 = (value.Value as NamedVariable).value;
					if (sharedVariable3.IsShared)
					{
						sharedVariable3 = behaviorTree.behavior.GetVariable(sharedVariable3.Name);
					}
				}
				else if (value.Value is GenericVariable)
				{
					sharedVariable3 = (value.Value as GenericVariable).value;
					if (sharedVariable3.IsShared)
					{
						sharedVariable3 = behaviorTree.behavior.GetVariable(sharedVariable3.Name);
					}
				}
				if (sharedVariable2 is SharedNamedVariable || sharedVariable2 is SharedGenericVariable)
				{
					if (fieldType.Equals(typeof(SharedVariable)) || sharedVariable3.GetType().Equals(sharedVariable.GetType()))
					{
						if (sharedVariable2 is SharedNamedVariable)
						{
							(sharedVariable2 as SharedNamedVariable).Value.value = sharedVariable3;
						}
						else if (sharedVariable2 is SharedGenericVariable)
						{
							(sharedVariable2 as SharedGenericVariable).Value.value = sharedVariable3;
						}
						behaviorTree.behavior.SetVariableValue(sharedVariable.Name, sharedVariable3.GetValue());
					}
				}
				else if (sharedVariable3 != null)
				{
					return sharedVariable3;
				}
			}
			return null;
		}

		public void DisableBehavior(Behavior behavior)
		{
			DisableBehavior(behavior, paused: false);
		}

		public void DisableBehavior(Behavior behavior, bool paused)
		{
			DisableBehavior(behavior, paused, TaskStatus.Success);
		}

		public void DisableBehavior(Behavior behavior, bool paused, TaskStatus executionStatus)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				if (!pausedBehaviorTrees.ContainsKey(behavior) || paused)
				{
					return;
				}
				EnableBehavior(behavior);
			}
			if (paused)
			{
				if (behaviorTreeMap.TryGetValue(behavior, out var value) && !pausedBehaviorTrees.ContainsKey(behavior))
				{
					pausedBehaviorTrees.Add(behavior, value);
					behavior.ExecutionStatus = TaskStatus.Inactive;
					for (int i = 0; i < value.taskList.Count; i++)
					{
						value.taskList[i].OnPause(paused: true);
					}
					behaviorTrees.Remove(value);
				}
			}
			else
			{
				DestroyBehavior(behavior, executionStatus);
			}
		}

		public void DestroyBehavior(Behavior behavior)
		{
			DestroyBehavior(behavior, TaskStatus.Success);
		}

		public void DestroyBehavior(Behavior behavior, TaskStatus executionStatus)
		{
			if (!behaviorTreeMap.TryGetValue(behavior, out var value) || value.destroyBehavior)
			{
				return;
			}
			value.destroyBehavior = true;
			if (pausedBehaviorTrees.ContainsKey(behavior))
			{
				pausedBehaviorTrees.Remove(behavior);
				for (int i = 0; i < value.taskList.Count; i++)
				{
					value.taskList[i].OnPause(paused: false);
				}
				behavior.ExecutionStatus = TaskStatus.Running;
			}
			for (int j = 0; j < value.taskList.Count; j++)
			{
				value.taskList[j].OnBehaviorBeginDestroy();
			}
			TaskStatus status = executionStatus;
			for (int num = value.activeStack.Count - 1; num > -1; num--)
			{
				while (value.activeStack[num].Count > 0)
				{
					int count = value.activeStack[num].Count;
					PopTask(value, value.activeStack[num].Peek(), num, ref status, popChildren: true, notifyOnEmptyStack: false);
					if (count == 1)
					{
						break;
					}
				}
			}
			RemoveChildConditionalReevaluate(value, -1);
			for (int k = 0; k < value.taskList.Count; k++)
			{
				value.taskList[k].OnBehaviorComplete();
			}
			behaviorTreeMap.Remove(behavior);
			behaviorTrees.Remove(value);
			value.destroyBehavior = false;
			ObjectPool.Return(value);
			behavior.ExecutionStatus = status;
			behavior.OnBehaviorEnded();
		}

		public void RestartBehavior(Behavior behavior)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return;
			}
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			TaskStatus status = TaskStatus.Success;
			for (int num = behaviorTree.activeStack.Count - 1; num > -1; num--)
			{
				while (behaviorTree.activeStack[num].Count > 0)
				{
					int count = behaviorTree.activeStack[num].Count;
					PopTask(behaviorTree, behaviorTree.activeStack[num].Peek(), num, ref status, popChildren: true, notifyOnEmptyStack: false);
					if (count == 1)
					{
						break;
					}
				}
			}
			Restart(behaviorTree);
		}

		public bool IsBehaviorEnabled(Behavior behavior)
		{
			if (behaviorTreeMap != null && behaviorTreeMap.Count > 0 && behavior != null)
			{
				return behavior.ExecutionStatus == TaskStatus.Running;
			}
			return false;
		}

		public void Update()
		{
			Tick();
		}

		public void LateUpdate()
		{
			for (int i = 0; i < behaviorTrees.Count; i++)
			{
				if (behaviorTrees[i].behavior.HasEvent[9])
				{
					for (int num = behaviorTrees[i].activeStack.Count - 1; num > -1; num--)
					{
						int index = behaviorTrees[i].activeStack[num].Peek();
						behaviorTrees[i].taskList[index].OnLateUpdate();
					}
				}
			}
		}

		public void FixedUpdate()
		{
			for (int i = 0; i < behaviorTrees.Count; i++)
			{
				if (behaviorTrees[i].behavior.HasEvent[10])
				{
					for (int num = behaviorTrees[i].activeStack.Count - 1; num > -1; num--)
					{
						int index = behaviorTrees[i].activeStack[num].Peek();
						behaviorTrees[i].taskList[index].OnFixedUpdate();
					}
				}
			}
		}

		private IEnumerator CoroutineUpdate()
		{
			while (true)
			{
				Tick();
				yield return updateWait;
			}
		}

		public void Tick()
		{
			for (int i = 0; i < behaviorTrees.Count; i++)
			{
				Tick(behaviorTrees[i]);
			}
		}

		public void Tick(Behavior behavior)
		{
			if (!(behavior == null) && IsBehaviorEnabled(behavior) && behaviorTreeMap.ContainsKey(behavior))
			{
				Tick(behaviorTreeMap[behavior]);
			}
		}

		private void Tick(BehaviorTree behaviorTree)
		{
			behaviorTree.executionCount = 0;
			ReevaluateParentTasks(behaviorTree);
			ReevaluateConditionalTasks(behaviorTree);
			for (int num = behaviorTree.activeStack.Count - 1; num > -1; num--)
			{
				TaskStatus status = TaskStatus.Inactive;
				int num2;
				if (num < behaviorTree.interruptionIndex.Count && (num2 = behaviorTree.interruptionIndex[num]) != -1)
				{
					behaviorTree.interruptionIndex[num] = -1;
					while (behaviorTree.activeStack[num].Peek() != num2)
					{
						int count = behaviorTree.activeStack[num].Count;
						PopTask(behaviorTree, behaviorTree.activeStack[num].Peek(), num, ref status, popChildren: true);
						if (count == 1)
						{
							break;
						}
					}
					if (num < behaviorTree.activeStack.Count && behaviorTree.activeStack[num].Count > 0 && behaviorTree.taskList[num2] == behaviorTree.taskList[behaviorTree.activeStack[num].Peek()])
					{
						if (behaviorTree.taskList[num2] is ParentTask)
						{
							status = (behaviorTree.taskList[num2] as ParentTask).OverrideStatus();
						}
						PopTask(behaviorTree, num2, num, ref status, popChildren: true);
					}
				}
				int num3 = -1;
				while (status != TaskStatus.Running && num < behaviorTree.activeStack.Count && behaviorTree.activeStack[num].Count > 0)
				{
					int num4 = behaviorTree.activeStack[num].Peek();
					if ((num < behaviorTree.activeStack.Count && behaviorTree.activeStack[num].Count > 0 && num3 == behaviorTree.activeStack[num].Peek()) || !IsBehaviorEnabled(behaviorTree.behavior))
					{
						break;
					}
					num3 = num4;
					status = RunTask(behaviorTree, num4, num, status);
				}
			}
		}

		private void ReevaluateConditionalTasks(BehaviorTree behaviorTree)
		{
			for (int i = 0; i < behaviorTree.conditionalReevaluate.Count; i++)
			{
				if (behaviorTree.conditionalReevaluate[i].compositeIndex == -1)
				{
					continue;
				}
				int index = behaviorTree.conditionalReevaluate[i].index;
				if (behaviorTree.taskList[index].OnUpdate() == behaviorTree.conditionalReevaluate[i].taskStatus)
				{
					continue;
				}
				int compositeIndex = behaviorTree.conditionalReevaluate[i].compositeIndex;
				for (int num = behaviorTree.activeStack.Count - 1; num > -1; num--)
				{
					if (behaviorTree.activeStack[num].Count > 0)
					{
						int num2 = behaviorTree.activeStack[num].Peek();
						int num3 = FindLCA(behaviorTree, index, num2);
						if (IsChild(behaviorTree, num3, compositeIndex))
						{
							int count = behaviorTree.activeStack.Count;
							while (num2 != -1 && num2 != num3 && behaviorTree.activeStack.Count == count)
							{
								TaskStatus status = TaskStatus.Failure;
								behaviorTree.taskList[num2].OnConditionalAbort();
								PopTask(behaviorTree, num2, num, ref status, popChildren: false);
								num2 = behaviorTree.parentIndex[num2];
							}
						}
					}
				}
				for (int num4 = behaviorTree.conditionalReevaluate.Count - 1; num4 > i - 1; num4--)
				{
					BehaviorTree.ConditionalReevaluate conditionalReevaluate = behaviorTree.conditionalReevaluate[num4];
					if (FindLCA(behaviorTree, compositeIndex, conditionalReevaluate.index) == compositeIndex)
					{
						ObjectPool.Return(behaviorTree.conditionalReevaluate[num4]);
						behaviorTree.conditionalReevaluateMap.Remove(behaviorTree.conditionalReevaluate[num4].index);
						behaviorTree.conditionalReevaluate.RemoveAt(num4);
					}
				}
				Composite composite = behaviorTree.taskList[behaviorTree.parentCompositeIndex[index]] as Composite;
				for (int num5 = i - 1; num5 > -1; num5--)
				{
					BehaviorTree.ConditionalReevaluate conditionalReevaluate2 = behaviorTree.conditionalReevaluate[num5];
					if (composite.AbortType == AbortType.LowerPriority && behaviorTree.parentCompositeIndex[conditionalReevaluate2.index] == behaviorTree.parentCompositeIndex[index])
					{
						behaviorTree.conditionalReevaluate[num5].compositeIndex = -1;
					}
					else if (behaviorTree.parentCompositeIndex[conditionalReevaluate2.index] == behaviorTree.parentCompositeIndex[index])
					{
						for (int j = 0; j < behaviorTree.childrenIndex[compositeIndex].Count; j++)
						{
							if (IsParentTask(behaviorTree, behaviorTree.childrenIndex[compositeIndex][j], conditionalReevaluate2.index))
							{
								int num6 = behaviorTree.childrenIndex[compositeIndex][j];
								while (!(behaviorTree.taskList[num6] is Composite) && behaviorTree.childrenIndex[num6] != null)
								{
									num6 = behaviorTree.childrenIndex[num6][0];
								}
								if (behaviorTree.taskList[num6] is Composite)
								{
									conditionalReevaluate2.compositeIndex = num6;
								}
								break;
							}
						}
					}
				}
				conditionalParentIndexes.Clear();
				for (int num7 = behaviorTree.parentIndex[index]; num7 != compositeIndex; num7 = behaviorTree.parentIndex[num7])
				{
					conditionalParentIndexes.Add(num7);
				}
				if (conditionalParentIndexes.Count == 0)
				{
					conditionalParentIndexes.Add(behaviorTree.parentIndex[index]);
				}
				ParentTask parentTask = behaviorTree.taskList[compositeIndex] as ParentTask;
				parentTask.OnConditionalAbort(behaviorTree.relativeChildIndex[conditionalParentIndexes[conditionalParentIndexes.Count - 1]]);
				for (int num8 = conditionalParentIndexes.Count - 1; num8 > -1; num8--)
				{
					parentTask = behaviorTree.taskList[conditionalParentIndexes[num8]] as ParentTask;
					if (num8 == 0)
					{
						parentTask.OnConditionalAbort(behaviorTree.relativeChildIndex[index]);
					}
					else
					{
						parentTask.OnConditionalAbort(behaviorTree.relativeChildIndex[conditionalParentIndexes[num8 - 1]]);
					}
				}
			}
		}

		private void ReevaluateParentTasks(BehaviorTree behaviorTree)
		{
			for (int num = behaviorTree.parentReevaluate.Count - 1; num > -1; num--)
			{
				int num2 = behaviorTree.parentReevaluate[num];
				if (behaviorTree.taskList[num2] is Decorator)
				{
					if (behaviorTree.taskList[num2].OnUpdate() == TaskStatus.Failure)
					{
						Interrupt(behaviorTree.behavior, behaviorTree.taskList[num2]);
					}
				}
				else if (behaviorTree.taskList[num2] is Composite)
				{
					ParentTask parentTask = behaviorTree.taskList[num2] as ParentTask;
					if (parentTask.OnReevaluationStarted())
					{
						int stackIndex = 0;
						TaskStatus status = RunParentTask(behaviorTree, num2, ref stackIndex, TaskStatus.Inactive);
						parentTask.OnReevaluationEnded(status);
					}
				}
			}
		}

		private TaskStatus RunTask(BehaviorTree behaviorTree, int taskIndex, int stackIndex, TaskStatus previousStatus)
		{
			Task task = behaviorTree.taskList[taskIndex];
			if (task == null)
			{
				return previousStatus;
			}
			if (task.Disabled)
			{
				if (behaviorTree.behavior.LogTaskChanges)
				{
					MonoBehaviour.print($"{RoundedTime()}: {behaviorTree.behavior.ToString()}: Skip task {behaviorTree.taskList[taskIndex].FriendlyName} ({behaviorTree.taskList[taskIndex].GetType()}, index {taskIndex}) at stack index {stackIndex} (task disabled)");
				}
				if (behaviorTree.parentIndex[taskIndex] != -1)
				{
					ParentTask parentTask = behaviorTree.taskList[behaviorTree.parentIndex[taskIndex]] as ParentTask;
					if (!parentTask.CanRunParallelChildren())
					{
						parentTask.OnChildExecuted(TaskStatus.Inactive);
					}
					else
					{
						parentTask.OnChildExecuted(behaviorTree.relativeChildIndex[taskIndex], TaskStatus.Inactive);
						RemoveStack(behaviorTree, stackIndex);
					}
				}
				return previousStatus;
			}
			TaskStatus status = previousStatus;
			if (!task.IsInstant && (behaviorTree.nonInstantTaskStatus[stackIndex] == TaskStatus.Failure || behaviorTree.nonInstantTaskStatus[stackIndex] == TaskStatus.Success))
			{
				status = behaviorTree.nonInstantTaskStatus[stackIndex];
				PopTask(behaviorTree, taskIndex, stackIndex, ref status, popChildren: true);
				return status;
			}
			PushTask(behaviorTree, taskIndex, stackIndex);
			if (task is ParentTask)
			{
				ParentTask obj = task as ParentTask;
				status = RunParentTask(behaviorTree, taskIndex, ref stackIndex, status);
				status = obj.OverrideStatus(status);
			}
			else
			{
				status = task.OnUpdate();
			}
			if (status != TaskStatus.Running)
			{
				if (task.IsInstant)
				{
					PopTask(behaviorTree, taskIndex, stackIndex, ref status, popChildren: true);
				}
				else
				{
					behaviorTree.nonInstantTaskStatus[stackIndex] = status;
				}
			}
			return status;
		}

		private TaskStatus RunParentTask(BehaviorTree behaviorTree, int taskIndex, ref int stackIndex, TaskStatus status)
		{
			ParentTask parentTask = behaviorTree.taskList[taskIndex] as ParentTask;
			if (!parentTask.CanRunParallelChildren() || parentTask.OverrideStatus(TaskStatus.Running) != TaskStatus.Running)
			{
				TaskStatus taskStatus = TaskStatus.Inactive;
				int num = stackIndex;
				int num2 = -1;
				Behavior behavior = behaviorTree.behavior;
				while (parentTask.CanExecute() && (taskStatus != TaskStatus.Running || parentTask.CanRunParallelChildren()) && IsBehaviorEnabled(behavior))
				{
					List<int> list = behaviorTree.childrenIndex[taskIndex];
					int num3 = parentTask.CurrentChildIndex();
					if ((executionsPerTick == ExecutionsPerTickType.NoDuplicates && num3 == num2) || (executionsPerTick == ExecutionsPerTickType.Count && behaviorTree.executionCount >= maxTaskExecutionsPerTick))
					{
						status = TaskStatus.Running;
						break;
					}
					num2 = num3;
					if (parentTask.CanRunParallelChildren())
					{
						behaviorTree.activeStack.Add(ObjectPool.Get<Stack<int>>());
						behaviorTree.interruptionIndex.Add(-1);
						behaviorTree.nonInstantTaskStatus.Add(TaskStatus.Inactive);
						stackIndex = behaviorTree.activeStack.Count - 1;
						parentTask.OnChildStarted(num3);
					}
					else
					{
						parentTask.OnChildStarted();
					}
					status = (taskStatus = RunTask(behaviorTree, list[num3], stackIndex, status));
				}
				stackIndex = num;
			}
			return status;
		}

		private void PushTask(BehaviorTree behaviorTree, int taskIndex, int stackIndex)
		{
			if (!IsBehaviorEnabled(behaviorTree.behavior) || stackIndex >= behaviorTree.activeStack.Count)
			{
				return;
			}
			Stack<int> stack = behaviorTree.activeStack[stackIndex];
			if (stack.Count == 0 || stack.Peek() != taskIndex)
			{
				stack.Push(taskIndex);
				behaviorTree.nonInstantTaskStatus[stackIndex] = TaskStatus.Running;
				behaviorTree.executionCount++;
				Task task = behaviorTree.taskList[taskIndex];
				task.OnStart();
				if (task is ParentTask && (task as ParentTask).CanReevaluate())
				{
					behaviorTree.parentReevaluate.Add(taskIndex);
				}
			}
		}

		private void PopTask(BehaviorTree behaviorTree, int taskIndex, int stackIndex, ref TaskStatus status, bool popChildren)
		{
			PopTask(behaviorTree, taskIndex, stackIndex, ref status, popChildren, notifyOnEmptyStack: true);
		}

		private void PopTask(BehaviorTree behaviorTree, int taskIndex, int stackIndex, ref TaskStatus status, bool popChildren, bool notifyOnEmptyStack)
		{
			if (stackIndex >= behaviorTree.activeStack.Count || behaviorTree.activeStack[stackIndex].Count == 0 || taskIndex != behaviorTree.activeStack[stackIndex].Peek())
			{
				return;
			}
			behaviorTree.activeStack[stackIndex].Pop();
			behaviorTree.nonInstantTaskStatus[stackIndex] = TaskStatus.Inactive;
			StopThirdPartyTask(behaviorTree, taskIndex);
			Task task = behaviorTree.taskList[taskIndex];
			task.OnEnd();
			int num = behaviorTree.parentIndex[taskIndex];
			if (num != -1)
			{
				if (task is Conditional)
				{
					int num2 = behaviorTree.parentCompositeIndex[taskIndex];
					if (num2 != -1)
					{
						Composite composite = behaviorTree.taskList[num2] as Composite;
						if (composite.AbortType != AbortType.None)
						{
							if (behaviorTree.conditionalReevaluateMap.TryGetValue(taskIndex, out var value))
							{
								value.compositeIndex = ((composite.AbortType != AbortType.LowerPriority) ? num2 : (-1));
								value.taskStatus = status;
							}
							else
							{
								BehaviorTree.ConditionalReevaluate conditionalReevaluate = ObjectPool.Get<BehaviorTree.ConditionalReevaluate>();
								conditionalReevaluate.Initialize(taskIndex, status, stackIndex, (composite.AbortType != AbortType.LowerPriority) ? num2 : (-1));
								behaviorTree.conditionalReevaluate.Add(conditionalReevaluate);
								behaviorTree.conditionalReevaluateMap.Add(taskIndex, conditionalReevaluate);
							}
						}
					}
				}
				ParentTask parentTask = behaviorTree.taskList[num] as ParentTask;
				if (!parentTask.CanRunParallelChildren())
				{
					parentTask.OnChildExecuted(status);
					status = parentTask.Decorate(status);
				}
				else
				{
					parentTask.OnChildExecuted(behaviorTree.relativeChildIndex[taskIndex], status);
				}
			}
			if (task is ParentTask)
			{
				ParentTask parentTask2 = task as ParentTask;
				if (parentTask2.CanReevaluate())
				{
					for (int num3 = behaviorTree.parentReevaluate.Count - 1; num3 > -1; num3--)
					{
						if (behaviorTree.parentReevaluate[num3] == taskIndex)
						{
							behaviorTree.parentReevaluate.RemoveAt(num3);
							break;
						}
					}
				}
				if (parentTask2 is Composite)
				{
					Composite composite2 = parentTask2 as Composite;
					if (composite2.AbortType == AbortType.Self || composite2.AbortType == AbortType.None || behaviorTree.activeStack[stackIndex].Count == 0)
					{
						RemoveChildConditionalReevaluate(behaviorTree, taskIndex);
					}
					else if (composite2.AbortType == AbortType.LowerPriority || composite2.AbortType == AbortType.Both)
					{
						int num4 = behaviorTree.parentCompositeIndex[taskIndex];
						if (num4 != -1)
						{
							if (!(behaviorTree.taskList[num4] as ParentTask).CanRunParallelChildren())
							{
								for (int i = 0; i < behaviorTree.childConditionalIndex[taskIndex].Count; i++)
								{
									int key = behaviorTree.childConditionalIndex[taskIndex][i];
									if (!behaviorTree.conditionalReevaluateMap.TryGetValue(key, out var value2))
									{
										continue;
									}
									if (!(behaviorTree.taskList[num4] as ParentTask).CanRunParallelChildren())
									{
										value2.compositeIndex = behaviorTree.parentCompositeIndex[taskIndex];
										continue;
									}
									for (int num5 = behaviorTree.conditionalReevaluate.Count - 1; num5 > i - 1; num5--)
									{
										BehaviorTree.ConditionalReevaluate conditionalReevaluate2 = behaviorTree.conditionalReevaluate[num5];
										if (FindLCA(behaviorTree, num4, conditionalReevaluate2.index) == num4)
										{
											ObjectPool.Return(behaviorTree.conditionalReevaluate[num5]);
											behaviorTree.conditionalReevaluateMap.Remove(behaviorTree.conditionalReevaluate[num5].index);
											behaviorTree.conditionalReevaluate.RemoveAt(num5);
										}
									}
								}
							}
							else
							{
								RemoveChildConditionalReevaluate(behaviorTree, taskIndex);
							}
						}
						for (int j = 0; j < behaviorTree.conditionalReevaluate.Count; j++)
						{
							if (behaviorTree.conditionalReevaluate[j].compositeIndex == taskIndex)
							{
								behaviorTree.conditionalReevaluate[j].compositeIndex = behaviorTree.parentCompositeIndex[taskIndex];
							}
						}
					}
				}
			}
			if (popChildren)
			{
				for (int num6 = behaviorTree.activeStack.Count - 1; num6 > stackIndex; num6--)
				{
					if (behaviorTree.activeStack[num6].Count > 0 && IsParentTask(behaviorTree, taskIndex, behaviorTree.activeStack[num6].Peek()))
					{
						TaskStatus status2 = TaskStatus.Failure;
						for (int num7 = behaviorTree.activeStack[num6].Count; num7 > 0; num7--)
						{
							PopTask(behaviorTree, behaviorTree.activeStack[num6].Peek(), num6, ref status2, popChildren: false, notifyOnEmptyStack);
						}
					}
				}
			}
			if (stackIndex >= behaviorTree.activeStack.Count || behaviorTree.activeStack[stackIndex].Count != 0)
			{
				return;
			}
			if (stackIndex == 0)
			{
				if (notifyOnEmptyStack)
				{
					if (behaviorTree.behavior.RestartWhenComplete)
					{
						Restart(behaviorTree);
					}
					else
					{
						DisableBehavior(behaviorTree.behavior, paused: false, status);
					}
				}
				status = TaskStatus.Inactive;
			}
			else
			{
				RemoveStack(behaviorTree, stackIndex);
				status = TaskStatus.Running;
			}
		}

		private void RemoveChildConditionalReevaluate(BehaviorTree behaviorTree, int compositeIndex)
		{
			for (int num = behaviorTree.conditionalReevaluate.Count - 1; num > -1; num--)
			{
				if (behaviorTree.conditionalReevaluate[num].compositeIndex == compositeIndex)
				{
					ObjectPool.Return(behaviorTree.conditionalReevaluate[num]);
					int index = behaviorTree.conditionalReevaluate[num].index;
					behaviorTree.conditionalReevaluateMap.Remove(index);
					behaviorTree.conditionalReevaluate.RemoveAt(num);
				}
			}
		}

		private void Restart(BehaviorTree behaviorTree)
		{
			RemoveChildConditionalReevaluate(behaviorTree, -1);
			if (behaviorTree.behavior.ResetValuesOnRestart)
			{
				behaviorTree.behavior.SaveResetValues();
			}
			for (int i = 0; i < behaviorTree.taskList.Count; i++)
			{
				behaviorTree.taskList[i].OnBehaviorRestart();
			}
			behaviorTree.behavior.OnBehaviorRestarted();
			PushTask(behaviorTree, 0, 0);
		}

		private bool IsParentTask(BehaviorTree behaviorTree, int possibleParent, int possibleChild)
		{
			int num = 0;
			for (int num2 = possibleChild; num2 != -1; num2 = num)
			{
				num = behaviorTree.parentIndex[num2];
				if (num == possibleParent)
				{
					return true;
				}
			}
			return false;
		}

		public void Interrupt(Behavior behavior, Task task)
		{
			Interrupt(behavior, task, task);
		}

		public void Interrupt(Behavior behavior, Task task, Task interruptionTask)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return;
			}
			int num = -1;
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			for (int i = 0; i < behaviorTree.taskList.Count; i++)
			{
				if (behaviorTree.taskList[i].ReferenceID == task.ReferenceID)
				{
					num = i;
					break;
				}
			}
			if (num <= -1)
			{
				return;
			}
			for (int j = 0; j < behaviorTree.activeStack.Count; j++)
			{
				if (behaviorTree.activeStack[j].Count <= 0)
				{
					continue;
				}
				for (int num2 = behaviorTree.activeStack[j].Peek(); num2 != -1; num2 = behaviorTree.parentIndex[num2])
				{
					if (num2 == num)
					{
						behaviorTree.interruptionIndex[j] = num;
						break;
					}
				}
			}
		}

		public void StopThirdPartyTask(BehaviorTree behaviorTree, int taskIndex)
		{
			thirdPartyTaskCompare.Task = behaviorTree.taskList[taskIndex];
			if (taskObjectMap.TryGetValue(thirdPartyTaskCompare, out var value))
			{
				ThirdPartyObjectType thirdPartyObjectType = objectTaskMap[value].ThirdPartyObjectType;
				if (invokeParameters == null)
				{
					invokeParameters = new object[1];
				}
				invokeParameters[0] = behaviorTree.taskList[taskIndex];
				switch (thirdPartyObjectType)
				{
				case ThirdPartyObjectType.PlayMaker:
					PlayMakerStopMethod.Invoke(null, invokeParameters);
					break;
				case ThirdPartyObjectType.uScript:
					UScriptStopMethod.Invoke(null, invokeParameters);
					break;
				case ThirdPartyObjectType.DialogueSystem:
					DialogueSystemStopMethod.Invoke(null, invokeParameters);
					break;
				case ThirdPartyObjectType.uSequencer:
					USequencerStopMethod.Invoke(null, invokeParameters);
					break;
				case ThirdPartyObjectType.ICode:
					ICodeStopMethod.Invoke(null, invokeParameters);
					break;
				}
				RemoveActiveThirdPartyTask(behaviorTree.taskList[taskIndex]);
			}
		}

		public void RemoveActiveThirdPartyTask(Task task)
		{
			thirdPartyTaskCompare.Task = task;
			if (taskObjectMap.TryGetValue(thirdPartyTaskCompare, out var value))
			{
				ObjectPool.Return(value);
				taskObjectMap.Remove(thirdPartyTaskCompare);
				objectTaskMap.Remove(value);
			}
		}

		private void RemoveStack(BehaviorTree behaviorTree, int stackIndex)
		{
			Stack<int> stack = behaviorTree.activeStack[stackIndex];
			stack.Clear();
			ObjectPool.Return(stack);
			behaviorTree.activeStack.RemoveAt(stackIndex);
			behaviorTree.interruptionIndex.RemoveAt(stackIndex);
			behaviorTree.nonInstantTaskStatus.RemoveAt(stackIndex);
		}

		private int FindLCA(BehaviorTree behaviorTree, int taskIndex1, int taskIndex2)
		{
			HashSet<int> hashSet = ObjectPool.Get<HashSet<int>>();
			hashSet.Clear();
			int num;
			for (num = taskIndex1; num != -1; num = behaviorTree.parentIndex[num])
			{
				hashSet.Add(num);
			}
			num = taskIndex2;
			while (!hashSet.Contains(num))
			{
				num = behaviorTree.parentIndex[num];
			}
			return num;
		}

		private bool IsChild(BehaviorTree behaviorTree, int taskIndex1, int taskIndex2)
		{
			for (int num = taskIndex1; num != -1; num = behaviorTree.parentIndex[num])
			{
				if (num == taskIndex2)
				{
					return true;
				}
			}
			return false;
		}

		public List<Task> GetActiveTasks(Behavior behavior)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return null;
			}
			List<Task> list = new List<Task>();
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			for (int i = 0; i < behaviorTree.activeStack.Count; i++)
			{
				Task task = behaviorTree.taskList[behaviorTree.activeStack[i].Peek()];
				if (task is BehaviorDesigner.Runtime.Tasks.Action)
				{
					list.Add(task);
				}
			}
			return list;
		}

		public void BehaviorOnCollisionEnter(Collision collision, Behavior behavior)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return;
			}
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			for (int i = 0; i < behaviorTree.activeStack.Count; i++)
			{
				int num = behaviorTree.activeStack[i].Peek();
				while (num != -1 && !behaviorTree.taskList[num].Disabled)
				{
					behaviorTree.taskList[num].OnCollisionEnter(collision);
					num = behaviorTree.parentIndex[num];
				}
			}
			for (int j = 0; j < behaviorTree.conditionalReevaluate.Count; j++)
			{
				int num = behaviorTree.conditionalReevaluate[j].index;
				if (!behaviorTree.taskList[num].Disabled && behaviorTree.conditionalReevaluate[j].compositeIndex != -1)
				{
					behaviorTree.taskList[num].OnCollisionEnter(collision);
				}
			}
		}

		public void BehaviorOnCollisionExit(Collision collision, Behavior behavior)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return;
			}
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			for (int i = 0; i < behaviorTree.activeStack.Count; i++)
			{
				int num = behaviorTree.activeStack[i].Peek();
				while (num != -1 && !behaviorTree.taskList[num].Disabled)
				{
					behaviorTree.taskList[num].OnCollisionExit(collision);
					num = behaviorTree.parentIndex[num];
				}
			}
			for (int j = 0; j < behaviorTree.conditionalReevaluate.Count; j++)
			{
				int num = behaviorTree.conditionalReevaluate[j].index;
				if (!behaviorTree.taskList[num].Disabled && behaviorTree.conditionalReevaluate[j].compositeIndex != -1)
				{
					behaviorTree.taskList[num].OnCollisionExit(collision);
				}
			}
		}

		public void BehaviorOnTriggerEnter(Collider other, Behavior behavior)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return;
			}
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			for (int i = 0; i < behaviorTree.activeStack.Count; i++)
			{
				for (int num = behaviorTree.activeStack[i].Peek(); num != -1; num = behaviorTree.parentIndex[num])
				{
					behaviorTree.taskList[num].OnTriggerEnter(other);
				}
			}
			for (int j = 0; j < behaviorTree.conditionalReevaluate.Count; j++)
			{
				int num = behaviorTree.conditionalReevaluate[j].index;
				if (!behaviorTree.taskList[num].Disabled && behaviorTree.conditionalReevaluate[j].compositeIndex != -1)
				{
					behaviorTree.taskList[num].OnTriggerEnter(other);
				}
			}
		}

		public void BehaviorOnTriggerExit(Collider other, Behavior behavior)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return;
			}
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			for (int i = 0; i < behaviorTree.activeStack.Count; i++)
			{
				int num = behaviorTree.activeStack[i].Peek();
				while (num != -1 && !behaviorTree.taskList[num].Disabled)
				{
					behaviorTree.taskList[num].OnTriggerExit(other);
					num = behaviorTree.parentIndex[num];
				}
			}
			for (int j = 0; j < behaviorTree.conditionalReevaluate.Count; j++)
			{
				int num = behaviorTree.conditionalReevaluate[j].index;
				if (!behaviorTree.taskList[num].Disabled && behaviorTree.conditionalReevaluate[j].compositeIndex != -1)
				{
					behaviorTree.taskList[num].OnTriggerExit(other);
				}
			}
		}

		public void BehaviorOnCollisionEnter2D(Collision2D collision, Behavior behavior)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return;
			}
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			for (int i = 0; i < behaviorTree.activeStack.Count; i++)
			{
				int num = behaviorTree.activeStack[i].Peek();
				while (num != -1 && !behaviorTree.taskList[num].Disabled)
				{
					behaviorTree.taskList[num].OnCollisionEnter2D(collision);
					num = behaviorTree.parentIndex[num];
				}
			}
			for (int j = 0; j < behaviorTree.conditionalReevaluate.Count; j++)
			{
				int num = behaviorTree.conditionalReevaluate[j].index;
				if (!behaviorTree.taskList[num].Disabled && behaviorTree.conditionalReevaluate[j].compositeIndex != -1)
				{
					behaviorTree.taskList[num].OnCollisionEnter2D(collision);
				}
			}
		}

		public void BehaviorOnCollisionExit2D(Collision2D collision, Behavior behavior)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return;
			}
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			for (int i = 0; i < behaviorTree.activeStack.Count; i++)
			{
				int num = behaviorTree.activeStack[i].Peek();
				while (num != -1 && !behaviorTree.taskList[num].Disabled)
				{
					behaviorTree.taskList[num].OnCollisionExit2D(collision);
					num = behaviorTree.parentIndex[num];
				}
			}
			for (int j = 0; j < behaviorTree.conditionalReevaluate.Count; j++)
			{
				int num = behaviorTree.conditionalReevaluate[j].index;
				if (!behaviorTree.taskList[num].Disabled && behaviorTree.conditionalReevaluate[j].compositeIndex != -1)
				{
					behaviorTree.taskList[num].OnCollisionExit2D(collision);
				}
			}
		}

		public void BehaviorOnTriggerEnter2D(Collider2D other, Behavior behavior)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return;
			}
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			for (int i = 0; i < behaviorTree.activeStack.Count; i++)
			{
				int num = behaviorTree.activeStack[i].Peek();
				while (num != -1 && !behaviorTree.taskList[num].Disabled)
				{
					behaviorTree.taskList[num].OnTriggerEnter2D(other);
					num = behaviorTree.parentIndex[num];
				}
			}
			for (int j = 0; j < behaviorTree.conditionalReevaluate.Count; j++)
			{
				int num = behaviorTree.conditionalReevaluate[j].index;
				if (!behaviorTree.taskList[num].Disabled && behaviorTree.conditionalReevaluate[j].compositeIndex != -1)
				{
					behaviorTree.taskList[num].OnTriggerEnter2D(other);
				}
			}
		}

		public void BehaviorOnTriggerExit2D(Collider2D other, Behavior behavior)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return;
			}
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			for (int i = 0; i < behaviorTree.activeStack.Count; i++)
			{
				int num = behaviorTree.activeStack[i].Peek();
				while (num != -1 && !behaviorTree.taskList[num].Disabled)
				{
					behaviorTree.taskList[num].OnTriggerExit2D(other);
					num = behaviorTree.parentIndex[num];
				}
			}
			for (int j = 0; j < behaviorTree.conditionalReevaluate.Count; j++)
			{
				int num = behaviorTree.conditionalReevaluate[j].index;
				if (!behaviorTree.taskList[num].Disabled && behaviorTree.conditionalReevaluate[j].compositeIndex != -1)
				{
					behaviorTree.taskList[num].OnTriggerExit2D(other);
				}
			}
		}

		public void BehaviorOnControllerColliderHit(ControllerColliderHit hit, Behavior behavior)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return;
			}
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			for (int i = 0; i < behaviorTree.activeStack.Count; i++)
			{
				int num = behaviorTree.activeStack[i].Peek();
				while (num != -1 && !behaviorTree.taskList[num].Disabled)
				{
					behaviorTree.taskList[num].OnControllerColliderHit(hit);
					num = behaviorTree.parentIndex[num];
				}
			}
			for (int j = 0; j < behaviorTree.conditionalReevaluate.Count; j++)
			{
				int num = behaviorTree.conditionalReevaluate[j].index;
				if (!behaviorTree.taskList[num].Disabled && behaviorTree.conditionalReevaluate[j].compositeIndex != -1)
				{
					behaviorTree.taskList[num].OnControllerColliderHit(hit);
				}
			}
		}

		public void BehaviorOnAnimatorIK(Behavior behavior)
		{
			if (!IsBehaviorEnabled(behavior))
			{
				return;
			}
			BehaviorTree behaviorTree = behaviorTreeMap[behavior];
			for (int i = 0; i < behaviorTree.activeStack.Count; i++)
			{
				int num = behaviorTree.activeStack[i].Peek();
				while (num != -1 && !behaviorTree.taskList[num].Disabled)
				{
					behaviorTree.taskList[num].OnAnimatorIK();
					num = behaviorTree.parentIndex[num];
				}
			}
			for (int j = 0; j < behaviorTree.conditionalReevaluate.Count; j++)
			{
				int num = behaviorTree.conditionalReevaluate[j].index;
				if (!behaviorTree.taskList[num].Disabled && behaviorTree.conditionalReevaluate[j].compositeIndex != -1)
				{
					behaviorTree.taskList[num].OnAnimatorIK();
				}
			}
		}

		public bool MapObjectToTask(object objectKey, Task task, ThirdPartyObjectType objectType)
		{
			if (objectTaskMap.ContainsKey(objectKey))
			{
				string arg = "";
				switch (objectType)
				{
				case ThirdPartyObjectType.PlayMaker:
					arg = "PlayMaker FSM";
					break;
				case ThirdPartyObjectType.uScript:
					arg = "uScript Graph";
					break;
				case ThirdPartyObjectType.DialogueSystem:
					arg = "Dialogue System";
					break;
				case ThirdPartyObjectType.uSequencer:
					arg = "uSequencer sequence";
					break;
				case ThirdPartyObjectType.ICode:
					arg = "ICode state machine";
					break;
				}
				UnityEngine.Debug.LogError($"Only one behavior can be mapped to the same instance of the {arg}.");
				return false;
			}
			ThirdPartyTask thirdPartyTask = ObjectPool.Get<ThirdPartyTask>();
			thirdPartyTask.Initialize(task, objectType);
			objectTaskMap.Add(objectKey, thirdPartyTask);
			taskObjectMap.Add(thirdPartyTask, objectKey);
			return true;
		}

		public Task TaskForObject(object objectKey)
		{
			if (!objectTaskMap.TryGetValue(objectKey, out var value))
			{
				return null;
			}
			return value.Task;
		}

		private decimal RoundedTime()
		{
			return Math.Round((decimal)Time.time, 5, MidpointRounding.AwayFromZero);
		}

		[Conditional("BD_ENABLE_PROFILING")]
		internal static void ProfilerBeginSample(string message)
		{
		}

		[Conditional("BD_ENABLE_PROFILING")]
		[StringFormatMethod("message")]
		internal static void ProfilerBeginSample(string message, params object[] args)
		{
		}

		[Conditional("BD_ENABLE_PROFILING")]
		internal static void ProfilerEndSample()
		{
		}
	}
}
