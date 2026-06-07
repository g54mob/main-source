using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class HealthComponent : MonoBehaviour
	{
		[Header("Parameters")]
		[SerializeField]
		public float healthPoints = 100f;

		[Header("Logic")]
		[SerializeField]
		private UnityEvent onHpZero;

		[SerializeField]
		private UnityEvent<float> onHpChanged;

		public void ChangeHealthPoints(float amountToChange)
		{
			healthPoints += amountToChange;
			onHpChanged?.Invoke(amountToChange);
			if (healthPoints <= 0f)
			{
				onHpZero?.Invoke();
			}
		}
	}
}
