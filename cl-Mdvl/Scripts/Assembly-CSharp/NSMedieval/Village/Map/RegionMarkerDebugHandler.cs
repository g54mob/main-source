using UnityEngine;

namespace NSMedieval.Village.Map
{
	public class RegionMarkerDebugHandler : MonoBehaviour
	{
		private bool isPointerEntered;

		private MeshRenderer meshRenderer;

		private MeshFilter meshFilter;

		private Region region;

		private Color color;

		public Color Color
		{
			get
			{
				return color;
			}
			set
			{
				color = value;
			}
		}

		public Region Region
		{
			get
			{
				return region;
			}
			set
			{
				region = value;
			}
		}

		public void OnPointerEnter(bool isConnection = false)
		{
			isPointerEntered = true;
			if (meshRenderer != null)
			{
				meshRenderer.sharedMaterial.SetFloat("_Hover", 1f);
				meshRenderer.sharedMaterial.SetFloat("_GiveRED", isConnection ? 1f : 0f);
			}
		}

		public void OnPointerExit()
		{
			if (isPointerEntered)
			{
				isPointerEntered = false;
				if (meshRenderer != null)
				{
					meshRenderer.sharedMaterial.SetFloat("_Hover", 0f);
					meshRenderer.sharedMaterial.SetFloat("_GiveRED", 0f);
				}
			}
		}

		private void Start()
		{
			meshRenderer = GetComponent<MeshRenderer>();
			meshFilter = GetComponent<MeshFilter>();
		}
	}
}
