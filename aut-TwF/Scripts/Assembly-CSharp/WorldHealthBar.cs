using UnityEngine;

[RequireComponent(typeof(WorldObjectUI))]
public class WorldHealthBar : HealthBar
{
	[SerializeField]
	private bool hideIfUndamaged = true;

	private bool characterHidden;

	public bool CharacterHidden
	{
		get
		{
			return characterHidden;
		}
		set
		{
			characterHidden = value;
			if (characterHidden)
			{
				SetVisible(isVisible: false);
			}
			else
			{
				SetVisible(base.Value < base.MaxValue);
			}
		}
	}

	public override CombatComponent CombatComponent
	{
		get
		{
			return base.CombatComponent;
		}
		set
		{
			base.CombatComponent = value;
			if ((bool)combatComponent)
			{
				GetComponent<WorldObjectUI>().SetFollowTarget(CombatComponent.gameObject);
			}
		}
	}

	private void SetVisible(bool isVisible)
	{
		foreach (Transform item in base.transform)
		{
			item.gameObject.SetActive(isVisible);
		}
	}

	public override void SetBarValue(float value)
	{
		base.SetBarValue(value);
		SetVisible(!hideIfUndamaged || value < base.MaxValue);
	}

	protected override void OnDie(CombatComponent cc)
	{
		base.OnDie(cc);
		Object.Destroy(base.gameObject);
	}

	private void OnHideCharacter(bool hidden)
	{
		CharacterHidden = hidden;
	}
}
