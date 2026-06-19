using System;
using UnityEngine;

namespace TH20.UI
{
	[AddComponentMenu("UI/Progress Bar Comparable", 101)]
	public class ProgressBarMaskableComparable : MonoBehaviour, IComparable<ProgressBarMaskableComparable>, IComparable
	{
		private const float SortPrecision = 0.01f;

		[SerializeField]
		private ProgressBarMaskable _progressBar;

		public ProgressBarMaskable ProgressBar
		{
			get
			{
				return _progressBar;
			}
			set
			{
				_progressBar = value;
			}
		}

		public int CompareTo(ProgressBarMaskableComparable other)
		{
			if (other != null && other.ProgressBar != null)
			{
				int num = Mathf.RoundToInt(ProgressBar.Progress / 0.01f);
				int num2 = Mathf.RoundToInt(other.ProgressBar.Progress / 0.01f);
				if (num != num2)
				{
					return num.CompareTo(num2);
				}
				return _progressBar.GetInstanceID().CompareTo(other.ProgressBar.GetInstanceID());
			}
			return 1;
		}

		public int CompareTo(object obj)
		{
			ProgressBarMaskableComparable progressBarMaskableComparable = obj as ProgressBarMaskableComparable;
			if (!(progressBarMaskableComparable != null))
			{
				return 1;
			}
			return CompareTo(progressBarMaskableComparable);
		}
	}
}
