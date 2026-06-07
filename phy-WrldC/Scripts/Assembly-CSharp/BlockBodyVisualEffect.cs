using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBodyVisualEffect : RigidbodyVisualEffect
{
	[SerializeField]
	private GameObject jointBreakParticlesPrefab;

	private BlockBodyView blockBodyView;

	private Collider[] colliders;

	private List<FixedJointView> fixedJointViews;

	private List<HingeJointView> hingeJointViews;

	protected override void Initialize()
	{
		base.Initialize();
		blockBodyView = GetComponent<BlockBodyView>();
		colliders = blockBodyView.GetComponentsInChildren<Collider>();
		fixedJointViews = new List<FixedJointView>();
		hingeJointViews = new List<HingeJointView>();
		blockBodyView.OnSetUpToActionEvent += delegate
		{
			fixedJointViews.Clear();
			fixedJointViews.AddRange(blockBodyView.GetAllFixedJointViews());
			hingeJointViews.Clear();
			hingeJointViews.AddRange(blockBodyView.GetAllHingeJointViews());
		};
		blockBodyView.OnBeforeDestroyBlockEvent += OnBeforeDestroyBlockHandler;
	}

	private IEnumerator OnJointBreak(float breakForce)
	{
		yield return null;
		GameObject gameObject = FindOtherBlockBodyInFixedJoints();
		if (gameObject == null)
		{
			gameObject = FindOtherBlockBodyInHingeJoints();
		}
		if (gameObject != null)
		{
			(Vector3, Quaternion) tuple = FindBestBreakPoint(gameObject);
			Vector3 item = tuple.Item1;
			Quaternion item2 = tuple.Item2;
			GameObject particlesInstance = VisualEffectsManager.Instance.GetParticlesInstance(jointBreakParticlesPrefab);
			particlesInstance.transform.position = item;
			particlesInstance.transform.rotation = item2;
		}
	}

	private GameObject FindOtherBlockBodyInFixedJoints()
	{
		GameObject result = null;
		FixedJointView fixedJointView = null;
		for (int i = 0; i < fixedJointViews.Count; i++)
		{
			if (fixedJointViews[i].FixedJoint == null)
			{
				result = fixedJointViews[i].ConnectedBlockBodyView.gameObject;
				fixedJointView = fixedJointViews[i];
				break;
			}
		}
		if (fixedJointView != null)
		{
			fixedJointViews.Remove(fixedJointView);
		}
		return result;
	}

	private GameObject FindOtherBlockBodyInHingeJoints()
	{
		GameObject result = null;
		HingeJointView hingeJointView = null;
		for (int i = 0; i < hingeJointViews.Count; i++)
		{
			if (hingeJointViews[i].HingeJoint == null)
			{
				result = hingeJointViews[i].ConnectedBlockBodyView.gameObject;
				hingeJointView = hingeJointViews[i];
				break;
			}
		}
		if (hingeJointView != null)
		{
			hingeJointViews.Remove(hingeJointView);
		}
		return result;
	}

	private void OnBeforeDestroyBlockHandler()
	{
		for (int i = 0; i < fixedJointViews.Count; i++)
		{
			if (fixedJointViews[i].FixedJoint != null)
			{
				(Vector3, Quaternion) tuple = FindBestBreakPoint(fixedJointViews[i].ConnectedBlockBodyView.gameObject);
				Vector3 item = tuple.Item1;
				Quaternion item2 = tuple.Item2;
				GameObject particlesInstance = VisualEffectsManager.Instance.GetParticlesInstance(jointBreakParticlesPrefab);
				particlesInstance.transform.position = item;
				particlesInstance.transform.rotation = item2;
			}
		}
		for (int j = 0; j < hingeJointViews.Count; j++)
		{
			if (hingeJointViews[j].HingeJoint != null)
			{
				(Vector3, Quaternion) tuple2 = FindBestBreakPoint(hingeJointViews[j].ConnectedBlockBodyView.gameObject);
				Vector3 item3 = tuple2.Item1;
				Quaternion item4 = tuple2.Item2;
				GameObject particlesInstance2 = VisualEffectsManager.Instance.GetParticlesInstance(jointBreakParticlesPrefab);
				particlesInstance2.transform.position = item3;
				particlesInstance2.transform.rotation = item4;
			}
		}
		fixedJointViews.Clear();
		hingeJointViews.Clear();
	}

	private (Vector3, Quaternion) FindBestBreakPoint(GameObject otherBodyObject)
	{
		Collider collider = colliders[0];
		if (colliders.Length > 1)
		{
			float num = Vector3.Distance(collider.bounds.center, otherBodyObject.transform.position);
			for (int i = 1; i < colliders.Length; i++)
			{
				float num2 = Vector3.Distance(colliders[i].bounds.center, otherBodyObject.transform.position);
				if (num2 < num)
				{
					collider = colliders[i];
					num = num2;
				}
			}
		}
		Vector3 vector = collider.ClosestPoint(otherBodyObject.transform.position);
		Quaternion item = Quaternion.FromToRotation(toDirection: (vector - otherBodyObject.transform.position).normalized, fromDirection: Vector3.up);
		return (vector, item);
	}

	public override void SetVisualEffectsByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetVisualEffectsByGameStyleData(gameStylesData);
		if (gameStylesData.visualEffectStylesData.bbJointBreakParticlesPrefab != null)
		{
			jointBreakParticlesPrefab = gameStylesData.visualEffectStylesData.bbJointBreakParticlesPrefab;
		}
	}
}
