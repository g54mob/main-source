using Assets.Source.Ability;
using Assets.Source.UI;
using UnityEngine;

namespace Assets.Behaviour.UI.Overview
{
	public class OverviewAbilityGhost : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _icon;

		private ActivatedAbility _contained;

		public ActivatedAbility Ability => _contained;

		public void SetAbility(ActivatedAbility ability)
		{
			_contained = ability;
			_icon.sprite = ability.Icon;
		}

		private void Update()
		{
			if (PlayerControls.InputCancel)
			{
				UISounds.Button();
				OverviewUI.Instance.StopAbilityTargeting();
				return;
			}
			bool isMouseOverUi = UIHelper.IsMouseOverUi;
			Vector2 mouseWorld = PlayerControls.MouseWorld;
			base.transform.position = mouseWorld;
			_icon.enabled = !isMouseOverUi;
			if (PlayerControls.InteractRelease && !isMouseOverUi)
			{
				WorldOverviewCell highlighted = WorldOverviewCell.Highlighted;
				if ((bool)highlighted && highlighted.Frame != null)
				{
					_contained.DoActivateAbility(highlighted.transform, highlighted.Frame);
				}
				else
				{
					OverviewUI.Instance.StopAbilityTargeting();
				}
			}
		}
	}
}
