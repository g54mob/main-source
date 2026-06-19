using Cysharp.Threading.Tasks;

namespace Services.Save
{
	public interface ISaveable
	{
		string SaveKey { get; }

		int Priority { get; }

		void OnSave();

		UniTask OnLoad();
	}
}
