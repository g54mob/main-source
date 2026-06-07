using System.Collections.Generic;
using Crosstales.Common.Model.Enum;
using UnityEngine;

namespace Crosstales.Common.Util
{
	public class PlatformController : MonoBehaviour
	{
		public List<Platform> Platforms;

		public bool Active;

		public GameObject[] Objects;

		public MonoBehaviour[] Scripts;

		protected Platform currentPlatform;

		protected virtual void Awake()
		{
		}

		private void Start()
		{
		}

		protected void selectPlatform()
		{
		}

		protected void activateGameObjects()
		{
		}

		protected void activateScripts()
		{
		}
	}
}
