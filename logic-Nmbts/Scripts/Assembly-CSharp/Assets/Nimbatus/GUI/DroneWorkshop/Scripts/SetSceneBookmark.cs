using Assets.Nimbatus.Scripts.Common.LevelTransition;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class SetSceneBookmark : MonoBehaviour
	{
		public void OnClick()
		{
			NimbatusSceneManager.BookmarkActiveScene();
		}
	}
}
