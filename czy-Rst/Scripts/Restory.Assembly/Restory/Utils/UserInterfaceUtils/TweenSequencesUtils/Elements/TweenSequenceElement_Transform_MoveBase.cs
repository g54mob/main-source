using System;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public abstract class TweenSequenceElement_Transform_MoveBase : TweenSequenceElement_Tween
	{
		protected static class TransformMoveStyle
		{
			public const string TransformMoveSettings = "Transform Movement Settings";
		}

		[SerializeField]
		protected Transform transformToMove;
	}
}
