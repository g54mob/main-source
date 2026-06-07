using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class UIGuideElement : MonoBehaviour
	{
		private static Dictionary<string, List<GameObject>> _elements;

		private static string _currentGuideId;

		public string guideId;

		private bool _isRegistered;

		public static void EnableGuide(string guideId)
		{
		}

		public static void DisableGuide()
		{
		}

		public static void DisableGuide(string guideId)
		{
		}

		public static void DisableAllGuides()
		{
		}

		public static void RegisterAllElements()
		{
		}

		public void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Register()
		{
		}
	}
}
