using UnityEngine;

namespace NSMedieval.Construction
{
	public class WellPreviewView : MonoBehaviour
	{
		private const string MaterialParameterName = "_materialChange";

		[SerializeField]
		private MeshRenderer waterIndicator;

		private MaterialPropertyBlock waterIndicatorMaterialPropertyBlock;

		public void UpdateWaterIndicator(bool hasWater)
		{
			SetWaterIndicator(hasWater ? 4f : 1f);
		}

		private void Awake()
		{
			waterIndicatorMaterialPropertyBlock = new MaterialPropertyBlock();
		}

		private void OnEnable()
		{
			SetWaterIndicator(4f);
		}

		private void OnDisable()
		{
			SetWaterIndicator(4f);
		}

		private void SetWaterIndicator(float value)
		{
			waterIndicatorMaterialPropertyBlock.SetFloat("_materialChange", value);
			waterIndicator.SetPropertyBlock(waterIndicatorMaterialPropertyBlock);
		}
	}
}
