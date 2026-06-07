using System.Collections.Generic;
using Reactivity;
using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.CommandConsole
{
	public class CommandConsoleTabs : RComponent
	{
		[Header("Variables")]
		[SerializeField]
		private bool _setFirstTabAsActive;

		[Header("References")]
		[SerializeField]
		private List<CommandConsoleTab> _tabs;

		[SerializeField]
		private List<CommandConsoleTabContent> _tabContents;

		public RString ActiveTab { get; }

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}
	}
}
