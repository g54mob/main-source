#define ENABLE_DEBUG_WARNINGS
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Utils;

namespace Logic.Lighting
{
	public class GlobalVolumeManager : MonoBehaviour
	{
		[SerializeField]
		private Volume _globalVolume;

		private ColorLookup _colorLookup;

		private Bloom _bloom;

		private ColorAdjustments _colorAdjustments;

		public Volume GlobalVolume => _globalVolume;

		public ColorLookup ColorLookup
		{
			get
			{
				if (_colorLookup == null)
				{
					if (_globalVolume.profile.TryGet<ColorLookup>(out var component))
					{
						_colorLookup = component;
					}
					else
					{
						this.LogWarning("No Color Lookup found on global volume !", "ColorLookup", 27);
					}
				}
				return _colorLookup;
			}
		}

		public Bloom Bloom
		{
			get
			{
				if (_bloom == null)
				{
					if (_globalVolume.profile.TryGet<Bloom>(out var component))
					{
						_bloom = component;
					}
					else
					{
						this.LogWarning("No Bloom found on global volume !", "Bloom", 49);
					}
				}
				return _bloom;
			}
		}

		public ColorAdjustments ColorAdjustments
		{
			get
			{
				if (_colorAdjustments == null)
				{
					if (_globalVolume.profile.TryGet<ColorAdjustments>(out var component))
					{
						_colorAdjustments = component;
					}
					else
					{
						this.LogWarning("No Color Lookup found on global volume !", "ColorAdjustments", 71);
					}
				}
				return _colorAdjustments;
			}
		}
	}
}
