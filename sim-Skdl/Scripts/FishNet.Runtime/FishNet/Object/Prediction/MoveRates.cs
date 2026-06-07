using System.Runtime.CompilerServices;

namespace FishNet.Object.Prediction
{
	internal struct MoveRates
	{
		public float Position;

		public float Rotation;

		public float Scale;

		public const float UNSET_VALUE = float.NegativeInfinity;

		public const float INSTANT_VALUE = float.PositiveInfinity;

		public bool PositionSet => false;

		public bool RotationSet => false;

		public bool ScaleSet => false;

		public bool AnySet => false;

		public bool InstantPosition => false;

		public bool InstantRotation => false;

		public bool InstantScale => false;

		public MoveRates(float value)
		{
			Position = 0f;
			Rotation = 0f;
			Scale = 0f;
		}

		public MoveRates(float position, float rotation)
		{
			Position = 0f;
			Rotation = 0f;
			Scale = 0f;
		}

		public MoveRates(float position, float rotation, float scale)
		{
			Position = 0f;
			Rotation = 0f;
			Scale = 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetInstantRates()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Update(float value)
		{
		}

		public void Update(float position, float rotation, float scale)
		{
		}
	}
}
