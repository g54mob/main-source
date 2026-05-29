using System.Collections.Generic;
using UnityEngine;

namespace InputControl
{
	public class CursorUICluster : MonoBehaviour
	{
		[SerializeField]
		private List<CursorUIGroup> _cursorUIGroups;

		[SerializeField]
		private CursorUIGroup _defaultGroup;

		private int _currentIndex;

		private CursorUIGroup CurrentGroup => null;

		public CursorUIGroup OnSelect()
		{
			return null;
		}
	}
}
