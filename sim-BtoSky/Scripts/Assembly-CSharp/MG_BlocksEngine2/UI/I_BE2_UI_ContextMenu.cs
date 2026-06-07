using MG_BlocksEngine2.Utils;

namespace MG_BlocksEngine2.UI
{
	public interface I_BE2_UI_ContextMenu
	{
		BE2_Text Title { get; }

		void Open<T>(T target, params string[] options);

		void Close();
	}
}
