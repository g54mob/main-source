using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Variables/Object Comparer")]
	public class ObjectComparer : MonoBehaviour
	{
		[Tooltip("The Events will be invoked when the Listener Value changes.\nIf is set to false, call Invoke() to invoke the events manually")]
		public bool Auto = true;

		public Object value;

		public List<ObjectsComp> compare = new List<ObjectsComp>();

		public Object Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
				if (Auto)
				{
					Invoke();
				}
			}
		}

		public Object this[int index]
		{
			get
			{
				return compare[index].CompareTo;
			}
			set
			{
				compare[index].CompareTo = value;
			}
		}

		private void OnEnable()
		{
			if (Auto)
			{
				Invoke();
			}
		}

		public virtual void Invoke()
		{
			foreach (ObjectsComp item in compare)
			{
				item.Invoke(Value);
			}
		}

		private void OnValidate()
		{
			for (int i = 0; i < compare.Count; i++)
			{
				ObjectsComp objectsComp = compare[i];
				objectsComp.elementName = ((objectsComp.CompareTo == null) ? $" [{i}] Is Object [Null] ?" : $" [{i}] Is Object equal to [{objectsComp.CompareTo.name}] ?");
			}
		}
	}
}
