using System.Collections;

namespace VoxelBusters.CoreLibrary
{
	public interface IScheduler
	{
		event Callback Update;

		void StartCoroutine(IEnumerator routine);

		void StopCoroutine(IEnumerator routine);

		void StopAllCoroutines();
	}
}
