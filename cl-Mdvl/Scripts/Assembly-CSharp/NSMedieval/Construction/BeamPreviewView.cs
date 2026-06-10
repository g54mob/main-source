using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Construction
{
	public class BeamPreviewView : MonoBehaviour, IBeamView
	{
		[SerializeField]
		private GameObject scalableElement;

		[SerializeField]
		private GameObject movableSupportRight;

		[SerializeField]
		private GameObject movableSupportLeft;

		[NonSerialized]
		private List<MeshRenderer> renderers = new List<MeshRenderer>();

		[NonSerialized]
		private MaterialPropertyBlock materialPropertyBlock;

		private Vector3 scale;

		public Transform Transform => base.gameObject.transform;

		public Vector3 Scale => scale;

		public GameObject MovableSupportRight => movableSupportRight;

		public GameObject MovableSupportLeft => movableSupportLeft;

		public void ResetBeamPreview()
		{
			scale = Vector3.one;
			scalableElement.transform.localScale = new Vector3(1f, 1f, 1f);
			movableSupportLeft.transform.localPosition = new Vector3(-0.35f, 0f, 0f);
			movableSupportRight.transform.localPosition = new Vector3(0.35f, 0f, 0f);
			SetMaterialChange(2);
		}

		private void SetMaterialChange(int value)
		{
			if (materialPropertyBlock == null)
			{
				materialPropertyBlock = new MaterialPropertyBlock();
			}
			materialPropertyBlock.SetFloat("_materialChange", value);
			foreach (MeshRenderer renderer in renderers)
			{
				renderer.SetPropertyBlock(materialPropertyBlock);
			}
		}

		public void SetupPositionAndScale(Vector3 rightOffset, Vector3 leftOffset, Vector3 newScale)
		{
			scale = newScale;
			leftOffset.y = movableSupportRight.transform.localPosition.y;
			rightOffset.y = movableSupportLeft.transform.localPosition.y;
			movableSupportLeft.transform.localPosition = leftOffset;
			movableSupportRight.transform.localPosition = rightOffset;
			scalableElement.transform.localScale = newScale;
		}

		public void InvalidPosition()
		{
			SetMaterialChange(1);
		}

		public void BeamTooLong(Vec3Int startPosition, Vec3Int endPosition)
		{
			SetMaterialChange(1);
		}

		private void Start()
		{
			renderers.Add(scalableElement.GetComponent<MeshRenderer>());
			renderers.Add(movableSupportRight.GetComponent<MeshRenderer>());
			renderers.Add(movableSupportLeft.GetComponent<MeshRenderer>());
		}
	}
}
