using System.Collections;
using PajamaLlama.Math;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Plop Properties")]
public class PlopProperties : ScriptableObject
{
	[Tooltip("Height curve that the transform will follow.")]
	[SerializeField]
	private AnimationCurve _movementCurve;

	public void Initiate(Transform transformToMove)
	{
		GameManager.Instance.StartCoroutine(StartPlopCoroutine(transformToMove));
	}

	private IEnumerator StartPlopCoroutine(Transform transformToMove)
	{
		float plopTimer = 0f;
		if (_movementCurve.keys.Length != 0)
		{
			float maximumAnimationTime = _movementCurve.keys[_movementCurve.keys.Length - 1].time;
			while (plopTimer >= 0f && plopTimer < maximumAnimationTime)
			{
				plopTimer += GameSpeedManager.PausableUnscaledDeltaTime;
				plopTimer = Mathf.Clamp(plopTimer, 0f, maximumAnimationTime);
				transformToMove.position = transformToMove.position.SetY(_movementCurve.Evaluate(plopTimer));
				yield return null;
			}
		}
	}
}
