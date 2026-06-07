using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal readonly struct Cascade
	{
		public readonly Vector2 _SnappedPosition;

		public readonly float _Texel;

		public readonly int _Resolution;

		public Vector4 Packed => new Vector4(_SnappedPosition.x, _SnappedPosition.y, _Texel, 0f);

		public Rect TexelRect
		{
			get
			{
				float num = _Texel * (float)_Resolution;
				return new Rect(_SnappedPosition.x - num / 2f, _SnappedPosition.y - num / 2f, num, num);
			}
		}

		public Cascade(Vector2 snapped, float texel, int resolution)
		{
			_SnappedPosition = snapped;
			_Texel = texel;
			_Resolution = resolution;
		}
	}
}
