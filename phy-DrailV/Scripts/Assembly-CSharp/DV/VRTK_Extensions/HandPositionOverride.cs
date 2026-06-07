using System;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.VRTK_Extensions
{
	[ExecuteAfter(typeof(DefaultOrder))]
	public class HandPositionOverride : MonoBehaviour
	{
		public interface IPositionProvider
		{
			int Priority { get; }

			(Vector3 pos, Quaternion rot, float lerp) GetPose();
		}

		private readonly List<IPositionProvider> providers = new List<IPositionProvider>();

		private void Awake()
		{
			base.enabled = providers.Count != 0;
		}

		private void OnEnable()
		{
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(OnPreCullCallback));
		}

		private void OnDisable()
		{
			Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(OnPreCullCallback));
		}

		private void OnPreCullCallback(Camera cam)
		{
			RefreshPose();
		}

		private void RefreshPose()
		{
			IPositionProvider positionProvider = null;
			int num = int.MinValue;
			foreach (IPositionProvider provider in providers)
			{
				if (provider.Priority > num)
				{
					num = provider.Priority;
					positionProvider = provider;
				}
			}
			if (positionProvider != null)
			{
				(Vector3, Quaternion, float) pose = positionProvider.GetPose();
				base.transform.position = Vector3.Lerp(base.transform.parent.position, pose.Item1, pose.Item3);
				base.transform.rotation = Quaternion.Slerp(base.transform.parent.rotation, pose.Item2, pose.Item3);
			}
			else
			{
				base.transform.localPosition = Vector3.zero;
				base.transform.localRotation = Quaternion.identity;
			}
		}

		public void Add(IPositionProvider provider)
		{
			providers.Add(provider);
			base.enabled = true;
		}

		public void Remove(IPositionProvider provider)
		{
			providers.Remove(provider);
			if (providers.Count == 0)
			{
				base.transform.localPosition = Vector3.zero;
				base.transform.localRotation = Quaternion.identity;
				base.enabled = false;
			}
		}
	}
}
