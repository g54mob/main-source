using UnityEngine;

public class SceneRoot : MonoBehaviour
{
	public enum ClockMode
	{
		Play = 0,
		Menu = 1
	}

	public bool awakeInactive;

	public OneBit oneBit;

	public ClockMode clockMode;

	public RInput.Mode inputMode;

	private void Awake()
	{
		if ((awakeInactive && Game.instance != null) || LocReview.active)
		{
			Activate(false);
		}
		else
		{
			Activate(true);
		}
	}

	public void Activate(bool a)
	{
		if (a)
		{
			Debug.Log("Activating scene: " + base.name);
			if (awakeInactive || LocReview.active)
			{
				base.gameObject.SetActive(true);
			}
			SetOneBitEnabled(true);
			Clock.menu.running = clockMode == ClockMode.Menu;
			Clock.play.running = clockMode == ClockMode.Play;
			RInput.mode = inputMode;
		}
		else
		{
			if (awakeInactive || LocReview.active)
			{
				base.gameObject.SetActive(false);
			}
			SetOneBitEnabled(false);
		}
	}

	public void SetOneBitEnabled(bool enabled)
	{
		if (oneBit == null)
		{
			return;
		}
		oneBit.gameObject.SetActive(enabled);
		if (Game.instance != null)
		{
			AudioListener component = oneBit.sourceCamera.GetComponent<AudioListener>();
			if (component != null)
			{
				component.enabled = clockMode == ClockMode.Play;
			}
		}
		else
		{
			AudioListener component2 = oneBit.sourceCamera.GetComponent<AudioListener>();
			if (component2 != null)
			{
				component2.enabled = enabled;
			}
		}
	}
}
