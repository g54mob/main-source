using System.Collections.Generic;
using UnityEngine;

public class PostAnimator : MonoBehaviour
{
	public ImageEffectBase effect;

	public List<AnimFloat> animations = new List<AnimFloat>();

	[HideInInspector]
	public GameObject effectHolder;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
