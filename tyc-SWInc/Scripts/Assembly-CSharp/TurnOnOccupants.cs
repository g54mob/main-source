using UnityEngine;

public class TurnOnOccupants : MonoBehaviour
{
	private Furniture furn;

	public GameObject spin;

	private float spinSpeed;

	private void Awake()
	{
		if (spin == null)
		{
			spin = null;
		}
	}

	private void Start()
	{
		furn = GetComponent<Furniture>();
	}

	private void FixedUpdate()
	{
		if (furn == null || furn.Parent == null)
		{
			return;
		}
		if (furn.IsOn)
		{
			if (!spin.IsReferenceNull())
			{
				spinSpeed = Mathf.Lerp(spinSpeed, 7f, Time.deltaTime * 0.3f * GameSettings.GameSpeed);
				spin.transform.rotation = spin.transform.rotation * Quaternion.Euler(0f, spinSpeed * GameSettings.GameSpeed, 0f);
			}
			if (!furn.Parent.AnyOccupantsAtrium(true))
			{
				furn.IsOn = false;
			}
			return;
		}
		if (!spin.IsReferenceNull() && spinSpeed > 0f)
		{
			if (Mathf.Approximately(spinSpeed, 0f))
			{
				spinSpeed = 0f;
			}
			else
			{
				spinSpeed = Mathf.Lerp(spinSpeed, 0f, Time.deltaTime * 0.3f * GameSettings.GameSpeed);
				spin.transform.rotation = spin.transform.rotation * Quaternion.Euler(0f, spinSpeed * GameSettings.GameSpeed, 0f);
			}
		}
		if (furn.Parent.AnyOccupantsAtrium(true))
		{
			furn.IsOn = true;
		}
	}
}
