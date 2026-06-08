using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public abstract class ProfileEditorSubmenu : Menu<ProfileMenuAction>
	{
		protected int PlayerID;

		protected ProfileEditorSubmenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
			DefaultElementSize = new Vector2(2.5f, 0.35f);
			module_list.Padding = 0.05f;
		}

		public void SetupWithPlayer(int player_id)
		{
			PlayerID = player_id;
			Setup(PlayerID);
		}
	}
}
