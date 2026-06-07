using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public abstract class ColorLod : Lod
	{
		private new static class ShaderIDs
		{
			public static readonly int s_ShorelineColor = Shader.PropertyToID("_Crest_ShorelineColor");

			public static readonly int s_ShorelineColorMaximumDistance = Shader.PropertyToID("_Crest_ShorelineColorMaximumDistance");

			public static readonly int s_ShorelineColorFalloff = Shader.PropertyToID("_Crest_ShorelineColorFalloff");
		}

		private sealed class ShorelineColorInput : ILodInput
		{
			private readonly ColorLod _VolumeColorLod;

			public bool Enabled
			{
				get
				{
					if (_VolumeColorLod._ShorelineColorSource != ShorelineVolumeColorSource.None)
					{
						return _VolumeColorLod._Water._DepthLod.Enabled;
					}
					return false;
				}
			}

			public bool IsCompute => true;

			public int Queue => int.MinValue;

			public int Pass => -1;

			public Rect Rect => Rect.zero;

			public MonoBehaviour Component => null;

			public float Filter(WaterRenderer water, int slice)
			{
				return 1f;
			}

			public ShorelineColorInput(ColorLod lod)
			{
				_VolumeColorLod = lod;
			}

			public void Draw(Lod lod, CommandBuffer buffer, RenderTargetIdentifier target, int pass = -1, float weight = 1f, int slices = -1)
			{
				WaterResources instance = ScriptableSingleton<WaterResources>.Instance;
				PropertyWrapperCompute propertyWrapperCompute = new PropertyWrapperCompute(buffer, instance.Compute._ShorelineColor, 0);
				propertyWrapperCompute.SetVector(ShaderIDs.s_ShorelineColor, _VolumeColorLod._ShorelineColorValue);
				propertyWrapperCompute.SetFloat(ShaderIDs.s_ShorelineColorMaximumDistance, _VolumeColorLod._ShorelineColorMaximumDistance);
				propertyWrapperCompute.SetFloat(ShaderIDs.s_ShorelineColorFalloff, _VolumeColorLod._ShorelineColorFalloff);
				propertyWrapperCompute.SetKeyword(ScriptableSingleton<WaterResources>.Instance.Keywords.ShorelineColorScattering, lod.GetType() == typeof(ScatteringLod));
				propertyWrapperCompute.SetKeyword(ScriptableSingleton<WaterResources>.Instance.Keywords.ShorelineColorSourceDistance, _VolumeColorLod._ShorelineColorSource == ShorelineVolumeColorSource.Distance);
				propertyWrapperCompute.SetTexture(WaveHarmonic.Crest.ShaderIDs.s_Target, target);
				int num = lod.Resolution / 8;
				propertyWrapperCompute.Dispatch(num, num, slices);
			}
		}

		[Tooltip("Source of the shoreline color.")]
		[SerializeField]
		internal ShorelineVolumeColorSource _ShorelineColorSource;

		[Tooltip("Color of the shoreline color.")]
		[SerializeField]
		private protected Color _ShorelineColor;

		[Tooltip("The maximum distance of the shoreline color.\n\nIf using Depth, then it is maximum depth.")]
		[SerializeField]
		private float _ShorelineColorMaximumDistance = 10f;

		[Tooltip("Shoreline color falloff value.")]
		[SerializeField]
		private float _ShorelineColorFalloff = 2f;

		private protected Vector4 _ShorelineColorValue;

		private ShorelineColorInput _ShorelineColorInput;

		private protected abstract int GlobalShaderID { get; }

		internal override bool SkipEndOfFrame => true;

		private protected override GraphicsFormat RequestedTextureFormat => _TextureFormatMode switch
		{
			LodTextureFormatMode.Manual => _TextureFormat, 
			LodTextureFormatMode.Performance => GraphicsFormat.R8G8B8_UNorm, 
			LodTextureFormatMode.Precision => GraphicsFormat.R16G16B16_UNorm, 
			_ => throw new NotImplementedException($"Crest: {_TextureFormatMode} not implemented for {Name}."), 
		};

		public Color ShorelineColor
		{
			get
			{
				return _ShorelineColor;
			}
			set
			{
				SetShorelineColor(_ShorelineColor, _ShorelineColor = value);
			}
		}

		public float ShorelineColorFalloff
		{
			get
			{
				return _ShorelineColorFalloff;
			}
			set
			{
				_ShorelineColorFalloff = value;
			}
		}

		public float ShorelineColorMaximumDistance
		{
			get
			{
				return _ShorelineColorMaximumDistance;
			}
			set
			{
				_ShorelineColorMaximumDistance = value;
			}
		}

		public ShorelineVolumeColorSource ShorelineColorSource
		{
			get
			{
				return _ShorelineColorSource;
			}
			set
			{
				_ShorelineColorSource = value;
			}
		}

		private protected abstract void SetShorelineColor(Color previous, Color current);

		internal ColorLod()
		{
			_TextureFormat = GraphicsFormat.R16G16B16_UNorm;
			_TextureFormatMode = LodTextureFormatMode.Precision;
		}

		internal override void Enable()
		{
			base.Enable();
			if (base.Enabled)
			{
				if (_ShorelineColorInput == null)
				{
					_ShorelineColorInput = new ShorelineColorInput(this);
				}
				SetShorelineColor(Color.clear, _ShorelineColor);
				Inputs.Add(_ShorelineColorInput.Queue, _ShorelineColorInput);
			}
		}

		internal override void SetGlobals(bool enable)
		{
			base.SetGlobals(enable);
			Helpers.SetGlobalBoolean(GlobalShaderID, enable && base.Enabled);
		}

		internal override void Disable()
		{
			base.Disable();
			Inputs.Remove(_ShorelineColorInput);
		}
	}
}
