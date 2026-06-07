using System;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI
{
	public class TouchControlCustomiser : MonoBehaviour
	{
		[Serializable]
		public class TouchControlPrefabDictionary : UnitySerializedDictionary<VisibleJoystickType, GameObject>
		{
		}

		[SerializeField]
		private TouchControlPrefabDictionary _joystickPrefabs;

		public void SetupJoystick(PlayerOptions playerOptions)
		{
		}
	}
}
