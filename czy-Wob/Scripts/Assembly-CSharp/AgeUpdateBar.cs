using System.Collections;
using TMPro;
using UnityEngine;

public class AgeUpdateBar : MonoBehaviour
{
	public GameObject interiorBar;

	public GameObject progressIndicator;

	public GameObject agesHolder;

	public TextMeshProUGUI beforeAgeText;

	public TextMeshProUGUI afterAgeText;

	private float puppyIndicatorXPos = -400f;

	private float adultIndicatorXPos = 400f;

	private float puppyBarXPos = -800f;

	private float adultBarXPos;

	private Vector3 agesHolderMov = new Vector3(0f, -100f, 0f);

	private Vector3 progressIndicatorMov;

	private Vector3 progressBarMov;

	private Inchworm inchwormRef;

	public void SetAges(DogAge oldAge, DogAge newAge)
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		string readableNameForDogAge = DoggyBrain.GetReadableNameForDogAge(oldAge);
		string readableNameForDogAge2 = DoggyBrain.GetReadableNameForDogAge(newAge);
		beforeAgeText.text = readableNameForDogAge;
		afterAgeText.text = readableNameForDogAge2;
		float xPosForAge = GetXPosForAge(oldAge, puppyIndicatorXPos, adultIndicatorXPos);
		float xPosForAge2 = GetXPosForAge(newAge, puppyIndicatorXPos, adultIndicatorXPos);
		float xPosForAge3 = GetXPosForAge(oldAge, puppyBarXPos, adultBarXPos);
		float xPosForAge4 = GetXPosForAge(newAge, puppyBarXPos, adultBarXPos);
		progressBarMov = new Vector3(xPosForAge4 - xPosForAge3, 0f, 0f);
		progressIndicatorMov = new Vector3(xPosForAge2 - xPosForAge, 0f, 0f);
		Vector3 localPosition = new Vector3(xPosForAge3, interiorBar.transform.localPosition.y, interiorBar.transform.localPosition.z);
		Vector3 localPosition2 = new Vector3(xPosForAge, progressIndicator.transform.localPosition.y, progressIndicator.transform.localPosition.z);
		interiorBar.transform.localPosition = localPosition;
		progressIndicator.transform.localPosition = localPosition2;
	}

	public void AnimateBar()
	{
		StartCoroutine(AnimateBarRoutine());
	}

	private IEnumerator AnimateBarRoutine()
	{
		yield return new WaitForSecondsRealtime(0.5f);
		inchwormRef.RequestEase(agesHolder, -agesHolderMov, 1f, adjustStartingPos: false, Inchworm.EaseStyle.EaseOutBounce, Inchworm.EaseType.Position, null, Inchworm.EasePriority.Normal, keepSameParent: true, 0.25f, invisibleBeforeStart: false, useLocalPosition: true);
		inchwormRef.RequestEase(interiorBar, progressBarMov, 1f, adjustStartingPos: false, Inchworm.EaseStyle.EaseOutBounce, Inchworm.EaseType.Position, null, Inchworm.EasePriority.Normal, keepSameParent: true, 0f, invisibleBeforeStart: false, useLocalPosition: true);
		inchwormRef.RequestEase(progressIndicator, progressIndicatorMov, 1f, adjustStartingPos: false, Inchworm.EaseStyle.EaseOutBounce, Inchworm.EaseType.Position, null, Inchworm.EasePriority.Normal, keepSameParent: true, 0f, invisibleBeforeStart: false, useLocalPosition: true);
	}

	private float GetXPosForAge(DogAge age, float startingXPos, float endingXPos)
	{
		float num = 1f;
		float num2 = (float)age;
		float num3 = 5f - num;
		float num4 = (num2 - num) / num3;
		return startingXPos + (endingXPos - startingXPos) * num4;
	}
}
