using FoxyVoxel.Logging;
using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class SoundRepository : MonoRepository<SoundRepository, SoundEvent>
	{
		public string GetPathByID(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return string.Empty;
			}
			SoundEvent byID = GetByID(id);
			if (byID != null)
			{
				return byID.Path;
			}
			Log.Warning("Sound " + id + " not found in Global.prefab > SoundRepository", "C:\\GIT\\dev\\Assets\\Scripts\\Repository\\Sound\\SoundRepository.cs");
			return string.Empty;
		}

		public bool AddNewSound(SoundEvent soundEvent)
		{
			if (dictionary.ContainsKey(soundEvent.GetID()))
			{
				return false;
			}
			Add(soundEvent);
			return true;
		}

		public bool EventExists(string eventId)
		{
			return dictionary.ContainsKey(eventId);
		}
	}
}
