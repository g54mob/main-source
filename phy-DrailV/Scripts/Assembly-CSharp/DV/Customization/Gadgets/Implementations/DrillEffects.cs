using DV.CabControls;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	[RequireComponent(typeof(DrillTool))]
	public class DrillEffects : MonoBehaviour
	{
		public float motorReactionFree = 1f;

		public float motorReactionDrilling = 8f;

		public float motorReactionDeacceleration = 0.1f;

		public float passiveDeacceleration = 0.1f;

		public float pitchDrillingStart = 1f;

		public float pitchDrillingEnd = 0.8f;

		public float pitchDrillingFree = 1.3f;

		public AudioSource sourceMotor;

		public AudioSource sourceDrill;

		public AudioSource sourceAirflow;

		public Transform headTransform;

		public float headAngle;

		public float headSpinSpeed = 10f;

		private DrillTool drill;

		private float spin;

		private void Start()
		{
			drill = GetComponent<DrillTool>();
			ItemBase component = GetComponent<ItemBase>();
			component.Grabbed += OnGrabbed;
			component.Ungrabbed += OnUngrabbed;
		}

		private void Update()
		{
			float num = 0f;
			if (drill.IsPressed)
			{
				num = (drill.TargetIsValid ? Mathf.Lerp(pitchDrillingStart, pitchDrillingEnd, drill.ProcessingProgress) : pitchDrillingFree);
			}
			float num2 = ((drill.TargetIsValid && num < spin) ? motorReactionDrilling : ((num != 0f) ? motorReactionFree : motorReactionDeacceleration));
			spin += (num - spin) * num2 * Time.deltaTime;
			if (num == 0f)
			{
				spin = Mathf.MoveTowards(spin, 0f, passiveDeacceleration * Time.deltaTime);
			}
			sourceMotor.pitch = spin;
			sourceMotor.volume = spin * spin;
			sourceAirflow.volume = spin * spin;
			sourceDrill.volume = (drill.TargetIsValid ? spin : 0f);
			sourceDrill.pitch = spin;
			headAngle = Mathf.Repeat(headAngle + spin * headSpinSpeed * 360f * Time.deltaTime, 360f);
			headTransform.localRotation = Quaternion.AngleAxis(headAngle, Vector3.forward);
		}

		private void OnGrabbed(object _)
		{
			sourceMotor.volume = 0f;
			sourceMotor.Play();
			sourceDrill.volume = 0f;
			sourceDrill.Play();
			sourceAirflow.volume = 0f;
			sourceAirflow.Play();
		}

		private void OnUngrabbed(object _)
		{
			sourceMotor.Stop();
			sourceDrill.Stop();
			sourceAirflow.Stop();
			spin = 0f;
		}
	}
}
