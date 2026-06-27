using Restory.Data.GameView;
using UnityEngine;

namespace Restory.Gameplay.GameView
{
	public class GameViewPresetRecorder : MonoBehaviour
	{
		[Header("Game View")]
		[SerializeField]
		private Camera gameCamera;

		[SerializeField]
		private DeviceSpotLight deviceSpotLight;

		[Header("Equipment")]
		[SerializeField]
		private GameObject smallElementBin;

		[SerializeField]
		private GameObject elementCleaner;

		[SerializeField]
		private GameObject note;

		[SerializeField]
		private GameObject tablet;

		[SerializeField]
		private GameObject inventory;

		[Header("Preset File")]
		[SerializeField]
		private GameViewPreset gameViewPreset;

		public void RecordPreset()
		{
			if (!gameViewPreset)
			{
				Debug.LogError("gameViewPreset is not assigned!");
				return;
			}
			if (!gameCamera)
			{
				Debug.LogError("gameCamera is not assigned!");
				return;
			}
			if (!deviceSpotLight)
			{
				Debug.LogError("deviceSpotLight is not assigned!");
				return;
			}
			if (!smallElementBin)
			{
				Debug.LogError("smallElementBin is not assigned!");
				return;
			}
			if (!elementCleaner)
			{
				Debug.LogError("elementCleaner is not assigned!");
				return;
			}
			if (!note)
			{
				Debug.LogError("note is not assigned!");
				return;
			}
			if (!tablet)
			{
				Debug.LogError("tablet is not assigned!");
				return;
			}
			if (!inventory)
			{
				Debug.LogError("inventory is not assigned!");
				return;
			}
			gameViewPreset.cameraPosition = gameCamera.transform.position;
			gameViewPreset.cameraFieldOfView = gameCamera.fieldOfView;
			gameViewPreset.lightPosition = deviceSpotLight.transform.position;
			gameViewPreset.lightRotation = deviceSpotLight.transform.rotation;
			gameViewPreset.binPosition = smallElementBin.transform.position;
			gameViewPreset.binRotation = smallElementBin.transform.rotation;
			gameViewPreset.cleanerPosition = elementCleaner.transform.position;
			gameViewPreset.cleanerRotation = elementCleaner.transform.rotation;
			gameViewPreset.notePosition = note.transform.position;
			gameViewPreset.noteRotation = note.transform.rotation;
			gameViewPreset.tabletPosition = tablet.transform.position;
			gameViewPreset.tabletRotation = tablet.transform.rotation;
			gameViewPreset.inventoryPosition = inventory.transform.position;
			gameViewPreset.inventoryRotation = inventory.transform.rotation;
			Debug.Log("Preset saved successfully!");
		}
	}
}
