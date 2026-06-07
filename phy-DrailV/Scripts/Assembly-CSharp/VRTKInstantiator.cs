using UnityEngine;
using VRTK;

public class VRTKInstantiator : MonoBehaviour
{
	public GameObject SDKManagerPrefab;

	public GameObject controllerPrefab;

	public GameObject otherScriptsPrefab;

	private void Start()
	{
		VRTK_SDKManager component = Object.Instantiate(SDKManagerPrefab, base.transform).GetComponent<VRTK_SDKManager>();
		component.gameObject.SetActive(value: true);
		GameObject gameObject = Object.Instantiate(controllerPrefab, base.transform);
		gameObject.name = "LeftController";
		GameObject gameObject2 = Object.Instantiate(controllerPrefab, base.transform);
		gameObject2.name = "RightController";
		component.scriptAliasLeftController = gameObject;
		component.scriptAliasRightController = gameObject2;
		Object.Instantiate(otherScriptsPrefab, base.transform);
		component.TryLoadSDKSetupFromList();
	}
}
