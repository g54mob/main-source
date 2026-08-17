using Assets.Scripts.Actors;

namespace Assets.Scripts.Inventory__Items__Pickups.Items;

public class ItemAttackModifier
{
	public float flatValues;

	public float additiveValues;

	public float multiplicativeValues = 1f;

	private float _003CdamageMultiplier_003Ek__BackingField = 1f;

	public float damageMultiplier
	{
		get
		{
			return _003CdamageMultiplier_003Ek__BackingField;
		}
		private set
		{
			_003CdamageMultiplier_003Ek__BackingField = value;
		}
	}

	public void Recycle()
	{
		multiplicativeValues = 1f;
		flatValues = 0f;
	}

	public void Apply(DamageContainer dc)
	{
		float damage = _003CdamageMultiplier_003Ek__BackingField * dc.damage;
		dc.damage = damage;
	}

	public void AddMultiplier(float multiplier)
	{
		float num = multiplier * _003CdamageMultiplier_003Ek__BackingField;
		_003CdamageMultiplier_003Ek__BackingField = num;
	}
}
