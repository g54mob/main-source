using System;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor.Islands
{
	[CreateAssetMenu(menuName = "Factory/Islands/CurrentEditingIsland", fileName = "CurrentEditingIsland", order = 0)]
	public class CurrentEditingIsland : ScriptableObject
	{
		private IslandData _islandData;

		private int _createdID;

		public Guid Id => _islandData.Id;

		public Texture2D Texture2D
		{
			get
			{
				if (!Empty)
				{
					return _islandData.Texture2D;
				}
				return null;
			}
		}

		public bool Empty => _islandData == null;

		public IslandData IslandData => _islandData;

		public int CreatedId => _createdID;

		public event Action ValueChanged = delegate
		{
		};

		public Color32[] GetFloorTextureToArray()
		{
			return _islandData.GetFloorTextureToArray();
		}

		public void SetCurrentIsland(int createdId, IslandData islandData)
		{
			_createdID = createdId;
			_islandData = islandData;
			this.ValueChanged();
		}

		public void NewId()
		{
			_createdID = IntIdGenerator.GetNewId;
			_islandData.NewId();
			this.ValueChanged();
		}

		public bool PaintTexture(Vector3Int position, Color32 color, out Color32 previousColor)
		{
			return _islandData.PaintTexture(position, color, out previousColor);
		}

		public void SetTexturePixels(Color32[] floorTextureColors)
		{
			_islandData.SetTexturePixels(floorTextureColors);
		}
	}
}
