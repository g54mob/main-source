using UnityEngine;

namespace MateoRyhr
{
	public class Vector2Input : BasicInput, IVector2
	{
		public Vector2 Value => _actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].ReadValue<Vector2>();
	}
}
