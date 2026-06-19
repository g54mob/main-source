using System;
using System.Threading.Tasks;
using ModIO.Implementation.Wss.Messages;
using ModIO.Implementation.Wss.Messages.Objects;

namespace ModIO.Implementation.Wss
{
	internal static class Wss
	{
		public static async Task<ResultAnd<ExternalAuthenticationToken>> BeginAuthenticationProcess(bool restartProcess = false)
		{
			ResultAnd<WssDeviceLoginResponse> resultAnd = await WssHandler.DoMessageHandshake<WssDeviceLoginResponse>(WssRequest.DeviceLogin());
			if (!resultAnd.result.Succeeded())
			{
				return ResultAnd.Create(resultAnd.result, default(ExternalAuthenticationToken));
			}
			Task<Result> task = WaitForAccessToken();
			ExternalAuthenticationToken value = new ExternalAuthenticationToken
			{
				code = resultAnd.value.code,
				url = resultAnd.value.login_url,
				autoUrl = resultAnd.value.login_url,
				expiryTime = DateTimeOffset.FromUnixTimeSeconds(resultAnd.value.date_expires).DateTime,
				task = task,
				cancel = delegate
				{
					WssHandler.CancelWaitingFor("login_success");
				}
			};
			return ResultAnd.Create(ResultBuilder.Success, value);
		}

		private static async Task<Result> WaitForAccessToken()
		{
			ResultAnd<WssMessage> resultAnd = await WssHandler.WaitForMessage("login_success");
			Result result = resultAnd.result;
			if (result.Succeeded())
			{
				if (resultAnd.value.TryGetValue<WssLoginSuccess>(out var output))
				{
					try
					{
						UserData.instance.SetOAuthToken(output);
						await ModIOUnityImplementation.GetCurrentUser(delegate
						{
						});
					}
					catch (Exception ex)
					{
						Logger.Log(LogLevel.Error, "Internal: Failed to deserialize user/token object from WssMessage and assign to UserData.\n" + ex.Message + "\nStacktrace: " + ex.StackTrace);
						result = ResultBuilder.Create(20501u);
					}
				}
				else
				{
					result = ResultBuilder.Create(20603u);
				}
			}
			WssHandler.Shutdown();
			return result;
		}
	}
}
