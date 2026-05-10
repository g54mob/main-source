using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "TutorialQuest_moveCamera", menuName = "Tower Factory/Tutorial/Move Camera Quest")]
public class TutorialQuestData_moveCamera : TutorialQuestData
{
	[SerializeField]
	private float distanceToMove = 1f;

	[SerializeField]
	private float degreesToRotate = 45f;

	private float movedDistance;

	private float rotatedDegrees;

	private Vector3 lastCameraPosition;

	private float lastCameraYaw;

	private IsometricCamera playerCamera;

	public override string GetObjectiveText()
	{
		string text = "";
		bool num = movedDistance >= distanceToMove;
		bool flag = rotatedDegrees >= degreesToRotate;
		if (num)
		{
			text += "<s>";
		}
		text += new LocalizedString("Tutorial", "Tutorial_text_moveCamera").GetLocalizedString();
		if (num)
		{
			text += "</s>";
		}
		text += "\n";
		if (flag)
		{
			text += "<s>";
		}
		text += new LocalizedString("Tutorial", "Tutorial_text_rotateCamera").GetLocalizedString();
		if (flag)
		{
			text += "</s>";
		}
		return text;
	}

	public override void StartQuest()
	{
		base.StartQuest();
		playerCamera = LTFunctionLibrary.GetLTPlayerController().PlayerCamera as IsometricCamera;
		movedDistance = 0f;
		rotatedDegrees = 0f;
		lastCameraPosition = playerCamera.transform.position;
		lastCameraYaw = playerCamera.WorldRotation;
	}

	public override bool UpdateQuest()
	{
		bool num = movedDistance >= distanceToMove;
		bool flag = rotatedDegrees >= degreesToRotate;
		movedDistance += Vector3.Distance(lastCameraPosition, playerCamera.transform.position);
		rotatedDegrees += Mathf.Abs(lastCameraYaw - playerCamera.WorldRotation);
		lastCameraPosition = playerCamera.transform.position;
		lastCameraYaw = playerCamera.WorldRotation;
		if (num == movedDistance >= distanceToMove)
		{
			return flag != rotatedDegrees >= degreesToRotate;
		}
		return true;
	}

	public override bool IsComplete()
	{
		if (movedDistance >= distanceToMove)
		{
			return rotatedDegrees >= degreesToRotate;
		}
		return false;
	}
}
