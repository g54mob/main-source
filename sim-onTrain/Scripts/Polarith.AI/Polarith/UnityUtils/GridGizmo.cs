using System;
using UnityEngine;

namespace Polarith.UnityUtils
{
	[Serializable]
	public sealed class GridGizmo
	{
		[Tooltip("Determines whether this gizmo is enabled.")]
		public bool Enabled = true;

		[Tooltip("If enabled, only the outer boundaries are visualized.")]
		public bool Outline;

		[Tooltip("The color of the drawn grid.")]
		public Color Color = new Color(1f, 47f / 51f, 0.015686275f, 10f / 51f);

		public void Draw(Vector3 center, float cellSizeX, float cellSizeY, float cellSizeZ, int cellCountX, int cellCountY, int cellCountZ)
		{
			if (!Enabled)
			{
				return;
			}
			cellCountX = Math.Abs(cellCountX);
			cellCountY = Math.Abs(cellCountY);
			cellCountZ = Math.Abs(cellCountZ);
			float num = cellSizeX * (float)cellCountX * 0.5f;
			float num2 = cellSizeY * (float)cellCountY * 0.5f;
			float num3 = cellSizeZ * (float)cellCountZ * 0.5f;
			Vector3 vector = new Vector3(-1f * num, 1f * num2, 1f * num3);
			Vector3 vector2 = new Vector3(1f * num, 1f * num2, 1f * num3);
			Vector3 vector3 = new Vector3(-1f * num, 1f * num2, -1f * num3);
			Vector3 vector4 = new Vector3(1f * num, 1f * num2, -1f * num3);
			Vector3 vector5 = new Vector3(-1f * num, -1f * num2, 1f * num3);
			Vector3 vector6 = new Vector3(1f * num, -1f * num2, 1f * num3);
			Vector3 vector7 = new Vector3(-1f * num, -1f * num2, -1f * num3);
			Vector3 vector8 = new Vector3(1f * num, -1f * num2, -1f * num3);
			Gizmos.color = Color;
			Gizmos.DrawLine(vector + center, vector2 + center);
			Gizmos.DrawLine(vector + center, vector3 + center);
			Gizmos.DrawLine(vector4 + center, vector3 + center);
			Gizmos.DrawLine(vector4 + center, vector2 + center);
			Gizmos.DrawLine(vector + center, vector5 + center);
			Gizmos.DrawLine(vector2 + center, vector6 + center);
			Gizmos.DrawLine(vector7 + center, vector3 + center);
			Gizmos.DrawLine(vector8 + center, vector4 + center);
			Gizmos.DrawLine(vector8 + center, vector6 + center);
			Gizmos.DrawLine(vector5 + center, vector7 + center);
			Gizmos.DrawLine(vector5 + center, vector6 + center);
			Gizmos.DrawLine(vector8 + center, vector7 + center);
			if (Outline)
			{
				return;
			}
			_ = Vector3.zero;
			Vector3 zero = Vector3.zero;
			for (int i = 0; i <= cellCountY; i++)
			{
				for (int j = 0; j <= cellCountZ; j++)
				{
					Vector3 vector9 = new Vector3(-1f * num, -1f * num2 + (float)i * cellSizeY, -1f * num3 + (float)j * cellSizeZ);
					Gizmos.DrawLine(to: new Vector3(1f * num, -1f * num2 + (float)i * cellSizeY, -1f * num3 + (float)j * cellSizeZ) + center, from: vector9 + center);
				}
			}
			for (int k = 0; k <= cellCountX; k++)
			{
				for (int l = 0; l <= cellCountZ; l++)
				{
					Vector3 vector10 = new Vector3(-1f * num + (float)k * cellSizeX, -1f * num2, -1f * num3 + (float)l * cellSizeZ);
					Gizmos.DrawLine(to: new Vector3(-1f * num + (float)k * cellSizeX, 1f * num2, -1f * num3 + (float)l * cellSizeZ) + center, from: vector10 + center);
				}
			}
			for (int m = 0; m <= cellCountX; m++)
			{
				for (int n = 0; n <= cellCountY; n++)
				{
					Vector3 vector11 = new Vector3(-1f * num + (float)m * cellSizeX, -1f * num2 + (float)n * cellSizeY, -1f * num3);
					Gizmos.DrawLine(to: new Vector3(-1f * num + (float)m * cellSizeX, -1f * num2 + (float)n * cellSizeY, 1f * num3) + center, from: vector11 + center);
				}
			}
		}
	}
}
