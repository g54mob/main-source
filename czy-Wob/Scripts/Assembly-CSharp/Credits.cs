using UnityEngine;

public class Credits : MonoBehaviour
{
	public MainMenu mainMenuRef;

	public Transform scrollTransform;

	private Vector3 scrollSpeedDefault = new Vector3(0f, 50f, 0f);

	private Vector3 scrollSpeedFast = new Vector3(0f, 500f, 0f);

	private Vector3 startingScrollPos = new Vector3(0f, -895f, 0f);

	private Vector3 endingScrollPos = new Vector3(0f, 16500f, 0f);

	private void Awake()
	{
		scrollTransform.localPosition = startingScrollPos;
	}

	private void OnEnable()
	{
		scrollTransform.localPosition = startingScrollPos;
	}

	private void Update()
	{
		Vector3 vector = scrollSpeedDefault;
		if (GameControls.actions.Interact.IsPressed)
		{
			vector = scrollSpeedFast;
		}
		else if (GameControls.actions.Cancel.IsPressed)
		{
			vector = -scrollSpeedFast;
		}
		scrollTransform.localPosition += vector * Time.deltaTime;
		if (scrollTransform.localPosition.y < startingScrollPos.y)
		{
			scrollTransform.localPosition = startingScrollPos;
		}
		if (scrollTransform.localPosition.y >= endingScrollPos.y)
		{
			CloseCredits();
		}
	}

	public void CloseCredits()
	{
		mainMenuRef.CloseCredits();
	}
}
