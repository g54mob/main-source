using System;

namespace Coherence.Cloud
{
	internal interface IPlayerAccountProvider : IDisposable
	{
		bool IsReady => false;

		string ProjectId { get; }

		CloudUniqueId CloudUniqueId { get; }

		PlayerAccount GetPlayerAccount(LoginInfo loginInfo);
	}
}
