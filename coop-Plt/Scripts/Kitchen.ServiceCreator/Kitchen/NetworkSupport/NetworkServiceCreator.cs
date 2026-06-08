using UnityEngine;

namespace Kitchen.NetworkSupport
{
	public class NetworkServiceCreator : MonoBehaviour
	{
		private void Awake()
		{
			CreateService<PhotonNetworkService>();
			CreateService<SteamNetworkService>();
		}

		private T CreateService<T>() where T : MonoBehaviour, INetworkService
		{
			GameObject obj = new GameObject();
			obj.transform.SetParent(base.transform);
			T val = obj.AddComponent<T>();
			obj.gameObject.name = val.GetType().Name;
			return val;
		}
	}
}
