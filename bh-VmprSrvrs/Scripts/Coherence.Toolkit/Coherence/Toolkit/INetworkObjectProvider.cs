using System;

namespace Coherence.Toolkit
{
	public interface INetworkObjectProvider
	{
		void LoadAsset(string networkAssetId, Action<ICoherenceSync> onLoaded);

		ICoherenceSync LoadAsset(string networkAssetId);

		void Release(ICoherenceSync obj);

		void OnApplicationQuit();

		void Initialize(CoherenceSyncConfig entry);

		bool Validate(CoherenceSyncConfig entry);
	}
}
