using System;
using System.Collections.Generic;
using UnityEngine;

public class CannedAnim : MonoBehaviour
{
	[Serializable]
	public class Sequence
	{
		public string propRootName;

		public bool propShowHandShadow;

		public string animStateName;

		public string handAnimsId;

		public AudioClip audioClip;

		[NonSerialized]
		public Prop prop;
	}

	private Player player;

	private Strider strider;

	private Animator animator;

	private Sequence playingSequence;

	private bool playingLastFrame;

	private bool haveHiddenHands;

	[NonSerialized]
	public GameObject head;

	[NonSerialized]
	private GameObject bodyRoot;

	[NonSerialized]
	private GameObject foot;

	public string bodyRootName;

	public string headName;

	public string footName;

	public List<Sequence> sequences = new List<Sequence>();

	public bool isPlaying
	{
		get
		{
			return playingSequence != null;
		}
	}

	private void Start()
	{
		bodyRoot = base.transform.FindDescendant(bodyRootName).gameObject;
		head = base.transform.FindDescendant(headName).gameObject;
		foot = base.transform.FindDescendant(footName).gameObject;
		foreach (Sequence sequence in sequences)
		{
			GameObject gameObject = base.transform.FindDescendant(sequence.propRootName).gameObject;
			sequence.prop = gameObject.AddComponent<Prop>();
			sequence.prop.handAnimsId = sequence.handAnimsId;
			sequence.prop.cannedAnim = this;
			sequence.prop.reachViewAngle = 120f;
			sequence.prop.spinnableElbow = true;
			sequence.prop.showHandShadow = sequence.propShowHandShadow;
			Hand.AddLateLevelProp(sequence.prop);
		}
		animator = base.gameObject.GetComponentInChildren<Animator>();
		animator.cullingMode = AnimatorCullingMode.AlwaysAnimate;
		animator.Play("Idle");
		animator.Update(0f);
		animator.Update(0f);
		bodyRoot.SetActive(false);
	}

	private void Update()
	{
		if (!isPlaying)
		{
			return;
		}
		AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if (currentAnimatorStateInfo.IsName(playingSequence.animStateName) && currentAnimatorStateInfo.normalizedTime < 1f)
		{
			if (!haveHiddenHands && currentAnimatorStateInfo.normalizedTime * currentAnimatorStateInfo.length > 1f)
			{
				player.hand.StartHiding();
				if (player.watchHand != null)
				{
					player.watchHand.visible = false;
				}
				haveHiddenHands = true;
			}
			player.DisableInputForOneFrame();
			if (strider != null)
			{
				strider.SilenceForOneFrame();
			}
			if (HeadMotion.instance != null && currentAnimatorStateInfo.normalizedTime * currentAnimatorStateInfo.length < currentAnimatorStateInfo.length - 2f)
			{
				HeadMotion.instance.IgnoreForOneFrame();
			}
		}
		else
		{
			playingSequence = null;
			player.head.transform.localPosition = player.eyeOffset;
			player.footPos = new Vector3(head.transform.position.x, foot.transform.position.y + 0.001f, head.transform.position.z);
			playingLastFrame = true;
		}
	}

	private void LateUpdate()
	{
		if (!isPlaying && !playingLastFrame)
		{
			return;
		}
		player.look = head.transform.rotation;
		if (playingLastFrame)
		{
			playingLastFrame = false;
			bodyRoot.SetActive(false);
			animator.Play("Idle");
			animator.Update(0f);
			animator.Update(0f);
			player.hand.StopHiding();
			if (player.watchHand != null)
			{
				player.watchHand.visible = true;
			}
		}
		else
		{
			player.head.transform.position = head.transform.position;
		}
	}

	private Sequence FindSequence(Prop prop)
	{
		foreach (Sequence sequence in sequences)
		{
			if (sequence.prop == prop)
			{
				return sequence;
			}
		}
		return null;
	}

	public void PrepareForPlay(Prop prop)
	{
		Sequence sequence = FindSequence(prop);
		if (sequence != null)
		{
			bodyRoot.SetActive(true);
			animator.speed = 0f;
			animator.Play(sequence.animStateName);
			animator.Update(0f);
			animator.Update(0f);
			bodyRoot.SetActive(false);
		}
	}

	public void Play(Player player_, Prop prop)
	{
		player = player_;
		playingSequence = FindSequence(prop);
		strider = player.GetComponent<Strider>();
		player.DisableInputForOneFrame();
		if (strider != null)
		{
			strider.SilenceForOneFrame();
		}
		bodyRoot.SetActive(true);
		animator.speed = 1f;
		haveHiddenHands = false;
		if (playingSequence.audioClip != null)
		{
			AudioOneShot audioOneShot = AudioOneShot.Play(playingSequence.audioClip);
			audioOneShot.gameObject.AddComponent<AudioPauseEcho>();
		}
	}
}
