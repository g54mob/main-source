using System.Numerics;
using Assets.Source.Ability;
using Assets.Source.Buff;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.Util;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Behaviour.UI.Overview
{
	public class AbilityButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, ITooltipTitleSource, ITooltipCustomSource
	{
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private RectTransform _highlight;

		[SerializeField]
		private RectTransform _glow;

		[SerializeField]
		private RectTransform _duration;

		private ActivatedAbility _contained;

		private UITooltipText _tooltipCost;

		private BigInteger _cost;

		private bool _canAfford;

		private bool _mouseOver;

		public ActivatedAbility Ability => _contained;

		private void Update()
		{
			_updateCost();
			_icon.material = (_canAfford ? Materials.Default : Materials.Grayscale75);
			_icon.color = (_canAfford ? Color.white : Color.gray);
			_highlight.gameObject.SetActive(_mouseOver && _canAfford);
			if ((bool)_tooltipCost)
			{
				UpdateTooltipCost();
			}
			if (_contained.TargetType == AbilityTargetType.Frame && ActiveWorldFrame.Active)
			{
				foreach (FrameBuff buff in ActiveWorldFrame.Current.ActiveFrame.Buffs)
				{
					if (buff.Ability == _contained)
					{
						_duration.localScale = new UnityEngine.Vector3(buff.Progress, 1f, 1f);
						_duration.gameObject.SetActive(value: true);
						return;
					}
				}
			}
			else if (_contained.TargetType == AbilityTargetType.None)
			{
				foreach (FrameBuff buff2 in GamePlayer.Current.Buffs)
				{
					if (buff2.Ability == _contained)
					{
						_duration.localScale = new UnityEngine.Vector3(buff2.Progress, 1f, 1f);
						_duration.gameObject.SetActive(value: true);
						return;
					}
				}
			}
			_duration.gameObject.SetActive(value: false);
		}

		private void _updateCost()
		{
			_cost = _contained.GetCastingCost();
			_canAfford = GamePlayer.Current.GetInventoryCount(ItemType.GlitchedWidget) >= _cost;
		}

		private void UpdateTooltipCost()
		{
			if (GamePlayer.Current.GetInventoryCount(ItemType.GlitchedWidget) < _cost)
			{
				_tooltipCost.Text.text = Translation.Highlight("@AbilityCost", "red", _cost, GameMath.FormatPercentage(GamePlayer.Current.AbilityEntropy, FormatPercentageMode.Offset));
			}
			else
			{
				_tooltipCost.Text.text = Translation.Translate("@AbilityCost", _cost, GameMath.FormatPercentage(GamePlayer.Current.AbilityEntropy, FormatPercentageMode.Offset));
			}
		}

		public void SetAbility(ActivatedAbility aa)
		{
			_contained = aa;
			_icon.sprite = aa.Icon;
		}

		public void SetSelected(bool sel)
		{
			_glow.gameObject.SetActive(sel);
		}

		public string GetTooltipTitle()
		{
			return _contained.DisplayName;
		}

		public void AddTooltipCustomContent(UITooltip tooltip)
		{
			_updateCost();
			_tooltipCost = tooltip.AddItemLine(ItemType.GlitchedWidget, "");
			_tooltipCost.Text.alignment = TextAlignmentOptions.TopLeft;
			UpdateTooltipCost();
			tooltip.AddTextLine(Translation.Translate("@AbilityAddEntropy", GameMath.FormatPercentage(_contained.Entropy, FormatPercentageMode.Offset)));
			tooltip.AddTextLine(_contained.DescriptionText);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				StartAbilityGhost(drag: false);
			}
		}

		public void StartAbilityGhost(bool drag)
		{
			if (_glow.gameObject.activeSelf)
			{
				UISounds.Button();
				OverviewUI.Instance.StopAbilityTargeting();
			}
			else if (_contained.GetCastingCost() > GamePlayer.Current.GetInventoryCount(ItemType.GlitchedWidget))
			{
				UISounds.CraftStep();
				_contained.ShowNeedItem(base.transform, ItemType.GlitchedWidget, _contained.GetCastingCost());
			}
			else if (_contained.TargetType == AbilityTargetType.Frame && ActiveWorldFrame.Active)
			{
				_contained.DoActivateAbility(base.transform, ActiveWorldFrame.Current.ActiveFrame);
			}
			else if (_contained.TargetType == AbilityTargetType.Frame)
			{
				UISounds.CraftStep();
				OverviewUI.Instance.ShowAbilityGhost(_contained);
			}
			else
			{
				_contained.DoActivateAbility(base.transform, null);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_mouseOver = false;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_mouseOver = true;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			StartAbilityGhost(drag: true);
		}

		public void OnDrag(PointerEventData eventData)
		{
		}
	}
}
