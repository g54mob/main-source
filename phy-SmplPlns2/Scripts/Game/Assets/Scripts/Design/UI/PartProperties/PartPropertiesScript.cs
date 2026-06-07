using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public abstract class PartPropertiesScript : MonoBehaviour
	{
		public DesignerScript Designer { get; set; }

		public virtual int PanelOrder => 10;

		public abstract void OnPartDeselected(PartScript part);

		public abstract bool OnPartSelected(PartScript part, PartModifierScript modifierScript);

		public virtual void OnPropertiesClosed()
		{
		}

		public virtual void OnPropertiesOpened()
		{
		}
	}
}
