using UnityEngine;

namespace __Project__.Scripts.Managers
{
	public class CleaningReputationManager : NoktaSingleton<CleaningReputationManager>
	{
		[SerializeField]
		private float m_GarbageReputationPoint;

		[SerializeField]
		private float m_DirtReputationPoint;

		[SerializeField]
		private float m_DustingReputationPoint;

		[SerializeField]
		private float m_TotalReputationLimit;

		[SerializeField]
		private int m_DirtyStorePenalty;

		[SerializeField]
		private int m_MinCustomerCountToCheck;

		[SerializeField]
		private int m_MaxCustomerCountToCheck;

		private float m_TotalGarbageReputationPoint;

		private float m_TotalDirtReputationPoint;

		private float m_TotalDustingReputationPoint;

		private int m_CustomerCheckCount;

		public float TotalGarbageReputationPoint
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TotalDirtReputationPoint
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TotalDustingReputationPoint
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TotalReputationPoint => 0f;

		public float TotalReputationLimit => 0f;

		public bool IsStoreDirty => false;

		private void Awake()
		{
		}

		private void ResetReputationData()
		{
		}

		public void UpdateGarbageReputationPoint(bool isAdding)
		{
		}

		public void UpdateDirtReputationPoint(bool isAdding)
		{
		}

		public void UpdateDustingReputationPoint()
		{
		}

		public void CheckStoreCleaning(Customer complainingCustomer)
		{
		}

		private void TryPunishing(Customer complainingCustomer)
		{
		}
	}
}
