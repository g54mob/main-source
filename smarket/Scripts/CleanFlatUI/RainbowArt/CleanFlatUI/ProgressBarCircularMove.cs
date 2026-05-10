using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarCircularMove : MonoBehaviour
	{
		public enum Origin
		{
			Bottom = 0,
			Top = 1,
			Left = 2,
			Right = 3
		}

		public enum PatternOriginVertical
		{
			Bottom = 0,
			Top = 1
		}

		public enum PatternOriginHorizontal
		{
			Left = 0,
			Right = 1
		}

		[SerializeField]
		public float currentValue;

		[SerializeField]
		public float maxValue;

		[SerializeField]
		public bool hasText;

		[SerializeField]
		private Text text;

		[SerializeField]
		private RectTransform foregroundArea;

		[SerializeField]
		private RawImage patternImage;

		[SerializeField]
		private RectTransform patternRect;

		[SerializeField]
		private Origin origin;

		[SerializeField]
		private bool patternPlay;

		[SerializeField]
		private float patternSpeed;

		[SerializeField]
		private int patternOrigin;

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

		public bool PatternPlay
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float PatternSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int PatternOrigin
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private void OnValueChanged()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateGUI()
		{
		}

		private void UpdatePattern()
		{
		}

		private void UpdateForeground()
		{
		}

		private void ResetForegroundOrigon()
		{
		}

		private void UpdateForegroundFromBottom()
		{
		}

		private void UpdateForegroundFromTop()
		{
		}

		private void UpdateForegroundFromLeft()
		{
		}

		private void UpdateForegroundFromRight()
		{
		}

		private void UpdateText()
		{
		}
	}
}
