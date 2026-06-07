using System.Collections;
using UnityEngine;

public class LilyPad : MonoBehaviour
{
	private SoundManager soundManager;

	public Transform lilypadHolder;

	public AnimationCurve buoyanceCurve;

	private bool isBuoyance;

	public void Start()
	{
		soundManager = Object.FindObjectOfType<SoundManager>();
	}

	public void OnMouseDown()
	{
		if (!isBuoyance)
		{
			StartCoroutine(Buoyance());
			SoundManager.LoadSoundEffect(base.transform, soundManager.overworld_lilypad);
		}
	}

	public IEnumerator Buoyance()
	{
		isBuoyance = true;
		Keyframe[] keys = buoyanceCurve.keys;
		keys[0].value = lilypadHolder.transform.localPosition.y;
		keys[0].outTangent = 1f;
		keys[^1].value = lilypadHolder.transform.localPosition.y;
		buoyanceCurve.keys = keys;
		float elapsedSeconds = 0f;
		while (elapsedSeconds < buoyanceCurve[buoyanceCurve.length - 1].time)
		{
			lilypadHolder.localPosition = new Vector3(lilypadHolder.localPosition.x, buoyanceCurve.Evaluate(elapsedSeconds), lilypadHolder.localPosition.z);
			elapsedSeconds += Time.deltaTime;
			yield return null;
		}
		isBuoyance = false;
	}
}
