using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Manager5 : MonoBehaviour
{
	public static Manager5 instance;

	[SerializeField]
	private PlayableDirector director;

	[SerializeField]
	private int eventIndex;

	[SerializeField]
	private Dialogue dialogue;

	[SerializeField]
	private PostProcessVolume volume;

	[SerializeField]
	private PostProcessProfile pro1;

	[SerializeField]
	private PostProcessProfile pro2;

	[SerializeField]
	private SFX sfx;

	[SerializeField]
	private Options options;

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
			dialogue.StartDialogue(119, 121, delegate
			{
				director.Resume();
			});
			break;
		case 1:
			director.Pause();
			dialogue.StartDialogue(122, 127, delegate
			{
				director.Resume();
			});
			break;
		case 2:
			director.Pause();
			dialogue.StartDialogue(128, 134, delegate
			{
				director.Resume();
				PlayerManager.instance.UnlockAll();
				PlayerManager.instance.ArrangePlayer();
			});
			break;
		case 3:
			sfx.PlaySound("Fall");
			break;
		case 4:
			volume.profile = pro2;
			PlayCutscene("Scene7");
			PlayerManager.instance.SetMovementSpeed(100f, 2f);
			break;
		case 5:
			options.UpdateFilter();
			break;
		case 6:
			volume.profile = pro2;
			PlayerManager.instance.LockAll();
			break;
		case 7:
			options.UpdateFilter();
			break;
		case 8:
			director.Stop();
			PlayCutscene("Scene8");
			break;
		case 9:
			director.Pause();
			dialogue.StartDialogue(135, 136, delegate
			{
				director.Resume();
			});
			break;
		case 10:
			director.Pause();
			dialogue.StartDialogue(137, 145, delegate
			{
				director.Resume();
			});
			break;
		case 11:
			SceneManager.LoadScene("Scene6");
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
