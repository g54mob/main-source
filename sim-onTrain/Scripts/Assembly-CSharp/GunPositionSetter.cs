using UnityEngine;

public class GunPositionSetter : MonoBehaviour
{
	[SerializeField]
	private int prefabID;

	[SerializeField]
	private PlayerGunsHolder gunsHolder;

	private void OnEnable()
	{
		SetParents();
	}

	private void SetParents()
	{
		TSGunObject tSGunObject = gunsHolder.guns.Find((TSGunObject x) => x.id == prefabID);
		tSGunObject.go.transform.parent = base.transform;
		tSGunObject.go.transform.localEulerAngles = Vector3.zero;
		tSGunObject.go.transform.localPosition = Vector3.zero;
		tSGunObject.go.transform.localScale = Vector3.one;
	}
}
