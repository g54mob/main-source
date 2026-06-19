using System.Collections.Generic;
using UnityEngine;

namespace FPL
{
	[RequireComponent(typeof(MeshRenderer))]
	public class FPL_Controller : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer _mesh;

		private MaterialPropertyBlock _propertyBlock;

		private static readonly Dictionary<FPL_Properties, int> LightPropertiesDictionary;

		static FPL_Controller()
		{
			LightPropertiesDictionary = new Dictionary<FPL_Properties, int>
			{
				{
					FPL_Properties._LightTint,
					Shader.PropertyToID(FPL_Properties._LightTint.ToString())
				},
				{
					FPL_Properties._LightSoftness,
					Shader.PropertyToID(FPL_Properties._LightSoftness.ToString())
				},
				{
					FPL_Properties._LightPosterize,
					Shader.PropertyToID(FPL_Properties._LightPosterize.ToString())
				},
				{
					FPL_Properties._ShadingBlend,
					Shader.PropertyToID(FPL_Properties._ShadingBlend.ToString())
				},
				{
					FPL_Properties._ShadingSoftness,
					Shader.PropertyToID(FPL_Properties._ShadingSoftness.ToString())
				},
				{
					FPL_Properties._HaloTint,
					Shader.PropertyToID(FPL_Properties._HaloTint.ToString())
				},
				{
					FPL_Properties._HaloSize,
					Shader.PropertyToID(FPL_Properties._HaloSize.ToString())
				},
				{
					FPL_Properties._HaloPosterize,
					Shader.PropertyToID(FPL_Properties._HaloPosterize.ToString())
				},
				{
					FPL_Properties._HaloDepthFade,
					Shader.PropertyToID(FPL_Properties._HaloDepthFade.ToString())
				},
				{
					FPL_Properties._FarFade,
					Shader.PropertyToID(FPL_Properties._FarFade.ToString())
				},
				{
					FPL_Properties._FarTransition,
					Shader.PropertyToID(FPL_Properties._FarTransition.ToString())
				},
				{
					FPL_Properties._CloseFade,
					Shader.PropertyToID(FPL_Properties._CloseFade.ToString())
				},
				{
					FPL_Properties._CloseTransition,
					Shader.PropertyToID(FPL_Properties._CloseTransition.ToString())
				},
				{
					FPL_Properties._RandomOffset,
					Shader.PropertyToID(FPL_Properties._RandomOffset.ToString())
				},
				{
					FPL_Properties._FlickerIntensity,
					Shader.PropertyToID(FPL_Properties._FlickerIntensity.ToString())
				},
				{
					FPL_Properties._FlickerSpeed,
					Shader.PropertyToID(FPL_Properties._FlickerSpeed.ToString())
				},
				{
					FPL_Properties._FlickerHue,
					Shader.PropertyToID(FPL_Properties._FlickerHue.ToString())
				},
				{
					FPL_Properties._FlickerSoftness,
					Shader.PropertyToID(FPL_Properties._FlickerSoftness.ToString())
				},
				{
					FPL_Properties._SizeFlickering,
					Shader.PropertyToID(FPL_Properties._SizeFlickering.ToString())
				},
				{
					FPL_Properties._Noisiness,
					Shader.PropertyToID(FPL_Properties._Noisiness.ToString())
				},
				{
					FPL_Properties._NoiseScale,
					Shader.PropertyToID(FPL_Properties._NoiseScale.ToString())
				},
				{
					FPL_Properties._NoiseMovement,
					Shader.PropertyToID(FPL_Properties._NoiseMovement.ToString())
				},
				{
					FPL_Properties._SpecIntensity,
					Shader.PropertyToID(FPL_Properties._SpecIntensity.ToString())
				},
				{
					FPL_Properties._SpecPower,
					Shader.PropertyToID(FPL_Properties._SpecPower.ToString())
				}
			};
		}

		private void InitializeVariables()
		{
			if (_mesh == null)
			{
				_mesh = GetComponent<MeshRenderer>();
			}
			if (_propertyBlock == null)
			{
				_propertyBlock = new MaterialPropertyBlock();
			}
		}

		private bool MeshCheck()
		{
			if (_mesh == null)
			{
				Debug.LogWarning("Warning: FPL_Controller is missing its mesh renderer component");
				return true;
			}
			return false;
		}

		private void Awake()
		{
			InitializeVariables();
		}

		public void SetProperty(FPL_Properties lightProperty, float value)
		{
			if (!MeshCheck())
			{
				_propertyBlock.SetFloat(LightPropertiesDictionary[lightProperty], value);
				_mesh.SetPropertyBlock(_propertyBlock);
			}
		}

		public void SetProperty(FPL_Properties lightProperty, Color value)
		{
			if (!MeshCheck())
			{
				_propertyBlock.SetColor(LightPropertiesDictionary[lightProperty], value);
				_mesh.SetPropertyBlock(_propertyBlock);
			}
		}

		public MaterialPropertyBlock GetPropertyBlock()
		{
			return _propertyBlock;
		}

		public void SetPropertyBlock(MaterialPropertyBlock propertyBlock)
		{
			_propertyBlock = propertyBlock;
			if (!MeshCheck())
			{
				_mesh.SetPropertyBlock(_propertyBlock);
			}
		}
	}
}
