using System;
using UnityEngine;

namespace Restory.UserInterface
{
	public abstract class GUI_InteractionModalBase : GUI_ScreenObjectBase
	{
		public Transform ActorTransform { get; protected set; }

		public event Action OnInitialized = delegate
		{
		};

		public virtual void Initialize(GameObject model, GameObject actor)
		{
			Model = ((model != null) ? model.transform : null);
			ActorTransform = ((actor != null) ? actor.transform : null);
			if (base.WindowRectTransform == null)
			{
				base.WindowRectTransform = base.RectTransform;
			}
			base.IsOpen = false;
			base.WindowRectTransform.localScale = Vector3.zero;
			this.OnInitialized();
		}

		public override void Clean()
		{
			ActorTransform = null;
			base.Clean();
		}
	}
}
