using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class CircusLightsAnimator : MonoBehaviour
	{
		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public struct Frame
		{
			public float Time;

			public Texture2D Texture;

			public Color LightColor;
		}

		public enum TextureChannel
		{
			Main = 0,
			Emission = 1
		}

		[SerializeField]
		private bool _useScaledTime = true;

		[SerializeField]
		private TextureChannel _textureChannel;

		[SerializeField]
		private bool _randomFrames;

		[SerializeField]
		private Frame[] _frames;

		[SerializeField]
		private Renderer _renderer;

		[SerializeField]
		private ClippableLight _clippableLight;

		private MaterialPropertyBlock _propertyBlock;

		private int _frame = -1;

		private float _time;

		private void Start()
		{
			_propertyBlock = new MaterialPropertyBlock();
		}

		private string GetChannel(TextureChannel channel)
		{
			return channel switch
			{
				TextureChannel.Main => "_MainTex", 
				TextureChannel.Emission => "_EmissionMap", 
				_ => throw new ArgumentOutOfRangeException("channel", channel, null), 
			};
		}

		private void Update()
		{
			if (_frames == null || _frames.Length == 0)
			{
				return;
			}
			_time -= (_useScaledTime ? Time.deltaTime : Time.unscaledDeltaTime);
			if (!(_time <= 0f))
			{
				return;
			}
			if (_randomFrames)
			{
				_frame = RandomUtils.GlobalRandomInstance.Next(_frames.Length);
			}
			else
			{
				_frame++;
				if (_frame >= _frames.Length)
				{
					_frame = 0;
				}
			}
			_time += _frames[_frame].Time;
			_propertyBlock.SetTexture(GetChannel(_textureChannel), _frames[_frame].Texture);
			_clippableLight.Color = _frames[_frame].LightColor;
			_renderer.SetPropertyBlock(_propertyBlock);
		}
	}
}
