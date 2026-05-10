using UnityEngine;

namespace PG
{
	[CreateAssetMenu(fileName = "ResourcesSettings", menuName = "GameBalance/Settings/ResourcesSettings")]
	public class ResourcesSettings : ScriptableObject
	{
		public PlayerController PlayerControllerPrefab;

		public PlayerController PlayerControllerPrefab_ForMobile;

		public Camera UVCMainCamera;

		public GroundDetection DefaultGroundDetection;
	}
}
