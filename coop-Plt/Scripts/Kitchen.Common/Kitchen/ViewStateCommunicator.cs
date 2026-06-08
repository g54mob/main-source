using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
	public class ViewStateCommunicator : MonoBehaviour
	{
		public HashSet<MonoBehaviour> Popups = new HashSet<MonoBehaviour>();

		public static ViewStateCommunicator Main;

		private void Start()
		{
			Main = this;
		}

		private void Update()
		{
			Popups.RemoveWhere((MonoBehaviour p) => p == null);
		}

		public bool HasPopup()
		{
			return Popups.Count > 0;
		}

		public void AddPopup(MonoBehaviour popup)
		{
			Popups.Add(popup);
		}

		public void RemovePopup(MonoBehaviour popup)
		{
			Popups.Remove(popup);
		}
	}
}
