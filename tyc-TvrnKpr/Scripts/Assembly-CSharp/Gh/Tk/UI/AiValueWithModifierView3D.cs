using System;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class AiValueWithModifierView3D : AiComponent3DUIView
	{
		public Transform starsContainer;

		[SerializeField]
		private TraitsContainer3DUIView _traitsContainer;

		public new AiValueWithModifiers SourceValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float BonusMalus
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void OnEffectiveValueChanged(object sender, EventArgs e)
		{
		}

		protected override void RefreshValues()
		{
		}
	}
}
