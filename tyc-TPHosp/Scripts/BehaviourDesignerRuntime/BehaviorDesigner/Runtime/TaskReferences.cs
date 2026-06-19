using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace BehaviorDesigner.Runtime
{
	public class TaskReferences : MonoBehaviour
	{
		public static void CheckReferences(BehaviorSource behaviorSource)
		{
			if (behaviorSource.RootTask != null)
			{
				CheckReferences(behaviorSource, behaviorSource.RootTask);
			}
			if (behaviorSource.DetachedTasks != null)
			{
				for (int i = 0; i < behaviorSource.DetachedTasks.Count; i++)
				{
					CheckReferences(behaviorSource, behaviorSource.DetachedTasks[i]);
				}
			}
		}

		private static void CheckReferences(BehaviorSource behaviorSource, Task task)
		{
			FieldInfo[] allFields = TaskUtility.GetAllFields(task.GetType());
			for (int i = 0; i < allFields.Length; i++)
			{
				if (!allFields[i].FieldType.IsArray && (allFields[i].FieldType.Equals(typeof(Task)) || allFields[i].FieldType.IsSubclassOf(typeof(Task))))
				{
					if (allFields[i].GetValue(task) is Task referencedTask)
					{
						Task task2 = FindReferencedTask(behaviorSource, referencedTask);
						if (task2 != null)
						{
							allFields[i].SetValue(task, task2);
						}
					}
				}
				else
				{
					if (!allFields[i].FieldType.IsArray || (!allFields[i].FieldType.GetElementType().Equals(typeof(Task)) && !allFields[i].FieldType.GetElementType().IsSubclassOf(typeof(Task))) || !(allFields[i].GetValue(task) is Task[] array))
					{
						continue;
					}
					IList list = Activator.CreateInstance(typeof(List<>).MakeGenericType(allFields[i].FieldType.GetElementType())) as IList;
					for (int j = 0; j < array.Length; j++)
					{
						Task task3 = FindReferencedTask(behaviorSource, array[j]);
						if (task3 != null)
						{
							list.Add(task3);
						}
					}
					Array array2 = Array.CreateInstance(allFields[i].FieldType.GetElementType(), list.Count);
					list.CopyTo(array2, 0);
					allFields[i].SetValue(task, array2);
				}
			}
			if (!task.GetType().IsSubclassOf(typeof(ParentTask)))
			{
				return;
			}
			ParentTask parentTask = task as ParentTask;
			if (parentTask.Children != null)
			{
				for (int k = 0; k < parentTask.Children.Count; k++)
				{
					CheckReferences(behaviorSource, parentTask.Children[k]);
				}
			}
		}

		private static Task FindReferencedTask(BehaviorSource behaviorSource, Task referencedTask)
		{
			int iD = referencedTask.ID;
			Task result;
			if (behaviorSource.RootTask != null && (result = FindReferencedTask(behaviorSource.RootTask, iD)) != null)
			{
				return result;
			}
			if (behaviorSource.DetachedTasks != null)
			{
				for (int i = 0; i < behaviorSource.DetachedTasks.Count; i++)
				{
					if ((result = FindReferencedTask(behaviorSource.DetachedTasks[i], iD)) != null)
					{
						return result;
					}
				}
			}
			return null;
		}

		private static Task FindReferencedTask(Task task, int referencedTaskID)
		{
			if (task.ID == referencedTaskID)
			{
				return task;
			}
			if (task.GetType().IsSubclassOf(typeof(ParentTask)))
			{
				ParentTask parentTask = task as ParentTask;
				if (parentTask.Children != null)
				{
					for (int i = 0; i < parentTask.Children.Count; i++)
					{
						Task result;
						if ((result = FindReferencedTask(parentTask.Children[i], referencedTaskID)) != null)
						{
							return result;
						}
					}
				}
			}
			return null;
		}

		public static void CheckReferences(Behavior behavior, List<Task> taskList)
		{
			for (int i = 0; i < taskList.Count; i++)
			{
				CheckReferences(behavior, taskList[i], taskList);
			}
		}

		private static void CheckReferences(Behavior behavior, Task task, List<Task> taskList)
		{
			if (TaskUtility.CompareType(task.GetType(), "BehaviorDesigner.Runtime.Tasks.ConditionalEvaluator"))
			{
				object value = task.GetType().GetField("conditionalTask").GetValue(task);
				if (value != null)
				{
					task = value as Task;
				}
			}
			FieldInfo[] allFields = TaskUtility.GetAllFields(task.GetType());
			for (int i = 0; i < allFields.Length; i++)
			{
				if (!allFields[i].FieldType.IsArray && (allFields[i].FieldType.Equals(typeof(Task)) || allFields[i].FieldType.IsSubclassOf(typeof(Task))))
				{
					if (allFields[i].GetValue(task) is Task task2 && !task2.Owner.Equals(behavior))
					{
						Task task3 = FindReferencedTask(task2, taskList);
						if (task3 != null)
						{
							allFields[i].SetValue(task, task3);
						}
					}
				}
				else
				{
					if (!allFields[i].FieldType.IsArray || (!allFields[i].FieldType.GetElementType().Equals(typeof(Task)) && !allFields[i].FieldType.GetElementType().IsSubclassOf(typeof(Task))) || !(allFields[i].GetValue(task) is Task[] array))
					{
						continue;
					}
					IList list = Activator.CreateInstance(typeof(List<>).MakeGenericType(allFields[i].FieldType.GetElementType())) as IList;
					for (int j = 0; j < array.Length; j++)
					{
						Task task4 = FindReferencedTask(array[j], taskList);
						if (task4 != null)
						{
							list.Add(task4);
						}
					}
					Array array2 = Array.CreateInstance(allFields[i].FieldType.GetElementType(), list.Count);
					list.CopyTo(array2, 0);
					allFields[i].SetValue(task, array2);
				}
			}
		}

		private static Task FindReferencedTask(Task referencedTask, List<Task> taskList)
		{
			int referenceID = referencedTask.ReferenceID;
			for (int i = 0; i < taskList.Count; i++)
			{
				if (taskList[i].ReferenceID == referenceID)
				{
					return taskList[i];
				}
			}
			return null;
		}
	}
}
