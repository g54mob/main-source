using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Particle Collection")]
public class ParticleCollection : ScriptableObject
{
	[Tooltip("Splash particles.")]
	public ParticleController Splash;
}
