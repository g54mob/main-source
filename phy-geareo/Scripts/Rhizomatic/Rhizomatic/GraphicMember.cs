using Rhizomatic.MemberBinding;
using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic
{
	public class GraphicMember : GraphicMember<Graphic>
	{
	}
	public class GraphicMember<T> : Member<T> where T : Graphic
	{
		public Color color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public float hue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float saturation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float colorValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float alpha
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private float GetHSV(byte index)
		{
			return 0f;
		}

		private void SetHSV(byte index, float value)
		{
		}
	}
}
