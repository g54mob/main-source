using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_PortalTowerEnergy : MonoBehaviour
{
	[SerializeField]
	private Image image_Bar;

	[SerializeField]
	private TMP_Text text_UpgradeAEffectTimer;

	[SerializeField]
	private Image image_Infinite;

	private Transform trackTarget;

	private Vector3 offset;

	public static UI_Obj_PortalTowerEnergy Create(Transform trackTarget, Vector3 offset)
	{
		return null;
	}

	private void Update()
	{
	}

	internal void SetTrackingTarget(Transform target, Vector3 offset)
	{
	}

	public void SetEnergyPercentage(float percentage)
	{
	}

	public void ToggleUpgradeAEffect(bool isOn)
	{
	}

	public void SetUpgradeAEffectTimer(int time)
	{
	}
}
