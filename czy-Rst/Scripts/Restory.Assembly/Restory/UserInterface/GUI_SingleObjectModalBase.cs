using System;
using UnityEngine;

namespace Restory.UserInterface
{
	public abstract class GUI_SingleObjectModalBase : GUI_ScreenObjectBase
	{
		public event Action OnInitializationDone;

		public virtual void Initialize(GameObject model)
		{
			Model = ((model != null) ? model.transform : null);
			if (base.WindowRectTransform == null)
			{
				base.WindowRectTransform = base.RectTransform;
			}
			base.IsOpen = false;
			base.WindowRectTransform.localScale = Vector3.zero;
			Customize(model);
			this.OnInitializationDone?.Invoke();
		}

		protected void Customize(GameObject model)
		{
		}
	}
}
