using NSEipix.Base;
using TwitchIntegration;

namespace NSMedieval
{
	public class TwitchCommandListener : TwitchMonoBehaviour
	{
		[TwitchCommand("name", new string[] { })]
		public void TwitchNameCommand(TwitchUser user)
		{
			MonoSingleton<TwitchController>.Instance.TwitchNameCommand(user);
		}

		[TwitchCommand("appear", new string[] { })]
		public void AnimalAppearCommand(TwitchUser user)
		{
			MonoSingleton<TwitchController>.Instance.AnimalAppearCommand(user);
		}

		[TwitchCommand("gift", new string[] { })]
		public void MysteryGiftCommand(TwitchUser user)
		{
			MonoSingleton<TwitchController>.Instance.MysteryGiftCommand(user);
		}

		[TwitchCommand("strike", new string[] { })]
		public void StrikeCommand(TwitchUser user)
		{
			MonoSingleton<TwitchController>.Instance.StrikeCommand(user);
		}
	}
}
