using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarSpecial : MonoBehaviour
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
		private RectTransform foreground;

		[SerializeField]
		private RectTransform foregroundArea;

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

		private void UpdateForeground()
		{
		}

		private void UpdateText()
		{
		}
	}
}
