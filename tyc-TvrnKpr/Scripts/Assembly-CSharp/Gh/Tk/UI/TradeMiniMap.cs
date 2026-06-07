using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class TradeMiniMap : MonoBehaviour
	{
		[Serializable]
		public class MapRegion
		{
			public string regionId;

			public Transform regionLookAtMarker;

			public BaseInteractable3DUIView button;
		}

		[SerializeField]
		private ShowHideAnimation3DUIView _showHideAnimation;

		public List<MapRegion> regions;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnWorldMapStateChanged(object sender, EventArgs e)
		{
		}
	}
}
