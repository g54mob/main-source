using System.Collections;
using RainbowArt.CleanFlatUI;
using UnityEngine;

public class Blender : MonoBehaviour
{
	public float shakeAmount = 0.1f;

	private Vector3 originalPos;

	public float maxGage = 20f;

	public float currentGage;

	public ProgressBarPattern grindGage;

	private bool overGrinded;

	[SerializeField]
	private Animator animator;

	private void Start()
	{
		originalPos = base.transform.localPosition;
		currentGage = 0f;
		animator.speed = 0f;
	}

	private void Update()
	{
	}

	public void Shake()
	{
		animator.speed = 1f;
		Vector3 vector = Random.insideUnitSphere * shakeAmount;
		base.transform.localPosition = originalPos + vector;
		if (currentGage > maxGage)
		{
			overGrinded = true;
		}
		if (overGrinded)
		{
			currentGage -= Time.deltaTime * 3f;
		}
		else
		{
			currentGage += Time.deltaTime * 3f;
		}
		grindGage.CurrentValue = currentGage;
	}

	public void StopShake()
	{
		animator.speed = 0f;
	}

	public void Clear()
	{
		grindGage.MaxValue = maxGage;
		currentGage = 0f;
		overGrinded = false;
	}

	public void InitBlender()
	{
		StartCoroutine(InitBlenderCorutine());
	}

	private IEnumerator InitBlenderCorutine()
	{
		yield return null;
		grindGage.MaxValue = maxGage;
		currentGage = 0f;
		overGrinded = false;
	}
}
