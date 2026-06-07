using UnityEngine;

namespace OutlineFx
{
	[ExecuteAlways]
	public class OutlineFx : Outline
	{
		public Color _color = Color.white;

		public override Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		public float Alpha
		{
			get
			{
				return _color.a;
			}
			set
			{
				_color.a = value;
			}
		}
	}
}
