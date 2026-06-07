using UnityEngine;

public class LilyPad : MonoBehaviour
{
	private bool alternate;

	private void Start()
	{
		RoundPositionToNearestPixel();
		Invoke("MoveOnePixel", Random.Range(0.25f, 5f));
	}

	private void RoundPositionToNearestPixel()
	{
		base.transform.position = new Vector3(Mathf.Round(base.transform.position.x * 16f) / 16f, Mathf.Round(base.transform.position.y * 16f) / 16f);
	}

	private void MoveOnePixel()
	{
		alternate = !alternate;
		if (alternate)
		{
			base.transform.position += new Vector3(0f, 0.0625f);
		}
		else
		{
			base.transform.position -= new Vector3(0f, 0.0625f);
		}
		Invoke("MoveOnePixel", Random.Range(2.5f, 5f));
	}
}
