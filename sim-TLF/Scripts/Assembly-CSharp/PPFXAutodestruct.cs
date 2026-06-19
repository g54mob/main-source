using UnityEngine;

public class PPFXAutodestruct : MonoBehaviour
{
	private ParticleSystem ps;

	private void Start()
	{
		ps = GetComponent<ParticleSystem>();
		if ((bool)ps)
		{
			ParticleSystem.MainModule main = ps.main;
			float t = main.duration + main.startLifetime.constantMin;
			if (!main.loop)
			{
				Object.Destroy(base.gameObject, t);
			}
		}
	}

	public void DestroyPSystem(GameObject _ps)
	{
		ParticleSystem.MainModule main = _ps.GetComponent<ParticleSystem>().main;
		float t = main.duration + main.startLifetime.constantMin;
		Object.Destroy(_ps, t);
	}
}
