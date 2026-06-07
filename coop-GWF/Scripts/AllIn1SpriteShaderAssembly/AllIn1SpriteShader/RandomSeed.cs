using UnityEngine;
using UnityEngine.UI;

namespace AllIn1SpriteShader
{
	public class RandomSeed : MonoBehaviour
	{
		private readonly int randomSeedProperty = Shader.PropertyToID("_RandomSeed");

		private MaterialPropertyBlock propertyBlock;

		private void Start()
		{
			Renderer component = GetComponent<Renderer>();
			if (component != null)
			{
				propertyBlock = new MaterialPropertyBlock();
				propertyBlock.SetFloat(randomSeedProperty, Random.Range(0f, 100f));
				component.SetPropertyBlock(propertyBlock);
				return;
			}
			Image component2 = GetComponent<Image>();
			if (component2 != null)
			{
				if (component2.material != null)
				{
					component2.material.SetFloat(randomSeedProperty, Random.Range(0f, 1000f));
				}
				else
				{
					Debug.LogError("Missing Material on UI Image: " + base.gameObject.name);
				}
			}
			else
			{
				Debug.LogError("Missing Renderer or UI Image on: " + base.gameObject.name);
			}
		}
	}
}
