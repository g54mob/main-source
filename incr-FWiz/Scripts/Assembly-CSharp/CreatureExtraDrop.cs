using UnityEngine;

public class CreatureExtraDrop : MonoBehaviour
{
	public DamageableCreature Damageable;

	[SerializeField]
	private float _dropRadius;

	[SerializeField]
	private float _itemDropDuration;

	public ItemType DropItemType;

	public float Chance;

	public void AddChance(float chance)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnHit(bool finishing)
	{
	}
}
