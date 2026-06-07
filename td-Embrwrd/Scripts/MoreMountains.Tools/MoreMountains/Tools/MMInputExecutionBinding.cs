using System;
using UnityEngine;
using UnityEngine.Events;

namespace MoreMountains.Tools
{
	[Serializable]
	public class MMInputExecutionBinding
	{
		public KeyCode TargetKey;

		public UnityEvent OnKeyDown;

		public UnityEvent OnKey;

		public UnityEvent OnKeyUp;

		public virtual void ProcessInput()
		{
		}
	}
}
