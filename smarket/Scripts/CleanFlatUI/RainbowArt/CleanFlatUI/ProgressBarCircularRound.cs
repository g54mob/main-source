using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarCircularRound : MonoBehaviour
	{
		public enum Origin
		{
			Bottom = 0,
			Right = 1,
			Top = 2,
			Left = 3
		}

		[SerializeField]
		private float currentValue;

		[SerializeField]
		private float maxValue;

		[SerializeField]
		private bool hasText;

		[SerializeField]
		public Text text;

		[SerializeField]
		private Image foreground;

		[SerializeField]
		private RectTransform roundArea;

		[SerializeField]
		private Image roundImage;

		[SerializeField]
		private bool clockwise;

		[SerializeField]
		private Origin origin;

		private bool bDelayedUpdate;

		public float CurrentValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaxValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool HasText
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Clockwise
		{
			get
			{
				return false;
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

		private void OnValueChanged()
		{
		}

		private void InitRoundImage()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void UpdateGUI()
		{
		}

		private void UpdateForeground()
		{
		}

		private void UpdateText()
		{
		}

		private void UpdateRoundArea()
		{
		}
	}
}
