using UnityEngine;

public class DeparentOnSpawn : MonoBehaviour
{
	private void Start()
	{
		base.transform.SetParent(null);
	}
}
