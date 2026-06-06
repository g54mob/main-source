using UnityEngine;

public class BuildableTester : MonoBehaviour
{
	[SerializeField]
	private Buildable _prefab;

	private void Start()
	{
		Community community = new Community("Player", Community.Type.Player);
		Buildable buildable = Object.Instantiate(_prefab, Vector3.zero, Quaternion.identity);
		buildable.Initialize(community, -1);
		buildable.FinishBuilding();
	}

	private void OnDestroy()
	{
		Community.DestroyAll();
	}
}
