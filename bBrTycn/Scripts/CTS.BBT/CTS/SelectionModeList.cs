using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class SelectionModeList : CTSSingleton<SelectionModeList>
	{
		private struct Mode : IComparable<Mode>, IEquatable<Mode>
		{
			public int Order;

			public int Count;

			public SelectionMode SelectionMode;

			public int CompareTo(Mode other)
			{
				return Order.CompareTo(other.Order);
			}

			public bool Equals(Mode other)
			{
				if (Order == other.Order)
				{
					return (object)SelectionMode == other.SelectionMode;
				}
				return false;
			}
		}

		[SerializeField]
		private SelectionMode _defaultSelectionMode;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private WorldSelector _worldSelector;

		private readonly List<Mode> _selectionModes = new List<Mode>();

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public void AddMode(OrderedSelectionMode mode)
		{
			AddMode(mode, mode.Order);
		}

		public void AddMode(SelectionMode mode, int order)
		{
			Mode mode2 = new Mode
			{
				Order = order,
				SelectionMode = mode,
				Count = 1
			};
			int num = _selectionModes.IndexOf(mode2);
			if (num >= 0)
			{
				Mode mode3 = _selectionModes[num];
				mode3.Count++;
				_selectionModes[num] = mode2;
			}
			else
			{
				_selectionModes.Add(mode2);
				_selectionModes.Sort();
				RecalculateSelectionMode();
			}
		}

		public void RemoveMode(OrderedSelectionMode mode)
		{
			RemoveMode(mode, mode.Order);
		}

		public void RemoveMode(SelectionMode mode, int order)
		{
			Mode mode2 = new Mode
			{
				Order = order,
				SelectionMode = mode,
				Count = 1
			};
			int num = _selectionModes.IndexOf(mode2);
			if (num < 0)
			{
				return;
			}
			Mode mode3 = _selectionModes[num];
			mode3.Count--;
			_selectionModes[num] = mode2;
			if (mode3.Count <= 0)
			{
				_selectionModes.RemoveAt(num);
				if (num >= _selectionModes.Count)
				{
					RecalculateSelectionMode();
				}
			}
		}

		public void RecalculateSelectionMode()
		{
			if (_selectionModes.Count <= 0)
			{
				_worldSelector.SetSelectionMode(_defaultSelectionMode);
				return;
			}
			WorldSelector worldSelector = _worldSelector;
			List<Mode> selectionModes = _selectionModes;
			worldSelector.SetSelectionMode(selectionModes[selectionModes.Count - 1].SelectionMode);
		}
	}
}
