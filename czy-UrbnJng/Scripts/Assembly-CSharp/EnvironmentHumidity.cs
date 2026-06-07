using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnvironmentHumidity : MonoBehaviour
{
	public enum Humidity
	{
		Low = 0,
		Middle = 1,
		High = 2
	}

	[SerializeField]
	public Humidity humidity;

	[SerializeField]
	public LayerMask visualColliderLayermask;

	[SerializeField]
	private DecalProjector decalProjector;

	private bool canChange = true;

	public bool movable = true;

	private void Awake()
	{
		Hide();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (canChange && ((int)visualColliderLayermask & (1 << other.gameObject.layer)) == 1 << other.gameObject.layer)
		{
			Show();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (canChange && ((int)visualColliderLayermask & (1 << other.gameObject.layer)) == 1 << other.gameObject.layer)
		{
			Hide();
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (canChange && ((int)visualColliderLayermask & (1 << other.gameObject.layer)) == 1 << other.gameObject.layer)
		{
			Show();
		}
	}

	public void SetCanChange(bool value)
	{
		canChange = value;
	}

	public void Show()
	{
		if (movable)
		{
			decalProjector.fadeFactor = 1f;
		}
	}

	public void Hide()
	{
		decalProjector.fadeFactor = 0f;
	}
}
