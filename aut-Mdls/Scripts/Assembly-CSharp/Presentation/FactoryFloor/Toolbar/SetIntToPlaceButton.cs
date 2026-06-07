using System;
using Events.Generic;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public class SetIntToPlaceButton : ToolBarButton
	{
		[SerializeField]
		private IntEvent _placementToolButtonPressedEvent;

		[SerializeField]
		private int _id;

		public override bool IsSelected
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override string BreadcrumbId
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		protected override void ButtonPressed()
		{
			_placementToolButtonPressedEvent.Fire(_id);
			base.ButtonPressed();
		}
	}
}
