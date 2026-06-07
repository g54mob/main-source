using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;
using Vectrosity;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class DisplayGrid : MonoBehaviour
	{
		public int FieldWidth;

		public float LineWidth;

		public int SizeX;

		public int SizeY;

		public float OffsetX;

		public float OffsetY;

		public Material LineMaterial;

		internal float Alpha;

		private Material _material;

		private VectorLine _gridLine;

		private Color _color;

		public void Start()
		{
			_material = new Material(LineMaterial);
			_color = RuntimeGlobals.Settings.GridColor;
			Alpha = 0.2f;
			MakeGrid();
		}

		public void SetColor(Color color)
		{
			_color = color;
		}

		public void Update()
		{
			UpdateColor();
		}

		private void UpdateColor()
		{
			_color.a = Alpha;
			_material.SetColor("_TintColor", _color);
		}

		public void MakeGrid()
		{
			_gridLine = new VectorLine("Grid", new Vector3[2], _material, LineWidth);
			Vector3[] array = new Vector3[(SizeX / FieldWidth + 1 + (SizeY / FieldWidth + 1)) * 2];
			_gridLine.Resize(array);
			int num = 0;
			for (int i = 0; (float)i < (float)SizeX - OffsetX; i += FieldWidth)
			{
				array[num++] = new Vector2(OffsetX + (float)i, OffsetY);
				array[num++] = new Vector2(OffsetX + (float)i, SizeY - 2);
			}
			for (int j = 0; (float)j < (float)SizeY - OffsetY; j += FieldWidth)
			{
				array[num++] = new Vector2(OffsetX, OffsetY + (float)j);
				array[num++] = new Vector2(SizeX - 2, OffsetY + (float)j);
			}
			_gridLine.Draw3D(base.transform);
		}
	}
}
