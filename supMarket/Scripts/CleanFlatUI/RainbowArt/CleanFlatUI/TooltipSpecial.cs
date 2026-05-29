using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class TooltipSpecial : MonoBehaviour
	{
		private enum Origin
		{
			Top = 0,
			RightTop = 1,
			LeftTop = 2,
			Bottom = 3,
			RightBottom = 4,
			LeftBottom = 5
		}

		[SerializeField]
		private Text description;

		[SerializeField]
		private Animator animator;

		private float parentWidth;

		private float parentHeight;

		private Origin origin;

		private bool bDelayedUpdate;

		public string DescriptionValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void InitTooltip(Vector2 mousePosition, RectTransform areaRect)
		{
		}

		public void ShowTooltip()
		{
		}

		public void HideTooltip()
		{
		}

		private void Update()
		{
		}

		private void UpdateHeight()
		{
		}

		private void UpdatePosition(Vector2 mousePosition, RectTransform areaRect)
		{
		}

		private void PlayAnimation()
		{
		}
	}
}
