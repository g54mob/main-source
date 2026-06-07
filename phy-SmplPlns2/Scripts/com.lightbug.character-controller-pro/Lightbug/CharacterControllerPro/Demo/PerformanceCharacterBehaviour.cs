using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class PerformanceCharacterBehaviour : MonoBehaviour
	{
		public CharacterActor characterActor;

		private float sineAmplitude;

		private float sineAngularSpeed;

		private float sinePhase;

		private void Start()
		{
			sineAmplitude = Random.Range(8f, 15f);
			sineAngularSpeed = Random.Range(0.5f, 2f);
			sinePhase = Random.Range(0f, 90f);
		}

		private void FixedUpdate()
		{
			characterActor.VerticalVelocity += Vector3.down * 15f * Time.deltaTime;
			characterActor.PlanarVelocity = CustomUtilities.Multiply(Vector3.forward, sineAmplitude * Mathf.Sin(Time.time * sineAngularSpeed + sinePhase));
		}
	}
}
