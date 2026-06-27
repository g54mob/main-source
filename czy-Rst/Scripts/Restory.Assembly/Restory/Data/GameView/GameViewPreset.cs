using Restory.Gameplay.GameView;
using UnityEngine;

namespace Restory.Data.GameView
{
	[CreateAssetMenu(fileName = "GameViewPreset", menuName = "Restory/GameViewPreset")]
	public class GameViewPreset : ScriptableObject
	{
		public Vector3 cameraPosition;

		public float cameraFieldOfView;

		public CameraDirection cameraDirection;

		public Vector3 lightPosition;

		public Quaternion lightRotation;

		public Vector3 binPosition;

		public Quaternion binRotation;

		public Vector3 cleanerPosition;

		public Quaternion cleanerRotation;

		public Vector3 notePosition;

		public Quaternion noteRotation;

		public Vector3 tabletPosition;

		public Quaternion tabletRotation;

		public Vector3 inventoryPosition;

		public Quaternion inventoryRotation;

		public Vector3 trashCanPosition;

		public Quaternion trashCanRotation;
	}
}
