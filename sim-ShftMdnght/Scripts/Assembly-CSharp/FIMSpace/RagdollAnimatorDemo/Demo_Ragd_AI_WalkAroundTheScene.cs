using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_AI_WalkAroundTheScene : FimpossibleComponent
	{
		public FBasic_RigidbodyMover Mover;

		public Animator Mecanim;

		public float WalkDistanceRange = 4f;

		private Vector3 startPos;

		private float waitForNextPoint;

		private bool atDestination = true;

		private Vector3 targetPosition;

		private void Start()
		{
			startPos = base.transform.position;
			targetPosition = base.transform.position;
			waitForNextPoint = Random.Range(1f, 3f);
		}

		private void Update()
		{
			if (Mecanim.GetBool("Action"))
			{
				return;
			}
			if (atDestination)
			{
				if (waitForNextPoint > 0f)
				{
					waitForNextPoint -= Time.deltaTime;
				}
				else
				{
					waitForNextPoint = Random.Range(1f, 3f);
					targetPosition = startPos + new Vector3(Random.Range(0f - WalkDistanceRange, WalkDistanceRange), 0f, Random.Range(0f - WalkDistanceRange, WalkDistanceRange));
				}
			}
			float num = Distance2D(base.transform.position, targetPosition);
			if (num < 0.3f)
			{
				atDestination = true;
			}
			else if (num > 0.3f)
			{
				Mover.MoveTowards(targetPosition);
			}
		}

		private float Distance2D(Vector3 a, Vector3 b)
		{
			return Vector2.Distance(new Vector2(a.x, a.z), new Vector2(b.x, b.z));
		}
	}
}
