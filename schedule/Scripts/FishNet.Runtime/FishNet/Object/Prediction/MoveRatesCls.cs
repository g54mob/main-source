using System.Runtime.CompilerServices;
using GameKit.Utilities;

namespace FishNet.Object.Prediction
{
	internal class MoveRatesCls : IResettable
	{
		public float Position;

		public float Rotation;

		public float Scale;

		public const float UNSET_VALUE = float.NegativeInfinity;

		public const float INSTANT_VALUE = float.PositiveInfinity;

		public float LastMultiplier { get; private set; }

		public bool PositionSet => false;

		public bool RotationSet => false;

		public bool ScaleSet => false;

		public bool AnySet => false;

		public bool InstantPosition => false;

		public bool InstantRotation => false;

		public bool InstantScale => false;

		public MoveRatesCls(float value)
		{
		}

		public MoveRatesCls(float position, float rotation)
		{
		}

		public MoveRatesCls(float position, float rotation, float scale)
		{
		}

		public MoveRatesCls()
		{
		}

		public void Multiply(float value)
		{
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Update(MoveRatesCls mr)
		{
		}

		public void ResetState()
		{
		}

		public void InitializeState()
		{
		}
	}
}
