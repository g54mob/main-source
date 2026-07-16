using UnityEngine;

[CreateAssetMenu(fileName = "25Vision", menuName = "Radar/25Vision")]
public class RadarVision : EnhancementRadar
{
	[SerializeField]
	private float cameraDstMultIncrease = 0.25f;

	public override void OnApplied()
	{
		CameraController.Instance.InteractCameraDstMult += cameraDstMultIncrease;
	}

	public override void OnRemoved()
	{
		CameraController.Instance.InteractCameraDstMult -= cameraDstMultIncrease;
	}
}
