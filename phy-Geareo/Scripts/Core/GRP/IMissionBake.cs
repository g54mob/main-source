using System.Threading.Tasks;

namespace GRP
{
	public interface IMissionBake
	{
		Task BakeMission(BakedMission mission, ProgressTaskGroup task);
	}
}
