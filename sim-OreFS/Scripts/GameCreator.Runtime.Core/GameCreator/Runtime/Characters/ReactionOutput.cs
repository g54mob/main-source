using System;

namespace GameCreator.Runtime.Characters
{
	public readonly struct ReactionOutput
	{
		public static readonly ReactionOutput None;

		[field: NonSerialized]
		public float Length { get; }

		[field: NonSerialized]
		public float Speed { get; }

		[field: NonSerialized]
		public float CancelTime { get; }

		[field: NonSerialized]
		public float Gravity { get; }

		[field: NonSerialized]
		public Reaction Reaction { get; }

		public ReactionOutput(float length, float speed, float cancelTime, float gravity, Reaction reaction)
		{
			Length = length;
			Speed = speed;
			CancelTime = cancelTime;
			Gravity = gravity;
			Reaction = reaction;
		}
	}
}
