using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class CheckBox3DUIView : Button3DUIView
	{
		[SerializeField]
		private GameObject _checkMark;

		private bool _isChecked;

		public bool toggleCheckWhenClicked;

		[DropDownChoice(new string[] { "Play_CheckBox_Checked_Positive", "Play_CheckBox_Checked_Negative" })]
		public string onCheckedSound;

		[field: SerializeField]
		public CheckBoxVisualizer CheckBoxVisualizer { get; private set; }

		public bool IsChecked
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event EventHandler<EventArgs<bool>> CheckboxToggled
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Awake()
		{
		}

		public override void CheckState()
		{
		}

		protected override void OnEnable()
		{
		}

		private void SetState(bool isChecked, bool skipTransition)
		{
		}

		protected override void OnClickedInternal()
		{
		}

		public void SetCheckBoxWithNotify(bool isChecked)
		{
		}

		public void SetCheck(bool isChecked, bool skipTransition)
		{
		}
	}
}
