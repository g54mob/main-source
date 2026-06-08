using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kitchen.Layouts
{
	[CreateAssetMenu(fileName = "LayoutDesign", menuName = "Kitchen/Layout Design", order = 1)]
	public class LayoutDesign : SerializedScriptableObject
	{
		public class ColorRoom
		{
			public Room Room;

			public Color Color;

			[HideInInspector]
			public bool RequestPaint;

			private void SetRequestPaint()
			{
				RequestPaint = true;
			}
		}

		public class ColorFeature
		{
			public FeatureType Feature;

			public Color Color;

			[HideInInspector]
			public bool RequestPaint;

			private void SetRequestPaint()
			{
				RequestPaint = true;
			}
		}

		public class DesignRoom
		{
			public int Room;

			public bool HasBottomFeature;

			public bool HasRightFeature;

			public int BottomFeature;

			public int RightFeature;
		}

		public List<ColorRoom> RoomSet = new List<ColorRoom>();

		public List<ColorFeature> FeatureSet = new List<ColorFeature>();

		public DesignRoom[,] Rooms;

		private bool PaintFeatures;

		private int PaintColour;

		private (bool, int) GetPaint()
		{
			for (int i = 0; i < RoomSet.Count; i++)
			{
				ColorRoom colorRoom = RoomSet[i];
				if (colorRoom.RequestPaint)
				{
					PaintColour = i;
					PaintFeatures = false;
					colorRoom.RequestPaint = false;
				}
			}
			for (int j = 0; j < FeatureSet.Count; j++)
			{
				ColorFeature colorFeature = FeatureSet[j];
				if (colorFeature.RequestPaint)
				{
					PaintColour = j;
					PaintFeatures = true;
					colorFeature.RequestPaint = false;
				}
			}
			return (PaintFeatures, PaintColour);
		}

		private void Resize(int w, int h)
		{
			if (Rooms == null)
			{
				Rooms = new DesignRoom[w, h];
			}
			else
			{
				Rooms = ResizeArray(Rooms, w, h);
			}
		}

		private int NextRoom(int value)
		{
			return (RoomSet.Count + value + 1) % RoomSet.Count;
		}

		private ColorRoom GetRoom(int index)
		{
			if (index < 0)
			{
				return RoomSet[0];
			}
			return RoomSet[index];
		}

		private FeatureType GetFeature(int index)
		{
			if (index < 0)
			{
				return FeatureType.Generic;
			}
			return FeatureSet[index].Feature;
		}

		private int RoomIndex(Room value)
		{
			for (int i = 0; i < RoomSet.Count; i++)
			{
				if (RoomSet[i].Room.ID == value.ID)
				{
					return i;
				}
			}
			return -1;
		}

		protected T[,] ResizeArray<T>(T[,] original, int x, int y)
		{
			T[,] array = new T[x, y];
			int length = Math.Min(original.GetLength(0), array.GetLength(0));
			int num = Math.Min(original.GetLength(1), array.GetLength(1));
			for (int i = 0; i < num; i++)
			{
				Array.Copy(original, i * original.GetLength(0), array, i * array.GetLength(0), length);
			}
			return array;
		}
	}
}
