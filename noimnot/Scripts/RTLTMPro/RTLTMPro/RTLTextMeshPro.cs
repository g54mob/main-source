using TMPro;
using UnityEngine;

namespace RTLTMPro
{
	[ExecuteInEditMode]
	public class RTLTextMeshPro : TextMeshProUGUI
	{
		[SerializeField]
		protected bool preserveNumbers;

		[SerializeField]
		protected bool farsi;

		[SerializeField]
		[TextArea(3, 10)]
		protected string originalText;

		[SerializeField]
		protected bool fixTags;

		[SerializeField]
		protected bool forceFix;

		protected readonly FastStringBuilder finalText;

		public new string text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string OriginalText => null;

		public bool PreserveNumbers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Farsi
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool FixTags
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ForceFix
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected void Update()
		{
		}

		public void UpdateText()
		{
		}

		private string GetFixedText(string input)
		{
			return null;
		}
	}
}
