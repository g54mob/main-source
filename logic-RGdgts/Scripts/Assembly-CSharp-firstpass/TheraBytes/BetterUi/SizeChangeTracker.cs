using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	public class SizeChangeTracker : UIBehaviour, ILayoutSelfController, ILayoutController
	{
		public RectTransform[] AffectedObjects;

		private bool isInRecursion;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void CallForAffectedObjects(Action<ILayoutChildDependency> function)
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		protected override void OnTransformParentChanged()
		{
		}

		public void SetLayoutHorizontal()
		{
		}

		public void SetLayoutVertical()
		{
		}
	}
}
