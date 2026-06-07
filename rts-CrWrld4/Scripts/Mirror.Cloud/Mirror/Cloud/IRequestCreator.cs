using System.Collections;
using UnityEngine.Networking;

namespace Mirror.Cloud
{
	public interface IRequestCreator
	{
		UnityWebRequest Delete(string page);

		UnityWebRequest Get(string page);

		UnityWebRequest Patch<T>(string page, T json) where T : struct, ICanBeJson;

		UnityWebRequest Post<T>(string page, T json) where T : struct, ICanBeJson;

		void SendRequest(UnityWebRequest request, RequestSuccess onSuccess = null, RequestFail onFail = null);

		IEnumerator SendRequestEnumerator(UnityWebRequest request, RequestSuccess onSuccess = null, RequestFail onFail = null);
	}
}
