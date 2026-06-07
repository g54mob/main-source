using System.Collections;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public class GameUISetup : MonoBehaviour
	{
		public GameObject vr;

		public GameObject nonVR;

		public GameObject common;

		private IEnumerator Start()
		{
			if (VRManager.IsVREnabled())
			{
				yield return null;
				vr.SetActive(value: true);
				SingletonBehaviour<CursorManager>.Instance.RequestCursor(this, visible: true, int.MaxValue);
			}
			else
			{
				nonVR.SetActive(value: true);
			}
			common.SetActive(value: true);
		}
	}
}
