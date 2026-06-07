using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class SyncAnimatorsToGamePause : MonoBehaviour
	{
		private List<Animator> _animators;

		public bool includeChildren;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnTimeSettingChanged(object sender, EventArgs e)
		{
		}
	}
}
