using System;
using UnityEngine;
using UnityEngine.Events;

namespace MoreMountains.Tools
{
	[Serializable]
	public class MMInputExecutionBinding
	{
		public KeyCode TargetKey = KeyCode.Space;

		public UnityEvent OnKeyDown;

		public UnityEvent OnKey;

		public UnityEvent OnKeyUp;

		public virtual void ProcessInput()
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			flag = Input.GetKey(TargetKey);
			flag2 = Input.GetKeyDown(TargetKey);
			flag3 = Input.GetKeyUp(TargetKey);
			if (OnKey != null && flag)
			{
				OnKey.Invoke();
			}
			if (OnKeyDown != null && flag2)
			{
				OnKeyDown.Invoke();
			}
			if (OnKeyUp != null && flag3)
			{
				OnKeyUp.Invoke();
			}
		}
	}
}
