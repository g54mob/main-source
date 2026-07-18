using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BuildFinishController : MonoBehaviour
{
	public static BuildFinishController Instance;

	private int rndAnimation;

	[SerializeField]
	private bool playSpecificAnimation;

	[SerializeField]
	private int animationToPlay;

	[SerializeField]
	private List<BuildFinishInstance> buildFinishes;

	[SerializeField]
	private SoundManager soundManager;

	private void Awake()
	{
		Instance = this;
	}

	public void DecideRandomAnimation()
	{
		rndAnimation = Random.Range(0, buildFinishes.Count);
	}

	public BuildFinishInstance GetSelectedAnimation()
	{
		if (!playSpecificAnimation)
		{
			return buildFinishes[rndAnimation];
		}
		return buildFinishes[animationToPlay];
	}

	public float GetSelectedAnimationTime()
	{
		float num = 0f;
		foreach (BuildFinishComponent buildFinishComponent in buildFinishes[rndAnimation].buildFinishComponents)
		{
			num += buildFinishComponent.time;
		}
		return num;
	}

	public void PlayBuildFinishAnimation(Transform tileTransform)
	{
		Sequence sequence = DOTween.Sequence();
		if (playSpecificAnimation)
		{
			rndAnimation = animationToPlay;
		}
		foreach (BuildFinishComponent buildFinishComponent in buildFinishes[rndAnimation].buildFinishComponents)
		{
			Tween t = tileTransform.DOMove(new Vector3(0f, 0f, 0f), 0f);
			Vector3 targetVector = buildFinishComponent.targetVector;
			switch (buildFinishComponent.transformComponent)
			{
			case TransformComponent.position:
				t = tileTransform.DOMove(new Vector3(tileTransform.position.x + targetVector.x, tileTransform.position.y + targetVector.y, tileTransform.position.z + targetVector.z), buildFinishComponent.time).SetEase(buildFinishComponent.easeMode);
				break;
			case TransformComponent.rotation:
				t = tileTransform.DOLocalRotateQuaternion(Quaternion.Euler(targetVector.x, targetVector.y, targetVector.z), buildFinishComponent.time).SetEase(buildFinishComponent.easeMode);
				break;
			case TransformComponent.scale:
				t = tileTransform.DOScale(new Vector3(targetVector.x, targetVector.y, targetVector.z), buildFinishComponent.time).SetEase(buildFinishComponent.easeMode);
				break;
			}
			if (buildFinishComponent.append)
			{
				sequence.Append(t);
			}
			else
			{
				t.Play();
			}
		}
		sequence.Play();
	}

	public void PlayFinishSound()
	{
		if (playSpecificAnimation)
		{
			rndAnimation = animationToPlay;
		}
		soundManager.PlaySound(buildFinishes[rndAnimation].soundEffect, randomPitch: false);
	}
}
