using UnityEngine;

namespace NSMedieval.EnvironmentEffects
{
	public class BirdsFlock : MonoBehaviour
	{
		[Header("General")]
		public GameObject birdsGo;

		public float fraction;

		public Vector3 start;

		public Vector3 destination;

		public float timeNeededForFlyOver;

		public ParticleSystem[] birdsParticles;

		[Header("Circling")]
		public bool birdOfPrey;

		public float rotationDistance = 3f;

		public int circlesNo = 1;

		public float GetCircleFractionPoint { get; private set; }

		public bool CirclingStarted { get; private set; }

		public bool CirclingFinished { get; set; }

		public Vector3 GetCirclingCenter { get; private set; }

		public float CirclingTimer { get; set; }

		public float Angle { get; set; }

		public void SetupCircling()
		{
			Angle = 0f;
			circlesNo = Random.Range(0, 3);
		}

		public void StartCircling()
		{
			CirclingStarted = true;
			GetCirclingCenter = Vector3.Cross(birdsGo.transform.forward, birdsGo.transform.up).normalized * rotationDistance + birdsGo.transform.position;
		}

		public void FinishCircling()
		{
			CirclingFinished = true;
		}

		public void ResetCircling()
		{
			CirclingStarted = false;
			CirclingFinished = false;
		}

		private void Start()
		{
			if (birdOfPrey)
			{
				GetCircleFractionPoint = Random.Range(0.2f, 0.8f);
			}
		}
	}
}
