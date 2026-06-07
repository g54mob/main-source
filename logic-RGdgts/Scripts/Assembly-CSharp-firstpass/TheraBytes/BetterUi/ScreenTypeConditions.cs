using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class ScreenTypeConditions
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private IsCertainScreenOrientation checkOrientation;

		[SerializeField]
		private IsScreenOfCertainSize checkScreenSize;

		[SerializeField]
		private IsCertainAspectRatio checkAspectRatio;

		[SerializeField]
		private IsScreenOfCertainDeviceInfo checkDeviceType;

		[SerializeField]
		private IsScreenTagPresent checkScreenTag;

		[SerializeField]
		private ScreenInfo optimizedScreenInfo;

		[SerializeField]
		private List<string> fallbacks;

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsActive { get; private set; }

		public List<string> Fallbacks => null;

		public Vector2 OptimizedResolution => default(Vector2);

		public int OptimizedWidth => 0;

		public int OptimizedHeight => 0;

		public float OptimizedDpi => 0f;

		public IsCertainScreenOrientation CheckOrientation => null;

		public IsScreenOfCertainSize CheckScreenSize => null;

		public IsCertainAspectRatio CheckAspectRatio => null;

		public IsScreenOfCertainDeviceInfo CheckDeviceType => null;

		public IsScreenTagPresent CheckScreenTag => null;

		public ScreenInfo OptimizedScreenInfo => null;

		public ScreenTypeConditions(string displayName, params Type[] enabledByDefault)
		{
		}

		private void EnsureScreenConditions(params Type[] enabledByDefault)
		{
		}

		private void EnsureScreenCondition<T>(ref T screenCondition, Func<T> instantiatoMethod, Type[] enabledTypes) where T : IIsActive
		{
		}

		public bool IsScreenType()
		{
			return false;
		}
	}
}
