using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public abstract class ActionTriggerComponent : MonoBehaviour
	{
		public enum ActionTriggerType
		{
			Start = 1,
			Destroy = 2,
			OnEnable = 3,
			OnDisable = 4,
			Update = 5,
			TriggerEnter = 6,
			TriggerExit = 7,
			CollisionEnter = 8,
			CollisionExit = 9,
			TriggerEnter2D = 10,
			TriggerExit2D = 11,
			CollisionEnter2D = 12,
			CollisionExit2D = 13,
			Custom = 14
		}

		[SerializeField]
		private ActionTriggerType m_triggerOn;

		public bool IsDone { get; protected set; }

		public abstract void ExecuteAction();

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		private void OnCollisionExit(Collision collision)
		{
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
		}

		public virtual void Reset()
		{
		}

		private bool TryExecuteAction(ActionTriggerType triggerType)
		{
			return false;
		}
	}
}
