using UnityEngine;

namespace Mirror
{
	public class NetworkRigidbodyReliable2D : NetworkTransformReliable
	{
		private Rigidbody2D rb;

		private bool wasKinematic;

		private new bool clientAuthority => syncDirection == SyncDirection.ClientToServer;

		protected override void Awake()
		{
			rb = target.GetComponent<Rigidbody2D>();
			if (rb == null)
			{
				Debug.LogError(base.name + "'s NetworkRigidbody2D.target " + target.name + " is missing a Rigidbody2D", this);
				return;
			}
			wasKinematic = rb.isKinematic;
			base.Awake();
		}

		public override void OnStopServer()
		{
			rb.isKinematic = wasKinematic;
		}

		public override void OnStopClient()
		{
			rb.isKinematic = wasKinematic;
		}

		private void FixedUpdate()
		{
			if (base.isServer && base.isClient)
			{
				if (clientAuthority && !base.IsClientWithAuthority)
				{
					rb.isKinematic = true;
				}
			}
			else if (base.isClient)
			{
				if (!base.IsClientWithAuthority)
				{
					rb.isKinematic = true;
				}
			}
			else if (base.isServer && clientAuthority)
			{
				rb.isKinematic = true;
			}
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			if (target.GetComponent<Rigidbody2D>() == null)
			{
				Debug.LogWarning(base.name + "'s NetworkRigidbody2D.target " + target.name + " is missing a Rigidbody2D", this);
			}
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
