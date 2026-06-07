using System;
using UnityEngine;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class ColorProperty
	{
		private float _alpha = 1f;

		private Color _color;

		private float _multiply = 1f;

		private Action<Color> _setter;

		public float Alpha
		{
			get
			{
				return _alpha;
			}
			set
			{
				_alpha = value;
				UpdateColor();
			}
		}

		public Color Base
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
				UpdateColor();
			}
		}

		public float Multiply
		{
			get
			{
				return _multiply;
			}
			set
			{
				_multiply = value;
				UpdateColor();
			}
		}

		public ColorProperty(Color startColor, Action<Color> setter)
		{
			_setter = setter;
		}

		private void UpdateColor()
		{
			Color obj = Base;
			obj.r *= Multiply;
			obj.g *= Multiply;
			obj.b *= Multiply;
			obj.a *= Alpha;
			_setter(obj);
		}
	}
}
