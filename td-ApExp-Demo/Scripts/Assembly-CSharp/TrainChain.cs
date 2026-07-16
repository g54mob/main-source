using System;
using UnityEngine;

public class TrainChain : MonoBehaviour
{
	[Header("Chain")]
	[SerializeField]
	private Transform[] segments;

	[SerializeField]
	private Transform hook;

	[SerializeField]
	private float throwSpeed;

	[SerializeField]
	private ParticleSystem attachPs;

	[NonSerialized]
	public Vector3 targetPos;

	[NonSerialized]
	public E2_7Chainer chainer;

	private float expansion;

	private bool throwing;

	private bool isAttached;

	private AudioSource audio;

	[Header("Audio")]
	[SerializeField]
	private AudioClip throwSound;

	[SerializeField]
	private AudioClip attachSound;

	[SerializeField]
	private AudioClip dragSound;

	private StateMachine sm;

	public bool IsThrowing => throwing;

	public bool IsAttached => isAttached;

	private void Start()
	{
		expansion = 0f;
		audio = GetComponent<AudioSource>();
		isAttached = false;
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[2]
		{
			new E2_7ChainThrowing(sm, this),
			new E2_7ChainAttach(sm, this)
		});
	}

	private void Update()
	{
		_ = targetPos;
		sm.UpdateStates();
	}

	public void Throw()
	{
		SetExpansion(expansion + Time.deltaTime * throwSpeed);
		float num = (base.transform.position - targetPos).magnitude / (float)segments.Length;
		for (int i = 0; i < segments.Length; i++)
		{
			segments[i].localPosition = new Vector3(0f, num * (float)i * expansion, 0f);
		}
	}

	public void HoldChain()
	{
		float num = (base.transform.position - targetPos).magnitude / (float)segments.Length;
		for (int i = 0; i < segments.Length; i++)
		{
			segments[i].localPosition = new Vector3(0f, num * (float)i, 0f);
		}
	}

	public bool CheckCanHookAttach()
	{
		return (hook.position - targetPos).magnitude <= 0.12f;
	}

	public void AttachHook()
	{
		isAttached = true;
		attachPs.Play();
	}

	public void SetTargetPos(Vector3 tt)
	{
		targetPos = tt;
	}

	public void SetExpansion(float value)
	{
		expansion = Mathf.Clamp(value, 0f, 1f);
	}

	public void PlayThrowingSound()
	{
		audio.clip = throwSound;
		audio.loop = false;
		audio.Play();
	}

	public void PlayAttachSound()
	{
		audio.clip = attachSound;
		audio.loop = false;
		audio.Play();
	}

	public void PlayDragSound()
	{
		audio.clip = dragSound;
		audio.loop = true;
		audio.Play();
	}
}
