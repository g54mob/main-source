using UnityEngine;

public class HealthBar : FillBar
{
	protected CombatComponent combatComponent;

	public virtual CombatComponent CombatComponent
	{
		get
		{
			return combatComponent;
		}
		set
		{
			if ((bool)combatComponent)
			{
				CombatComponent.onHealthChanged -= OnHealthChanged;
				CombatComponent.onDie -= OnDie;
			}
			combatComponent = value;
			if ((bool)combatComponent)
			{
				CombatComponent.onHealthChanged += OnHealthChanged;
				CombatComponent.onDie += OnDie;
				SetBarValue(CombatComponent.Health / CombatComponent.MaxHealth);
				base.LifeBarSizePerUnit = Mathf.Log(FunctionLibrary.GetObjectRadius(CombatComponent.gameObject) + 1f, 10f) * 250f;
			}
		}
	}

	protected override void Start()
	{
		base.Start();
		SetBarMaxValue(1f);
		if ((bool)CombatComponent)
		{
			SetBarValue(CombatComponent.Health / CombatComponent.MaxHealth);
		}
		else
		{
			SetBarValue(1f);
		}
	}

	protected virtual void OnHealthChanged(float newValue, float oldValue)
	{
		SetBarValue(newValue / CombatComponent.MaxHealth);
	}

	protected virtual void OnDie(CombatComponent cc)
	{
		CombatComponent.onHealthChanged -= OnHealthChanged;
		CombatComponent.onDie -= OnDie;
	}
}
