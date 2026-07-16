using System;
using System.Collections;
using AudioSystem;
using UnityEngine;

public class CoalHose : ExtendableLinksComponent
{
	private CoalHoseLastSegment lastSegment;

	[Header("Coal Hose")]
	[SerializeField]
	private float suckAnimSpeed;

	[SerializeField]
	private float suckAnimInterval;

	[NonSerialized]
	public bool IsHacked;

	[Header("SFX")]
	[SerializeField]
	protected SoundData expandingSound;

	[SerializeField]
	protected SoundData suckSound;

	protected SoundBuilder soundBuilder;

	private Coroutine suckCoroutine;

	public new void Start()
	{
		base.Start();
		lastSegment = lastLinkLC.GetComponent<CoalHoseLastSegment>();
		if (base.transform.position.y > 0f)
		{
			lastLinkLC.GetComponent<SpriteRenderer>().flipY = true;
		}
		soundBuilder = PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder();
	}

	public override void Update()
	{
		base.Update();
	}

	public void PlayEmbers()
	{
		if (lastSegment != null)
		{
			lastSegment.PlayEmbers();
		}
	}

	public void StartSuckAnim()
	{
		suckCoroutine = StartCoroutine(Suck());
	}

	public void StopSuckingAnim()
	{
		if (suckCoroutine != null)
		{
			StopCoroutine(suckCoroutine);
			suckCoroutine = null;
		}
	}

	private IEnumerator Suck()
	{
		while (base.IsAttached)
		{
			if (!IsHacked)
			{
				if ((bool)lastLinkLC)
				{
					lastLinkLC.GetComponent<Animator>().SetTrigger("Suck");
					lastSegment.PlayEmbers();
					yield return new WaitForSeconds(suckAnimSpeed);
				}
				for (int i = linksLC.Length - 1; i >= 0; i--)
				{
					if (!(linksLC[i] == null))
					{
						linksLC[i].GetComponent<Animator>().SetTrigger("Suck");
						yield return new WaitForSeconds(suckAnimSpeed);
					}
				}
				if ((bool)firstLinkLC)
				{
					firstLinkLC.GetComponent<Animator>().SetTrigger("Suck");
				}
			}
			else
			{
				if ((bool)firstLinkLC)
				{
					firstLinkLC.GetComponent<Animator>().SetTrigger("Suck");
					yield return new WaitForSeconds(suckAnimSpeed);
				}
				for (int i = linksLC.Length - 1; i >= 0; i--)
				{
					if (!(linksLC[i] == null))
					{
						linksLC[i].GetComponent<Animator>().SetTrigger("Suck");
						yield return new WaitForSeconds(suckAnimSpeed);
					}
				}
				if ((bool)lastLinkLC)
				{
					lastLinkLC.GetComponent<Animator>().SetTrigger("Suck");
					lastSegment.PlayEmbers();
				}
			}
			yield return new WaitForSeconds(suckAnimInterval);
		}
	}

	public void PlayExpandingSound()
	{
		soundBuilder.Play(expandingSound);
	}

	public void PlaySuckingSound()
	{
		if (suckSound.clips.Count > 0)
		{
			soundBuilder.Play(suckSound);
		}
		soundBuilder.FindAndStop(expandingSound);
	}

	public void StopAudio()
	{
		soundBuilder.FindAndStop(expandingSound);
		if (suckSound.clips.Count > 0)
		{
			soundBuilder.FindAndStop(suckSound);
		}
	}

	protected override void Aim()
	{
		base.Aim();
		lastLinkLC.transform.rotation = Quaternion.identity;
	}

	public void Retract()
	{
		StartCoroutine(RetractCoroutine());
	}

	private IEnumerator RetractCoroutine()
	{
		do
		{
			expansion01 -= Time.deltaTime * retractionSpeed;
			SetExpansion(Mathf.Clamp01(expansion01));
			yield return new WaitForSeconds(Time.deltaTime);
		}
		while (expansion01 > 0f);
		Retracted = true;
	}
}
