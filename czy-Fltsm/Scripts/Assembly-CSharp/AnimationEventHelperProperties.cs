using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Animation Event Properties")]
public class AnimationEventHelperProperties : ScriptableObject
{
	[Tooltip("Track the transform of the animator, if disabled the sound or particle will stay at the starting location.")]
	public bool TrackTransform;

	[Header("Audio")]
	[Tooltip("Play audio for this event.")]
	public bool PlayAudio;

	[Tooltip("Audio properties for this event.")]
	public AudioClipProperties AudioProperties;

	[Header("Particles")]
	[Tooltip("Spawn a particle for this event.")]
	public bool SpawnParticle;

	[Tooltip("Offset to apply to particle if particle should spawn offsetted from its animator.")]
	[ConditionalHide("SpawnParticle")]
	public Vector3 Offset;

	[Tooltip("Particle controllers to get a random particle controller from.")]
	[ConditionalHide("SpawnParticle")]
	public List<ParticleController> ParticleControllers = new List<ParticleController>();
}
