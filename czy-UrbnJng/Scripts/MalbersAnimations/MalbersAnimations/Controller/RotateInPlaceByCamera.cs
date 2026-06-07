using System;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Animal Controller/Rotate in Place by Camera")]
	public class RotateInPlaceByCamera : MonoBehaviour
	{
		[Tooltip("Reference for the Animal Controller")]
		[RequiredField]
		public MAnimal animal;

		[Tooltip("If the angle formed by Camera's forward direction and Character's forward direction greater than this value, then start rotating in place")]
		[Min(15f)]
		public float LimitAngle = 90f;

		[Tooltip("If the angle formed by Camera's forward direction and Character's forward direction greater than this value, then Stop rotating in place")]
		[Min(1f)]
		public float AngleThreshold = 2f;

		[Tooltip("Wait x seconds before rotating in place if the conditions are true")]
		[Min(0f)]
		public float Wait = 1f;

		[Tooltip("Use only RootMotion Movement")]
		public bool RootMotionOnly = true;

		public bool debug = true;

		private bool RotateInPlace;

		private Vector3 TargetRotation;

		private float angle;

		private float releaseTime;

		private bool waitTime;

		private void OnEnable()
		{
			MAnimal mAnimal = animal;
			mAnimal.PreInput = (Action<MAnimal>)Delegate.Combine(mAnimal.PreInput, new Action<MAnimal>(PreInput));
			MAnimal mAnimal2 = animal;
			mAnimal2.PostStateMovement = (Action<MAnimal>)Delegate.Combine(mAnimal2.PostStateMovement, new Action<MAnimal>(PostStateMovement));
		}

		private void OnDisable()
		{
			MAnimal mAnimal = animal;
			mAnimal.PreInput = (Action<MAnimal>)Delegate.Remove(mAnimal.PreInput, new Action<MAnimal>(PreInput));
			MAnimal mAnimal2 = animal;
			mAnimal2.PostStateMovement = (Action<MAnimal>)Delegate.Remove(mAnimal2.PostStateMovement, new Action<MAnimal>(PostStateMovement));
		}

		private void PostStateMovement(MAnimal animal)
		{
			if (RotateInPlace && RootMotionOnly)
			{
				animal.AdditiveRotation = animal.Anim.deltaRotation;
			}
		}

		private void PreInput(MAnimal animal)
		{
			if (animal.RawInputAxis != Vector3.zero || animal.ActiveStateID.ID > 1 || animal.Strafe || animal.LockMovement || animal.LockUpDownMovement)
			{
				RotateInPlace = false;
				animal.Rotate_at_Direction = false;
				releaseTime = Time.time;
				waitTime = false;
				return;
			}
			if (!waitTime && MTools.ElapsedTime(releaseTime, Wait))
			{
				waitTime = true;
			}
			if (!waitTime)
			{
				return;
			}
			TargetRotation = Vector3.ProjectOnPlane(animal.MainCamera.transform.forward, Vector3.up).normalized;
			angle = Vector3.Angle(animal.transform.forward, TargetRotation);
			if (debug)
			{
				MDebug.DrawRay(base.transform.position + Vector3.up * 0.01f, TargetRotation, Color.yellow);
				MDebug.DrawRay(base.transform.position + Vector3.up * 0.01f, base.transform.forward, Color.yellow);
			}
			if (RotateInPlace)
			{
				animal.RotateAtDirection(TargetRotation);
				if (angle <= AngleThreshold)
				{
					if (debug)
					{
						Debug.Log("Stoping Rotate In Place ");
					}
					RotateInPlace = false;
					animal.Rotate_at_Direction = false;
				}
			}
			else if (angle >= LimitAngle)
			{
				RotateInPlace = true;
			}
		}

		private void Reset()
		{
			animal = GetComponent<MAnimal>();
		}
	}
}
