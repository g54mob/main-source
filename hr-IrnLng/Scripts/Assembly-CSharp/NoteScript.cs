using UnityEngine;

public class NoteScript : ImportantObjectClass
{
	public CanvasGroup Group;

	public AudioSource Sound;

	private SteamScript SScript;

	private void Start()
	{
		SScript = GameObject.Find("SteamObject").GetComponent<SteamScript>();
	}

	private void Update()
	{
	}

	public override void DoInteraction()
	{
		ToggleNote(b: true);
		SScript.UnlockCheevo("read_note");
	}

	public void ToggleNote(bool b)
	{
		if (b)
		{
			Group.alpha = 1f;
			Sound.Play();
		}
		else
		{
			Group.alpha = 0f;
		}
	}

	public bool NoteState()
	{
		if (Group.alpha == 1f)
		{
			return true;
		}
		return false;
	}
}
