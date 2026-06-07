using System;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	[Serializable]
	public class ObjectsComp
	{
		[HideInInspector]
		public string elementName;

		public UnityEngine.Object CompareTo;

		public UnityEvent Then = new UnityEvent();

		public UnityEvent Else = new UnityEvent();

		public virtual void Invoke(UnityEngine.Object value)
		{
			Response(value == CompareTo);
		}

		private void Response(bool value)
		{
			if (value)
			{
				Then.Invoke();
			}
			else
			{
				Else.Invoke();
			}
		}
	}
}
