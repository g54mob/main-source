using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Restory.Data.GUIControllerElements
{
	[Preserve]
	[CreateAssetMenu(menuName = "Restory/Controllers/GUI/GuiControllerSchemeList", fileName = "New GuiControllerSchemeList")]
	public sealed class GuiControllerSchemeList : ScriptableObject
	{
		[SerializeField]
		private GuiControllerScheme keypoardScheme;

		[SerializeField]
		private GuiControllerScheme mouseScheme;

		[SerializeField]
		private GuiControllerScheme defaultGamepadScheme;

		[SerializeField]
		private List<GuiControllerScheme> gamepadSchemes = new List<GuiControllerScheme>();

		private Dictionary<string, GuiControllerScheme> controllersCache;

		public GuiControllerScheme KeyboardScheme => keypoardScheme;

		public GuiControllerScheme MouseScheme => mouseScheme;

		public GuiControllerScheme DefaultGamepadScheme => defaultGamepadScheme;

		public IReadOnlyCollection<GuiControllerScheme> GamepadSchemes => gamepadSchemes;

		private void CreateCache()
		{
			if (controllersCache != null)
			{
				return;
			}
			controllersCache = new Dictionary<string, GuiControllerScheme>();
			controllersCache[keypoardScheme.ControllerId.ID] = keypoardScheme;
			controllersCache[mouseScheme.ControllerId.ID] = mouseScheme;
			foreach (GuiControllerScheme gamepadScheme in gamepadSchemes)
			{
				controllersCache[gamepadScheme.ControllerId.ID] = gamepadScheme;
			}
		}

		public bool TryGetGuiControllerScheme(ControllerId controllerId, out GuiControllerScheme scheme)
		{
			return TryGetGuiControllerScheme(controllerId.ID, out scheme);
		}

		public bool TryGetGuiControllerScheme(string controllerId, out GuiControllerScheme scheme)
		{
			CreateCache();
			return controllersCache.TryGetValue(controllerId, out scheme);
		}
	}
}
