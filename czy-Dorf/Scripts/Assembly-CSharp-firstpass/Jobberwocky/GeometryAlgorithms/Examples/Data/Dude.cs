using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Dude : Shape
	{
		public Dude()
		{
			LoadDataFromFile("Assets/GeometryAlgorithms/Examples/Data/Shapes/2D/Dude.txt");
			base.CameraPoint = new Vector3(380f, 0f, -320f);
			base.CameraRotation = new Quaternion(0f, 0f, 0f, 1f);
		}
	}
}
