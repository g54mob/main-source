using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Rhizomatic.Langer
{
	public class LangerManager : MonoBehaviour
	{
		public LangerLanguage language;

		public LangerSource[] soruces;

		public static LangerManager instance { get; private set; }

		public event Action onLanguageChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		public void SetLanguage(LangerLanguage language)
		{
		}
	}
}
