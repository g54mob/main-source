using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarPatternAuto : MonoBehaviour
	{
		[SerializeField]
		private float minValue;

		[SerializeField]
		private float maxValue;

		[SerializeField]
		[Range(0f, 1f)]
		private float loadSpeed;

		[SerializeField]
		private bool forward;

		[SerializeField]
		private bool loop;

		[SerializeField]
		private bool hasText;

		[SerializeField]
		private Text text;

		[SerializeField]
		private Image foreground;

		[SerializeField]
		private RawImage patternImage;

		[SerializeField]
		private RectTransform patternRect;

		[SerializeField]
		private bool patternPlay;

		[SerializeField]
		private float patternSpeed;

		[SerializeField]
		private bool patternForward;

		[SerializeField]
		private float patternScale;

		private float currentValue;

		private bool bDelayedUpdate;

		public float MinValue
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

		public float LoadSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool Forward
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Loop
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

		public float PatternScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void OnValueChanged()
		{
		}

		private void InitValue()
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

		private void UpdateForeground()
		{
		}

		private void UpdateText()
		{
		}
	}
}
