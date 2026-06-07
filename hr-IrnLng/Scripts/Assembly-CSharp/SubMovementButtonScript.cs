using UnityEngine;

public class SubMovementButtonScript : ImportantObjectClass
{
	public float Direction;

	public Vector3 Rotate;

	public SubController SubC;

	private bool ButtonPressed;

	public GameObject VisualButton;

	public float PressedY;

	private float NormalY;

	private int ButtonResetCount;

	public AudioSource ButtonSound;

	private void Start()
	{
		NormalY = VisualButton.transform.position.y;
	}

	private void Update()
	{
		if (ButtonPressed)
		{
			VisualButton.transform.position = new Vector3(VisualButton.transform.position.x, PressedY, VisualButton.transform.position.z);
		}
		else
		{
			VisualButton.transform.position = new Vector3(VisualButton.transform.position.x, NormalY, VisualButton.transform.position.z);
		}
	}

	private void FixedUpdate()
	{
		ButtonResetCount++;
		if (ButtonResetCount >= 5)
		{
			ButtonResetCount = 5;
			ButtonPressed = false;
		}
	}

	public override void DoConstantInteraction()
	{
		SubC.AddVelocity(Direction, Rotate);
		if (!ButtonPressed)
		{
			ButtonSound.Play();
		}
		ButtonPressed = true;
		ButtonResetCount = 0;
	}
}
