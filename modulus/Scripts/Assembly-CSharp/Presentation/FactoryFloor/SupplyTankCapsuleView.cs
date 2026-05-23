using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor.Resources;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class SupplyTankCapsuleView : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer _liquid;

		[SerializeField]
		private Material _noLiquidMat;

		[SerializeField]
		private int _liquidMaterialIndex;

		[SerializeField]
		private ResourceDatabaseSO _resourceDatabaseSO;

		[SerializeField]
		private SerializedDictionary<ResourceDataSO, Material> _resourceMaterials;

		[SerializeField]
		private float _fillAmountMin;

		[SerializeField]
		private float _fillAmountMax;

		[SerializeField]
		private float _animationDuration = 0.2f;

		private bool _initialized;

		private List<Material> _withLiquidMaterials;

		private List<Material> _withoutLiquidMaterials;

		private Material _liquidMat;

		private static readonly int FillAmount = Shader.PropertyToID("_FillAmount");

		private void Awake()
		{
			Init();
		}

		private void Init()
		{
			if (!_initialized)
			{
				_liquidMat = Object.Instantiate(_liquid.materials[_liquidMaterialIndex]);
				_withLiquidMaterials = _liquid.materials.ToList();
				_withoutLiquidMaterials = _liquid.materials.ToList();
				_withLiquidMaterials[_liquidMaterialIndex] = _liquidMat;
				_withoutLiquidMaterials[_liquidMaterialIndex] = _noLiquidMat;
				_initialized = true;
			}
		}

		public void AnimateLiquidFillPercentage(float perc)
		{
			SetMat(perc);
			float y = Mathf.Lerp(_fillAmountMin, _fillAmountMax, perc);
			_liquid.material.SetVector(FillAmount, new Vector3(0f, y, 0f));
		}

		public void SetLiquidFillPercentage(float perc)
		{
			SetMat(perc);
			float y = Mathf.Lerp(_fillAmountMin, _fillAmountMax, perc);
			_liquid.material.SetVector(FillAmount, new Vector3(0f, y, 0f));
		}

		private void SetMat(float perc)
		{
			Init();
			if (perc > 0.01f)
			{
				_liquid.SetMaterials(_withLiquidMaterials);
			}
			else
			{
				_liquid.SetMaterials(_withoutLiquidMaterials);
			}
		}

		public void SetLiquidToResource(int resourceID)
		{
			SetLiquidToResource(_resourceDatabaseSO.GetResourceDataFromID(resourceID));
		}

		public void SetLiquidToResource(ResourceDataSO resourceData)
		{
		}
	}
}
