using UnityEngine;

public class BreakableWall : MonoBehaviour
{
	[SerializeField]
	private GameObject broken_Prefab;

	private bool hasBroken;

	public int wallTier;

	[SerializeField]
	private bool pauseAmbienceOnDestroy;

	public void BreakWall(Vector3 _impactPos)
	{
		hasBroken = true;
		GameObject gameObject = Object.Instantiate(broken_Prefab, base.transform.position, base.transform.rotation);
		gameObject.transform.localScale = base.transform.localScale;
		AudioManager.Singleton.PlayWallBreakingSFX(_impactPos);
		Material material = base.transform.GetChild(0).GetComponent<MeshRenderer>().material;
		Rigidbody rigidbody = null;
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < 8; i++)
		{
			gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().material = material;
			rigidbody = gameObject.transform.GetChild(i).GetComponent<Rigidbody>();
			if ((bool)rigidbody)
			{
				zero = (rigidbody.transform.position - _impactPos).normalized;
				zero.y = 1f;
				rigidbody.AddForce(zero * 10f, ForceMode.VelocityChange);
			}
		}
		try
		{
			int index = GameManager.Singleton.walls_MasterList.IndexOf(this);
			GameManager.Singleton.walls_MasterList_Bools[index] = false;
		}
		catch
		{
			Debug.Log("FAILED to find this wall in the master list, Check to make sure this milestone is included in the master list");
		}
		if (pauseAmbienceOnDestroy)
		{
			AudioManager.Singleton.PauseAmbientTrack();
		}
		PlayerStats.Singleton.IncreaseWallsBrokenStat();
		Object.Destroy(base.gameObject);
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Blender") && PlayerStats.Singleton.SledgeHammer_Tier >= wallTier)
		{
			AudioManager.Singleton.PlaySFX_ChainSawRev(other.transform.position);
			BreakWall(other.transform.position);
		}
	}
}
