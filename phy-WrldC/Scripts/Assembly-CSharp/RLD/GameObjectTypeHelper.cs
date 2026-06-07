using System;
using System.Collections.Generic;

namespace RLD
{
	public static class GameObjectTypeHelper
	{
		private static int _numTypes;

		private static List<GameObjectType> _allObjectTypes;

		private static GameObjectType _allCombined;

		public static int NumTypes => _numTypes;

		public static GameObjectType[] AllObjectTypes => _allObjectTypes.ToArray();

		public static GameObjectType AllCombined => _allCombined;

		static GameObjectTypeHelper()
		{
			_allCombined = GameObjectType.Mesh | GameObjectType.Terrain | GameObjectType.Sprite | GameObjectType.Camera | GameObjectType.Light | GameObjectType.ParticleSystem | GameObjectType.Empty;
			Array values = Enum.GetValues(typeof(GameObjectType));
			_numTypes = values.Length;
			_allObjectTypes = new List<GameObjectType>(_numTypes);
			foreach (object item in values)
			{
				_allObjectTypes.Add((GameObjectType)item);
			}
		}

		public static bool Is3DObjectType(GameObjectType objectType)
		{
			return objectType != GameObjectType.Sprite;
		}

		public static bool Is2DObjectType(GameObjectType objectType)
		{
			return objectType == GameObjectType.Sprite;
		}

		public static bool HasVolume(GameObjectType objectType)
		{
			if (objectType != GameObjectType.Terrain && objectType != GameObjectType.Mesh)
			{
				return objectType == GameObjectType.Sprite;
			}
			return true;
		}

		public static bool IsTypeBitSet(int objectTypeMask, GameObjectType typeBit)
		{
			return ((uint)objectTypeMask & (uint)typeBit) != 0;
		}

		public static int SetTypeBit(int objectTypeMask, GameObjectType typeBit)
		{
			return objectTypeMask | (int)typeBit;
		}

		public static int ClearTypeBit(int objectTypeMask, GameObjectType typeBit)
		{
			return objectTypeMask & (int)(~typeBit);
		}
	}
}
