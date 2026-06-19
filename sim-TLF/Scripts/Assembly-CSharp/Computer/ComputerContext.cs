using System;
using Michsky.DreamOS;
using UnityEngine;

namespace Computer
{
	[Obsolete]
	public class ComputerContext : MonoBehaviour
	{
		[SerializeField]
		private WebBrowserManager _webBrowserManager;

		[SerializeField]
		private CommanderManager _commanderManager;

		[SerializeField]
		private MailManager _mailManager;

		public WebBrowserManager WebBrowserManager => _webBrowserManager;

		public CommanderManager CommanderManager => _commanderManager;

		public MailManager MailManager => _mailManager;
	}
}
