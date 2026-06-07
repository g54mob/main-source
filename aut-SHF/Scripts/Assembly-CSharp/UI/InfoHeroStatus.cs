using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
	public class InfoHeroStatus : MonoBehaviour
	{
		[SerializeField]
		private Image actionType;

		[SerializeField]
		private EventTrigger actionTypeEventTrigger;

		[SerializeField]
		private RectTransform attackKindContent;

		[SerializeField]
		private Image spellAttackKindIcon;

		[SerializeField]
		private ChoiceMenuButtonBase attackKindImagePrefab;

		[SerializeField]
		private Image attackBar;

		[SerializeField]
		private TMP_Text attackPoint;

		[SerializeField]
		private Image staminaBar;

		[SerializeField]
		private TMP_Text staminaPoint;

		[SerializeField]
		private ChoiceMenuButtonBase hitPrefab;

		[SerializeField]
		private RectTransform hitBar;

		[SerializeField]
		private TMP_Text lifePoint;

		[SerializeField]
		private Transform lifeContent;

		private StatusLifeBlock[] _lifes;

		private EventTrigger.Entry _enterEntry;

		private EventTrigger.Entry _exitEntry;

		private Vector2? _initialHitBerDelta;

		private string _actionTypeName;

		private string _actionTypeDesc;

		private GameObject _spellAttackTypeObject;

		private string _spellAttackTypeName;

		private string _spellAttackTypeDesc;

		private Dictionary<GameObject, (string name, string desc)> _attackTypeData;

		private void Awake()
		{
		}

		public void DisplayHeroStatus(eLuggage luggage)
		{
		}

		public void ShowActionTypeMouseOver(PointerEventData eventData)
		{
		}

		public void HideActionTypeMouseOver(PointerEventData eventData)
		{
		}

		public void ShowActionTypeMouseOver()
		{
		}

		public void HideActionTypeMouseOver()
		{
		}

		public void ShowSpellAttackTypeMouseOver(PointerEventData eventData = null)
		{
		}

		public void HideSpellAttackTypeMouseOver(PointerEventData eventData = null)
		{
		}

		public void ShowAttackTypeMouseOver(GameObject gameObject, PointerEventData eventData = null)
		{
		}

		public void HideAttackTypeMouseOver(PointerEventData eventData = null)
		{
		}

		private void CreateActionTypeIcon(eUnitActionType value)
		{
		}

		private void CreateSpellAttackTypeIcon(bool isClick)
		{
		}

		private void CreateAttackTypeIcons(List<eUnitAttackType> attackTypes, List<int> attackTypeLevels)
		{
		}

		private void CreateLifeBar(bool valid, int lifePoint = 0)
		{
		}

		private void CreateHit(int shootCount)
		{
		}
	}
}
