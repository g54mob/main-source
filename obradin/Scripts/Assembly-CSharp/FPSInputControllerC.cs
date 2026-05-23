using UnityEngine;

[RequireComponent(typeof(CharacterMotorC))]
[AddComponentMenu("Character/FPS Input Controller C")]
public class FPSInputControllerC : MonoBehaviour
{
	private CharacterMotorC cmotor;

	private void Awake()
	{
		cmotor = GetComponent<CharacterMotorC>();
	}

	private void Update()
	{
		if (Clock.play.running)
		{
			Vector3 vector = new Vector3(RInput.GetAxis(0), 0f, RInput.GetAxis(1));
			if (vector != Vector3.zero)
			{
				float magnitude = vector.magnitude;
				vector /= magnitude;
				magnitude = Mathf.Min(1f, magnitude);
				magnitude *= magnitude;
				vector *= magnitude;
			}
			cmotor.inputMoveDirection = base.transform.rotation * vector;
			cmotor.inputJump = false;
		}
	}
}
