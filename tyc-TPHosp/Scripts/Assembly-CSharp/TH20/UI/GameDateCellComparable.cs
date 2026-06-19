using System;
using UnityEngine;

namespace TH20.UI
{
	[AddComponentMenu("UI/Game Date Comparable", 104)]
	public class GameDateCellComparable : MonoBehaviour, IComparable<GameDateCellComparable>, IComparable
	{
		[SerializeField]
		private GameDate _value;

		public GameDate Value
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

		public int CompareTo(GameDateCellComparable other)
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
			GameDateCellComparable gameDateCellComparable = obj as GameDateCellComparable;
			if (!(gameDateCellComparable != null))
			{
				return 1;
			}
			return CompareTo(gameDateCellComparable);
		}
	}
}
