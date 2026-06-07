using UnityEngine;

namespace Obi
{
	public abstract class ObiColliderBase : MonoBehaviour
	{
		[SerializeProperty("Thickness")]
		[SerializeField]
		private float thickness;

		[SerializeProperty("Inverted")]
		[SerializeField]
		private bool inverted;

		[SerializeProperty("CollisionMaterial")]
		[SerializeField]
		private ObiCollisionMaterial material;

		[SerializeField]
		private int filter = ObiUtils.MakeFilter(65535, 0);

		protected ObiColliderHandle shapeHandle;

		protected ObiRigidbodyBase obiRigidbody;

		protected bool wasUnityColliderEnabled = true;

		protected bool needsUpdate = true;

		protected ObiShapeTracker tracker;

		public ObiCollisionMaterial CollisionMaterial
		{
			get
			{
				return material;
			}
			set
			{
				if (material != value)
				{
					material = value;
					needsUpdate = true;
				}
			}
		}

		public int Filter
		{
			get
			{
				return filter;
			}
			set
			{
				if (filter != value)
				{
					filter = value;
					needsUpdate = true;
				}
			}
		}

		public float Thickness
		{
			get
			{
				return thickness;
			}
			set
			{
				if (!Mathf.Approximately(thickness, value))
				{
					thickness = value;
					needsUpdate = true;
				}
			}
		}

		public bool Inverted
		{
			get
			{
				return inverted;
			}
			set
			{
				if (inverted != value)
				{
					inverted = value;
					needsUpdate = true;
				}
			}
		}

		public ObiShapeTracker Tracker => tracker;

		public ObiColliderHandle Handle
		{
			get
			{
				if (shapeHandle == null)
				{
					FindSourceCollider();
				}
				return shapeHandle;
			}
		}

		public ObiForceZone ForceZone { get; set; }

		public ObiRigidbodyBase Rigidbody => obiRigidbody;

		protected abstract void CreateTracker();

		protected abstract Component GetUnityCollider(ref bool enabled);

		protected abstract void FindSourceCollider();

		protected void CreateRigidbody()
		{
			obiRigidbody = null;
			Rigidbody componentInParent = GetComponentInParent<Rigidbody>();
			Rigidbody2D componentInParent2 = GetComponentInParent<Rigidbody2D>();
			if (componentInParent != null)
			{
				obiRigidbody = componentInParent.GetComponent<ObiRigidbody>();
				if (obiRigidbody == null)
				{
					obiRigidbody = componentInParent.gameObject.AddComponent<ObiRigidbody>();
				}
			}
			else if (componentInParent2 != null)
			{
				obiRigidbody = componentInParent2.GetComponent<ObiRigidbody2D>();
				if (obiRigidbody == null)
				{
					obiRigidbody = componentInParent2.gameObject.AddComponent<ObiRigidbody2D>();
				}
			}
		}

		private void OnTransformParentChanged()
		{
			CreateRigidbody();
		}

		protected void AddCollider()
		{
			if (GetUnityCollider(ref wasUnityColliderEnabled) != null && (shapeHandle == null || !shapeHandle.isValid))
			{
				shapeHandle = ObiColliderWorld.GetInstance().CreateCollider();
				shapeHandle.owner = this;
				CreateTracker();
				CreateRigidbody();
			}
		}

		protected void RemoveCollider()
		{
			ObiColliderWorld.GetInstance().DestroyCollider(shapeHandle);
			if (tracker != null)
			{
				tracker.Destroy();
				tracker = null;
			}
		}

		public void ForceUpdate()
		{
			needsUpdate = true;
		}

		public void UpdateIfNeeded()
		{
			bool flag = false;
			Component unityCollider = GetUnityCollider(ref flag);
			if (unityCollider != null)
			{
				if (tracker != null && needsUpdate)
				{
					tracker.UpdateIfNeeded();
				}
				needsUpdate = !unityCollider.gameObject.isStatic;
			}
			else if (shapeHandle != null && shapeHandle.isValid)
			{
				RemoveCollider();
			}
		}

		private void OnEnable()
		{
			needsUpdate = true;
			FindSourceCollider();
		}

		private void OnDisable()
		{
			RemoveCollider();
		}
	}
}
