using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ConstructionPause : CTSBehaviour
	{
		[SerializeField]
		[NavArea(true)]
		private int _humanAreaMask;

		private bool _constructionIsValid;

		private EAccess _allRoomsAccess;

		private bool _humanAccess;

		public static event Action<bool> ConstructionValidityChanged;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			EntranceResolver.EntranceCountChanged += OnEntranceCountChanged;
		}

		private void OnEntranceCountChanged(int obj)
		{
			if (EntranceResolver.EntranceExists(_humanAreaMask) && !_humanAccess)
			{
				_humanAccess = true;
				_constructionIsValid = _allRoomsAccess != EAccess.Inaccessible;
			}
		}

		private void SetConstructionValidity(bool isValid)
		{
			_ = _constructionIsValid;
		}
	}
}
