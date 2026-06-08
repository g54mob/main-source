using System;
using System.Threading.Tasks;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP
{
	public class AlertPage : Page
	{
		[TextCrew]
		public string message;

		[TextCrew]
		public string okText;

		private Action callback;

		public AlertPage(string message)
		{
		}

		public AlertPage(string message, Action callback)
		{
		}

		protected override void OnPageRemoved()
		{
		}

		[CrewMethod]
		public void Ok()
		{
		}

		public static Task Show(Context context, string message)
		{
			return null;
		}

		public static void Show(Context context, string message, Action callback)
		{
		}
	}
}
