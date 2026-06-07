using UnityEngine;

[CreateAssetMenu(menuName = "Minamolc/Rigidbody Styles Data")]
public class RigidbodyStylesData : ScriptableObject
{
	[Header("General Audio Effects")]
	[Space(5f)]
	public AudioClip impactClip;

	public AudioClip jointBreakClip;

	[Space(10f)]
	[Header("Blocks Audio Effects")]
	[Space(5f)]
	public AudioClip blockDestroyedClip;

	[Space(10f)]
	[Header("Land Mine Audio Effects")]
	[Space(5f)]
	public AudioClip landMineBeepClip;

	public AudioClip landMineExplosionClip;

	[Space(10f)]
	[Header("Crate Audio Effects")]
	[Space(5f)]
	public AudioClip tntCrateExplosionClip;

	[Space(10f)]
	[Header("Level Button Audio Effects")]
	[Space(5f)]
	public AudioClip levelButtonOnClip;

	public AudioClip levelButtonOffClip;

	[Space(10f)]
	[Header("Laser Button Audio Effects")]
	[Space(5f)]
	public AudioClip laserButtonOnClip;

	public AudioClip laserButtonOffClip;

	[Space(10f)]
	[Header("Laser Emitter Audio Effects")]
	[Space(5f)]
	public AudioClip laserEmitterWorkingClip;

	public AudioClip laserDamagingClip;

	[Space(10f)]
	[Header("Level Animations Audio Effects")]
	[Space(5f)]
	public AudioClip motorClip;

	public AudioClip airClip;

	public AudioClip endCourseClip;

	[Space(10f)]
	[Header("Collectables Audio Effects")]
	[Space(5f)]
	public AudioClip collectedClip;
}
