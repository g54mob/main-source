using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ProgressBarGridLinearAuto : MonoBehaviour
	{
		[SerializeField]
		private int minValue;

		[SerializeField]
		private int maxValue;

		private int currentValue;

		[SerializeField]
		private float spacing;

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
		private RectTransform background;

		[SerializeField]
		private RectTransform foreground;

		[SerializeField]
		private RectTransform bgTemplate;

		[SerializeField]
		private RectTransform fgTemplate;

		private List<RectTransform> bgList;

		private List<RectTransform> fgList;

		private float totalTime;

		public int MinValue
		{
			get
			{
				return 0;
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

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateGUI()
		{
		}

		private void CreateList(List<RectTransform> list, RectTransform rectParent, RectTransform template)
		{
		}

		private RectTransform CreateItem(RectTransform rectParent, RectTransform template)
		{
			return null;
		}

		private void UpdateForeground()
		{
		}

		private void UpdateText()
		{
		}
	}
}
