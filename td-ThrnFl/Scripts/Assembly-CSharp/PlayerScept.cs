using System.Collections;
using Rewired;
using UnityEngine;

public class PlayerScept : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public GameObject loadoutParent;

	public Transform scept;

	public Transform scepterInteractionTarget;

	public AnimationCurve inCurve;

	public AnimationCurve outCurve;

	public float inTime = 0.2f;

	public float outTime = 0.4f;

	private Player input;

	private Vector3 initPos;

	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		input = ReInput.players.GetPlayer(0);
		initPos = scept.localPosition;
	}

	private void Update()
	{
		if (input.GetButtonDown("Interact"))
		{
			StopAllCoroutines();
			StartCoroutine(AnimationIn());
		}
		if (input.GetButtonUp("Interact"))
		{
			StopAllCoroutines();
			StartCoroutine(AnimationOut());
		}
	}

	private IEnumerator AnimationIn()
	{
		float timer = 0f;
		Vector3 startPos = scept.localPosition;
		while (timer < inTime)
		{
			timer += Time.deltaTime;
			scept.localPosition = Vector3.Lerp(startPos, scepterInteractionTarget.localPosition, inCurve.Evaluate(Mathf.InverseLerp(0f, inTime, timer)));
			yield return null;
		}
		scept.localPosition = scepterInteractionTarget.localPosition;
	}

	private IEnumerator AnimationOut()
	{
		float timer = 0f;
		_ = scept.localPosition;
		while (timer < outTime)
		{
			timer += Time.deltaTime;
			scept.localPosition = Vector3.Lerp(scept.localPosition, initPos, outCurve.Evaluate(Mathf.InverseLerp(0f, outTime, timer)));
			yield return null;
		}
		scept.localPosition = initPos;
	}

	public void OnDawn_AfterSunrise()
	{
		loadoutParent.SetActive(value: true);
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDusk()
	{
		loadoutParent.SetActive(value: false);
	}

	public void OnDuskEarly()
	{
	}
}
