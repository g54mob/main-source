using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Owl15k : Shape
	{
		public Owl15k()
		{
			LoadDataFromFile("Assets/GeometryAlgorithms/Examples/Data/Shapes/2D/Owl15k.txt");
			base.CameraPoint = new Vector3(325f, 530f, -820f);
			base.CameraRotation = Quaternion.Euler(0f, 0f, 180f);
		}
	}
}
