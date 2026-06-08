using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Tank : Shape
	{
		public Tank()
		{
			LoadDataFromFile("Assets/GeometryAlgorithms/Examples/Data/Shapes/2D/Tank.txt");
			base.CameraPoint = new Vector3(375f, 0f, -600f);
			base.CameraRotation = new Quaternion(0f, 0f, 0f, 1f);
		}
	}
}
