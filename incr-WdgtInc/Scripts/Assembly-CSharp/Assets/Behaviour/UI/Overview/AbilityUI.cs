using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Ability;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.Util;
using TMPro;
using UnityEngine;

namespace Assets.Behaviour.UI.Overview
{
	public class AbilityUI : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _buttonParent;

		[SerializeField]
		private AbilityButton _buttonPrefab;

		[SerializeField]
		private RectTransform _costParent;

		[SerializeField]
		private TMP_Text _costText;

		private List<AbilityButton> _buttons = new List<AbilityButton>();

		private void Update()
		{
			if (OverviewUI.Instance.AbilityActive)
			{
				BigInteger castingCost = OverviewUI.Instance.CurrentAbility.GetCastingCost();
				if (castingCost > GamePlayer.Current.GetInventoryCount(ItemType.GlitchedWidget))
				{
					_costText.text = Translation.Highlight("@AbilitySideBarCost", "red", castingCost);
				}
				else
				{
					_costText.text = Translation.Translate("@AbilitySideBarCost", castingCost);
				}
			}
		}

		public void UpdateUI(IEnumerable<ActivatedAbility> abilities)
		{
			_costParent.gameObject.SetActive(value: false);
			_buttons.Clear();
			_buttonParent.DestroyActiveChildren();
			bool active = false;
			float num = 0f;
			foreach (ActivatedAbility ability in abilities)
			{
				active = true;
				AbilityButton abilityButton = Object.Instantiate(_buttonPrefab, _buttonParent);
				abilityButton.SetAbility(ability);
				_buttons.Add(abilityButton);
				((RectTransform)abilityButton.transform).anchoredPosition = new UnityEngine.Vector2(num, 0f);
				num += 102f;
			}
			_buttonParent.sizeDelta = new UnityEngine.Vector2(num - 10f, _buttonParent.sizeDelta.y);
			RectTransform rectTransform = (RectTransform)base.transform;
			rectTransform.sizeDelta = new UnityEngine.Vector2(Mathf.Max(300f, num - 10f), rectTransform.sizeDelta.y);
			base.gameObject.SetActive(active);
		}

		public void SetSelectedAbility(ActivatedAbility ability)
		{
			_costParent.gameObject.SetActive(ability != null);
			foreach (AbilityButton button in _buttons)
			{
				button.SetSelected(button.Ability == ability);
			}
		}

		public void SelectAbility(int key)
		{
			if (_buttons.Count >= key)
			{
				_buttons[key - 1].StartAbilityGhost(drag: false);
			}
		}
	}
}
