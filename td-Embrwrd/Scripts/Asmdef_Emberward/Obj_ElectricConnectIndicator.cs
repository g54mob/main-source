using UnityEngine;

public class Obj_ElectricConnectIndicator : MonoBehaviour
{
	[SerializeField]
	private Renderer renderer_Icon;

	[SerializeField]
	private Material mat_Electrified;

	[SerializeField]
	private Material mat_UnElectrified;

	[SerializeField]
	private Obj_AncientMech_Base ancientMech;

	private bool isActivated;

	private Vector3Int positionInt;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnToggleElectricConnectIndicator(bool isOn)
	{
	}

	public void Toggle(bool isOn)
	{
	}
}
