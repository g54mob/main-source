using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarBubbleAuto : MonoBehaviour
	{
		[SerializeField]
		private float minValue;

		[SerializeField]
		private float maxValue;

		private float currentValue;

		[Range(0f, 1f)]
		[SerializeField]
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
		private RectTransform bubble;

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

		private void OnValueChanged()
		{
		}

		private void InitValue()
		{
		}

		private void OnEnable()
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
