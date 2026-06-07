using System.Collections.Generic;
using AwesomeTechnologies.VegetationSystem;

namespace AwesomeTechnologies.Common
{
	public class SelectedVegetationCell
	{
		public readonly VegetationCell VegetationCell;

		public int CameraCount;

		private readonly List<VegetationStudioCamera> _vegetationStudioCameraList = new List<VegetationStudioCamera>();

		public SelectedVegetationCell(VegetationCell vegetationCell, VegetationStudioCamera vegetationStudioCamera)
		{
			VegetationCell = vegetationCell;
			CameraCount = 0;
			AddCameraReference(vegetationStudioCamera);
		}

		public void AddCameraReference(VegetationStudioCamera vegetationStudioCamera)
		{
			if (!_vegetationStudioCameraList.Contains(vegetationStudioCamera))
			{
				CameraCount++;
				_vegetationStudioCameraList.Add(vegetationStudioCamera);
			}
		}

		public void RemoveCameraReference(VegetationStudioCamera vegetationStudioCamera)
		{
			if (_vegetationStudioCameraList.Contains(vegetationStudioCamera))
			{
				_vegetationStudioCameraList.Remove(vegetationStudioCamera);
				CameraCount--;
			}
		}
	}
}
