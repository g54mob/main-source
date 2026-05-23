using UnityEngine;

public class PerkDestroyGameObjectModifyer : MonoBehaviour
{
	[SerializeField]
	private Equippable perk;

	[SerializeField]
	private bool destroyIfPerkIsEquipped;

	[SerializeField]
	private bool destroyIfPerkIsNotEquipped;

	public virtual bool IsGoingToBeDestroyed
	{
		get
		{
			if (PerkManager.IsEquipped(perk))
			{
				if (destroyIfPerkIsEquipped)
				{
					return true;
				}
			}
			else if (destroyIfPerkIsNotEquipped)
			{
				return true;
			}
			return false;
		}
	}

	public virtual void Start()
	{
		if (PerkManager.IsEquipped(perk))
		{
			if (destroyIfPerkIsEquipped)
			{
				Object.Destroy(base.gameObject);
			}
		}
		else if (destroyIfPerkIsNotEquipped)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
