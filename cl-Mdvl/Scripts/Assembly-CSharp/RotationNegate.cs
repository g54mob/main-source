using UnityEngine;

public class RotationNegate : MonoBehaviour
{
	[SerializeField]
	private GameObject rainEffectParent;

	private Quaternion rotation;

	private void Awake()
	{
		rotation = rainEffectParent.transform.rotation;
	}

	private void LateUpdate()
	{
		rainEffectParent.transform.rotation = rotation;
	}
}
