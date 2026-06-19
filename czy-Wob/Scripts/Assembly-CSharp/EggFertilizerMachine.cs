using UnityEngine;

public class EggFertilizerMachine : ClickableObject
{
	public GameObject guiPrefab;

	private EggFertilizerGUIController eggGuiRef;

	protected override void OnClickInternal()
	{
		GameObject gameObject = Object.Instantiate(guiPrefab, Vector3.zero, Quaternion.identity);
		eggGuiRef = gameObject.GetComponent<EggFertilizerGUIController>();
		eggGuiRef.SetMachineRef(this);
	}
}
