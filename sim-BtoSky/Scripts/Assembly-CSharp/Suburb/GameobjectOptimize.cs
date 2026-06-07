using UnityEngine;

namespace Suburb
{
	public class GameobjectOptimize : MonoBehaviour
	{
		public GameObject GameobjectToDisable;

		public GameObject DistanceFromObject;

		public float VisibilityDistance;

		private float Distance;

		private GameObject MainCamera;

		private void Start()
		{
			if (DistanceFromObject == null)
			{
				DistanceFromObject = base.gameObject;
			}
			if (GameObject.FindGameObjectWithTag("MainCamera") != null)
			{
				MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
			}
			else
			{
				Object.Destroy(GetComponent("GameobjectOptimize"));
			}
		}

		private void Update()
		{
			Distance = Vector3.Distance(MainCamera.transform.position, DistanceFromObject.transform.position);
			if (Distance < VisibilityDistance)
			{
				GameobjectToDisable.SetActive(value: true);
			}
			if (Distance > VisibilityDistance)
			{
				GameobjectToDisable.SetActive(value: false);
			}
		}
	}
}
