using System;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using UnityEngine;

namespace ModApi.Design.PartProperties
{
	public abstract class PartPropertiesScript : MonoBehaviour
	{
		private bool _initialized;

		public DesignerPartModifierAttribute DesignerAttribute { get; private set; }

		public IPartPropertiesFlyout Flyout { get; private set; }

		public virtual bool HandlesMultipleModifiers => false;

		public bool IsVisible => base.gameObject.activeInHierarchy;

		public int ModifierIndex { get; private set; }

		public Type ModifierType { get; private set; }

		public int PanelOrder { get; protected set; }

		protected IDesigner Designer { get; private set; }

		public void Initialize(IDesigner designer, IPartPropertiesFlyout flyout, Type modifierType, int modifierIndex, DesignerPartModifierAttribute attribute)
		{
			if (!_initialized)
			{
				_initialized = true;
				Designer = designer;
				Flyout = flyout;
				ModifierType = modifierType;
				ModifierIndex = modifierIndex;
				DesignerAttribute = attribute;
				PanelOrder = ((DesignerAttribute == null) ? 1000 : DesignerAttribute.PanelOrder);
				OnInitialized();
			}
		}

		public virtual void OnPartDeselected(IPartScript part)
		{
		}

		public abstract bool OnPartSelected(IPartScript part);

		public virtual void OnPropertiesClosed()
		{
		}

		public virtual void OnPropertiesOpened()
		{
		}

		public virtual void SetVisible(bool visible)
		{
			base.gameObject.SetActive(visible);
		}

		protected virtual void OnInitialized()
		{
		}
	}
}
