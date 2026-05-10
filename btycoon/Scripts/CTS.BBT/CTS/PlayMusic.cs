using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class PlayMusic : CTSBehaviour
	{
		private enum EMusicType
		{
			Menu = 0,
			Bar = 1,
			SelectionMap = 2
		}

		[SerializeField]
		private EMusicType _musicType;

		private void Start()
		{
			switch (_musicType)
			{
			case EMusicType.Menu:
				MonoSingleton<MusicManager>.Instance.PlayMenuMusic();
				break;
			case EMusicType.Bar:
				MonoSingleton<MusicManager>.Instance.PlayBarMusic();
				break;
			case EMusicType.SelectionMap:
				MonoSingleton<MusicManager>.Instance.PlaySelectionMapMusic();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
