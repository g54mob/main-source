using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationsPlayer : MonoBehaviour
{
	public AnimationClip[] Clips;

	private int _i;

	private void Start()
	{
		AnimationClip animationClip = Clips[_i];
		GetComponent<Animation>().AddClip(animationClip, animationClip.name);
		GetComponent<Animation>().clip = animationClip;
		GetComponent<Animation>().Play();
	}

	private void Update()
	{
		if (!GetComponent<Animation>().isPlaying)
		{
			_i++;
			Start();
		}
	}
}
