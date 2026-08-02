using JUTPSEditor.JUHeader;
using UnityEngine;

namespace JUTPS.AI
{
	public class AIRandomDestination : MonoBehaviour
	{
		private JUCharacterArtificialInteligenceBrain AICharacter;

		[JUHeader("AI Random Position Generation")]
		public Vector3 CenterPositionOffset;

		public float MinTime = 3f;

		public float MaxTime = 10f;

		public float Area = 100f;

		private float currentMaxTime;

		private float currentTime;

		private void Start()
		{
			AICharacter = GetComponent<JUCharacterArtificialInteligenceBrain>();
		}

		private void Update()
		{
			if (!(AICharacter == null))
			{
				currentTime += Time.deltaTime;
				if (currentTime >= currentMaxTime)
				{
					GenerateNewRandomPosition();
					currentMaxTime = Random.Range(MinTime, MaxTime);
					currentTime = 0f;
				}
			}
		}

		public void GenerateNewRandomPosition()
		{
			Vector3 destination = Vector3.zero + CenterPositionOffset;
			destination.z += Random.Range(0f - Area, Area);
			destination.x += Random.Range(0f - Area, Area);
			AICharacter.Destination = destination;
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireCube(Vector3.zero + CenterPositionOffset, new Vector3(Area, 0f, Area));
		}
	}
}
