using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
	public bool isBusy;

	public bool isTalking;

	public CharacterInteraction lastNpc;

	[Header("Characters")]
	public WorkerAI rusty;

	public WorkerAI haiku;

	public BeekeeperAI forbic;

	public PinionAI pinion;

	public UpgradeWorkerAI echo;

	public FossilWorkerAI slate;

	[Header("Bubbles")]
	public Transform bubbleTransform;

	public Animator topicIconAnimator;

	public AnimatorOverrideController[] topics;

	private bool topicPlaying;

	private void Start()
	{
		if (GameManager.ins.contentUpdate)
		{
			GameManager.ins.npcs.Add(this);
			isBusy = true;
			StopTopic();
		}
	}

	public void TriggerWalkToMeetCharacter(Vector3 npcPosition)
	{
		if ((bool)rusty)
		{
			StartCoroutine(rusty.WalkToMeetCharacter(npcPosition));
		}
		if ((bool)haiku)
		{
			StartCoroutine(haiku.WalkToMeetCharacter(npcPosition));
		}
		if ((bool)forbic)
		{
			StartCoroutine(forbic.WalkToMeetCharacter(npcPosition));
		}
		if ((bool)pinion)
		{
			StartCoroutine(pinion.WalkToMeetCharacter(npcPosition));
		}
		if ((bool)echo)
		{
			StartCoroutine(echo.WalkToMeetCharacter(npcPosition));
		}
		if ((bool)slate)
		{
			StartCoroutine(slate.WalkToMeetCharacter(npcPosition));
		}
	}

	public void TriggerEndOfTalk()
	{
		if ((bool)rusty)
		{
			rusty.FinishTalking();
		}
		if ((bool)haiku)
		{
			haiku.FinishTalking();
		}
		if ((bool)forbic)
		{
			forbic.FinishTalking();
		}
		if ((bool)pinion)
		{
			pinion.FinishTalking();
		}
		if ((bool)echo)
		{
			echo.FinishTalking();
		}
		if ((bool)slate)
		{
			slate.FinishTalking();
		}
	}

	public void PlayTopic()
	{
		bubbleTransform.gameObject.SetActive(value: true);
		topicIconAnimator.gameObject.SetActive(value: true);
		int num = Random.Range(0, topics.Length);
		topicIconAnimator.runtimeAnimatorController = topics[num];
		topicPlaying = true;
	}

	public void StopTopic()
	{
		bubbleTransform.gameObject.SetActive(value: false);
		topicIconAnimator.gameObject.SetActive(value: false);
		topicPlaying = false;
	}
}
