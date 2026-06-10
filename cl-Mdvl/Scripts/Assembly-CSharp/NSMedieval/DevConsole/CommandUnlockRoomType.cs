using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Production;
using NSMedieval.RoomDetection;

namespace NSMedieval.DevConsole
{
	public class CommandUnlockRoomType : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandUnlockRoomType()
		{
			Command = "unlockRoomType";
			Description = "Unlocks the given room type.";
			Help = "Usage: unlockRoomType <roomType:string>";
		}

		private static string GetRoomTypesString()
		{
			return string.Join(", ", (from rt in Repository<RoomTypeRepository, RoomType>.Instance.GetAllItems()
				where rt.Locked
				select rt).ToList().ConvertAll((RoomType rt) => (!RoomType.IsRoomTypeUnlocked(rt)) ? rt.GetID() : (rt.GetID() + " [unlocked]")));
		}

		private void CommandMethod()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(Help + "\nAvailable lockable room types:\n   " + GetRoomTypesString());
		}

		private void CommandMethod(string roomTypeName)
		{
			RoomType byID = Repository<RoomTypeRepository, RoomType>.Instance.GetByID(roomTypeName);
			if (byID == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("RoomType with id " + roomTypeName + " not found in RoomTypes.json.\nAvailable lockable room types:\n   " + GetRoomTypesString());
				return;
			}
			string result = (byID.Unlock() ? ("Unlocked room type " + roomTypeName) : ("Didn't unlock room type " + roomTypeName + " - " + (byID.Locked ? "room type is already unlocked" : "room type is not lockable") + "."));
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}
	}
}
