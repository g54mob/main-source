using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Restory.Data.GUIControllerElements
{
	[Preserve]
	[CreateAssetMenu(menuName = "Restory/Controllers/GUI/GuiControllerTemplateList", fileName = "New GuiControllerTemplateList")]
	public sealed class GuiControllerTemplateList : ScriptableObject
	{
		[SerializeField]
		private GuiKeyboardTemplate keypoard;

		[SerializeField]
		private GuiMouseTemplate mouse;

		[SerializeField]
		private GuiBaseGamepadTemplate defaultGamepad;

		[SerializeField]
		private List<GuiBaseGamepadTemplate> gamepads = new List<GuiBaseGamepadTemplate>();

		private Dictionary<string, IGuiControllerTemplate> controllersCache;

		public IGuiKeyboardTemplate Keyboard => keypoard;

		public IGuiMouseTemplate Mouse => mouse;

		public IGuiGamepadTemplate DefaultGamepad => defaultGamepad;

		public IReadOnlyCollection<IGuiControllerTemplate> Gamepads => gamepads;

		private void CreateCache()
		{
			if (controllersCache != null)
			{
				return;
			}
			controllersCache = new Dictionary<string, IGuiControllerTemplate>();
			controllersCache[keypoard.ControllerId.ID] = keypoard;
			controllersCache[mouse.ControllerId.ID] = mouse;
			foreach (GuiBaseGamepadTemplate gamepad in gamepads)
			{
				controllersCache[gamepad.ControllerId.ID] = gamepad;
			}
		}

		public bool TryGetGuiControllerTemplate(ControllerId controllerId, out IGuiControllerTemplate template)
		{
			return TryGetGuiControllerTemplate(controllerId.ID, out template);
		}

		public bool TryGetGuiControllerTemplate(string controllerId, out IGuiControllerTemplate template)
		{
			CreateCache();
			return controllersCache.TryGetValue(controllerId, out template);
		}
	}
}
