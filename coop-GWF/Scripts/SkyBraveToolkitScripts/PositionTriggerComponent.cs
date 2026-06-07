using UnityEngine;
using UnityEngine.Events;

public class PositionTriggerComponent : MonoBehaviour
{
	[SerializeField]
	private Vector3 conditionPosition;

	[SerializeField]
	private Vector3 conditionPosition_SFX;

	[SerializeField]
	private UnityEvent onBelowConditionPositionY;

	[SerializeField]
	private UnityEvent onBelowConditionPositionY_SFX;

	[SerializeField]
	private bool bIsBelowConditionPositionY;

	[SerializeField]
	private bool bIsBelowConditionPositionY_SFX;

	private void LateUpdate()
	{
		OnBelowConditionPositionY();
	}

	public void OnBelowConditionPositionY()
	{
		if (!bIsBelowConditionPositionY)
		{
			if (base.transform.position.y < conditionPosition.y)
			{
				onBelowConditionPositionY?.Invoke();
				bIsBelowConditionPositionY = true;
			}
			if (base.transform.position.y < conditionPosition_SFX.y && !bIsBelowConditionPositionY_SFX)
			{
				onBelowConditionPositionY_SFX?.Invoke();
				bIsBelowConditionPositionY_SFX = true;
			}
		}
	}
}
