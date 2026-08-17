using System;
using System.Collections.Generic;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class AnimatedMesh : MonoBehaviour
{
	public delegate void AnimationEndEvent(string Name);

	private AnimatedMeshScriptableObject AnimationSO;

	private MeshFilter Filter;

	private int Tick = 1;

	private int AnimationIndex;

	private string AnimationName;

	private List<Mesh> AnimationMeshes;

	public bool paused;

	private AnimationEndEvent m_OnAnimationEnd;

	private float LastTickTime;

	private float tickInterval;

	public bool testing;

	public event AnimationEndEvent OnAnimationEnd
	{
		add
		{
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			Delegate obj = this.m_OnAnimationEnd;
			Delegate obj5 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(AnimationEndEvent);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				object obj4 = this + 80;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802652A0");
				bool flag3 = (object)obj5 != obj;
				obj = obj5;
				if (!flag3)
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		remove
		{
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			Delegate obj = this.m_OnAnimationEnd;
			Delegate obj5 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(AnimationEndEvent);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				object obj4 = this + 80;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802652A0");
				bool flag3 = (object)obj5 != obj;
				obj = obj5;
				if (!flag3)
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
	}

	public void SetAnimation(AnimatedMeshScriptableObject animation)
	{
		//IL_006f: Expected F4, but got I4
		Tick = 1;
		AnimationSO = animation;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18112EC70");
		List<Mesh> animationMeshes = default(List<Mesh>);
		AnimationMeshes = animationMeshes;
		Mesh mesh = AnimationMeshes.get_Item(0);
		Filter.mesh = mesh;
		AnimatedMeshScriptableObject animationSO = AnimationSO;
		paused = false;
		tickInterval = animationSO.AnimationFPS;
	}

	private void Awake()
	{
		//IL_007e: Expected F4, but got I4
		MeshFilter component = GetComponent<MeshFilter>();
		Filter = component;
		if (testing)
		{
			AnimatedMeshScriptableObject animationSO = AnimationSO;
			Tick = 1;
			AnimationSO = AnimationSO;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18112EC70");
			List<Mesh> animationMeshes = default(List<Mesh>);
			AnimationMeshes = animationMeshes;
			Mesh mesh = AnimationMeshes.get_Item(0);
			Filter.mesh = mesh;
			AnimatedMeshScriptableObject animationSO2 = AnimationSO;
			paused = false;
			tickInterval = animationSO2.AnimationFPS;
		}
	}

	public void Pause()
	{
		paused = true;
	}

	public void UnPause()
	{
		paused = false;
	}

	private void Update()
	{
		if (AnimationMeshes == null || paused)
		{
			return;
		}
		float num = 1f / tickInterval;
		float num2 = num + LastTickTime;
		if (!(MyTime.time < num2))
		{
			Mesh mesh = AnimationMeshes.get_Item(AnimationIndex);
			Filter.mesh = mesh;
			List<Mesh> animationMeshes = AnimationMeshes;
			if (++AnimationIndex >= animationMeshes._size)
			{
				AnimationIndex = 0;
			}
			LastTickTime = MyTime.time;
		}
		int tick = Tick + 1;
		Tick = tick;
	}
}
