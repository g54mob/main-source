using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Manager4 : MonoBehaviour
{
	public static Manager4 instance;

	[SerializeField]
	private PlayableDirector director;

	[SerializeField]
	private int eventIndex;

	[SerializeField]
	private Dialogue dialogue;

	[SerializeField]
	private InteractObject spell;

	[SerializeField]
	private InteractObject dad;

	[SerializeField]
	private GameObject black;

	[SerializeField]
	private GameObject music;

	[SerializeField]
	private SFX sfx;

	[SerializeField]
	private Animator handAnim;

	[SerializeField]
	private Animator arrAnim;

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
			dad.interactable = false;
			PlayerManager.instance.LockMovement();
			arrAnim.Play("HandPos");
			dialogue.StartDialogue(111, 117, delegate
			{
				spell.interactable = true;
				PlayerManager.instance.UnlockAll();
			});
			break;
		case 1:
			sfx.PlaySound("HandNoise");
			PlayerManager.instance.ArrangePlayer();
			PlayerManager.instance.LockMovement();
			handAnim.gameObject.SetActive(value: true);
			break;
		case 2:
			StartCoroutine(IGrab());
			break;
		}
		eventIndex++;
	}

	public void PlayCutscene(string scene)
	{
		director.playableAsset = Resources.Load<PlayableAsset>("Timeline/" + scene);
		director.Play();
	}

	private IEnumerator IGrab()
	{
		handAnim.Play("Grab");
		yield return new WaitForSeconds(0.3f);
		sfx.PlaySound("Hand");
		yield return new WaitForSeconds(0.4f);
		black.SetActive(value: true);
		music.SetActive(value: false);
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("Scene5");
	}
}
