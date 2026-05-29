using CTS.BBT.AI;
using CTS.Emotes;
using UnityEngine.Localization;

namespace CTS
{
	public static class Barks
	{
		public static void BarkAgent(Agent agent, string text, float duration = 3f)
		{
			if ((bool)agent)
			{
				EmoteManagerBBT.Play(agent, text).SetStayDuration(duration);
			}
		}

		public static void KillBark(Agent agent)
		{
			if ((bool)agent)
			{
				EmoteManagerBBT.Kill(agent);
			}
		}

		public static void BarkAgent(Agent agent, LocalizedString text, float duration = 3f)
		{
			BarkAgent(agent, text.GetLocalizedString(), duration);
		}

		public static void BarkAnyWorker(string text, float duration = 3f)
		{
			if (WorkerList.TryGet(out var outWorker))
			{
				BarkAgent(outWorker, text, duration);
			}
		}

		public static void BarkAnyWorker(LocalizedString text, float duration = 3f)
		{
			BarkAnyWorker(text.GetLocalizedString(), duration);
		}

		public static void BarkAnyHumanCustomer(string text, float duration = 3f)
		{
			if (CustomerManager.TryGetAnyHumanInBar(out var outCustomer))
			{
				BarkAgent(outCustomer, text, duration);
			}
		}

		public static void BarkAnyHumanCustomer(LocalizedString text, float duration = 3f)
		{
			BarkAnyVampireCustomer(text.GetLocalizedString(), duration);
		}

		public static void BarkAnyVampireCustomer(string text, float duration = 3f)
		{
			if (CustomerManager.TryGetAnyVampireInBar(out var outCustomer))
			{
				BarkAgent(outCustomer, text, duration);
			}
		}

		public static void BarkAnyVampireCustomer(LocalizedString text, float duration = 3f)
		{
			if (text != null)
			{
				BarkAnyVampireCustomer(text.GetLocalizedString(), duration);
			}
		}

		public static void BarkAnySpecificTypeCustomer(CustomerParameters customerParameters, string text, float duration = 3f)
		{
			if (CustomerManager.TryGetAnySpecificInBar(customerParameters, out var outCustomer))
			{
				BarkAgent(outCustomer, text, duration);
			}
		}

		public static void BarkAnySpecificTypeCustomer(CustomerParameters customerParameters, LocalizedString text, float duration = 3f)
		{
			BarkAnySpecificTypeCustomer(customerParameters, text.GetLocalizedString(), duration);
		}
	}
}
