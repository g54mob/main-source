using System.Collections;
using ModIO.Util;
using ModIOBrowser.Implementation;
using UnityEngine;

namespace Plugins.mod.io.UI.Examples
{
	public class ExampleGlyphSetter : MonoBehaviour
	{
		private bool connected;

		private void Awake()
		{
			StartCoroutine(CheckForControllers());
		}

		private IEnumerator CheckForControllers()
		{
			while (true)
			{
				string[] joystickNames = Input.GetJoystickNames();
				if (!connected && joystickNames.Length != 0)
				{
					connected = true;
					if (joystickNames[0].Contains("Microsoft"))
					{
						SelfInstancingMonoSingleton<Glyphs>.Instance.ChangeGlyphs(GlyphPlatforms.XBOX);
					}
					else if (joystickNames[0].Contains("Sony"))
					{
						SelfInstancingMonoSingleton<Glyphs>.Instance.ChangeGlyphs(GlyphPlatforms.PLAYSTATION_5);
					}
					else if (joystickNames[0].Contains("Nintendo"))
					{
						SelfInstancingMonoSingleton<Glyphs>.Instance.ChangeGlyphs(GlyphPlatforms.NINTENDO_SWITCH);
					}
					Debug.Log("Connected");
				}
				else if (connected && joystickNames.Length == 0)
				{
					connected = false;
					SelfInstancingMonoSingleton<Glyphs>.Instance.ChangeGlyphs(GlyphPlatforms.PC);
					Debug.Log("Disconnected");
				}
				yield return new WaitForSeconds(1f);
			}
		}
	}
}
