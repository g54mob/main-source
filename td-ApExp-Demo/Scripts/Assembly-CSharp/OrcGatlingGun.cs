using UnityEngine;

public class OrcGatlingGun : MonoBehaviour
{
	[SerializeField]
	private E1_2Technical technical;

	public void Shoot()
	{
		technical.Shoot();
	}
}
