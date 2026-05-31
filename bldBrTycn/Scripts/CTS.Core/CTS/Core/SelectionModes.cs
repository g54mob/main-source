using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	[CreateAssetMenu(menuName = "CTS/Selection/Modes Selection")]
	public class SelectionModes : ScriptableObject
	{
		[SerializeField]
		private List<StringKey<SelectionMode>> _selectionModes = new List<StringKey<SelectionMode>>();

		public bool CanBeSelectedBy(StringKey<SelectionMode> selectionMode)
		{
			return _selectionModes.Contains(selectionMode);
		}
	}
}
