using System;
using UnityEngine;

namespace HQFPSTemplate
{
	[Serializable]
	public class StaminaSettings
	{
		[Range(0.01f, 100f)]
		public float InitialValue = 100f;

		[Range(0.01f, 20f)]
		public float DepletionSpeed = 12f;

		[Range(0.01f, 100f)]
		public float JumpStaminaTake = 10f;

		[Range(0.5f, 10f)]
		public float RegenPause = 3f;

		[Range(1f, 100f)]
		public float RegenSpeed = 25f;
	}
}
