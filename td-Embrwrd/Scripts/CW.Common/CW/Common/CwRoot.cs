using System.Collections.Generic;
using UnityEngine;

namespace CW.Common
{
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwRoot")]
	[DefaultExecutionOrder(-100)]
	[ExecuteInEditMode]
	[AddComponentMenu("Common/CW Root")]
	public class CwRoot : MonoBehaviour
	{
		private static List<CwRoot> instances;

		public static bool Exists => false;

		public static Transform Root => null;

		public static Transform GetRoot()
		{
			return null;
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
