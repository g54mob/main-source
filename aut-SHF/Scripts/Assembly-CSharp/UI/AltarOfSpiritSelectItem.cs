using Factory.FieldData;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class AltarOfSpiritSelectItem : MonoBehaviour
	{
		[SerializeField]
		private GameObject bgObj;

		[SerializeField]
		private Toggle toggle;

		[SerializeField]
		private Image counterBar;

		[SerializeField]
		private TMP_Text counterText;

		private FactoryContext.AltarOfSpiritType _altarType;

		private UnityAction<FactoryContext.AltarOfSpiritType> _onClickAction;

		private CustomRuleSetting _ruleData;

		private int _needCount;

		public void Init(FactoryContext.AltarOfSpiritType altarType, UnityAction<FactoryContext.AltarOfSpiritType> onClickAction)
		{
		}

		public void UpdateUI()
		{
		}

		public void OnClickButton()
		{
		}

		public void ResetCounter()
		{
		}

		public void UpdateCounter()
		{
		}
	}
}
