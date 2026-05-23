using Presentation.Locators;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Camera", fileName = "CameraPersistentSO", order = 0)]
	public class CameraPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			CameraSaveData cameraSaveData = saveData as CameraSaveData;
			_cameraViewLocator.CameraView.LerpToTarget(cameraSaveData.Pos, cameraSaveData.Zoom, cameraSaveData.Yaw, cameraSaveData.Pitch, blockInput: true);
		}

		public override void ResetToDefaults()
		{
		}

		public override AbstractSaveData GetSaveData()
		{
			Vector3 pos = new Vector3(_cameraViewLocator.CameraView.transform.position.x, _cameraViewLocator.CameraView.transform.position.y, _cameraViewLocator.CameraView.transform.position.z);
			float currentZoomPercentage = _cameraViewLocator.CameraView.CurrentZoomPercentage;
			float originYawRotation = _cameraViewLocator.CameraView.OriginYawRotation;
			float cameraPitchRotation = _cameraViewLocator.CameraView.CameraPitchRotation;
			return new CameraSaveData(pos, currentZoomPercentage, originYawRotation, cameraPitchRotation);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<CameraSaveData>(fullPath);
		}
	}
}
