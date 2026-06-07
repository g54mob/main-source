using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace ManagementScripts
{
	public class UINavigationManager : MonoBehaviour
	{
		public static UINavigationManager instance;

		public static bool emptyEscapeStack;

		public static UnityEvent<IRevertableAction> onRedoOrRevert = new UnityEvent<IRevertableAction>();

		public List<IEscapable> escapeStack = new List<IEscapable>();

		public List<IRevertableAction> revertableActionStack = new List<IRevertableAction>();

		public int revertableStackIndex = -1;

		public static bool exists;

		private void Awake()
		{
			instance = this;
			exists = true;
			GameManager.onSceneChange.AddListener(OnSceneChange);
		}

		private void Update()
		{
			emptyEscapeStack = escapeStack.Count < 1;
			if (emptyEscapeStack)
			{
				return;
			}
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				IEscapable escapable = escapeStack.Last();
				if (escapable.CanBeEscaped())
				{
					escapeStack.Remove(escapable);
					escapable.Escape();
				}
			}
			if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
			{
				if (Input.GetKey(KeyCode.LeftShift))
				{
					RedoOneAction();
				}
				else
				{
					RevertOneAction();
				}
			}
		}

		public static void AddEscapableToStack(IEscapable escapable)
		{
			if (exists)
			{
				instance.escapeStack.Add(escapable);
			}
		}

		public static void RemoveEscapableFromStack(IEscapable escapable)
		{
			if (exists)
			{
				instance.escapeStack.Remove(escapable);
			}
		}

		public static void AddRevertableActionToStack(IRevertableAction action)
		{
			instance?.AddRevertableToStack(action);
		}

		public void AddRevertableToStack(IRevertableAction action)
		{
			int count = revertableActionStack.Count;
			if (revertableStackIndex < count - 1)
			{
				revertableActionStack.RemoveRange(revertableStackIndex + 1, count - 1 - revertableStackIndex);
			}
			revertableActionStack.Add(action);
			if (revertableStackIndex >= 59)
			{
				revertableActionStack.RemoveAt(0);
			}
			else
			{
				revertableStackIndex++;
			}
		}

		private void RevertOneAction()
		{
			if (revertableStackIndex >= 0)
			{
				IRevertableAction revertableAction = revertableActionStack[revertableStackIndex--];
				revertableAction.Revert();
				onRedoOrRevert.Invoke(revertableAction);
			}
		}

		private void RedoOneAction()
		{
			if (revertableStackIndex < revertableActionStack.Count - 1)
			{
				IRevertableAction revertableAction = revertableActionStack[++revertableStackIndex];
				revertableAction.ReDo();
				onRedoOrRevert.Invoke(revertableAction);
			}
		}

		public static void ClearRevertableStack()
		{
			if (exists)
			{
				instance?.ClearRevertable();
			}
		}

		public void ClearRevertable()
		{
			revertableActionStack.Clear();
			revertableStackIndex = -1;
		}

		private void OnSceneChange()
		{
			escapeStack.Clear();
			ClearRevertable();
		}

		private void OnDestroy()
		{
			exists = false;
		}
	}
}
