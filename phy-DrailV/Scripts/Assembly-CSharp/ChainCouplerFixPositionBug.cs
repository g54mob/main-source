using UnityEngine;

public class ChainCouplerFixPositionBug : MonoBehaviour
{
	private Vector3 initialLocalPosition;

	private void Awake()
	{
		initialLocalPosition = base.transform.localPosition;
	}

	private void OnEnable()
	{
		base.transform.localPosition = initialLocalPosition;
	}
}
