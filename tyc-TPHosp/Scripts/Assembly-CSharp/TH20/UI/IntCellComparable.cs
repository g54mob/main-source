using System;
using UnityEngine;

namespace TH20.UI
{
	[AddComponentMenu("UI/Int Comparable", 104)]
	public class IntCellComparable : MonoBehaviour, IComparable<IntCellComparable>, IComparable
	{
		[SerializeField]
		private int _value;

		public int Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

		public int CompareTo(IntCellComparable other)
		{
			if (other != null)
			{
				if (_value != other.Value)
				{
					return _value.CompareTo(other.Value);
				}
				return GetInstanceID().CompareTo(other.GetInstanceID());
			}
			return 1;
		}

		public int CompareTo(object obj)
		{
			IntCellComparable intCellComparable = obj as IntCellComparable;
			if (!(intCellComparable != null))
			{
				return 1;
			}
			return CompareTo(intCellComparable);
		}
	}
}
