using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;

namespace DV.Common
{
	public interface IUserProfile : IDisposable
	{
		string Name { get; }

		JObject GameData { get; }

		string Signature { get; }

		string UserBasePath { get; }

		string GameDataPath { get; }

		IGameSession CurrentSession { get; }

		Dictionary<string, ReadOnlyObservableCollection<IGameSession>> Sessions { get; }

		void Save(UserSavingMode savingMode = UserSavingMode.AllSessions);

		bool CanCreateNewSessions(string gameMode);
	}
}
