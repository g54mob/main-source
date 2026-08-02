using System;
using UnityEngine;

namespace Rowlan.Yapp
{
	[Serializable]
	public class InteractionSettings
	{
		public enum InteractionType
		{
			AntiGravity = 0,
			Magnet = 1,
			ChangeScale = 2,
			SetScale = 3
		}

		[Serializable]
		public class AntiGravity
		{
			[Range(0f, 100f)]
			public int strength = 30;
		}

		[Serializable]
		public class Magnet
		{
			[Range(0f, 100f)]
			public int strength = 10;
		}

		[Serializable]
		public class ChangeScale
		{
			[Range(0f, 100f)]
			public float changeScaleStrength = 10f;
		}

		[Serializable]
		public class SetScale
		{
			[Range(0f, 10f)]
			public float setScaleValue = 1f;
		}

		public InteractionType interactionType;

		public AntiGravity antiGravity = new AntiGravity();

		public Magnet magnet = new Magnet();

		public ChangeScale changeScale = new ChangeScale();

		public SetScale setScale = new SetScale();
	}
}
