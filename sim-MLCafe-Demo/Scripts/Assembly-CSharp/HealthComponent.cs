using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
	[SerializeField]
	private float health;

	[SerializeField]
	private float maxHealth;

	[SerializeField]
	private bool killOnHealthZero = true;

	private UnityEvent OnHealthBelowZeroEvent = new UnityEvent();

	public float GetHealth()
	{
		return health;
	}

	public float GetMaxHealth()
	{
		return maxHealth;
	}

	public void IncreaseMaxHealth(int amount, bool heal = false)
	{
		maxHealth += amount;
		if (heal)
		{
			health = maxHealth;
		}
	}

	public void DecreaseMaxHealth(float amount)
	{
		maxHealth -= amount;
		if (health >= maxHealth)
		{
			health = maxHealth;
		}
	}

	public void HealAmount(float amount)
	{
		health += amount;
		if (health > maxHealth)
		{
			health = maxHealth;
		}
	}

	public void ReduceHealth(float amount)
	{
		health -= amount;
		if (health <= 0f)
		{
			OnHealthBelowZeroEvent.Invoke();
			if (killOnHealthZero)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}

	public void SubscribeOnDieEvent(UnityAction action)
	{
		if (action != null)
		{
			OnHealthBelowZeroEvent.AddListener(action);
		}
	}

	public void UnsubscribeOnDieEvent(UnityAction action)
	{
		if (action != null)
		{
			OnHealthBelowZeroEvent.RemoveListener(action);
		}
	}
}
