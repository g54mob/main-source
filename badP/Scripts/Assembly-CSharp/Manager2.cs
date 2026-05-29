using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Manager2 : MonoBehaviour
{
	public static Manager2 instance;

	[SerializeField]
	private PlayableDirector director;

	[SerializeField]
	private int eventIndex;

	[SerializeField]
	private Dialogue dialogue;

	[SerializeField]
	private InteractObject box;

	[SerializeField]
	private InteractObject closet;

	[SerializeField]
	private InteractObject door;

	[SerializeField]
	private InteractObject chair;

	[SerializeField]
	private InteractObject food;

	[SerializeField]
	private InteractObject stove;

	[SerializeField]
	private InteractObject table;

	[SerializeField]
	private InteractObject foodTable;

	[SerializeField]
	private InteractObject doorP;

	[SerializeField]
	private InteractObject closetParent;

	[SerializeField]
	private InteractObject dollBed;

	[SerializeField]
	private InteractObject radio1;

	[SerializeField]
	private InteractObject radioHolder;

	[SerializeField]
	private InteractObject radio2;

	[SerializeField]
	private GameObject dollInTheBox;

	[SerializeField]
	private GameObject dollChair;

	[SerializeField]
	private GameObject dollCloset;

	[SerializeField]
	private GameObject dollCloset2;

	[SerializeField]
	private GameObject black;

	[SerializeField]
	private Animator closetAnim;

	[SerializeField]
	private Animator stoveAnim;

	[SerializeField]
	private Animator closetAnim2;

	[SerializeField]
	private SFX radioSource;

	[SerializeField]
	private PostProcessVolume volume;

	[SerializeField]
	private PostProcessProfile profile1;

	[SerializeField]
	private PostProcessProfile profile2;

	[SerializeField]
	private Options options;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		StartCoroutine(IUnlockControl());
	}

	public void TriggerEvent()
	{
		switch (eventIndex)
		{
		case 0:
			box.interactable = false;
			PlayerManager.instance.LockMovement();
			dialogue.StartDialogue(21, 22, delegate
			{
				StartCoroutine(ITalkToDoll());
			});
			break;
		case 1:
			StartCoroutine(IOpenCloset1());
			break;
		case 2:
			StartCoroutine(IOpenCloset2());
			break;
		case 3:
			dollChair.SetActive(value: true);
			chair.interactable = false;
			break;
		case 4:
			Object.Destroy(food.gameObject);
			PlayerManager.instance.AddItem("Meal");
			break;
		case 5:
			StartCoroutine(IWarmFood());
			break;
		case 6:
			foodTable.gameObject.SetActive(value: true);
			table.interactable = false;
			break;
		case 7:
			PlayerManager.instance.LockAll();
			PlayCutscene("Scene3");
			break;
		case 8:
			director.Pause();
			dialogue.StartDialogue(45, 48, delegate
			{
				director.Resume();
			});
			break;
		case 9:
			director.Pause();
			dialogue.StartDialogue(49, 50, delegate
			{
				director.Resume();
			});
			break;
		case 10:
			foodTable.interactable = false;
			director.Pause();
			dialogue.StartDialogue(51, 57, delegate
			{
				director.Stop();
				PlayerManager.instance.UnlockAll();
				PlayerManager.instance.ArrangePlayer();
				doorP.interactable = true;
			});
			break;
		case 11:
			Object.Destroy(dollChair);
			dollBed.interactable = false;
			PlayerManager.instance.LockMovement();
			dialogue.StartDialogue(58, 72, delegate
			{
				PlayerManager.instance.UnlockAll();
				closet.interactable = true;
				dollCloset.SetActive(value: true);
			});
			break;
		case 12:
			StartCoroutine(IOpenCloset3());
			break;
		case 13:
			PlayerManager.instance.LockMovement();
			dialogue.StartDialogue(75, 77, delegate
			{
				PlayerManager.instance.UnlockAll();
				closetParent.interactable = true;
				Object.Destroy(dollCloset);
			});
			break;
		case 14:
			StartCoroutine(IOpenCloset4());
			break;
		case 15:
			Object.Destroy(radio1.gameObject);
			PlayerManager.instance.AddItem("Radio");
			radioHolder.interactable = true;
			break;
		case 16:
			Object.Destroy(radioHolder.gameObject);
			radio2.gameObject.SetActive(value: true);
			PlayerManager.instance.LockMovement();
			dialogue.StartDialogue(82, 83, delegate
			{
				GameObject.Find("Player").transform.position = new Vector3(-44.56f, 0f, 30.4f);
				PlayerManager.instance.InteractDistance(15f);
				radio2.interactable = true;
			});
			break;
		case 17:
			StartCoroutine(IRadio1());
			break;
		case 18:
			StartCoroutine(IOpenCloset5());
			break;
		case 19:
			StartCoroutine(IRadio2());
			break;
		case 20:
			StartCoroutine(IOpenCloset6());
			break;
		case 21:
			StartCoroutine(IRadio3());
			break;
		case 22:
			StartCoroutine(IOpenCloset7());
			break;
		case 23:
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

	private IEnumerator IUnlockControl()
	{
		PlayerManager.instance.LockAll();
		yield return new WaitForSeconds(3f);
		PlayerManager.instance.UnlockAll();
		PlayerManager.instance.ArrangePlayer();
	}

	private IEnumerator ITalkToDoll()
	{
		PlayerManager.instance.AddItem("Doll");
		Object.Destroy(dollInTheBox);
		yield return new WaitForSeconds(3f);
		dialogue.StartDialogue(23, 34, delegate
		{
			PlayerManager.instance.UnlockAll();
			closet.interactable = true;
		});
	}

	private IEnumerator IOpenCloset1()
	{
		closet.interactable = false;
		PlayerManager.instance.LockAll();
		closetAnim.Play("Stuck");
		yield return new WaitForSeconds(2.4f);
		dialogue.StartDialogue(35, 36, delegate
		{
			PlayerManager.instance.UnlockAll();
			closet.interactable = true;
		});
	}

	private IEnumerator IOpenCloset2()
	{
		closet.interactable = false;
		PlayerManager.instance.LockAll();
		closetAnim.Play("Stuck");
		yield return new WaitForSeconds(2.4f);
		dialogue.StartDialogue(37, 43, delegate
		{
			PlayerManager.instance.UnlockAll();
			door.interactable = true;
		});
	}

	private IEnumerator IOpenCloset3()
	{
		closet.interactable = false;
		PlayerManager.instance.LockAll();
		closetAnim.Play("Stuck");
		yield return new WaitForSeconds(2.4f);
		dialogue.StartDialogue(73, 74, delegate
		{
			PlayerManager.instance.UnlockAll();
			dollCloset2.SetActive(value: true);
			Object.Destroy(dollBed.gameObject);
		});
	}

	private IEnumerator IOpenCloset4()
	{
		closetParent.interactable = false;
		PlayerManager.instance.LockMovement();
		PlayerManager.instance.LockInteract();
		closetAnim2.Play("Open");
		yield return new WaitForSeconds(2f);
		dialogue.StartDialogue(78, 81, delegate
		{
			PlayerManager.instance.UnlockAll();
			radio1.interactable = true;
		});
	}

	private IEnumerator IOpenCloset5()
	{
		closetParent.interactable = false;
		closetAnim2.Play("Forest");
		yield return new WaitForSeconds(3f);
		dialogue.StartDialogue(84, 84, delegate
		{
			radio2.interactable = true;
		});
	}

	private IEnumerator IOpenCloset6()
	{
		closetParent.interactable = false;
		closetAnim2.Play("Wave");
		radioSource.Stop();
		yield return new WaitForSeconds(6f);
		radio2.interactable = true;
	}

	private IEnumerator IOpenCloset7()
	{
		closetParent.interactable = false;
		closetAnim2.Play("Void");
		yield return new WaitForSeconds(3f);
		dialogue.StartDialogue(85, 86, delegate
		{
			radio2.interactable = false;
			PlayerManager.instance.UnlockAll();
			closetParent.interactable = true;
		});
	}

	private IEnumerator IWarmFood()
	{
		stove.interactable = false;
		stoveAnim.Play("On");
		yield return new WaitForSeconds(6f);
		PlayerManager.instance.AddItem("Meal");
		table.interactable = true;
	}

	public void ChangePP()
	{
		if (volume.profile == profile2)
		{
			options.UpdateFilter();
		}
		else
		{
			volume.profile = profile2;
		}
	}

	private IEnumerator IRadio1()
	{
		radio2.interactable = false;
		radioSource.PlaySound("Noise");
		yield return new WaitForSeconds(3f);
		radioSource.PlaySoundLoop("Forest");
		closetParent.interactable = true;
	}

	private IEnumerator IRadio2()
	{
		radio2.interactable = false;
		radioSource.PlaySound("Noise");
		yield return new WaitForSeconds(3f);
		radioSource.PlaySoundLoop("Wave");
		closetParent.interactable = true;
	}

	private IEnumerator IRadio3()
	{
		radio2.interactable = false;
		radioSource.PlaySound("Noise");
		yield return new WaitForSeconds(3f);
		radioSource.PlaySoundLoop("WindCloset");
		closetParent.interactable = true;
	}

	private IEnumerator IStepInCloset()
	{
		black.SetActive(value: true);
		radioSource.Stop();
		PlayerManager.instance.LockAll();
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Scene3");
	}
}
