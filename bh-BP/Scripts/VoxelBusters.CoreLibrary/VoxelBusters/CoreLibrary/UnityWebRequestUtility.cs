using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace VoxelBusters.CoreLibrary
{
	public static class UnityWebRequestUtility
	{
		public static Task<string> ToTask(this UnityWebRequest request, CancellationToken cancellationToken)
		{
			return null;
		}
	}
}
