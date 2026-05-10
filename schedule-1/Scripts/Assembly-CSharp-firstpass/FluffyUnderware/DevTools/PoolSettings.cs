using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace FluffyUnderware.DevTools
{
	[Serializable]
	public class PoolSettings
	{
		[Header("General")]
		[SerializeField]
		[Label("Auto Create Items", null)]
		[Tooltip("Automatically create items when an item is requested and none is available")]
		private bool m_AutoCreate;

		[Tooltip("Automatically disable objects when entering the pool and enable them when leaving it")]
		[Label("Auto Enable/Disable Items", null)]
		[SerializeField]
		private bool m_AutoEnableDisable;

		[Label("Debug mode", null)]
		[Tooltip("Log operations and show pooled objects in the hierarchy")]
		public bool Debug;

		[FormerlySerializedAs("m_MinItems")]
		[SerializeField]
		[Header("Item Count Constraints")]
		[Positive]
		[Tooltip("Minimum number of items in the pool")]
		private int minimumCount;

		[Positive]
		[SerializeField]
		[FormerlySerializedAs("m_Threshold")]
		[Tooltip("Maximum number of items in the pool")]
		private int maximumCount;

		[Label("Adjustment Interval", null)]
		[SerializeField]
		[Tooltip("Number of seconds between item count adjustments.\r\nIf 0, adjustments are instantaneous.")]
		[Positive]
		[FormerlySerializedAs("m_Speed")]
		private float countAdjustmentInterval;

		[FormerlySerializedAs("m_Prewarm")]
		[Tooltip("Initialize the pool with its item count already within the constraints")]
		[SerializeField]
		[Label("Initialize Constrained", null)]
		private bool initializeCountConstrained;

		public bool InitializeCountConstrained
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AutoCreate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AutoEnableDisable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int MinimumCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int MaximumCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float CountAdjustmentInterval
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use InitializeCountConstrained instead")]
		public bool Prewarm
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use MinimumCount instead")]
		public int MinItems
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use MaximumCount instead")]
		public int Threshold
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use CountAdjustmentInterval instead")]
		public float Speed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public PoolSettings()
		{
		}

		public PoolSettings(PoolSettings src)
		{
		}

		public void SetToDefault()
		{
		}

		[Obsolete("Use Validate instead")]
		[UsedImplicitly]
		public void OnValidate()
		{
		}

		public void Validate()
		{
		}
	}
}
