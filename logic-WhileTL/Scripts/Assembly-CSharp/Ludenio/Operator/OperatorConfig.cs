using System;
using UnityEngine;

namespace Ludenio.Operator
{
	public class OperatorConfig
	{
		public Sprite Sprite;

		public string Title;

		public string URL;

		public string Version;

		public DateTime NextDate = DateTime.MinValue;

		public bool IsNextDateInFuture => NextDate > DateTime.Now;

		public TimeSpan GetRemainingTimespan()
		{
			return NextDate - DateTime.Now;
		}

		public string GetRemainingTimeString()
		{
			return GetRemainingTimespan().ToString("d\\d\\ hh\\:mm\\:ss");
		}
	}
}
