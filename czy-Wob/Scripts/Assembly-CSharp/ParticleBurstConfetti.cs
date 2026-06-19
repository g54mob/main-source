using UnityEngine;

public class ParticleBurstConfetti : ParticleBurst
{
	private float order;

	private float positionFudge = 0.001f;

	private bool foundStageYPos;

	private float stageYPos = float.NegativeInfinity;

	private ConfettiBurstController controllerRef;

	public void SetController(ConfettiBurstController newRef, int newOrder)
	{
		order = newOrder;
		controllerRef = newRef;
		FindStageYPos();
	}

	private void LateUpdate()
	{
		ParticleSystem.Particle[] array = new ParticleSystem.Particle[particleSystemRef.main.maxParticles];
		int particles = particleSystemRef.GetParticles(array);
		for (int i = 0; i < particles; i++)
		{
			if (!hitRotDict.ContainsKey(i) && Mathf.Abs(array[i].velocity.y) != 0f)
			{
				continue;
			}
			if (!hitRotDict.ContainsKey(i))
			{
				Vector3 vector = array[i].position;
				if (foundStageYPos)
				{
					vector = new Vector3(vector.x, stageYPos, vector.z);
				}
				hitPosDict[i] = vector + new Vector3(0f, positionFudge * order, 0f);
				hitRotDict[i] = hitRot + new Vector3(0f, array[i].rotation3D.y, 0f);
			}
			array[i].position = hitPosDict[i];
			array[i].rotation3D = hitRotDict[i];
		}
		particleSystemRef.SetParticles(array, particles);
	}

	protected override void OnDestroy()
	{
		if (controllerRef != null)
		{
			controllerRef.OnDestroy();
		}
		base.OnDestroy();
	}

	private void FindStageYPos()
	{
		foundStageYPos = RaycastUtil.StageRaycast(base.transform.position, Vector3.down, out var hitInfo, 100f);
		if (foundStageYPos)
		{
			hitInfo.point = base.transform.InverseTransformPoint(hitInfo.point);
			stageYPos = hitInfo.point.y + positionFudge;
		}
	}
}
