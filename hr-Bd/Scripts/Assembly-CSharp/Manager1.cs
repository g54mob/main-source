using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Manager1 : MonoBehaviour
{
	public static Manager1 instance;

	[SerializeField]
	private PlayableDirector director;

	[SerializeField]
	private int eventIndex;

	[SerializeField]
	private Dialogue dialogue;

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
			dialogue.StartDialogue(0, 2, delegate
			{
				director.Resume();
			});
			break;
		case 1:
			director.Pause();
			dialogue.StartDialogue(3, 5, delegate
			{
				director.Resume();
			});
			break;
		case 2:
			director.Pause();
			dialogue.StartDialogue(6, 12, delegate
			{
				director.Resume();
			});
			break;
		case 3:
			director.Pause();
			dialogue.StartDialogue(13, 14, delegate
			{
				director.Resume();
			});
			break;
		case 4:
			director.Pause();
			dialogue.StartDialogue(15, 15, delegate
			{
				director.Resume();
			});
			break;
		case 5:
			director.Pause();
			dialogue.StartDialogue(16, 17, delegate
			{
				director.Resume();
			});
			break;
		case 6:
			director.Pause();
			dialogue.StartDialogue(18, 20, delegate
			{
				director.Resume();
			});
			break;
		case 7:
			director.Stop();
			PlayerManager.instance.UnlockAll();
			PlayerManager.instance.ArrangePlayer();
			break;
		case 8:
			PlayerManager.instance.LockAll();
			PlayCutscene("Scene2");
			break;
		case 9:
			SceneManager.LoadScene("Scene2");
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
