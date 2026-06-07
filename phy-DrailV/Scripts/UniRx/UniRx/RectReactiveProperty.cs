using System;
using System.Collections.Generic;
using UniRx.InternalUtil;
using UnityEngine;

namespace UniRx
{
	[Serializable]
	public class RectReactiveProperty : ReactiveProperty<Rect>
	{
		protected override IEqualityComparer<Rect> EqualityComparer => UnityEqualityComparer.Rect;

		public RectReactiveProperty()
		{
		}

		public RectReactiveProperty(Rect initialValue)
			: base(initialValue)
		{
		}
	}
}
