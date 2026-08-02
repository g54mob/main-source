using System;
using UnityEngine;

namespace HQFPSTemplate.UserInterface
{
	[CreateAssetMenu(menuName = "HQ FPS Template/User Interface/Crosshair")]
	public class UI_CrosshairInfo : ScriptableObject
	{
		[Serializable]
		public struct CrosshairGfxSettings
		{
			public Color NormalColor;

			public Color OnEntityColor;

			public Color UnusableColor;

			[Space]
			public bool ShowWhenAiming;

			public float PivotRotation;

			[Group]
			public SpriteSetup LeftSprite;

			[Group]
			public SpriteSetup RightSprite;

			[Group]
			public SpriteSetup CenterSprite;

			[Group]
			public SpriteSetup TopSprite;

			[Group]
			public SpriteSetup BottomSprite;
		}

		[Serializable]
		public struct SpriteSetup
		{
			public Sprite Sprite;

			public Vector2 Size;
		}

		[Serializable]
		public struct CrosshairScaleSettings
		{
			[Group]
			public UI_Spring.Data ScaleSpringData;

			[Group]
			public UI_SpringForce ItemUseScaleForce;

			[Range(0f, 5f)]
			public float ScaleMultiplier;

			[Range(0f, 5f)]
			public float IdleScale;

			[Range(0f, 5f)]
			public float CrouchScale;

			[Range(0f, 5f)]
			public float ProneScale;

			[Range(0f, 5f)]
			public float WalkScale;

			[Range(0f, 5f)]
			public float RunScale;

			[Range(0f, 5f)]
			public float AirborneMultiplier;

			[Range(0f, 5f)]
			public float AimScaleMultiplier;
		}

		[Group]
		public CrosshairGfxSettings GraphicsInfo;

		[Group]
		public CrosshairScaleSettings ScaleInfo;
	}
}
