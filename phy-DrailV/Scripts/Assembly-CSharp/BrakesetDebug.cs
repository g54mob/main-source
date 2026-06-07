using CommandTerminal;
using TMPro;
using UnityEngine;

public class BrakesetDebug : MonoBehaviour
{
	private const string PREFAB_NAME = "BrakesetDebug";

	private TrainCar car;

	private TextMeshPro textMesh;

	private static bool showDebug;

	private void Start()
	{
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("BrakesetDebug"), base.transform);
		car = GetComponent<TrainCar>();
		textMesh = gameObject.GetComponentInChildren<TextMeshPro>(includeInactive: true);
	}

	private void Update()
	{
		bool activeSelf = textMesh.gameObject.activeSelf;
		if (!showDebug)
		{
			if (activeSelf)
			{
				textMesh.gameObject.SetActive(value: false);
			}
			return;
		}
		if (!activeSelf)
		{
			textMesh.gameObject.SetActive(value: true);
		}
		string text = $"{car.trainset.id}\n{car.indexInTrainset}\n{car.brakeSystem.brakeset.id}\n{car.brakeSystem.indexInBrakeset}";
		text += "\n";
		text = text + (car.frontCoupler.IsCockOpen ? "F" : "") + (car.rearCoupler.IsCockOpen ? "R" : "");
		textMesh.text = text;
		float num = Vector3.Dot(textMesh.transform.parent.forward, textMesh.transform.parent.position - PlayerManager.PlayerTransform.transform.position);
		textMesh.transform.localRotation = Quaternion.Euler(0f, (num < 0f) ? 180 : 0, 0f);
	}

	private static void Debug_brakes(CommandArg[] args)
	{
		showDebug = !showDebug;
	}
}
