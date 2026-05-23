using System;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class SpiritCounterCell : SideCounterCell
	{
		[SerializeField]
		private Image counterBar;

		[SerializeField]
		private TMP_Text counterMaxText;

		[SerializeField]
		private TMP_Text counterText;

		private CustomRuleSetting _ruleData;

		private int _needCount => 0;

		public override void InitComponent(eLuggage luggage, Action<eLuggage> onPointerEnter, Action onPointerExit)
		{
		}

		public override void ResetCell()
		{
		}

		public override void UpdateCounter()
		{
		}

		private void ChangeMaxText(int maxCount)
		{
		}
	}
}
