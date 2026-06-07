using UnityEngine;

namespace VampireSurvivors.Framework.Platforms
{
	public class NintendoSwitchRewiredLayoutHelper : MonoBehaviour
	{
		[SerializeField]
		private string _MapCategory;

		[SerializeField]
		private string _NormalLayout;

		[SerializeField]
		private string _SwitchLayout;

		private static string s_MapCategory;

		private static string s_NormalLayout;

		private static string s_SwitchLayout;
	}
}
