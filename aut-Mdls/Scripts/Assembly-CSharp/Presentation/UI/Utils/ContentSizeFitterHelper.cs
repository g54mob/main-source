using System;
using UnityEngine.EventSystems;

namespace Presentation.UI.Utils
{
	public class ContentSizeFitterHelper : UIBehaviour
	{
		public event Action OnSizeFitterUpdated;

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			this.OnSizeFitterUpdated();
		}
	}
}
