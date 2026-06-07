using UnityEngine;

public class TutorialTurnTableFinder : MonoBehaviour
{
	public TurntableController controller;

	public void ResetTurntable()
	{
		if (controller == null)
		{
			Initialize();
		}
		controller.turntable.targetYRotation = 0f;
		controller.turntable.RotateToTargetRotation();
	}

	public void Initialize()
	{
		if (!(controller != null))
		{
			Vector3 position = base.transform.position;
			TurntableController turntableController = TurntableController.FindClosestTo(position);
			if (Vector3.SqrMagnitude(turntableController.transform.position - position) <= 100f)
			{
				controller = turntableController;
			}
		}
	}
}
