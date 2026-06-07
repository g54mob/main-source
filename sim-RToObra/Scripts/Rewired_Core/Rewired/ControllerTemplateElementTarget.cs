using System;

namespace Rewired
{
	public struct ControllerTemplateElementTarget
	{
		private IControllerTemplateElement uLXtOJWFVkSakMKrKISOhGpQNHo;

		private AxisRange ObWitXNhWFZMnOJBWvYTcBBfVnG;

		public AxisRange axisRange
		{
			get
			{
				return ObWitXNhWFZMnOJBWvYTcBBfVnG;
			}
			set
			{
				ObWitXNhWFZMnOJBWvYTcBBfVnG = value;
			}
		}

		public ControllerTemplateElementType elementType
		{
			get
			{
				if (uLXtOJWFVkSakMKrKISOhGpQNHo == null)
				{
					return ControllerTemplateElementType.Axis;
				}
				return uLXtOJWFVkSakMKrKISOhGpQNHo.type;
			}
		}

		public string descriptiveName
		{
			get
			{
				if (uLXtOJWFVkSakMKrKISOhGpQNHo == null)
				{
					return string.Empty;
				}
				switch (uLXtOJWFVkSakMKrKISOhGpQNHo.type)
				{
				case ControllerTemplateElementType.Axis:
					return ((IControllerTemplateAxis)uLXtOJWFVkSakMKrKISOhGpQNHo).GetDescriptiveName(ObWitXNhWFZMnOJBWvYTcBBfVnG);
				case ControllerTemplateElementType.Button:
					return ((IControllerTemplateButton)uLXtOJWFVkSakMKrKISOhGpQNHo).descriptiveName;
				default:
					return uLXtOJWFVkSakMKrKISOhGpQNHo.descriptiveName;
				}
			}
		}

		public IControllerTemplateElement element
		{
			get
			{
				return uLXtOJWFVkSakMKrKISOhGpQNHo;
			}
			set
			{
				uLXtOJWFVkSakMKrKISOhGpQNHo = value;
			}
		}

		public IControllerTemplate template
		{
			get
			{
				if (uLXtOJWFVkSakMKrKISOhGpQNHo == null)
				{
					return null;
				}
				return (uLXtOJWFVkSakMKrKISOhGpQNHo as IControllerTemplateElement_Internal).parent;
			}
		}

		public bool hasTarget
		{
			get
			{
				return uLXtOJWFVkSakMKrKISOhGpQNHo != null;
			}
		}

		internal ControllerTemplateElementTarget(IControllerTemplateElement element, AxisRange axisRange)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			uLXtOJWFVkSakMKrKISOhGpQNHo = element;
			ObWitXNhWFZMnOJBWvYTcBBfVnG = axisRange;
		}

		public ControllerTemplateElementTarget(ControllerTemplateElementTarget other)
		{
			uLXtOJWFVkSakMKrKISOhGpQNHo = other.uLXtOJWFVkSakMKrKISOhGpQNHo;
			ObWitXNhWFZMnOJBWvYTcBBfVnG = other.ObWitXNhWFZMnOJBWvYTcBBfVnG;
		}
	}
}
