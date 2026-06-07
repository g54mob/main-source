using Reactivity.Unity.Components;
using UnityEngine;

namespace FractureField.UI.CommandConsole
{
	public class CommandConsoleTabContent : RComponent, ICommandConsoleTab
	{
		[Header("Values")]
		[SerializeField]
		private string _tabTitle;

		[Header("References")]
		[SerializeField]
		protected CommandConsoleTabs _tabs;

		public virtual string TabTitle
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool HasAwoken { get; private set; }

		protected override void Awake()
		{
		}
	}
}
