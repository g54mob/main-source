using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public struct EyeBlinking
	{
		private const float BlinkDuration = 0.2f;

		private const float OpenMinDuration = 2f;

		private const float OpenMaxDuration = 8f;

		private Material _eyeLidMaterial;

		private Material _eyeMaterial;

		public int _eyeSubMeshIndex;

		public CharModule.ModuleInstance _eyeModuleInstance;

		private bool _isOpen;

		private float _currentStateLifetime;

		private Material[] _materialArray;

		public void SetupEyeBlinking(List<CharModule.ModuleInstance> moduleInstances, Material eyeLidMaterial)
		{
			foreach (CharModule.ModuleInstance moduleInstance in moduleInstances)
			{
				if ((moduleInstance.Tags & CharModule.Tags.Face) == 0)
				{
					continue;
				}
				int num = -1;
				for (int i = 0; i < moduleInstance.OriginalMaterials.Length; i++)
				{
					if (moduleInstance.MaterialModes[i] == CharModule.MaterialMode.Eye)
					{
						num = i;
						break;
					}
				}
				if (num >= 0)
				{
					Configure(eyeLidMaterial, num, moduleInstance);
					break;
				}
			}
		}

		private void Configure(Material eyeLidMaterial, int eyeSubMeshIndex, CharModule.ModuleInstance eyeModuleInstance)
		{
			_eyeLidMaterial = eyeLidMaterial;
			_eyeSubMeshIndex = eyeSubMeshIndex;
			_eyeModuleInstance = eyeModuleInstance;
			if (_materialArray == null || _materialArray.Length != _eyeModuleInstance.OriginalMaterials.Length)
			{
				_materialArray = new Material[_eyeModuleInstance.OriginalMaterials.Length];
			}
			_eyeModuleInstance.Renderer.sharedMaterials.CopyTo(_materialArray, 0);
			_eyeMaterial = _materialArray[_eyeSubMeshIndex];
		}

		public void Reset()
		{
			_eyeLidMaterial = null;
			_eyeSubMeshIndex = -1;
			_eyeModuleInstance = default(CharModule.ModuleInstance);
		}

		public void Update(float deltaTime)
		{
			if (_eyeSubMeshIndex < 0 || _eyeModuleInstance.Renderer == null)
			{
				return;
			}
			_currentStateLifetime -= deltaTime;
			if (_currentStateLifetime < 0f)
			{
				if (_isOpen)
				{
					_currentStateLifetime = 0.2f;
					_materialArray[_eyeSubMeshIndex] = _eyeLidMaterial;
					_eyeModuleInstance.Renderer.sharedMaterials = _materialArray;
				}
				else
				{
					_currentStateLifetime = Random.Range(2f, 8f);
					_materialArray[_eyeSubMeshIndex] = _eyeMaterial;
					_eyeModuleInstance.Renderer.sharedMaterials = _materialArray;
				}
				_isOpen = !_isOpen;
			}
		}
	}
}
