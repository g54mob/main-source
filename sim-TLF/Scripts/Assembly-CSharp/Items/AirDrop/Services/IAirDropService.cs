using Items.Box;
using UnityEngine;

namespace Items.AirDrop.Services
{
	public interface IAirDropService
	{
		ParachuteHolder SpawnAirDrop(ItemBoxView box, Vector3 worldPos);
	}
}
