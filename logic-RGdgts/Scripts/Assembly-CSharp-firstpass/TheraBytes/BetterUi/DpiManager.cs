using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class DpiManager
	{
		[Serializable]
		public class DpiOverride
		{
			[SerializeField]
			private float dpi;

			[SerializeField]
			private string deviceModel;

			public float Dpi => 0f;

			public string DeviceModel => null;

			public DpiOverride(string deviceModel, float dpi)
			{
			}
		}

		[SerializeField]
		private List<DpiOverride> overrides;

		public float GetDpi()
		{
			return 0f;
		}
	}
}
