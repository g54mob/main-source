using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Manager
{
	[Serializable]
	public class SphereRenderManager : MonoSingleton<SphereRenderManager>
	{
		[SerializeField]
		private GameObject spherePrefab;

		[SerializeField]
		private GameObject skepSpherePrefab;

		private Dictionary<SphereRenderType, GameObject> sphereInstances = new Dictionary<SphereRenderType, GameObject>();

		private void Start()
		{
			InitializeSpherePrefab(SphereRenderType.ArcherRange);
			InitializeSpherePrefab(SphereRenderType.SkepRange);
			foreach (GameObject value in sphereInstances.Values)
			{
				value.SetActive(value: false);
			}
		}

		private void InitializeSpherePrefab(SphereRenderType sphereType)
		{
			switch (sphereType)
			{
			case SphereRenderType.ArcherRange:
				sphereInstances.Add(SphereRenderType.ArcherRange, UnityEngine.Object.Instantiate(spherePrefab, base.transform));
				break;
			case SphereRenderType.SkepRange:
				sphereInstances.Add(SphereRenderType.SkepRange, UnityEngine.Object.Instantiate(skepSpherePrefab, base.transform));
				break;
			default:
				Log.Error("Invalid SphereRenderType", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\SphereRenderManager.cs");
				break;
			}
		}

		public void Show(Vector3 position, float range, SphereRenderType type)
		{
			GameObject gameObject = sphereInstances[type];
			if (gameObject == null)
			{
				sphereInstances.Remove(type);
				InitializeSpherePrefab(type);
				gameObject = sphereInstances[type];
			}
			Transform obj = gameObject.transform;
			obj.position = position;
			obj.rotation = Quaternion.identity;
			obj.localScale = new Vector3(range, range, range);
			gameObject.SetActive(value: true);
		}

		public void Show(Transform parent, float range, SphereRenderType type)
		{
			GameObject gameObject = sphereInstances[type];
			if (gameObject == null)
			{
				sphereInstances.Remove(type);
				InitializeSpherePrefab(type);
				gameObject = sphereInstances[type];
			}
			if (gameObject.transform.parent != parent)
			{
				gameObject.transform.SetParent(parent);
			}
			Vector3 lossyScale = parent.lossyScale;
			Transform obj = gameObject.transform;
			obj.rotation = Quaternion.identity;
			obj.localScale = new Vector3(range / lossyScale.x, range / lossyScale.y, range / lossyScale.z);
			obj.localPosition = Vector3.zero;
			gameObject.SetActive(value: true);
		}

		public void Hide(SphereRenderType type)
		{
			GameObject gameObject = sphereInstances[type];
			if (gameObject != null)
			{
				gameObject.SetActive(value: false);
			}
		}
	}
}
