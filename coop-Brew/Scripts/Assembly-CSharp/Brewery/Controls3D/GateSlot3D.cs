using UnityEngine;

namespace Brewery.Controls3D
{
	public class GateSlot3D : MonoBehaviour
	{
		[Header("Element Visuals")]
		[SerializeField]
		private GameObject element0;

		[SerializeField]
		private GameObject element1;

		[SerializeField]
		private GameObject element2;

		[SerializeField]
		private GameObject element3;

		[Header("Fake Materials")]
		[Tooltip("Random material selected from this list when showing a fake element.")]
		[SerializeField]
		private Material[] fakeMaterials;

		[Header("Animation")]
		[SerializeField]
		private TweenConfig showAnimation;

		[SerializeField]
		private TweenConfig hideAnimation;

		private int currentElementIndex;

		private bool currentIsFake;

		private GameObject activeVisual;

		private Renderer activeRenderer;

		private Material originalMaterial;

		private int scaleTweenId;

		public int CurrentElementIndex => 0;

		public bool IsFake => false;

		public bool HasElement => false;

		private void Awake()
		{
		}

		private void CacheOriginalMaterials()
		{
		}

		public void ShowElement(int elementIndex, bool isFake, bool animate = true)
		{
		}

		public void Hide(bool animate = true)
		{
		}

		public void Reset()
		{
		}

		private void RestoreOriginalMaterial()
		{
		}

		private GameObject GetVisual(int elementIndex)
		{
			return null;
		}

		private void HideAllVisuals()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
