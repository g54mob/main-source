using UnityEngine;

public class PlayToolButton : DogButtonBase
{
	public PlayToolMode newMode;

	public GameObject selectorObject;

	private void Update()
	{
		InternalUpdate();
	}

	protected virtual void InternalUpdate()
	{
		if (homeRef.GetCurrentMode() == newMode)
		{
			selectorObject.SetActive(value: true);
		}
		else
		{
			selectorObject.SetActive(value: false);
		}
	}

	protected override void ButtonBehavior()
	{
		homeRef.SetMode(newMode);
	}
}
