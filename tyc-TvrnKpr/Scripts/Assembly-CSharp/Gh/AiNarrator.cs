using System;
using Gh.Tk;
using UnityEngine.InputSystem;

namespace Gh
{
	public static class AiNarrator
	{
		private static bool isProcessing;

		public static void Init()
		{
		}

		private static void PlayAiSpeech(InputAction.CallbackContext obj)
		{
		}

		public static void PlayLocalFile(string file, Action callback)
		{
		}

		public static string GetAiNarratorVoice(TkWebService.AiVoice voiceType)
		{
			return null;
		}

		public static string GetAiFallbackHash(string content, TkWebService.AiVoice voice, string style)
		{
			return null;
		}

		public static void PlaySpeech(string content, TkWebService.AiVoice voice, string style)
		{
		}
	}
}
