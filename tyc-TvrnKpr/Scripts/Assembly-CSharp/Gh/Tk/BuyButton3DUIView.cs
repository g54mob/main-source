using System;
using Pixeye.Unity;
using UnityEngine;

namespace Gh.Tk
{
	public class BuyButton3DUIView : Button3DUIView
	{
		public Func<bool> canAffordCheck;

		private static readonly int _canAffordAnimatorHash;

		private bool _canAfford;

		[Foldout("Colour Changer", false)]
		public Color cantAffordColor;

		[Foldout("Colour Changer", false)]
		public Color cantAffordEmission;

		public virtual bool CanAfford
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override void CheckState()
		{
		}

		protected override void UpdateColourChanger()
		{
		}

		protected override void UpdateAnimatorValues()
		{
		}
	}
}
