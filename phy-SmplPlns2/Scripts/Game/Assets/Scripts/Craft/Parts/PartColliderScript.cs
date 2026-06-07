using Jundroo.Common.Attributes;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartColliderScript : MonoBehaviour
	{
		private static class Profile
		{
			public static readonly ProfilerMarker Start = new ProfilerMarker("PartColliderScript.Start");
		}

		[SerializeField]
		[InspectorLabel("Is Primary Collider")]
		[Tooltip("Indicates that this collider is the primary collider for the part. This should encompass the as much of the primary portion of the part as possible. A part can only have one primary collider. If it is not specified or if more than one is specified as primary, the first collider found will be chose to be the primary.")]
		private bool __isPrimary;

		private Collider _collider;

		[SerializeField]
		[Tooltip("A value indicating whether to exclude this mesh from the drag model. By default, all mesh renderers are included in the drag calculation, so this flag can be set to remove specific renderers from the calculation.")]
		private bool _excludeFromDragModel;

		[SerializeField]
		[Tooltip("If set to true, the collider will be ignore when detecting collisions while placing parts in the designer.")]
		private bool _ignoreDesignerCollisions;

		[SerializeField]
		[Tooltip("If set to true, the collider will be included in the aircraft's bounds calculation.")]
		private bool _includeInBounds = true;

		public Collider Collider => _collider ?? (_collider = GetComponent<Collider>());

		public bool ExcludeFromDragModel
		{
			get
			{
				return _excludeFromDragModel;
			}
			set
			{
				_excludeFromDragModel = value;
			}
		}

		public bool IgnoreDesignerCollisions
		{
			get
			{
				return _ignoreDesignerCollisions;
			}
			set
			{
				_ignoreDesignerCollisions = value;
			}
		}

		public bool IncludeInBounds
		{
			get
			{
				return _includeInBounds;
			}
			set
			{
				_includeInBounds = value;
			}
		}

		public bool IsPrimary
		{
			get
			{
				return __isPrimary;
			}
			set
			{
				__isPrimary = value;
			}
		}

		public static PartColliderScript AddAsPrimary(GameObject obj)
		{
			PartColliderScript partColliderScript = obj.AddComponent<PartColliderScript>();
			partColliderScript.__isPrimary = true;
			return partColliderScript;
		}

		protected virtual void Awake()
		{
			if (Collider == null)
			{
				Debug.LogWarning("PartColliderScript could not find an associated collider attached to its game object.", this);
			}
		}

		protected virtual void Start()
		{
			using (Profile.Start.Auto())
			{
				PartScript componentInParent = GetComponentInParent<PartScript>();
				AircraftScript aircraftScript = componentInParent?.Aircraft;
				if (IsPrimary && (object)aircraftScript != null && !aircraftScript.RemoteAircraft && aircraftScript.LoadContext == CraftLoadContext.Flight)
				{
					CollisionIgnoreScript.Create(this, componentInParent);
				}
			}
		}
	}
}
