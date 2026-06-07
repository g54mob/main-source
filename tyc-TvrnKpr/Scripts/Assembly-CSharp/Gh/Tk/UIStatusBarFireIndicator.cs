using System;
using UnityEngine;

namespace Gh.Tk
{
	public class UIStatusBarFireIndicator : MonoBehaviour
	{
		public float MaxFires;

		private Transform[] _fireTransforms;

		private long _transformCount;

		private static SoundEngineParameterControl<int> _fireIntensityUI;

		protected void Start()
		{
		}

		protected void UpdateFires(object sender, EventArgs eventArgs)
		{
		}

		private void UpdateFires()
		{
		}
	}
}
