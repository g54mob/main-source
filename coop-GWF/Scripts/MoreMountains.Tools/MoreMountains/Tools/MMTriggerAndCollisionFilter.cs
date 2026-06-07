using UnityEngine;

namespace MoreMountains.Tools
{
	public abstract class MMTriggerAndCollisionFilter : MonoBehaviour
	{
		public TriggerAndCollisionMask TriggerAndCollisionFilter = TriggerAndCollisionMask.All;

		protected virtual bool UseEvent(TriggerAndCollisionMask value)
		{
			return (TriggerAndCollisionFilter & value) != 0;
		}

		protected abstract void OnCollisionEnter2D_(Collision2D collision);

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (UseEvent(TriggerAndCollisionMask.OnCollisionEnter2D))
			{
				OnCollisionEnter2D_(collision);
			}
		}

		protected abstract void OnCollisionExit2D_(Collision2D collision);

		private void OnCollisionExit2D(Collision2D collision)
		{
			if (UseEvent(TriggerAndCollisionMask.OnCollisionExit2D))
			{
				OnCollisionExit2D_(collision);
			}
		}

		protected abstract void OnCollisionStay2D_(Collision2D collision);

		private void OnCollisionStay2D(Collision2D collision)
		{
			if (UseEvent(TriggerAndCollisionMask.OnCollisionStay2D))
			{
				OnCollisionStay2D_(collision);
			}
		}

		protected abstract void OnTriggerEnter2D_(Collider2D collider);

		private void OnTriggerEnter2D(Collider2D collider)
		{
			if (UseEvent(TriggerAndCollisionMask.OnTriggerEnter2D))
			{
				OnTriggerEnter2D_(collider);
			}
		}

		protected abstract void OnTriggerExit2D_(Collider2D collider);

		private void OnTriggerExit2D(Collider2D collider)
		{
			if (UseEvent(TriggerAndCollisionMask.OnTriggerExit2D))
			{
				OnTriggerExit2D_(collider);
			}
		}

		protected abstract void OnTriggerStay2D_(Collider2D collider);

		private void OnTriggerStay2D(Collider2D collider)
		{
			if (UseEvent(TriggerAndCollisionMask.OnTriggerStay2D))
			{
				OnTriggerStay2D_(collider);
			}
		}

		protected abstract void OnCollisionEnter_(Collision c);

		private void OnCollisionEnter(Collision c)
		{
			if (UseEvent(TriggerAndCollisionMask.OnCollisionEnter))
			{
				OnCollisionEnter_(c);
			}
		}

		protected abstract void OnCollisionExit_(Collision c);

		private void OnCollisionExit(Collision c)
		{
			if (UseEvent(TriggerAndCollisionMask.OnCollisionExit))
			{
				OnCollisionExit_(c);
			}
		}

		protected abstract void OnCollisionStay_(Collision c);

		private void OnCollisionStay(Collision c)
		{
			if (UseEvent(TriggerAndCollisionMask.OnCollisionStay))
			{
				OnCollisionStay_(c);
			}
		}

		protected abstract void OnTriggerEnter_(Collider collider);

		private void OnTriggerEnter(Collider collider)
		{
			if (UseEvent(TriggerAndCollisionMask.OnTriggerEnter))
			{
				OnTriggerEnter_(collider);
			}
		}

		protected abstract void OnTriggerExit_(Collider collider);

		private void OnTriggerExit(Collider collider)
		{
			if (UseEvent(TriggerAndCollisionMask.OnTriggerExit))
			{
				OnTriggerExit_(collider);
			}
		}

		protected abstract void OnTriggerStay_(Collider collider);

		private void OnTriggerStay(Collider collider)
		{
			if (UseEvent(TriggerAndCollisionMask.OnTriggerStay))
			{
				OnTriggerStay_(collider);
			}
		}
	}
}
