using System;
using UnityEngine;

namespace UI.Xml
{
	public class DelayedAction
	{
		public float timeToExecute;

		public Action action;

		public MonoBehaviour target;

		public bool forceEvenIfTargetIsInactive;
	}
}
