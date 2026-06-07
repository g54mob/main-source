using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace FluffyUnderware.DevTools
{
	[Serializable]
	public class PoolSettings
	{
		[Tooltip("Automatically create items when an item is requested and none is available")]
		[Label("Auto Create Items", null)]
		[SerializeField]
		[Header("General")]
		private bool m_AutoCreate;

		[SerializeField]
		[Tooltip("Automatically disable objects when entering the pool and enable them when leaving it")]
		[Label("Auto Enable/Disable Items", null)]
		private bool m_AutoEnableDisable;

		[Label("Debug mode", null)]
		[Tooltip("Log operations and show pooled objects in the hierarchy")]
		public bool Debug;

		[Tooltip("Minimum number of items in the pool")]
		[FormerlySerializedAs("m_MinItems")]
		[SerializeField]
		[Positive]
		[Header("Item Count Constraints")]
		private int minimumCount;

		[FormerlySerializedAs("m_Threshold")]
		[SerializeField]
		[Positive]
		[Tooltip("Maximum number of items in the pool")]
		private int maximumCount;

		[Label("Adjustment Interval", null)]
		[Tooltip("Number of seconds between item count adjustments.\r\nIf 0, adjustments are instantaneous.")]
		[FormerlySerializedAs("m_Speed")]
		[Positive]
		[SerializeField]
		private float countAdjustmentInterval;

		[SerializeField]
		[FormerlySerializedAs("m_Prewarm")]
		[Label("Initialize Constrained", null)]
		[Tooltip("Initialize the pool with its item count already within the constraints")]
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

		[Obsolete("Use CountAdjustmentInterval instead")]
		[UsedImplicitly]
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
