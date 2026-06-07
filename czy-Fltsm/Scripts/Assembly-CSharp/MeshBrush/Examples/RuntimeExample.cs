using UnityEngine;
using UnityEngine.UI;

namespace MeshBrush.Examples
{
	public class RuntimeExample : MonoBehaviour
	{
		[SerializeField]
		private MeshBrush meshbrushInstance;

		[SerializeField]
		private Transform circleBrush;

		[SerializeField]
		private Slider radiusSlider;

		[SerializeField]
		private Slider scatteringSlider;

		[SerializeField]
		private Slider densitySlider;

		private Transform mainCamera;

		private void Start()
		{
			mainCamera = Camera.main.transform;
		}

		private void Update()
		{
			meshbrushInstance.radius = radiusSlider.value;
			meshbrushInstance.scatteringRange = new Vector2(scatteringSlider.value, scatteringSlider.value);
			meshbrushInstance.densityRange = new Vector2(densitySlider.value, densitySlider.value);
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo))
			{
				circleBrush.position = hitInfo.point;
				circleBrush.forward = -hitInfo.normal;
				circleBrush.localScale = new Vector3(meshbrushInstance.radius, meshbrushInstance.radius, 1f);
				if (Input.GetKey(meshbrushInstance.paintKey))
				{
					meshbrushInstance.PaintMeshes(hitInfo);
				}
				if (Input.GetKey(meshbrushInstance.deleteKey))
				{
					meshbrushInstance.DeleteMeshes(hitInfo);
				}
				if (Input.GetKey(meshbrushInstance.randomizeKey))
				{
					meshbrushInstance.RandomizeMeshes(hitInfo);
				}
			}
		}
	}
}
