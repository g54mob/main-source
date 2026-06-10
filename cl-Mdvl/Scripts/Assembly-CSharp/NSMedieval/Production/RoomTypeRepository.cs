using System;
using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.RoomDetection;

namespace NSMedieval.Production
{
	[Serializable]
	public class RoomTypeRepository : DynamicJsonRepository<RoomTypeRepository, RoomType>
	{
		public static readonly string DefaultRoomTypeName = "default";

		public static readonly string SingleBedroomTypeName = "bedroom_single";

		public static readonly string SharedBedroomTypeName = "bedroom_shared";

		private RoomType defaultRoomType;

		private RoomType singleBedroomType;

		private RoomType sharedBedroomType;

		private bool roomTypesSortedByPriorityInit;

		private List<RoomType> roomTypesSortedByPriority;

		public RoomType DefaultRoomType
		{
			get
			{
				if (defaultRoomType == null)
				{
					defaultRoomType = GetByID(DefaultRoomTypeName);
				}
				return defaultRoomType;
			}
		}

		public RoomType SingleBedroomType
		{
			get
			{
				if (singleBedroomType == null)
				{
					singleBedroomType = GetByID(SingleBedroomTypeName);
				}
				return singleBedroomType;
			}
		}

		public RoomType SharedBedroomType
		{
			get
			{
				if (sharedBedroomType == null)
				{
					sharedBedroomType = GetByID(SharedBedroomTypeName);
				}
				return sharedBedroomType;
			}
		}

		public IReadOnlyList<RoomType> GetRoomTypesByPriority()
		{
			if (roomTypesSortedByPriorityInit)
			{
				return roomTypesSortedByPriority;
			}
			InitRoomTypesByPriority();
			return roomTypesSortedByPriority;
		}

		protected override string JsonFile()
		{
			return "Data/RoomTypes.json";
		}

		private void InitRoomTypesByPriority()
		{
			roomTypesSortedByPriority = new List<RoomType>();
			roomTypesSortedByPriority.AddRange(GetAllItems());
			roomTypesSortedByPriority.Sort((RoomType a, RoomType b) => b.Priority - a.Priority);
			roomTypesSortedByPriorityInit = true;
		}
	}
}
