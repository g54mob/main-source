using R3;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GnormanAnimationListener : MonoBehaviour
{
	private PlayableReference _playable;

	private void Awake()
	{
		_playable = new PlayableReference("Gnorman", "Animation", GetComponent<Animator>()).AddTo(this);
		Database.State.Gnorman.Animation.Where((GnormanAnimation x) => x != GnormanAnimation.None).DistinctUntilChanged().Subscribe(_playable, delegate(GnormanAnimation x, PlayableReference playable)
		{
			playable.Play(x.Value());
		})
			.AddTo(this);
	}
}
