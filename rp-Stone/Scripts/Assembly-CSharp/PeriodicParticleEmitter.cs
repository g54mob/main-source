using UnityEngine;

[RequireComponent(typeof(AsciiParticleEmitter))]
public class PeriodicParticleEmitter : MonoBehaviour
{
	public float period = 1f;

	private float elapsedTime;

	private AsciiParticleEmitter[] myEmitters;

	private PrewarmEmitter myPrewarm;

	private void Update()
	{
		if (myPrewarm != null)
		{
			for (int i = 0; i < myEmitters.Length; i++)
			{
				myEmitters[i].FindParticleLayer();
			}
			myPrewarm.DoPrewarm(0, 0);
			myPrewarm = null;
		}
		UpdateWithDeltaTime(Utils.deltaTime);
	}

	public void UpdateWithDeltaTime(float delta)
	{
		elapsedTime += delta;
		int num = 0;
		while (elapsedTime >= period && num++ < 10)
		{
			elapsedTime -= period;
			for (int i = 0; i < myEmitters.Length; i++)
			{
				if (myEmitters[i].enabled)
				{
					myEmitters[i].Emit();
				}
			}
		}
	}

	private void Awake()
	{
		myEmitters = GetComponents<AsciiParticleEmitter>();
		myPrewarm = GetComponent<PrewarmEmitter>();
	}

	private void OnDestroy()
	{
		myEmitters = null;
		myPrewarm = null;
	}
}
