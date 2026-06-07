using System;
using UnityEngine;

namespace EngineCore
{
	[Serializable]
	public class GlobalFogDefinition
	{
		[Header("General")]
		[Tooltip("If enabled, the linear color values will be passed on to the PP shader. This will ensure that what we see on screen matches the colors exactly as selected. Not that this will not effect the colors directly but only the setting in the post processing effect.")]
		public bool EnableFogColorGammaCorrection = true;

		[Tooltip("Blend between a single color combined fog mask and a multi color composited fog mask. If set to 0, the FogColor that is specified in the distance fog settings will be used.\n If set to 1, each fog type will use it's own color. Blending order: HeightFog , Custom HeightFog, Distance Fog .\n\nIn case UseSceneFogSettings is enabled in the current active fog all fog colors will be ignored and the lighting fog settings will be used instead.")]
		[Range(0f, 1f)]
		public float FogColorCompositionPercentage;

		[Tooltip("Exclude far plane pixels from distance-based fog? (Skybox or clear color)")]
		public bool ExcludeFarPixels;

		[Tooltip("Push fog away from the camera by this amount.If the player position is used for the calculations of a specific fog, the start distance will be pushed away from the player position instead")]
		public float StartDistance;

		[Tooltip("The min overall fog intensity that is allowed")]
		[Range(0f, 1f)]
		public float MinFogClamp;

		[Tooltip("The max overall fog intensity that is allowed")]
		[Range(0f, 1f)]
		public float MaxFogClamp = 1f;

		[Header("HDR")]
		[Tooltip("How much should the HDR emissiveness bleed through the fog.")]
		[Range(0f, 1f)]
		public float HDRPunchThrough;

		[Tooltip("At what intensity value should the HDR punchtrough start?")]
		public float HDRPunchThroughThreshold = 2f;

		[Header("______________________________________________________________________________________")]
		[Header("Standard Fog")]
		[Tooltip("If true, then all fog definition colors will be ignored and the fog settings from the lighting settings will be used.\nNote that this mode will also be able to influence the colors and affected settings in the source definitionwhen blending between this source definition and another definition directly using the BlendTo Function.\nIf you do not want the blend to affect the source use an additional result definition to store the results in -> ResultDefinition.BlendTo(targetDefinition, blendpercentage, setboolsandmodes,sourceDefinition)\n\nThe CopyTo Function will not have this problem and copy over the entire definition as is leaving the colors and affected variables intact.")]
		public bool UseSceneFogSettings;

		[SerializeField]
		protected EFogMode _fogMode;

		[ConditionalEnumHide("_fogMode", 1, false, EnumValue2 = 2)]
		[SerializeField]
		protected float _fogDensity = 0.05f;

		[ConditionalEnumHide("_fogMode", 0, false)]
		[SerializeField]
		protected float _fogStartDistance;

		[ConditionalEnumHide("_fogMode", 0, false)]
		[SerializeField]
		protected float _fogEndDistance = 100f;

		[Header("======================================================================================")]
		[Header("Standard Fog - Distance fog")]
		[Tooltip("Apply distance-based fog?")]
		public bool DistanceFog = true;

		[Tooltip("The color used by the distance based fog and for all other colors in case the FogCompositionPercentage == 0")]
		[ColorUsage(true, true)]
		[SerializeField]
		protected Color _fogColor = Color.white;

		[Tooltip("How do we want to calculate the distance fog? Depth =  linear fog in camera direction, Radial =  linear fog from the camera in a radius.\nPlayerPositionDepth =  same a radial be we can decide if the falloff should be from the camera position or from the player position. This intensity can be controlled by PlayerPositionDistanceInfluence.")]
		public EFogCalculationMode DistanceFogCalculationMode;

		[Tooltip("The amount of distance fog allowed (0 =  no fog, 1 = distance fog fully enabled)")]
		[Range(0f, 1f)]
		public float DistanceFogIntensity;

		[Tooltip("If the DistanceFogCalculationMode ==  PlayerPositionDepth , then we can control how much the player position will influence the falloff")]
		[Range(0f, 1f)]
		public float PlayerPositionDistanceInfluence;

		[Header("Standard Fog - Distance Fog Noise")]
		[Range(-1f, 1f)]
		public float DistanceFogNoiseInfluence;

		public float DistanceFogNoiseScale = 4f;

		public float DistanceFogNoisePower = 0.75f;

		[Range(-1f, 1f)]
		public float DistanceFogCenterOffset;

		public float DistanceFogNoiseOffsetScale = 20f;

		public Vector3 DistanceFogNoiseDirection = new Vector3(1f, 1f, 1f);

		public float DistanceFogNoiseSpeed = 1f;

		[Header("======================================================================================")]
		[Header("Standard Fog - Height")]
		[Tooltip("Apply height-based fog?")]
		public bool HeightFog = true;

		[Tooltip("The color used by the height based fog and when the FogCompositionPercentage == 0")]
		[ColorUsage(true, true)]
		[SerializeField]
		protected Color _heightFogColor = Color.white;

		[Range(0f, 1f)]
		public float HeightFogIntensity;

		[Tooltip("Fog top Y coordinate. The density controls the fog density. This results in a different look than the custom height fog and allows for a light surface visual pierce through depending on angle and distances from a curface in relation to the density.")]
		public float Height = 1f;

		[Range(0.001f, 500f)]
		public float HeightDensity = 2f;

		[Space(10f)]
		[Tooltip("Should the standard heightfog falloff mask be calculated based on the player position or on the camera position. This also influences how the general start distance is applied.")]
		[Range(0f, 1f)]
		public float PlayerPositionHeightInfluence;

		[Tooltip("The range over which the standard height fog is faded in around the reference position (either playerpos or camera pos depending on PlayerPositionCustomHeightInfluence. 0 = no fade mask\n\nIMPORTANT NOTE: Because the standard height fog uses density instead of a linear height control as implemented by the custom height fog combined with the shared standard fog settings it can be harder to control how the falloff mask is applied. Increase the mask power to better see the falloff or increase the mask radius to a higher value untill a visual pleasing falloff is achieved.")]
		public float HeightMaskRadius = 15f;

		[Range(0f, 1f)]
		public float HeightMaskLowerClamp;

		public float HeightMaskPower = 1f;

		[Header("Standard Fog - Height Fog Noise")]
		[Range(-1f, 1f)]
		public float HeightFogNoiseInfluence;

		public float HeightFogNoiseScale = 4f;

		public float HeightFogNoisePower = 1f;

		[Range(-1f, 1f)]
		public float HeightFogCenterOffset;

		public float HeightFogNoiseOffsetScale = 1f;

		public Vector3 HeightFogNoiseDirection = new Vector3(1f, 1f, 1f);

		public float HeightFogNoiseSpeed = 1f;

		[Header("______________________________________________________________________________________")]
		[Header("Custom Linear Height Fog")]
		public bool CustomHeightFog = true;

		[Tooltip("The color used by the custom height based fog and when the FogCompositionPercentage == 0")]
		[ColorUsage(true, true)]
		[SerializeField]
		protected Color _customHeightFogColor = Color.white;

		[Range(0f, 1f)]
		public float CustomHeightFogIntensity;

		public float CustomHeightFogTopHeight = 5f;

		public float CustomHeightFogBottomHeight;

		public float CustomHeightFogFallofPower = 2f;

		[Space(10f)]
		[Tooltip("Should the custom height fog falloff mask be calculated based on the player position or on the camera position. This also influences how the general start distance is applied.")]
		[Range(0f, 1f)]
		public float PlayerPositionCustomHeightInfluence;

		[Tooltip("The range over which the custom height fog is faded in around the reference position (either playerpos or camera pos depending on PlayerPositionCustomHeightInfluence. 0 = no fade mask")]
		public float CustomHeightMaskRadius = 15f;

		[Range(0f, 1f)]
		public float CustomHeightMaskLowerClamp;

		public float CustomHeightMaskPower = 1f;

		[Header("Standard Fog - Height Fog Noise")]
		[Range(-1f, 1f)]
		public float CustomHeightFogNoiseInfluence;

		public float CustomHeightFogNoiseScale = 4f;

		public float CustomHeightFogNoisePower = 1f;

		[Range(-1f, 1f)]
		public float CustomHeightFogCenterOffset;

		public float CustomHeightFogNoiseOffsetScale = 1f;

		public Vector3 CustomHeightFogNoiseDirection = new Vector3(1f, 1f, 1f);

		public float CustomHeightFogNoiseSpeed = 1f;

		public EFogMode FogMode
		{
			get
			{
				if (UseSceneFogSettings)
				{
					return RenderSettings.fogMode switch
					{
						UnityEngine.FogMode.Linear => EFogMode.Linear, 
						UnityEngine.FogMode.Exponential => EFogMode.Exponential, 
						UnityEngine.FogMode.ExponentialSquared => EFogMode.ExponentialSquared, 
						_ => EFogMode.Exponential, 
					};
				}
				return _fogMode;
			}
			set
			{
				_fogMode = value;
			}
		}

		public float FogDensity
		{
			get
			{
				if (UseSceneFogSettings)
				{
					return RenderSettings.fogDensity;
				}
				return _fogDensity;
			}
			set
			{
				_fogDensity = value;
			}
		}

		public float FogStartDistance
		{
			get
			{
				if (UseSceneFogSettings)
				{
					return RenderSettings.fogStartDistance;
				}
				return _fogStartDistance;
			}
			set
			{
				_fogStartDistance = value;
			}
		}

		public float FogEndDistance
		{
			get
			{
				if (UseSceneFogSettings)
				{
					return RenderSettings.fogEndDistance;
				}
				return _fogEndDistance;
			}
			set
			{
				_fogEndDistance = value;
			}
		}

		public Color FogColor
		{
			get
			{
				if (UseSceneFogSettings)
				{
					return RenderSettings.fogColor;
				}
				return _fogColor;
			}
			set
			{
				_fogColor = value;
			}
		}

		public Color HeightFogColor
		{
			get
			{
				if (UseSceneFogSettings)
				{
					return RenderSettings.fogColor;
				}
				return _heightFogColor;
			}
			set
			{
				_heightFogColor = value;
			}
		}

		public Color CustomHeightFogColor
		{
			get
			{
				if (UseSceneFogSettings)
				{
					return RenderSettings.fogColor;
				}
				return _customHeightFogColor;
			}
			set
			{
				_customHeightFogColor = value;
			}
		}

		public void CopyFrom(GlobalFogDefinition source, bool setFlagsAndFogModes = true)
		{
			if (source != null)
			{
				if (setFlagsAndFogModes)
				{
					EnableFogColorGammaCorrection = source.EnableFogColorGammaCorrection;
				}
				FogColorCompositionPercentage = source.FogColorCompositionPercentage;
				if (setFlagsAndFogModes)
				{
					ExcludeFarPixels = source.ExcludeFarPixels;
				}
				StartDistance = source.StartDistance;
				_fogColor = source._fogColor;
				_heightFogColor = source._heightFogColor;
				_customHeightFogColor = source._customHeightFogColor;
				MinFogClamp = source.MinFogClamp;
				MaxFogClamp = source.MaxFogClamp;
				HDRPunchThrough = source.HDRPunchThrough;
				HDRPunchThroughThreshold = source.HDRPunchThroughThreshold;
				if (setFlagsAndFogModes)
				{
					UseSceneFogSettings = source.UseSceneFogSettings;
				}
				if (setFlagsAndFogModes)
				{
					_fogMode = source._fogMode;
				}
				_fogDensity = source._fogDensity;
				_fogStartDistance = source._fogStartDistance;
				_fogEndDistance = source._fogEndDistance;
				if (setFlagsAndFogModes)
				{
					DistanceFog = source.DistanceFog;
				}
				if (setFlagsAndFogModes)
				{
					DistanceFogCalculationMode = source.DistanceFogCalculationMode;
				}
				DistanceFogIntensity = (source.DistanceFog ? source.DistanceFogIntensity : 0f);
				PlayerPositionDistanceInfluence = source.PlayerPositionDistanceInfluence;
				DistanceFogNoiseInfluence = source.DistanceFogNoiseInfluence;
				DistanceFogNoiseScale = source.DistanceFogNoiseScale;
				DistanceFogNoisePower = source.DistanceFogNoisePower;
				DistanceFogCenterOffset = source.DistanceFogCenterOffset;
				DistanceFogNoiseOffsetScale = source.DistanceFogNoiseOffsetScale;
				DistanceFogNoiseDirection = source.DistanceFogNoiseDirection;
				DistanceFogNoiseSpeed = source.DistanceFogNoiseSpeed;
				if (setFlagsAndFogModes)
				{
					HeightFog = source.HeightFog;
				}
				HeightFogIntensity = (source.HeightFog ? source.HeightFogIntensity : 0f);
				Height = source.Height;
				HeightDensity = source.HeightDensity;
				PlayerPositionHeightInfluence = source.PlayerPositionHeightInfluence;
				HeightMaskRadius = source.HeightMaskRadius;
				HeightMaskLowerClamp = source.HeightMaskLowerClamp;
				HeightMaskPower = source.HeightMaskPower;
				HeightFogNoiseInfluence = source.HeightFogNoiseInfluence;
				HeightFogNoiseScale = source.HeightFogNoiseScale;
				HeightFogNoisePower = source.HeightFogNoisePower;
				HeightFogCenterOffset = source.HeightFogCenterOffset;
				HeightFogNoiseOffsetScale = source.HeightFogNoiseOffsetScale;
				HeightFogNoiseDirection = source.HeightFogNoiseDirection;
				HeightFogNoiseSpeed = source.HeightFogNoiseSpeed;
				if (setFlagsAndFogModes)
				{
					CustomHeightFog = source.CustomHeightFog;
				}
				CustomHeightFogIntensity = (source.CustomHeightFog ? source.CustomHeightFogIntensity : 0f);
				CustomHeightFogTopHeight = source.CustomHeightFogTopHeight;
				CustomHeightFogBottomHeight = source.CustomHeightFogBottomHeight;
				CustomHeightFogFallofPower = source.CustomHeightFogFallofPower;
				PlayerPositionCustomHeightInfluence = source.PlayerPositionCustomHeightInfluence;
				CustomHeightMaskRadius = source.CustomHeightMaskRadius;
				CustomHeightMaskLowerClamp = source.CustomHeightMaskLowerClamp;
				CustomHeightMaskPower = source.CustomHeightMaskPower;
				CustomHeightFogNoiseInfluence = source.CustomHeightFogNoiseInfluence;
				CustomHeightFogNoiseScale = source.CustomHeightFogNoiseScale;
				CustomHeightFogNoisePower = source.CustomHeightFogNoisePower;
				CustomHeightFogCenterOffset = source.CustomHeightFogCenterOffset;
				CustomHeightFogNoiseOffsetScale = source.CustomHeightFogNoiseOffsetScale;
				CustomHeightFogNoiseDirection = source.CustomHeightFogNoiseDirection;
				CustomHeightFogNoiseSpeed = source.CustomHeightFogNoiseSpeed;
			}
		}

		public void CopyFromFlagsOnly(GlobalFogDefinition source)
		{
			if (source != null)
			{
				EnableFogColorGammaCorrection = source.EnableFogColorGammaCorrection;
				ExcludeFarPixels = source.ExcludeFarPixels;
				UseSceneFogSettings = source.UseSceneFogSettings;
				_fogMode = source._fogMode;
				DistanceFog = source.DistanceFog;
				DistanceFogCalculationMode = source.DistanceFogCalculationMode;
				HeightFog = source.HeightFog;
				CustomHeightFog = source.CustomHeightFog;
			}
		}

		public void BlendTo(GlobalFogDefinition target, float blendPercentage, bool setFlagsAndFogModes = false, GlobalFogDefinition source = null, bool basicNoiseBlend = false)
		{
			if (source == null)
			{
				source = this;
			}
			if (setFlagsAndFogModes)
			{
				EnableFogColorGammaCorrection = target.EnableFogColorGammaCorrection;
			}
			FogColorCompositionPercentage = Mathf.Lerp(source.FogColorCompositionPercentage, target.FogColorCompositionPercentage, blendPercentage);
			if (setFlagsAndFogModes)
			{
				ExcludeFarPixels = target.ExcludeFarPixels;
			}
			StartDistance = Mathf.Lerp(source.StartDistance, target.StartDistance, blendPercentage);
			MinFogClamp = Mathf.Lerp(source.MinFogClamp, target.MinFogClamp, blendPercentage);
			MaxFogClamp = Mathf.Lerp(source.MaxFogClamp, target.MaxFogClamp, blendPercentage);
			HDRPunchThrough = Mathf.Lerp(source.HDRPunchThrough, target.HDRPunchThrough, blendPercentage);
			HDRPunchThroughThreshold = Mathf.Lerp(source.HDRPunchThroughThreshold, target.HDRPunchThroughThreshold, blendPercentage);
			if (setFlagsAndFogModes)
			{
				UseSceneFogSettings = target.UseSceneFogSettings;
			}
			if (setFlagsAndFogModes)
			{
				FogMode = target.FogMode;
			}
			FogDensity = Mathf.Lerp(source.FogDensity, target.FogDensity, blendPercentage);
			FogStartDistance = Mathf.Lerp(source.FogStartDistance, target.FogStartDistance, blendPercentage);
			FogEndDistance = Mathf.Lerp(source.FogEndDistance, target.FogEndDistance, blendPercentage);
			if (setFlagsAndFogModes)
			{
				DistanceFog = target.DistanceFog;
			}
			if (setFlagsAndFogModes)
			{
				DistanceFogCalculationMode = target.DistanceFogCalculationMode;
			}
			if (!target.DistanceFog || target.DistanceFogIntensity == 0f)
			{
				if ((target.HeightFog || target.CustomHeightFog) && target.FogColorCompositionPercentage != 1f)
				{
					FogColor = Color.Lerp(source.FogColor, target.FogColor, blendPercentage);
				}
				else
				{
					FogColor = source.FogColor;
				}
				DistanceFogIntensity = Mathf.Lerp(source.DistanceFogIntensity, 0f, blendPercentage);
				PlayerPositionDistanceInfluence = source.PlayerPositionDistanceInfluence;
				DistanceFogNoiseInfluence = source.DistanceFogNoiseInfluence;
				DistanceFogNoiseScale = source.DistanceFogNoiseScale;
				DistanceFogNoisePower = source.DistanceFogNoisePower;
				DistanceFogCenterOffset = source.DistanceFogCenterOffset;
				DistanceFogNoiseOffsetScale = source.DistanceFogNoiseOffsetScale;
				DistanceFogNoiseDirection = source.DistanceFogNoiseDirection;
				DistanceFogNoiseSpeed = source.DistanceFogNoiseSpeed;
			}
			else if (target.DistanceFog && target.DistanceFogIntensity != 0f && (!source.DistanceFog || source.DistanceFogIntensity == 0f))
			{
				if ((source.HeightFog || source.CustomHeightFog) && source.FogColorCompositionPercentage != 1f)
				{
					FogColor = Color.Lerp(source.FogColor, target.FogColor, blendPercentage);
				}
				else
				{
					FogColor = target.FogColor;
				}
				DistanceFogIntensity = Mathf.Lerp(0f, target.DistanceFogIntensity, blendPercentage);
				PlayerPositionDistanceInfluence = target.PlayerPositionDistanceInfluence;
				DistanceFogNoiseInfluence = target.DistanceFogNoiseInfluence;
				DistanceFogNoiseScale = target.DistanceFogNoiseScale;
				DistanceFogNoisePower = target.DistanceFogNoisePower;
				DistanceFogCenterOffset = target.DistanceFogCenterOffset;
				DistanceFogNoiseOffsetScale = target.DistanceFogNoiseOffsetScale;
				DistanceFogNoiseDirection = target.DistanceFogNoiseDirection;
				DistanceFogNoiseSpeed = target.DistanceFogNoiseSpeed;
			}
			else
			{
				FogColor = Color.Lerp(source.FogColor, target.FogColor, blendPercentage);
				DistanceFogIntensity = Mathf.Lerp(source.DistanceFogIntensity, target.DistanceFogIntensity, blendPercentage);
				PlayerPositionDistanceInfluence = Mathf.Lerp(source.PlayerPositionDistanceInfluence, target.PlayerPositionDistanceInfluence, blendPercentage);
				if (basicNoiseBlend || source.DistanceFogNoiseScale == target.DistanceFogNoiseScale)
				{
					DistanceFogNoiseInfluence = Mathf.Lerp(source.DistanceFogNoiseInfluence, target.DistanceFogNoiseInfluence, blendPercentage);
					DistanceFogNoiseScale = Mathf.Lerp(source.DistanceFogNoiseScale, target.DistanceFogNoiseScale, blendPercentage);
					DistanceFogNoisePower = Mathf.Lerp(source.DistanceFogNoisePower, target.DistanceFogNoisePower, blendPercentage);
					DistanceFogCenterOffset = Mathf.Lerp(source.DistanceFogCenterOffset, target.DistanceFogCenterOffset, blendPercentage);
					DistanceFogNoiseOffsetScale = Mathf.Lerp(source.DistanceFogNoiseOffsetScale, target.DistanceFogNoiseOffsetScale, blendPercentage);
					DistanceFogNoiseDirection = Vector3.Lerp(source.DistanceFogNoiseDirection, target.DistanceFogNoiseDirection, blendPercentage);
					DistanceFogNoiseSpeed = Mathf.Lerp(source.DistanceFogNoiseSpeed, target.DistanceFogNoiseSpeed, blendPercentage);
				}
				else if (target.DistanceFogNoiseInfluence != 0f)
				{
					if (source.DistanceFogNoiseInfluence != 0f)
					{
						if (blendPercentage < 0.5f)
						{
							DistanceFogNoiseInfluence = Mathf.Lerp(source.DistanceFogNoiseInfluence, 0f, blendPercentage * 2f);
							DistanceFogNoiseScale = source.DistanceFogNoiseScale;
							DistanceFogNoisePower = source.DistanceFogNoisePower;
							DistanceFogCenterOffset = source.DistanceFogCenterOffset;
							DistanceFogNoiseOffsetScale = source.DistanceFogNoiseOffsetScale;
							DistanceFogNoiseDirection = source.DistanceFogNoiseDirection;
							DistanceFogNoiseSpeed = source.DistanceFogNoiseSpeed;
						}
						else
						{
							DistanceFogNoiseInfluence = Mathf.Lerp(0f, target.DistanceFogNoiseInfluence, blendPercentage * 2f - 1f);
							DistanceFogNoiseScale = target.DistanceFogNoiseScale;
							DistanceFogNoisePower = target.DistanceFogNoisePower;
							DistanceFogCenterOffset = target.DistanceFogCenterOffset;
							DistanceFogNoiseOffsetScale = target.DistanceFogNoiseOffsetScale;
							DistanceFogNoiseDirection = target.DistanceFogNoiseDirection;
							DistanceFogNoiseSpeed = target.DistanceFogNoiseSpeed;
						}
					}
					else
					{
						DistanceFogNoiseInfluence = Mathf.Lerp(source.DistanceFogNoiseInfluence, target.DistanceFogNoiseInfluence, blendPercentage);
						DistanceFogNoiseScale = target.DistanceFogNoiseScale;
						DistanceFogNoisePower = target.DistanceFogNoisePower;
						DistanceFogCenterOffset = target.DistanceFogCenterOffset;
						DistanceFogNoiseOffsetScale = target.DistanceFogNoiseOffsetScale;
						DistanceFogNoiseDirection = target.DistanceFogNoiseDirection;
						DistanceFogNoiseSpeed = target.DistanceFogNoiseSpeed;
					}
				}
				else
				{
					DistanceFogNoiseInfluence = Mathf.Lerp(source.DistanceFogNoiseInfluence, target.DistanceFogNoiseInfluence, blendPercentage);
					DistanceFogNoiseScale = source.DistanceFogNoiseScale;
					DistanceFogNoisePower = source.DistanceFogNoisePower;
					DistanceFogCenterOffset = source.DistanceFogCenterOffset;
					DistanceFogNoiseOffsetScale = source.DistanceFogNoiseOffsetScale;
					DistanceFogNoiseDirection = source.DistanceFogNoiseDirection;
					DistanceFogNoiseSpeed = source.DistanceFogNoiseSpeed;
				}
			}
			if (setFlagsAndFogModes)
			{
				HeightFog = target.HeightFog;
			}
			if (!target.HeightFog || target.HeightFogIntensity == 0f)
			{
				HeightFogColor = source.HeightFogColor;
				HeightFogIntensity = Mathf.Lerp(source.HeightFogIntensity, 0f, blendPercentage);
				Height = source.Height;
				HeightDensity = source.HeightDensity;
				PlayerPositionHeightInfluence = source.PlayerPositionHeightInfluence;
				HeightMaskRadius = source.HeightMaskRadius;
				HeightMaskLowerClamp = source.HeightMaskLowerClamp;
				HeightMaskPower = source.HeightMaskPower;
				HeightFogNoiseInfluence = source.HeightFogNoiseInfluence;
				HeightFogNoiseScale = source.HeightFogNoiseScale;
				HeightFogNoisePower = source.HeightFogNoisePower;
				HeightFogCenterOffset = source.HeightFogCenterOffset;
				HeightFogNoiseOffsetScale = source.HeightFogNoiseOffsetScale;
				HeightFogNoiseDirection = source.HeightFogNoiseDirection;
				HeightFogNoiseSpeed = source.HeightFogNoiseSpeed;
			}
			else if (target.HeightFog && target.HeightFogIntensity != 0f && (!source.HeightFog || source.HeightFogIntensity == 0f))
			{
				HeightFogColor = target.HeightFogColor;
				HeightFogIntensity = Mathf.Lerp(0f, target.HeightFogIntensity, blendPercentage);
				Height = target.Height;
				HeightDensity = target.HeightDensity;
				PlayerPositionHeightInfluence = target.PlayerPositionHeightInfluence;
				HeightMaskRadius = target.HeightMaskRadius;
				HeightMaskLowerClamp = target.HeightMaskLowerClamp;
				HeightMaskPower = target.HeightMaskPower;
				HeightFogNoiseInfluence = target.HeightFogNoiseInfluence;
				HeightFogNoiseScale = target.HeightFogNoiseScale;
				HeightFogNoisePower = target.HeightFogNoisePower;
				HeightFogCenterOffset = target.HeightFogCenterOffset;
				HeightFogNoiseOffsetScale = target.HeightFogNoiseOffsetScale;
				HeightFogNoiseDirection = target.HeightFogNoiseDirection;
				HeightFogNoiseSpeed = target.HeightFogNoiseSpeed;
			}
			else
			{
				HeightFogColor = Color.Lerp(source.HeightFogColor, target.HeightFogColor, blendPercentage);
				HeightFogIntensity = Mathf.Lerp(source.HeightFogIntensity, target.HeightFogIntensity, blendPercentage);
				Height = Mathf.Lerp(source.Height, target.Height, blendPercentage);
				HeightDensity = Mathf.Lerp(source.HeightDensity, target.HeightDensity, blendPercentage);
				PlayerPositionHeightInfluence = Mathf.Lerp(source.PlayerPositionHeightInfluence, target.PlayerPositionHeightInfluence, blendPercentage);
				HeightMaskRadius = Mathf.Lerp(source.HeightMaskRadius, target.HeightMaskRadius, blendPercentage);
				HeightMaskLowerClamp = Mathf.Lerp(source.HeightMaskLowerClamp, target.HeightMaskLowerClamp, blendPercentage);
				HeightMaskPower = Mathf.Lerp(source.HeightMaskPower, target.HeightMaskPower, blendPercentage);
				if (basicNoiseBlend || source.HeightFogNoiseScale == target.HeightFogNoiseScale)
				{
					HeightFogNoiseInfluence = Mathf.Lerp(source.HeightFogNoiseInfluence, target.HeightFogNoiseInfluence, blendPercentage);
					HeightFogNoiseScale = Mathf.Lerp(source.HeightFogNoiseScale, target.HeightFogNoiseScale, blendPercentage);
					HeightFogNoisePower = Mathf.Lerp(source.HeightFogNoisePower, target.HeightFogNoisePower, blendPercentage);
					HeightFogCenterOffset = Mathf.Lerp(source.HeightFogCenterOffset, target.HeightFogCenterOffset, blendPercentage);
					HeightFogNoiseOffsetScale = Mathf.Lerp(source.HeightFogNoiseOffsetScale, target.HeightFogNoiseOffsetScale, blendPercentage);
					HeightFogNoiseDirection = Vector3.Lerp(source.HeightFogNoiseDirection, target.HeightFogNoiseDirection, blendPercentage);
					HeightFogNoiseSpeed = Mathf.Lerp(source.HeightFogNoiseSpeed, target.HeightFogNoiseSpeed, blendPercentage);
				}
				else if (target.HeightFogNoiseInfluence != 0f)
				{
					if (source.HeightFogNoiseInfluence != 0f)
					{
						if (blendPercentage < 0.5f)
						{
							HeightFogNoiseInfluence = Mathf.Lerp(source.HeightFogNoiseInfluence, 0f, blendPercentage * 2f);
							HeightFogNoiseScale = source.HeightFogNoiseScale;
							HeightFogNoisePower = source.HeightFogNoisePower;
							HeightFogCenterOffset = source.HeightFogCenterOffset;
							HeightFogNoiseOffsetScale = source.HeightFogNoiseOffsetScale;
							HeightFogNoiseDirection = source.HeightFogNoiseDirection;
							HeightFogNoiseSpeed = source.HeightFogNoiseSpeed;
						}
						else
						{
							HeightFogNoiseInfluence = Mathf.Lerp(0f, target.HeightFogNoiseInfluence, blendPercentage * 2f - 1f);
							HeightFogNoiseScale = target.HeightFogNoiseScale;
							HeightFogNoisePower = target.HeightFogNoisePower;
							HeightFogCenterOffset = target.HeightFogCenterOffset;
							HeightFogNoiseOffsetScale = target.HeightFogNoiseOffsetScale;
							HeightFogNoiseDirection = target.HeightFogNoiseDirection;
							HeightFogNoiseSpeed = target.HeightFogNoiseSpeed;
						}
					}
					else
					{
						HeightFogNoiseInfluence = Mathf.Lerp(source.HeightFogNoiseInfluence, target.HeightFogNoiseInfluence, blendPercentage);
						HeightFogNoiseScale = target.HeightFogNoiseScale;
						HeightFogNoisePower = target.HeightFogNoisePower;
						HeightFogCenterOffset = target.HeightFogCenterOffset;
						HeightFogNoiseOffsetScale = target.HeightFogNoiseOffsetScale;
						HeightFogNoiseDirection = target.HeightFogNoiseDirection;
						HeightFogNoiseSpeed = target.HeightFogNoiseSpeed;
					}
				}
				else
				{
					HeightFogNoiseInfluence = Mathf.Lerp(source.HeightFogNoiseInfluence, target.HeightFogNoiseInfluence, blendPercentage);
					HeightFogNoiseScale = source.HeightFogNoiseScale;
					HeightFogNoisePower = source.HeightFogNoisePower;
					HeightFogCenterOffset = source.HeightFogCenterOffset;
					HeightFogNoiseOffsetScale = source.HeightFogNoiseOffsetScale;
					HeightFogNoiseDirection = source.HeightFogNoiseDirection;
					HeightFogNoiseSpeed = source.HeightFogNoiseSpeed;
				}
			}
			if (setFlagsAndFogModes)
			{
				CustomHeightFog = target.CustomHeightFog;
			}
			if (!target.CustomHeightFog || target.CustomHeightFogIntensity == 0f)
			{
				CustomHeightFogColor = source.CustomHeightFogColor;
				CustomHeightFogIntensity = Mathf.Lerp(source.CustomHeightFogIntensity, 0f, blendPercentage);
				CustomHeightFogTopHeight = source.CustomHeightFogTopHeight;
				CustomHeightFogBottomHeight = source.CustomHeightFogBottomHeight;
				CustomHeightFogFallofPower = source.CustomHeightFogFallofPower;
				PlayerPositionCustomHeightInfluence = source.PlayerPositionCustomHeightInfluence;
				CustomHeightMaskRadius = source.CustomHeightMaskRadius;
				CustomHeightMaskLowerClamp = source.CustomHeightMaskLowerClamp;
				CustomHeightMaskPower = source.CustomHeightMaskPower;
				CustomHeightFogNoiseInfluence = source.CustomHeightFogNoiseInfluence;
				CustomHeightFogNoiseScale = source.CustomHeightFogNoiseScale;
				CustomHeightFogNoisePower = source.CustomHeightFogNoisePower;
				CustomHeightFogCenterOffset = source.CustomHeightFogCenterOffset;
				CustomHeightFogNoiseOffsetScale = source.CustomHeightFogNoiseOffsetScale;
				CustomHeightFogNoiseDirection = source.CustomHeightFogNoiseDirection;
				CustomHeightFogNoiseSpeed = source.CustomHeightFogNoiseSpeed;
				return;
			}
			if (target.CustomHeightFog && target.CustomHeightFogIntensity != 0f && (!source.CustomHeightFog || source.CustomHeightFogIntensity == 0f))
			{
				CustomHeightFogColor = target.CustomHeightFogColor;
				CustomHeightFogIntensity = Mathf.Lerp(0f, target.CustomHeightFogIntensity, blendPercentage);
				CustomHeightFogTopHeight = target.CustomHeightFogTopHeight;
				CustomHeightFogBottomHeight = target.CustomHeightFogBottomHeight;
				CustomHeightFogFallofPower = target.CustomHeightFogFallofPower;
				PlayerPositionCustomHeightInfluence = target.PlayerPositionCustomHeightInfluence;
				CustomHeightMaskRadius = target.CustomHeightMaskRadius;
				CustomHeightMaskLowerClamp = target.CustomHeightMaskLowerClamp;
				CustomHeightMaskPower = target.CustomHeightMaskPower;
				CustomHeightFogNoiseInfluence = target.CustomHeightFogNoiseInfluence;
				CustomHeightFogNoiseScale = target.CustomHeightFogNoiseScale;
				CustomHeightFogNoisePower = target.CustomHeightFogNoisePower;
				CustomHeightFogCenterOffset = target.CustomHeightFogCenterOffset;
				CustomHeightFogNoiseOffsetScale = target.CustomHeightFogNoiseOffsetScale;
				CustomHeightFogNoiseDirection = target.CustomHeightFogNoiseDirection;
				CustomHeightFogNoiseSpeed = target.CustomHeightFogNoiseSpeed;
				return;
			}
			CustomHeightFogColor = Color.Lerp(source.CustomHeightFogColor, target.CustomHeightFogColor, blendPercentage);
			CustomHeightFogIntensity = Mathf.Lerp(source.CustomHeightFogIntensity, target.CustomHeightFogIntensity, blendPercentage);
			CustomHeightFogTopHeight = Mathf.Lerp(source.CustomHeightFogTopHeight, target.CustomHeightFogTopHeight, blendPercentage);
			CustomHeightFogBottomHeight = Mathf.Lerp(source.CustomHeightFogBottomHeight, target.CustomHeightFogBottomHeight, blendPercentage);
			CustomHeightFogFallofPower = Mathf.Lerp(source.CustomHeightFogFallofPower, target.CustomHeightFogFallofPower, blendPercentage);
			PlayerPositionCustomHeightInfluence = Mathf.Lerp(source.PlayerPositionCustomHeightInfluence, target.PlayerPositionCustomHeightInfluence, blendPercentage);
			CustomHeightMaskRadius = Mathf.Lerp(source.CustomHeightMaskRadius, target.CustomHeightMaskRadius, blendPercentage);
			CustomHeightMaskLowerClamp = Mathf.Lerp(source.CustomHeightMaskLowerClamp, target.CustomHeightMaskLowerClamp, blendPercentage);
			CustomHeightMaskPower = Mathf.Lerp(source.CustomHeightMaskPower, target.CustomHeightMaskPower, blendPercentage);
			if (basicNoiseBlend || source.CustomHeightFogNoiseScale == target.CustomHeightFogNoiseScale)
			{
				CustomHeightFogNoiseInfluence = Mathf.Lerp(source.CustomHeightFogNoiseInfluence, target.CustomHeightFogNoiseInfluence, blendPercentage);
				CustomHeightFogNoiseScale = Mathf.Lerp(source.CustomHeightFogNoiseScale, target.CustomHeightFogNoiseScale, blendPercentage);
				CustomHeightFogNoisePower = Mathf.Lerp(CustomHeightFogNoisePower, target.CustomHeightFogNoisePower, blendPercentage);
				CustomHeightFogCenterOffset = Mathf.Lerp(source.CustomHeightFogCenterOffset, target.CustomHeightFogCenterOffset, blendPercentage);
				CustomHeightFogNoiseOffsetScale = Mathf.Lerp(source.CustomHeightFogNoiseOffsetScale, target.CustomHeightFogNoiseOffsetScale, blendPercentage);
				CustomHeightFogNoiseDirection = Vector3.Lerp(source.CustomHeightFogNoiseDirection, target.CustomHeightFogNoiseDirection, blendPercentage);
				CustomHeightFogNoiseSpeed = Mathf.Lerp(source.CustomHeightFogNoiseSpeed, target.CustomHeightFogNoiseSpeed, blendPercentage);
			}
			else if (target.CustomHeightFogNoiseInfluence != 0f)
			{
				if (source.CustomHeightFogNoiseInfluence != 0f)
				{
					if (blendPercentage < 0.5f)
					{
						CustomHeightFogNoiseInfluence = Mathf.Lerp(source.CustomHeightFogNoiseInfluence, 0f, blendPercentage * 2f);
						CustomHeightFogNoiseScale = source.CustomHeightFogNoiseScale;
						CustomHeightFogNoisePower = source.CustomHeightFogNoisePower;
						CustomHeightFogCenterOffset = source.CustomHeightFogCenterOffset;
						CustomHeightFogNoiseOffsetScale = source.CustomHeightFogNoiseOffsetScale;
						CustomHeightFogNoiseDirection = source.CustomHeightFogNoiseDirection;
						CustomHeightFogNoiseSpeed = source.CustomHeightFogNoiseSpeed;
					}
					else
					{
						CustomHeightFogNoiseInfluence = Mathf.Lerp(0f, target.CustomHeightFogNoiseInfluence, blendPercentage * 2f - 1f);
						CustomHeightFogNoiseScale = target.CustomHeightFogNoiseScale;
						CustomHeightFogNoisePower = target.CustomHeightFogNoisePower;
						CustomHeightFogCenterOffset = target.CustomHeightFogCenterOffset;
						CustomHeightFogNoiseOffsetScale = target.CustomHeightFogNoiseOffsetScale;
						CustomHeightFogNoiseDirection = target.CustomHeightFogNoiseDirection;
						CustomHeightFogNoiseSpeed = target.CustomHeightFogNoiseSpeed;
					}
				}
				else
				{
					CustomHeightFogNoiseInfluence = Mathf.Lerp(source.CustomHeightFogNoiseInfluence, target.CustomHeightFogNoiseInfluence, blendPercentage);
					CustomHeightFogNoiseScale = target.CustomHeightFogNoiseScale;
					CustomHeightFogNoisePower = target.CustomHeightFogNoisePower;
					CustomHeightFogCenterOffset = target.CustomHeightFogCenterOffset;
					CustomHeightFogNoiseOffsetScale = target.CustomHeightFogNoiseOffsetScale;
					CustomHeightFogNoiseDirection = target.CustomHeightFogNoiseDirection;
					CustomHeightFogNoiseSpeed = target.CustomHeightFogNoiseSpeed;
				}
			}
			else
			{
				CustomHeightFogNoiseInfluence = Mathf.Lerp(source.CustomHeightFogNoiseInfluence, target.CustomHeightFogNoiseInfluence, blendPercentage);
				CustomHeightFogNoiseScale = source.CustomHeightFogNoiseScale;
				CustomHeightFogNoisePower = source.CustomHeightFogNoisePower;
				CustomHeightFogCenterOffset = source.CustomHeightFogCenterOffset;
				CustomHeightFogNoiseOffsetScale = source.CustomHeightFogNoiseOffsetScale;
				CustomHeightFogNoiseDirection = source.CustomHeightFogNoiseDirection;
				CustomHeightFogNoiseSpeed = source.CustomHeightFogNoiseSpeed;
			}
		}
	}
}
