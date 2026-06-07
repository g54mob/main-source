using UnityEngine;

namespace ModApi.Craft.Program.Craft
{
	public interface ILineWidget
	{
		float Length { get; set; }

		float Thickness { get; set; }

		void SetLineEndPoints(Vector3 pointA, Vector3 pointB);
	}
}
