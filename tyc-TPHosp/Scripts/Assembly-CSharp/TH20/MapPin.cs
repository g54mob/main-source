using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MapPin : MonoBehaviour
	{
		[SerializeField]
		private Collider _collider;

		[SerializeField]
		private Collider _boundingCollider;

		[SerializeField]
		protected TooltipSpawner _tooltipSpawner;

		[SerializeField]
		private MetagameCutsceneLocation _cutsceneLocation;

		[SerializeField]
		protected GameObject _meshRoot;

		public MetagameCutsceneLocation CutsceneLocation => _cutsceneLocation;

		public virtual void PrepareForDestroy()
		{
		}

		protected virtual void OnEnable()
		{
			Refresh();
		}

		protected virtual void OnDisable()
		{
		}

		public virtual void Refresh(bool refreshVisuals = true)
		{
		}

		public virtual void OnCursorOver(bool over)
		{
		}

		public virtual void OnSelected()
		{
		}

		public virtual void OnUnselected()
		{
		}

		public virtual void OnDebugClick()
		{
		}

		public virtual bool IsPinShowing()
		{
			if (base.gameObject.activeSelf)
			{
				return _meshRoot.activeSelf;
			}
			return false;
		}

		public virtual bool IsPinUnlocked()
		{
			return true;
		}

		public bool RayCast(Ray ray, float rayLength, out float distance)
		{
			if (base.enabled && _collider != null)
			{
				if (_collider != null && _collider.Raycast(ray, out var hitInfo, rayLength))
				{
					distance = hitInfo.distance;
					return true;
				}
				if (_boundingCollider != null && _boundingCollider.Raycast(ray, out var hitInfo2, rayLength))
				{
					distance = hitInfo2.distance;
					return true;
				}
			}
			distance = 0f;
			return false;
		}
	}
}
