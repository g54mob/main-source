using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class AnimatedMesh : MonoBehaviour
{
	public delegate void AnimationEndEvent(string Name);

	[SerializeField]
	private AnimatedMeshScriptableObject AnimationSO;

	private MeshFilter Filter;

	[Header("Debug")]
	[SerializeField]
	private int Tick;

	[SerializeField]
	private int AnimationIndex;

	[SerializeField]
	private string AnimationName;

	private List<Mesh> AnimationMeshes;

	public bool paused;

	private float LastTickTime;

	private float tickInterval;

	public bool testing;

	public event AnimationEndEvent OnAnimationEnd
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void SetAnimation(AnimatedMeshScriptableObject animation)
	{
	}

	private void Awake()
	{
	}

	public void Pause()
	{
	}

	public void UnPause()
	{
	}

	private void Update()
	{
	}
}
