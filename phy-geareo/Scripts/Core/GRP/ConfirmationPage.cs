using System;
using System.Threading.Tasks;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP
{
	public class ConfirmationPage : Page
	{
		[TextCrew]
		public string message;

		private Action confirm;

		private Action cancel;

		private bool confirmed;

		public ConfirmationPage(string message, Action confirm, Action cancel = null)
		{
		}

		protected override void OnPageRemoved()
		{
		}

		[CrewMethod]
		public void Confirm()
		{
		}

		[CrewMethod]
		public void Cancel()
		{
		}

		public static Task<bool> Ask(Context context, string message)
		{
			return null;
		}

		public static void Ask(Context context, string message, Action confirm, Action cancel = null)
		{
		}
	}
}
