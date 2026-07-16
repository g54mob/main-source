using UnityEngine;

public class ToolComponent : MonoBehaviour
{
	[SerializeField]
	private Transform impactPoint;

	public Transform GetImpactPoint()
	{
		return impactPoint;
	}
}
