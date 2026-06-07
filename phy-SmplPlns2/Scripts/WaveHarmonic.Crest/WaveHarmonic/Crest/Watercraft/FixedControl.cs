using UnityEngine;

namespace WaveHarmonic.Crest.Watercraft
{
	[AddComponentMenu("Crest/Physics/Crest Watercraft Control (Constant)")]
	public sealed class FixedControl : Control
	{
		[Tooltip("Constantly move.")]
		[SerializeField]
		private float _Move;

		[Tooltip("Constantly turn.")]
		[SerializeField]
		private float _Turn;

		public float Move
		{
			get
			{
				return _Move;
			}
			set
			{
				_Move = value;
			}
		}

		public float Turn
		{
			get
			{
				return _Turn;
			}
			set
			{
				_Turn = value;
			}
		}

		public override Vector3 Input
		{
			get
			{
				if (!base.isActiveAndEnabled)
				{
					return Vector3.zero;
				}
				return new Vector3(_Turn, 0f, _Move);
			}
		}
	}
}
