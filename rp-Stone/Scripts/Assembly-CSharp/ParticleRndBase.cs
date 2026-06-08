using UnityEngine;

[RequireComponent(typeof(AsciiParticle))]
public abstract class ParticleRndBase : MonoBehaviour
{
	public AsciiParticle myParticle { get; set; }

	public abstract void Init(AsciiParticle particle);

	protected void Update()
	{
	}

	protected void OnStart()
	{
	}

	protected void HandleOnParticleReset(AsciiParticle p)
	{
		if (base.enabled)
		{
			Init(p);
		}
	}

	protected void Awake()
	{
		myParticle = GetComponent<AsciiParticle>();
		myParticle.OnReset += HandleOnParticleReset;
		if (base.enabled)
		{
			Init(myParticle);
		}
	}
}
