using System;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors
{
	public class HelpButton : MonoBehaviour
	{
		public static HelpButton Instance;

		private Button _button;

		private void Awake()
		{
		}

		public static void AddCallback(Action cb)
		{
		}

		public static void Clear()
		{
		}

		public static void SetNavigation(Selectable left, Selectable right, Selectable up, Selectable down)
		{
		}
	}
}
