using UnityEngine;

public class StatusManager : MonoBehaviour
{
	[SerializeField]
	private GameObject sunderStatusPrefab;

	public void NewSunder(Unit unit)
	{
		Object.Instantiate(sunderStatusPrefab, Vector3.zero, Quaternion.identity, base.transform).GetComponent<Status>().Initialize(unit);
	}
}
