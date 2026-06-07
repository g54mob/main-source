using UnityEngine;

namespace ModApi.Craft.Parts
{
	public class PartColliderScript : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("If set to true, the collider will be ignore when detecting collisions while placing parts in the designer.")]
		private bool _ignoreDesignerCollisions;

		[SerializeField]
		[Tooltip("If set to true, then the collider will be ignored when checking for part interactions in first person view.")]
		private bool _ignoreFirstPersonCollisions;

		[SerializeField]
		[Tooltip("Indicates that this collider is the primary collider for the part. This should encompass the as much of the primary portion of the part as possible. A part can only have one primary collider. If it is not specified or if more than one is specified as primary, the first collider found will be chose to be the primary.")]
		private bool _isPrimary;

		[SerializeField]
		private bool _selectionEnabledInFlight = true;

		public Collider Collider { get; private set; }

		public bool IgnoreDesignerCollisions => _ignoreDesignerCollisions;

		public bool IgnoreFirstPersonCollisions => _ignoreFirstPersonCollisions;

		public bool IsPrimary
		{
			get
			{
				return _isPrimary;
			}
			set
			{
				_isPrimary = value;
			}
		}

		public bool SelectionEnabledInFlight
		{
			get
			{
				return _selectionEnabledInFlight;
			}
			set
			{
				_selectionEnabledInFlight = value;
			}
		}

		public static PartColliderScript AddAsPrimary(GameObject obj)
		{
			PartColliderScript partColliderScript = obj.AddComponent<PartColliderScript>();
			partColliderScript._isPrimary = true;
			return partColliderScript;
		}

		protected virtual void Awake()
		{
			Collider = GetComponent<Collider>();
			if (Collider == null)
			{
				Debug.LogWarning("PartColliderScript could not find an associated collider attached to its game object.", this);
			}
		}
	}
}
