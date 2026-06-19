using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InWorldMenuObject : InWorldMenuBase
	{
		protected ICursorSelectable _objectSelected;

		public ICursorSelectable ObjectSelected => _objectSelected;

		protected virtual void Setup(ICursorSelectable objectSelected, Level level)
		{
			_objectSelected = objectSelected;
			_objectSelected.SetActiveMenu(this);
			base.Setup(level);
		}

		protected override Vector3 GetMenuPosition()
		{
			if (_objectSelected == null)
			{
				return Vector3.zero;
			}
			return _objectSelected.GetMenuAnchorPosition() + Vector3.up * _menuYOffset;
		}

		public override void CloseMenu()
		{
			_objectSelected.SetActiveMenu(null);
			base.CloseMenu();
		}
	}
}
