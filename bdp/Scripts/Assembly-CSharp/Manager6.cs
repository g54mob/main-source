using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager6 : MonoBehaviour
{
	public static Manager6 instance;

	[SerializeField]
	private PlayableDirector director;

	[SerializeField]
	private int eventIndex;

	[SerializeField]
	private Dialogue dialogue;

	[SerializeField]
	private GameObject black;

	[SerializeField]
	private GameObject music;

	[SerializeField]
	private InteractObject doll;

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
			dialogue.StartDialogue(146, 147, delegate
			{
				director.Stop();
				PlayerManager.instance.UnlockAll();
				PlayerManager.instance.ArrangePlayer();
			});
			break;
		case 1:
			doll.interactable = false;
			PlayerManager.instance.LockAll();
			PlayCutscene("Scene10");
			break;
		case 2:
			director.Pause();
			dialogue.StartDialogue(148, 153, delegate
			{
				director.Resume();
			});
			break;
		case 3:
			director.Pause();
			dialogue.StartDialogue(154, 159, delegate
			{
				director.Resume();
			});
			break;
		case 4:
			director.Pause();
			dialogue.StartDialogue(160, 163, delegate
			{
				director.Resume();
				PlayerManager.instance.UnlockAll();
			});
			break;
		case 5:
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
		black.GetComponent<Image>().color = Color.black;
		Object.Destroy(music);
		PlayerManager.instance.LockAll();
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Scene7");
	}
}
