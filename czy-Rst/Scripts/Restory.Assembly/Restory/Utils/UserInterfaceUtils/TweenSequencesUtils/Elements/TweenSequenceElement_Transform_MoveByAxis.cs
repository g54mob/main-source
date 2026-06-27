using System;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public abstract class TweenSequenceElement_Transform_MoveByAxis : TweenSequenceElement_Transform_MoveBase
	{
		[SerializeField]
		protected float targetCoordinateValue;
	}
}
