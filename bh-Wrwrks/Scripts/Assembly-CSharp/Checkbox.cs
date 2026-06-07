using System.Collections;
using UnityEngine;

public class Checkbox : MonoBehaviour
{
	public enum func
	{
		Fullscreen = 0,
		Screenshake = 1,
		Stretch = 2,
		ColectionUpgrades = 3
	}

	public func f;

	public MonoBehaviour owner;

	public SpriteRenderer check;

	public bool state;

	public void Toggle()
	{
		state = !state;
		check.enabled = state;
		if (state)
		{
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.DragModule, 0.9f, 0.5f);
			StartCoroutine(bouncer(check));
		}
		else
		{
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.DragModule, 0.8f, 0.5f);
		}
		Set(state);
	}

	private IEnumerator bouncer(SpriteRenderer b, int f = 2)
	{
		for (int i = 0; i < f; i++)
		{
			b.transform.localPosition += new Vector3(0f, 0.0625f);
			yield return AnimationManager.WaitUI(1);
		}
		for (int i = 0; i < f; i++)
		{
			yield return AnimationManager.WaitUI(1);
			b.transform.localPosition -= new Vector3(0f, 0.0625f);
		}
	}

	public void Set(bool s, bool silent = false)
	{
		state = s;
		check.enabled = state;
		if (!silent)
		{
			Invoke(f.ToString(), 0f);
		}
	}

	private void Fullscreen()
	{
		owner.GetComponent<SettingsMenu>().SetFullscreen(state);
	}

	private void Screenshake()
	{
		owner.GetComponent<SettingsMenu>().SetScreenshake(state);
	}

	private void Stretch()
	{
		owner.GetComponent<SettingsMenu>().SetStretch(state);
	}

	private void ColectionUpgrades()
	{
		owner.GetComponent<CollectionMenu>().ToggleUpgrade(state);
	}

	private void OnMouseUpAsButton()
	{
		Toggle();
	}
}
