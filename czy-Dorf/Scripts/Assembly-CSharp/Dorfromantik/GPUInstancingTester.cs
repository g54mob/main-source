using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class GPUInstancingTester : MonoBehaviour
	{
		[SerializeField]
		private KeyCode placementKey;

		[SerializeField]
		private ElementType elementType;

		[SerializeField]
		private ElementVisual elementVisualReference;

		[SerializeField]
		private Biome biome;

		[SerializeField]
		private Vector2 randomYOffset = new Vector2(-0.1f, 0.1f);

		[SerializeField]
		private List<ElementVisual> randomVisuals;

		private Plane groundPlane = new Plane(Vector3.up, 0f);

		private void Update()
		{
			if (Input.GetKey(placementKey))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				groundPlane.Raycast(ray, out var enter);
				Vector3 position = ray.GetPoint(enter) + Vector3.up * Random.Range(randomYOffset.x, randomYOffset.y);
				ElementVisual elementVisual = randomVisuals[Random.Range(0, randomVisuals.Count)];
				OverwritingSingleton<InstanceDrawer>.Instance.AddTestInstance(((IRecyclable)elementVisual).RecyclableId, elementType, elementVisual, biome, position, Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.up), Vector3.one);
			}
		}
	}
}
