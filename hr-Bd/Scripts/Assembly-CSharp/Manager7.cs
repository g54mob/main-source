using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Manager7 : MonoBehaviour
{
	public static Manager7 instance;

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
	private InteractObject door;

	[SerializeField]
	private InteractObject cover;

	[SerializeField]
	private InteractObject closet;

	[SerializeField]
	private GameObject spell;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		PlayerManager.instance.AddItem("Spell");
	}

	public void TriggerEvent()
	{
		switch (eventIndex)
		{
		case 0:
			PlayerManager.instance.LockMovement();
			dialogue.StartDialogue(164, 164, delegate
			{
				door.interactable = true;
				PlayerManager.instance.UnlockAll();
			});
			break;
		case 1:
			spell.SetActive(value: true);
			door.interactable = false;
			cover.interactable = true;
			break;
		case 2:
			cover.interactable = false;
			PlayerManager.instance.LockAll();
			PlayCutscene("Scene11");
			break;
		case 3:
			closet.interactable = true;
			director.Stop();
			PlayerManager.instance.UnlockAll();
			PlayerManager.instance.ArrangePlayer();
			break;
		case 4:
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
		SceneManager.LoadScene("Scene8");
	}
}
