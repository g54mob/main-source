using System.Collections;
using UnityEngine;

public class DogBreedingMachine : MonoBehaviour
{
	public Animator animatorRef;

	public ConfigurableJoint leftEarJoint;

	public ConfigurableJoint rightEarJoint;

	public Transform leftArmAttachTransform;

	public Transform rightArmAttachTransform;

	public ConfigurableJoint leftArmControlJoint;

	public ConfigurableJoint rightArmControlJoint;

	public ParticleSystem smashParticles;

	private string fastGearsBool = "fast";

	private string vibrateBool = "vibrate";

	private string movementStartBool = "movement";

	private Vector3 startingEggOffset = new Vector3(0f, 19f, 0f);

	private Vector3 loweredEarRotation = Vector3.zero;

	private Vector3 raisedEarRotation = new Vector3(90f, 0f, 0f);

	private Quaternion loweredArmRotation = Quaternion.identity;

	private Quaternion raisedArmRotationLeft = new Quaternion(0.782f, 0f, 0.9f, 1.06f);

	private Quaternion raisedArmRotationRight = new Quaternion(0.782f, 0f, -0.9f, 1.06f);

	private Quaternion smashedArmRotationLeft = new Quaternion(0.8f, -0.3f, 0.5f, 0.4f);

	private Quaternion smashedArmRotationRight = new Quaternion(0.8f, 0.3f, -0.5f, 0.4f);

	private Vector3 startingPos;

	private Vector3 startingOffset = new Vector3(0f, -32f, 0f);

	private void Awake()
	{
		startingPos = base.transform.position;
		base.transform.position += startingOffset;
	}

	public Vector3 GetStartingEggOffset()
	{
		return startingEggOffset;
	}

	public IEnumerator SmashRoutine(GameObject eggRef, BreedingGUI guiRef)
	{
		WaitForSeconds betweenWait = new WaitForSeconds(1f);
		WaitForFixedUpdate fixedWait = new WaitForFixedUpdate();
		int smashCount = 3;
		float currentTime = 0f;
		float raiseArmTime = 5f;
		float smashTime = 0.25f;
		float releaseTime = 1f;
		Vector3 finalEggPos = eggRef.transform.localPosition - startingEggOffset;
		Vector3 startingEggPos = eggRef.transform.localPosition;
		eggRef.transform.localPosition = startingEggPos;
		while (currentTime < raiseArmTime)
		{
			currentTime += Time.fixedDeltaTime;
			Quaternion targetRotation = Quaternion.Slerp(loweredArmRotation, raisedArmRotationLeft, currentTime / raiseArmTime);
			Quaternion targetRotation2 = Quaternion.Slerp(loweredArmRotation, raisedArmRotationRight, currentTime / raiseArmTime);
			leftArmControlJoint.targetRotation = targetRotation;
			rightArmControlJoint.targetRotation = targetRotation2;
			float quadraticOutValue = Inchworm.GetQuadraticOutValue(currentTime, 0f, -1f, raiseArmTime);
			eggRef.transform.localPosition = Vector3.Lerp(startingEggPos, finalEggPos, quadraticOutValue);
			yield return fixedWait;
		}
		eggRef.transform.localPosition = finalEggPos;
		leftArmControlJoint.targetRotation = raisedArmRotationLeft;
		rightArmControlJoint.targetRotation = raisedArmRotationRight;
		yield return new WaitForSeconds(1.5f);
		yield return StartCoroutine(guiRef.PeekRuneRoutine());
		SetFastGears(val: true);
		StartCoroutine(EarFlapRoutine());
		yield return new WaitForSeconds(1f);
		while (smashCount > 0)
		{
			currentTime = 0f;
			while (currentTime < smashTime)
			{
				currentTime += Time.fixedDeltaTime;
				Quaternion targetRotation3 = Quaternion.Slerp(raisedArmRotationLeft, smashedArmRotationLeft, currentTime / smashTime);
				Quaternion targetRotation4 = Quaternion.Slerp(raisedArmRotationRight, smashedArmRotationRight, currentTime / smashTime);
				leftArmControlJoint.targetRotation = targetRotation3;
				rightArmControlJoint.targetRotation = targetRotation4;
				yield return fixedWait;
			}
			leftArmControlJoint.targetRotation = smashedArmRotationLeft;
			rightArmControlJoint.targetRotation = smashedArmRotationRight;
			smashParticles.Play();
			yield return new WaitForSeconds(0.5f);
			currentTime = 0f;
			while (currentTime < releaseTime)
			{
				currentTime += Time.fixedDeltaTime;
				Quaternion targetRotation5 = Quaternion.Slerp(smashedArmRotationLeft, raisedArmRotationLeft, currentTime / releaseTime);
				Quaternion targetRotation6 = Quaternion.Slerp(smashedArmRotationRight, raisedArmRotationRight, currentTime / releaseTime);
				leftArmControlJoint.targetRotation = targetRotation5;
				rightArmControlJoint.targetRotation = targetRotation6;
				yield return fixedWait;
			}
			leftArmControlJoint.targetRotation = raisedArmRotationLeft;
			rightArmControlJoint.targetRotation = raisedArmRotationRight;
			yield return betweenWait;
			smashCount--;
		}
	}

	public Vector3 GetStartingPosition()
	{
		return startingPos;
	}

	public Vector3 GetStartingOffset()
	{
		return startingOffset;
	}

	public void SetVibrate(bool val)
	{
		animatorRef.SetBool(vibrateBool, val);
	}

	public void StartGearMovement()
	{
		animatorRef.SetBool(movementStartBool, value: true);
	}

	public void SetFastGears(bool val)
	{
		animatorRef.SetBool(fastGearsBool, val);
	}

	public void RaiseEars()
	{
		leftEarJoint.targetRotation = Quaternion.Euler(raisedEarRotation);
		rightEarJoint.targetRotation = Quaternion.Euler(raisedEarRotation);
	}

	public void LowerEars()
	{
		leftEarJoint.targetRotation = Quaternion.Euler(loweredEarRotation);
		rightEarJoint.targetRotation = Quaternion.Euler(loweredEarRotation);
	}

	private IEnumerator EarFlapRoutine()
	{
		WaitForSeconds earWait = new WaitForSeconds(0.1f);
		for (int flapCount = 50; flapCount > 0; flapCount--)
		{
			RaiseEars();
			yield return earWait;
			LowerEars();
			yield return earWait;
		}
	}
}
