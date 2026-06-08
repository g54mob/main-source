using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic.Utility
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(GridLayoutGroup))]
	public class AdjustGridLayoutCellSize : MonoBehaviour
	{
		public enum Axis
		{
			X = 0,
			Y = 1
		}

		public enum RatioMode
		{
			Free = 0,
			Fixed = 1
		}

		[SerializeField]
		private Axis expand;

		[SerializeField]
		private RatioMode ratioMode;

		[SerializeField]
		private float cellRatio;

		[SerializeField]
		public int count;

		private new RectTransform transform;

		private GridLayoutGroup grid;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnRectTransformDimensionsChange()
		{
		}

		private void OnValidate()
		{
		}

		public void UpdateCellSize()
		{
		}
	}
}
