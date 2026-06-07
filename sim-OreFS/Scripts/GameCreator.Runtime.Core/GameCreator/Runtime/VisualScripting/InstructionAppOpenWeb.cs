using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Open Web Page")]
	[Description("Opens the specified URL with the default web browser")]
	[Category("Application/Open Web Page")]
	[Parameter("URL", "The route link to open. Must include the protocol prepended (http or https)")]
	[Keywords(new string[] { "Site", "Internet" })]
	[Image(typeof(IconWeb), ColorTheme.Type.Yellow)]
	public class InstructionAppOpenWeb : Instruction
	{
		private const string DEF = "https://gamecreator.io";

		[SerializeField]
		private PropertyGetString m_URL = new PropertyGetString("https://gamecreator.io");

		public override string Title => $"Open Browser URL: {m_URL}";

		protected override Task Run(Args args)
		{
			Application.OpenURL(m_URL.Get(args));
			return Instruction.DefaultResult;
		}
	}
}
