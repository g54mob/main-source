using System.Collections;
using UnityEngine;

public class DoggyLauncher : MonoBehaviour
{
	public enum TriggerType
	{
		PAD = 0,
		UNDER_PAD = 1
	}

	public Transform springTransform;

	public Rigidbody platformRigidbody;

	private int lastReportedUnderPadFrame = -1;

	private int padClearFrameRequirement = 10;

	private float extendTime = 0.1f;

	private float holdTime = 0.5f;

	private float returnTime = 0.25f;

	private Vector3 springStartingScale = Vector3.one;

	private Vector3 platformStartingPos = Vector3.zero;

	private Vector3 springExtensionScale = new Vector3(1f, 5.35f, 1f);

	private Vector3 platformExtensionPos = new Vector3(0f, 2.855f, 0f);

	private string launchSound = "launcher_launch";

	private Coroutine currentExtensionRoutine;

	private void OnDestroy()
	{
		if (currentExtensionRoutine != null)
		{
			StopCoroutine(currentExtensionRoutine);
			currentExtensionRoutine = null;
		}
	}

	private void OnDisable()
	{
		if (currentExtensionRoutine != null)
		{
			StopCoroutine(currentExtensionRoutine);
			currentExtensionRoutine = null;
		}
		springTransform.localScale = springStartingScale;
		platformRigidbody.transform.localPosition = platformStartingPos;
	}

	public void OnObjectInTriggerArea(TriggerType tType)
	{
		if (currentExtensionRoutine != null)
		{
			if (tType == TriggerType.UNDER_PAD)
			{
				lastReportedUnderPadFrame = Time.frameCount;
			}
		}
		else if (tType == TriggerType.PAD)
		{
			currentExtensionRoutine = StartCoroutine(ExtendRoutine());
		}
	}

	private IEnumerator ExtendRoutine()
	{
		WaitForFixedUpdate fixedUpdateWait = new WaitForFixedUpdate();
		AudioController.Play(launchSound, base.transform.position);
		float currentTimer = 0f;
		for (float usedExtendTime = extendTime * base.transform.localScale.x; currentTimer < usedExtendTime; currentTimer += Time.fixedDeltaTime)
		{
			float sinusoidalValue = Inchworm.GetSinusoidalValue(currentTimer / usedExtendTime, 0f, -1f, 1f);
			float x = springStartingScale.x;
			float y = springStartingScale.y + (springExtensionScale.y - springStartingScale.y) * sinusoidalValue;
			float z = springStartingScale.z;
			float x2 = platformStartingPos.x;
			float y2 = (platformExtensionPos.y - platformStartingPos.y) * sinusoidalValue;
			float z2 = platformStartingPos.z;
			springTransform.localScale = new Vector3(x, y, z);
			platformRigidbody.MovePosition(platformRigidbody.transform.parent.TransformPoint(new Vector3(x2, y2, z2)));
			yield return fixedUpdateWait;
		}
		springTransform.localScale = springExtensionScale;
		platformRigidbody.MovePosition(platformRigidbody.transform.parent.TransformPoint(platformExtensionPos));
		yield return new WaitForSeconds(holdTime);
		while (Time.frameCount <= lastReportedUnderPadFrame + padClearFrameRequirement)
		{
			yield return fixedUpdateWait;
		}
		currentTimer = returnTime;
		while (currentTimer > 0f)
		{
			if (Time.frameCount <= lastReportedUnderPadFrame + padClearFrameRequirement)
			{
				yield return fixedUpdateWait;
				continue;
			}
			float sinusoidalValue2 = Inchworm.GetSinusoidalValue(currentTimer / returnTime, 0f, -1f, 1f);
			float x3 = springStartingScale.x;
			float y3 = springStartingScale.y + (springExtensionScale.y - springStartingScale.y) * sinusoidalValue2;
			float z3 = springStartingScale.z;
			float x4 = platformStartingPos.x;
			float y4 = (platformExtensionPos.y - platformStartingPos.y) * sinusoidalValue2;
			float z4 = platformStartingPos.z;
			springTransform.localScale = new Vector3(x3, y3, z3);
			platformRigidbody.MovePosition(platformRigidbody.transform.parent.TransformPoint(new Vector3(x4, y4, z4)));
			yield return fixedUpdateWait;
			currentTimer -= Time.fixedDeltaTime;
		}
		springTransform.localScale = springStartingScale;
		platformRigidbody.MovePosition(platformRigidbody.transform.parent.TransformPoint(platformStartingPos));
		currentExtensionRoutine = null;
	}
}
