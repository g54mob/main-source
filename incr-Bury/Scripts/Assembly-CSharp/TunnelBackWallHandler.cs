using UnityEngine;

public class TunnelBackWallHandler : MonoBehaviour
{
	[SerializeField]
	private GameObject belladonnaPlantBed;

	[SerializeField]
	private float playerDistThreshold;

	[SerializeField]
	private float wall_MoveSpeed;

	[SerializeField]
	private Vector2 moveSpectrum;

	private void Start()
	{
		moveSpectrum.x = base.transform.position.z;
	}

	private void Update()
	{
		HandleMovingWall();
	}

	private void HandleMovingWall()
	{
		if (GameManager.Singleton.isInsideBellaDonnaTunnel && base.transform.position.z < moveSpectrum.y && Vector3.Distance(GameManager.Singleton.playerObject.transform.position, belladonnaPlantBed.transform.position) < playerDistThreshold)
		{
			base.transform.Translate(Vector3.forward * (wall_MoveSpeed * Time.deltaTime), Space.World);
			if (base.transform.position.z > moveSpectrum.y)
			{
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, moveSpectrum.y);
			}
		}
	}
}
