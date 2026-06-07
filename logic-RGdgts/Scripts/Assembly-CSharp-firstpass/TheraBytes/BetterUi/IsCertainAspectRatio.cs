using System;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class IsCertainAspectRatio : IScreenTypeCheck, IIsActive
	{
		[SerializeField]
		private float minAspect;

		[SerializeField]
		private float maxAspect;

		[SerializeField]
		private bool inverse;

		[SerializeField]
		private bool isActive;

		public float MinAspect
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaxAspect
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool Inverse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsScreenType()
		{
			return false;
		}
	}
}
