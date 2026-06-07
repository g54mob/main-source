using System;
using UnityEngine;
using UnityEngine.Rendering;
using WaveHarmonic.Crest.Internal;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[Serializable]
	public abstract class TextureLodInputData : LodInputData
	{
		[Tooltip("Texture to render into the simulation.")]
		[SerializeField]
		internal Texture _Texture;

		[Tooltip("Multiplies the texture sample.\n\nThis is useful for normalized textures. The four components map to the four color/alpha components of the texture (if they exist).\n\nIf you just want to fade out the input, consider using weight instead.")]
		[SerializeField]
		private Vector4 _Multiplier = Vector4.one;

		private protected abstract ComputeShader TextureShader { get; }

		internal override bool IsEnabled => _Texture != null;

		internal override bool HasHeightRange => false;

		public Vector4 Multiplier
		{
			get
			{
				return _Multiplier;
			}
			set
			{
				_Multiplier = value;
			}
		}

		public Texture Texture
		{
			get
			{
				return _Texture;
			}
			set
			{
				_Texture = value;
			}
		}

		internal override void RecalculateRect()
		{
			_Rect = _Input.transform.RectXZ();
		}

		internal override void RecalculateBounds()
		{
			Transform transform = _Input.transform;
			Vector2 size = transform.lossyScale.XZ();
			size = Helpers.RotateAndEncapsulateXZ(size, transform.rotation.eulerAngles.y);
			_Bounds = new Bounds(_Input.transform.position, size.XNZ());
		}

		internal override void Draw(Lod lod, Component component, CommandBuffer buffer, RenderTargetIdentifier target, int slices)
		{
			Transform transform = component.transform;
			PropertyWrapperCompute propertyWrapperCompute = new PropertyWrapperCompute(buffer, TextureShader, 0);
			Vector2 normalized = new Vector2(transform.localToWorldMatrix.m20, transform.localToWorldMatrix.m00).normalized;
			propertyWrapperCompute.SetVector(ShaderIDs.s_TextureSize, transform.lossyScale.XZ());
			propertyWrapperCompute.SetVector(ShaderIDs.s_TexturePosition, transform.position.XZ());
			propertyWrapperCompute.SetVector(ShaderIDs.s_TextureRotation, normalized);
			propertyWrapperCompute.SetVector(ShaderIDs.s_TextureResolution, new Vector4(_Texture.width, _Texture.height));
			propertyWrapperCompute.SetVector(ShaderIDs.s_Multiplier, _Multiplier);
			propertyWrapperCompute.SetFloat(ShaderIDs.s_FeatherWidth, _Input.FeatherWidth);
			propertyWrapperCompute.SetTexture(ShaderIDs.s_Texture, _Texture);
			propertyWrapperCompute.SetInteger(ShaderIDs.s_Blend, (int)_Input.Blend);
			propertyWrapperCompute.SetTexture(ShaderIDs.s_Target, target);
			if (this is LevelTextureLodInputData levelTextureLodInputData)
			{
				propertyWrapperCompute.SetKeyword(ScriptableSingleton<WaterResources>.Instance.Keywords.LevelTextureCatmullRom, levelTextureLodInputData._UseCatmullRomFiltering);
			}
			if (this is DirectionalTextureLodInputData directionalTextureLodInputData)
			{
				propertyWrapperCompute.SetBoolean(ShaderIDs.s_NegativeValues, directionalTextureLodInputData._NegativeValues);
			}
			int num = lod.Resolution / 8;
			propertyWrapperCompute.Dispatch(num, num, slices);
		}

		internal override void OnEnable()
		{
		}

		internal override void OnDisable()
		{
		}
	}
}
