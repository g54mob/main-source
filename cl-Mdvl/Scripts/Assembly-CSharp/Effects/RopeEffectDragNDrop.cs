using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Manager;
using UnityEngine;

namespace Effects
{
	public class RopeEffectDragNDrop : MonoBehaviour
	{
		[SerializeField]
		private int vertexCount = 12;

		[SerializeField]
		private float Point2Yposition = 2f;

		[SerializeField]
		private RopeMaterial materialType;

		[SerializeField]
		private Material ropeMaterial;

		[SerializeField]
		private Material chainMaterial;

		private LineRenderer lineRenderer;

		private MaterialPropertyBlock mpb;

		[SerializeField]
		private Transform start;

		[SerializeField]
		private Transform target;

		private Transform transformTarget;

		private List<Vector3> points = new List<Vector3>();

		[SerializeField]
		private Transform midPoint;

		private List<Vector3> CalculatePoints()
		{
			points.Clear();
			Vector3 position = start.position;
			Vector3 b = Vector3.zero;
			if (target != null)
			{
				b = target.position;
			}
			if (transformTarget != null)
			{
				b = transformTarget.position;
			}
			midPoint.position = new Vector3((position.x + b.x) / 2f, position.y - Point2Yposition, (position.z + b.z) / 2f);
			for (float num = 0f; num <= 1f; num += 1f / (float)vertexCount)
			{
				Vector3 a = Vector3.Lerp(position, midPoint.position, num);
				Vector3 b2 = Vector3.Lerp(midPoint.position, b, num);
				Vector3 item = Vector3.Lerp(a, b2, num);
				points.Add(item);
			}
			return points;
		}

		private void Start()
		{
			GetReferences();
		}

		private void GetReferences()
		{
			lineRenderer = GetComponentInChildren<LineRenderer>() ?? GetComponent<LineRenderer>();
			mpb = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(lineRenderer);
		}

		public void SelectMaterial(RopeMaterial type)
		{
			Texture texture = null;
			Vector2 value = Vector2.zero;
			float value2 = 0f;
			GetReferences();
			if (!(lineRenderer == null) && mpb != null)
			{
				switch (type)
				{
				case RopeMaterial.Chains:
					texture = chainMaterial.GetTexture("_Diffuse");
					value = chainMaterial.GetTextureScale("_Diffuse");
					lineRenderer.textureScale = new Vector2(10f, 1f);
					value2 = 0f;
					break;
				case RopeMaterial.Rope:
					texture = ropeMaterial.GetTexture("_Diffuse");
					value = ropeMaterial.GetTextureScale("_Diffuse");
					lineRenderer.textureScale = new Vector2(1f, 1f);
					value2 = 10f;
					break;
				}
				if (!(texture == null))
				{
					mpb.SetTexture("_Diffuse", texture);
					lineRenderer.material.SetTextureScale("_Diffuse", value);
					mpb.SetFloat("_TextureRotation", value2);
					lineRenderer.SetPropertyBlock(mpb);
				}
			}
		}

		private void Update()
		{
			List<Vector3> list = CalculatePoints();
			lineRenderer.positionCount = list.Count;
			lineRenderer.SetPositions(list.ToArray());
		}
	}
}
