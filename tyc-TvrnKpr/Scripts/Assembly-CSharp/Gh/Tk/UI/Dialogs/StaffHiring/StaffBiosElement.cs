using System;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.StaffHiring
{
	public class StaffBiosElement : MonoBehaviour
	{
		private Actor _actor;

		[SerializeField]
		private TextBlock3DUIView _text;

		[SerializeField]
		private BaseInteractable3DUIView _ellipsisFallbackTooltipProvider;

		public Actor Actor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void UpdateTexts()
		{
		}

		private void OnEnable()
		{
		}

		private string GetUnlocalizedText()
		{
			return null;
		}

		private void UpdateTooltipState()
		{
		}

		private void Awake()
		{
		}

		private void OnLanguageChanged(object sender, EventArgs e)
		{
		}
	}
}
