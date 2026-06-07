using System;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyVisualEffect : VisualEffectBase
{
	[SerializeField]
	private List<GameObject> impactDecalList;

	[SerializeField]
	private List<GameObject> impactParticlesList;

	[SerializeField]
	private GameObject dragSparkParticles;

	[SerializeField]
	private float dragParticlesFrequency = 0.2f;

	private readonly float[][] ranges = new float[5][]
	{
		new float[2] { 1f, 15f },
		new float[2] { 15f, 30f },
		new float[2] { 30f, 45f },
		new float[2] { 45f, 60f },
		new float[2] { 60f, 75f }
	};

	private float timeCounter;

	protected override void Initialize()
	{
		timeCounter = 0f;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!(collision.impulse.magnitude < 1f))
		{
			CreateParticles(collision);
			CreateDecal(collision);
		}
	}

	private void OnCollisionStay(Collision collision)
	{
		timeCounter += Time.deltaTime;
		if (!(timeCounter < dragParticlesFrequency) && !collision.gameObject.CompareTag("Block"))
		{
			float magnitude = collision.relativeVelocity.magnitude;
			if (!(magnitude < 3f) && !(UnityEngine.Random.Range(magnitude / 20f, 1f) < 0.99f))
			{
				timeCounter = 0f;
				ContactPoint contact = collision.GetContact(UnityEngine.Random.Range(0, collision.contactCount - 1));
				GameObject particlesInstance = VisualEffectsManager.Instance.GetParticlesInstance(dragSparkParticles);
				particlesInstance.transform.position = contact.point;
				particlesInstance.transform.rotation = Quaternion.identity;
			}
		}
	}

	private void CreateParticles(Collision collision)
	{
		CreateVisualObjectAtImpact(collision, impactParticlesList, InstantiateMethod);
		GameObject InstantiateMethod(GameObject visualEffectPrefab)
		{
			return VisualEffectsManager.Instance.GetParticlesInstance(visualEffectPrefab);
		}
	}

	private void CreateDecal(Collision collision)
	{
		var (gameObject, gameObject2) = CreateVisualObjectAtImpact(collision, impactDecalList, InstantiateMethod);
		if (gameObject == null)
		{
			return;
		}
		AdjustScaleByCollisionImpulse(gameObject, gameObject2.transform.localScale, collision.impulse.magnitude);
		DecalLifeControl component = gameObject.GetComponent<DecalLifeControl>();
		if (collision.gameObject.GetComponent<Rigidbody>() != null)
		{
			GameObject gameObject3 = collision.gameObject;
			if (collision.gameObject.GetComponent<WheelColliderSource>() != null)
			{
				gameObject3 = gameObject3.transform.GetChild(0).GetChild(0).gameObject;
			}
			ContactPoint contact = collision.GetContact(0);
			Vector3 offsetPos = gameObject3.transform.InverseTransformPoint(contact.point);
			Vector3 offsetUpDir = gameObject3.transform.InverseTransformDirection(contact.normal);
			Vector3 offsetFwDir = gameObject3.transform.InverseTransformDirection(gameObject.transform.forward);
			component.StickToOtherObject(gameObject3.transform, offsetPos, offsetUpDir, offsetFwDir);
		}
		GameObject InstantiateMethod(GameObject visualEffectPrefab)
		{
			return VisualEffectsManager.Instance.GetDecalInstance(visualEffectPrefab);
		}
	}

	private (GameObject veObject, GameObject vePrefab) CreateVisualObjectAtImpact(Collision collision, List<GameObject> visualEffectPrefabs, Func<GameObject, GameObject> instantiateMethod)
	{
		float magnitude = collision.impulse.magnitude;
		ContactPoint contact = collision.GetContact(0);
		Vector3 point = contact.point;
		Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
		var (gameObject, item) = InstantiateByCollisionImpulse(magnitude, visualEffectPrefabs, instantiateMethod);
		if (gameObject == null)
		{
			Debug.LogWarning("Visual effect not instantiated (" + base.name + "). Impulse: " + magnitude + " Library: " + visualEffectPrefabs.Count);
			return (veObject: null, vePrefab: null);
		}
		gameObject.transform.position = point;
		gameObject.transform.rotation = rotation;
		gameObject.transform.Rotate(Vector3.up, UnityEngine.Random.Range(0, 360), Space.Self);
		return (veObject: gameObject, vePrefab: item);
	}

	private (GameObject veObject, GameObject vePrefab) InstantiateByCollisionImpulse(float impulse, List<GameObject> visualEffectPrefabs, Func<GameObject, GameObject> instantiateMethod)
	{
		GameObject gameObject = null;
		if (visualEffectPrefabs.Count < 4)
		{
			return (veObject: null, vePrefab: null);
		}
		gameObject = (impulse.IsInRange(1f, 15f, MyExtensions.RangeLimits.MinInMaxEx) ? visualEffectPrefabs[0] : (impulse.IsInRange(15f, 30f, MyExtensions.RangeLimits.MinInMaxEx) ? visualEffectPrefabs[1] : (impulse.IsInRange(45f, 60f, MyExtensions.RangeLimits.MinInMaxEx) ? visualEffectPrefabs[2] : ((!(impulse >= 60f)) ? visualEffectPrefabs[0] : visualEffectPrefabs[3]))));
		GameObject obj = instantiateMethod(gameObject);
		obj.SetActive(value: true);
		return (veObject: obj, vePrefab: gameObject);
	}

	private void AdjustScaleByCollisionImpulse(GameObject visualObject, Vector3 originalScale, float impulse)
	{
		float num = 0f;
		if (impulse.IsInRange(ranges[0], MyExtensions.RangeLimits.MinInMaxEx))
		{
			num = Mathf.InverseLerp(ranges[0][0], ranges[0][1], impulse) * 2f - 1f;
		}
		else if (impulse.IsInRange(ranges[1], MyExtensions.RangeLimits.MinInMaxEx))
		{
			num = Mathf.InverseLerp(ranges[1][0], ranges[1][1], impulse) * 2f - 1f;
		}
		else if (impulse.IsInRange(ranges[2], MyExtensions.RangeLimits.MinInMaxEx))
		{
			num = Mathf.InverseLerp(ranges[2][0], ranges[2][1], impulse) * 2f - 1f;
		}
		else if (impulse > ranges[3][0])
		{
			num = Mathf.InverseLerp(ranges[3][0], ranges[3][1], impulse) * 2f - 1f;
		}
		num = 1f + num * 0.2f;
		visualObject.transform.localScale = Vector3.Scale(originalScale, new Vector3(num, 1f, num));
	}

	public override void SetVisualEffectsByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetVisualEffectsByGameStyleData(gameStylesData);
		if (gameStylesData.visualEffectStylesData.rbImpactDecalList != null)
		{
			impactDecalList = gameStylesData.visualEffectStylesData.rbImpactDecalList;
		}
		if (gameStylesData.visualEffectStylesData.rbImpactParticlesList != null)
		{
			impactParticlesList = gameStylesData.visualEffectStylesData.rbImpactParticlesList;
		}
		if (gameStylesData.visualEffectStylesData.rbDragSparkParticles != null)
		{
			dragSparkParticles = gameStylesData.visualEffectStylesData.rbDragSparkParticles;
		}
	}
}
