using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarPatternCircular : MonoBehaviour
	{
		[SerializeField]
		private float currentValue;

		[SerializeField]
		private float maxValue;

		[SerializeField]
		private bool hasText;

		[SerializeField]
		private Text text;

		[SerializeField]
		private Image foreground;

		[SerializeField]
		private RawImage patternImage;

		[SerializeField]
		private bool patternPlay;

		[SerializeField]
		private float patternSpeed;

		[SerializeField]
		private bool patternForward;

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

		public bool PatternForward
		{
			get
			{
				return false;
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

		private void UpdateForegroundAndPattern()
		{
		}

		private void UpdateText()
		{
		}
	}
}
