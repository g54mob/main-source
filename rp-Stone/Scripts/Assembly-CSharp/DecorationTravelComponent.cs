using UnityEngine;

[RequireComponent(typeof(Decoration))]
public class DecorationTravelComponent : MonoBehaviour
{
	public int durationTics;

	public float velocityX;

	public float velocityY;

	public float velocityZ;

	private Decoration myDecoration;

	private float f_x;

	private float f_y;

	private float f_z;

	private void HandleUpdateTic(Character character)
	{
		if (durationTics-- >= 0)
		{
			f_x += velocityX;
			f_y += velocityY;
			f_z += velocityZ;
			while (f_x <= -1f)
			{
				f_x += 1f;
				myDecoration.PositionX--;
			}
			while (f_x >= 1f)
			{
				f_x -= 1f;
				myDecoration.PositionX++;
			}
			while (f_y <= -1f)
			{
				f_y += 1f;
				myDecoration.PositionY--;
			}
			while (f_y >= 1f)
			{
				f_y -= 1f;
				myDecoration.PositionY++;
			}
			while (f_z <= -1f)
			{
				f_z += 1f;
				myDecoration.PositionZ--;
			}
			while (f_z >= 1f)
			{
				f_z -= 1f;
				myDecoration.PositionZ++;
			}
		}
	}

	private void Awake()
	{
		myDecoration = GetComponent<Decoration>();
		myDecoration.OnUpdateTic += HandleUpdateTic;
	}

	private void OnDestroy()
	{
		myDecoration.OnUpdateTic -= HandleUpdateTic;
	}
}
