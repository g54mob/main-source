using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Bird : Shape
	{
		public Bird()
		{
			LoadDataFromFile("Assets/GeometryAlgorithms/Examples/Data/Shapes/2D/Bird.txt");
			base.CameraPoint = new Vector3(150f, 0f, -800f);
			base.CameraRotation = new Quaternion(0f, 0f, 0f, 1f);
		}
	}
}
