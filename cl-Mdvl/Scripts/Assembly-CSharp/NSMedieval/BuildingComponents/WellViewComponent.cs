using System;
using System.Collections;
using NSEipix;
using NSMedieval.Map;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(WellComponent))]
	public class WellViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private WellComponent wellComponent;

		[SerializeField]
		private LineRenderer bucketLineRenderer;

		[SerializeField]
		private GameObject bucket;

		private float bucketPickupPositionY;

		private float bucketLowerPositionY;

		private IEnumerator bucketCoroutine;

		private bool animationInProgress;

		private WellComponentInstance WellComponentInstance => wellComponent?.ComponentInstance;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			wellComponent = GetComponent<WellComponent>();
		}

		protected override void OnComponentEnterFinishedState(bool fromLoading = false)
		{
			base.OnComponentEnterFinishedState(fromLoading);
			WellComponentInstance.RefreshBucketLineEvent += OnRefreshBucketLine;
			WellComponentInstance.StartObtainingWaterEvent += OnStartObtainingWater;
			WellComponentInstance.BucketHardResetEvent += OnBucketHardReset;
			WellComponentInstance.WaterObtainedEvent += OnWaterObtained;
			bucketPickupPositionY = WellComponentInstance.WorldPosition.y + 1f;
		}

		private void OnRefreshBucketLine()
		{
			if (WellComponentInstance == null || WellComponentInstance.HasDisposed || WellComponentInstance.OwnerBuilding == null || WellComponentInstance.OwnerBuilding.HasDisposed || WellComponentInstance?.WaterSourceNode == null)
			{
				bucketLineRenderer.gameObject.SetActive(value: false);
				bucket.SetActive(value: false);
				return;
			}
			float x = WellComponentInstance.Center.ToVector3World().x;
			float z = WellComponentInstance.Center.ToVector3World().z;
			float num = 1.5f;
			float num2 = 0.8f;
			MapNode waterSourceNode = WellComponentInstance.WaterSourceNode;
			float y = WellComponentInstance.Center.ToVector3World().y + num;
			float num3 = waterSourceNode.WorldPosition.y + (float)World.MapBlockHeight + num2;
			switch (waterSourceNode.WaterLevel)
			{
			case WaterDepthLevel.Low:
				num3 -= 2.5f;
				break;
			case WaterDepthLevel.Medium:
				num3 -= 1f;
				break;
			}
			bucketLowerPositionY = num3;
			bucketLineRenderer.gameObject.SetActive(value: true);
			bucket.SetActive(value: true);
			bucket.transform.position = new Vector3(x, num3, z);
			bucketLineRenderer.positionCount = 2;
			bucketLineRenderer.SetPosition(0, new Vector3(x, y, z));
			bucketLineRenderer.SetPosition(1, new Vector3(x, num3, z));
		}

		private void OnStartObtainingWater(float time)
		{
			if (!animationInProgress)
			{
				animationInProgress = true;
				if (bucketCoroutine != null)
				{
					StopCoroutine(bucketCoroutine);
				}
				bucketCoroutine = AnimateBucket(bucketLowerPositionY, bucketPickupPositionY, time);
				StartCoroutine(bucketCoroutine);
			}
		}

		private void OnBucketHardReset()
		{
			if (bucketCoroutine != null)
			{
				StopCoroutine(bucketCoroutine);
			}
			float x = bucket.transform.position.x;
			float z = bucket.transform.position.z;
			bucket.transform.position = new Vector3(x, bucketLowerPositionY, z);
			bucketLineRenderer.positionCount = 2;
			bucketLineRenderer.SetPosition(1, new Vector3(x, bucketLowerPositionY, z));
			animationInProgress = false;
		}

		private void OnWaterObtained()
		{
			if (bucketCoroutine != null)
			{
				StopCoroutine(bucketCoroutine);
			}
			bucketCoroutine = AnimateBucket(bucketPickupPositionY, bucketLowerPositionY, WellComponentInstance.WellHeight * 0.05f);
			StartCoroutine(bucketCoroutine);
		}

		private IEnumerator AnimateBucket(float fromVal, float toVal, float duration)
		{
			float counter = 0f;
			while (counter < duration)
			{
				counter += Time.deltaTime;
				float y = Mathf.Lerp(fromVal, toVal, counter / duration);
				float x = bucket.transform.position.x;
				float z = bucket.transform.position.z;
				bucket.transform.position = new Vector3(x, y, z);
				bucketLineRenderer.SetPosition(1, new Vector3(x, y, z));
				yield return null;
			}
			animationInProgress = false;
		}
	}
}
