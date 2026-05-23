using UnityEngine;

public class Teleport : MonoBehaviour
{
	public bool usePlayerStart;

	private void OnEnable()
	{
		Player instance = Player.instance;
		if (usePlayerStart && instance.playerStart != null)
		{
			PlayerStart playerStart = instance.playerStart;
			instance.DropToFloor(playerStart.transform.position);
			instance.look = Quaternion.Euler(playerStart.lookUpDownAngle, playerStart.transform.rotation.eulerAngles.y, playerStart.transform.rotation.eulerAngles.z);
		}
		else
		{
			instance.DropToFloor(base.transform.position);
			instance.look = base.transform.rotation;
		}
		base.gameObject.SetActive(false);
	}
}
