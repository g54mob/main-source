using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.FloatingOverlaySystem
{
	internal class FloatingOverlayManager : MonoSingleton<FloatingOverlayManager>
	{
		private readonly Dictionary<Transform, FloatingSystemRootTransform> holders = new Dictionary<Transform, FloatingSystemRootTransform>();

		private FloatingOverlayView backgroundView;

		private FloatingOverlayView foregroundView;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			holders.Clear();
			backgroundView = null;
			foregroundView = null;
		}

		internal FloatingElementHolder GetElementHolder(Transform transform, FloatingElementHolderType holderType, FloatingElementParentType parentType = FloatingElementParentType.Background)
		{
			if (transform == null)
			{
				Log.Error("Tried to access overlay element holder on probably disposed transform.", "C:\\GIT\\dev\\Assets\\Scripts\\FloatingOverlaySystem\\FloatingOverlayManager.cs");
				return null;
			}
			FloatingSystemRootTransform floatingSystemRootTransform = transform.gameObject.GetComponent<FloatingSystemRootTransform>();
			if (floatingSystemRootTransform == null)
			{
				floatingSystemRootTransform = transform.gameObject.AddComponent<FloatingSystemRootTransform>();
				holders.Add(transform, floatingSystemRootTransform);
			}
			if (!floatingSystemRootTransform.Holders.TryGetValue(holderType, out var value))
			{
				value = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(FloatingOverlaySystemConstants.ElementHolderPrefabName[(int)holderType]), GetParent(parentType)).GetComponent<FloatingElementHolder>();
				value.transform.localPosition = Vector3.zero;
				value.Setup(holderType, transform);
				floatingSystemRootTransform.AddHolder(value);
			}
			else
			{
				value.Setup(holderType, transform);
			}
			return value;
		}

		private Transform GetParent(FloatingElementParentType parentType)
		{
			switch (parentType)
			{
			case FloatingElementParentType.None:
			case FloatingElementParentType.Background:
				return backgroundView.transform;
			case FloatingElementParentType.Foreground:
				return foregroundView.transform;
			default:
				throw new ArgumentOutOfRangeException("parentType", parentType, null);
			}
		}

		internal void RootTransformDestroyed(Transform transform)
		{
			holders.Remove(transform);
		}

		internal void RegisterBackgroundView(BackgroundOverlayView view)
		{
			backgroundView = view;
		}

		internal void RegisterForegroundView(ForegroundOverlayView view)
		{
			foregroundView = view;
		}
	}
}
