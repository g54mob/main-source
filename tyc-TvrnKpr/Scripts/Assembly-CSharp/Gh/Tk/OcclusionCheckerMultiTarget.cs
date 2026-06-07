using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class OcclusionCheckerMultiTarget : BaseOcclusionChecker
	{
		public LayerMask layerMask;

		public List<Transform> targets;

		private Transform _mainCamT;

		private readonly Dictionary<SetOccluderTransparency, bool> _currentSots;

		private readonly RaycastHit[] _hitResult;

		protected override void DisableOcclusions()
		{
		}

		public override void Start()
		{
		}

		private void UIController_ResetUI(object sender, EventArgs e)
		{
		}

		protected override void UpdateInternal()
		{
		}
	}
}
