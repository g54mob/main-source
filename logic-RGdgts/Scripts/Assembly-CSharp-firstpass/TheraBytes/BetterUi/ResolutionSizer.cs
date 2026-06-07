using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public abstract class ResolutionSizer<T> : UIBehaviour, ILayoutController, ILayoutSelfController, IResolutionDependency
	{
		protected abstract ScreenDependentSize<T> sizer { get; }

		public virtual void SetLayoutHorizontal()
		{
		}

		public virtual void SetLayoutVertical()
		{
		}

		protected override void OnEnable()
		{
		}

		protected void SetDirty()
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		private void UpdateSize()
		{
		}

		protected abstract void ApplySize(T newSize);

		public void OnResolutionChanged()
		{
		}
	}
}
