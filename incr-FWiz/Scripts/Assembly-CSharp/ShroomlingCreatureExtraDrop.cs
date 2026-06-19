using UnityEngine;

public class ShroomlingCreatureExtraDrop : MonoBehaviour
{
	[SerializeField]
	private ShroomlingCreature _shroomlingCreature;

	[SerializeField]
	private ItemType _itemType;

	[SerializeField]
	private float _chance;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnFinalHit()
	{
	}

	public void AddChance(float chance)
	{
	}
}
