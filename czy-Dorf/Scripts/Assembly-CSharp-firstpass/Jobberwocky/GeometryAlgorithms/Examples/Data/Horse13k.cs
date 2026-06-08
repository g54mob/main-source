using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Horse13k : Shape
	{
		public Horse13k()
		{
			LoadDataFromFile("Assets/GeometryAlgorithms/Examples/Data/Shapes/2D/Horse13k.txt");
			base.CameraPoint = new Vector3(375f, 400f, -700f);
			base.CameraRotation = Quaternion.Euler(0f, 0f, 180f);
		}
	}
}
