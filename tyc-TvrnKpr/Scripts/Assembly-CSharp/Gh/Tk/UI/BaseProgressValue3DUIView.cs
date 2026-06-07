using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class BaseProgressValue3DUIView : BaseInteractable3DUIView
	{
		public TextMeshProI18n valueLabel;

		public ObjectProgressBar3DUIView progressBar;

		public ValueDisplayMode defaultDisplayMode;

		public string controlGroup;

		public GameObject flipRoot;

		private bool isValueLabelVisible;

		private string _labelKey;

		[SerializeField]
		private float _flipProgressHeightOffset;

		[SerializeField]
		private float _flipValueHeightOffset;

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

		public float Value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public string LabelKey
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void OnClicked()
		{
		}

		private IEnumerable<BaseProgressValue3DUIView> GetControlsInGroup()
		{
			return null;
		}

		protected override void Start()
		{
		}

		private void ToggleDisplayMode(bool animate = true)
		{
		}
	}
}
