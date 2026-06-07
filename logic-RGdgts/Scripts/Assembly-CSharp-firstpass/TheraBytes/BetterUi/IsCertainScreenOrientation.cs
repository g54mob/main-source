using System;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class IsCertainScreenOrientation : IScreenTypeCheck, IIsActive
	{
		public enum Orientation
		{
			Portrait = 0,
			Landscape = 1
		}

		[SerializeField]
		private Orientation expectedOrientation;

		[SerializeField]
		private bool isActive;

		public Orientation ExpectedOrientation
		{
			get
			{
				return default(Orientation);
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

		public IsCertainScreenOrientation(Orientation expectedOrientation)
		{
		}

		public bool IsScreenType()
		{
			return false;
		}
	}
}
