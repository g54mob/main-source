using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Pools
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[HelpURL("https://curvyeditor.com/doclink/arraypoolsettings")]
	public class ArrayPoolsSettings : DTVersionedMonoBehaviour
	{
		[Tooltip("The maximal number of elements of type Vector2 allowed to be stored in the arrays' pool waiting to be reused")]
		[SerializeField]
		private long vector2Capacity;

		[Tooltip("The maximal number of elements of type Vector3 allowed to be stored in the arrays' pool waiting to be reused")]
		[SerializeField]
		private long vector3Capacity;

		[Tooltip("The maximal number of elements of type Vector4 allowed to be stored in the arrays' pool waiting to be reused")]
		[SerializeField]
		private long vector4Capacity;

		[Tooltip("The maximal number of elements of type Int32 allowed to be stored in the arrays' pool waiting to be reused")]
		[SerializeField]
		private long intCapacity;

		[Tooltip("The maximal number of elements of type Single (a.k.a float) allowed to be stored in the arrays' pool waiting to be reused")]
		[SerializeField]
		private long floatCapacity;

		[Tooltip("The maximal number of elements of type CGSpots allowed to be stored in the arrays' pool waiting to be reused")]
		[SerializeField]
		private long cgSpotCapacity;

		[SerializeField]
		[Tooltip("Log in the console each time an array pool allocates a new array in memory")]
		private bool logAllocations;

		public long Vector2Capacity
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public long Vector3Capacity
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public long Vector4Capacity
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public long IntCapacity
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public long FloatCapacity
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public long CGSpotCapacity
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public bool LogAllocations
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override void OnValidate()
		{
		}

		protected override void OnEnable()
		{
		}

		[UsedImplicitly]
		private void Start()
		{
		}

		private void ValidateAndApply()
		{
		}
	}
}
