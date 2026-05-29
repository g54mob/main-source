using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Manager8 : MonoBehaviour
{
	public static Manager8 instance;

	[SerializeField]
	private PlayableDirector director;

	[SerializeField]
	private int eventIndex;

	[SerializeField]
	private Dialogue dialogue;

	[SerializeField]
	private InteractObject door;

	[SerializeField]
	private InteractObject doll;

	[SerializeField]
	private InteractObject closet;

	[SerializeField]
	private GameObject trigger2;

	[SerializeField]
	private GameObject trigger3;

	[SerializeField]
	private GameObject doll2;

	[SerializeField]
	private GameObject doll3;

	[SerializeField]
	private Animator doorAnim;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		PlayerManager.instance.ArrangePlayer();
	}

	public void TriggerEvent()
	{
		switch (eventIndex)
		{
		case 0:
			PlayerManager.instance.LockMovement();
			doll.interactable = false;
			dialogue.StartDialogue(165, 169, delegate
			{
				door.interactable = true;
				PlayerManager.instance.UnlockAll();
			});
			break;
		case 1:
			PlayerManager.instance.LockAll();
			PlayCutscene("Scene12");
			break;
		case 2:
			Object.Destroy(doll.gameObject);
			director.Pause();
			dialogue.StartDialogue(170, 171, delegate
			{
				director.Resume();
			});
			break;
		case 3:
			director.Pause();
			dialogue.StartDialogue(172, 173, delegate
			{
				director.Resume();
			});
			break;
		case 4:
			director.Pause();
			dialogue.StartDialogue(174, 175, delegate
			{
				director.Resume();
			});
			break;
		case 5:
			director.Pause();
			dialogue.StartDialogue(176, 179, delegate
			{
				director.Resume();
			});
			break;
		case 6:
			director.Pause();
			dialogue.StartDialogue(180, 183, delegate
			{
				director.Resume();
			});
			break;
		case 7:
			director.Pause();
			dialogue.StartDialogue(184, 184, delegate
			{
				director.Resume();
			});
			break;
		case 8:
			director.Pause();
			PlayerManager.instance.UnlockAll();
			PlayerManager.instance.ArrangePlayer();
			trigger2.SetActive(value: true);
			break;
		case 9:
			director.Resume();
			PlayerManager.instance.LockAll();
			director.Resume();
			break;
		case 10:
			director.Pause();
			dialogue.StartDialogue(185, 185, delegate
			{
				director.Resume();
			});
			break;
		case 11:
			director.Pause();
			trigger3.SetActive(value: true);
			PlayerManager.instance.UnlockAll();
			PlayerManager.instance.ArrangePlayer();
			doorAnim.Play("StayOpen");
			break;
		case 12:
			director.Resume();
			PlayerManager.instance.LockAll();
			break;
		case 13:
			doll2.SetActive(value: true);
			director.Pause();
			dialogue.StartDialogue(186, 188, delegate
			{
				director.Resume();
			});
			break;
		case 14:
			director.Pause();
			dialogue.StartDialogue(189, 189, delegate
			{
				director.Stop();
				PlayerManager.instance.UnlockAll();
				PlayerManager.instance.ArrangePlayer();
				closet.interactable = true;
				Object.Destroy(doll2);
				doll3.SetActive(value: true);
			});
			break;
		case 15:
			SceneManager.LoadScene("Scene9");
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
