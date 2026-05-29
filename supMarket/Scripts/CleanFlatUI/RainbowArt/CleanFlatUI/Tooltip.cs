using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class Tooltip : MonoBehaviour
	{
		public enum Origin
		{
			Top = 0,
			Bottom = 1,
			Left = 2,
			Right = 3
		}

		[SerializeField]
		private Text description;

		[SerializeField]
		private RectTransform arrowRect;

		[SerializeField]
		private uint distance;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private Origin origin;

		private bool bDelayedUpdate;

		public uint Distance
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public Origin CurOrigin
		{
			get
			{
				return default(Origin);
			}
			set
			{
			}
		}

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

		public void SetTooltipPosition(Vector3 position, float width, float height)
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

		private void PlayAnimation()
		{
		}
	}
}
