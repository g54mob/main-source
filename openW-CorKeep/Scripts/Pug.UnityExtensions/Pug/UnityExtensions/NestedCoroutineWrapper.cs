using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public class NestedCoroutineWrapper : CoroutineWrapper
	{
		private const int STACKCAP = 8;

		private readonly Stack<IEnumerator> callStack = new Stack<IEnumerator>(8);

		public uint currentRunID { get; private set; }

		private string logHeader => "[CoroutinePlus: " + mb.name + ": " + name + "] ";

		public NestedCoroutineWrapper(MonoBehaviour mb, string name = "", bool addAutoStopComponent = false)
			: base(mb, name, addAutoStopComponent)
		{
		}

		public bool IsRunning()
		{
			return coroutine != null;
		}

		public override void Start(IEnumerator mainSubroutine)
		{
			currentRunID++;
			base.Start(_Run(mainSubroutine, currentRunID));
		}

		public override void Stop()
		{
			if (IsRunning())
			{
				base.Stop();
				callStack.Clear();
			}
		}

		public void Restart(IEnumerator mainSubroutine)
		{
			if (IsRunning())
			{
				Stop();
			}
			Start(mainSubroutine);
		}

		private bool GotInterrupted(uint coroutineRunID)
		{
			return currentRunID != coroutineRunID;
		}

		private IEnumerator _Run(IEnumerator mainSubroutine, uint coroutineRunID)
		{
			if (callStack.Count > 0)
			{
				Debug.LogWarning(logHeader + "Some junk is already in the call stack! Did you use CoroutinePlus.Stop?");
			}
			callStack.Clear();
			callStack.Push(mainSubroutine);
			while (callStack.Count > 0)
			{
				IEnumerator subroutine = callStack.Pop();
				bool flag = callStack.Count == 0;
				bool flag2 = subroutine.MoveNext();
				if (GotInterrupted(coroutineRunID))
				{
					break;
				}
				if (flag2)
				{
					IEnumerator nestedCall = subroutine.Current as IEnumerator;
					if (nestedCall == null)
					{
						yield return subroutine.Current;
						if (GotInterrupted(coroutineRunID))
						{
							break;
						}
					}
					callStack.Push(subroutine);
					if (nestedCall != null)
					{
						callStack.Push(nestedCall);
					}
				}
				else if (flag)
				{
					coroutine = null;
					break;
				}
			}
			if (callStack.Count > 0 && !GotInterrupted(coroutineRunID))
			{
				Debug.LogWarning(logHeader + "The call stack still contains stuff after we're done with it");
			}
		}
	}
}
