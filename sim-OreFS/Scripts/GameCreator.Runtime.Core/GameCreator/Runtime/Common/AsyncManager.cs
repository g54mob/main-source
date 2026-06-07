using System.Threading;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public class AsyncManager : Singleton<AsyncManager>
	{
		private CancellationTokenSource ExitToken { get; set; }

		public static bool ExitRequest
		{
			get
			{
				if (!(Singleton<AsyncManager>.Instance == null))
				{
					return Singleton<AsyncManager>.Instance.ExitToken.IsCancellationRequested;
				}
				return true;
			}
		}

		protected override void OnCreate()
		{
			base.OnCreate();
			ExitToken = new CancellationTokenSource();
		}

		private void OnApplicationQuit()
		{
			ExitToken?.Cancel();
		}
	}
}
