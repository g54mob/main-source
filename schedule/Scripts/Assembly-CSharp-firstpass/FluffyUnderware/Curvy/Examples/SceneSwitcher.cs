using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace FluffyUnderware.Curvy.Examples
{
	public class SceneSwitcher : MonoBehaviour
	{
		public Text Text;

		public Dropdown DropDown;

		private Dictionary<string, string> scenesAlternativeNames;

		private int CurrentLevel
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[UsedImplicitly]
		private void Start()
		{
		}

		private List<string> getScenes()
		{
			return null;
		}

		private void OnValueChanged(int value)
		{
		}
	}
}
