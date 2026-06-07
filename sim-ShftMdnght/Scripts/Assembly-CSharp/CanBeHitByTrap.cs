using UnityEngine;

public class CanBeHitByTrap : MonoBehaviour
{
	public Hittable hittable;

	private void OnTriggerEnter(Collider otherCol)
	{
		MonoBehaviour.print("HIT SOEMTHING");
		GameObject gameObject = otherCol.gameObject;
		if (gameObject.CompareTag("Bear Trap"))
		{
			MonoBehaviour.print("HIT BEAR TRAP");
			gameObject.gameObject.GetComponent<BearTrap>().Trap();
			hittable.Hit(260f, base.transform.position);
		}
		else if (gameObject.CompareTag("Landmine"))
		{
			gameObject.gameObject.GetComponent<Landmine>().Trap();
		}
	}
}
