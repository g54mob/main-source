using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Manager3 : MonoBehaviour
{
	public static Manager3 instance;

	[SerializeField]
	private PlayableDirector director;

	[SerializeField]
	private int eventIndex;

	[SerializeField]
	private Dialogue dialogue;

	[SerializeField]
	private InteractObject cat;

	[SerializeField]
	private GameObject closet;

	[SerializeField]
	private GameObject trigger;

	[SerializeField]
	private GameObject black;

	[SerializeField]
	private GameObject music;

	private void Awake()
	{
		instance = this;
	}

	public void TriggerEvent()
	{
		switch (eventIndex)
		{
		case 0:
			cat.interactable = false;
			PlayerManager.instance.LockAll();
			director.Play();
			break;
		case 1:
			director.Pause();
			dialogue.StartDialogue(87, 91, delegate
			{
				director.Resume();
			});
			break;
		case 2:
			director.Pause();
			dialogue.StartDialogue(92, 95, delegate
			{
				director.Resume();
			});
			break;
		case 3:
			director.Pause();
			dialogue.StartDialogue(96, 103, delegate
			{
				director.Stop();
				PlayerManager.instance.UnlockAll();
				PlayerManager.instance.ArrangePlayer();
				closet.SetActive(value: true);
				trigger.SetActive(value: true);
			});
			break;
		case 4:
			PlayerManager.instance.LockAll();
			PlayCutscene("Scene5");
			break;
		case 5:
			director.Pause();
			dialogue.StartDialogue(104, 110, delegate
			{
				director.Resume();
				PlayerManager.instance.UnlockAll();
			});
			break;
		case 6:
			StartCoroutine(IStepInCloset());
			break;
		}
		eventIndex++;
	}

	public void PlayCutscene(string scene)
	{
		director.playableAsset = Resources.Load<PlayableAsset>("Timeline/" + scene);
		director.Play();
	}

	private IEnumerator IStepInCloset()
	{
		black.SetActive(value: true);
		Object.Destroy(music);
		PlayerManager.instance.LockAll();
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Scene4");
	}
}
