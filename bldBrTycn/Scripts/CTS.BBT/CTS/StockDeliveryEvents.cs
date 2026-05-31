using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Stocks/Delivery Events")]
	public class StockDeliveryEvents : ScriptableObject
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct Comparer : IComparer<DateEvent>
		{
			public int Compare(DateEvent x, DateEvent y)
			{
				if (x.Year != y.Year)
				{
					if (x.Year > y.Year)
					{
						return 1;
					}
					return -1;
				}
				if (x.Month != y.Month)
				{
					if (x.Month > y.Month)
					{
						return 1;
					}
					return -1;
				}
				return 0;
			}
		}

		[Serializable]
		public struct DateEvent
		{
			public int Year;

			[Range(0f, 11f)]
			public int Month;

			public StockDeliveryData Data;
		}

		private static readonly Comparer _comparer;

		[field: SerializeField]
		public List<DateEvent> Deliveries { get; private set; }

		[Button(null, EButtonEnableMode.Always)]
		public void Sort()
		{
			Deliveries.Sort(_comparer);
			_ = Application.isPlaying;
		}
	}
}
