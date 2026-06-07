using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
	public class EasterLuggageCell : SideCounterCell
	{
		private class LuggagePointGroup
		{
			public int point;

			public List<eLuggage> luggages;

			public LuggagePointGroup(int point, List<eLuggage> luggages)
			{
			}
		}

		[SerializeField]
		private TMP_Text[] point;

		[SerializeField]
		private TMP_Text[] deliveryCounter;

		private List<LuggagePointGroup> _pointGroup;

		private int _lineCount;

		private int[] _deliveryCountCache;

		public override void InitComponent(eLuggage luggage, Action<eLuggage> onPointerEnter, Action onPointerExit)
		{
		}

		public override void UpdateCounter()
		{
		}

		public override void ResetCell()
		{
		}

		private int GetAllHistoryAbilityCount(List<eLuggage> luggages)
		{
			return 0;
		}

		public bool UpdateCheck(eLuggage luggage)
		{
			return false;
		}
	}
}
