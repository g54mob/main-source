using FIMSpace.FProceduralAnimation;
using UnityEngine;

public class DEMO_LegsAnim_RedirectVector : MonoBehaviour
{
	public LegsAnimator Legs;

	public Vector3 Dir = Vector3.zero;

	private void Start()
	{
	}

	private void Update()
	{
		Legs.SetCustomIKRotatorVector(Legs.transform.rotation * Dir);
		Legs.User_UpdateParametersAfterManualChange();
	}
}
