using System.Collections.Generic;
using UnityEngine;

namespace AllIn1SpriteShader
{
	[ExecuteInEditMode]
	public class All1CreateUnifiedOutline : MonoBehaviour
	{
		[SerializeField]
		private Material outlineMaterial;

		[SerializeField]
		private Transform outlineParentTransform;

		[Space]
		[Header("Only needed if Sprite (ignored if UI)")]
		[SerializeField]
		private int duplicateOrderInLayer;

		[SerializeField]
		private string duplicateSortingLayer;

		[Space]
		[Header("This operation will delete the component")]
		[SerializeField]
		private bool createUnifiedOutline;

		private void Update()
		{
		}

		private void CreateOutlineSpriteDuplicate(GameObject target)
		{
		}

		private void MissingMaterial()
		{
		}

		private void GetAllChildren(Transform parent, ref List<Transform> transforms)
		{
		}
	}
}
