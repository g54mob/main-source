using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "CameraManagers", menuName = "CTS/Camera/Managers")]
	public class SOCameraManagersParameters : ScriptableObject
	{
		[SerializeField]
		[Expandable]
		public List<SOCameraParemeters> Parameters;
	}
}
