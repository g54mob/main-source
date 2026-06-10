using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.WorldMap.Caravan;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	public class CaravanView : WorldMapItemClickable
	{
		[SerializeField]
		private LineRenderer lineRenderer;

		[SerializeField]
		private MeshRenderer figurine;

		[NonSerialized]
		private CaravanInstance caravanInstance;

		private void OnCaravanStateChanged(CaravanInstance caravanInstance, CaravanState caravanState)
		{
			if (caravanInstance == this.caravanInstance)
			{
				bool flag = caravanInstance.EventContext is AmbushContext;
				float value = (flag ? 1f : 0f);
				MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(figurine);
				materialPropertyBlock.SetFloat("_CaravanAttacked", value);
				figurine.SetPropertyBlock(materialPropertyBlock);
				MaterialPropertyBlock materialPropertyBlock2 = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(lineRenderer);
				materialPropertyBlock2.SetFloat("_CaravanAttacked", value);
				lineRenderer.SetPropertyBlock(materialPropertyBlock2);
				if (caravanState == CaravanState.Returning || caravanState == CaravanState.Travelling || flag)
				{
					SetupLineRenderer();
				}
			}
		}

		public void TickTime(long minutes, float minutesFract)
		{
			UpdatePosition();
		}

		public void Setup(CaravanInstance caravanInstance)
		{
			this.caravanInstance = caravanInstance;
			CaravanController instance = MonoSingleton<CaravanController>.Instance;
			instance.CaravanStateChangedEvent = (CaravanController.CaravanStateChangedDelegate)Delegate.Combine(instance.CaravanStateChangedEvent, new CaravanController.CaravanStateChangedDelegate(OnCaravanStateChanged));
			OnCaravanStateChanged(this.caravanInstance, this.caravanInstance.CaravanState);
		}

		public void SetupLineRenderer()
		{
			int num = (int)Mathf.Clamp((caravanInstance.DestinationGridPosition - caravanInstance.StartGridPosition).magnitude * 0.5f, 3f, 50f);
			List<Vector3> list = new List<Vector3>();
			Vector3 vector = MonoSingleton<WorldMap>.Instance.transform.position + Vector3.up * 0.4f;
			for (int i = 0; i < num; i++)
			{
				float value = (float)i / (float)(num - 1);
				Vector3 positionByProgress = caravanInstance.GetPositionByProgress(Mathf.Clamp01(value));
				positionByProgress += vector;
				list.Add(positionByProgress);
			}
			lineRenderer.positionCount = list.Count;
			lineRenderer.SetPositions(list.ToArray());
		}

		private void UpdatePosition()
		{
			if (caravanInstance != null && caravanInstance.CaravanState != CaravanState.None)
			{
				base.transform.localPosition = caravanInstance.CurrentPosition;
				Vector3 forward = caravanInstance.GetDestinationPosition() - caravanInstance.CurrentPosition;
				if (!forward.Equals(Vector3.zero))
				{
					Vector3 eulerAngles = Quaternion.LookRotation(forward, Vector3.up).eulerAngles;
					eulerAngles.x = 0f;
					eulerAngles.z = 0f;
					base.transform.rotation = Quaternion.Euler(eulerAngles);
				}
			}
		}

		public override void OnPointerEnter()
		{
		}

		public override void OnPointerLeave()
		{
		}

		public override void OnClick()
		{
			MonoSingleton<WorldMapController>.Instance.CaravanClicked(caravanInstance);
		}

		public void OnEnd()
		{
			if (MonoSingleton<CaravanController>.IsInstantiated())
			{
				CaravanController instance = MonoSingleton<CaravanController>.Instance;
				instance.CaravanStateChangedEvent = (CaravanController.CaravanStateChangedDelegate)Delegate.Remove(instance.CaravanStateChangedEvent, new CaravanController.CaravanStateChangedDelegate(OnCaravanStateChanged));
			}
		}
	}
}
