using UnityEngine;

namespace AllIn1VfxToolkit
{
	public class All1VfxRandomTimeSeed : MonoBehaviour
	{
		[SerializeField]
		private float minSeedValue;

		[SerializeField]
		private float maxSeedValue = 100f;

		private void Start()
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetFloat("_TimingSeed", Random.Range(minSeedValue, maxSeedValue));
			GetComponent<Renderer>().SetPropertyBlock(materialPropertyBlock);
		}
	}
}
