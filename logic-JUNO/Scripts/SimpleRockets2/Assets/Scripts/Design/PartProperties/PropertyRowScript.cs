using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design.PartProperties
{
	public class PropertyRowScript : MonoBehaviour
	{
		private bool _collapsed;

		private bool _visible = true;

		public bool Collapsed
		{
			get
			{
				return _collapsed;
			}
			set
			{
				_collapsed = value;
				UpdateVisibility();
			}
		}

		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				_visible = value;
				UpdateVisibility();
			}
		}

		public void SetTooltip(string tooltip)
		{
			GetComponent<XmlElement>().Tooltip = tooltip;
		}

		private void UpdateVisibility()
		{
			base.gameObject.SetActive(!Collapsed && Visible);
		}
	}
}
