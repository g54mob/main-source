using System;
using DV.Common;

namespace DV.UI.PresetEditors
{
	public class PresetSelectorLogicSession : PresetSelectorLogic<IGameSession>
	{
		protected override string LOC_NO_ELEMENTS => "session/session_selector_no_sessions";

		protected override string LOC_SAVE_OR_REVERT_PROMPT
		{
			get
			{
				throw new NotImplementedException("Reverting Sessions is not supported");
			}
		}

		protected override string ProcessName(IGameSession thing)
		{
			return thing.Name;
		}
	}
}
