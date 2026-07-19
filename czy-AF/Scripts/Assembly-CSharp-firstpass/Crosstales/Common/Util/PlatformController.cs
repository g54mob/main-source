using System.Collections.Generic;
using System.Linq;
using Crosstales.Common.Model.Enum;
using UnityEngine;

namespace Crosstales.Common.Util
{
	public class PlatformController : MonoBehaviour
	{
		[Header("Configuration")]
		[Tooltip("Selected platforms for the controller.")]
		public List<Platform> Platforms;

		[Tooltip("Enable or disable the 'Objects' for the selected 'Platforms' (default: true).")]
		public bool Active = true;

		[Header("Objects")]
		[Tooltip("Selected objects for the controller.")]
		public GameObject[] Objects;

		protected Platform currentPlatform;

		public virtual void Start()
		{
			selectPlatform();
		}

		protected void selectPlatform()
		{
			currentPlatform = BaseHelper.CurrentPlatform;
			activateGO();
		}

		protected void activateGO()
		{
			bool active = (Platforms.Contains(currentPlatform) ? Active : (!Active));
			foreach (GameObject item in Objects.Where((GameObject go) => go != null))
			{
				item.SetActive(active);
			}
		}
	}
}
