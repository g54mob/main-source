using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Examples.Data
{
	public class Square : Shape
	{
		public Square()
		{
			base.Points = CreateSquare(1f);
			base.CameraPoint = new Vector3(0f, 0f, -10f);
			base.CameraRotation = new Quaternion(0f, 0f, 0f, 1f);
		}

		protected Vector3[] CreateSquare(float scale)
		{
			return new Vector3[4]
			{
				new Vector3(0.5f * scale, 0.5f * scale),
				new Vector3(0.5f * scale, -0.5f * scale),
				new Vector3(-0.5f * scale, -0.5f * scale),
				new Vector3(-0.5f * scale, 0.5f * scale)
			};
		}
	}
}
