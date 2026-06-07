using System.Xml.Linq;
using ModApi.Craft.Program.Craft;
using ModApi.Ui.Inspector;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class ScreenWidgetScript : WidgetScript
	{
		private Image _image;

		public override Vector2 AnchoredPosition
		{
			get
			{
				return Vector2.zero;
			}
			set
			{
			}
		}

		public override Vector2 AnchorMax
		{
			get
			{
				return base.Transform.anchorMax;
			}
			set
			{
			}
		}

		public override Vector2 AnchorMin
		{
			get
			{
				return base.Transform.anchorMin;
			}
			set
			{
			}
		}

		public override Vector2 LocalPosition
		{
			get
			{
				return Vector2.zero;
			}
			set
			{
			}
		}

		public override float LocalRotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override IMfdWidget Parent => null;

		public override Vector2 Scale
		{
			get
			{
				return Vector2.one;
			}
			set
			{
			}
		}

		public override Vector2 Size
		{
			get
			{
				return base.Transform.rect.size;
			}
			set
			{
			}
		}

		protected override Color WidgetColor
		{
			get
			{
				return _image.color;
			}
			set
			{
				_image.color = value;
			}
		}

		public override void Destroy()
		{
		}

		public override void Initialize(MfdScript mfdScript, string name, MfdWidgetType widgetType)
		{
			base.Initialize(mfdScript, name, widgetType);
			_image = GetComponent<Image>();
		}

		public override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
		}

		public override void SetAnchor(ElementAlignment alignment)
		{
		}

		public override void SetParent(IMfdWidget parent, bool worldPositionStays)
		{
		}

		public override void SetWidgetOrder(IMfdWidget target, bool front)
		{
		}

		protected override void SetRaycastTarget(bool enabled)
		{
			base.SetRaycastTarget(enabled);
			_image.raycastTarget = enabled;
		}
	}
}
