using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Manager9 : MonoBehaviour
{
	public static Manager9 instance;

	[SerializeField]
	private PlayableDirector director;

	[SerializeField]
	private int eventIndex;

	[SerializeField]
	private Dialogue dialogue;

	[SerializeField]
	private SFX music;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		PlayerManager.instance.LockAll();
	}

	public void TriggerEvent()
	{
		switch (eventIndex)
		{
		case 0:
			director.Pause();
			dialogue.StartDialogue(190, 191, delegate
			{
				director.Resume();
			});
			break;
		case 1:
			director.Pause();
			dialogue.StartDialogue(192, 192, delegate
			{
				director.Resume();
			});
			break;
		case 2:
			director.Pause();
			dialogue.StartDialogue(193, 198, delegate
			{
				director.Resume();
			});
			break;
		case 3:
			director.Pause();
			dialogue.StartDialogue(199, 199, delegate
			{
				director.Resume();
			});
			break;
		case 4:
			director.Pause();
			dialogue.StartDialogue(200, 203, delegate
			{
				director.Resume();
			});
			break;
		case 5:
			director.Pause();
			music.PlaySoundLoop("Horror4");
			dialogue.StartDialogue(204, 204, delegate
			{
				music.Stop();
				director.Resume();
			});
			break;
		case 6:
			director.Pause();
			dialogue.StartDialogue(205, 207, delegate
			{
				director.Resume();
			});
			break;
		case 7:
			director.Pause();
			dialogue.StartDialogue(208, 208, delegate
			{
				director.Resume();
			});
			break;
		case 8:
			director.Pause();
			dialogue.StartDialogue(209, 209, delegate
			{
				director.Resume();
			});
			break;
		case 9:
			director.Pause();
			dialogue.StartDialogue(210, 210, delegate
			{
				director.Resume();
			});
			break;
		case 10:
			director.Pause();
			dialogue.StartDialogue(211, 211, delegate
			{
				director.Resume();
			});
			break;
		case 11:
			director.Pause();
			dialogue.StartDialogue(212, 213, delegate
			{
				director.Resume();
			});
			break;
		case 12:
			SceneManager.LoadScene("Scene10");
			break;
		}
		eventIndex++;
	}

	public void PlayCutscene(string scene)
	{
		director.playableAsset = Resources.Load<PlayableAsset>("Timeline/" + scene);
		director.Play();
	}
}
