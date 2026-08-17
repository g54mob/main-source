using System;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
	public float psMinInterval = 0.1f;

	public ParticleSystem ps;

	public AudioSpamFilter audioSpamFilter;

	public RandomSfx randomSfx;

	private float nextPlayTime;

	public bool playOnEnable;

	public Action A_Played;

	private void OnEnable()
	{
		//IL_0080: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		if (!playOnEnable || nextPlayTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + psMinInterval;
		nextPlayTime = num;
		ps.Play();
		if (audioSpamFilter == null)
		{
			bool flag = randomSfx != null;
			bool flag2 = !flag;
			object obj = 0;
			if (!flag2)
			{
				randomSfx.Play();
				obj = 0;
			}
		}
		else
		{
			audioSpamFilter.OnEnable();
			object obj = 0;
		}
		Action a_Played = A_Played;
		if (A_Played != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v286.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void Play()
	{
		//IL_0061: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		//IL_008d: Expected O, but got I4
		if (nextPlayTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + psMinInterval;
		nextPlayTime = num;
		ps.Play();
		if (audioSpamFilter == null)
		{
			bool flag = randomSfx != null;
			bool flag2 = !flag;
			object obj = 0;
			if (!flag2)
			{
				randomSfx.Play();
				obj = 0;
			}
		}
		else
		{
			audioSpamFilter.OnEnable();
			object obj = 0;
		}
		Action a_Played = A_Played;
		if (A_Played != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v275.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void OnValidate()
	{
		if (ps == null)
		{
			ParticleSystem component = GetComponent<ParticleSystem>();
			ps = component;
		}
		if (audioSpamFilter == null)
		{
			AudioSpamFilter component2 = GetComponent<AudioSpamFilter>();
			audioSpamFilter = component2;
		}
		if (randomSfx == null)
		{
			RandomSfx component3 = GetComponent<RandomSfx>();
			randomSfx = component3;
		}
	}
}
