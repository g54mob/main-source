using System;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Common.UnityUI;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Text")]
	[Image(typeof(IconString), ColorTheme.Type.Yellow)]
	[Category("UI/Change Text")]
	[Description("Changes the chosen Text value")]
	public class SpotChangeText : Spot
	{
		[SerializeField]
		protected PropertySetString m_Change = SetStringUIText.Create;

		[SerializeField]
		protected PropertyGetString m_Text = new PropertyGetString();

		public override string Title => $"Set {m_Change} = {m_Text}";

		public override void OnEnable(Hotspot hotspot)
		{
			base.OnEnable(hotspot);
			string value = m_Text.Get(hotspot.Args);
			m_Change.Set(value, hotspot.Args);
		}
	}
}
